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
            this.Btm_Atualizar = new System.Windows.Forms.Button();
            this.lbl_Filtro = new System.Windows.Forms.Label();
            this.comboBox_FiltroInicial = new System.Windows.Forms.ComboBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.comboBox_Clientes = new System.Windows.Forms.ComboBox();
            this.checkBox_Filtro = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Os)).BeginInit();
            this.SuspendLayout();
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
            this.Data_Os.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Data_Os.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_Os.EnableHeadersVisualStyles = false;
            this.Data_Os.Location = new System.Drawing.Point(0, 56);
            this.Data_Os.MultiSelect = false;
            this.Data_Os.Name = "Data_Os";
            this.Data_Os.ReadOnly = true;
            this.Data_Os.Size = new System.Drawing.Size(1082, 417);
            this.Data_Os.TabIndex = 0;
            this.Data_Os.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Data_Os_CellMouseDoubleClick);
            // 
            // Btm_Atualizar
            // 
            this.Btm_Atualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btm_Atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btm_Atualizar.Location = new System.Drawing.Point(928, 16);
            this.Btm_Atualizar.Name = "Btm_Atualizar";
            this.Btm_Atualizar.Size = new System.Drawing.Size(123, 23);
            this.Btm_Atualizar.TabIndex = 1;
            this.Btm_Atualizar.Text = "Atualizar";
            this.Btm_Atualizar.UseVisualStyleBackColor = true;
            this.Btm_Atualizar.Click += new System.EventHandler(this.Btm_Atualizar_Click);
            // 
            // lbl_Filtro
            // 
            this.lbl_Filtro.AutoSize = true;
            this.lbl_Filtro.Location = new System.Drawing.Point(12, 21);
            this.lbl_Filtro.Name = "lbl_Filtro";
            this.lbl_Filtro.Size = new System.Drawing.Size(92, 13);
            this.lbl_Filtro.TabIndex = 2;
            this.lbl_Filtro.Text = "Filtro de pesquisa:";
            // 
            // comboBox_FiltroInicial
            // 
            this.comboBox_FiltroInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FiltroInicial.FormattingEnabled = true;
            this.comboBox_FiltroInicial.Items.AddRange(new object[] {
            "Cliente"});
            this.comboBox_FiltroInicial.Location = new System.Drawing.Point(122, 18);
            this.comboBox_FiltroInicial.Name = "comboBox_FiltroInicial";
            this.comboBox_FiltroInicial.Size = new System.Drawing.Size(169, 21);
            this.comboBox_FiltroInicial.TabIndex = 3;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "É",
            "Não é"});
            this.comboBoxStatus.Location = new System.Drawing.Point(311, 18);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(84, 21);
            this.comboBoxStatus.TabIndex = 4;
            // 
            // comboBox_Clientes
            // 
            this.comboBox_Clientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Clientes.FormattingEnabled = true;
            this.comboBox_Clientes.Location = new System.Drawing.Point(421, 18);
            this.comboBox_Clientes.Name = "comboBox_Clientes";
            this.comboBox_Clientes.Size = new System.Drawing.Size(387, 21);
            this.comboBox_Clientes.TabIndex = 5;
            // 
            // checkBox_Filtro
            // 
            this.checkBox_Filtro.AutoSize = true;
            this.checkBox_Filtro.Location = new System.Drawing.Point(832, 21);
            this.checkBox_Filtro.Name = "checkBox_Filtro";
            this.checkBox_Filtro.Size = new System.Drawing.Size(79, 17);
            this.checkBox_Filtro.TabIndex = 6;
            this.checkBox_Filtro.Text = "Utilizar filtro";
            this.checkBox_Filtro.UseVisualStyleBackColor = true;
            // 
            // Frm_ListarOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1082, 477);
            this.Controls.Add(this.checkBox_Filtro);
            this.Controls.Add(this.comboBox_Clientes);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.comboBox_FiltroInicial);
            this.Controls.Add(this.lbl_Filtro);
            this.Controls.Add(this.Btm_Atualizar);
            this.Controls.Add(this.Data_Os);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_ListarOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de ordens de serviço";
            this.Load += new System.EventHandler(this.Frm_ListarOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Os)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView Data_Os;
        private System.Windows.Forms.Button Btm_Atualizar;
        private System.Windows.Forms.Label lbl_Filtro;
        private System.Windows.Forms.ComboBox comboBox_FiltroInicial;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.ComboBox comboBox_Clientes;
        private System.Windows.Forms.CheckBox checkBox_Filtro;
    }
}