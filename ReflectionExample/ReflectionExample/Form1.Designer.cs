﻿namespace ReflectionExample
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
            this.btnLoadAssembly = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxClassName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxAccesType = new System.Windows.Forms.ComboBox();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadAssembly
            // 
            this.btnLoadAssembly.Location = new System.Drawing.Point(22, 25);
            this.btnLoadAssembly.Name = "btnLoadAssembly";
            this.btnLoadAssembly.Size = new System.Drawing.Size(99, 24);
            this.btnLoadAssembly.TabIndex = 0;
            this.btnLoadAssembly.Text = "Load assembly";
            this.btnLoadAssembly.UseVisualStyleBackColor = true;
            this.btnLoadAssembly.Click += new System.EventHandler(this.btnLoadAssembly_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show methods";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class name";
            // 
            // cbxClassName
            // 
            this.cbxClassName.FormattingEnabled = true;
            this.cbxClassName.Location = new System.Drawing.Point(113, 137);
            this.cbxClassName.Name = "cbxClassName";
            this.cbxClassName.Size = new System.Drawing.Size(121, 21);
            this.cbxClassName.TabIndex = 3;
            this.cbxClassName.SelectedIndexChanged += new System.EventHandler(this.cbxClassName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Acces type";
            // 
            // cbxAccesType
            // 
            this.cbxAccesType.FormattingEnabled = true;
            this.cbxAccesType.Items.AddRange(new object[] {
            "Public",
            "NonPublic"});
            this.cbxAccesType.Location = new System.Drawing.Point(113, 175);
            this.cbxAccesType.Name = "cbxAccesType";
            this.cbxAccesType.Size = new System.Drawing.Size(121, 21);
            this.cbxAccesType.TabIndex = 5;
            this.cbxAccesType.SelectedIndexChanged += new System.EventHandler(this.cbxAccesType_SelectedIndexChanged);
            // 
            // tbxResult
            // 
            this.tbxResult.Location = new System.Drawing.Point(280, 137);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.Size = new System.Drawing.Size(477, 156);
            this.tbxResult.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(35, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Show fields";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(35, 274);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Show properties";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 339);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbxResult);
            this.Controls.Add(this.cbxAccesType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxClassName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadAssembly);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadAssembly;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxAccesType;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

