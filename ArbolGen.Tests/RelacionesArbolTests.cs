#nullable disable
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MapaTest;

namespace ArbolGen.Tests
{
    [TestClass]
    public class RelacionesArbolTests
    {
      
        private PrivateObject _registroPrivado;

        [TestInitialize]
        public void CrearInstanciaSinConstructor()
        {
          
            var instancia = (FormRegistro)FormatterServices
                .GetUninitializedObject(typeof(FormRegistro));

            _registroPrivado = new PrivateObject(instancia);
        }

        [TestMethod]
        public void ObtenerPadresSegunParentezco_Hijo_RegresaMadreYPadre()
        {
            var resultado = (List<string>)_registroPrivado!
                .Invoke("ObtenerPadresSegunParentezco", "Hijo");

            CollectionAssert.AreEqual(
                new List<string> { "Madre", "Padre" },
                resultado,
                "Un hijo debe tener como padres 'Madre' y 'Padre'.");
        }

        [TestMethod]
        public void ObtenerPadresSegunParentezco_Madre_RegresaAbuelosMaternos()
        {
            var resultado = (List<string>)_registroPrivado!
                .Invoke("ObtenerPadresSegunParentezco", "Madre");
            

            CollectionAssert.AreEqual(
                new List<string> { "Abuela Materna", "Abuelo Materno" },
                resultado,
                "Una 'Madre' debe tener como padres los abuelos maternos.");
        }

        [TestMethod]
        public void ObtenerNivelGeneracional_ValoresClave_CoincidenConMapaDefinido()
        {
            int nivelAbuela = (int)_registroPrivado!
                .Invoke("ObtenerNivelGeneracional", "Abuela Materna");
            int nivelMadre = (int)_registroPrivado!
                .Invoke("ObtenerNivelGeneracional", "Madre");
            int nivelHijo = (int)_registroPrivado!
                .Invoke("ObtenerNivelGeneracional", "Hijo");
            int nivelOtro = (int)_registroPrivado!
                .Invoke("ObtenerNivelGeneracional", "Primo");

            Assert.AreEqual(0, nivelAbuela, "Los abuelos deben estar en nivel 0.");
            Assert.AreEqual(1, nivelMadre, "Madre/Padre deben estar en nivel 1.");
            Assert.AreEqual(2, nivelHijo, "Hijo/Hija deben estar en nivel 2.");
            Assert.AreEqual(3, nivelOtro, "Otros parentescos deben caer en el nivel 3.");
        }
        public void Limpiar()
        {
            GrafoFamiliar.Nodos.Clear();
        }
    }
}
