using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapaTest;
#nullable disable

namespace ArbolGen.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class GrafoFamiliarTests
    {
        private GrafoFamiliar _grafo;

        [TestInitialize]
        public void Limpiar()
        {
            
            _grafo = new GrafoFamiliar();
        }


        [TestMethod]
        public void AgregarPersona_AgregaNodoConCedulaEnDiccionario()
        {
            
            var persona = new Persona
            {
                Cedula = "111",
                Nombre = "Ana"
            };

            
            _grafo.AgregarPersona(persona);

            
            Assert.IsTrue(
                _grafo.Nodos.ContainsKey("111"),
                "El grafo debe contener un nodo con la cédula de la persona agregada.");

            var nodo = _grafo.Nodos["111"];
            Assert.AreSame(
                persona,
                nodo.Persona,
                "El nodo debe referenciar exactamente al objeto Persona agregado.");
        }

  
        [TestMethod]
        public void Conectar_CuandoAmbosExisten_LosVuelveVecinosBidireccionales()
        {
            
            var p1 = new Persona { Cedula = "111", Nombre = "Ana" };
            var p2 = new Persona { Cedula = "222", Nombre = "Luis" };

            _grafo.AgregarPersona(p1);
            _grafo.AgregarPersona(p2);

            
            _grafo.Conectar("111", "222");

            
            var nodo1 = _grafo.Nodos["111"];
            var nodo2 = _grafo.Nodos["222"];

            CollectionAssert.Contains(
                nodo1.Vecinos,
                "222",
                "La cédula 222 debe aparecer como vecina de la 111.");

            CollectionAssert.Contains(
                nodo2.Vecinos,
                "111",
                "La cédula 111 debe aparecer como vecina de la 222.");
        }
    }
}
