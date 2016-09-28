namespace View.Servicos
{
    partial class Frm_ExcluirServico
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
            this.label1 = new System.Windows.Forms.Label();
            this.Btm_Excluir = new System.Windows.Forms.Button();
            this.Txt_IDPesquisa = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID da ordem de serviço:\r\n\r\n";
            // 
            // Btm_Excluir
            // 
            this.Btm_Excluir.Location = new System.Drawing.Point(396, 7);
            this.Btm_Excluir.Name = "Btm_Excluir";
            this.Btm_Excluir.Size = new System.Drawing.Size(75, 23);
            this.Btm_Excluir.TabIndex = 4;
            this.Btm_Excluir.Text = "Excluir";
            this.Btm_Excluir.UseVisualStyleBackColor = true;
            this.Btm_Excluir.Click += new System.EventHandler(this.Btm_Excluir_Click);
            // 
            // Txt_IDPesquisa
            // 
            this.Txt_IDPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Txt_IDPesquisa.Location = new System.Drawing.Point(144, 10);
            this.Txt_IDPesquisa.Name = "Txt_IDPesquisa";
            this.Txt_IDPesquisa.Size = new System.Drawing.Size(233, 21);
            this.Txt_IDPesquisa.TabIndex = 6;
            // 
            // Frm_ExcluirServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 42);
            this.Controls.Add(this.Txt_IDPesquisa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btm_Excluir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_ExcluirServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir serviço";
            this.Load += new System.EventHandler(this.Frm_ExcluirServico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btm_Excluir;
        private System.Windows.Forms.ComboBox Txt_IDPesquisa;
    }
}