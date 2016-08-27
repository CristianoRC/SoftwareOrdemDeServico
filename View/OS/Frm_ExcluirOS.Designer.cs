namespace View.OS
{
    partial class Frm_ExcluirOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ExcluirOS));
            this.Btm_Excluir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Os = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Btm_Excluir
            // 
            this.Btm_Excluir.Location = new System.Drawing.Point(314, 12);
            this.Btm_Excluir.Name = "Btm_Excluir";
            this.Btm_Excluir.Size = new System.Drawing.Size(75, 23);
            this.Btm_Excluir.TabIndex = 1;
            this.Btm_Excluir.Text = "Excluir";
            this.Btm_Excluir.UseVisualStyleBackColor = true;
            this.Btm_Excluir.Click += new System.EventHandler(this.Btm_Excluir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero";
            // 
            // Txt_Os
            // 
            this.Txt_Os.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Txt_Os.Items.AddRange(new object[] {
            "Administrador",
            "Técnico"});
            this.Txt_Os.Location = new System.Drawing.Point(62, 12);
            this.Txt_Os.Name = "Txt_Os";
            this.Txt_Os.Size = new System.Drawing.Size(238, 21);
            this.Txt_Os.TabIndex = 25;
            // 
            // Frm_ExcluirOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(401, 57);
            this.Controls.Add(this.Txt_Os);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btm_Excluir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_ExcluirOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir Ordem de serviço";
            this.Load += new System.EventHandler(this.Frm_ExcluirOS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btm_Excluir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Txt_Os;
    }
}