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
    public partial class FEditorHijo : Form
    {
        /// <summary>
        /// Inicializa las componentes del formulario.
        /// </summary>
        public FEditorHijo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Define el nombre e inicializa las componentes del formulario.
        /// </summary>
        /// <param name="numero"></param>
        public FEditorHijo(int numero)
        {
            InitializeComponent();
            this.Text = "Documento" + numero;
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
        public void rellenarRichTextBox(string name, RichTextBoxStreamType rtbst)
        {
            this.richTextBox1.LoadFile(name, rtbst);
        }
    }
}
