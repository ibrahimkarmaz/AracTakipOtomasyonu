namespace WindowsFormsApplication1
{
    partial class kiralama_islemini_teslim_al_veya_iptal_et
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kiralama_islemini_teslim_al_veya_iptal_et));
            this.degistirilecekler_gb = new System.Windows.Forms.GroupBox();
            this.musteriyi_cikar_cb = new System.Windows.Forms.CheckBox();
            this.tum_kiralananlari_teslim_al_cb = new System.Windows.Forms.CheckBox();
            this.ozet_bilgi_label = new System.Windows.Forms.Label();
            this.kiranalan_arac_pb = new System.Windows.Forms.PictureBox();
            this.iptalet_pb = new System.Windows.Forms.PictureBox();
            this.kiralayan_tc_bilgi_pb = new System.Windows.Forms.PictureBox();
            this.kirala_pb = new System.Windows.Forms.PictureBox();
            this.ve_isareti_label = new System.Windows.Forms.Label();
            this.karkater_sayisi_kalan_label = new System.Windows.Forms.Label();
            this.kiralanan_arac_combo = new System.Windows.Forms.ComboBox();
            this.aciklama_pb = new System.Windows.Forms.PictureBox();
            this.aciklama_label = new System.Windows.Forms.Label();
            this.kiralayan_tc_pb = new System.Windows.Forms.PictureBox();
            this.aciklama_tb = new System.Windows.Forms.TextBox();
            this.kiralayan_tc_combo = new System.Windows.Forms.ComboBox();
            this.kiralayan_tc_label = new System.Windows.Forms.Label();
            this.kirala_menu = new System.Windows.Forms.MenuStrip();
            this.kiralama_iptal_et_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.yardim_toolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.sagtikmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kiralama_iptal_et_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.yardim_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.degistirilecekler_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kiranalan_arac_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiralayan_tc_bilgi_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kirala_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiralayan_tc_pb)).BeginInit();
            this.kirala_menu.SuspendLayout();
            this.sagtikmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // degistirilecekler_gb
            // 
            this.degistirilecekler_gb.Controls.Add(this.musteriyi_cikar_cb);
            this.degistirilecekler_gb.Controls.Add(this.tum_kiralananlari_teslim_al_cb);
            this.degistirilecekler_gb.Controls.Add(this.ozet_bilgi_label);
            this.degistirilecekler_gb.Controls.Add(this.kiranalan_arac_pb);
            this.degistirilecekler_gb.Controls.Add(this.iptalet_pb);
            this.degistirilecekler_gb.Controls.Add(this.kiralayan_tc_bilgi_pb);
            this.degistirilecekler_gb.Controls.Add(this.kirala_pb);
            this.degistirilecekler_gb.Controls.Add(this.ve_isareti_label);
            this.degistirilecekler_gb.Controls.Add(this.karkater_sayisi_kalan_label);
            this.degistirilecekler_gb.Controls.Add(this.kiralanan_arac_combo);
            this.degistirilecekler_gb.Controls.Add(this.aciklama_pb);
            this.degistirilecekler_gb.Controls.Add(this.aciklama_label);
            this.degistirilecekler_gb.Controls.Add(this.kiralayan_tc_pb);
            this.degistirilecekler_gb.Controls.Add(this.aciklama_tb);
            this.degistirilecekler_gb.Controls.Add(this.kiralayan_tc_combo);
            this.degistirilecekler_gb.Controls.Add(this.kiralayan_tc_label);
            this.degistirilecekler_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.degistirilecekler_gb.Location = new System.Drawing.Point(12, 29);
            this.degistirilecekler_gb.Name = "degistirilecekler_gb";
            this.degistirilecekler_gb.Size = new System.Drawing.Size(741, 296);
            this.degistirilecekler_gb.TabIndex = 97;
            this.degistirilecekler_gb.TabStop = false;
            this.degistirilecekler_gb.Text = "Kiralayan Müşteri ve Kiralanan Araç(lar)";
            // 
            // musteriyi_cikar_cb
            // 
            this.musteriyi_cikar_cb.AutoSize = true;
            this.musteriyi_cikar_cb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.musteriyi_cikar_cb.ForeColor = System.Drawing.Color.Black;
            this.musteriyi_cikar_cb.Location = new System.Drawing.Point(377, 201);
            this.musteriyi_cikar_cb.Name = "musteriyi_cikar_cb";
            this.musteriyi_cikar_cb.Size = new System.Drawing.Size(264, 23);
            this.musteriyi_cikar_cb.TabIndex = 105;
            this.musteriyi_cikar_cb.Text = "Müşteriler listesinden müşteriyi çıkar";
            this.musteriyi_cikar_cb.UseVisualStyleBackColor = true;
            this.musteriyi_cikar_cb.Visible = false;
            // 
            // tum_kiralananlari_teslim_al_cb
            // 
            this.tum_kiralananlari_teslim_al_cb.AutoSize = true;
            this.tum_kiralananlari_teslim_al_cb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tum_kiralananlari_teslim_al_cb.ForeColor = System.Drawing.Color.Black;
            this.tum_kiralananlari_teslim_al_cb.Location = new System.Drawing.Point(377, 154);
            this.tum_kiralananlari_teslim_al_cb.Name = "tum_kiralananlari_teslim_al_cb";
            this.tum_kiralananlari_teslim_al_cb.Size = new System.Drawing.Size(343, 42);
            this.tum_kiralananlari_teslim_al_cb.TabIndex = 104;
            this.tum_kiralananlari_teslim_al_cb.Text = "Müşteriye ait kiralanan araçlar üç ve üçden fazla\r\nise tümünü teslim al";
            this.tum_kiralananlari_teslim_al_cb.UseVisualStyleBackColor = true;
            this.tum_kiralananlari_teslim_al_cb.Visible = false;
            this.tum_kiralananlari_teslim_al_cb.CheckedChanged += new System.EventHandler(this.tum_kiralananlari_teslim_al_cb_CheckedChanged);
            // 
            // ozet_bilgi_label
            // 
            this.ozet_bilgi_label.AutoSize = true;
            this.ozet_bilgi_label.Location = new System.Drawing.Point(6, 62);
            this.ozet_bilgi_label.Name = "ozet_bilgi_label";
            this.ozet_bilgi_label.Size = new System.Drawing.Size(72, 18);
            this.ozet_bilgi_label.TabIndex = 92;
            this.ozet_bilgi_label.Text = "Özet Bilgi:";
            // 
            // kiranalan_arac_pb
            // 
            this.kiranalan_arac_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kiranalan_arac_pb.Location = new System.Drawing.Point(694, 25);
            this.kiranalan_arac_pb.Name = "kiranalan_arac_pb";
            this.kiranalan_arac_pb.Size = new System.Drawing.Size(32, 24);
            this.kiranalan_arac_pb.TabIndex = 91;
            this.kiranalan_arac_pb.TabStop = false;
            this.kiranalan_arac_pb.Click += new System.EventHandler(this.kiranalan_arac_pb_Click);
            this.kiranalan_arac_pb.MouseLeave += new System.EventHandler(this.kiranalan_arac_pb_MouseLeave);
            this.kiranalan_arac_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.kiranalan_arac_pb_MouseMove);
            // 
            // iptalet_pb
            // 
            this.iptalet_pb.BackColor = System.Drawing.Color.Transparent;
            this.iptalet_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iptalet_pb.Location = new System.Drawing.Point(564, 230);
            this.iptalet_pb.Name = "iptalet_pb";
            this.iptalet_pb.Size = new System.Drawing.Size(78, 55);
            this.iptalet_pb.TabIndex = 103;
            this.iptalet_pb.TabStop = false;
            this.iptalet_pb.Click += new System.EventHandler(this.iptalet_pb_Click);
            this.iptalet_pb.MouseLeave += new System.EventHandler(this.iptalet_pb_MouseLeave);
            this.iptalet_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iptalet_pb_MouseMove);
            // 
            // kiralayan_tc_bilgi_pb
            // 
            this.kiralayan_tc_bilgi_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kiralayan_tc_bilgi_pb.Location = new System.Drawing.Point(453, 25);
            this.kiralayan_tc_bilgi_pb.Name = "kiralayan_tc_bilgi_pb";
            this.kiralayan_tc_bilgi_pb.Size = new System.Drawing.Size(32, 24);
            this.kiralayan_tc_bilgi_pb.TabIndex = 90;
            this.kiralayan_tc_bilgi_pb.TabStop = false;
            this.kiralayan_tc_bilgi_pb.Click += new System.EventHandler(this.kiralayan_tc_bilgi_pb_Click);
            this.kiralayan_tc_bilgi_pb.MouseLeave += new System.EventHandler(this.kiralayan_tc_bilgi_pb_MouseLeave);
            this.kiralayan_tc_bilgi_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.kiralayan_tc_bilgi_pb_MouseMove);
            // 
            // kirala_pb
            // 
            this.kirala_pb.BackColor = System.Drawing.Color.Transparent;
            this.kirala_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kirala_pb.Location = new System.Drawing.Point(648, 230);
            this.kirala_pb.Name = "kirala_pb";
            this.kirala_pb.Size = new System.Drawing.Size(78, 55);
            this.kirala_pb.TabIndex = 102;
            this.kirala_pb.TabStop = false;
            this.kirala_pb.Click += new System.EventHandler(this.kirala_pb_Click);
            this.kirala_pb.MouseLeave += new System.EventHandler(this.kirala_pb_MouseLeave);
            this.kirala_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.kirala_pb_MouseMove);
            // 
            // ve_isareti_label
            // 
            this.ve_isareti_label.AutoSize = true;
            this.ve_isareti_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ve_isareti_label.Location = new System.Drawing.Point(488, 26);
            this.ve_isareti_label.Name = "ve_isareti_label";
            this.ve_isareti_label.Size = new System.Drawing.Size(20, 23);
            this.ve_isareti_label.TabIndex = 88;
            this.ve_isareti_label.Text = "&&";
            // 
            // karkater_sayisi_kalan_label
            // 
            this.karkater_sayisi_kalan_label.AutoSize = true;
            this.karkater_sayisi_kalan_label.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.karkater_sayisi_kalan_label.Location = new System.Drawing.Point(329, 268);
            this.karkater_sayisi_kalan_label.Name = "karkater_sayisi_kalan_label";
            this.karkater_sayisi_kalan_label.Size = new System.Drawing.Size(42, 17);
            this.karkater_sayisi_kalan_label.TabIndex = 99;
            this.karkater_sayisi_kalan_label.Text = "0/255";
            // 
            // kiralanan_arac_combo
            // 
            this.kiralanan_arac_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kiralanan_arac_combo.FormattingEnabled = true;
            this.kiralanan_arac_combo.Location = new System.Drawing.Point(510, 23);
            this.kiralanan_arac_combo.Name = "kiralanan_arac_combo";
            this.kiralanan_arac_combo.Size = new System.Drawing.Size(178, 26);
            this.kiralanan_arac_combo.TabIndex = 87;
            this.kiralanan_arac_combo.SelectedIndexChanged += new System.EventHandler(this.kiralanan_arac_combo_SelectedIndexChanged);
            // 
            // aciklama_pb
            // 
            this.aciklama_pb.Location = new System.Drawing.Point(6, 124);
            this.aciklama_pb.Name = "aciklama_pb";
            this.aciklama_pb.Size = new System.Drawing.Size(32, 24);
            this.aciklama_pb.TabIndex = 98;
            this.aciklama_pb.TabStop = false;
            // 
            // aciklama_label
            // 
            this.aciklama_label.AutoSize = true;
            this.aciklama_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aciklama_label.Location = new System.Drawing.Point(44, 125);
            this.aciklama_label.Name = "aciklama_label";
            this.aciklama_label.Size = new System.Drawing.Size(261, 23);
            this.aciklama_label.TabIndex = 100;
            this.aciklama_label.Text = "İptel Etme Sebebini Açıklayınız:";
            // 
            // kiralayan_tc_pb
            // 
            this.kiralayan_tc_pb.Location = new System.Drawing.Point(6, 25);
            this.kiralayan_tc_pb.Name = "kiralayan_tc_pb";
            this.kiralayan_tc_pb.Size = new System.Drawing.Size(32, 24);
            this.kiralayan_tc_pb.TabIndex = 81;
            this.kiralayan_tc_pb.TabStop = false;
            // 
            // aciklama_tb
            // 
            this.aciklama_tb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aciklama_tb.Location = new System.Drawing.Point(6, 154);
            this.aciklama_tb.Multiline = true;
            this.aciklama_tb.Name = "aciklama_tb";
            this.aciklama_tb.Size = new System.Drawing.Size(365, 111);
            this.aciklama_tb.TabIndex = 101;
            this.aciklama_tb.TextChanged += new System.EventHandler(this.aciklama_tb_TextChanged);
            // 
            // kiralayan_tc_combo
            // 
            this.kiralayan_tc_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kiralayan_tc_combo.FormattingEnabled = true;
            this.kiralayan_tc_combo.Location = new System.Drawing.Point(269, 23);
            this.kiralayan_tc_combo.Name = "kiralayan_tc_combo";
            this.kiralayan_tc_combo.Size = new System.Drawing.Size(178, 26);
            this.kiralayan_tc_combo.TabIndex = 83;
            this.kiralayan_tc_combo.SelectedIndexChanged += new System.EventHandler(this.kiralayan_tc_combo_SelectedIndexChanged);
            // 
            // kiralayan_tc_label
            // 
            this.kiralayan_tc_label.AutoSize = true;
            this.kiralayan_tc_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kiralayan_tc_label.Location = new System.Drawing.Point(44, 26);
            this.kiralayan_tc_label.Name = "kiralayan_tc_label";
            this.kiralayan_tc_label.Size = new System.Drawing.Size(220, 23);
            this.kiralayan_tc_label.TabIndex = 82;
            this.kiralayan_tc_label.Text = "TC ve Plaka No\'nu Seçiniz:";
            // 
            // kirala_menu
            // 
            this.kirala_menu.BackColor = System.Drawing.SystemColors.Highlight;
            this.kirala_menu.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kirala_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kiralama_iptal_et_menu,
            this.iptal_et_menu,
            this.yardim_toolstrip});
            this.kirala_menu.Location = new System.Drawing.Point(0, 0);
            this.kirala_menu.Name = "kirala_menu";
            this.kirala_menu.Size = new System.Drawing.Size(767, 26);
            this.kirala_menu.TabIndex = 105;
            this.kirala_menu.Text = "menuStrip1";
            // 
            // kiralama_iptal_et_menu
            // 
            this.kiralama_iptal_et_menu.Name = "kiralama_iptal_et_menu";
            this.kiralama_iptal_et_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.kiralama_iptal_et_menu.Size = new System.Drawing.Size(134, 22);
            this.kiralama_iptal_et_menu.Text = "Kiralamayı İptal Et";
            this.kiralama_iptal_et_menu.Click += new System.EventHandler(this.kirala_pb_Click);
            // 
            // iptal_et_menu
            // 
            this.iptal_et_menu.Name = "iptal_et_menu";
            this.iptal_et_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.iptal_et_menu.Size = new System.Drawing.Size(67, 22);
            this.iptal_et_menu.Text = "İptal Et";
            this.iptal_et_menu.Click += new System.EventHandler(this.iptalet_pb_Click);
            // 
            // yardim_toolstrip
            // 
            this.yardim_toolstrip.Name = "yardim_toolstrip";
            this.yardim_toolstrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.yardim_toolstrip.Size = new System.Drawing.Size(63, 22);
            this.yardim_toolstrip.Text = "Yardım";
            this.yardim_toolstrip.Click += new System.EventHandler(this.yardim_toolstrip_Click);
            // 
            // sagtikmenu
            // 
            this.sagtikmenu.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sagtikmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kiralama_iptal_et_sagtik,
            this.iptal_et_sagtik,
            this.yardim_sagtik});
            this.sagtikmenu.Name = "sagtikmenu";
            this.sagtikmenu.Size = new System.Drawing.Size(191, 92);
            // 
            // kiralama_iptal_et_sagtik
            // 
            this.kiralama_iptal_et_sagtik.Name = "kiralama_iptal_et_sagtik";
            this.kiralama_iptal_et_sagtik.Size = new System.Drawing.Size(190, 22);
            this.kiralama_iptal_et_sagtik.Text = "Kiralamayı İptal Et";
            this.kiralama_iptal_et_sagtik.Click += new System.EventHandler(this.kirala_pb_Click);
            // 
            // iptal_et_sagtik
            // 
            this.iptal_et_sagtik.Name = "iptal_et_sagtik";
            this.iptal_et_sagtik.Size = new System.Drawing.Size(190, 22);
            this.iptal_et_sagtik.Text = "İptal Et";
            this.iptal_et_sagtik.Click += new System.EventHandler(this.iptalet_pb_Click);
            // 
            // yardim_sagtik
            // 
            this.yardim_sagtik.Name = "yardim_sagtik";
            this.yardim_sagtik.Size = new System.Drawing.Size(190, 22);
            this.yardim_sagtik.Text = "Yardım";
            this.yardim_sagtik.Click += new System.EventHandler(this.yardim_toolstrip_Click);
            // 
            // kiralama_islemini_teslim_al_veya_iptal_et
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(767, 342);
            this.ContextMenuStrip = this.sagtikmenu;
            this.Controls.Add(this.kirala_menu);
            this.Controls.Add(this.degistirilecekler_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "kiralama_islemini_teslim_al_veya_iptal_et";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "kiralama_islemini_iptal_et";
            this.Load += new System.EventHandler(this.kiralama_islemini_iptal_et_Load);
            this.degistirilecekler_gb.ResumeLayout(false);
            this.degistirilecekler_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kiranalan_arac_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiralayan_tc_bilgi_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kirala_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiralayan_tc_pb)).EndInit();
            this.kirala_menu.ResumeLayout(false);
            this.kirala_menu.PerformLayout();
            this.sagtikmenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox degistirilecekler_gb;
        private System.Windows.Forms.PictureBox kiranalan_arac_pb;
        private System.Windows.Forms.PictureBox kiralayan_tc_bilgi_pb;
        private System.Windows.Forms.Label ve_isareti_label;
        private System.Windows.Forms.ComboBox kiralanan_arac_combo;
        private System.Windows.Forms.PictureBox kiralayan_tc_pb;
        private System.Windows.Forms.ComboBox kiralayan_tc_combo;
        private System.Windows.Forms.Label kiralayan_tc_label;
        private System.Windows.Forms.Label ozet_bilgi_label;
        private System.Windows.Forms.Label karkater_sayisi_kalan_label;
        private System.Windows.Forms.PictureBox aciklama_pb;
        private System.Windows.Forms.Label aciklama_label;
        private System.Windows.Forms.TextBox aciklama_tb;
        private System.Windows.Forms.PictureBox iptalet_pb;
        private System.Windows.Forms.PictureBox kirala_pb;
        private System.Windows.Forms.MenuStrip kirala_menu;
        private System.Windows.Forms.ToolStripMenuItem kiralama_iptal_et_menu;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_menu;
        private System.Windows.Forms.ToolStripMenuItem yardim_toolstrip;
        private System.Windows.Forms.ContextMenuStrip sagtikmenu;
        private System.Windows.Forms.ToolStripMenuItem kiralama_iptal_et_sagtik;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_sagtik;
        private System.Windows.Forms.ToolStripMenuItem yardim_sagtik;
        private System.Windows.Forms.CheckBox tum_kiralananlari_teslim_al_cb;
        private System.Windows.Forms.CheckBox musteriyi_cikar_cb;
    }
}