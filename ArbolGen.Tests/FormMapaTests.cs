using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GMap.NET;
using MapaTest;

namespace ArbolGen.Tests
{
    [TestClass]
    public class FormMapaTests
    {
        // 7) HaversineKm: 1° de latitud en el ecuador ≈ 111.19 km
        [TestMethod]
        public void HaversineKm_UnGradoLatitudEnEcuador_Aprox111Km()
        {
            var tipo = new PrivateType(typeof(FormMapa));

            var a = new PointLatLng(0, 0);
            var b = new PointLatLng(1, 0);

            double d = (double)tipo.InvokeStatic(
                "HaversineKm",
                new object[] { a, b });

            Assert.IsTrue(Math.Abs(d - 111.195) < 0.5,
                $"Distancia esperada ~111.2 km, fue {d} km");
        }

        // 8) ToRad: 180° → π radianes
        [TestMethod]
        public void ToRad_180Grados_EsPiRadianes()
        {
            var tipo = new PrivateType(typeof(FormMapa));

            double rad = (double)tipo.InvokeStatic(
                "ToRad",
                new object[] { 180.0 });

            Assert.IsTrue(Math.Abs(rad - Math.PI) < 1e-10,
                $"Se esperaba π, se obtuvo {rad}");
        }
    }
}
