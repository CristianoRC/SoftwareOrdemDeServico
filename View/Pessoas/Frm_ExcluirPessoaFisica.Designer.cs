namespace View.Pessoas
{
    partial class Frm_ExcluirPessoaFisica
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
            this.Btm_Excluir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Pessoa = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Btm_Excluir
            // 
            this.Btm_Excluir.Location = new System.Drawing.Point(137, 58);
            this.Btm_Excluir.Name = "Btm_Excluir";
            this.Btm_Excluir.Size = new System.Drawing.Size(75, 23);
            this.Btm_Excluir.TabIndex = 0;
            this.Btm_Excluir.Text = "Excluir";
            this.Btm_Excluir.UseVisualStyleBackColor = true;
            this.Btm_Excluir.Click += new System.EventHandler(this.Btm_Excluir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome";
            // 
            // Txt_Pessoa
            // 
            this.Txt_Pessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Txt_Pessoa.Location = new System.Drawing.Point(68, 18);
            this.Txt_Pessoa.Name = "Txt_Pessoa";
            this.Txt_Pessoa.Size = new System.Drawing.Size(206, 21);
            this.Txt_Pessoa.TabIndex = 3;
            // 
            // Frm_ExcluirPessoaFisica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 93);
            this.Controls.Add(this.Txt_Pessoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btm_Excluir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_ExcluirPessoaFisica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir Cliente";
            this.Load += new System.EventHandler(this.Frm_ExcluirPessoaFisica_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btm_Excluir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Txt_Pessoa;
    }
}