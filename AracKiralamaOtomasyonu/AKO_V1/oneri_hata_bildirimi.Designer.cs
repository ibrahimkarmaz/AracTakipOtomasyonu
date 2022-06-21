namespace WindowsFormsApplication1
{
    partial class oneri_hata_bildirimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(oneri_hata_bildirimi));
            this.konu_combo = new System.Windows.Forms.ComboBox();
            this.konu_label = new System.Windows.Forms.Label();
            this.konu_pb = new System.Windows.Forms.PictureBox();
            this.icerik_tb = new System.Windows.Forms.TextBox();
            this.icerik_label = new System.Windows.Forms.Label();
            this.icerik_pb = new System.Windows.Forms.PictureBox();
            this.karkater_sayisi_kalan_label = new System.Windows.Forms.Label();
            this.iptalet_pb = new System.Windows.Forms.PictureBox();
            this.gonder_pb = new System.Windows.Forms.PictureBox();
            this.ilk_rasgele_sayi_tb = new System.Windows.Forms.TextBox();
            this.mat_soru_label = new System.Windows.Forms.Label();
            this.mat_pb = new System.Windows.Forms.PictureBox();
            this.ikinci_rasgele_sayi_tb = new System.Windows.Forms.TextBox();
            this.isaret_label = new System.Windows.Forms.Label();
            this.esittir_label = new System.Windows.Forms.Label();
            this.sonuc_tb = new System.Windows.Forms.TextBox();
            this.yenile_pb = new System.Windows.Forms.PictureBox();
            this.oneri_hata_menu = new System.Windows.Forms.MenuStrip();
            this.mesaj_gonder_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.yenile_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.yardim_toolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.sagtikmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mesaj_gonder_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.yenile_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.yardim_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.konu_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icerik_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gonder_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mat_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yenile_pb)).BeginInit();
            this.oneri_hata_menu.SuspendLayout();
            this.sagtikmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // konu_combo
            // 
            this.konu_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.konu_combo.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.konu_combo.FormattingEnabled = true;
            this.konu_combo.Location = new System.Drawing.Point(120, 42);
            this.konu_combo.Name = "konu_combo";
            this.konu_combo.Size = new System.Drawing.Size(287, 26);
            this.konu_combo.TabIndex = 51;
            // 
            // konu_label
            // 
            this.konu_label.AutoSize = true;
            this.konu_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.konu_label.Location = new System.Drawing.Point(50, 41);
            this.konu_label.Name = "konu_label";
            this.konu_label.Size = new System.Drawing.Size(51, 23);
            this.konu_label.TabIndex = 50;
            this.konu_label.Text = "Konu:";
            // 
            // konu_pb
            // 
            this.konu_pb.Location = new System.Drawing.Point(12, 40);
            this.konu_pb.Name = "konu_pb";
            this.konu_pb.Size = new System.Drawing.Size(32, 24);
            this.konu_pb.TabIndex = 49;
            this.konu_pb.TabStop = false;
            // 
            // icerik_tb
            // 
            this.icerik_tb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.icerik_tb.Location = new System.Drawing.Point(120, 74);
            this.icerik_tb.Multiline = true;
            this.icerik_tb.Name = "icerik_tb";
            this.icerik_tb.Size = new System.Drawing.Size(287, 179);
            this.icerik_tb.TabIndex = 57;
            this.icerik_tb.TextChanged += new System.EventHandler(this.icerik_tb_TextChanged);
            // 
            // icerik_label
            // 
            this.icerik_label.AutoSize = true;
            this.icerik_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.icerik_label.Location = new System.Drawing.Point(50, 75);
            this.icerik_label.Name = "icerik_label";
            this.icerik_label.Size = new System.Drawing.Size(64, 23);
            this.icerik_label.TabIndex = 56;
            this.icerik_label.Text = "İçerik:";
            // 
            // icerik_pb
            // 
            this.icerik_pb.Location = new System.Drawing.Point(12, 74);
            this.icerik_pb.Name = "icerik_pb";
            this.icerik_pb.Size = new System.Drawing.Size(32, 24);
            this.icerik_pb.TabIndex = 55;
            this.icerik_pb.TabStop = false;
            // 
            // karkater_sayisi_kalan_label
            // 
            this.karkater_sayisi_kalan_label.AutoSize = true;
            this.karkater_sayisi_kalan_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.karkater_sayisi_kalan_label.Location = new System.Drawing.Point(360, 256);
            this.karkater_sayisi_kalan_label.Name = "karkater_sayisi_kalan_label";
            this.karkater_sayisi_kalan_label.Size = new System.Drawing.Size(47, 18);
            this.karkater_sayisi_kalan_label.TabIndex = 58;
            this.karkater_sayisi_kalan_label.Text = "0/255";
            // 
            // iptalet_pb
            // 
            this.iptalet_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iptalet_pb.Location = new System.Drawing.Point(245, 315);
            this.iptalet_pb.Name = "iptalet_pb";
            this.iptalet_pb.Size = new System.Drawing.Size(78, 55);
            this.iptalet_pb.TabIndex = 60;
            this.iptalet_pb.TabStop = false;
            this.iptalet_pb.Click += new System.EventHandler(this.iptalet_pb_Click);
            this.iptalet_pb.MouseLeave += new System.EventHandler(this.iptalet_pb_MouseLeave);
            this.iptalet_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iptalet_pb_MouseMove);
            // 
            // gonder_pb
            // 
            this.gonder_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gonder_pb.Location = new System.Drawing.Point(329, 315);
            this.gonder_pb.Name = "gonder_pb";
            this.gonder_pb.Size = new System.Drawing.Size(78, 55);
            this.gonder_pb.TabIndex = 59;
            this.gonder_pb.TabStop = false;
            this.gonder_pb.Click += new System.EventHandler(this.gonder_pb_Click);
            this.gonder_pb.MouseLeave += new System.EventHandler(this.gonder_pb_MouseLeave);
            this.gonder_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gonder_pb_MouseMove);
            // 
            // ilk_rasgele_sayi_tb
            // 
            this.ilk_rasgele_sayi_tb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.ilk_rasgele_sayi_tb.Location = new System.Drawing.Point(120, 268);
            this.ilk_rasgele_sayi_tb.Name = "ilk_rasgele_sayi_tb";
            this.ilk_rasgele_sayi_tb.Size = new System.Drawing.Size(39, 26);
            this.ilk_rasgele_sayi_tb.TabIndex = 63;
            // 
            // mat_soru_label
            // 
            this.mat_soru_label.AutoSize = true;
            this.mat_soru_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mat_soru_label.Location = new System.Drawing.Point(51, 272);
            this.mat_soru_label.Name = "mat_soru_label";
            this.mat_soru_label.Size = new System.Drawing.Size(52, 23);
            this.mat_soru_label.TabIndex = 62;
            this.mat_soru_label.Text = "Soru:";
            // 
            // mat_pb
            // 
            this.mat_pb.Location = new System.Drawing.Point(12, 270);
            this.mat_pb.Name = "mat_pb";
            this.mat_pb.Size = new System.Drawing.Size(32, 24);
            this.mat_pb.TabIndex = 61;
            this.mat_pb.TabStop = false;
            // 
            // ikinci_rasgele_sayi_tb
            // 
            this.ikinci_rasgele_sayi_tb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.ikinci_rasgele_sayi_tb.Location = new System.Drawing.Point(190, 269);
            this.ikinci_rasgele_sayi_tb.Name = "ikinci_rasgele_sayi_tb";
            this.ikinci_rasgele_sayi_tb.Size = new System.Drawing.Size(39, 26);
            this.ikinci_rasgele_sayi_tb.TabIndex = 64;
            // 
            // isaret_label
            // 
            this.isaret_label.AutoSize = true;
            this.isaret_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isaret_label.Location = new System.Drawing.Point(165, 269);
            this.isaret_label.Name = "isaret_label";
            this.isaret_label.Size = new System.Drawing.Size(19, 23);
            this.isaret_label.TabIndex = 65;
            this.isaret_label.Text = "?";
            // 
            // esittir_label
            // 
            this.esittir_label.AutoSize = true;
            this.esittir_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.esittir_label.Location = new System.Drawing.Point(235, 269);
            this.esittir_label.Name = "esittir_label";
            this.esittir_label.Size = new System.Drawing.Size(20, 23);
            this.esittir_label.TabIndex = 66;
            this.esittir_label.Text = "=";
            // 
            // sonuc_tb
            // 
            this.sonuc_tb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.sonuc_tb.Location = new System.Drawing.Point(261, 269);
            this.sonuc_tb.Name = "sonuc_tb";
            this.sonuc_tb.Size = new System.Drawing.Size(39, 26);
            this.sonuc_tb.TabIndex = 67;
            // 
            // yenile_pb
            // 
            this.yenile_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yenile_pb.Location = new System.Drawing.Point(308, 270);
            this.yenile_pb.Name = "yenile_pb";
            this.yenile_pb.Size = new System.Drawing.Size(32, 24);
            this.yenile_pb.TabIndex = 68;
            this.yenile_pb.TabStop = false;
            this.yenile_pb.Click += new System.EventHandler(this.yenile_pb_Click);
            this.yenile_pb.MouseLeave += new System.EventHandler(this.yenile_pb_MouseLeave);
            this.yenile_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.yenile_pb_MouseMove);
            // 
            // oneri_hata_menu
            // 
            this.oneri_hata_menu.BackColor = System.Drawing.SystemColors.Highlight;
            this.oneri_hata_menu.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.oneri_hata_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mesaj_gonder_menu,
            this.iptal_et_menu,
            this.yenile_menu,
            this.yardim_toolstrip});
            this.oneri_hata_menu.Location = new System.Drawing.Point(0, 0);
            this.oneri_hata_menu.Name = "oneri_hata_menu";
            this.oneri_hata_menu.Size = new System.Drawing.Size(422, 26);
            this.oneri_hata_menu.TabIndex = 69;
            this.oneri_hata_menu.Text = "menuStrip1";
            // 
            // mesaj_gonder_menu
            // 
            this.mesaj_gonder_menu.Name = "mesaj_gonder_menu";
            this.mesaj_gonder_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.mesaj_gonder_menu.Size = new System.Drawing.Size(104, 22);
            this.mesaj_gonder_menu.Text = "Mesaj Gönder";
            this.mesaj_gonder_menu.Click += new System.EventHandler(this.gonder_pb_Click);
            // 
            // iptal_et_menu
            // 
            this.iptal_et_menu.Name = "iptal_et_menu";
            this.iptal_et_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.iptal_et_menu.Size = new System.Drawing.Size(67, 22);
            this.iptal_et_menu.Text = "İptal Et";
            this.iptal_et_menu.Click += new System.EventHandler(this.iptalet_pb_Click);
            // 
            // yenile_menu
            // 
            this.yenile_menu.Name = "yenile_menu";
            this.yenile_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.yenile_menu.Size = new System.Drawing.Size(105, 22);
            this.yenile_menu.Text = "Soruyu Yenile";
            this.yenile_menu.Click += new System.EventHandler(this.yenile_pb_Click);
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
            this.mesaj_gonder_sagtik,
            this.iptal_et_sagtik,
            this.yenile_sagtik,
            this.yardim_sagtik});
            this.sagtikmenu.Name = "sagtikmenu";
            this.sagtikmenu.Size = new System.Drawing.Size(192, 92);
            // 
            // mesaj_gonder_sagtik
            // 
            this.mesaj_gonder_sagtik.Name = "mesaj_gonder_sagtik";
            this.mesaj_gonder_sagtik.Size = new System.Drawing.Size(191, 22);
            this.mesaj_gonder_sagtik.Text = "Üye Başvurusu Yap";
            this.mesaj_gonder_sagtik.Click += new System.EventHandler(this.gonder_pb_Click);
            // 
            // iptal_et_sagtik
            // 
            this.iptal_et_sagtik.Name = "iptal_et_sagtik";
            this.iptal_et_sagtik.Size = new System.Drawing.Size(191, 22);
            this.iptal_et_sagtik.Text = "İptal Et";
            this.iptal_et_sagtik.Click += new System.EventHandler(this.iptalet_pb_Click);
            // 
            // yenile_sagtik
            // 
            this.yenile_sagtik.Name = "yenile_sagtik";
            this.yenile_sagtik.Size = new System.Drawing.Size(191, 22);
            this.yenile_sagtik.Text = "Soruyu Yenile";
            this.yenile_sagtik.Click += new System.EventHandler(this.yenile_pb_Click);
            // 
            // yardim_sagtik
            // 
            this.yardim_sagtik.Name = "yardim_sagtik";
            this.yardim_sagtik.Size = new System.Drawing.Size(191, 22);
            this.yardim_sagtik.Text = "Yardım";
            this.yardim_sagtik.Click += new System.EventHandler(this.yardim_toolstrip_Click);
            // 
            // oneri_hata_bildirimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(422, 382);
            this.ContextMenuStrip = this.sagtikmenu;
            this.Controls.Add(this.oneri_hata_menu);
            this.Controls.Add(this.yenile_pb);
            this.Controls.Add(this.sonuc_tb);
            this.Controls.Add(this.esittir_label);
            this.Controls.Add(this.isaret_label);
            this.Controls.Add(this.ikinci_rasgele_sayi_tb);
            this.Controls.Add(this.ilk_rasgele_sayi_tb);
            this.Controls.Add(this.mat_soru_label);
            this.Controls.Add(this.mat_pb);
            this.Controls.Add(this.iptalet_pb);
            this.Controls.Add(this.gonder_pb);
            this.Controls.Add(this.karkater_sayisi_kalan_label);
            this.Controls.Add(this.icerik_tb);
            this.Controls.Add(this.icerik_label);
            this.Controls.Add(this.icerik_pb);
            this.Controls.Add(this.konu_combo);
            this.Controls.Add(this.konu_label);
            this.Controls.Add(this.konu_pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "oneri_hata_bildirimi";
            this.Text = "Öneri ve Hata Bildirimleri";
            this.Load += new System.EventHandler(this.oneri_hata_bildirimi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.konu_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icerik_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gonder_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mat_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yenile_pb)).EndInit();
            this.oneri_hata_menu.ResumeLayout(false);
            this.oneri_hata_menu.PerformLayout();
            this.sagtikmenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox konu_combo;
        private System.Windows.Forms.Label konu_label;
        private System.Windows.Forms.PictureBox konu_pb;
        private System.Windows.Forms.TextBox icerik_tb;
        private System.Windows.Forms.Label icerik_label;
        private System.Windows.Forms.PictureBox icerik_pb;
        private System.Windows.Forms.Label karkater_sayisi_kalan_label;
        private System.Windows.Forms.PictureBox iptalet_pb;
        private System.Windows.Forms.PictureBox gonder_pb;
        private System.Windows.Forms.TextBox ilk_rasgele_sayi_tb;
        private System.Windows.Forms.Label mat_soru_label;
        private System.Windows.Forms.PictureBox mat_pb;
        private System.Windows.Forms.TextBox ikinci_rasgele_sayi_tb;
        private System.Windows.Forms.Label isaret_label;
        private System.Windows.Forms.Label esittir_label;
        private System.Windows.Forms.TextBox sonuc_tb;
        private System.Windows.Forms.PictureBox yenile_pb;
        private System.Windows.Forms.MenuStrip oneri_hata_menu;
        private System.Windows.Forms.ToolStripMenuItem mesaj_gonder_menu;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_menu;
        private System.Windows.Forms.ToolStripMenuItem yardim_toolstrip;
        private System.Windows.Forms.ContextMenuStrip sagtikmenu;
        private System.Windows.Forms.ToolStripMenuItem mesaj_gonder_sagtik;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_sagtik;
        private System.Windows.Forms.ToolStripMenuItem yardim_sagtik;
        private System.Windows.Forms.ToolStripMenuItem yenile_menu;
        private System.Windows.Forms.ToolStripMenuItem yenile_sagtik;
    }
}