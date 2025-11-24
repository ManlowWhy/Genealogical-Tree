using System;
using System.Collections.Generic;

namespace MapaTest
{

    public class GrafoFamiliar
    {
        // Diccionario interno de nodos
        private readonly Dictionary<string, NodoFamiliar> _nodos
            = new Dictionary<string, NodoFamiliar>();

        public IReadOnlyDictionary<string, NodoFamiliar> Nodos => _nodos;


        // Agrega una persona como nodo del grafo Si ya existe un nodo con esa cédula, no hace nada

        public void AgregarPersona(Persona persona)
        {
            if (persona == null) throw new ArgumentNullException(nameof(persona));
            if (string.IsNullOrWhiteSpace(persona.Cedula)) return;

            if (_nodos.ContainsKey(persona.Cedula))
                return; 

            var nodo = new NodoFamiliar(persona);
            _nodos.Add(persona.Cedula, nodo);
        }

        public void EliminarPersona(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula)) return;

            if (!_nodos.ContainsKey(cedula))
                return;

            // Quitar la cédula de las listas de vecinos de todos
            foreach (var nodo in _nodos.Values)
            {
                nodo.Vecinos.Remove(cedula);
            }

            // Eliminar el nodo
            _nodos.Remove(cedula);
        }


        // Conecta dos personas como vecinas 
        public void Conectar(string cedulaA, string cedulaB)
        {
            if (string.IsNullOrWhiteSpace(cedulaA) || string.IsNullOrWhiteSpace(cedulaB))
                return;

            if (!_nodos.ContainsKey(cedulaA) || !_nodos.ContainsKey(cedulaB))
                return;

            var nodoA = _nodos[cedulaA];
            var nodoB = _nodos[cedulaB];

            if (!nodoA.Vecinos.Contains(cedulaB))
                nodoA.Vecinos.Add(cedulaB);

            if (!nodoB.Vecinos.Contains(cedulaA))
                nodoB.Vecinos.Add(cedulaA);
        }


        public void Desconectar(string cedulaA, string cedulaB)
        {
            if (string.IsNullOrWhiteSpace(cedulaA) || string.IsNullOrWhiteSpace(cedulaB))
                return;

            if (_nodos.TryGetValue(cedulaA, out var nodoA))
                nodoA.Vecinos.Remove(cedulaB);

            if (_nodos.TryGetValue(cedulaB, out var nodoB))
                nodoB.Vecinos.Remove(cedulaA);
        }
        //Recorrido BFS 
        // Devuelve la lista de personas visitadas

        public List<Persona> BfsDesde(string cedulaInicio)
        {
            var resultado = new List<Persona>();

            if (string.IsNullOrWhiteSpace(cedulaInicio))
                return resultado;

            if (!_nodos.ContainsKey(cedulaInicio))
                return resultado;

            var visitados = new HashSet<string>();
            var cola = new Queue<string>();

            visitados.Add(cedulaInicio);
            cola.Enqueue(cedulaInicio);

            while (cola.Count > 0)
            {
                var actualCed = cola.Dequeue();
                var actualNodo = _nodos[actualCed];
                resultado.Add(actualNodo.Persona);

                foreach (var vecino in actualNodo.Vecinos)
                {
                    if (!visitados.Contains(vecino))
                    {
                        visitados.Add(vecino);
                        cola.Enqueue(vecino);
                    }
                }
            }

            return resultado;
        }
    }
}
