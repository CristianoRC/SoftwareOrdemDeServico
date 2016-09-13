namespace View.Pessoas
{
    partial class Frm_ListarClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ListarClientes));
            this.Btm_Atualizar = new System.Windows.Forms.Button();
            this.Data_Os = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Os)).BeginInit();
            this.SuspendLayout();
            // 
            // Btm_Atualizar
            // 
            this.Btm_Atualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btm_Atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btm_Atualizar.Location = new System.Drawing.Point(976, 410);
            this.Btm_Atualizar.Name = "Btm_Atualizar";
            this.Btm_Atualizar.Size = new System.Drawing.Size(123, 23);
            this.Btm_Atualizar.TabIndex = 5;
            this.Btm_Atualizar.Text = "Atualizar";
            this.Btm_Atualizar.UseVisualStyleBackColor = true;
            this.Btm_Atualizar.Click += new System.EventHandler(this.Btm_Atualizar_Click);
            // 
            // Data_Os
            // 
            this.Data_Os.AllowUserToAddRows = false;
            this.Data_Os.AllowUserToDeleteRows = false;
            this.Data_Os.AllowUserToOrderColumns = true;
            this.Data_Os.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Data_Os.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Data_Os.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_Os.Location = new System.Drawing.Point(0, -1);
            this.Data_Os.Name = "Data_Os";
            this.Data_Os.ReadOnly = true;
            this.Data_Os.Size = new System.Drawing.Size(1108, 406);
            this.Data_Os.TabIndex = 4;
            this.Data_Os.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Data_Os_CellMouseDoubleClick);
            // 
            // Frm_ListarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1111, 445);
            this.Controls.Add(this.Btm_Atualizar);
            this.Controls.Add(this.Data_Os);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_ListarClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Clientes";
            this.Load += new System.EventHandler(this.Frm_ListarClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Os)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btm_Atualizar;
        private System.Windows.Forms.DataGridView Data_Os;
    }
}