namespace View
{
    partial class Frm_Pai
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Pai));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ordensDeServiçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaF5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pessoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jurídicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opiçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telaInicialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirPainelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lbl_Nome = new System.Windows.Forms.Label();
            this.Lbl_HoraData = new System.Windows.Forms.Label();
            this.Lbl_NomeEmpresa = new System.Windows.Forms.Label();
            this.Pic_LgoEmpresa = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listarFísicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_LgoEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.ordensDeServiçosToolStripMenuItem,
            this.pessoaToolStripMenuItem,
            this.opiçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1131, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.inicioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inicioToolStripMenuItem.Image")));
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.inicioToolStripMenuItem.Text = "&Inicio";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sairToolStripMenuItem.Image")));
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.sairToolStripMenuItem.Text = "&Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.excluirToolStripMenuItem,
            this.listarToolStripMenuItem2});
            this.usuariosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usuariosToolStripMenuItem.Image")));
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.usuariosToolStripMenuItem.Text = "&Usuários";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("novoToolStripMenuItem.Image")));
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.novoToolStripMenuItem.Text = "&Novo";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editarToolStripMenuItem.Image")));
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.editarToolStripMenuItem.Text = "&Editar";
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("excluirToolStripMenuItem.Image")));
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.excluirToolStripMenuItem.Text = "&Excluir";
            // 
            // listarToolStripMenuItem2
            // 
            this.listarToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("listarToolStripMenuItem2.Image")));
            this.listarToolStripMenuItem2.Name = "listarToolStripMenuItem2";
            this.listarToolStripMenuItem2.Size = new System.Drawing.Size(108, 22);
            this.listarToolStripMenuItem2.Text = "&Listar";
            // 
            // ordensDeServiçosToolStripMenuItem
            // 
            this.ordensDeServiçosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaF5ToolStripMenuItem,
            this.editarToolStripMenuItem1,
            this.listarToolStripMenuItem1});
            this.ordensDeServiçosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ordensDeServiçosToolStripMenuItem.Image")));
            this.ordensDeServiçosToolStripMenuItem.Name = "ordensDeServiçosToolStripMenuItem";
            this.ordensDeServiçosToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.ordensDeServiçosToolStripMenuItem.Text = "&Ordens de serviços";
            // 
            // novaF5ToolStripMenuItem
            // 
            this.novaF5ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("novaF5ToolStripMenuItem.Image")));
            this.novaF5ToolStripMenuItem.Name = "novaF5ToolStripMenuItem";
            this.novaF5ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.novaF5ToolStripMenuItem.Text = "&Nova Ordem";
            this.novaF5ToolStripMenuItem.Click += new System.EventHandler(this.novaF5ToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem1
            // 
            this.editarToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("editarToolStripMenuItem1.Image")));
            this.editarToolStripMenuItem1.Name = "editarToolStripMenuItem1";
            this.editarToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.editarToolStripMenuItem1.Text = "&Editar";
            this.editarToolStripMenuItem1.Click += new System.EventHandler(this.editarToolStripMenuItem1_Click);
            // 
            // listarToolStripMenuItem1
            // 
            this.listarToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("listarToolStripMenuItem1.Image")));
            this.listarToolStripMenuItem1.Name = "listarToolStripMenuItem1";
            this.listarToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.listarToolStripMenuItem1.Text = "&Listar";
            this.listarToolStripMenuItem1.Click += new System.EventHandler(this.listarToolStripMenuItem1_Click);
            // 
            // pessoaToolStripMenuItem
            // 
            this.pessoaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem,
            this.jurídicaToolStripMenuItem,
            this.listarFísicaToolStripMenuItem,
            this.listarToolStripMenuItem});
            this.pessoaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pessoaToolStripMenuItem.Image")));
            this.pessoaToolStripMenuItem.Name = "pessoaToolStripMenuItem";
            this.pessoaToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.pessoaToolStripMenuItem.Text = "&Pessoa";
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cadastrarToolStripMenuItem.Image")));
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cadastrarToolStripMenuItem.Text = "&Física";
            this.cadastrarToolStripMenuItem.Click += new System.EventHandler(this.cadastrarToolStripMenuItem_Click);
            // 
            // jurídicaToolStripMenuItem
            // 
            this.jurídicaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("jurídicaToolStripMenuItem.Image")));
            this.jurídicaToolStripMenuItem.Name = "jurídicaToolStripMenuItem";
            this.jurídicaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.jurídicaToolStripMenuItem.Text = "&Jurídica";
            this.jurídicaToolStripMenuItem.Click += new System.EventHandler(this.jurídicaToolStripMenuItem_Click);
            // 
            // listarToolStripMenuItem
            // 
            this.listarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("listarToolStripMenuItem.Image")));
            this.listarToolStripMenuItem.Name = "listarToolStripMenuItem";
            this.listarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listarToolStripMenuItem.Text = "&Listar Jurídica";
            this.listarToolStripMenuItem.Click += new System.EventHandler(this.listarToolStripMenuItem_Click);
            // 
            // opiçõesToolStripMenuItem
            // 
            this.opiçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.telaInicialToolStripMenuItem,
            this.exibirPainelToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.opiçõesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("opiçõesToolStripMenuItem.Image")));
            this.opiçõesToolStripMenuItem.Name = "opiçõesToolStripMenuItem";
            this.opiçõesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.opiçõesToolStripMenuItem.Text = "&Opções";
            // 
            // telaInicialToolStripMenuItem
            // 
            this.telaInicialToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("telaInicialToolStripMenuItem.Image")));
            this.telaInicialToolStripMenuItem.Name = "telaInicialToolStripMenuItem";
            this.telaInicialToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.telaInicialToolStripMenuItem.Text = "&Empresa";
            this.telaInicialToolStripMenuItem.Click += new System.EventHandler(this.telaInicialToolStripMenuItem_Click);
            // 
            // exibirPainelToolStripMenuItem
            // 
            this.exibirPainelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exibirPainelToolStripMenuItem.Image")));
            this.exibirPainelToolStripMenuItem.Name = "exibirPainelToolStripMenuItem";
            this.exibirPainelToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exibirPainelToolStripMenuItem.Text = "&Painel On/Off";
            this.exibirPainelToolStripMenuItem.Click += new System.EventHandler(this.exibirPainelToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sobreToolStripMenuItem.Image")));
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.sobreToolStripMenuItem.Text = "&Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.Lbl_Nome);
            this.panel1.Controls.Add(this.Lbl_HoraData);
            this.panel1.Controls.Add(this.Lbl_NomeEmpresa);
            this.panel1.Controls.Add(this.Pic_LgoEmpresa);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 426);
            this.panel1.TabIndex = 6;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // Lbl_Nome
            // 
            this.Lbl_Nome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lbl_Nome.AutoSize = true;
            this.Lbl_Nome.Enabled = false;
            this.Lbl_Nome.Location = new System.Drawing.Point(54, 365);
            this.Lbl_Nome.Name = "Lbl_Nome";
            this.Lbl_Nome.Size = new System.Drawing.Size(74, 13);
            this.Lbl_Nome.TabIndex = 3;
            this.Lbl_Nome.Text = "Nome Usuario";
            // 
            // Lbl_HoraData
            // 
            this.Lbl_HoraData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lbl_HoraData.AutoSize = true;
            this.Lbl_HoraData.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_HoraData.Location = new System.Drawing.Point(38, 399);
            this.Lbl_HoraData.Name = "Lbl_HoraData";
            this.Lbl_HoraData.Size = new System.Drawing.Size(53, 18);
            this.Lbl_HoraData.TabIndex = 2;
            this.Lbl_HoraData.Text = "00:00";
            this.Lbl_HoraData.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // Lbl_NomeEmpresa
            // 
            this.Lbl_NomeEmpresa.AutoSize = true;
            this.Lbl_NomeEmpresa.Enabled = false;
            this.Lbl_NomeEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NomeEmpresa.Location = new System.Drawing.Point(31, 205);
            this.Lbl_NomeEmpresa.Name = "Lbl_NomeEmpresa";
            this.Lbl_NomeEmpresa.Size = new System.Drawing.Size(142, 26);
            this.Lbl_NomeEmpresa.TabIndex = 1;
            this.Lbl_NomeEmpresa.Text = "Software Desenvolvido \r\npor Cristiano Cunha";
            // 
            // Pic_LgoEmpresa
            // 
            this.Pic_LgoEmpresa.Location = new System.Drawing.Point(6, 25);
            this.Pic_LgoEmpresa.Name = "Pic_LgoEmpresa";
            this.Pic_LgoEmpresa.Size = new System.Drawing.Size(171, 157);
            this.Pic_LgoEmpresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic_LgoEmpresa.TabIndex = 0;
            this.Pic_LgoEmpresa.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listarFísicaToolStripMenuItem
            // 
            this.listarFísicaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("listarFísicaToolStripMenuItem.Image")));
            this.listarFísicaToolStripMenuItem.Name = "listarFísicaToolStripMenuItem";
            this.listarFísicaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listarFísicaToolStripMenuItem.Text = "&Listar Física";
            // 
            // Frm_Pai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "Frm_Pai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordem de serviço";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Pai_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Pai_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_LgoEmpresa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordensDeServiçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaF5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pessoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jurídicaToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lbl_HoraData;
        private System.Windows.Forms.Label Lbl_NomeEmpresa;
        private System.Windows.Forms.PictureBox Pic_LgoEmpresa;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem opiçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telaInicialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exibirPainelToolStripMenuItem;
        private System.Windows.Forms.Label Lbl_Nome;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem listarFísicaToolStripMenuItem;
    }
}



