namespace View.OS
{
    partial class Frm_ListarOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ListarOS));
            this.Data_Os = new System.Windows.Forms.DataGridView();
            this.Coluna_Identificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coluna_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coluna_situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cluna_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coluna_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Os)).BeginInit();
            this.SuspendLayout();
            // 
            // Data_Os
            // 
            this.Data_Os.AllowUserToAddRows = false;
            this.Data_Os.AllowUserToDeleteRows = false;
            this.Data_Os.AllowUserToOrderColumns = true;
            this.Data_Os.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Data_Os.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_Os.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Coluna_Identificador,
            this.Coluna_Produto,
            this.Coluna_situacao,
            this.Cluna_Cliente,
            this.Coluna_Data});
            this.Data_Os.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Data_Os.Location = new System.Drawing.Point(0, 0);
            this.Data_Os.Name = "Data_Os";
            this.Data_Os.ReadOnly = true;
            this.Data_Os.Size = new System.Drawing.Size(985, 444);
            this.Data_Os.TabIndex = 0;
            // 
            // Coluna_Identificador
            // 
            this.Coluna_Identificador.HeaderText = "Ordem de serviço";
            this.Coluna_Identificador.Name = "Coluna_Identificador";
            this.Coluna_Identificador.ReadOnly = true;
            // 
            // Coluna_Produto
            // 
            this.Coluna_Produto.HeaderText = "Equipamento";
            this.Coluna_Produto.Name = "Coluna_Produto";
            this.Coluna_Produto.ReadOnly = true;
            // 
            // Coluna_situacao
            // 
            this.Coluna_situacao.HeaderText = "Situação";
            this.Coluna_situacao.Name = "Coluna_situacao";
            this.Coluna_situacao.ReadOnly = true;
            // 
            // Cluna_Cliente
            // 
            this.Cluna_Cliente.HeaderText = "Cliente";
            this.Cluna_Cliente.Name = "Cluna_Cliente";
            this.Cluna_Cliente.ReadOnly = true;
            // 
            // Coluna_Data
            // 
            this.Coluna_Data.HeaderText = "Data de entrada";
            this.Coluna_Data.Name = "Coluna_Data";
            this.Coluna_Data.ReadOnly = true;
            // 
            // Frm_ListarOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 444);
            this.Controls.Add(this.Data_Os);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_ListarOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de ordens de serviço";
            this.Load += new System.EventHandler(this.Frm_ListarOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Os)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Data_Os;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coluna_Identificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coluna_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coluna_situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cluna_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coluna_Data;
    }
}