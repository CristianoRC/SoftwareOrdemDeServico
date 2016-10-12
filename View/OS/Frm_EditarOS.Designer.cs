namespace View.OS
{
    partial class Frm_EditarOS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_EditarOS));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Txt_IDPesquisa = new System.Windows.Forms.ComboBox();
            this.Btm_Carregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Cliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_DataEntrada = new System.Windows.Forms.MaskedTextBox();
            this.Txt_Descricao = new System.Windows.Forms.TextBox();
            this.Lbl_Descricao = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Txt_Equipamento = new System.Windows.Forms.TextBox();
            this.Lbl_Equipamento = new System.Windows.Forms.Label();
            this.Txt_Defeito = new System.Windows.Forms.TextBox();
            this.lBL_dEFEITO = new System.Windows.Forms.Label();
            this.Txt_Nserie = new System.Windows.Forms.TextBox();
            this.Lbl_Nserie = new System.Windows.Forms.Label();
            this.Txt_Observacoes = new System.Windows.Forms.TextBox();
            this.Lbl_Observacoes = new System.Windows.Forms.Label();
            this.Txt_Situacao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(833, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 248);
            this.button1.TabIndex = 17;
            this.toolTip1.SetToolTip(this.button1, "Salvar");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Txt_IDPesquisa);
            this.panel1.Controls.Add(this.Btm_Carregar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 44);
            this.panel1.TabIndex = 0;
            // 
            // Txt_IDPesquisa
            // 
            this.Txt_IDPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Txt_IDPesquisa.Location = new System.Drawing.Point(126, 10);
            this.Txt_IDPesquisa.Name = "Txt_IDPesquisa";
            this.Txt_IDPesquisa.Size = new System.Drawing.Size(207, 21);
            this.Txt_IDPesquisa.TabIndex = 1;
            // 
            // Btm_Carregar
            // 
            this.Btm_Carregar.Location = new System.Drawing.Point(362, 8);
            this.Btm_Carregar.Name = "Btm_Carregar";
            this.Btm_Carregar.Size = new System.Drawing.Size(75, 23);
            this.Btm_Carregar.TabIndex = 2;
            this.Btm_Carregar.Text = "Carregar";
            this.Btm_Carregar.UseVisualStyleBackColor = true;
            this.Btm_Carregar.Click += new System.EventHandler(this.Btm_Pesquisa_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ordem de serviço:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(919, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Salvar";
            // 
            // Txt_Cliente
            // 
            this.Txt_Cliente.Location = new System.Drawing.Point(104, 51);
            this.Txt_Cliente.Name = "Txt_Cliente";
            this.Txt_Cliente.Size = new System.Drawing.Size(207, 21);
            this.Txt_Cliente.TabIndex = 2;
            this.Txt_Cliente.TextUpdate += new System.EventHandler(this.Txt_Cliente_TextUpdate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cliente";
            // 
            // Txt_DataEntrada
            // 
            this.Txt_DataEntrada.Enabled = false;
            this.Txt_DataEntrada.Location = new System.Drawing.Point(532, 55);
            this.Txt_DataEntrada.Name = "Txt_DataEntrada";
            this.Txt_DataEntrada.Size = new System.Drawing.Size(207, 20);
            this.Txt_DataEntrada.TabIndex = 12;
            // 
            // Txt_Descricao
            // 
            this.Txt_Descricao.Location = new System.Drawing.Point(532, 133);
            this.Txt_Descricao.Multiline = true;
            this.Txt_Descricao.Name = "Txt_Descricao";
            this.Txt_Descricao.Size = new System.Drawing.Size(207, 120);
            this.Txt_Descricao.TabIndex = 16;
            // 
            // Lbl_Descricao
            // 
            this.Lbl_Descricao.AutoSize = true;
            this.Lbl_Descricao.Location = new System.Drawing.Point(457, 133);
            this.Lbl_Descricao.Name = "Lbl_Descricao";
            this.Lbl_Descricao.Size = new System.Drawing.Size(55, 13);
            this.Lbl_Descricao.TabIndex = 15;
            this.Lbl_Descricao.Text = "Descrição";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(457, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Data entrada";
            // 
            // Txt_Equipamento
            // 
            this.Txt_Equipamento.Location = new System.Drawing.Point(104, 126);
            this.Txt_Equipamento.Name = "Txt_Equipamento";
            this.Txt_Equipamento.Size = new System.Drawing.Size(207, 20);
            this.Txt_Equipamento.TabIndex = 6;
            // 
            // Lbl_Equipamento
            // 
            this.Lbl_Equipamento.AutoSize = true;
            this.Lbl_Equipamento.Location = new System.Drawing.Point(29, 130);
            this.Lbl_Equipamento.Name = "Lbl_Equipamento";
            this.Lbl_Equipamento.Size = new System.Drawing.Size(69, 13);
            this.Lbl_Equipamento.TabIndex = 5;
            this.Lbl_Equipamento.Text = "Equipamento";
            // 
            // Txt_Defeito
            // 
            this.Txt_Defeito.Location = new System.Drawing.Point(104, 218);
            this.Txt_Defeito.Multiline = true;
            this.Txt_Defeito.Name = "Txt_Defeito";
            this.Txt_Defeito.Size = new System.Drawing.Size(207, 97);
            this.Txt_Defeito.TabIndex = 10;
            // 
            // lBL_dEFEITO
            // 
            this.lBL_dEFEITO.AutoSize = true;
            this.lBL_dEFEITO.Location = new System.Drawing.Point(29, 221);
            this.lBL_dEFEITO.Name = "lBL_dEFEITO";
            this.lBL_dEFEITO.Size = new System.Drawing.Size(41, 13);
            this.lBL_dEFEITO.TabIndex = 9;
            this.lBL_dEFEITO.Text = "Defeito";
            // 
            // Txt_Nserie
            // 
            this.Txt_Nserie.Location = new System.Drawing.Point(104, 178);
            this.Txt_Nserie.Name = "Txt_Nserie";
            this.Txt_Nserie.Size = new System.Drawing.Size(207, 20);
            this.Txt_Nserie.TabIndex = 8;
            // 
            // Lbl_Nserie
            // 
            this.Lbl_Nserie.AutoSize = true;
            this.Lbl_Nserie.Location = new System.Drawing.Point(29, 182);
            this.Lbl_Nserie.Name = "Lbl_Nserie";
            this.Lbl_Nserie.Size = new System.Drawing.Size(64, 13);
            this.Lbl_Nserie.TabIndex = 7;
            this.Lbl_Nserie.Text = "Nº  de Serie";
            // 
            // Txt_Observacoes
            // 
            this.Txt_Observacoes.Location = new System.Drawing.Point(532, 94);
            this.Txt_Observacoes.Name = "Txt_Observacoes";
            this.Txt_Observacoes.Size = new System.Drawing.Size(207, 20);
            this.Txt_Observacoes.TabIndex = 14;
            // 
            // Lbl_Observacoes
            // 
            this.Lbl_Observacoes.AutoSize = true;
            this.Lbl_Observacoes.Location = new System.Drawing.Point(456, 97);
            this.Lbl_Observacoes.Name = "Lbl_Observacoes";
            this.Lbl_Observacoes.Size = new System.Drawing.Size(70, 13);
            this.Lbl_Observacoes.TabIndex = 13;
            this.Lbl_Observacoes.Text = "Observações";
            // 
            // Txt_Situacao
            // 
            this.Txt_Situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Txt_Situacao.Items.AddRange(new object[] {
            "Avaliação",
            "Orçamento",
            "Manutenção",
            "Montagem",
            "Finalizado"});
            this.Txt_Situacao.Location = new System.Drawing.Point(104, 89);
            this.Txt_Situacao.Name = "Txt_Situacao";
            this.Txt_Situacao.Size = new System.Drawing.Size(207, 21);
            this.Txt_Situacao.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Situação";
            // 
            // Frm_EditarOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 326);
            this.Controls.Add(this.Txt_Situacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Cliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Txt_DataEntrada);
            this.Controls.Add(this.Txt_Descricao);
            this.Controls.Add(this.Lbl_Descricao);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Txt_Equipamento);
            this.Controls.Add(this.Lbl_Equipamento);
            this.Controls.Add(this.Txt_Defeito);
            this.Controls.Add(this.lBL_dEFEITO);
            this.Controls.Add(this.Txt_Nserie);
            this.Controls.Add(this.Lbl_Nserie);
            this.Controls.Add(this.Txt_Observacoes);
            this.Controls.Add(this.Lbl_Observacoes);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_EditarOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Ordem de serviço";
            this.Load += new System.EventHandler(this.Frm_EditarOS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btm_Carregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Txt_IDPesquisa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Txt_Cliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox Txt_DataEntrada;
        private System.Windows.Forms.TextBox Txt_Descricao;
        private System.Windows.Forms.Label Lbl_Descricao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Txt_Equipamento;
        private System.Windows.Forms.Label Lbl_Equipamento;
        private System.Windows.Forms.TextBox Txt_Defeito;
        private System.Windows.Forms.Label lBL_dEFEITO;
        private System.Windows.Forms.TextBox Txt_Nserie;
        private System.Windows.Forms.Label Lbl_Nserie;
        private System.Windows.Forms.TextBox Txt_Observacoes;
        private System.Windows.Forms.Label Lbl_Observacoes;
        private System.Windows.Forms.ComboBox Txt_Situacao;
        private System.Windows.Forms.Label label1;
    }
}