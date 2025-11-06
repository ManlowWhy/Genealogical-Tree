using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace MapaTest
{
    public partial class FormRegistro : Form
    {
        // >>> Nuevo: expone la persona creada y permite cerrar automático al guardar
        public Persona PersonaCreada { get; private set; }
        public bool CloseOnSave { get; set; } = false;

        // Constructor original
        public FormRegistro()
        {
            InitializeComponent();
            panelArbol.Paint += panelArbol_Paint;
        }

        // >>> Nuevo: constructor con lat/lng prellenados
        public FormRegistro(double lat, double lng) : this()
        {
            // Prellenar cajas de texto con invariante (punto decimal)
            textBoxLatitud.Text = lat.ToString(CultureInfo.InvariantCulture);
            textBoxLongitud.Text = lng.ToString(CultureInfo.InvariantCulture);
            CloseOnSave = true; // por defecto, si vengo del mapa, cierro al guardar
        }

        private List<string> ObtenerPadresSegunParentezco(string parentezco)
        {
            switch (parentezco)
            {
                case "Madre":
                    return new List<string> { "Abuela Materna", "Abuelo Materno" };
                case "Padre":
                    return new List<string> { "Abuela Paterna", "Abuelo Paterno" };
                case "Hijo":
                case "Hija":
                    return new List<string> { "Madre", "Padre" };
                default:
                    return new List<string>();
            }
        }

        private void ReconectarGrafo()
        {
            foreach (var nodo in GrafoFamiliar.Nodos.Values)
                nodo.Hijos.Clear();

            foreach (var posibleHijo in GrafoFamiliar.Nodos.Values)
            {
                var padresEsperados = ObtenerPadresSegunParentezco(posibleHijo.Parentezco);
                foreach (var parentezcoPadre in padresEsperados)
                {
                    if (GrafoFamiliar.Nodos.ContainsKey(parentezcoPadre))
                    {
                        var padreNodo = GrafoFamiliar.Nodos[parentezcoPadre];
                        if (!padreNodo.Hijos.Contains(posibleHijo))
                            padreNodo.Hijos.Add(posibleHijo);
                    }
                }
            }
        }

        private void DibujarArbol()
        {
            ReconectarGrafo();
            panelArbol.Invalidate();
        }

        private int ObtenerNivelGeneracional(string parentezco)
        {
            switch (parentezco)
            {
                case "Abuela Materna":
                case "Abuelo Materno":
                case "Abuela Paterna":
                case "Abuelo Paterno":
                    return 0;
                case "Madre":
                case "Padre":
                    return 1;
                case "Hijo":
                case "Hija":
                    return 2;
                default:
                    return 3;
            }
        }

        private void panelArbol_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int nivelY = 30;
            int espacioX = 150;
            int nodoAncho = 120;
            int nodoAlto = 50;

            var niveles = new Dictionary<int, List<NodoFamiliar>>();
            var posiciones = new Dictionary<NodoFamiliar, Point>();

            // Agrupar nodos por generación
            foreach (var nodo in GrafoFamiliar.Nodos.Values)
            {
                int nivel = ObtenerNivelGeneracional(nodo.Parentezco);
                if (!niveles.ContainsKey(nivel))
                    niveles[nivel] = new List<NodoFamiliar>();
                niveles[nivel].Add(nodo);
            }

            foreach (var nivel in niveles.Keys.OrderBy(k => k))
            {
                int y = nivelY + nivel * 100;
                int x = 30;

                foreach (var nodo in niveles[nivel])
                {
                    var rect = new Rectangle(x, y, nodoAncho, nodoAlto);
                    g.FillRectangle(Brushes.LightBlue, rect);
                    g.DrawRectangle(Pens.Black, rect);
                    g.DrawString($"{nodo.Parentezco}\n{nodo.Nombre}\n({nodo.Latitud}, {nodo.Longitud})", this.Font, Brushes.Black, x + 5, y + 5);

                    posiciones[nodo] = new Point(x + nodoAncho / 2, y);
                    x += espacioX;
                }
            }

            using (var redPen = new Pen(Color.Black, 2))
            {
                foreach (var padre in GrafoFamiliar.Nodos.Values)
                {
                    foreach (var hijo in padre.Hijos)
                    {
                        if (posiciones.ContainsKey(padre) && posiciones.ContainsKey(hijo))
                        {
                            var p1 = posiciones[padre];
                            var p2 = posiciones[hijo];
                            g.DrawLine(redPen, p1.X, p1.Y + nodoAlto, p2.X, p2.Y);
                        }
                    }
                }
            }
        }

        private void buttonAgregarFamiliar_Click(object sender, EventArgs e)
        {
            
            var culture = CultureInfo.InvariantCulture;

            // === Validaciones de entrada ===
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                MessageBox.Show("Ingrese el Nombre.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNombre.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(textBoxCedula.Text))
            {
                MessageBox.Show("Ingrese la Cédula.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCedula.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxParentezco.Text))
            {
                MessageBox.Show("Seleccione el Parentezco.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxParentezco.Focus(); return;
            }

            // Tomar la fecha directamente del calendario
            DateTime fechaNacimientoValida = dtpNacimiento.Value;

            // Validación simple: no permitir fechas futuras
            if (fechaNacimientoValida > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.",
                    "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Edad: si no teclean, la calculo; si teclean, valido número
            int edadEntera = (int)Math.Floor((DateTime.Today - fechaNacimientoValida).TotalDays / 365.2425);
            if (!string.IsNullOrWhiteSpace(textBoxEdad.Text))
            {
                double edadValida;
                if (!double.TryParse(textBoxEdad.Text, NumberStyles.Any, culture, out edadValida))
                {
                    MessageBox.Show("Por favor, ingrese la Edad como un número válido.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxEdad.Focus(); return;
                }
                edadEntera = (int)Math.Round(edadValida);
            }

            double latitudValida;
            if (!double.TryParse(textBoxLatitud.Text, NumberStyles.Any, culture, out latitudValida) ||
                latitudValida < -90 || latitudValida > 90)
            {
                MessageBox.Show("Ingrese una Latitud válida en [-90, 90] (use '.' como separador decimal).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLatitud.Focus(); return;
            }

            double longitudValida;
            if (!double.TryParse(textBoxLongitud.Text, NumberStyles.Any, culture, out longitudValida) ||
                longitudValida < -180 || longitudValida > 180)
            {
                MessageBox.Show("Ingrese una Longitud válida en [-180, 180] (use '.' como separador decimal).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLongitud.Focus(); return;
            }

            if (!string.IsNullOrWhiteSpace(textBoxRutaFoto.Text) && !File.Exists(textBoxRutaFoto.Text))
            {
                var r = MessageBox.Show("La ruta de la foto no existe. ¿Desea continuar sin foto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.No) { textBoxRutaFoto.Focus(); return; }
            }

            // === Construir Persona y Nodo ===
            var persona = new Persona
            {
                Nombre = textBoxNombre.Text.Trim(),
                Cedula = textBoxCedula.Text.Trim(),
                FechaNacimiento = fechaNacimientoValida.ToString("yyyy-MM-dd"),
                Edad = edadEntera.ToString("F0", culture),
                Parentezco = comboBoxParentezco.Text,
                Latitud = latitudValida,
                Longitud = longitudValida,
                RutaFoto = textBoxRutaFoto.Text.Trim()
            };

            var nodo = new NodoFamiliar
            {
                Nombre = persona.Nombre,
                Parentezco = persona.Parentezco,
                Latitud = persona.Latitud,
                Longitud = persona.Longitud
            };

            // Determinar padres (por tu esquema actual basado en texto)
            List<string> padres = ObtenerPadresSegunParentezco(persona.Parentezco);

            // Agregar al grafo (tu estructura actual basada en parentezco como clave)
            GrafoFamiliar.AgregarNodo(nodo);

            // Agregar a la lista global para el mapa
            DatosGlobales.Familia.Add(persona);

            // Refrescar árbol
            DibujarArbol();

            // >>> Nuevo: preparar retorno para el caso modal (desde el mapa)
            PersonaCreada = persona;

            if (CloseOnSave || this.Modal)
            {
                DialogResult = DialogResult.OK;
                return;
            }

            MessageBox.Show("Familiar agregado correctamente.");
        }

        private void buttonVerMapa_Click(object sender, EventArgs e)
        {
            // Abrir el mapa siempre, aunque la lista esté vacía
            var mapa = new FormMapa();
            mapa.Show();
        }

        private void labelEdad_Click(object sender, EventArgs e)
        {

        }
        private static int CalcularEdad(DateTime nacimiento)
        {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - nacimiento.Year;
            if (nacimiento.Date > hoy.AddYears(-edad)) edad--;
            return Math.Max(0, edad);
        }

        private void dtpNacimiento_ValueChanged(object sender, EventArgs e)
        {
            textBoxEdad.Text = CalcularEdad(dtpNacimiento.Value).ToString();
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            // Limitar fechas válidas
            dtpNacimiento.MaxDate = DateTime.Today;
            dtpNacimiento.MinDate = new DateTime(1900, 1, 1);

            // Calcular edad al abrir (útil al editar registros)
            textBoxEdad.Text = CalcularEdad(dtpNacimiento.Value).ToString();
        }

    }
}
