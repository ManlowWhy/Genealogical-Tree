using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapaTest;

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
        public void AgregarNodo_GuardaEnDiccionarioPorParentezco()
        {
            var nodo = new NodoFamiliar
            {
                Nombre = "Ana",
                Parentezco = "Madre",
                Latitud = 10,
                Longitud = -84
            };

            GrafoFamiliar.AgregarNodo(nodo);

            Assert.IsTrue(GrafoFamiliar.Nodos.ContainsKey("Madre"));
            Assert.AreSame(nodo, GrafoFamiliar.Nodos["Madre"]);
        }

        [TestMethod]
        public void AgregarNodo_ConPadreAgregaHijoALaListaDeHijos()
        {
            var padre = new NodoFamiliar
            {
                Nombre = "Ana",
                Parentezco = "Madre",
                Latitud = 10,
                Longitud = -84
            };

            var hijo = new NodoFamiliar
            {
                Nombre = "Luis",
                Parentezco = "Hijo",
                Latitud = 11,
                Longitud = -85
            };

            // Act: primero agregamos el padre, luego el hijo indicando el parentezco del padre
            GrafoFamiliar.AgregarNodo(padre);
            GrafoFamiliar.AgregarNodo(hijo, "Madre");

            // Assert: el padre debe tener exactamente un hijo, y debe ser ese nodo
            Assert.AreEqual(1, padre.Hijos.Count, "El padre debe tener exactamente un hijo.");
            Assert.AreSame(hijo, padre.Hijos[0], "El hijo agregado debe ser el mismo nodo que se pasó.");
        }

    }
}
