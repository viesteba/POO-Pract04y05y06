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
            numHijos = 0;
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            numHijos++;
            FEditorHijo f2 = new FEditorHijo(numHijos);
            f2.MdiParent = this;
            f2.Show();
            this.ventanaToolStripMenuItem.Enabled = true;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void ventanaToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            bool existeAlguno = false;
            foreach(FEditorHijo fEditorHijo in this.MdiChildren)
            {
                if(fEditorHijo.IsHandleCreated)
                { 
                    existeAlguno = true;
                } 
            }
            if (!existeAlguno)
            {
                this.ventanaToolStripMenuItem.Enabled = false;
            }
        }
    }
}
