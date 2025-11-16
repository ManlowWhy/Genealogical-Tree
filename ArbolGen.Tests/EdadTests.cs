using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace ArbolGen.Tests
{
    [TestClass]
    public class EdadTests
    {
        private static int CalcularEdadPrivado(DateTime nacimiento)
        {
            var acceso = new PrivateType(typeof(MapaTest.FormRegistro));
            return (int)acceso.InvokeStatic("CalcularEdad", new object[] { nacimiento });
        }

        [TestMethod]
        public void CalcularEdad_CuandoCumpleaniosYaPaso_EdadExacta()
        {
           
            DateTime nacimiento = DateTime.Today.AddYears(-20).AddDays(-1);

            int edad = CalcularEdadPrivado(nacimiento);

            Assert.AreEqual(20, edad);
        }

        [TestMethod]
        public void CalcularEdad_CuandoCumpleaniosEsManana_NoSeCuentaTodavia()
        {
            
            DateTime nacimiento = DateTime.Today.AddYears(-20).AddDays(1);

            int edad = CalcularEdadPrivado(nacimiento);

            Assert.AreEqual(19, edad);
        }

        [TestMethod]
        public void CalcularEdad_FechaFutura_RegresaCero()
        {
            DateTime nacimiento = DateTime.Today.AddYears(1);

            int edad = CalcularEdadPrivado(nacimiento);

            Assert.AreEqual(0, edad);
        }
    }
}
