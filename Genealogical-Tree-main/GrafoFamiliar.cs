using MapaTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MapaTest
{
    public static class GrafoFamiliar
    {
        
        public static Dictionary<string, NodoFamiliar> Nodos { get; } =
            new Dictionary<string, NodoFamiliar>(StringComparer.OrdinalIgnoreCase);

        public static void AgregarNodo(NodoFamiliar nodo, string parentezcoPadre = null)
        {
            if (nodo == null) return;
            if (string.IsNullOrWhiteSpace(nodo.Parentezco)) return;

            // Último que entra con el mismo parentezco tiene prioridad de lectura :V
            Nodos[nodo.Parentezco] = nodo;

            if (!string.IsNullOrWhiteSpace(parentezcoPadre) &&
                Nodos.TryGetValue(parentezcoPadre, out var padre))
            {
                if (padre.Hijos == null)
                    padre.Hijos = new List<NodoFamiliar>();

                padre.Hijos.Add(nodo);
            }
        }
    }
}
