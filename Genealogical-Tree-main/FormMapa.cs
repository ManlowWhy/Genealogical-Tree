using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MapaTest
{
    public partial class FormMapa : Form
    {
        private GMapOverlay _overlayRutas;
        private GMapOverlay _overlayEtiquetas;

        // estilo de líneas
        private readonly Pen _penRuta = new Pen(Color.FromArgb(180, 33, 150, 243), 2f)
        {
            StartCap = System.Drawing.Drawing2D.LineCap.Round,
            EndCap = System.Drawing.Drawing2D.LineCap.Round,
            LineJoin = System.Drawing.Drawing2D.LineJoin.Round
        };

        private GMapOverlay _overlayPersonas;
        private ContextMenuStrip _ctxMapa;
        private PointLatLng _lastClickPoint;

        private ContextMenuStrip _ctxMarker;
        private GMapMarker _markerSeleccionado;
        private GMapMarker _markerOrigenConexion; // persona A

        // ítems del menú de conexión
        private ToolStripMenuItem _mnuPadreDe;
        private ToolStripMenuItem _mnuMadreDe;
        private ToolStripMenuItem _mnuHijoDe;
        private ToolStripMenuItem _mnuHijaDe;

        private enum TipoConexion
        {
            PadreDe,
            MadreDe,
            HijoDe,
            HijaDe
        }

        public FormMapa()
        {
            InitializeComponent();
            InicializarMapa();
        }

        private void InicializarMapa()
        {
            // Configuración básica del mapa
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;   // Mapa libre
            GMaps.Instance.Mode = AccessMode.ServerAndCache;          // Cache local
            gMapControl1.Position = new PointLatLng(9.936, -84.09);   // Centro CR por defecto
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 6;
            gMapControl1.ShowCenter = false;
            gMapControl1.DragButton = MouseButtons.Left;

            // Overlays
            _overlayPersonas = new GMapOverlay("personas");
            gMapControl1.Overlays.Add(_overlayPersonas);

            _overlayRutas = new GMapOverlay("rutas");
            _overlayEtiquetas = new GMapOverlay("etiquetas");
            gMapControl1.Overlays.Add(_overlayRutas);
            gMapControl1.Overlays.Add(_overlayEtiquetas);

            // 🔹 MENÚ PARA EL MAPA (click derecho en lugar vacío)
            _ctxMapa = new ContextMenuStrip();
            _ctxMapa.Items.Add("Nuevo miembro aquí", null, (s, e) => CrearMiembroEn(_lastClickPoint));

            // 🔹 MENÚ PARA LOS MARCADORES (click derecho en una persona)
            _ctxMarker = new ContextMenuStrip();

            _mnuPadreDe = new ToolStripMenuItem("", null, (s, e) => ConectarOrigenDestino(TipoConexion.PadreDe));
            _mnuMadreDe = new ToolStripMenuItem("", null, (s, e) => ConectarOrigenDestino(TipoConexion.MadreDe));
            _mnuHijoDe = new ToolStripMenuItem("", null, (s, e) => ConectarOrigenDestino(TipoConexion.HijoDe));
            _mnuHijaDe = new ToolStripMenuItem("", null, (s, e) => ConectarOrigenDestino(TipoConexion.HijaDe));

            _ctxMarker.Items.Add(_mnuPadreDe);
            _ctxMarker.Items.Add(_mnuMadreDe);
            _ctxMarker.Items.Add(_mnuHijoDe);
            _ctxMarker.Items.Add(_mnuHijaDe);
            _ctxMarker.Items.Add(new ToolStripSeparator());
            _ctxMarker.Items.Add("Editar", null, (s, e) => EditarPersonaSeleccionada());
            _ctxMarker.Items.Add("Eliminar", null, (s, e) => EliminarPersonaSeleccionada());

            // 🔹 Mouse (clicks sobre mapa y marcadores)
            gMapControl1.MouseDown += gMapControl1_MouseDown;

            // Cargar marcadores existentes
            CargarMarcadoresIniciales();
        }

        // Detectar si el click cayó sobre algún marcador
        private GMapMarker GetMarkerAt(Point pt)
        {
            foreach (var marker in _overlayPersonas.Markers)
            {
                var pos = gMapControl1.FromLatLngToLocal(marker.Position);

                // pos.X y pos.Y son long → los convertimos a int
                int x = (int)(pos.X + marker.Offset.X);
                int y = (int)(pos.Y + marker.Offset.Y);

                var rect = new Rectangle(x, y, marker.Size.Width, marker.Size.Height);

                if (rect.Contains(pt))
                    return marker;
            }
            return null;
        }

        private void gMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            var marker = GetMarkerAt(e.Location);

            if (e.Button == MouseButtons.Left)
            {
                // Seleccionar origen de conexión
                if (marker != null)
                {
                    _markerOrigenConexion = marker;

                    var ced = marker.Tag as string;
                    var persona = DatosGlobales.Familia.Find(p => p.Cedula == ced);
                    if (persona != null)
                        this.Text = $"Mapa Interactivo - Origen: {persona.Nombre}";
                    else
                        this.Text = "Mapa Interactivo";
                }
                else
                {
                    _markerOrigenConexion = null;
                    this.Text = "Mapa Interactivo";
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (marker != null)
                {
                    // Click derecho SOBRE una persona → menú de marcador
                    _markerSeleccionado = marker;
                    PrepararMenuMarker();
                    _ctxMarker.Show(gMapControl1.PointToScreen(e.Location));
                }
                else
                {
                    // Click derecho en vacío → menú del mapa
                    _lastClickPoint = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                    _ctxMapa.Show(gMapControl1.PointToScreen(e.Location));
                }
            }
        }

        private void PrepararMenuMarker()
        {
            var origen = _markerOrigenConexion != null
                ? DatosGlobales.Familia.Find(p => p.Cedula == (string)_markerOrigenConexion.Tag)
                : null;
            var destino = _markerSeleccionado != null
                ? DatosGlobales.Familia.Find(p => p.Cedula == (string)_markerSeleccionado.Tag)
                : null;

            if (origen == null || destino == null || _markerOrigenConexion == _markerSeleccionado)
            {
                // No hay origen seleccionado válido → deshabilitar opciones de conexión
                _mnuPadreDe.Enabled = false;
                _mnuMadreDe.Enabled = false;
                _mnuHijoDe.Enabled = false;
                _mnuHijaDe.Enabled = false;

                _mnuPadreDe.Text = "Seleccione primero una persona origen (clic izquierdo)";
                _mnuMadreDe.Text = "Seleccione primero una persona origen (clic izquierdo)";
                _mnuHijoDe.Text = "Seleccione primero una persona origen (clic izquierdo)";
                _mnuHijaDe.Text = "Seleccione primero una persona origen (clic izquierdo)";
            }
            else
            {
                string nomO = origen.Nombre;
                string nomD = destino.Nombre;

                _mnuPadreDe.Enabled = true;
                _mnuMadreDe.Enabled = true;
                _mnuHijoDe.Enabled = true;
                _mnuHijaDe.Enabled = true;

                _mnuPadreDe.Text = $"{nomO} es PAPÁ de {nomD}";
                _mnuMadreDe.Text = $"{nomO} es MAMÁ de {nomD}";
                _mnuHijoDe.Text = $"{nomO} es HIJO de {nomD}";
                _mnuHijaDe.Text = $"{nomO} es HIJA de {nomD}";
            }
        }

        private void ConectarOrigenDestino(TipoConexion tipo)
        {
            if (_markerOrigenConexion == null || _markerSeleccionado == null)
                return;

            var cedOrigen = _markerOrigenConexion.Tag as string;
            var cedDestino = _markerSeleccionado.Tag as string;
            if (string.IsNullOrEmpty(cedOrigen) || string.IsNullOrEmpty(cedDestino))
                return;
            if (cedOrigen == cedDestino) return;

            string cedPadre;
            string cedHijo;

            switch (tipo)
            {
                case TipoConexion.PadreDe:
                case TipoConexion.MadreDe:
                    // Origen es padre/madre del destino
                    cedPadre = cedOrigen;
                    cedHijo = cedDestino;
                    break;

                case TipoConexion.HijoDe:
                case TipoConexion.HijaDe:
                    // Origen es hijo/hija del destino → destino es el padre
                    cedPadre = cedDestino;
                    cedHijo = cedOrigen;
                    break;

                default:
                    return;
            }

            RelacionesFamilia.DefinirPadreHijo(cedPadre, cedHijo);

            // Redibujar todas las conexiones
            RedibujarRelaciones();
        }

        private void CargarMarcadoresIniciales()
        {
            _overlayPersonas.Markers.Clear();

            foreach (var persona in DatosGlobales.Familia)
            {
                AgregarMarkerPersona(persona);
            }

            RedibujarRelaciones();
            gMapControl1.Refresh();
        }

        private void CrearMiembroEn(PointLatLng pt)
        {
            using var frm = new FormRegistro(pt.Lat, pt.Lng) { CloseOnSave = true };
            if (frm.ShowDialog(this) == DialogResult.OK && frm.PersonaCreada != null)
            {
                AgregarMarkerPersona(frm.PersonaCreada);
                RedibujarRelaciones();
                gMapControl1.Refresh();
            }
        }

        private void AgregarMarkerPersona(Persona p)
        {
            GMapMarker marker;

            if (!string.IsNullOrWhiteSpace(p.RutaFoto) && File.Exists(p.RutaFoto))
            {
                using var original = (Bitmap)Image.FromFile(p.RutaFoto);
                using var scaled = new Bitmap(original, new Size(48, 48));
                var icon = Redondear(scaled, 48);
                marker = new GMarkerGoogle(new PointLatLng(p.Latitud, p.Longitud), icon);
            }
            else
            {
                marker = new GMarkerGoogle(new PointLatLng(p.Latitud, p.Longitud), GMarkerGoogleType.blue_pushpin);
            }


            // Aquí hay que revisar para que se visualizen bien los globos blancos de info (tooltip)
            marker.ToolTipText = $"{p.Nombre}\nEdad: {p.Edad}\nParentezco: {p.Parentezco}";
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.Tag = p.Cedula;

            _overlayPersonas.Markers.Add(marker);
        }

        // Helper para crear ícono circular
        private static Bitmap Redondear(Bitmap src, int size)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using var gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddEllipse(0, 0, size, size);
                g.SetClip(gp);
                g.DrawImage(src, new Rectangle(0, 0, size, size));
            }
            return bmp;
        }

        private void gMapControl1_Load(object sender, EventArgs e) { }
        private void gMapControl1_Load_1(object sender, EventArgs e) { }

        // ---- Distancia Haversine (km)
        private static double HaversineKm(PointLatLng a, PointLatLng b)
        {
            const double R = 6371.0088;
            double dLat = ToRad(b.Lat - a.Lat);
            double dLon = ToRad(b.Lng - a.Lng);
            double lat1 = ToRad(a.Lat);
            double lat2 = ToRad(b.Lat);

            double sinDlat = Math.Sin(dLat / 2);
            double sinDlon = Math.Sin(dLon / 2);

            double h = sinDlat * sinDlat + Math.Cos(lat1) * Math.Cos(lat2) * sinDlon * sinDlon;
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h)));
            return R * c;
        }
        private static double ToRad(double deg) => deg * Math.PI / 180.0;
        private static double ToDeg(double rad) => rad * 180.0 / Math.PI;

        // ---- Curva gran-círculo (slerp)
        private GMapRoute RutaGranCirculo(PointLatLng a, PointLatLng b, int segmentos = 64)
        {
            double lat1 = ToRad(a.Lat), lon1 = ToRad(a.Lng);
            double lat2 = ToRad(b.Lat), lon2 = ToRad(b.Lng);

            var p1 = new[] { Math.Cos(lat1) * Math.Cos(lon1), Math.Cos(lat1) * Math.Sin(lon1), Math.Sin(lat1) };
            var p2 = new[] { Math.Cos(lat2) * Math.Cos(lon2), Math.Cos(lat2) * Math.Sin(lon2), Math.Sin(lat2) };

            double dot = Math.Max(-1, Math.Min(1, p1[0] * p2[0] + p1[1] * p2[1] + p1[2] * p2[2]));
            double omega = Math.Acos(dot);

            if (omega < 1e-6)
            {
                var trivial = new List<PointLatLng> { a, b };
                var r = new GMapRoute(trivial, "gc") { Stroke = _penRuta };
                return r;
            }

            var pts = new List<PointLatLng>(segmentos + 1);
            for (int i = 0; i <= segmentos; i++)
            {
                double t = (double)i / segmentos;
                double sinOmega = Math.Sin(omega);
                double k1 = Math.Sin((1 - t) * omega) / sinOmega;
                double k2 = Math.Sin(t * omega) / sinOmega;

                double x = k1 * p1[0] + k2 * p2[0];
                double y = k1 * p1[1] + k2 * p2[1];
                double z = k1 * p1[2] + k2 * p2[2];

                double norm = Math.Sqrt(x * x + y * y + z * z);
                x /= norm; y /= norm; z /= norm;

                double lat = Math.Asin(z);
                double lon = Math.Atan2(y, x);

                pts.Add(new PointLatLng(ToDeg(lat), ToDeg(lon)));
            }

            var route = new GMapRoute(pts, "gc") { Stroke = _penRuta };
            return route;
        }

        // ---- Etiqueta en el punto medio
        private class MarkerTexto : GMap.NET.WindowsForms.GMapMarker
        {
            private readonly string _texto;
            private readonly Font _font = new Font("Segoe UI", 9f, FontStyle.Bold);
            private readonly Brush _bFondo = new SolidBrush(Color.FromArgb(210, 255, 255, 255));
            private readonly Pen _pBorde = new Pen(Color.FromArgb(180, 50, 50, 50), 1f);

            public MarkerTexto(PointLatLng pos, string texto) : base(pos)
            {
                _texto = texto;
                IsHitTestVisible = false;
            }

            public override void OnRender(Graphics g)
            {
                var size = g.MeasureString(_texto, _font);
                var rect = new RectangleF(LocalPosition.X - size.Width / 2f, LocalPosition.Y - size.Height - 6, size.Width + 10, size.Height + 6);
                var rectFill = Rectangle.Round(rect);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillRectangle(_bFondo, rectFill);
                g.DrawRectangle(_pBorde, rectFill);
                g.DrawString(_texto, _font, Brushes.Black, rectFill.X + 5, rectFill.Y + 3);
            }
        }

        // Redibuja TODAS las conexiones padre–hijo existentes
        private void RedibujarRelaciones()
        {
            _overlayRutas.Routes.Clear();
            _overlayEtiquetas.Markers.Clear();

            foreach (var rel in RelacionesFamilia.Relaciones)
            {
                var padre = DatosGlobales.Familia.Find(p => p.Cedula == rel.CedulaPadre);
                var hijo = DatosGlobales.Familia.Find(p => p.Cedula == rel.CedulaHijo);
                if (padre == null || hijo == null) continue;

                var p0 = new PointLatLng(padre.Latitud, padre.Longitud);
                var p1 = new PointLatLng(hijo.Latitud, hijo.Longitud);

                var ruta = RutaGranCirculo(p0, p1, segmentos: 72);
                _overlayRutas.Routes.Add(ruta);

                double km = HaversineKm(p0, p1);
                string label = $"{km:0.#} km";

                int mid = Math.Max(0, ruta.Points.Count / 2);
                var posMid = ruta.Points[mid];

                _overlayEtiquetas.Markers.Add(new MarkerTexto(posMid, label));
            }

            gMapControl1.Refresh();
        }

        private void EditarPersonaSeleccionada()
        {
            if (_markerSeleccionado == null) return;

            var ced = _markerSeleccionado.Tag as string;
            var persona = DatosGlobales.Familia.Find(p => p.Cedula == ced);
            if (persona == null) return;

            using var frm = new FormRegistro(persona.Latitud, persona.Longitud)
            {
                CloseOnSave = true
            };

            frm.CargarParaEdicion(persona);
            if (frm.ShowDialog(this) == DialogResult.OK && frm.PersonaCreada != null)
            {
                // Actualizar datos de la persona existente
                persona.Nombre = frm.PersonaCreada.Nombre;
                persona.FechaNacimiento = frm.PersonaCreada.FechaNacimiento;
                persona.Edad = frm.PersonaCreada.Edad;
                persona.Parentezco = frm.PersonaCreada.Parentezco;
                persona.Latitud = frm.PersonaCreada.Latitud;
                persona.Longitud = frm.PersonaCreada.Longitud;
                persona.RutaFoto = frm.PersonaCreada.RutaFoto;

                // Volver a cargar marcadores
                CargarMarcadoresIniciales();
            }
        }

        private void EliminarPersonaSeleccionada()
        {
            if (_markerSeleccionado == null) return;

            var ced = _markerSeleccionado.Tag as string;
            var persona = DatosGlobales.Familia.Find(p => p.Cedula == ced);
            if (persona == null) return;

            var r = MessageBox.Show(
                $"¿Seguro que desea eliminar a {persona.Nombre}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r != DialogResult.Yes) return;

            DatosGlobales.Familia.Remove(persona);

            // Eliminar relaciones donde participa
            RelacionesFamilia.EliminarRelacionesDe(ced);

            _overlayPersonas.Markers.Remove(_markerSeleccionado);
            _markerSeleccionado = null;

            RedibujarRelaciones();
            gMapControl1.Refresh();
        }
    }

    // ================= RELACIONES FAMILIARES =================

    public class RelacionFamiliar
    {
        public string CedulaPadre { get; set; }
        public string CedulaHijo { get; set; }
    }

    public static class RelacionesFamilia
    {
        public static readonly List<RelacionFamiliar> Relaciones = new List<RelacionFamiliar>();

        public static void DefinirPadreHijo(string cedPadre, string cedHijo)
        {
            if (string.IsNullOrWhiteSpace(cedPadre) || string.IsNullOrWhiteSpace(cedHijo))
                return;

            // evitar duplicados
            if (!Relaciones.Any(r => r.CedulaPadre == cedPadre && r.CedulaHijo == cedHijo))
            {
                Relaciones.Add(new RelacionFamiliar
                {
                    CedulaPadre = cedPadre,
                    CedulaHijo = cedHijo
                });
            }
        }

        public static void EliminarRelacionesDe(string cedPersona)
        {
            Relaciones.RemoveAll(r => r.CedulaPadre == cedPersona || r.CedulaHijo == cedPersona);
        }
    }
}
