using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapaTest
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

        }

        private void buttonPrincipal_Click(object sender, EventArgs e)
        {
            FormMapa form = new FormMapa();
            this.Hide();
            form.Show();
        }
    }
}
