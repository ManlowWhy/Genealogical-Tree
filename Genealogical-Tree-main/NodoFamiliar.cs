using System;
using System.Collections.Generic;

namespace MapaTest
{
    /// <summary>
    /// Nodo del grafo familiar.
    /// Representa a una persona como vértice del grafo.
    /// </summary>
    public class NodoFamiliar
    {
        /// <summary>
        /// Cédula de la persona. Se usa como identificador único del nodo.
        /// </summary>
        public string Cedula { get; }

        /// <summary>
        /// Referencia a la persona asociada a este nodo.
        /// </summary>
        public Persona Persona { get; }

        /// <summary>
        /// Lista de cédulas de vecinos conectados (padres, hijos, etc.).
        /// </summary>
        public List<string> Vecinos { get; }

        public NodoFamiliar(Persona persona)
        {
            Persona = persona ?? throw new ArgumentNullException(nameof(persona));
            Cedula = persona.Cedula;
            Vecinos = new List<string>();
        }
    }
}
