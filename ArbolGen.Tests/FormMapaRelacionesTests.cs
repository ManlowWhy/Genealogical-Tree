#nullable disable
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapaTest;
using System.Linq;

namespace ArbolGen.Tests
{
    [TestClass]
    [DoNotParallelize] 
    public class FormMapaRelacionesTests
    {
        [TestInitialize]
        public void Limpiar()
        {
            DatosGlobales.Familia.Clear();
            RelacionesFamilia.Relaciones.Clear();
        }

        [TestMethod]
        public void RedibujarRelaciones_CreaUnaRutaYUnaEtiquetaPorRelacionValida()
        {
            // 2 personas con coordenadas y una relación padre–hijo
            var padre = new Persona
            {
                Cedula = "111",
                Nombre = "Padre",
                Latitud = 9.93,
                Longitud = -84.08
            };

            var hijo = new Persona
            {
                Cedula = "222",
                Nombre = "Hijo",
                Latitud = 9.94,
                Longitud = -84.09
            };

            DatosGlobales.Familia.Add(padre);
            DatosGlobales.Familia.Add(hijo);

            RelacionesFamilia.DefinirPadreHijo("111", "222");

            // Instanciar el mapa 
            using var frm = new FormMapa();
            var acceso = new PrivateObject(frm);

            acceso.Invoke("RedibujarRelaciones", new object[] { });

            dynamic overlayRutas = acceso.GetField("_overlayRutas");
            dynamic overlayEtiquetas = acceso.GetField("_overlayEtiquetas");

            int rutasCount = overlayRutas.Routes.Count;
            int etiquetasCount = overlayEtiquetas.Markers.Count;

            // Assert
            Assert.AreEqual(1, rutasCount,
                "Debe existir exactamente una ruta por la relación padre–hijo registrada.");

            Assert.AreEqual(1, etiquetasCount,
                "Debe existir exactamente una etiqueta de distancia por cada ruta dibujada.");
        }
    }
}

