namespace View
{
    partial class Frm_ExcluirOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ExcluirOrcamento));
            this.label1 = new System.Windows.Forms.Label();
            this.Btm_Excluir = new System.Windows.Forms.Button();
            this.Txt_OS = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero:";
            // 
            // Btm_Excluir
            // 
            this.Btm_Excluir.Location = new System.Drawing.Point(264, 47);
            this.Btm_Excluir.Name = "Btm_Excluir";
            this.Btm_Excluir.Size = new System.Drawing.Size(75, 23);
            this.Btm_Excluir.TabIndex = 1;
            this.Btm_Excluir.Text = "Excluir";
            this.Btm_Excluir.UseVisualStyleBackColor = true;
            this.Btm_Excluir.Click += new System.EventHandler(this.Btm_Excluir_Click);
            // 
            // Txt_OS
            // 
            this.Txt_OS.Location = new System.Drawing.Point(65, 20);
            this.Txt_OS.Name = "Txt_OS";
            this.Txt_OS.Size = new System.Drawing.Size(274, 20);
            this.Txt_OS.TabIndex = 2;
            // 
            // Frm_ExcluirOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(361, 82);
            this.Controls.Add(this.Txt_OS);
            this.Controls.Add(this.Btm_Excluir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_ExcluirOrcamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir orçamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btm_Excluir;
        private System.Windows.Forms.TextBox Txt_OS;
    }
}