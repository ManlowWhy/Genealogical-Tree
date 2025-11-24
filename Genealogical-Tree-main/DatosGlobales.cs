using System.Collections.Generic;

namespace MapaTest
{
    public static class DatosGlobales
    {
        // Lista de todos los familiares registrados

        public static List<Persona> Familia = new List<Persona>();
        //Grafo familiar 
        public static GrafoFamiliar Grafo { get; } = new GrafoFamiliar();
    }
}
