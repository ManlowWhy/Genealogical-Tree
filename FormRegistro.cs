using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace MapaTest
{
    public enum TipoRelacion
    {
        Libre,
        Hijo,
        Padre,
        Hermano
    }

    public partial class FormRegistro : Form
    {
        public Persona PersonaCreada { get; private set; }
        public bool CloseOnSave { get; set; } = false;

        public Persona PersonaReferencia { get; private set; }
        public TipoRelacion TipoRelacionActual { get; private set; } = TipoRelacion.Libre;

        public FormRegistro()
        {
            InitializeComponent();
            panelArbol.Paint += panelArbol_Paint;
        }

        // Constructor con lat/lng, ahora sin imponer parentezco
        public FormRegistro(double lat, double lng,
                    TipoRelacion tipoRelacion = TipoRelacion.Libre,
                    Persona personaReferencia = null) : this()
        {
            textBoxLatitud.Text = lat.ToString(CultureInfo.InvariantCulture);
            textBoxLongitud.Text = lng.ToString(CultureInfo.InvariantCulture);
            CloseOnSave = true;

            TipoRelacionActual = tipoRelacion;
            PersonaReferencia = personaReferencia;
            // Ya NO tocamos comboBoxParentezco: las personas se crean sin parentezco obligatorio.
        }

        // ===================== Árbol (igual que antes) =====================

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
            panelArbol.Invalidate();
        }

        private class NodoVista
        {
            public Persona Persona { get; set; }
            public List<NodoVista> Hijos { get; } = new List<NodoVista>();
            public int Nivel { get; set; } = 0;
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

            // 1) Todas las personas que existen
            var personas = DatosGlobales.Familia.ToList();
            if (personas.Count == 0) return;

            // 2) Crear un NodoVista por cada persona (clave = cédula)
            var nodos = new Dictionary<string, NodoVista>();
            foreach (var p in personas)
            {
                if (!string.IsNullOrWhiteSpace(p.Cedula) && !nodos.ContainsKey(p.Cedula))
                {
                    nodos[p.Cedula] = new NodoVista { Persona = p };
                }
            }
            if (nodos.Count == 0) return;

            // 3) Armar padre–hijo usando tus relaciones hechas “a mano”
            var padresCount = new Dictionary<string, int>();
            var padresPorCedula = new Dictionary<string, List<NodoVista>>();

            foreach (var ced in nodos.Keys)
                padresCount[ced] = 0;

            foreach (var rel in RelacionesFamilia.Relaciones)
            {
                if (!nodos.ContainsKey(rel.CedulaPadre) || !nodos.ContainsKey(rel.CedulaHijo))
                    continue;

                var padre = nodos[rel.CedulaPadre];
                var hijo = nodos[rel.CedulaHijo];

                if (!padre.Hijos.Contains(hijo))
                    padre.Hijos.Add(hijo);

                padresCount[rel.CedulaHijo]++;

                // Construimos también la lista de padres para cada hijo
                if (!padresPorCedula.TryGetValue(rel.CedulaHijo, out var listaPadres))
                {
                    listaPadres = new List<NodoVista>();
                    padresPorCedula[rel.CedulaHijo] = listaPadres;
                }
                if (!listaPadres.Contains(padre))
                    listaPadres.Add(padre);
            }

            // 4) Calcular "profundidad hacia abajo" empezando desde los hijos (sin hijos propios)
            // depth[ced] = 0 para hojas, luego padres = max(hijos) + 1
            var depth = new Dictionary<string, int>();
            foreach (var kv in nodos)
                depth[kv.Key] = 0;

            var cola = new Queue<NodoVista>();
            var enCola = new HashSet<string>();

            // Hojas = personas sin hijos
            foreach (var n in nodos.Values)
            {
                if (n.Hijos.Count == 0)
                {
                    cola.Enqueue(n);
                    enCola.Add(n.Persona.Cedula);
                }
            }

            while (cola.Count > 0)
            {
                var actual = cola.Dequeue();
                int dActual = depth[actual.Persona.Cedula];

                // Propagamos hacia los padres
                if (padresPorCedula.TryGetValue(actual.Persona.Cedula, out var listaPadres))
                {
                    foreach (var padre in listaPadres)
                    {
                        var cedP = padre.Persona.Cedula;
                        int old = depth[cedP];
                        int proposed = dActual + 1;

                        if (proposed > old)
                        {
                            depth[cedP] = proposed;
                            if (!enCola.Contains(cedP))
                            {
                                cola.Enqueue(padre);
                                enCola.Add(cedP);
                            }
                        }
                    }
                }
            }

            // Si no había relaciones, todos se quedan con depth 0
            int maxDepth = depth.Values.DefaultIfEmpty(0).Max();

            // Convertimos la "profundidad" en Nivel de dibujo:
            // más profundidad => generación más nueva => va más abajo.
            // Nivel = maxDepth - depth
            foreach (var kv in nodos)
            {
                string ced = kv.Key;
                kv.Value.Nivel = maxDepth - depth[ced];
            }

            // 5) Layout: agrupar por nivel y dibujar nodos
            int nodoAncho = 160;
            int nodoAlto = 60;
            int margenX = 20;
            int margenY = 20;
            int espacioX = 30;
            int espacioY = 60;

            var niveles = nodos.Values
                .GroupBy(n => n.Nivel)
                .OrderBy(gp => gp.Key);

            var rectPorCedula = new Dictionary<string, Rectangle>();

            foreach (var grupo in niveles)
            {
                int nivel = grupo.Key;
                int y = margenY + nivel * (nodoAlto + espacioY);
                int x = margenX;

                foreach (var nodo in grupo)
                {
                    var rect = new Rectangle(x, y, nodoAncho, nodoAlto);
                    g.FillRectangle(Brushes.LightBlue, rect);
                    g.DrawRectangle(Pens.Black, rect);

                    // Zona de imagen a la izquierda (cuadrito)
                    int imgSize = nodoAlto - 10;
                    var rectImg = new Rectangle(rect.X + 5, rect.Y + 5, imgSize, imgSize);

                    // Dibujar imagen si existe
                    if (!string.IsNullOrWhiteSpace(nodo.Persona.RutaFoto) &&
                        File.Exists(nodo.Persona.RutaFoto))
                    {
                        try
                        {
                            using (var imgTemp = Image.FromFile(nodo.Persona.RutaFoto))
                            using (var img = new Bitmap(imgTemp)) // clonar
                            {
                                g.DrawImage(img, rectImg);
                            }
                        }
                        catch
                        {
                            // si falla la imagen, simplemente no se dibuja
                        }
                    }
                    else
                    {
                        // Si no hay imagen, dibujamos un placeholder
                        g.FillRectangle(Brushes.Gray, rectImg);
                        g.DrawRectangle(Pens.Black, rectImg);
                    }

                    // Texto a la derecha de la imagen
                    int textoX = rectImg.Right + 5;
                    int textoY = rect.Y + 5;

                    string texto = nodo.Persona.Nombre;
                    if (!string.IsNullOrWhiteSpace(nodo.Persona.Parentezco))
                        texto += $"\n{nodo.Persona.Parentezco}";
                    texto += $"\n({nodo.Persona.Latitud:F4}, {nodo.Persona.Longitud:F4})";

                    g.DrawString(texto, this.Font, Brushes.Black, textoX, textoY);

                    rectPorCedula[nodo.Persona.Cedula] = rect;
                    x += nodoAncho + espacioX;
                }
            }

            // 6) Dibujar líneas padre–hijo
            using (var pen = new Pen(Color.Black, 2))
            {
                foreach (var rel in RelacionesFamilia.Relaciones)
                {
                    if (!rectPorCedula.ContainsKey(rel.CedulaPadre) ||
                        !rectPorCedula.ContainsKey(rel.CedulaHijo))
                        continue;

                    var rectPadre = rectPorCedula[rel.CedulaPadre];
                    var rectHijo = rectPorCedula[rel.CedulaHijo];

                    var p1 = new Point(rectPadre.X + rectPadre.Width / 2, rectPadre.Bottom);
                    var p2 = new Point(rectHijo.X + rectHijo.Width / 2, rectHijo.Top);

                    g.DrawLine(pen, p1, p2);
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
            // ⚠️ AHORA NO OBLIGAMOS A ELEGIR PARENTEZCO
            // if (string.IsNullOrWhiteSpace(comboBoxParentezco.Text)) ...

            DateTime fechaNacimientoValida = dtpNacimiento.Value;
            if (fechaNacimientoValida > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.",
                    "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int edadEntera = (int)Math.Floor((DateTime.Today - fechaNacimientoValida).TotalDays / 365.2425);
            if (!string.IsNullOrWhiteSpace(textBoxEdad.Text))
            {
                if (!double.TryParse(textBoxEdad.Text, NumberStyles.Any, culture, out double edadValida))
                {
                    MessageBox.Show("Por favor, ingrese la Edad como un número válido.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxEdad.Focus(); return;
                }
                edadEntera = (int)Math.Round(edadValida);
            }

            if (!double.TryParse(textBoxLatitud.Text, NumberStyles.Any, culture, out double latitudValida) ||
                latitudValida < -90 || latitudValida > 90)
            {
                MessageBox.Show("Ingrese una Latitud válida en [-90, 90] (use '.' como separador decimal).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLatitud.Focus(); return;
            }

            if (!double.TryParse(textBoxLongitud.Text, NumberStyles.Any, culture, out double longitudValida) ||
                longitudValida < -180 || longitudValida > 180)
            {
                MessageBox.Show("Ingrese una Longitud válida en [-180, 180] (use '.' como separador decimal).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLongitud.Focus(); return;
            }

            if (!string.IsNullOrWhiteSpace(textBoxRutaFoto.Text) && !File.Exists(textBoxRutaFoto.Text))
            {
                var r = MessageBox.Show("La ruta de la foto no existe. ¿Desea continuar sin foto?", "Advertencia",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.No) { textBoxRutaFoto.Focus(); return; }
            }

            var persona = new Persona
            {
                Nombre = textBoxNombre.Text.Trim(),
                Cedula = textBoxCedula.Text.Trim(),
                FechaNacimiento = fechaNacimientoValida.ToString("yyyy-MM-dd"),
                Edad = edadEntera.ToString("F0", culture),
                Parentezco = comboBoxParentezco.Text,  // puede estar vacío
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

            List<string> padres = ObtenerPadresSegunParentezco(persona.Parentezco);

            GrafoFamiliar.AgregarNodo(nodo);
            DatosGlobales.Familia.Add(persona);

            DibujarArbol();

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
            var mapa = new FormMapa();
            mapa.Show();
        }

        private void labelEdad_Click(object sender, EventArgs e) { }

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
            dtpNacimiento.MaxDate = DateTime.Today;
            dtpNacimiento.MinDate = new DateTime(1900, 1, 1);
            textBoxEdad.Text = CalcularEdad(dtpNacimiento.Value).ToString();
        }

        private void groupBoxUbicacion_Enter(object sender, EventArgs e) { }
        private void groupBoxDatosPersona_Enter(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }

        public void CargarParaEdicion(Persona p)
        {
            if (p == null) return;

            textBoxNombre.Text = p.Nombre;
            textBoxCedula.Text = p.Cedula;

            if (DateTime.TryParse(p.FechaNacimiento, out var fecha))
            {
                dtpNacimiento.Value = fecha;
            }

            textBoxEdad.Text = p.Edad;
            comboBoxParentezco.Text = p.Parentezco;

            textBoxLatitud.Text = p.Latitud.ToString(CultureInfo.InvariantCulture);
            textBoxLongitud.Text = p.Longitud.ToString(CultureInfo.InvariantCulture);

            textBoxRutaFoto.Text = p.RutaFoto ?? string.Empty;
        }

        private void labelFoto_Click(object sender, EventArgs e)
        {

        }

        private void buttonBuscarFoto_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar foto del familiar";
                ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Multiselect = false;

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    textBoxRutaFoto.Text = ofd.FileName;

                    try
                    {
                        using (var imgTemp = Image.FromFile(ofd.FileName))
                        {
                            pictureFoto.Image = new Bitmap(imgTemp);
                        }
                        pictureFoto.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo cargar la imagen seleccionada.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
