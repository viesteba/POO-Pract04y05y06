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
        private int numHijosMuertos;
        /// <summary>
        /// Se inicializan las componentes del formulario.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            numHijos = 0;
            numHijosMuertos = 0;
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

            //Activamos la ventana y añadimos un tsmi del formulario hijo
            this.ventanaToolStripMenuItem.Enabled = true;
            ToolStripMenuItem fHijoIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaToolStripMenuItem.DropDownItems.Insert(4+numHijos-numHijosMuertos,fHijoIconsToolStripMenuItem);
            fHijoIconsToolStripMenuItem.Text = numHijos + " Documento " + numHijos;
            fHijoIconsToolStripMenuItem.Checked = true;
            fHijoIconsToolStripMenuItem.Click += (s, ev) => f2.Activate();

            //Si cerramos el formulario hijo lo eliminamos de la ventana. Verficamos si quedan hijos.
            f2.FormClosed += (s, ev) => this.ventanaToolStripMenuItem.DropDownItems.Remove(fHijoIconsToolStripMenuItem);
            f2.FormClosed += ChildForm_FormClosed;
            f2.FormClosed += (s, ev) => this.numHijosMuertos++;

            //Si desactivamos el formulario hijo lo desmarcamos en la ventana.
            f2.Deactivate += (s, ev) => fHijoIconsToolStripMenuItem.Checked = false;

            //Si activamos el formulario hijo lo marcamos en la ventana.
            f2.Activated += (s, ev) => fHijoIconsToolStripMenuItem.Checked = true;
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
        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }
        /// <summary>
        /// Al seleccionar 'Cascada' en ventana ofrece una presentación en estilo cascada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }
        /// <summary>
        /// Al seleccionar 'Horizontal' en ventana ofrece una disposición horizontal de los formularios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }
        /// <summary>
        /// Al seleccionar 'Vertical' en ventana muestra una disposición vertical de los formularios hijos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }
    }
}
