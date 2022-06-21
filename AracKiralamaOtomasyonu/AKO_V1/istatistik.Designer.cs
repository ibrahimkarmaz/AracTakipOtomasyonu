namespace WindowsFormsApplication1
{
    partial class istatistik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(istatistik));
            this.istatistik_bilgileri_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // istatistik_bilgileri_label
            // 
            this.istatistik_bilgileri_label.AutoSize = true;
            this.istatistik_bilgileri_label.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.istatistik_bilgileri_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.istatistik_bilgileri_label.Location = new System.Drawing.Point(12, 9);
            this.istatistik_bilgileri_label.Name = "istatistik_bilgileri_label";
            this.istatistik_bilgileri_label.Size = new System.Drawing.Size(133, 18);
            this.istatistik_bilgileri_label.TabIndex = 1;
            this.istatistik_bilgileri_label.Text = "--İSTATİKTİKLER--";
            // 
            // istatistik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(527, 623);
            this.Controls.Add(this.istatistik_bilgileri_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "istatistik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İstatiktikler";
            this.Load += new System.EventHandler(this.istatistik_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label istatistik_bilgileri_label;
    }
}