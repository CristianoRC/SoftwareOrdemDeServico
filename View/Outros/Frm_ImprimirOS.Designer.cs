namespace View
{
    partial class Frm_ImprimirOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ImprimirOS));
            this.Btm_Imprimir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Ids = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Btm_Imprimir
            // 
            this.Btm_Imprimir.Location = new System.Drawing.Point(326, 12);
            this.Btm_Imprimir.Name = "Btm_Imprimir";
            this.Btm_Imprimir.Size = new System.Drawing.Size(114, 23);
            this.Btm_Imprimir.TabIndex = 1;
            this.Btm_Imprimir.Text = "Imprimir";
            this.Btm_Imprimir.UseVisualStyleBackColor = true;
            this.Btm_Imprimir.Click += new System.EventHandler(this.Btm_Imprimir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero:";
            // 
            // Txt_Ids
            // 
            this.Txt_Ids.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Txt_Ids.FormattingEnabled = true;
            this.Txt_Ids.Location = new System.Drawing.Point(65, 14);
            this.Txt_Ids.Name = "Txt_Ids";
            this.Txt_Ids.Size = new System.Drawing.Size(243, 21);
            this.Txt_Ids.TabIndex = 3;
            // 
            // Frm_ImprimirOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 53);
            this.Controls.Add(this.Txt_Ids);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btm_Imprimir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_ImprimirOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Ordem de serviço";
            this.Load += new System.EventHandler(this.Frm_ImprimirOS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btm_Imprimir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Txt_Ids;
    }
}