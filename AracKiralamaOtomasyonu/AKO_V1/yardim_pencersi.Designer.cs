namespace WindowsFormsApplication1
{
    partial class yardim_pencersi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(yardim_pencersi));
            this.arama_tb = new System.Windows.Forms.TextBox();
            this.ara_pb = new System.Windows.Forms.PictureBox();
            this.yardim_bilgileri_tb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ara_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // arama_tb
            // 
            this.arama_tb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.arama_tb.Location = new System.Drawing.Point(12, 12);
            this.arama_tb.Name = "arama_tb";
            this.arama_tb.Size = new System.Drawing.Size(236, 26);
            this.arama_tb.TabIndex = 63;
            // 
            // ara_pb
            // 
            this.ara_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ara_pb.Location = new System.Drawing.Point(254, 12);
            this.ara_pb.Name = "ara_pb";
            this.ara_pb.Size = new System.Drawing.Size(32, 27);
            this.ara_pb.TabIndex = 62;
            this.ara_pb.TabStop = false;
            this.ara_pb.Click += new System.EventHandler(this.ara_pb_Click);
            this.ara_pb.MouseLeave += new System.EventHandler(this.ara_pb_MouseLeave);
            this.ara_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ara_pb_MouseMove);
            // 
            // yardim_bilgileri_tb
            // 
            this.yardim_bilgileri_tb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.yardim_bilgileri_tb.Location = new System.Drawing.Point(12, 44);
            this.yardim_bilgileri_tb.Multiline = true;
            this.yardim_bilgileri_tb.Name = "yardim_bilgileri_tb";
            this.yardim_bilgileri_tb.ReadOnly = true;
            this.yardim_bilgileri_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.yardim_bilgileri_tb.Size = new System.Drawing.Size(274, 246);
            this.yardim_bilgileri_tb.TabIndex = 64;
            this.yardim_bilgileri_tb.Text = "Yardım almak istediğiniz konuyu aratınız.\r\nÖrnek:menüler,giriş yapamıyorum gibi\r\n" +
    "\r\n\r\n-Yardim Penceresi beta aşamasındadır.\r\n";
            // 
            // yardim_pencersi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 302);
            this.Controls.Add(this.yardim_bilgileri_tb);
            this.Controls.Add(this.arama_tb);
            this.Controls.Add(this.ara_pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "yardim_pencersi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yardım- BETA 1.0";
            this.Load += new System.EventHandler(this.yardim_pencersi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ara_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox arama_tb;
        private System.Windows.Forms.PictureBox ara_pb;
        private System.Windows.Forms.TextBox yardim_bilgileri_tb;
    }
}