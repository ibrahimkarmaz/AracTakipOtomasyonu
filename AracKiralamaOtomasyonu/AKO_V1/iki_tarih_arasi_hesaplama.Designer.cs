namespace WindowsFormsApplication1
{
    partial class iki_tarih_arasi_hesaplama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iki_tarih_arasi_hesaplama));
            this.tarih_gb = new System.Windows.Forms.GroupBox();
            this.tarih2_dt = new System.Windows.Forms.DateTimePicker();
            this.tarih2_label = new System.Windows.Forms.Label();
            this.tarih2_pb = new System.Windows.Forms.PictureBox();
            this.tarih1_dt = new System.Windows.Forms.DateTimePicker();
            this.tarih1_label = new System.Windows.Forms.Label();
            this.tarih1_pb = new System.Windows.Forms.PictureBox();
            this.tarih_bilgileri_label = new System.Windows.Forms.Label();
            this.tarih_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tarih2_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih1_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // tarih_gb
            // 
            this.tarih_gb.Controls.Add(this.tarih2_dt);
            this.tarih_gb.Controls.Add(this.tarih2_label);
            this.tarih_gb.Controls.Add(this.tarih2_pb);
            this.tarih_gb.Controls.Add(this.tarih1_dt);
            this.tarih_gb.Controls.Add(this.tarih1_label);
            this.tarih_gb.Controls.Add(this.tarih1_pb);
            this.tarih_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tarih_gb.Location = new System.Drawing.Point(12, 12);
            this.tarih_gb.Name = "tarih_gb";
            this.tarih_gb.Size = new System.Drawing.Size(330, 94);
            this.tarih_gb.TabIndex = 88;
            this.tarih_gb.TabStop = false;
            this.tarih_gb.Text = "Tarihler ";
            // 
            // tarih2_dt
            // 
            this.tarih2_dt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tarih2_dt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tarih2_dt.Location = new System.Drawing.Point(152, 55);
            this.tarih2_dt.MinDate = new System.DateTime(1976, 1, 1, 0, 0, 0, 0);
            this.tarih2_dt.Name = "tarih2_dt";
            this.tarih2_dt.Size = new System.Drawing.Size(167, 26);
            this.tarih2_dt.TabIndex = 58;
            this.tarih2_dt.ValueChanged += new System.EventHandler(this.tarih2_dt_ValueChanged);
            // 
            // tarih2_label
            // 
            this.tarih2_label.AutoSize = true;
            this.tarih2_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tarih2_label.Location = new System.Drawing.Point(44, 58);
            this.tarih2_label.Name = "tarih2_label";
            this.tarih2_label.Size = new System.Drawing.Size(107, 23);
            this.tarih2_label.TabIndex = 57;
            this.tarih2_label.Text = "İkinci Tarih:";
            // 
            // tarih2_pb
            // 
            this.tarih2_pb.Location = new System.Drawing.Point(6, 57);
            this.tarih2_pb.Name = "tarih2_pb";
            this.tarih2_pb.Size = new System.Drawing.Size(32, 24);
            this.tarih2_pb.TabIndex = 56;
            this.tarih2_pb.TabStop = false;
            // 
            // tarih1_dt
            // 
            this.tarih1_dt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tarih1_dt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tarih1_dt.Location = new System.Drawing.Point(152, 23);
            this.tarih1_dt.MinDate = new System.DateTime(1976, 1, 1, 0, 0, 0, 0);
            this.tarih1_dt.Name = "tarih1_dt";
            this.tarih1_dt.Size = new System.Drawing.Size(167, 26);
            this.tarih1_dt.TabIndex = 55;
            this.tarih1_dt.ValueChanged += new System.EventHandler(this.tarih1_dt_ValueChanged);
            // 
            // tarih1_label
            // 
            this.tarih1_label.AutoSize = true;
            this.tarih1_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tarih1_label.Location = new System.Drawing.Point(44, 26);
            this.tarih1_label.Name = "tarih1_label";
            this.tarih1_label.Size = new System.Drawing.Size(87, 23);
            this.tarih1_label.TabIndex = 54;
            this.tarih1_label.Text = "İlk Tarih:";
            // 
            // tarih1_pb
            // 
            this.tarih1_pb.Location = new System.Drawing.Point(6, 25);
            this.tarih1_pb.Name = "tarih1_pb";
            this.tarih1_pb.Size = new System.Drawing.Size(32, 24);
            this.tarih1_pb.TabIndex = 53;
            this.tarih1_pb.TabStop = false;
            // 
            // tarih_bilgileri_label
            // 
            this.tarih_bilgileri_label.AutoSize = true;
            this.tarih_bilgileri_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.tarih_bilgileri_label.Location = new System.Drawing.Point(15, 109);
            this.tarih_bilgileri_label.Name = "tarih_bilgileri_label";
            this.tarih_bilgileri_label.Size = new System.Drawing.Size(66, 18);
            this.tarih_bilgileri_label.TabIndex = 89;
            this.tarih_bilgileri_label.Text = "Sonuçlar:";
            // 
            // iki_tarih_arasi_hesaplama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(353, 249);
            this.Controls.Add(this.tarih_bilgileri_label);
            this.Controls.Add(this.tarih_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "iki_tarih_arasi_hesaplama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İki Tarih Arası Hesaplama";
            this.Load += new System.EventHandler(this.iki_tarih_arasi_hesaplama_Load);
            this.tarih_gb.ResumeLayout(false);
            this.tarih_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tarih2_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih1_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox tarih_gb;
        private System.Windows.Forms.DateTimePicker tarih2_dt;
        private System.Windows.Forms.Label tarih2_label;
        private System.Windows.Forms.PictureBox tarih2_pb;
        private System.Windows.Forms.DateTimePicker tarih1_dt;
        private System.Windows.Forms.Label tarih1_label;
        private System.Windows.Forms.PictureBox tarih1_pb;
        private System.Windows.Forms.Label tarih_bilgileri_label;

    }
}