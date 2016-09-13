namespace View.Pessoas
{
    partial class Frm_ExcluirClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ExcluirClientes));
            this.Txt_Pessoa = new System.Windows.Forms.ComboBox();
            this.Btm_Deletar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Txt_Pessoa
            // 
            this.Txt_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Txt_Pessoa.Items.AddRange(new object[] {
            "Administrador",
            "Técnico"});
            this.Txt_Pessoa.Location = new System.Drawing.Point(17, 32);
            this.Txt_Pessoa.Name = "Txt_Pessoa";
            this.Txt_Pessoa.Size = new System.Drawing.Size(238, 21);
            this.Txt_Pessoa.TabIndex = 26;
            // 
            // Btm_Deletar
            // 
            this.Btm_Deletar.Location = new System.Drawing.Point(290, 30);
            this.Btm_Deletar.Name = "Btm_Deletar";
            this.Btm_Deletar.Size = new System.Drawing.Size(75, 23);
            this.Btm_Deletar.TabIndex = 25;
            this.Btm_Deletar.Text = "Excluir";
            this.Btm_Deletar.UseVisualStyleBackColor = true;
            this.Btm_Deletar.Click += new System.EventHandler(this.Btm_Deletar_Click);
            // 
            // Frm_ExcluirClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 83);
            this.Controls.Add(this.Txt_Pessoa);
            this.Controls.Add(this.Btm_Deletar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_ExcluirClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir Clientes";
            this.Load += new System.EventHandler(this.Frm_ExcluirClientes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Txt_Pessoa;
        private System.Windows.Forms.Button Btm_Deletar;
    }
}