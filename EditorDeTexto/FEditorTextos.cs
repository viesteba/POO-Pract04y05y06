using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeTexto
{
    public partial class Form1 : Form
    {
        private int numHijos;
        public Form1()
        {
            InitializeComponent();
            numHijos = 1;
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FEditorHijo f2 = new FEditorHijo(numHijos);
            f2.MdiParent = this;
            f2.Show();
            numHijos++;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
