namespace WordAddIn
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSuma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSumaLitere = new System.Windows.Forms.TextBox();
            this.btnTransforma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Suma";
            // 
            // tbxSuma
            // 
            this.tbxSuma.Location = new System.Drawing.Point(121, 52);
            this.tbxSuma.Name = "tbxSuma";
            this.tbxSuma.Size = new System.Drawing.Size(68, 20);
            this.tbxSuma.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Suma in litere";
            // 
            // tbxSumaLitere
            // 
            this.tbxSumaLitere.Location = new System.Drawing.Point(121, 94);
            this.tbxSumaLitere.Name = "tbxSumaLitere";
            this.tbxSumaLitere.ReadOnly = true;
            this.tbxSumaLitere.Size = new System.Drawing.Size(163, 20);
            this.tbxSumaLitere.TabIndex = 4;
            this.tbxSumaLitere.TextChanged += new System.EventHandler(this.tbxSumaLitere_TextChanged);
            // 
            // btnTransforma
            // 
            this.btnTransforma.Location = new System.Drawing.Point(121, 144);
            this.btnTransforma.Name = "btnTransforma";
            this.btnTransforma.Size = new System.Drawing.Size(75, 23);
            this.btnTransforma.TabIndex = 5;
            this.btnTransforma.Text = "Transforma";
            this.btnTransforma.UseVisualStyleBackColor = true;
            this.btnTransforma.Click += new System.EventHandler(this.btnTransforma_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 181);
            this.Controls.Add(this.btnTransforma);
            this.Controls.Add(this.tbxSumaLitere);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxSuma);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSuma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSumaLitere;
        private System.Windows.Forms.Button btnTransforma;
    }
}