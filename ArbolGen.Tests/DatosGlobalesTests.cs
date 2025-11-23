using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapaTest;

namespace ArbolGen.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class DatosGlobalesTests
    {
        [TestInitialize]
        public void Limpiar()
        {
            DatosGlobales.Familia.Clear();
        }

        // 9) Verifica que la lista global almacena personas correctamente
        [TestMethod]
        public void Familia_AlAgregarPersonas_SeIncrementaElConteo()
        {
            DatosGlobales.Familia.Add(new Persona { Nombre = "Ana", Cedula = "1" });
            DatosGlobales.Familia.Add(new Persona { Nombre = "Luis", Cedula = "2" });

            Assert.AreEqual(2, DatosGlobales.Familia.Count);
        }
    }
}
