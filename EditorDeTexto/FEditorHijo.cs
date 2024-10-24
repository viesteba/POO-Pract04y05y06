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
    public partial class FEditorHijo : Form
    {
        private string direccion;
        /// <summary>
        /// Inicializa las componentes del formulario.
        /// </summary>
        public FEditorHijo()
        {
            InitializeComponent();
            this.direccion = "";
        }
        /// <summary>
        /// Pre: direcc es la dirección donde se quiere almacenar el documento
        /// Pos: Define la dirección e inicializa las componentes del formulario.
        /// </summary>
        /// <param name="numero"></param>
        public FEditorHijo(string direcc)
        {
            InitializeComponent();
            this.direccion = direcc;

            this.Text = Path.GetFileName(direcc);
            this.Name = "form" + this.Text;

            RichTextBox rtb = new RichTextBox();
            if(Path.GetExtension(direcc) == ".txt")
            {
                rtb.LoadFile(direcc,RichTextBoxStreamType.PlainText);
            }
            else if(Path.GetExtension(direcc) == ".rtf")
            {
                rtb.LoadFile(direcc,RichTextBoxStreamType.RichText);
            }
            this.richTextBox1.Text = rtb.Text;
        }
        /// <summary>
        /// Avisa del cierre del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FEditorHijo_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Se ha cerrado " + this.Text);
        }
        /// <summary>
        /// Cierra el formulario cuando pulsas sobre el botón 'Cerrar'.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.direccion == "")
            {
                this.guardarComoToolStripMenuItem.PerformClick();
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                if(Path.GetExtension(this.direccion) == ".txt")
                {
                    this.richTextBox1.SaveFile(this.direccion, RichTextBoxStreamType.PlainText);
                }
                else if(Path.GetExtension(this.direccion) == ".rtf")
                {
                    this.richTextBox1.SaveFile(this.direccion, RichTextBoxStreamType.RichText);
                }
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Title = "Seleccione el archivo a guardar";
            save.Filter = "Archivos de texto|*.txt|Todos los archivos|*.*";

            DialogResult resultado = save.ShowDialog();
            this.direccion = save.FileName;

            if (resultado == DialogResult.OK)
            {
                if (Path.GetExtension(save.FileName) == ".txt")
                {
                    this.richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                }
                else if (Path.GetExtension(save.FileName) == ".rtf")
                {
                    this.richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.RichText);
                }
            }
        }

        private void FEditorHijo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.richTextBox1.Modified)
            {
                DialogResult respuesta = MessageBox.Show("¿Quieres cerrar sin guardar?", "Aviso", MessageBoxButtons.YesNoCancel);
                if (respuesta == DialogResult.No)
                {
                    this.guardarToolStripMenuItem.PerformClick();
                }
                else if (respuesta == DialogResult.Cancel) {
                    e.Cancel = true;
                }
            }
        }
    }
}
