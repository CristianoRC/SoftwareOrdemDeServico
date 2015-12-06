namespace View
{
    partial class Frm_NewOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NewOrcamento));
            this.Txt_NOrdem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.finalizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verificarNomeDoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_NomeCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_Observacoes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_ValorFinal = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Txt_NOrdem
            // 
            this.Txt_NOrdem.Location = new System.Drawing.Point(112, 43);
            this.Txt_NOrdem.Name = "Txt_NOrdem";
            this.Txt_NOrdem.Size = new System.Drawing.Size(207, 20);
            this.Txt_NOrdem.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero da ordem";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finalizarToolStripMenuItem,
            this.verificarNomeDoClienteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(357, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // finalizarToolStripMenuItem
            // 
            this.finalizarToolStripMenuItem.Image = global::View.Properties.Resources.Save_32;
            this.finalizarToolStripMenuItem.Name = "finalizarToolStripMenuItem";
            this.finalizarToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.finalizarToolStripMenuItem.Text = "Finalizar";
            this.finalizarToolStripMenuItem.Click += new System.EventHandler(this.finalizarToolStripMenuItem_Click);
            // 
            // verificarNomeDoClienteToolStripMenuItem
            // 
            this.verificarNomeDoClienteToolStripMenuItem.Image = global::View.Properties.Resources.Search_32;
            this.verificarNomeDoClienteToolStripMenuItem.Name = "verificarNomeDoClienteToolStripMenuItem";
            this.verificarNomeDoClienteToolStripMenuItem.Size = new System.Drawing.Size(166, 20);
            this.verificarNomeDoClienteToolStripMenuItem.Text = "Verificar nome do cliente";
            this.verificarNomeDoClienteToolStripMenuItem.Click += new System.EventHandler(this.verificarNomeDoClienteToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome do cliente";
            // 
            // Txt_NomeCliente
            // 
            this.Txt_NomeCliente.Location = new System.Drawing.Point(112, 83);
            this.Txt_NomeCliente.Name = "Txt_NomeCliente";
            this.Txt_NomeCliente.Size = new System.Drawing.Size(207, 20);
            this.Txt_NomeCliente.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Observações";
            // 
            // Txt_Observacoes
            // 
            this.Txt_Observacoes.Location = new System.Drawing.Point(112, 168);
            this.Txt_Observacoes.Multiline = true;
            this.Txt_Observacoes.Name = "Txt_Observacoes";
            this.Txt_Observacoes.Size = new System.Drawing.Size(207, 107);
            this.Txt_Observacoes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Valor final";
            // 
            // Txt_ValorFinal
            // 
            this.Txt_ValorFinal.Location = new System.Drawing.Point(112, 123);
            this.Txt_ValorFinal.Name = "Txt_ValorFinal";
            this.Txt_ValorFinal.Size = new System.Drawing.Size(207, 20);
            this.Txt_ValorFinal.TabIndex = 5;
            // 
            // Frm_NewOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(357, 297);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Txt_ValorFinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt_Observacoes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_NomeCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_NOrdem);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "Frm_NewOrcamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finalizar";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_NOrdem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem finalizarToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_NomeCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_Observacoes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_ValorFinal;
        private System.Windows.Forms.ToolStripMenuItem verificarNomeDoClienteToolStripMenuItem;
    }
}