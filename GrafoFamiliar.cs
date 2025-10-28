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
        public static Dictionary<string, NodoFamiliar> Nodos { get; } = new Dictionary<string, NodoFamiliar>();

        public static void AgregarNodo(NodoFamiliar nodo, string parentezcoPadre = null)
        {
            Nodos[nodo.Parentezco] = nodo;

            if (parentezcoPadre != null && Nodos.ContainsKey(parentezcoPadre))
            {
                Nodos[parentezcoPadre].Hijos.Add(nodo);
            }
        }
    }
}