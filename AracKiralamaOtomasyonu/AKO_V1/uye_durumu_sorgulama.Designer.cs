namespace WindowsFormsApplication1
{
    partial class uye_durumu_sorgulama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uye_durumu_sorgulama));
            this.sorgu_gb = new System.Windows.Forms.GroupBox();
            this.durum_label = new System.Windows.Forms.Label();
            this.ara_pb = new System.Windows.Forms.PictureBox();
            this.tc_masketb = new System.Windows.Forms.MaskedTextBox();
            this.tc_pb = new System.Windows.Forms.PictureBox();
            this.tc_label = new System.Windows.Forms.Label();
            this.gore_label = new System.Windows.Forms.Label();
            this.sorgu_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ara_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // sorgu_gb
            // 
            this.sorgu_gb.Controls.Add(this.durum_label);
            this.sorgu_gb.Controls.Add(this.ara_pb);
            this.sorgu_gb.Controls.Add(this.tc_masketb);
            this.sorgu_gb.Controls.Add(this.tc_pb);
            this.sorgu_gb.Controls.Add(this.tc_label);
            this.sorgu_gb.Controls.Add(this.gore_label);
            this.sorgu_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.sorgu_gb.Location = new System.Drawing.Point(12, 12);
            this.sorgu_gb.Name = "sorgu_gb";
            this.sorgu_gb.Size = new System.Drawing.Size(344, 159);
            this.sorgu_gb.TabIndex = 48;
            this.sorgu_gb.TabStop = false;
            this.sorgu_gb.Text = "Sorgula Ve Bilgilendirme";
            // 
            // durum_label
            // 
            this.durum_label.AutoSize = true;
            this.durum_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.durum_label.Location = new System.Drawing.Point(3, 61);
            this.durum_label.Name = "durum_label";
            this.durum_label.Size = new System.Drawing.Size(228, 18);
            this.durum_label.TabIndex = 49;
            this.durum_label.Text = "Durum:Sorgulama işlemi bekleniyor...";
            // 
            // ara_pb
            // 
            this.ara_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ara_pb.Location = new System.Drawing.Point(298, 22);
            this.ara_pb.Name = "ara_pb";
            this.ara_pb.Size = new System.Drawing.Size(32, 27);
            this.ara_pb.TabIndex = 54;
            this.ara_pb.TabStop = false;
            this.ara_pb.Click += new System.EventHandler(this.ara_pb_Click);
            this.ara_pb.MouseLeave += new System.EventHandler(this.ara_pb_MouseLeave);
            this.ara_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ara_pb_MouseMove);
            // 
            // tc_masketb
            // 
            this.tc_masketb.Location = new System.Drawing.Point(165, 22);
            this.tc_masketb.Mask = "00000000000";
            this.tc_masketb.Name = "tc_masketb";
            this.tc_masketb.Size = new System.Drawing.Size(127, 26);
            this.tc_masketb.TabIndex = 53;
            // 
            // tc_pb
            // 
            this.tc_pb.Location = new System.Drawing.Point(6, 25);
            this.tc_pb.Name = "tc_pb";
            this.tc_pb.Size = new System.Drawing.Size(32, 24);
            this.tc_pb.TabIndex = 52;
            this.tc_pb.TabStop = false;
            // 
            // tc_label
            // 
            this.tc_label.AutoSize = true;
            this.tc_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tc_label.Location = new System.Drawing.Point(44, 25);
            this.tc_label.Name = "tc_label";
            this.tc_label.Size = new System.Drawing.Size(116, 23);
            this.tc_label.TabIndex = 51;
            this.tc_label.Text = "TC Kimlik No:";
            // 
            // gore_label
            // 
            this.gore_label.AutoSize = true;
            this.gore_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gore_label.Location = new System.Drawing.Point(44, 28);
            this.gore_label.Name = "gore_label";
            this.gore_label.Size = new System.Drawing.Size(0, 19);
            this.gore_label.TabIndex = 50;
            // 
            // uye_durumu_sorgulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(367, 181);
            this.Controls.Add(this.sorgu_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "uye_durumu_sorgulama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üyelik Durumu Sorgulama";
            this.Load += new System.EventHandler(this.uye_durumu_sorgulama_Load);
            this.sorgu_gb.ResumeLayout(false);
            this.sorgu_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ara_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc_pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox sorgu_gb;
        private System.Windows.Forms.Label gore_label;
        private System.Windows.Forms.MaskedTextBox tc_masketb;
        private System.Windows.Forms.PictureBox tc_pb;
        private System.Windows.Forms.Label tc_label;
        private System.Windows.Forms.PictureBox ara_pb;
        private System.Windows.Forms.Label durum_label;
    }
}