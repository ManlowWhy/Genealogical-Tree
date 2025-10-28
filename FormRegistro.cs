
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


namespace MapaTest
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
            panelArbol.Paint += panelArbol_Paint;
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
            {
                nodo.Hijos.Clear();
            }

            foreach (var posibleHijo in GrafoFamiliar.Nodos.Values)
            {
                var padresEsperados = ObtenerPadresSegunParentezco(posibleHijo.Parentezco);

                foreach (var parentezcoPadre in padresEsperados)
                {
                    if (GrafoFamiliar.Nodos.ContainsKey(parentezcoPadre))
                    {
                        var padreNodo = GrafoFamiliar.Nodos[parentezcoPadre];
                        if (!padreNodo.Hijos.Contains(posibleHijo))
                        {
                            padreNodo.Hijos.Add(posibleHijo);
                        }
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

            const string formatoFecha = "dd/MM/yyyy";
            var culture = CultureInfo.InvariantCulture;

            DateTime fechaNacimientoValida;
            if (!DateTime.TryParseExact(
                textBoxFechaNaci.Text,
                formatoFecha,
                culture,
                DateTimeStyles.None,
                out fechaNacimientoValida))
            {
                MessageBox.Show($"Por favor, ingrese la Fecha de Nacimiento exactamente en el formato: {formatoFecha}", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFechaNaci.Focus();
                return; // Detiene la ejecución
            }

            double edadValida;
            if (!double.TryParse(textBoxEdad.Text, System.Globalization.NumberStyles.Any, culture, out edadValida))
            {
                MessageBox.Show("Por favor, ingrese la Edad como un número válido.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEdad.Focus();
                return;
            }

            double latitudValida;
            if (!double.TryParse(textBoxLatitud.Text, System.Globalization.NumberStyles.Any, culture, out latitudValida))
            {
                MessageBox.Show("Ingrese una Latitud válida (use el punto '.' como separador decimal).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLatitud.Focus();
                return;
            }

            double longitudValida;
            if (!double.TryParse(textBoxLongitud.Text, System.Globalization.NumberStyles.Any, culture, out longitudValida))
            {
                MessageBox.Show("Ingrese una Longitud válida (use el punto '.' como separador decimal).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLongitud.Focus();
                return;
            }

            var persona = new Persona
            {
                Nombre = textBoxNombre.Text,
                Cedula = textBoxCedula.Text,
                FechaNacimiento = fechaNacimientoValida.ToString("yyyy-MM-dd"),
                Edad = edadValida.ToString("F0"),
                Parentezco = comboBoxParentezco.Text,
                Latitud = latitudValida,
                Longitud = longitudValida,
                RutaFoto = textBoxRutaFoto.Text
            };

            var nodo = new NodoFamiliar
            {
                Nombre = persona.Nombre,
                Parentezco = persona.Parentezco,
                Latitud = persona.Latitud,
                Longitud = persona.Longitud
            };

            // Determinar el padre según el parentezco
            List<string> padres = ObtenerPadresSegunParentezco(persona.Parentezco);


            // Agregar al grafo
            GrafoFamiliar.AgregarNodo(nodo);

            DibujarArbol();

            DatosGlobales.Familia.Add(persona);

            MessageBox.Show("Familiar agregado correctamente.");
        }

        private void buttonVerMapa_Click(object sender, EventArgs e)
        {
            if (DatosGlobales.Familia.Count == 0)
            {
                MessageBox.Show("Agrega al menos un familiar antes de ver el mapa.");
                return;
            }

            var mapa = new FormMapa();
            mapa.Show();
        }
    }
}

