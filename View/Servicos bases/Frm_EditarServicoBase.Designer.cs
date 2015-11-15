namespace View
{
    partial class Frm_EditarServicoBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_EditarServicoBase));
            this.Txt_Observacoes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_Valor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Nome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btm_Carregar = new System.Windows.Forms.Button();
            this.Txt_ServicoBase = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Txt_Observacoes
            // 
            this.Txt_Observacoes.Location = new System.Drawing.Point(95, 166);
            this.Txt_Observacoes.Multiline = true;
            this.Txt_Observacoes.Name = "Txt_Observacoes";
            this.Txt_Observacoes.Size = new System.Drawing.Size(234, 131);
            this.Txt_Observacoes.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Observações";
            // 
            // Txt_Valor
            // 
            this.Txt_Valor.Location = new System.Drawing.Point(95, 129);
            this.Txt_Valor.Name = "Txt_Valor";
            this.Txt_Valor.Size = new System.Drawing.Size(234, 20);
            this.Txt_Valor.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Valor";
            // 
            // Txt_Nome
            // 
            this.Txt_Nome.Location = new System.Drawing.Point(95, 94);
            this.Txt_Nome.Name = "Txt_Nome";
            this.Txt_Nome.Size = new System.Drawing.Size(234, 20);
            this.Txt_Nome.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nome";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(397, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salvarToolStripMenuItem.Image")));
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.salvarToolStripMenuItem.Text = "Salvar";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.Btm_Carregar);
            this.panel1.Controls.Add(this.Txt_ServicoBase);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 34);
            this.panel1.TabIndex = 14;
            // 
            // Btm_Carregar
            // 
            this.Btm_Carregar.Location = new System.Drawing.Point(260, 4);
            this.Btm_Carregar.Name = "Btm_Carregar";
            this.Btm_Carregar.Size = new System.Drawing.Size(75, 23);
            this.Btm_Carregar.TabIndex = 15;
            this.Btm_Carregar.Text = "Carregar";
            this.Btm_Carregar.UseVisualStyleBackColor = true;
            this.Btm_Carregar.Click += new System.EventHandler(this.Btm_Carregar_Click);
            // 
            // Txt_ServicoBase
            // 
            this.Txt_ServicoBase.FormattingEnabled = true;
            this.Txt_ServicoBase.Location = new System.Drawing.Point(7, 6);
            this.Txt_ServicoBase.Name = "Txt_ServicoBase";
            this.Txt_ServicoBase.Size = new System.Drawing.Size(238, 21);
            this.Txt_ServicoBase.TabIndex = 16;
            // 
            // Frm_EditarServicoBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 338);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Txt_Observacoes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Txt_Valor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Nome);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_EditarServicoBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar serviço base";
            this.Load += new System.EventHandler(this.Frm_EditarServicoBase_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Observacoes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_Valor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Nome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btm_Carregar;
        private System.Windows.Forms.ComboBox Txt_ServicoBase;
    }
}