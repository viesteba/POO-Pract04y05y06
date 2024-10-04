namespace EditorDeTexto
{
    partial class FEditorHijo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.botonCierre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(436, 275);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // botonCierre
            // 
            this.botonCierre.Location = new System.Drawing.Point(116, 88);
            this.botonCierre.Name = "botonCierre";
            this.botonCierre.Size = new System.Drawing.Size(182, 96);
            this.botonCierre.TabIndex = 1;
            this.botonCierre.Text = "Cerrar";
            this.botonCierre.UseVisualStyleBackColor = true;
            this.botonCierre.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FEditorHijo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(436, 275);
            this.Controls.Add(this.botonCierre);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FEditorHijo";
            this.Text = "Documento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FEditorHijo_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button botonCierre;
    }
}