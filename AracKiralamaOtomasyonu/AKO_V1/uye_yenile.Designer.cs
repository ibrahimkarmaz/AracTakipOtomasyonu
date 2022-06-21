namespace WindowsFormsApplication1
{
    partial class uye_yenile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uye_yenile));
            this.uyelik_yenile_gb = new System.Windows.Forms.GroupBox();
            this.yenile_pb = new System.Windows.Forms.PictureBox();
            this.tc_masketb = new System.Windows.Forms.MaskedTextBox();
            this.tc_pb = new System.Windows.Forms.PictureBox();
            this.tc_label = new System.Windows.Forms.Label();
            this.gore_label = new System.Windows.Forms.Label();
            this.uyelik_yenile_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yenile_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // uyelik_yenile_gb
            // 
            this.uyelik_yenile_gb.Controls.Add(this.yenile_pb);
            this.uyelik_yenile_gb.Controls.Add(this.tc_masketb);
            this.uyelik_yenile_gb.Controls.Add(this.tc_pb);
            this.uyelik_yenile_gb.Controls.Add(this.tc_label);
            this.uyelik_yenile_gb.Controls.Add(this.gore_label);
            this.uyelik_yenile_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.uyelik_yenile_gb.Location = new System.Drawing.Point(12, 12);
            this.uyelik_yenile_gb.Name = "uyelik_yenile_gb";
            this.uyelik_yenile_gb.Size = new System.Drawing.Size(344, 65);
            this.uyelik_yenile_gb.TabIndex = 49;
            this.uyelik_yenile_gb.TabStop = false;
            this.uyelik_yenile_gb.Text = "Üyelik Yenileme";
            // 
            // yenile_pb
            // 
            this.yenile_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yenile_pb.Location = new System.Drawing.Point(298, 22);
            this.yenile_pb.Name = "yenile_pb";
            this.yenile_pb.Size = new System.Drawing.Size(32, 27);
            this.yenile_pb.TabIndex = 54;
            this.yenile_pb.TabStop = false;
            this.yenile_pb.Click += new System.EventHandler(this.yenile_pb_Click);
            this.yenile_pb.MouseLeave += new System.EventHandler(this.yenile_pb_MouseLeave);
            this.yenile_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.yenile_pb_MouseMove);
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
            // uye_yenile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(368, 88);
            this.Controls.Add(this.uyelik_yenile_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "uye_yenile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üyelik Yenileme";
            this.Load += new System.EventHandler(this.uye_yenile_Load);
            this.uyelik_yenile_gb.ResumeLayout(false);
            this.uyelik_yenile_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yenile_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc_pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox uyelik_yenile_gb;
        private System.Windows.Forms.PictureBox yenile_pb;
        private System.Windows.Forms.MaskedTextBox tc_masketb;
        private System.Windows.Forms.PictureBox tc_pb;
        private System.Windows.Forms.Label tc_label;
        private System.Windows.Forms.Label gore_label;
    }
}