#nullable disable
#nullable disable
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MapaTest;

namespace ArbolGen.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class FormRegistroTests
    {
        private PrivateType _registroStatic;
        private PrivateObject _registroInstancia;

        [TestInitialize]
        public void Setup()
        {
            _registroStatic = new PrivateType(typeof(FormRegistro));

            var instancia = (FormRegistro)FormatterServices
                .GetUninitializedObject(typeof(FormRegistro));
            _registroInstancia = new PrivateObject(instancia);

            GrafoFamiliar.Nodos.Clear();
        }

        // 2) CalcularEdad: fecha futura → 0
        [TestMethod]
        public void CalcularEdad_FechaFutura_RegresaCero()
        {
            var nacimiento = DateTime.Today.AddYears(1);

            int edad = (int)_registroStatic.InvokeStatic(
                "CalcularEdad",
                new object[] { nacimiento });

            Assert.AreEqual(0, edad);
        }

        // 3) ObtenerPadresSegunParentezco: Hijo/Hija → Madre, Padre
        [TestMethod]
        public void ObtenerPadresSegunParentezco_Hijo_RegresaMadreYPadre()
        {
            var padres = (List<string>)_registroInstancia.Invoke(
                "ObtenerPadresSegunParentezco",
                new object[] { "Hijo" });

            CollectionAssert.AreEqual(
                new List<string> { "Madre", "Padre" },
                padres);
        }


    }
}
