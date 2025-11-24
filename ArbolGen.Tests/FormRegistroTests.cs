#nullable disable
#nullable disable
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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

            // Limpiar el grafo global para que cada prueba empiece sin conexiones.
            var grafo = DatosGlobales.Grafo;
            var cedulas = grafo.Nodos.Keys.ToList();
            foreach (var ced in cedulas)
            {
                grafo.EliminarPersona(ced);
            }
        }

        /// <summary>
        /// Verifica que, para una persona fallecida, la edad se calcule
        /// usando la fecha de defunción y no la fecha actual.
        /// </summary>
        [TestMethod]
        public void CalcularEdad_PersonaFallecida_UsaFechaDefuncion()
        {
            // Arrange
            var nacimiento = new DateTime(1980, 1, 1);
            var fallecimiento = new DateTime(2020, 1, 1); // 40 años

            // Act
            int edad = (int)_registroStatic.InvokeStatic(
                "CalcularEdad",
                new object[] { nacimiento, fallecimiento });

            // Assert
            Assert.AreEqual(40, edad);
        }

        /// <summary>
        /// Verifica que el método privado ObtenerPadresSegunParentezco
        /// devuelva "Madre" y "Padre" cuando el parentezco es "Hijo".
        /// </summary>
        [TestMethod]
        public void ObtenerPadresSegunParentezco_Hijo_RegresaMadreYPadre()
        {
            // Act
            var padres = (List<string>)_registroInstancia.Invoke(
                "ObtenerPadresSegunParentezco",
                new object[] { "Hijo" });

            // Assert
            CollectionAssert.AreEqual(
                new List<string> { "Madre", "Padre" },
                padres);
        }
    }
}
