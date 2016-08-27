namespace View.Pessoas
{
    partial class Frm_ListarFisica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ListarFisica));
            this.Data_Os = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Os)).BeginInit();
            this.SuspendLayout();
            // 
            // Data_Os
            // 
            this.Data_Os.AllowUserToAddRows = false;
            this.Data_Os.AllowUserToDeleteRows = false;
            this.Data_Os.AllowUserToOrderColumns = true;
            this.Data_Os.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Data_Os.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_Os.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Data_Os.Location = new System.Drawing.Point(0, 0);
            this.Data_Os.Name = "Data_Os";
            this.Data_Os.ReadOnly = true;
            this.Data_Os.Size = new System.Drawing.Size(1098, 422);
            this.Data_Os.TabIndex = 2;
            // 
            // Frm_ListarFisica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 422);
            this.Controls.Add(this.Data_Os);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_ListarFisica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Clientes";
            this.Load += new System.EventHandler(this.Frm_ListarFisica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Os)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Data_Os;
    }
}