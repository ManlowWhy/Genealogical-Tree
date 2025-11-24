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

        // 1) DefinirPadreHijo
        [TestMethod]
        public void DefinirPadreHijo_NoCreaRelacionesDuplicadas()
        {
   
            RelacionesFamilia.DefinirPadreHijo("111", "222");
            RelacionesFamilia.DefinirPadreHijo("111", "222"); 

            // Assert
            Assert.AreEqual(1, RelacionesFamilia.Relaciones.Count);
            Assert.AreEqual("111", RelacionesFamilia.Relaciones[0].CedulaPadre);
            Assert.AreEqual("222", RelacionesFamilia.Relaciones[0].CedulaHijo);
        }

        // 2) EliminarRelacionesDePersona
        [TestMethod]
        public void EliminarRelacionesDePersona_EliminaTodasLasRelacionesDeLaPersona()
        {
            // Aparece como padre y otra como hijo
            RelacionesFamilia.DefinirPadreHijo("111", "222"); 
            RelacionesFamilia.DefinirPadreHijo("333", "111"); 

            Assert.AreEqual(2, RelacionesFamilia.Relaciones.Count,
                "Antes de eliminar debe haber dos relaciones registradas.");


            RelacionesFamilia.EliminarRelacionesDePersona("111");

            // Ninguna relación debe contener a 111 
            Assert.IsFalse(RelacionesFamilia.Relaciones
                .Any(r => r.CedulaPadre == "111" || r.CedulaHijo == "111"));
            Assert.AreEqual(0, RelacionesFamilia.Relaciones.Count);
        }
    }
}
