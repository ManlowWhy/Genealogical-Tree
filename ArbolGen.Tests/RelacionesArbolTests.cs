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

        // 5) DefinirPadreHijo: evita duplicados
        [TestMethod]
        public void DefinirPadreHijo_NoCreaRelacionesDuplicadas()
        {
            RelacionesFamilia.DefinirPadreHijo("111", "222");
            RelacionesFamilia.DefinirPadreHijo("111", "222"); // duplicado

            Assert.AreEqual(1, RelacionesFamilia.Relaciones.Count);
            Assert.AreEqual("111", RelacionesFamilia.Relaciones[0].CedulaPadre);
            Assert.AreEqual("222", RelacionesFamilia.Relaciones[0].CedulaHijo);
        }

        // 6) EliminarRelacionesDe: borra donde es padre o hijo
        [TestMethod]
        public void EliminarRelacionesDe_EliminaTodasLasRelacionesDeLaPersona()
        {
            RelacionesFamilia.DefinirPadreHijo("111", "222"); // 111 padre
            RelacionesFamilia.DefinirPadreHijo("333", "111"); // 111 hijo

            Assert.AreEqual(2, RelacionesFamilia.Relaciones.Count);

            RelacionesFamilia.EliminarRelacionesDe("111");

            Assert.IsFalse(RelacionesFamilia.Relaciones
                .Any(r => r.CedulaPadre == "111" || r.CedulaHijo == "111"));
            Assert.AreEqual(0, RelacionesFamilia.Relaciones.Count);
        }
    }
}
