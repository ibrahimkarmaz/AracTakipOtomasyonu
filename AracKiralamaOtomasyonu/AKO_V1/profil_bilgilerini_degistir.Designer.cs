namespace WindowsFormsApplication1
{
    partial class profil_bilgilerini_degistir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(profil_bilgilerini_degistir));
            this.ev_masketb = new System.Windows.Forms.MaskedTextBox();
            this.zaman_datetime = new System.Windows.Forms.DateTimePicker();
            this.cep_masketb = new System.Windows.Forms.MaskedTextBox();
            this.e_label = new System.Windows.Forms.Label();
            this.mail_uzantisi_combo = new System.Windows.Forms.ComboBox();
            this.ilce_combo = new System.Windows.Forms.ComboBox();
            this.il_combo = new System.Windows.Forms.ComboBox();
            this.kadin_cb = new System.Windows.Forms.RadioButton();
            this.erkek_cb = new System.Windows.Forms.RadioButton();
            this.iptalet_pb = new System.Windows.Forms.PictureBox();
            this.duzenle_pb = new System.Windows.Forms.PictureBox();
            this.tc_masketb = new System.Windows.Forms.MaskedTextBox();
            this.adres_tb = new System.Windows.Forms.TextBox();
            this.adres_label = new System.Windows.Forms.Label();
            this.adres_pb = new System.Windows.Forms.PictureBox();
            this.uye_ol_menu = new System.Windows.Forms.MenuStrip();
            this.duzenle_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.yardim_toolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.mail_tb = new System.Windows.Forms.TextBox();
            this.mail_label = new System.Windows.Forms.Label();
            this.mail_pb = new System.Windows.Forms.PictureBox();
            this.ev_label = new System.Windows.Forms.Label();
            this.ev_pb = new System.Windows.Forms.PictureBox();
            this.cep_label = new System.Windows.Forms.Label();
            this.cep_pb = new System.Windows.Forms.PictureBox();
            this.dogum_tarihi_label = new System.Windows.Forms.Label();
            this.dogum_tarihi_pb = new System.Windows.Forms.PictureBox();
            this.dogum_yeri_tb = new System.Windows.Forms.TextBox();
            this.dogum_yeri_label = new System.Windows.Forms.Label();
            this.dogum_yeri_pb = new System.Windows.Forms.PictureBox();
            this.ilce_label = new System.Windows.Forms.Label();
            this.ilce_pb = new System.Windows.Forms.PictureBox();
            this.il_label = new System.Windows.Forms.Label();
            this.il_pb = new System.Windows.Forms.PictureBox();
            this.cinsiyet_label = new System.Windows.Forms.Label();
            this.cinsiyet_pb = new System.Windows.Forms.PictureBox();
            this.tc_pb = new System.Windows.Forms.PictureBox();
            this.profil_bilgileri_gb = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.degistir_cb = new System.Windows.Forms.CheckBox();
            this.fotograf_gb = new System.Windows.Forms.GroupBox();
            this.profil_fotografi_pb = new System.Windows.Forms.PictureBox();
            this.fotograf_yuke_label = new System.Windows.Forms.Label();
            this.profil_fotografi_combo = new System.Windows.Forms.ComboBox();
            this.soyad_tb = new System.Windows.Forms.TextBox();
            this.soyad_label = new System.Windows.Forms.Label();
            this.soyad_pb = new System.Windows.Forms.PictureBox();
            this.ad_tb = new System.Windows.Forms.TextBox();
            this.ad_label = new System.Windows.Forms.Label();
            this.tc_label = new System.Windows.Forms.Label();
            this.ad_pb = new System.Windows.Forms.PictureBox();
            this.sagtikmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.duzenle_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.yardim_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duzenle_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adres_pb)).BeginInit();
            this.uye_ol_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mail_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ev_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cep_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogum_tarihi_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogum_yeri_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilce_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.il_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinsiyet_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc_pb)).BeginInit();
            this.profil_bilgileri_gb.SuspendLayout();
            this.fotograf_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profil_fotografi_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soyad_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ad_pb)).BeginInit();
            this.sagtikmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ev_masketb
            // 
            this.ev_masketb.Location = new System.Drawing.Point(579, 60);
            this.ev_masketb.Mask = "(000) 000-0000";
            this.ev_masketb.Name = "ev_masketb";
            this.ev_masketb.Size = new System.Drawing.Size(167, 26);
            this.ev_masketb.TabIndex = 53;
            // 
            // zaman_datetime
            // 
            this.zaman_datetime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.zaman_datetime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.zaman_datetime.Location = new System.Drawing.Point(198, 347);
            this.zaman_datetime.MinDate = new System.DateTime(1976, 1, 1, 0, 0, 0, 0);
            this.zaman_datetime.Name = "zaman_datetime";
            this.zaman_datetime.Size = new System.Drawing.Size(167, 26);
            this.zaman_datetime.TabIndex = 52;
            // 
            // cep_masketb
            // 
            this.cep_masketb.Location = new System.Drawing.Point(579, 28);
            this.cep_masketb.Mask = "(000) 000-0000";
            this.cep_masketb.Name = "cep_masketb";
            this.cep_masketb.Size = new System.Drawing.Size(167, 26);
            this.cep_masketb.TabIndex = 51;
            // 
            // e_label
            // 
            this.e_label.AutoSize = true;
            this.e_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.e_label.Location = new System.Drawing.Point(575, 126);
            this.e_label.Name = "e_label";
            this.e_label.Size = new System.Drawing.Size(25, 23);
            this.e_label.TabIndex = 50;
            this.e_label.Text = "@";
            // 
            // mail_uzantisi_combo
            // 
            this.mail_uzantisi_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mail_uzantisi_combo.FormattingEnabled = true;
            this.mail_uzantisi_combo.Location = new System.Drawing.Point(604, 124);
            this.mail_uzantisi_combo.Name = "mail_uzantisi_combo";
            this.mail_uzantisi_combo.Size = new System.Drawing.Size(142, 26);
            this.mail_uzantisi_combo.TabIndex = 49;
            // 
            // ilce_combo
            // 
            this.ilce_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ilce_combo.FormattingEnabled = true;
            this.ilce_combo.Location = new System.Drawing.Point(198, 285);
            this.ilce_combo.Name = "ilce_combo";
            this.ilce_combo.Size = new System.Drawing.Size(167, 26);
            this.ilce_combo.TabIndex = 48;
            // 
            // il_combo
            // 
            this.il_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.il_combo.FormattingEnabled = true;
            this.il_combo.Location = new System.Drawing.Point(198, 253);
            this.il_combo.Name = "il_combo";
            this.il_combo.Size = new System.Drawing.Size(167, 26);
            this.il_combo.TabIndex = 47;
            this.il_combo.SelectedIndexChanged += new System.EventHandler(this.il_combo_SelectedIndexChanged);
            // 
            // kadin_cb
            // 
            this.kadin_cb.AutoSize = true;
            this.kadin_cb.Location = new System.Drawing.Point(305, 224);
            this.kadin_cb.Name = "kadin_cb";
            this.kadin_cb.Size = new System.Drawing.Size(60, 22);
            this.kadin_cb.TabIndex = 46;
            this.kadin_cb.TabStop = true;
            this.kadin_cb.Text = "Kadın";
            this.kadin_cb.UseVisualStyleBackColor = true;
            // 
            // erkek_cb
            // 
            this.erkek_cb.AutoSize = true;
            this.erkek_cb.Location = new System.Drawing.Point(198, 224);
            this.erkek_cb.Name = "erkek_cb";
            this.erkek_cb.Size = new System.Drawing.Size(61, 22);
            this.erkek_cb.TabIndex = 45;
            this.erkek_cb.TabStop = true;
            this.erkek_cb.Text = "Erkek";
            this.erkek_cb.UseVisualStyleBackColor = true;
            // 
            // iptalet_pb
            // 
            this.iptalet_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iptalet_pb.Location = new System.Drawing.Point(585, 342);
            this.iptalet_pb.Name = "iptalet_pb";
            this.iptalet_pb.Size = new System.Drawing.Size(78, 55);
            this.iptalet_pb.TabIndex = 32;
            this.iptalet_pb.TabStop = false;
            this.iptalet_pb.Click += new System.EventHandler(this.iptalet_pb_Click);
            this.iptalet_pb.MouseLeave += new System.EventHandler(this.iptalet_pb_MouseLeave);
            this.iptalet_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iptalet_pb_MouseMove);
            // 
            // duzenle_pb
            // 
            this.duzenle_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.duzenle_pb.Location = new System.Drawing.Point(669, 342);
            this.duzenle_pb.Name = "duzenle_pb";
            this.duzenle_pb.Size = new System.Drawing.Size(78, 55);
            this.duzenle_pb.TabIndex = 31;
            this.duzenle_pb.TabStop = false;
            this.duzenle_pb.Click += new System.EventHandler(this.duzenle_pb_Click);
            this.duzenle_pb.MouseLeave += new System.EventHandler(this.duzenle_pb_MouseLeave);
            this.duzenle_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.duzenle_pb_MouseMove);
            // 
            // tc_masketb
            // 
            this.tc_masketb.Location = new System.Drawing.Point(198, 124);
            this.tc_masketb.Mask = "00000000000";
            this.tc_masketb.Name = "tc_masketb";
            this.tc_masketb.ReadOnly = true;
            this.tc_masketb.Size = new System.Drawing.Size(146, 26);
            this.tc_masketb.TabIndex = 44;
            // 
            // adres_tb
            // 
            this.adres_tb.Location = new System.Drawing.Point(579, 156);
            this.adres_tb.Multiline = true;
            this.adres_tb.Name = "adres_tb";
            this.adres_tb.Size = new System.Drawing.Size(167, 102);
            this.adres_tb.TabIndex = 43;
            // 
            // adres_label
            // 
            this.adres_label.AutoSize = true;
            this.adres_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.adres_label.Location = new System.Drawing.Point(425, 157);
            this.adres_label.Name = "adres_label";
            this.adres_label.Size = new System.Drawing.Size(113, 23);
            this.adres_label.TabIndex = 42;
            this.adres_label.Text = "Ev Adresiniz:";
            // 
            // adres_pb
            // 
            this.adres_pb.Location = new System.Drawing.Point(387, 156);
            this.adres_pb.Name = "adres_pb";
            this.adres_pb.Size = new System.Drawing.Size(32, 24);
            this.adres_pb.TabIndex = 41;
            this.adres_pb.TabStop = false;
            // 
            // uye_ol_menu
            // 
            this.uye_ol_menu.BackColor = System.Drawing.SystemColors.Highlight;
            this.uye_ol_menu.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uye_ol_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duzenle_menu,
            this.iptal_et_menu,
            this.yardim_toolstrip});
            this.uye_ol_menu.Location = new System.Drawing.Point(0, 0);
            this.uye_ol_menu.Name = "uye_ol_menu";
            this.uye_ol_menu.Size = new System.Drawing.Size(782, 26);
            this.uye_ol_menu.TabIndex = 33;
            this.uye_ol_menu.Text = "menuStrip1";
            // 
            // duzenle_menu
            // 
            this.duzenle_menu.Name = "duzenle_menu";
            this.duzenle_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.duzenle_menu.Size = new System.Drawing.Size(170, 22);
            this.duzenle_menu.Text = "Profil Bilgilerini Düzenle";
            this.duzenle_menu.Click += new System.EventHandler(this.duzenle_pb_Click);
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
            // mail_tb
            // 
            this.mail_tb.Location = new System.Drawing.Point(579, 92);
            this.mail_tb.Name = "mail_tb";
            this.mail_tb.Size = new System.Drawing.Size(167, 26);
            this.mail_tb.TabIndex = 40;
            // 
            // mail_label
            // 
            this.mail_label.AutoSize = true;
            this.mail_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mail_label.Location = new System.Drawing.Point(425, 93);
            this.mail_label.Name = "mail_label";
            this.mail_label.Size = new System.Drawing.Size(157, 23);
            this.mail_label.TabIndex = 39;
            this.mail_label.Text = "E-Posta Adresiniz:";
            // 
            // mail_pb
            // 
            this.mail_pb.Location = new System.Drawing.Point(387, 92);
            this.mail_pb.Name = "mail_pb";
            this.mail_pb.Size = new System.Drawing.Size(32, 24);
            this.mail_pb.TabIndex = 38;
            this.mail_pb.TabStop = false;
            // 
            // ev_label
            // 
            this.ev_label.AutoSize = true;
            this.ev_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ev_label.Location = new System.Drawing.Point(425, 61);
            this.ev_label.Name = "ev_label";
            this.ev_label.Size = new System.Drawing.Size(132, 23);
            this.ev_label.TabIndex = 36;
            this.ev_label.Text = "Ev Telefonunuz:";
            // 
            // ev_pb
            // 
            this.ev_pb.Location = new System.Drawing.Point(387, 60);
            this.ev_pb.Name = "ev_pb";
            this.ev_pb.Size = new System.Drawing.Size(32, 24);
            this.ev_pb.TabIndex = 35;
            this.ev_pb.TabStop = false;
            // 
            // cep_label
            // 
            this.cep_label.AutoSize = true;
            this.cep_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cep_label.Location = new System.Drawing.Point(425, 29);
            this.cep_label.Name = "cep_label";
            this.cep_label.Size = new System.Drawing.Size(142, 23);
            this.cep_label.TabIndex = 33;
            this.cep_label.Text = "Cep Telefonunuz:";
            // 
            // cep_pb
            // 
            this.cep_pb.Location = new System.Drawing.Point(387, 28);
            this.cep_pb.Name = "cep_pb";
            this.cep_pb.Size = new System.Drawing.Size(32, 24);
            this.cep_pb.TabIndex = 32;
            this.cep_pb.TabStop = false;
            // 
            // dogum_tarihi_label
            // 
            this.dogum_tarihi_label.AutoSize = true;
            this.dogum_tarihi_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dogum_tarihi_label.Location = new System.Drawing.Point(44, 350);
            this.dogum_tarihi_label.Name = "dogum_tarihi_label";
            this.dogum_tarihi_label.Size = new System.Drawing.Size(139, 23);
            this.dogum_tarihi_label.TabIndex = 30;
            this.dogum_tarihi_label.Text = "Doğum Tarihiniz:";
            // 
            // dogum_tarihi_pb
            // 
            this.dogum_tarihi_pb.Location = new System.Drawing.Point(6, 349);
            this.dogum_tarihi_pb.Name = "dogum_tarihi_pb";
            this.dogum_tarihi_pb.Size = new System.Drawing.Size(32, 24);
            this.dogum_tarihi_pb.TabIndex = 29;
            this.dogum_tarihi_pb.TabStop = false;
            // 
            // dogum_yeri_tb
            // 
            this.dogum_yeri_tb.Location = new System.Drawing.Point(198, 317);
            this.dogum_yeri_tb.Name = "dogum_yeri_tb";
            this.dogum_yeri_tb.Size = new System.Drawing.Size(167, 26);
            this.dogum_yeri_tb.TabIndex = 28;
            // 
            // dogum_yeri_label
            // 
            this.dogum_yeri_label.AutoSize = true;
            this.dogum_yeri_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dogum_yeri_label.Location = new System.Drawing.Point(44, 318);
            this.dogum_yeri_label.Name = "dogum_yeri_label";
            this.dogum_yeri_label.Size = new System.Drawing.Size(125, 23);
            this.dogum_yeri_label.TabIndex = 27;
            this.dogum_yeri_label.Text = "Doğum Yeriniz:";
            // 
            // dogum_yeri_pb
            // 
            this.dogum_yeri_pb.Location = new System.Drawing.Point(6, 317);
            this.dogum_yeri_pb.Name = "dogum_yeri_pb";
            this.dogum_yeri_pb.Size = new System.Drawing.Size(32, 24);
            this.dogum_yeri_pb.TabIndex = 26;
            this.dogum_yeri_pb.TabStop = false;
            // 
            // ilce_label
            // 
            this.ilce_label.AutoSize = true;
            this.ilce_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ilce_label.Location = new System.Drawing.Point(44, 284);
            this.ilce_label.Name = "ilce_label";
            this.ilce_label.Size = new System.Drawing.Size(137, 23);
            this.ilce_label.TabIndex = 24;
            this.ilce_label.Text = "Yaşadığınız İlçe:";
            // 
            // ilce_pb
            // 
            this.ilce_pb.Location = new System.Drawing.Point(6, 283);
            this.ilce_pb.Name = "ilce_pb";
            this.ilce_pb.Size = new System.Drawing.Size(32, 24);
            this.ilce_pb.TabIndex = 23;
            this.ilce_pb.TabStop = false;
            // 
            // il_label
            // 
            this.il_label.AutoSize = true;
            this.il_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.il_label.Location = new System.Drawing.Point(44, 252);
            this.il_label.Name = "il_label";
            this.il_label.Size = new System.Drawing.Size(120, 23);
            this.il_label.TabIndex = 21;
            this.il_label.Text = "Yaşadığınız İl:";
            // 
            // il_pb
            // 
            this.il_pb.Location = new System.Drawing.Point(6, 251);
            this.il_pb.Name = "il_pb";
            this.il_pb.Size = new System.Drawing.Size(32, 24);
            this.il_pb.TabIndex = 20;
            this.il_pb.TabStop = false;
            // 
            // cinsiyet_label
            // 
            this.cinsiyet_label.AutoSize = true;
            this.cinsiyet_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cinsiyet_label.Location = new System.Drawing.Point(44, 219);
            this.cinsiyet_label.Name = "cinsiyet_label";
            this.cinsiyet_label.Size = new System.Drawing.Size(102, 23);
            this.cinsiyet_label.TabIndex = 18;
            this.cinsiyet_label.Text = "Cinsiyetiniz:";
            // 
            // cinsiyet_pb
            // 
            this.cinsiyet_pb.Location = new System.Drawing.Point(6, 218);
            this.cinsiyet_pb.Name = "cinsiyet_pb";
            this.cinsiyet_pb.Size = new System.Drawing.Size(32, 24);
            this.cinsiyet_pb.TabIndex = 17;
            this.cinsiyet_pb.TabStop = false;
            // 
            // tc_pb
            // 
            this.tc_pb.Location = new System.Drawing.Point(6, 121);
            this.tc_pb.Name = "tc_pb";
            this.tc_pb.Size = new System.Drawing.Size(32, 24);
            this.tc_pb.TabIndex = 11;
            this.tc_pb.TabStop = false;
            // 
            // profil_bilgileri_gb
            // 
            this.profil_bilgileri_gb.Controls.Add(this.label1);
            this.profil_bilgileri_gb.Controls.Add(this.degistir_cb);
            this.profil_bilgileri_gb.Controls.Add(this.fotograf_gb);
            this.profil_bilgileri_gb.Controls.Add(this.iptalet_pb);
            this.profil_bilgileri_gb.Controls.Add(this.duzenle_pb);
            this.profil_bilgileri_gb.Controls.Add(this.ev_masketb);
            this.profil_bilgileri_gb.Controls.Add(this.zaman_datetime);
            this.profil_bilgileri_gb.Controls.Add(this.cep_masketb);
            this.profil_bilgileri_gb.Controls.Add(this.e_label);
            this.profil_bilgileri_gb.Controls.Add(this.mail_uzantisi_combo);
            this.profil_bilgileri_gb.Controls.Add(this.ilce_combo);
            this.profil_bilgileri_gb.Controls.Add(this.il_combo);
            this.profil_bilgileri_gb.Controls.Add(this.kadin_cb);
            this.profil_bilgileri_gb.Controls.Add(this.erkek_cb);
            this.profil_bilgileri_gb.Controls.Add(this.tc_masketb);
            this.profil_bilgileri_gb.Controls.Add(this.adres_tb);
            this.profil_bilgileri_gb.Controls.Add(this.adres_label);
            this.profil_bilgileri_gb.Controls.Add(this.adres_pb);
            this.profil_bilgileri_gb.Controls.Add(this.mail_tb);
            this.profil_bilgileri_gb.Controls.Add(this.mail_label);
            this.profil_bilgileri_gb.Controls.Add(this.mail_pb);
            this.profil_bilgileri_gb.Controls.Add(this.ev_label);
            this.profil_bilgileri_gb.Controls.Add(this.ev_pb);
            this.profil_bilgileri_gb.Controls.Add(this.cep_label);
            this.profil_bilgileri_gb.Controls.Add(this.cep_pb);
            this.profil_bilgileri_gb.Controls.Add(this.dogum_tarihi_label);
            this.profil_bilgileri_gb.Controls.Add(this.dogum_tarihi_pb);
            this.profil_bilgileri_gb.Controls.Add(this.dogum_yeri_tb);
            this.profil_bilgileri_gb.Controls.Add(this.dogum_yeri_label);
            this.profil_bilgileri_gb.Controls.Add(this.dogum_yeri_pb);
            this.profil_bilgileri_gb.Controls.Add(this.ilce_label);
            this.profil_bilgileri_gb.Controls.Add(this.ilce_pb);
            this.profil_bilgileri_gb.Controls.Add(this.il_label);
            this.profil_bilgileri_gb.Controls.Add(this.il_pb);
            this.profil_bilgileri_gb.Controls.Add(this.cinsiyet_label);
            this.profil_bilgileri_gb.Controls.Add(this.cinsiyet_pb);
            this.profil_bilgileri_gb.Controls.Add(this.soyad_tb);
            this.profil_bilgileri_gb.Controls.Add(this.soyad_label);
            this.profil_bilgileri_gb.Controls.Add(this.soyad_pb);
            this.profil_bilgileri_gb.Controls.Add(this.ad_tb);
            this.profil_bilgileri_gb.Controls.Add(this.ad_label);
            this.profil_bilgileri_gb.Controls.Add(this.tc_pb);
            this.profil_bilgileri_gb.Controls.Add(this.tc_label);
            this.profil_bilgileri_gb.Controls.Add(this.ad_pb);
            this.profil_bilgileri_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.profil_bilgileri_gb.Location = new System.Drawing.Point(12, 29);
            this.profil_bilgileri_gb.Name = "profil_bilgileri_gb";
            this.profil_bilgileri_gb.Size = new System.Drawing.Size(760, 413);
            this.profil_bilgileri_gb.TabIndex = 27;
            this.profil_bilgileri_gb.TabStop = false;
            this.profil_bilgileri_gb.Text = "Profil Bilgileri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(540, 19);
            this.label1.TabIndex = 98;
            this.label1.Text = "BİLGİLENDİRME:DEĞİŞİKLİKLER TEKRAR OTURUM AÇILDIĞINDA AKTİF OLUR.";
            // 
            // degistir_cb
            // 
            this.degistir_cb.AutoSize = true;
            this.degistir_cb.Font = new System.Drawing.Font("Comic Sans MS", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.degistir_cb.Location = new System.Drawing.Point(350, 131);
            this.degistir_cb.Name = "degistir_cb";
            this.degistir_cb.Size = new System.Drawing.Size(15, 14);
            this.degistir_cb.TabIndex = 55;
            this.degistir_cb.UseVisualStyleBackColor = true;
            this.degistir_cb.CheckedChanged += new System.EventHandler(this.degistir_cb_CheckedChanged);
            // 
            // fotograf_gb
            // 
            this.fotograf_gb.Controls.Add(this.profil_fotografi_pb);
            this.fotograf_gb.Controls.Add(this.fotograf_yuke_label);
            this.fotograf_gb.Controls.Add(this.profil_fotografi_combo);
            this.fotograf_gb.Location = new System.Drawing.Point(6, 16);
            this.fotograf_gb.Name = "fotograf_gb";
            this.fotograf_gb.Size = new System.Drawing.Size(359, 99);
            this.fotograf_gb.TabIndex = 54;
            this.fotograf_gb.TabStop = false;
            this.fotograf_gb.Text = "Profil Fotoğrafını Değiştir";
            // 
            // profil_fotografi_pb
            // 
            this.profil_fotografi_pb.Cursor = System.Windows.Forms.Cursors.No;
            this.profil_fotografi_pb.Location = new System.Drawing.Point(6, 25);
            this.profil_fotografi_pb.Name = "profil_fotografi_pb";
            this.profil_fotografi_pb.Size = new System.Drawing.Size(78, 57);
            this.profil_fotografi_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
            this.profil_fotografi_pb.TabIndex = 50;
            this.profil_fotografi_pb.TabStop = false;
            // 
            // fotograf_yuke_label
            // 
            this.fotograf_yuke_label.AutoSize = true;
            this.fotograf_yuke_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fotograf_yuke_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fotograf_yuke_label.Location = new System.Drawing.Point(232, 54);
            this.fotograf_yuke_label.Name = "fotograf_yuke_label";
            this.fotograf_yuke_label.Size = new System.Drawing.Size(121, 23);
            this.fotograf_yuke_label.TabIndex = 52;
            this.fotograf_yuke_label.Text = "Fotoğraf Yükle";
            this.fotograf_yuke_label.Click += new System.EventHandler(this.fotograf_yuke_label_Click);
            this.fotograf_yuke_label.MouseLeave += new System.EventHandler(this.fotograf_yuke_label_MouseLeave);
            this.fotograf_yuke_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fotograf_yuke_label_MouseMove);
            // 
            // profil_fotografi_combo
            // 
            this.profil_fotografi_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profil_fotografi_combo.FormattingEnabled = true;
            this.profil_fotografi_combo.Location = new System.Drawing.Point(90, 25);
            this.profil_fotografi_combo.Name = "profil_fotografi_combo";
            this.profil_fotografi_combo.Size = new System.Drawing.Size(263, 26);
            this.profil_fotografi_combo.TabIndex = 51;
            this.profil_fotografi_combo.SelectedIndexChanged += new System.EventHandler(this.profil_fotografi_combo_SelectedIndexChanged);
            // 
            // soyad_tb
            // 
            this.soyad_tb.Location = new System.Drawing.Point(198, 188);
            this.soyad_tb.Name = "soyad_tb";
            this.soyad_tb.Size = new System.Drawing.Size(167, 26);
            this.soyad_tb.TabIndex = 16;
            // 
            // soyad_label
            // 
            this.soyad_label.AutoSize = true;
            this.soyad_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.soyad_label.Location = new System.Drawing.Point(44, 189);
            this.soyad_label.Name = "soyad_label";
            this.soyad_label.Size = new System.Drawing.Size(88, 23);
            this.soyad_label.TabIndex = 15;
            this.soyad_label.Text = "Soyadınız:";
            // 
            // soyad_pb
            // 
            this.soyad_pb.Location = new System.Drawing.Point(6, 188);
            this.soyad_pb.Name = "soyad_pb";
            this.soyad_pb.Size = new System.Drawing.Size(32, 24);
            this.soyad_pb.TabIndex = 14;
            this.soyad_pb.TabStop = false;
            // 
            // ad_tb
            // 
            this.ad_tb.Location = new System.Drawing.Point(198, 156);
            this.ad_tb.Name = "ad_tb";
            this.ad_tb.Size = new System.Drawing.Size(167, 26);
            this.ad_tb.TabIndex = 13;
            // 
            // ad_label
            // 
            this.ad_label.AutoSize = true;
            this.ad_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ad_label.Location = new System.Drawing.Point(44, 157);
            this.ad_label.Name = "ad_label";
            this.ad_label.Size = new System.Drawing.Size(63, 23);
            this.ad_label.TabIndex = 12;
            this.ad_label.Text = "Adınız:";
            // 
            // tc_label
            // 
            this.tc_label.AutoSize = true;
            this.tc_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tc_label.Location = new System.Drawing.Point(44, 122);
            this.tc_label.Name = "tc_label";
            this.tc_label.Size = new System.Drawing.Size(116, 23);
            this.tc_label.TabIndex = 9;
            this.tc_label.Text = "TC Kimlik No:";
            // 
            // ad_pb
            // 
            this.ad_pb.Location = new System.Drawing.Point(6, 156);
            this.ad_pb.Name = "ad_pb";
            this.ad_pb.Size = new System.Drawing.Size(32, 24);
            this.ad_pb.TabIndex = 8;
            this.ad_pb.TabStop = false;
            // 
            // sagtikmenu
            // 
            this.sagtikmenu.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sagtikmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duzenle_sagtik,
            this.iptal_et_sagtik,
            this.yardim_sagtik});
            this.sagtikmenu.Name = "sagtikmenu";
            this.sagtikmenu.Size = new System.Drawing.Size(227, 92);
            // 
            // duzenle_sagtik
            // 
            this.duzenle_sagtik.Name = "duzenle_sagtik";
            this.duzenle_sagtik.Size = new System.Drawing.Size(226, 22);
            this.duzenle_sagtik.Text = "Profil Bilgilerini Düzenle";
            this.duzenle_sagtik.Click += new System.EventHandler(this.duzenle_pb_Click);
            // 
            // iptal_et_sagtik
            // 
            this.iptal_et_sagtik.Name = "iptal_et_sagtik";
            this.iptal_et_sagtik.Size = new System.Drawing.Size(226, 22);
            this.iptal_et_sagtik.Text = "İptal Et";
            this.iptal_et_sagtik.Click += new System.EventHandler(this.iptalet_pb_Click);
            // 
            // yardim_sagtik
            // 
            this.yardim_sagtik.Name = "yardim_sagtik";
            this.yardim_sagtik.Size = new System.Drawing.Size(226, 22);
            this.yardim_sagtik.Text = "Yardım";
            this.yardim_sagtik.Click += new System.EventHandler(this.yardim_toolstrip_Click);
            // 
            // profil_bilgilerini_degistir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 452);
            this.ContextMenuStrip = this.sagtikmenu;
            this.Controls.Add(this.uye_ol_menu);
            this.Controls.Add(this.profil_bilgileri_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "profil_bilgilerini_degistir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profil Bilgilerini Düzenle";
            this.Load += new System.EventHandler(this.profil_bilgilerini_degistir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duzenle_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adres_pb)).EndInit();
            this.uye_ol_menu.ResumeLayout(false);
            this.uye_ol_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mail_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ev_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cep_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogum_tarihi_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogum_yeri_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilce_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.il_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinsiyet_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc_pb)).EndInit();
            this.profil_bilgileri_gb.ResumeLayout(false);
            this.profil_bilgileri_gb.PerformLayout();
            this.fotograf_gb.ResumeLayout(false);
            this.fotograf_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profil_fotografi_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soyad_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ad_pb)).EndInit();
            this.sagtikmenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox ev_masketb;
        private System.Windows.Forms.DateTimePicker zaman_datetime;
        private System.Windows.Forms.MaskedTextBox cep_masketb;
        private System.Windows.Forms.Label e_label;
        private System.Windows.Forms.ComboBox mail_uzantisi_combo;
        private System.Windows.Forms.ComboBox ilce_combo;
        private System.Windows.Forms.ComboBox il_combo;
        private System.Windows.Forms.RadioButton kadin_cb;
        private System.Windows.Forms.RadioButton erkek_cb;
        private System.Windows.Forms.PictureBox iptalet_pb;
        private System.Windows.Forms.PictureBox duzenle_pb;
        private System.Windows.Forms.MaskedTextBox tc_masketb;
        private System.Windows.Forms.TextBox adres_tb;
        private System.Windows.Forms.Label adres_label;
        private System.Windows.Forms.PictureBox adres_pb;
        private System.Windows.Forms.MenuStrip uye_ol_menu;
        private System.Windows.Forms.ToolStripMenuItem duzenle_menu;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_menu;
        private System.Windows.Forms.ToolStripMenuItem yardim_toolstrip;
        private System.Windows.Forms.TextBox mail_tb;
        private System.Windows.Forms.Label mail_label;
        private System.Windows.Forms.PictureBox mail_pb;
        private System.Windows.Forms.Label ev_label;
        private System.Windows.Forms.PictureBox ev_pb;
        private System.Windows.Forms.Label cep_label;
        private System.Windows.Forms.PictureBox cep_pb;
        private System.Windows.Forms.Label dogum_tarihi_label;
        private System.Windows.Forms.PictureBox dogum_tarihi_pb;
        private System.Windows.Forms.TextBox dogum_yeri_tb;
        private System.Windows.Forms.Label dogum_yeri_label;
        private System.Windows.Forms.PictureBox dogum_yeri_pb;
        private System.Windows.Forms.Label ilce_label;
        private System.Windows.Forms.PictureBox ilce_pb;
        private System.Windows.Forms.Label il_label;
        private System.Windows.Forms.PictureBox il_pb;
        private System.Windows.Forms.Label cinsiyet_label;
        private System.Windows.Forms.PictureBox cinsiyet_pb;
        private System.Windows.Forms.PictureBox tc_pb;
        private System.Windows.Forms.GroupBox profil_bilgileri_gb;
        private System.Windows.Forms.TextBox soyad_tb;
        private System.Windows.Forms.Label soyad_label;
        private System.Windows.Forms.PictureBox soyad_pb;
        private System.Windows.Forms.TextBox ad_tb;
        private System.Windows.Forms.Label ad_label;
        private System.Windows.Forms.Label tc_label;
        private System.Windows.Forms.PictureBox ad_pb;
        private System.Windows.Forms.Label fotograf_yuke_label;
        private System.Windows.Forms.ComboBox profil_fotografi_combo;
        private System.Windows.Forms.PictureBox profil_fotografi_pb;
        private System.Windows.Forms.GroupBox fotograf_gb;
        private System.Windows.Forms.CheckBox degistir_cb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip sagtikmenu;
        private System.Windows.Forms.ToolStripMenuItem duzenle_sagtik;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_sagtik;
        private System.Windows.Forms.ToolStripMenuItem yardim_sagtik;
    }
}