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

            // El primer formulario será el que salga aquí:
            //Application.Run(new FormMapa());
            Application.Run(new FormPrincipal());
        }
    }
}
