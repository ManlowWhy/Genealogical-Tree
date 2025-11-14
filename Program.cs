using System;
using System.Windows.Forms;

namespace MapaTest
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ahora el primer formulario será el mapa
            Application.Run(new FormMapa());
        }
    }
}
