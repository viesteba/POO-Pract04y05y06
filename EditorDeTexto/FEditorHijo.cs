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

            if(Path.GetExtension(direcc) == ".txt")
            {
                this.richTextBox1.LoadFile(direcc,RichTextBoxStreamType.PlainText);
            }
            else if(Path.GetExtension(direcc) == ".rtf")
            {
                this.richTextBox1.LoadFile(direcc,RichTextBoxStreamType.RichText);
            }
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
        /// <summary>
        /// Si no tiene dirección, lo guarda desde cero. 
        /// Si tiene dirección, lo guarda con su correspondiente extensión (txt o rtf).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Determina el título y lo guarda con la extensión correspondiente (txt o rtf).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Pregunta al usuario si quiere cerrar en caso de que no esté guardado. 
        /// Si quiere se cierra, si no quiere se guarda y si cancela vuelve al estado antes de hacer clic en cerrar. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Deshace los cambios no almacenados en el documento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Undo();
        }
        /// <summary>
        /// Corta el texto seleccionado en el documento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Cut();
        }
        /// <summary>
        /// Copia el texto seleccionado en el documento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Copy();
        }
        /// <summary>
        /// Pega el contenido del portapales en el docuemnto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }
        /// <summary>
        /// Determina los valores de la fuente y el color del documento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fuente = new FontDialog();
            fuente.ShowColor = true;

            if(fuente.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.Font = fuente.Font;
                this.richTextBox1.ForeColor = fuente.Color;
            };
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            this.guardarToolStripMenuItem_Click(sender, e);
        }
    }
}
