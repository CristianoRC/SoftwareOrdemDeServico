namespace View
{
    partial class Frm_ListarServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ListarServico));
            this.Data_Os = new System.Windows.Forms.DataGridView();
            this.Coluna_Identificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cluna_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coluna_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Os)).BeginInit();
            this.SuspendLayout();
            // 
            // Data_Os
            // 
            this.Data_Os.AllowUserToAddRows = false;
            this.Data_Os.AllowUserToDeleteRows = false;
            this.Data_Os.AllowUserToOrderColumns = true;
            this.Data_Os.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Data_Os.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Data_Os.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_Os.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Coluna_Identificador,
            this.Cluna_Cliente,
            this.Coluna_Data,
            this.Valor});
            this.Data_Os.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Data_Os.EnableHeadersVisualStyles = false;
            this.Data_Os.Location = new System.Drawing.Point(0, 0);
            this.Data_Os.MultiSelect = false;
            this.Data_Os.Name = "Data_Os";
            this.Data_Os.Size = new System.Drawing.Size(985, 444);
            this.Data_Os.TabIndex = 1;
            // 
            // Coluna_Identificador
            // 
            this.Coluna_Identificador.HeaderText = "Serviço";
            this.Coluna_Identificador.Name = "Coluna_Identificador";
            // 
            // Cluna_Cliente
            // 
            this.Cluna_Cliente.HeaderText = "Cliente";
            this.Cluna_Cliente.Name = "Cluna_Cliente";
            // 
            // Coluna_Data
            // 
            this.Coluna_Data.HeaderText = "Descrição";
            this.Coluna_Data.Name = "Coluna_Data";
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Frm_ListarServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 444);
            this.Controls.Add(this.Data_Os);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_ListarServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de serviços";
            this.Load += new System.EventHandler(this.Frm_ListarServico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Os)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Data_Os;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coluna_Identificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cluna_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coluna_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
    }
}