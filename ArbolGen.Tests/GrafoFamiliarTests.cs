using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapaTest;              
using System.Collections.Generic;

namespace ArbolGen.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class GrafoFamiliarTests
    {
        [TestInitialize]
        public void Limpiar()
        {
            GrafoFamiliar.Nodos.Clear();
        }

        [TestMethod]
        public void AgregarNodo_InsertaConClaveDeParentezco()
        {
            var n = new NodoFamiliar
            {
                Nombre = "Ana",
                Parentezco = "Madre",
                Latitud = 10,
                Longitud = -84
            };

            GrafoFamiliar.AgregarNodo(n);

            Assert.IsTrue(GrafoFamiliar.Nodos.ContainsKey("Madre"));
            Assert.AreEqual("Ana", GrafoFamiliar.Nodos["Madre"].Nombre);
        }

        [TestMethod]
        public void AgregarNodo_ConPadre_CreaRelacionPadreHijo()
        {
            var padre = new NodoFamiliar { Nombre = "Juan", Parentezco = "Padre" };
            GrafoFamiliar.AgregarNodo(padre);

            var hijo = new NodoFamiliar { Nombre = "Luis", Parentezco = "Hijo" };
            GrafoFamiliar.AgregarNodo(hijo, "Padre");

            Assert.AreEqual(1, GrafoFamiliar.Nodos["Padre"].Hijos.Count);
            Assert.AreEqual("Luis", GrafoFamiliar.Nodos["Padre"].Hijos[0].Nombre);
        }

        [TestMethod]
        public void AgregarNodo_PadreNoExiste_NoLanzaErrorNiCreaPadreFantasma()
        {
            var hijo = new NodoFamiliar { Nombre = "Luis", Parentezco = "Hijo" };

            GrafoFamiliar.AgregarNodo(hijo, "NoExiste");

            Assert.IsTrue(GrafoFamiliar.Nodos.ContainsKey("Hijo"));
            Assert.IsFalse(GrafoFamiliar.Nodos.ContainsKey("NoExiste"));
        }

        [TestMethod]
        public void AgregarNodo_MismoParentezco_ReemplazaPorUltimoInsertado()
        {
            var n1 = new NodoFamiliar { Nombre = "Primera", Parentezco = "Madre" };
            var n2 = new NodoFamiliar { Nombre = "Segunda", Parentezco = "Madre" };

            GrafoFamiliar.AgregarNodo(n1);
            GrafoFamiliar.AgregarNodo(n2);

            // Debe existir solo la clave "Madre" y apuntar al último nodo
            Assert.IsTrue(GrafoFamiliar.Nodos.ContainsKey("Madre"));
            Assert.AreEqual("Segunda", GrafoFamiliar.Nodos["Madre"].Nombre);
        }
    }
}
