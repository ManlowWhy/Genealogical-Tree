using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Windows.Forms;

namespace MapaTest
{
    public partial class FormMapa : Form
    {
        public FormMapa()
        {
            InitializeComponent();

            InicializarMapa();
        }

        private void InicializarMapa()
        {
            // Configuración básica del mapa
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap; // Mapa libre, no requiere API Key
            GMaps.Instance.Mode = AccessMode.ServerAndCache; // Usar cache local
            gMapControl1.Position = new PointLatLng(23.6345, -102.5528); // Centro de México
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 18;
            gMapControl1.Zoom = 4;
            gMapControl1.ShowCenter = false;
            gMapControl1.DragButton = MouseButtons.Left; // Arrastrar mapa con clic izquierdo

            // Crear capa de marcadores
            GMapOverlay markersOverlay = new GMapOverlay("marcadores");

            //agregar marcadores por cada persona registrada
            foreach (var persona in DatosGlobales.Familia)
            {
                var punto = new PointLatLng(persona.Latitud, persona.Longitud);
                var marcador = new GMarkerGoogle(punto, GMarkerGoogleType.blue_pushpin);

                // 🏷️ Mostrar nombre y edad como tooltip
                marcador.ToolTipText = $"{persona.Nombre}\nEdad: {persona.Edad}\nParentezco: {persona.Parentezco}";
                marcador.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                markersOverlay.Markers.Add(marcador);
            }

            // Agregar capa al mapa
            gMapControl1.Overlays.Add(markersOverlay);

            // Opcional: manejar clics en el mapa
            gMapControl1.OnMapClick += GMapControl1_OnMapClick;
        }

        private void GMapControl1_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            MessageBox.Show($"Hiciste clic en Lat: {pointClick.Lat}, Lng: {pointClick.Lng}");
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
