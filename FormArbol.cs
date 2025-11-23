using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MapaTest
{
    public partial class FormArbol : Form
    {
        private List<Persona> personas;
        private List<RelacionFamiliar> relaciones;
        private List<NodoArbol> raices;

        public FormArbol(List<Persona> listaPersonas, List<RelacionFamiliar> listaRelaciones)
        {
            InitializeComponent();
            personas = listaPersonas;
            relaciones = listaRelaciones;

            InicializarLienzo();
            ConstruirArbolLogico();
            CalcularPosiciones();
            picArbol.Paint += PicArbol_Paint;
        }

        private Panel pnlScroll;
        private PictureBox picArbol;

        private void InicializarLienzo()
        {
            pnlScroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            this.Controls.Add(pnlScroll);

            picArbol = new PictureBox
            {
                BackColor = Color.Black,
                SizeMode = PictureBoxSizeMode.Normal
            };
            pnlScroll.Controls.Add(picArbol);
        }

        private class NodoArbol
        {
            public Persona Persona;
            public int X;
            public int Y;
            public List<NodoArbol> Hijos = new List<NodoArbol>();
        }

        private void ConstruirArbolLogico()
        {
            var dic = personas.ToDictionary(p => p.Cedula, p => new NodoArbol { Persona = p });

            foreach (var r in relaciones)
            {
                if (dic.ContainsKey(r.CedulaPadre) && dic.ContainsKey(r.CedulaHijo))
                {
                    dic[r.CedulaPadre].Hijos.Add(dic[r.CedulaHijo]);
                }
            }

            var hijosSet = relaciones.Select(r => r.CedulaHijo).ToHashSet();
            raices = dic.Values.Where(n => !hijosSet.Contains(n.Persona.Cedula)).ToList();
        }

        private const int EspacioX = 160;
        private const int EspacioY = 160;

        private void CalcularPosiciones()
        {
            int x = 100;

            foreach (var r in raices)
                x += UbicarNodo(r, x, 50);

            int anchoReal = ObtenerAnchoMaximo(raices);
            int alturaReal = ObtenerAlturaMaxima(raices);

            picArbol.Width = anchoReal + 100;
            picArbol.Height = alturaReal + 100;
        }

        private int ObtenerAlturaMaxima(List<NodoArbol> nodos)
        {
            int max = 0;
            foreach (var n in nodos)
                max = Math.Max(max, ObtenerAlturaMaximaNodo(n));
            return max;
        }

        private int ObtenerAlturaMaximaNodo(NodoArbol nodo)
        {
            int iconSize = 70;
            int h = nodo.Y + iconSize;

            foreach (var hijo in nodo.Hijos)
                h = Math.Max(h, ObtenerAlturaMaximaNodo(hijo));

            return h;
        }

        private int ObtenerAnchoMaximo(List<NodoArbol> nodos)
        {
            int max = 0;
            foreach (var n in nodos)
                max = Math.Max(max, ObtenerAnchoMaximoNodo(n));
            return max;
        }

        private int ObtenerAnchoMaximoNodo(NodoArbol nodo)
        {
            int iconSize = 70;
            int w = nodo.X + iconSize;

            foreach (var hijo in nodo.Hijos)
                w = Math.Max(w, ObtenerAnchoMaximoNodo(hijo));

            return w;
        }

        private int UbicarNodo(NodoArbol nodo, int x, int y)
        {
            nodo.X = x;
            nodo.Y = y;

            if (nodo.Hijos.Count == 0)
                return EspacioX;

            int anchoTotal = 0;
            int xActual = x;

            foreach (var h in nodo.Hijos)
            {
                int anchoHijo = UbicarNodo(h, xActual, y + EspacioY);
                anchoTotal += anchoHijo;
                xActual += anchoHijo;
            }

            nodo.X = x + (anchoTotal - EspacioX) / 2;

            return anchoTotal;
        }

        private void PicArbol_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var r in raices)
                DibujarNodo(g, r);
        }

        private void DibujarNodo(Graphics g, NodoArbol nodo)
        {
            int iconSize = 70;
            int x = nodo.X;
            int y = nodo.Y;

            // Líneas padre-hijo
            foreach (var h in nodo.Hijos)
            {
                g.DrawLine(
                    Pens.Gray,
                    x + iconSize / 2, y + iconSize,
                    h.X + iconSize / 2, h.Y
                );

                DibujarNodo(g, h);
            }

            Image foto = ObtenerIconoPersona(nodo.Persona, iconSize);
            g.DrawImage(foto, x, y, iconSize, iconSize);

            var s = nodo.Persona.Nombre;
            SizeF textSize = g.MeasureString(s, new Font("Segoe UI", 9f));
            g.DrawString(s, new Font("Segoe UI", 9f),
                Brushes.White,
                x + iconSize / 2 - textSize.Width / 2,
                y + iconSize + 5);
        }

        private Image ObtenerIconoPersona(Persona p, int size)
        {
            if (!string.IsNullOrEmpty(p.RutaFoto) && File.Exists(p.RutaFoto))
            {
                using var bmp = new Bitmap(p.RutaFoto);
                var scaled = new Bitmap(bmp, new Size(size, size));
                return Redondear(scaled, size);
            }

            Bitmap b = new Bitmap(size, size);
            using var g = Graphics.FromImage(b);
            g.FillEllipse(Brushes.White, 0, 0, size, size);
            g.DrawEllipse(Pens.White, 0, 0, size, size);
            return b;
        }

        private static Bitmap Redondear(Bitmap src, int size)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using var gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddEllipse(0, 0, size, size);
                g.SetClip(gp);
                g.DrawImage(src, new Rectangle(0, 0, size, size));
            }
            return bmp;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg";
                sfd.FileName = "ArbolFamiliar.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    GuardarImagenArbol(sfd.FileName);
                    MessageBox.Show("Imagen guardada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GuardarImagenArbol(string ruta)
        {
            picArbol.Refresh();

            using (Bitmap bmp = new Bitmap(picArbol.Width, picArbol.Height))
            {
                picArbol.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                if (ruta.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                    bmp.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
                else
                    bmp.Save(ruta, System.Drawing.Imaging.ImageFormat.Png);
            }
        }


    }
}
