namespace View.Opicoes
{
    partial class Frm_OpicoesInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_OpicoesInicial));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Btm_Salvar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Txt_Contato = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Endereco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Check_Informações = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Btm_Salvar
            // 
            this.Btm_Salvar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Btm_Salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btm_Salvar.Location = new System.Drawing.Point(170, 239);
            this.Btm_Salvar.Name = "Btm_Salvar";
            this.Btm_Salvar.Size = new System.Drawing.Size(81, 28);
            this.Btm_Salvar.TabIndex = 7;
            this.Btm_Salvar.Text = "Salvar";
            this.Btm_Salvar.UseVisualStyleBackColor = true;
            this.Btm_Salvar.Click += new System.EventHandler(this.Btm_Salvar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(390, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 205);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(104, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Carregar Logo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Txt_Contato
            // 
            this.Txt_Contato.Location = new System.Drawing.Point(72, 79);
            this.Txt_Contato.Name = "Txt_Contato";
            this.Txt_Contato.Size = new System.Drawing.Size(277, 20);
            this.Txt_Contato.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contato:";
            // 
            // Txt_Endereco
            // 
            this.Txt_Endereco.Location = new System.Drawing.Point(72, 124);
            this.Txt_Endereco.Name = "Txt_Endereco";
            this.Txt_Endereco.Size = new System.Drawing.Size(277, 20);
            this.Txt_Endereco.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Endereço:";
            // 
            // Check_Informações
            // 
            this.Check_Informações.AutoSize = true;
            this.Check_Informações.Location = new System.Drawing.Point(72, 150);
            this.Check_Informações.Name = "Check_Informações";
            this.Check_Informações.Size = new System.Drawing.Size(189, 17);
            this.Check_Informações.TabIndex = 8;
            this.Check_Informações.Text = "Modificar Informações da Empresa";
            this.Check_Informações.UseVisualStyleBackColor = true;
            // 
            // Frm_OpicoesInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(683, 296);
            this.Controls.Add(this.Check_Informações);
            this.Controls.Add(this.Txt_Endereco);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt_Contato);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Btm_Salvar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_OpicoesInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sobre a Empresa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Btm_Salvar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox Txt_Contato;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Endereco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox Check_Informações;
    }
}