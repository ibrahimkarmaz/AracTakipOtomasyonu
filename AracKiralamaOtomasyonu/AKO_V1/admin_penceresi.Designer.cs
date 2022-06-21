namespace WindowsFormsApplication1
{
    partial class admin_penceresi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin_penceresi));
            this.tablolari_listele_dgv = new System.Windows.Forms.DataGridView();
            this.admin_islemleri_gb = new System.Windows.Forms.GroupBox();
            this.personel_arsivi_bilgi_label = new System.Windows.Forms.Label();
            this.personel_arsivi_pb = new System.Windows.Forms.PictureBox();
            this.personel_arsivi_label = new System.Windows.Forms.Label();
            this.personel_cikar_bilgi_label = new System.Windows.Forms.Label();
            this.personel_cikar_pb = new System.Windows.Forms.PictureBox();
            this.personel_cikar_label = new System.Windows.Forms.Label();
            this.personel_yetkilerini_duzenle_bilgi_label = new System.Windows.Forms.Label();
            this.onay_bekleyenler_bilgi_label = new System.Windows.Forms.Label();
            this.personel_yetkilerini_duzenle_pb = new System.Windows.Forms.PictureBox();
            this.personel_yetkilerini_duzenle_label = new System.Windows.Forms.Label();
            this.onay_bekleyenler_pb = new System.Windows.Forms.PictureBox();
            this.onay_bekleyenler_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablolari_listele_dgv)).BeginInit();
            this.admin_islemleri_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personel_arsivi_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personel_cikar_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personel_yetkilerini_duzenle_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onay_bekleyenler_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // tablolari_listele_dgv
            // 
            this.tablolari_listele_dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablolari_listele_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablolari_listele_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablolari_listele_dgv.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablolari_listele_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.tablolari_listele_dgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.tablolari_listele_dgv.Location = new System.Drawing.Point(0, 0);
            this.tablolari_listele_dgv.Name = "tablolari_listele_dgv";
            this.tablolari_listele_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablolari_listele_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tablolari_listele_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablolari_listele_dgv.Size = new System.Drawing.Size(667, 286);
            this.tablolari_listele_dgv.TabIndex = 46;
            // 
            // admin_islemleri_gb
            // 
            this.admin_islemleri_gb.Controls.Add(this.personel_arsivi_bilgi_label);
            this.admin_islemleri_gb.Controls.Add(this.personel_arsivi_pb);
            this.admin_islemleri_gb.Controls.Add(this.personel_arsivi_label);
            this.admin_islemleri_gb.Controls.Add(this.personel_cikar_bilgi_label);
            this.admin_islemleri_gb.Controls.Add(this.personel_cikar_pb);
            this.admin_islemleri_gb.Controls.Add(this.personel_cikar_label);
            this.admin_islemleri_gb.Controls.Add(this.personel_yetkilerini_duzenle_bilgi_label);
            this.admin_islemleri_gb.Controls.Add(this.onay_bekleyenler_bilgi_label);
            this.admin_islemleri_gb.Controls.Add(this.personel_yetkilerini_duzenle_pb);
            this.admin_islemleri_gb.Controls.Add(this.personel_yetkilerini_duzenle_label);
            this.admin_islemleri_gb.Controls.Add(this.onay_bekleyenler_pb);
            this.admin_islemleri_gb.Controls.Add(this.onay_bekleyenler_label);
            this.admin_islemleri_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.admin_islemleri_gb.Location = new System.Drawing.Point(673, 0);
            this.admin_islemleri_gb.Name = "admin_islemleri_gb";
            this.admin_islemleri_gb.Size = new System.Drawing.Size(370, 280);
            this.admin_islemleri_gb.TabIndex = 47;
            this.admin_islemleri_gb.TabStop = false;
            this.admin_islemleri_gb.Text = "Yönetici İşlem Pencereleri";
            // 
            // personel_arsivi_bilgi_label
            // 
            this.personel_arsivi_bilgi_label.AutoSize = true;
            this.personel_arsivi_bilgi_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personel_arsivi_bilgi_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personel_arsivi_bilgi_label.Location = new System.Drawing.Point(91, 237);
            this.personel_arsivi_bilgi_label.Name = "personel_arsivi_bilgi_label";
            this.personel_arsivi_bilgi_label.Size = new System.Drawing.Size(267, 18);
            this.personel_arsivi_bilgi_label.TabIndex = 39;
            this.personel_arsivi_bilgi_label.Text = "Sisteminize eklenen araçları düzenlersiniz.";
            this.personel_arsivi_bilgi_label.Click += new System.EventHandler(this.personel_arsivi_pb_Click);
            this.personel_arsivi_bilgi_label.MouseLeave += new System.EventHandler(this.personel_arsivi_pb_MouseLeave);
            this.personel_arsivi_bilgi_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.personel_arsivi_pb_MouseMove);
            // 
            // personel_arsivi_pb
            // 
            this.personel_arsivi_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personel_arsivi_pb.Location = new System.Drawing.Point(6, 214);
            this.personel_arsivi_pb.Name = "personel_arsivi_pb";
            this.personel_arsivi_pb.Size = new System.Drawing.Size(78, 57);
            this.personel_arsivi_pb.TabIndex = 37;
            this.personel_arsivi_pb.TabStop = false;
            this.personel_arsivi_pb.Click += new System.EventHandler(this.personel_arsivi_pb_Click);
            this.personel_arsivi_pb.MouseLeave += new System.EventHandler(this.personel_arsivi_pb_MouseLeave);
            this.personel_arsivi_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.personel_arsivi_pb_MouseMove);
            // 
            // personel_arsivi_label
            // 
            this.personel_arsivi_label.AutoSize = true;
            this.personel_arsivi_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personel_arsivi_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personel_arsivi_label.Location = new System.Drawing.Point(90, 214);
            this.personel_arsivi_label.Name = "personel_arsivi_label";
            this.personel_arsivi_label.Size = new System.Drawing.Size(121, 23);
            this.personel_arsivi_label.TabIndex = 38;
            this.personel_arsivi_label.Text = "Personel Arşivi";
            this.personel_arsivi_label.Click += new System.EventHandler(this.personel_arsivi_pb_Click);
            this.personel_arsivi_label.MouseLeave += new System.EventHandler(this.personel_arsivi_pb_MouseLeave);
            this.personel_arsivi_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.personel_arsivi_pb_MouseMove);
            // 
            // personel_cikar_bilgi_label
            // 
            this.personel_cikar_bilgi_label.AutoSize = true;
            this.personel_cikar_bilgi_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personel_cikar_bilgi_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personel_cikar_bilgi_label.Location = new System.Drawing.Point(91, 174);
            this.personel_cikar_bilgi_label.Name = "personel_cikar_bilgi_label";
            this.personel_cikar_bilgi_label.Size = new System.Drawing.Size(195, 36);
            this.personel_cikar_bilgi_label.TabIndex = 36;
            this.personel_cikar_bilgi_label.Text = "Personeli sistemde çıkarırsınız.\r\nsisteme giriş yapamaz.";
            this.personel_cikar_bilgi_label.Click += new System.EventHandler(this.personel_cikar_pb_Click);
            this.personel_cikar_bilgi_label.MouseLeave += new System.EventHandler(this.personel_cikar_pb_MouseLeave);
            this.personel_cikar_bilgi_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.personel_cikar_pb_MouseMove);
            // 
            // personel_cikar_pb
            // 
            this.personel_cikar_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personel_cikar_pb.Location = new System.Drawing.Point(6, 151);
            this.personel_cikar_pb.Name = "personel_cikar_pb";
            this.personel_cikar_pb.Size = new System.Drawing.Size(78, 57);
            this.personel_cikar_pb.TabIndex = 34;
            this.personel_cikar_pb.TabStop = false;
            this.personel_cikar_pb.Click += new System.EventHandler(this.personel_cikar_pb_Click);
            this.personel_cikar_pb.MouseLeave += new System.EventHandler(this.personel_cikar_pb_MouseLeave);
            this.personel_cikar_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.personel_cikar_pb_MouseMove);
            // 
            // personel_cikar_label
            // 
            this.personel_cikar_label.AutoSize = true;
            this.personel_cikar_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personel_cikar_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personel_cikar_label.Location = new System.Drawing.Point(90, 151);
            this.personel_cikar_label.Name = "personel_cikar_label";
            this.personel_cikar_label.Size = new System.Drawing.Size(115, 23);
            this.personel_cikar_label.TabIndex = 35;
            this.personel_cikar_label.Text = "Personel Çıkar";
            this.personel_cikar_label.Click += new System.EventHandler(this.personel_cikar_pb_Click);
            this.personel_cikar_label.MouseLeave += new System.EventHandler(this.personel_cikar_pb_MouseLeave);
            this.personel_cikar_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.personel_cikar_pb_MouseMove);
            // 
            // personel_yetkilerini_duzenle_bilgi_label
            // 
            this.personel_yetkilerini_duzenle_bilgi_label.AutoSize = true;
            this.personel_yetkilerini_duzenle_bilgi_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personel_yetkilerini_duzenle_bilgi_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personel_yetkilerini_duzenle_bilgi_label.Location = new System.Drawing.Point(91, 111);
            this.personel_yetkilerini_duzenle_bilgi_label.Name = "personel_yetkilerini_duzenle_bilgi_label";
            this.personel_yetkilerini_duzenle_bilgi_label.Size = new System.Drawing.Size(252, 36);
            this.personel_yetkilerini_duzenle_bilgi_label.TabIndex = 33;
            this.personel_yetkilerini_duzenle_bilgi_label.Text = "Personelin hangi işlemleri yapabileceğini\r\nbelirlersiniz.";
            this.personel_yetkilerini_duzenle_bilgi_label.Click += new System.EventHandler(this.personel_yetkilerini_duzenle_pb_Click);
            this.personel_yetkilerini_duzenle_bilgi_label.MouseLeave += new System.EventHandler(this.personel_yetkilerini_duzenle_pb_MouseLeave);
            this.personel_yetkilerini_duzenle_bilgi_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.personel_yetkilerini_duzenle_pb_MouseMove);
            // 
            // onay_bekleyenler_bilgi_label
            // 
            this.onay_bekleyenler_bilgi_label.AutoSize = true;
            this.onay_bekleyenler_bilgi_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.onay_bekleyenler_bilgi_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.onay_bekleyenler_bilgi_label.Location = new System.Drawing.Point(91, 48);
            this.onay_bekleyenler_bilgi_label.Name = "onay_bekleyenler_bilgi_label";
            this.onay_bekleyenler_bilgi_label.Size = new System.Drawing.Size(262, 36);
            this.onay_bekleyenler_bilgi_label.TabIndex = 30;
            this.onay_bekleyenler_bilgi_label.Text = "Üye Ol Penceresinden bilgilerini dolduran\r\naday personel(ler)";
            this.onay_bekleyenler_bilgi_label.Click += new System.EventHandler(this.onay_bekleyenler_pb_Click);
            this.onay_bekleyenler_bilgi_label.MouseLeave += new System.EventHandler(this.onay_bekleyenler_pb_MouseLeave);
            this.onay_bekleyenler_bilgi_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onay_bekleyenler_pb_MouseMove);
            // 
            // personel_yetkilerini_duzenle_pb
            // 
            this.personel_yetkilerini_duzenle_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personel_yetkilerini_duzenle_pb.Location = new System.Drawing.Point(6, 88);
            this.personel_yetkilerini_duzenle_pb.Name = "personel_yetkilerini_duzenle_pb";
            this.personel_yetkilerini_duzenle_pb.Size = new System.Drawing.Size(78, 57);
            this.personel_yetkilerini_duzenle_pb.TabIndex = 31;
            this.personel_yetkilerini_duzenle_pb.TabStop = false;
            this.personel_yetkilerini_duzenle_pb.Click += new System.EventHandler(this.personel_yetkilerini_duzenle_pb_Click);
            this.personel_yetkilerini_duzenle_pb.MouseLeave += new System.EventHandler(this.personel_yetkilerini_duzenle_pb_MouseLeave);
            this.personel_yetkilerini_duzenle_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.personel_yetkilerini_duzenle_pb_MouseMove);
            // 
            // personel_yetkilerini_duzenle_label
            // 
            this.personel_yetkilerini_duzenle_label.AutoSize = true;
            this.personel_yetkilerini_duzenle_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personel_yetkilerini_duzenle_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personel_yetkilerini_duzenle_label.Location = new System.Drawing.Point(90, 88);
            this.personel_yetkilerini_duzenle_label.Name = "personel_yetkilerini_duzenle_label";
            this.personel_yetkilerini_duzenle_label.Size = new System.Drawing.Size(177, 23);
            this.personel_yetkilerini_duzenle_label.TabIndex = 32;
            this.personel_yetkilerini_duzenle_label.Text = "Personel Yetkilendirme";
            this.personel_yetkilerini_duzenle_label.Click += new System.EventHandler(this.personel_yetkilerini_duzenle_pb_Click);
            this.personel_yetkilerini_duzenle_label.MouseLeave += new System.EventHandler(this.personel_yetkilerini_duzenle_pb_MouseLeave);
            this.personel_yetkilerini_duzenle_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.personel_yetkilerini_duzenle_pb_MouseMove);
            // 
            // onay_bekleyenler_pb
            // 
            this.onay_bekleyenler_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.onay_bekleyenler_pb.Location = new System.Drawing.Point(6, 25);
            this.onay_bekleyenler_pb.Name = "onay_bekleyenler_pb";
            this.onay_bekleyenler_pb.Size = new System.Drawing.Size(78, 57);
            this.onay_bekleyenler_pb.TabIndex = 24;
            this.onay_bekleyenler_pb.TabStop = false;
            this.onay_bekleyenler_pb.Click += new System.EventHandler(this.onay_bekleyenler_pb_Click);
            this.onay_bekleyenler_pb.MouseLeave += new System.EventHandler(this.onay_bekleyenler_pb_MouseLeave);
            this.onay_bekleyenler_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onay_bekleyenler_pb_MouseMove);
            // 
            // onay_bekleyenler_label
            // 
            this.onay_bekleyenler_label.AutoSize = true;
            this.onay_bekleyenler_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.onay_bekleyenler_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.onay_bekleyenler_label.Location = new System.Drawing.Point(90, 25);
            this.onay_bekleyenler_label.Name = "onay_bekleyenler_label";
            this.onay_bekleyenler_label.Size = new System.Drawing.Size(205, 23);
            this.onay_bekleyenler_label.TabIndex = 25;
            this.onay_bekleyenler_label.Text = "Onay Bekleyenlerin Listesi";
            this.onay_bekleyenler_label.Click += new System.EventHandler(this.onay_bekleyenler_pb_Click);
            this.onay_bekleyenler_label.MouseLeave += new System.EventHandler(this.onay_bekleyenler_pb_MouseLeave);
            this.onay_bekleyenler_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onay_bekleyenler_pb_MouseMove);
            // 
            // admin_penceresi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1054, 286);
            this.Controls.Add(this.admin_islemleri_gb);
            this.Controls.Add(this.tablolari_listele_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "admin_penceresi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetici";
            this.Load += new System.EventHandler(this.admin_penceresi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablolari_listele_dgv)).EndInit();
            this.admin_islemleri_gb.ResumeLayout(false);
            this.admin_islemleri_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personel_arsivi_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personel_cikar_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personel_yetkilerini_duzenle_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onay_bekleyenler_pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablolari_listele_dgv;
        private System.Windows.Forms.GroupBox admin_islemleri_gb;
        private System.Windows.Forms.Label personel_cikar_bilgi_label;
        private System.Windows.Forms.PictureBox personel_cikar_pb;
        private System.Windows.Forms.Label personel_cikar_label;
        private System.Windows.Forms.Label personel_yetkilerini_duzenle_bilgi_label;
        private System.Windows.Forms.Label onay_bekleyenler_bilgi_label;
        private System.Windows.Forms.PictureBox personel_yetkilerini_duzenle_pb;
        private System.Windows.Forms.Label personel_yetkilerini_duzenle_label;
        private System.Windows.Forms.PictureBox onay_bekleyenler_pb;
        private System.Windows.Forms.Label onay_bekleyenler_label;
        private System.Windows.Forms.Label personel_arsivi_bilgi_label;
        private System.Windows.Forms.PictureBox personel_arsivi_pb;
        private System.Windows.Forms.Label personel_arsivi_label;
    }
}