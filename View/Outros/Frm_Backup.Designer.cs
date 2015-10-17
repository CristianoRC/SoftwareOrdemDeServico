namespace View
{
    partial class Frm_Backup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Backup));
            this.Btm_Salvar = new System.Windows.Forms.Button();
            this.Btm_Carregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // Btm_Salvar
            // 
            this.Btm_Salvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btm_Salvar.BackgroundImage")));
            this.Btm_Salvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btm_Salvar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Btm_Salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btm_Salvar.Location = new System.Drawing.Point(32, 43);
            this.Btm_Salvar.Name = "Btm_Salvar";
            this.Btm_Salvar.Size = new System.Drawing.Size(122, 105);
            this.Btm_Salvar.TabIndex = 0;
            this.Btm_Salvar.UseVisualStyleBackColor = true;
            this.Btm_Salvar.Click += new System.EventHandler(this.Btm_Salvar_Click);
            // 
            // Btm_Carregar
            // 
            this.Btm_Carregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btm_Carregar.BackgroundImage")));
            this.Btm_Carregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btm_Carregar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Btm_Carregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btm_Carregar.Location = new System.Drawing.Point(228, 43);
            this.Btm_Carregar.Name = "Btm_Carregar";
            this.Btm_Carregar.Size = new System.Drawing.Size(122, 105);
            this.Btm_Carregar.TabIndex = 1;
            this.Btm_Carregar.UseVisualStyleBackColor = true;
            this.Btm_Carregar.Click += new System.EventHandler(this.Btm_Carregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Salvar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(255, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Restaurar";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Frm_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 173);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btm_Carregar);
            this.Controls.Add(this.Btm_Salvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btm_Salvar;
        private System.Windows.Forms.Button Btm_Carregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}