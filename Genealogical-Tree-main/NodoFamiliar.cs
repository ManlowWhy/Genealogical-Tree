using System;
using System.Collections.Generic;

namespace MapaTest
{

    // Representa a una persona como vértice del grafo.
    public class NodoFamiliar
    {

        // Cédula de la persona
        public string Cedula { get; }


        public Persona Persona { get; }


        public List<string> Vecinos { get; }

        public NodoFamiliar(Persona persona)
        {
            Persona = persona ?? throw new ArgumentNullException(nameof(persona));
            Cedula = persona.Cedula;
            Vecinos = new List<string>();
        }
    }
}
