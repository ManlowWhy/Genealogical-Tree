using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapaTest;
using System.Linq;

namespace ArbolGen.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class RelacionesArbolTests
    {
        [TestInitialize]
        public void Limpiar()
        {
            RelacionesFamilia.Relaciones.Clear();
        }

        // 1) DefinirPadreHijo: evita duplicados
        [TestMethod]
        public void DefinirPadreHijo_NoCreaRelacionesDuplicadas()
        {
            // Arrange + Act: se intenta registrar la misma relación dos veces
            RelacionesFamilia.DefinirPadreHijo("111", "222");
            RelacionesFamilia.DefinirPadreHijo("111", "222"); // duplicado

            // Assert
            Assert.AreEqual(1, RelacionesFamilia.Relaciones.Count);
            Assert.AreEqual("111", RelacionesFamilia.Relaciones[0].CedulaPadre);
            Assert.AreEqual("222", RelacionesFamilia.Relaciones[0].CedulaHijo);
        }

        // 2) EliminarRelacionesDePersona: borra donde es padre o hijo
        [TestMethod]
        public void EliminarRelacionesDePersona_EliminaTodasLasRelacionesDeLaPersona()
        {
            // Arrange: 111 aparece una vez como padre y otra como hijo
            RelacionesFamilia.DefinirPadreHijo("111", "222"); // 111 como padre
            RelacionesFamilia.DefinirPadreHijo("333", "111"); // 111 como hijo

            Assert.AreEqual(2, RelacionesFamilia.Relaciones.Count,
                "Antes de eliminar debe haber dos relaciones registradas.");

            // Act
            RelacionesFamilia.EliminarRelacionesDePersona("111");

            // Assert: ninguna relación debe contener a 111 y la lista queda vacía
            Assert.IsFalse(RelacionesFamilia.Relaciones
                .Any(r => r.CedulaPadre == "111" || r.CedulaHijo == "111"));
            Assert.AreEqual(0, RelacionesFamilia.Relaciones.Count);
        }
    }
}
