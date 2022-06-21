namespace WindowsFormsApplication1
{
    partial class kiralama_islemleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kiralama_islemleri));
            this.kirala_menu = new System.Windows.Forms.MenuStrip();
            this.arac_kirala_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.yardim_toolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.sagtikmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.arac_kirala_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.yardim_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.arac_bilgileri_gb = new System.Windows.Forms.GroupBox();
            this.arac_bilgi_label = new System.Windows.Forms.Label();
            this.plaka_pb = new System.Windows.Forms.PictureBox();
            this.plaka_combo = new System.Windows.Forms.ComboBox();
            this.plaka_label = new System.Windows.Forms.Label();
            this.musteri_bilgileri_gb = new System.Windows.Forms.GroupBox();
            this.musteri_bilgi_label = new System.Windows.Forms.Label();
            this.tc_no_pb = new System.Windows.Forms.PictureBox();
            this.tc_combo = new System.Windows.Forms.ComboBox();
            this.tc_no_label = new System.Windows.Forms.Label();
            this.kiralama_bilgileri_gb = new System.Windows.Forms.GroupBox();
            this.turk_lirasi_label = new System.Windows.Forms.Label();
            this.fiyat_label = new System.Windows.Forms.Label();
            this.fiyat_tb = new System.Windows.Forms.TextBox();
            this.fiyat_pb = new System.Windows.Forms.PictureBox();
            this.odeme_turu_pb = new System.Windows.Forms.PictureBox();
            this.odeme_turu_combo = new System.Windows.Forms.ComboBox();
            this.odeme_turu_label = new System.Windows.Forms.Label();
            this.geri_alis_tarihi_dt = new System.Windows.Forms.DateTimePicker();
            this.geri_alis_tarihi_label = new System.Windows.Forms.Label();
            this.geri_alis_tarihi_pb = new System.Windows.Forms.PictureBox();
            this.kiralama_tarihi_dt = new System.Windows.Forms.DateTimePicker();
            this.kiralama_tarihi_label = new System.Windows.Forms.Label();
            this.kiralama_tarihi_pb = new System.Windows.Forms.PictureBox();
            this.iptalet_pb = new System.Windows.Forms.PictureBox();
            this.kirala_pb = new System.Windows.Forms.PictureBox();
            this.kirala_menu.SuspendLayout();
            this.sagtikmenu.SuspendLayout();
            this.arac_bilgileri_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plaka_pb)).BeginInit();
            this.musteri_bilgileri_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tc_no_pb)).BeginInit();
            this.kiralama_bilgileri_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fiyat_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.odeme_turu_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.geri_alis_tarihi_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiralama_tarihi_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kirala_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // kirala_menu
            // 
            this.kirala_menu.BackColor = System.Drawing.SystemColors.Highlight;
            this.kirala_menu.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kirala_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arac_kirala_menu,
            this.iptal_et_menu,
            this.yardim_toolstrip});
            this.kirala_menu.Location = new System.Drawing.Point(0, 0);
            this.kirala_menu.Name = "kirala_menu";
            this.kirala_menu.Size = new System.Drawing.Size(766, 26);
            this.kirala_menu.TabIndex = 28;
            this.kirala_menu.Text = "menuStrip1";
            // 
            // arac_kirala_menu
            // 
            this.arac_kirala_menu.Name = "arac_kirala_menu";
            this.arac_kirala_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.arac_kirala_menu.Size = new System.Drawing.Size(56, 22);
            this.arac_kirala_menu.Text = "Kirala";
            this.arac_kirala_menu.Click += new System.EventHandler(this.kirala_pb_Click);
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
            this.arac_kirala_sagtik,
            this.iptal_et_sagtik,
            this.yardim_sagtik});
            this.sagtikmenu.Name = "sagtikmenu";
            this.sagtikmenu.Size = new System.Drawing.Size(153, 92);
            // 
            // arac_kirala_sagtik
            // 
            this.arac_kirala_sagtik.Name = "arac_kirala_sagtik";
            this.arac_kirala_sagtik.Size = new System.Drawing.Size(152, 22);
            this.arac_kirala_sagtik.Text = "Kirala";
            this.arac_kirala_sagtik.Click += new System.EventHandler(this.kirala_pb_Click);
            // 
            // iptal_et_sagtik
            // 
            this.iptal_et_sagtik.Name = "iptal_et_sagtik";
            this.iptal_et_sagtik.Size = new System.Drawing.Size(152, 22);
            this.iptal_et_sagtik.Text = "İptal Et";
            this.iptal_et_sagtik.Click += new System.EventHandler(this.iptalet_pb_Click);
            // 
            // yardim_sagtik
            // 
            this.yardim_sagtik.Name = "yardim_sagtik";
            this.yardim_sagtik.Size = new System.Drawing.Size(152, 22);
            this.yardim_sagtik.Text = "Yardım";
            this.yardim_sagtik.Click += new System.EventHandler(this.yardim_toolstrip_Click);
            // 
            // arac_bilgileri_gb
            // 
            this.arac_bilgileri_gb.Controls.Add(this.arac_bilgi_label);
            this.arac_bilgileri_gb.Controls.Add(this.plaka_pb);
            this.arac_bilgileri_gb.Controls.Add(this.plaka_combo);
            this.arac_bilgileri_gb.Controls.Add(this.plaka_label);
            this.arac_bilgileri_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.arac_bilgileri_gb.Location = new System.Drawing.Point(402, 29);
            this.arac_bilgileri_gb.Name = "arac_bilgileri_gb";
            this.arac_bilgileri_gb.Size = new System.Drawing.Size(351, 382);
            this.arac_bilgileri_gb.TabIndex = 85;
            this.arac_bilgileri_gb.TabStop = false;
            this.arac_bilgileri_gb.Text = "Araç Bilgileri";
            // 
            // arac_bilgi_label
            // 
            this.arac_bilgi_label.AutoSize = true;
            this.arac_bilgi_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.arac_bilgi_label.Location = new System.Drawing.Point(6, 65);
            this.arac_bilgi_label.Name = "arac_bilgi_label";
            this.arac_bilgi_label.Size = new System.Drawing.Size(35, 18);
            this.arac_bilgi_label.TabIndex = 86;
            this.arac_bilgi_label.Text = "bilgi";
            // 
            // plaka_pb
            // 
            this.plaka_pb.Location = new System.Drawing.Point(6, 25);
            this.plaka_pb.Name = "plaka_pb";
            this.plaka_pb.Size = new System.Drawing.Size(32, 24);
            this.plaka_pb.TabIndex = 81;
            this.plaka_pb.TabStop = false;
            // 
            // plaka_combo
            // 
            this.plaka_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plaka_combo.FormattingEnabled = true;
            this.plaka_combo.Location = new System.Drawing.Point(167, 23);
            this.plaka_combo.Name = "plaka_combo";
            this.plaka_combo.Size = new System.Drawing.Size(178, 26);
            this.plaka_combo.TabIndex = 83;
            this.plaka_combo.SelectedIndexChanged += new System.EventHandler(this.plaka_combo_SelectedIndexChanged);
            // 
            // plaka_label
            // 
            this.plaka_label.AutoSize = true;
            this.plaka_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plaka_label.Location = new System.Drawing.Point(44, 26);
            this.plaka_label.Name = "plaka_label";
            this.plaka_label.Size = new System.Drawing.Size(117, 23);
            this.plaka_label.TabIndex = 82;
            this.plaka_label.Text = "Plaka Seçiniz:";
            // 
            // musteri_bilgileri_gb
            // 
            this.musteri_bilgileri_gb.Controls.Add(this.musteri_bilgi_label);
            this.musteri_bilgileri_gb.Controls.Add(this.tc_no_pb);
            this.musteri_bilgileri_gb.Controls.Add(this.tc_combo);
            this.musteri_bilgileri_gb.Controls.Add(this.tc_no_label);
            this.musteri_bilgileri_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.musteri_bilgileri_gb.Location = new System.Drawing.Point(12, 29);
            this.musteri_bilgileri_gb.Name = "musteri_bilgileri_gb";
            this.musteri_bilgileri_gb.Size = new System.Drawing.Size(351, 382);
            this.musteri_bilgileri_gb.TabIndex = 86;
            this.musteri_bilgileri_gb.TabStop = false;
            this.musteri_bilgileri_gb.Text = "Müşteri Bilgileri";
            // 
            // musteri_bilgi_label
            // 
            this.musteri_bilgi_label.AutoSize = true;
            this.musteri_bilgi_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.musteri_bilgi_label.Location = new System.Drawing.Point(6, 65);
            this.musteri_bilgi_label.Name = "musteri_bilgi_label";
            this.musteri_bilgi_label.Size = new System.Drawing.Size(35, 18);
            this.musteri_bilgi_label.TabIndex = 86;
            this.musteri_bilgi_label.Text = "bilgi";
            // 
            // tc_no_pb
            // 
            this.tc_no_pb.Location = new System.Drawing.Point(6, 25);
            this.tc_no_pb.Name = "tc_no_pb";
            this.tc_no_pb.Size = new System.Drawing.Size(32, 24);
            this.tc_no_pb.TabIndex = 81;
            this.tc_no_pb.TabStop = false;
            // 
            // tc_combo
            // 
            this.tc_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tc_combo.FormattingEnabled = true;
            this.tc_combo.Location = new System.Drawing.Point(167, 23);
            this.tc_combo.Name = "tc_combo";
            this.tc_combo.Size = new System.Drawing.Size(178, 26);
            this.tc_combo.TabIndex = 83;
            this.tc_combo.SelectedIndexChanged += new System.EventHandler(this.tc_combo_SelectedIndexChanged);
            // 
            // tc_no_label
            // 
            this.tc_no_label.AutoSize = true;
            this.tc_no_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tc_no_label.Location = new System.Drawing.Point(44, 26);
            this.tc_no_label.Name = "tc_no_label";
            this.tc_no_label.Size = new System.Drawing.Size(126, 23);
            this.tc_no_label.TabIndex = 82;
            this.tc_no_label.Text = "TC No Seçiniz:";
            // 
            // kiralama_bilgileri_gb
            // 
            this.kiralama_bilgileri_gb.Controls.Add(this.turk_lirasi_label);
            this.kiralama_bilgileri_gb.Controls.Add(this.fiyat_label);
            this.kiralama_bilgileri_gb.Controls.Add(this.fiyat_tb);
            this.kiralama_bilgileri_gb.Controls.Add(this.fiyat_pb);
            this.kiralama_bilgileri_gb.Controls.Add(this.odeme_turu_pb);
            this.kiralama_bilgileri_gb.Controls.Add(this.odeme_turu_combo);
            this.kiralama_bilgileri_gb.Controls.Add(this.odeme_turu_label);
            this.kiralama_bilgileri_gb.Controls.Add(this.geri_alis_tarihi_dt);
            this.kiralama_bilgileri_gb.Controls.Add(this.geri_alis_tarihi_label);
            this.kiralama_bilgileri_gb.Controls.Add(this.geri_alis_tarihi_pb);
            this.kiralama_bilgileri_gb.Controls.Add(this.kiralama_tarihi_dt);
            this.kiralama_bilgileri_gb.Controls.Add(this.kiralama_tarihi_label);
            this.kiralama_bilgileri_gb.Controls.Add(this.kiralama_tarihi_pb);
            this.kiralama_bilgileri_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kiralama_bilgileri_gb.Location = new System.Drawing.Point(12, 417);
            this.kiralama_bilgileri_gb.Name = "kiralama_bilgileri_gb";
            this.kiralama_bilgileri_gb.Size = new System.Drawing.Size(741, 94);
            this.kiralama_bilgileri_gb.TabIndex = 87;
            this.kiralama_bilgileri_gb.TabStop = false;
            this.kiralama_bilgileri_gb.Text = "Kiralama Bilgileri";
            // 
            // turk_lirasi_label
            // 
            this.turk_lirasi_label.AutoSize = true;
            this.turk_lirasi_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.turk_lirasi_label.Location = new System.Drawing.Point(635, 63);
            this.turk_lirasi_label.Name = "turk_lirasi_label";
            this.turk_lirasi_label.Size = new System.Drawing.Size(93, 18);
            this.turk_lirasi_label.TabIndex = 89;
            this.turk_lirasi_label.Text = "Türk Lirasi(₺)";
            // 
            // fiyat_label
            // 
            this.fiyat_label.AutoSize = true;
            this.fiyat_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fiyat_label.Location = new System.Drawing.Point(409, 57);
            this.fiyat_label.Name = "fiyat_label";
            this.fiyat_label.Size = new System.Drawing.Size(120, 23);
            this.fiyat_label.TabIndex = 88;
            this.fiyat_label.Text = "Toplam Kirasi:";
            // 
            // fiyat_tb
            // 
            this.fiyat_tb.Location = new System.Drawing.Point(563, 58);
            this.fiyat_tb.Name = "fiyat_tb";
            this.fiyat_tb.ReadOnly = true;
            this.fiyat_tb.Size = new System.Drawing.Size(68, 26);
            this.fiyat_tb.TabIndex = 88;
            // 
            // fiyat_pb
            // 
            this.fiyat_pb.Location = new System.Drawing.Point(371, 56);
            this.fiyat_pb.Name = "fiyat_pb";
            this.fiyat_pb.Size = new System.Drawing.Size(32, 24);
            this.fiyat_pb.TabIndex = 87;
            this.fiyat_pb.TabStop = false;
            // 
            // odeme_turu_pb
            // 
            this.odeme_turu_pb.Location = new System.Drawing.Point(371, 26);
            this.odeme_turu_pb.Name = "odeme_turu_pb";
            this.odeme_turu_pb.Size = new System.Drawing.Size(32, 24);
            this.odeme_turu_pb.TabIndex = 84;
            this.odeme_turu_pb.TabStop = false;
            // 
            // odeme_turu_combo
            // 
            this.odeme_turu_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.odeme_turu_combo.FormattingEnabled = true;
            this.odeme_turu_combo.Location = new System.Drawing.Point(563, 24);
            this.odeme_turu_combo.Name = "odeme_turu_combo";
            this.odeme_turu_combo.Size = new System.Drawing.Size(167, 26);
            this.odeme_turu_combo.TabIndex = 86;
            // 
            // odeme_turu_label
            // 
            this.odeme_turu_label.AutoSize = true;
            this.odeme_turu_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.odeme_turu_label.Location = new System.Drawing.Point(409, 27);
            this.odeme_turu_label.Name = "odeme_turu_label";
            this.odeme_turu_label.Size = new System.Drawing.Size(111, 23);
            this.odeme_turu_label.TabIndex = 85;
            this.odeme_turu_label.Text = "Ödeme Türü:";
            // 
            // geri_alis_tarihi_dt
            // 
            this.geri_alis_tarihi_dt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.geri_alis_tarihi_dt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.geri_alis_tarihi_dt.Location = new System.Drawing.Point(198, 55);
            this.geri_alis_tarihi_dt.MinDate = new System.DateTime(1976, 1, 1, 0, 0, 0, 0);
            this.geri_alis_tarihi_dt.Name = "geri_alis_tarihi_dt";
            this.geri_alis_tarihi_dt.ShowUpDown = true;
            this.geri_alis_tarihi_dt.Size = new System.Drawing.Size(167, 26);
            this.geri_alis_tarihi_dt.TabIndex = 58;
            this.geri_alis_tarihi_dt.ValueChanged += new System.EventHandler(this.geri_alis_tarihi_dt_ValueChanged);
            // 
            // geri_alis_tarihi_label
            // 
            this.geri_alis_tarihi_label.AutoSize = true;
            this.geri_alis_tarihi_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.geri_alis_tarihi_label.Location = new System.Drawing.Point(44, 58);
            this.geri_alis_tarihi_label.Name = "geri_alis_tarihi_label";
            this.geri_alis_tarihi_label.Size = new System.Drawing.Size(152, 23);
            this.geri_alis_tarihi_label.TabIndex = 57;
            this.geri_alis_tarihi_label.Text = "Geri Dönüş Tarihi:";
            // 
            // geri_alis_tarihi_pb
            // 
            this.geri_alis_tarihi_pb.Location = new System.Drawing.Point(6, 57);
            this.geri_alis_tarihi_pb.Name = "geri_alis_tarihi_pb";
            this.geri_alis_tarihi_pb.Size = new System.Drawing.Size(32, 24);
            this.geri_alis_tarihi_pb.TabIndex = 56;
            this.geri_alis_tarihi_pb.TabStop = false;
            // 
            // kiralama_tarihi_dt
            // 
            this.kiralama_tarihi_dt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.kiralama_tarihi_dt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kiralama_tarihi_dt.Location = new System.Drawing.Point(198, 23);
            this.kiralama_tarihi_dt.MinDate = new System.DateTime(1976, 1, 1, 0, 0, 0, 0);
            this.kiralama_tarihi_dt.Name = "kiralama_tarihi_dt";
            this.kiralama_tarihi_dt.ShowUpDown = true;
            this.kiralama_tarihi_dt.Size = new System.Drawing.Size(167, 26);
            this.kiralama_tarihi_dt.TabIndex = 55;
            this.kiralama_tarihi_dt.ValueChanged += new System.EventHandler(this.kiralama_tarihi_dt_ValueChanged);
            // 
            // kiralama_tarihi_label
            // 
            this.kiralama_tarihi_label.AutoSize = true;
            this.kiralama_tarihi_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kiralama_tarihi_label.Location = new System.Drawing.Point(44, 26);
            this.kiralama_tarihi_label.Name = "kiralama_tarihi_label";
            this.kiralama_tarihi_label.Size = new System.Drawing.Size(134, 23);
            this.kiralama_tarihi_label.TabIndex = 54;
            this.kiralama_tarihi_label.Text = "Kiralama Tarihi:";
            // 
            // kiralama_tarihi_pb
            // 
            this.kiralama_tarihi_pb.Location = new System.Drawing.Point(6, 25);
            this.kiralama_tarihi_pb.Name = "kiralama_tarihi_pb";
            this.kiralama_tarihi_pb.Size = new System.Drawing.Size(32, 24);
            this.kiralama_tarihi_pb.TabIndex = 53;
            this.kiralama_tarihi_pb.TabStop = false;
            // 
            // iptalet_pb
            // 
            this.iptalet_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iptalet_pb.Location = new System.Drawing.Point(591, 525);
            this.iptalet_pb.Name = "iptalet_pb";
            this.iptalet_pb.Size = new System.Drawing.Size(78, 55);
            this.iptalet_pb.TabIndex = 89;
            this.iptalet_pb.TabStop = false;
            this.iptalet_pb.Click += new System.EventHandler(this.iptalet_pb_Click);
            this.iptalet_pb.MouseLeave += new System.EventHandler(this.iptalet_pb_MouseLeave);
            this.iptalet_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iptalet_pb_MouseMove);
            // 
            // kirala_pb
            // 
            this.kirala_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kirala_pb.Location = new System.Drawing.Point(675, 525);
            this.kirala_pb.Name = "kirala_pb";
            this.kirala_pb.Size = new System.Drawing.Size(78, 55);
            this.kirala_pb.TabIndex = 88;
            this.kirala_pb.TabStop = false;
            this.kirala_pb.Click += new System.EventHandler(this.kirala_pb_Click);
            this.kirala_pb.MouseLeave += new System.EventHandler(this.kirala_pb_MouseLeave);
            this.kirala_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.kirala_pb_MouseMove);
            // 
            // kiralama_islemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(766, 592);
            this.ContextMenuStrip = this.sagtikmenu;
            this.Controls.Add(this.iptalet_pb);
            this.Controls.Add(this.kirala_pb);
            this.Controls.Add(this.kiralama_bilgileri_gb);
            this.Controls.Add(this.musteri_bilgileri_gb);
            this.Controls.Add(this.arac_bilgileri_gb);
            this.Controls.Add(this.kirala_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "kiralama_islemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiralama İşlemleri";
            this.Load += new System.EventHandler(this.kiralama_islemleri_Load);
            this.kirala_menu.ResumeLayout(false);
            this.kirala_menu.PerformLayout();
            this.sagtikmenu.ResumeLayout(false);
            this.arac_bilgileri_gb.ResumeLayout(false);
            this.arac_bilgileri_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plaka_pb)).EndInit();
            this.musteri_bilgileri_gb.ResumeLayout(false);
            this.musteri_bilgileri_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tc_no_pb)).EndInit();
            this.kiralama_bilgileri_gb.ResumeLayout(false);
            this.kiralama_bilgileri_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fiyat_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.odeme_turu_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.geri_alis_tarihi_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiralama_tarihi_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kirala_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip kirala_menu;
        private System.Windows.Forms.ToolStripMenuItem arac_kirala_menu;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_menu;
        private System.Windows.Forms.ToolStripMenuItem yardim_toolstrip;
        private System.Windows.Forms.ContextMenuStrip sagtikmenu;
        private System.Windows.Forms.ToolStripMenuItem arac_kirala_sagtik;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_sagtik;
        private System.Windows.Forms.ToolStripMenuItem yardim_sagtik;
        private System.Windows.Forms.GroupBox arac_bilgileri_gb;
        private System.Windows.Forms.Label arac_bilgi_label;
        private System.Windows.Forms.PictureBox plaka_pb;
        private System.Windows.Forms.ComboBox plaka_combo;
        private System.Windows.Forms.Label plaka_label;
        private System.Windows.Forms.GroupBox musteri_bilgileri_gb;
        private System.Windows.Forms.Label musteri_bilgi_label;
        private System.Windows.Forms.PictureBox tc_no_pb;
        private System.Windows.Forms.ComboBox tc_combo;
        private System.Windows.Forms.Label tc_no_label;
        private System.Windows.Forms.GroupBox kiralama_bilgileri_gb;
        private System.Windows.Forms.DateTimePicker kiralama_tarihi_dt;
        private System.Windows.Forms.Label kiralama_tarihi_label;
        private System.Windows.Forms.PictureBox kiralama_tarihi_pb;
        private System.Windows.Forms.DateTimePicker geri_alis_tarihi_dt;
        private System.Windows.Forms.Label geri_alis_tarihi_label;
        private System.Windows.Forms.PictureBox geri_alis_tarihi_pb;
        private System.Windows.Forms.PictureBox odeme_turu_pb;
        private System.Windows.Forms.ComboBox odeme_turu_combo;
        private System.Windows.Forms.Label odeme_turu_label;
        private System.Windows.Forms.Label fiyat_label;
        private System.Windows.Forms.PictureBox fiyat_pb;
        private System.Windows.Forms.Label turk_lirasi_label;
        private System.Windows.Forms.TextBox fiyat_tb;
        private System.Windows.Forms.PictureBox iptalet_pb;
        private System.Windows.Forms.PictureBox kirala_pb;
    }
}