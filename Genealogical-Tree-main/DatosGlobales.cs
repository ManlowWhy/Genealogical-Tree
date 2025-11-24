using System.Collections.Generic;

namespace MapaTest
{
    public static class DatosGlobales
    {
        /// <summary>
        /// Lista de todos los familiares registrados.
        /// </summary>
        public static List<Persona> Familia = new List<Persona>();

        /// <summary>
        /// Grafo familiar que modela la red de relaciones entre las personas.
        /// Se implementa a mano (sin librerías externas).
        /// </summary>
        public static GrafoFamiliar Grafo { get; } = new GrafoFamiliar();
    }
}
