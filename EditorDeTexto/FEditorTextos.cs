using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            FEditorHijo f2 = new FEditorHijo();
            f2.MdiParent = this;
            f2.Text = "Documento " + numHijos;
            f2.Show();

            ////Activamos la ventana y añadimos un tsmi del formulario hijo
            this.ventanaToolStripMenuItem.Enabled = true;
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
        /// <summary>
        /// Determina el estilo de las ventanas de los formularios hijos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Cuando se hace clic sobre la barra de estado, si no está se muestra y si está desaparece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barraDeEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.barraDeEstadoToolStripMenuItem.Checked)
            {
                this.barraDeEstadoToolStripMenuItem.Checked = false;
                this.statusStrip1.Visible = false;
            }
            else
            {
                this.barraDeEstadoToolStripMenuItem.Checked = true;
                this.statusStrip1.Visible = true;
            }
        }
        /// <summary>
        /// Carga los eventos del mouse sobre el menuStrip
        /// </summary>
        private void cargarEventosEnStatusBar()
        {
            foreach(ToolStripMenuItem item in this.menuStrip1.Items)
            {
                item.MouseEnter += new EventHandler(menuStrip1_MouseEnter);
                item.MouseLeave += new EventHandler(menuStrip1_MouseLeave);
                
                foreach(ToolStripItem dropDownItem in item.DropDownItems)
                {
                    if(dropDownItem is ToolStripMenuItem)
                    {
                        dropDownItem.MouseEnter += new EventHandler(menuStrip1_MouseEnter);
                        dropDownItem.MouseLeave += new EventHandler(menuStrip1_MouseLeave);
                    }
                }
            }
        }
        /// <summary>
        /// Descargar los eventos del mouse sobre el menuStrip.
        /// </summary>
        private void descargarEventosEnStatusBar()
        {
            foreach (ToolStripMenuItem item in this.menuStrip1.Items)
            {
                item.MouseEnter -= new EventHandler(menuStrip1_MouseEnter);
                item.MouseLeave -= new EventHandler(menuStrip1_MouseLeave);

                foreach (ToolStripItem dropDownItem in item.DropDownItems)
                {
                    if(dropDownItem is ToolStripMenuItem)
                    {
                        dropDownItem.MouseEnter -= new EventHandler(menuStrip1_MouseEnter);
                        dropDownItem.MouseLeave -= new EventHandler(menuStrip1_MouseLeave);
                    }
                }
            }
        }

        /// <summary>
        /// Le da el nombre si tiene a la barra de estado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStrip1_MouseEnter(object sender, EventArgs e)
        {
            ToolStripMenuItem aux = sender as ToolStripMenuItem;
            if(aux != null)
            {
                this.toolStripStatusLabel1.Text = aux.Text;
            }
        }
        /// <summary>
        /// Elimina el nombre que tiene la barra de estado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "";
        }
        /// <summary>
        /// Abre el archivo que se seleccione en el formulario hijo activo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Seleccione el archivo a abrir";
            file.Filter = "Archivos de texto|*.txt|Todos los archivos|*.*";

            // Para seleccionar el archivo a abrir.
            DialogResult resultado = file.ShowDialog();
            if (resultado == DialogResult.OK) {
                FEditorHijo fhijo = new FEditorHijo(file.FileName);
                fhijo.MdiParent = this;
                numHijos++;
                fhijo.Show();
                fhijo.Text = Path.GetFileName(file.FileName);
            }
        }
        /// <summary>
        /// Completa el diseño descargando los eventos del mouse y cargando los nuevos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusStrip1_LayoutCompleted(object sender, EventArgs e)
        {
            this.descargarEventosEnStatusBar();
            this.cargarEventosEnStatusBar();
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem1_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.abrirToolStripMenuItem_Click((object) sender, e);
        }

        private void cerrarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(FEditorHijo fhijo in this.MdiChildren)
            {
                fhijo.Close();
            }
        }
    }
}
