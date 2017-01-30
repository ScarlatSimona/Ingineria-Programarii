namespace DocumentChitanta
{
    partial class RegieCaminControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCNPStudent = new System.Windows.Forms.TextBox();
            this.tbxSumaPlatita = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnVizualizareStudenti = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(17, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Incarca date";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CNP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Suma";
            // 
            // tbxCNPStudent
            // 
            this.tbxCNPStudent.Location = new System.Drawing.Point(84, 41);
            this.tbxCNPStudent.Name = "tbxCNPStudent";
            this.tbxCNPStudent.Size = new System.Drawing.Size(158, 20);
            this.tbxCNPStudent.TabIndex = 3;
            // 
            // tbxSumaPlatita
            // 
            this.tbxSumaPlatita.Location = new System.Drawing.Point(84, 65);
            this.tbxSumaPlatita.Name = "tbxSumaPlatita";
            this.tbxSumaPlatita.Size = new System.Drawing.Size(62, 20);
            this.tbxSumaPlatita.TabIndex = 4;
            this.tbxSumaPlatita.DoubleClick += new System.EventHandler(this.tbxSumaPlatita_DoubleClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(17, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "Salveaza plata";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Location = new System.Drawing.Point(17, 181);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 34);
            this.button3.TabIndex = 6;
            this.button3.Text = "Exporta PDF";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // btnVizualizareStudenti
            // 
            this.btnVizualizareStudenti.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVizualizareStudenti.Location = new System.Drawing.Point(17, 370);
            this.btnVizualizareStudenti.Name = "btnVizualizareStudenti";
            this.btnVizualizareStudenti.Size = new System.Drawing.Size(106, 25);
            this.btnVizualizareStudenti.TabIndex = 7;
            this.btnVizualizareStudenti.Text = "Restantieri regie";
            this.btnVizualizareStudenti.UseVisualStyleBackColor = false;
            this.btnVizualizareStudenti.Click += new System.EventHandler(this.btnVizualizareStudenti_Click);
            // 
            // RegieCaminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVizualizareStudenti);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbxSumaPlatita);
            this.Controls.Add(this.tbxCNPStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "RegieCaminControl";
            this.Size = new System.Drawing.Size(259, 495);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCNPStudent;
        private System.Windows.Forms.TextBox tbxSumaPlatita;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Button btnVizualizareStudenti;
    }
}
