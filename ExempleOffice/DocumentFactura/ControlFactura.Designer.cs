namespace DocumentFactura
{
    partial class ControlFactura
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
            this.btnStergeRand = new System.Windows.Forms.Button();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.numCantitate = new System.Windows.Forms.NumericUpDown();
            this.lblCantitate = new System.Windows.Forms.Label();
            this.cmbProduse = new System.Windows.Forms.ComboBox();
            this.lblProdus = new System.Windows.Forms.Label();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.lblClient = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCantitate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStergeRand
            // 
            this.btnStergeRand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStergeRand.Location = new System.Drawing.Point(5, 155);
            this.btnStergeRand.Name = "btnStergeRand";
            this.btnStergeRand.Size = new System.Drawing.Size(176, 23);
            this.btnStergeRand.TabIndex = 11;
            this.btnStergeRand.Text = "Sterge Ultimul Rand";
            this.btnStergeRand.UseVisualStyleBackColor = true;
            this.btnStergeRand.Click += new System.EventHandler(this.btnStergeRand_Click);
            // 
            // btnAdauga
            // 
            this.btnAdauga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdauga.Location = new System.Drawing.Point(5, 92);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(176, 23);
            this.btnAdauga.TabIndex = 10;
            this.btnAdauga.Text = "Adaugă produs";
            this.btnAdauga.UseVisualStyleBackColor = true;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // numCantitate
            // 
            this.numCantitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numCantitate.Location = new System.Drawing.Point(4, 65);
            this.numCantitate.Name = "numCantitate";
            this.numCantitate.Size = new System.Drawing.Size(177, 20);
            this.numCantitate.TabIndex = 9;
            // 
            // lblCantitate
            // 
            this.lblCantitate.AutoSize = true;
            this.lblCantitate.Location = new System.Drawing.Point(1, 49);
            this.lblCantitate.Name = "lblCantitate";
            this.lblCantitate.Size = new System.Drawing.Size(52, 13);
            this.lblCantitate.TabIndex = 8;
            this.lblCantitate.Text = "Cantitate:";
            // 
            // cmbProduse
            // 
            this.cmbProduse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProduse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduse.FormattingEnabled = true;
            this.cmbProduse.Location = new System.Drawing.Point(4, 21);
            this.cmbProduse.Name = "cmbProduse";
            this.cmbProduse.Size = new System.Drawing.Size(177, 21);
            this.cmbProduse.TabIndex = 7;
            // 
            // lblProdus
            // 
            this.lblProdus.AutoSize = true;
            this.lblProdus.Location = new System.Drawing.Point(1, 4);
            this.lblProdus.Name = "lblProdus";
            this.lblProdus.Size = new System.Drawing.Size(43, 13);
            this.lblProdus.TabIndex = 6;
            this.lblProdus.Text = "Produs:";
            // 
            // btnSalvare
            // 
            this.btnSalvare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvare.Location = new System.Drawing.Point(4, 344);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(176, 23);
            this.btnSalvare.TabIndex = 12;
            this.btnSalvare.Text = "Salveaza PDF";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(1, 201);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(42, 13);
            this.lblClient.TabIndex = 14;
            this.lblClient.Text = "Client: -";
            // 
            // ControlFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.btnStergeRand);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.numCantitate);
            this.Controls.Add(this.lblCantitate);
            this.Controls.Add(this.cmbProduse);
            this.Controls.Add(this.lblProdus);
            this.Name = "ControlFactura";
            this.Size = new System.Drawing.Size(183, 370);
            ((System.ComponentModel.ISupportInitialize)(this.numCantitate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStergeRand;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.NumericUpDown numCantitate;
        private System.Windows.Forms.Label lblCantitate;
        private System.Windows.Forms.ComboBox cmbProduse;
        private System.Windows.Forms.Label lblProdus;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Label lblClient;
    }
}
