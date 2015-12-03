namespace View
{
    partial class Frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.Btm_Sair = new System.Windows.Forms.Button();
            this.bTM_lOGAR = new System.Windows.Forms.Button();
            this.Txt_Login = new System.Windows.Forms.TextBox();
            this.Txt_Senha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btm_Sair
            // 
            this.Btm_Sair.Location = new System.Drawing.Point(225, 164);
            this.Btm_Sair.Name = "Btm_Sair";
            this.Btm_Sair.Size = new System.Drawing.Size(87, 31);
            this.Btm_Sair.TabIndex = 3;
            this.Btm_Sair.Text = "Sair";
            this.Btm_Sair.UseVisualStyleBackColor = true;
            this.Btm_Sair.Click += new System.EventHandler(this.Btm_Sair_Click);
            // 
            // bTM_lOGAR
            // 
            this.bTM_lOGAR.Location = new System.Drawing.Point(68, 164);
            this.bTM_lOGAR.Name = "bTM_lOGAR";
            this.bTM_lOGAR.Size = new System.Drawing.Size(87, 31);
            this.bTM_lOGAR.TabIndex = 2;
            this.bTM_lOGAR.Text = "Logar";
            this.bTM_lOGAR.UseVisualStyleBackColor = true;
            this.bTM_lOGAR.Click += new System.EventHandler(this.bTM_lOGAR_Click);
            // 
            // Txt_Login
            // 
            this.Txt_Login.Location = new System.Drawing.Point(68, 35);
            this.Txt_Login.Name = "Txt_Login";
            this.Txt_Login.Size = new System.Drawing.Size(244, 20);
            this.Txt_Login.TabIndex = 0;
            this.Txt_Login.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Login_KeyPress);
            // 
            // Txt_Senha
            // 
            this.Txt_Senha.Location = new System.Drawing.Point(68, 96);
            this.Txt_Senha.Name = "Txt_Senha";
            this.Txt_Senha.Size = new System.Drawing.Size(244, 20);
            this.Txt_Senha.TabIndex = 1;
            this.Txt_Senha.UseSystemPasswordChar = true;
            this.Txt_Senha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Senha_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Senha";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(358, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(579, 231);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_Senha);
            this.Controls.Add(this.Txt_Login);
            this.Controls.Add(this.bTM_lOGAR);
            this.Controls.Add(this.Btm_Sair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Software Ordem de serviço";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Login_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btm_Sair;
        private System.Windows.Forms.Button bTM_lOGAR;
        private System.Windows.Forms.TextBox Txt_Login;
        private System.Windows.Forms.TextBox Txt_Senha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}