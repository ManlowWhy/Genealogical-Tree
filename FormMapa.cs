using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MapaTest
{
    public partial class FormMapa : Form
    {
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
    }
}
