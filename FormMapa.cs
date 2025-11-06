using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private ContextMenuStrip _ctx;
        private PointLatLng _lastClickPoint;

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

            // Overlay de personas
            _overlayPersonas = new GMapOverlay("personas");
            gMapControl1.Overlays.Add(_overlayPersonas);

            _overlayRutas = new GMapOverlay("rutas");
            _overlayEtiquetas = new GMapOverlay("etiquetas");
            gMapControl1.Overlays.Add(_overlayRutas);
            gMapControl1.Overlays.Add(_overlayEtiquetas);

            // manejar clic en marcador: dibujar conexiones curvas + etiquetas
            gMapControl1.OnMarkerClick += (item, mouseArgs) =>
            {
                if (item == null) return;
                var ced = item.Tag as string;
                var persona = DatosGlobales.Familia.Find(p => p.Cedula == ced);
                if (persona == null) return;

                DibujarConexionesDesde(persona);
            };


            // Menú contextual (clic derecho)
            _ctx = new ContextMenuStrip();
            _ctx.Items.Add("Nuevo miembro aquí", null, (s, e) => CrearMiembroEn(_lastClickPoint));

            // Eventos de click
            gMapControl1.OnMapClick += GMapControl1_OnMapClick;
            gMapControl1.MouseDown += GMapControl1_MouseDown;

            // Cargar marcadores existentes
            CargarMarcadoresIniciales();
        }

        // Muestra menú contextual en clic derecho y guarda la coordenada
        private void GMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _lastClickPoint = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                _ctx.Show(Cursor.Position);
            }
        }

        // También disponible por OnMapClick (por compatibilidad)
        private void GMapControl1_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _lastClickPoint = pointClick;
                _ctx.Show(Cursor.Position);
            }
        }

        private void CargarMarcadoresIniciales()
        {
            _overlayPersonas.Markers.Clear();

            foreach (var persona in DatosGlobales.Familia)
            {
                AgregarMarkerPersona(persona);
            }
            if (DatosGlobales.Familia.Count > 0)
            {
                DibujarConexionesDesde(DatosGlobales.Familia[0]);
            }
    
            gMapControl1.Refresh();
        }

        private void CrearMiembroEn(PointLatLng pt)
        {
            using var frm = new FormRegistro(pt.Lat, pt.Lng) { CloseOnSave = true };
            if (frm.ShowDialog(this) == DialogResult.OK && frm.PersonaCreada != null)
            {
                // El form ya agregó la persona a DatosGlobales.Familia; aquí solo pintamos el marcador.
                AgregarMarkerPersona(frm.PersonaCreada);
                gMapControl1.Refresh();
            }
        }

        private void AgregarMarkerPersona(Persona p)
        {
            // Si hay foto, usamos ícono circular; si no, pushpin azul
            GMapMarker marker;

            if (!string.IsNullOrWhiteSpace(p.RutaFoto) && File.Exists(p.RutaFoto))
            {
                using var original = (Bitmap)Image.FromFile(p.RutaFoto);
                using var scaled = new Bitmap(original, new Size(48, 48));
                var icon = Redondear(scaled, 48);  // devolvemos un Bitmap NUEVO que sí vive fuera del using

                marker = new GMarkerGoogle(new PointLatLng(p.Latitud, p.Longitud), icon);
            }
            else
            {
                marker = new GMarkerGoogle(new PointLatLng(p.Latitud, p.Longitud), GMarkerGoogleType.blue_pushpin);
            }

            marker.ToolTipText = $"{p.Nombre}\nEdad: {p.Edad}\nParentezco: {p.Parentezco}";
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.Tag = p.Cedula; // para identificar la persona al hacer clic, si luego quieres distancias etc.

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

        // (Opcional) Si luego quieres manejar clic en marcador para mostrar distancias:
        // gMapControl1.OnMarkerClick += (item, mouse) => { var ced = (string)item.Tag; /* ... */ };

        private void gMapControl1_Load(object sender, EventArgs e) { }
        private void gMapControl1_Load_1(object sender, EventArgs e) { }
        // ---- Distancia Haversine (km)
        private static double HaversineKm(PointLatLng a, PointLatLng b)
        {
            const double R = 6371.0088; // radio medio Tierra en km
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

        // ---- Curva gran-círculo (slerp) como ruta suave
        private GMapRoute RutaGranCirculo(PointLatLng a, PointLatLng b, int segmentos = 64)
        {
            // convertir a radianes y a coordenadas 3D sobre esfera unidad
            double lat1 = ToRad(a.Lat), lon1 = ToRad(a.Lng);
            double lat2 = ToRad(b.Lat), lon2 = ToRad(b.Lng);

            var p1 = new[] { Math.Cos(lat1) * Math.Cos(lon1), Math.Cos(lat1) * Math.Sin(lon1), Math.Sin(lat1) };
            var p2 = new[] { Math.Cos(lat2) * Math.Cos(lon2), Math.Cos(lat2) * Math.Sin(lon2), Math.Sin(lat2) };

            // ángulo entre p1 y p2
            double dot = Math.Max(-1, Math.Min(1, p1[0] * p2[0] + p1[1] * p2[1] + p1[2] * p2[2]));
            double omega = Math.Acos(dot);
            // si puntos casi iguales, retornar línea trivial
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

                // normalizar
                double norm = Math.Sqrt(x * x + y * y + z * z);
                x /= norm; y /= norm; z /= norm;

                double lat = Math.Asin(z);
                double lon = Math.Atan2(y, x);

                pts.Add(new PointLatLng(ToDeg(lat), ToDeg(lon)));
            }

            var route = new GMapRoute(pts, "gc") { Stroke = _penRuta };
            return route;
        }

        // ---- Etiqueta en el punto medio (marcador de texto custom)
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

        // ---- Dibuja todas las conexiones desde una persona hacia el resto
        private void DibujarConexionesDesde(Persona origen)
        {
            _overlayRutas.Routes.Clear();
            _overlayEtiquetas.Markers.Clear();

            var p0 = new PointLatLng(origen.Latitud, origen.Longitud);

            foreach (var destino in DatosGlobales.Familia)
            {
                if (destino.Cedula == origen.Cedula) continue;

                var p1 = new PointLatLng(destino.Latitud, destino.Longitud);
                var ruta = RutaGranCirculo(p0, p1, segmentos: 72);
                _overlayRutas.Routes.Add(ruta);

                // distancia
                double km = HaversineKm(p0, p1);
                string label = $"{km:0.#} km";

                // punto medio "geométrico" sobre la ruta
                int mid = Math.Max(0, ruta.Points.Count / 2);
                var posMid = ruta.Points[mid];

                _overlayEtiquetas.Markers.Add(new MarkerTexto(posMid, label));
            }

            gMapControl1.Refresh();
        }

    }
}
