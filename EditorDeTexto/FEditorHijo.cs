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
        public FEditorHijo()
        {
            InitializeComponent();
        }
        public FEditorHijo(int numero)
        {
            InitializeComponent();
            this.Text = "Documento" + numero;
        }

        private void FEditorHijo_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Se ha cerrado " + this.Text);
        }
    }
}
