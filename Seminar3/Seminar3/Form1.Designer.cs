namespace Seminar3
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
            this.mes = new System.Windows.Forms.Label();
            this.tVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.setVal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mes
            // 
            this.mes.AutoSize = true;
            this.mes.Location = new System.Drawing.Point(38, 209);
            this.mes.Name = "mes";
            this.mes.Size = new System.Drawing.Size(0, 13);
            this.mes.TabIndex = 0;
            // 
            // tVal
            // 
            this.tVal.Location = new System.Drawing.Point(84, 58);
            this.tVal.Name = "tVal";
            this.tVal.Size = new System.Drawing.Size(100, 20);
            this.tVal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Valoare";
            // 
            // setVal
            // 
            this.setVal.Location = new System.Drawing.Point(84, 118);
            this.setVal.Name = "setVal";
            this.setVal.Size = new System.Drawing.Size(100, 21);
            this.setVal.TabIndex = 3;
            this.setVal.Text = "Seteaza valoare";
            this.setVal.UseVisualStyleBackColor = true;
            this.setVal.Click += new System.EventHandler(this.setVal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.setVal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tVal);
            this.Controls.Add(this.mes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mes;
        private System.Windows.Forms.TextBox tVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setVal;
    }
}