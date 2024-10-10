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
        /// <summary>
        /// Se inicializan las componentes del formulario.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            numHijos = 0;
        }
        /// <summary>
        /// Se crea un formulario un hijo.
        /// Aparece en la ventana cuando está abierto y marcado cuando está activado.
        /// Si no quedan formularios no aparecen las opciones de ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Creamos y mostramos el nuevo formulario hijo
            numHijos++;
            FEditorHijo f2 = new FEditorHijo(numHijos);
            f2.MdiParent = this;
            f2.Show();

            ////Activamos la ventana y añadimos un tsmi del formulario hijo
            this.ventanaToolStripMenuItem.Enabled = true;
        }
        /// <summary>
        /// Si se cierra el formulario y no queda ningún otro formulario hijo, ventana no muestra sus opciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildForm_FormClosed(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 1)
            {
                this.ventanaToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.ventanaToolStripMenuItem.Enabled = false;
            }
        }
        /// <summary>
        /// Cierra el formulario cuando se pulsa el botón Salir en Archivo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Al seleccionar 'ArrangeIcons' en ventana ofrece una presentación reorganizando los iconos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                this.ventanaToolStripMenuItem.Visible = false;
                this.toolStripStatusLabel2.Text = "";
            }
            else
            {
                this.ventanaToolStripMenuItem.Visible = true;
                this.toolStripStatusLabel2.Text = this.ActiveMdiChild.Text;
            }
        }

        private void ventanaToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem auxiliar = e.ClickedItem;

            if (auxiliar.Equals(this.arrangeIconsToolStripMenuItem))
            {
                this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
            }else if (auxiliar.Equals(this.cascadaToolStripMenuItem))
            {
                this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
            }else if (auxiliar.Equals(this.horizontalToolStripMenuItem))
            {
                this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
            }else if (auxiliar.Equals(this.verticalToolStripMenuItem))
            {
                this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
            }
        }
    }
}
