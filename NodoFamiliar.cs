using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaTest
{
    public class NodoFamiliar
    {
        public string Nombre { get; set; }
        public string Parentezco { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public List<NodoFamiliar> Hijos { get; set; } = new List<NodoFamiliar>();
    }
}
