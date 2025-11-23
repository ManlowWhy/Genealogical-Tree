using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaTest
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string FechaNacimiento { get; set; }
        public string Edad { get; set; }
        public string Parentezco { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string RutaFoto { get; set; }

        // NUEVO: estado de vida / defunción
        public bool EstaVivo { get; set; } = true;
        public string FechaDefuncion { get; set; }      // null si está vivo
        public string EdadAlFallecer { get; set; }      // null si está vivo
    }
}
