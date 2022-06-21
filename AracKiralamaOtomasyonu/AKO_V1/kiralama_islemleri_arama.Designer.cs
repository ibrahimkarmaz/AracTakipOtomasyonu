namespace WindowsFormsApplication1
{
    partial class kiralama_islemleri_arama
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kiralama_islemleri_arama));
            this.yardim_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.ilk_belirle_combo_sagtik = new System.Windows.Forms.ToolStripComboBox();
            this.listeleme_belirle_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.listeleme_islemleri_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.hepsini_listele_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.otomatik_arama_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.gelismis_arama_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.kiralayan_arama_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.sagtikmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yardim_toolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.hepsini_listele_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.ilk_belirle_combo = new System.Windows.Forms.ToolStripComboBox();
            this.listeleme_belirle_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.listeleme_islemleri_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.otomatik_arama_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.gelismis_arama_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.arama_islemleri_gb = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ilk_label = new System.Windows.Forms.Label();
            this.ilk_combo = new System.Windows.Forms.ComboBox();
            this.konu_combo = new System.Windows.Forms.ComboBox();
            this.ilk_pb = new System.Windows.Forms.PictureBox();
            this.tumunu_listele_pb = new System.Windows.Forms.PictureBox();
            this.arama_tb = new System.Windows.Forms.TextBox();
            this.otomatik_arama_cb = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.gelismis_arama_secenekleri_cb = new System.Windows.Forms.CheckBox();
            this.ara_pb = new System.Windows.Forms.PictureBox();
            this.konu_pb = new System.Windows.Forms.PictureBox();
            this.tablolari_listele_dgv = new System.Windows.Forms.DataGridView();
            this.kiralama_islemleri_arama_menu = new System.Windows.Forms.MenuStrip();
            this.kiralayan_arama_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.sagtikmenu.SuspendLayout();
            this.arama_islemleri_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ilk_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tumunu_listele_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ara_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.konu_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablolari_listele_dgv)).BeginInit();
            this.kiralama_islemleri_arama_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // yardim_sagtik
            // 
            this.yardim_sagtik.Name = "yardim_sagtik";
            this.yardim_sagtik.Size = new System.Drawing.Size(223, 22);
            this.yardim_sagtik.Text = "Yardım";
            this.yardim_sagtik.Click += new System.EventHandler(this.yardim_toolstrip_Click);
            // 
            // ilk_belirle_combo_sagtik
            // 
            this.ilk_belirle_combo_sagtik.Name = "ilk_belirle_combo_sagtik";
            this.ilk_belirle_combo_sagtik.Size = new System.Drawing.Size(121, 23);
            this.ilk_belirle_combo_sagtik.TextChanged += new System.EventHandler(this.ilk_belirle_combo_sagtik_TextChanged);
            // 
            // listeleme_belirle_sagtik
            // 
            this.listeleme_belirle_sagtik.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ilk_belirle_combo_sagtik});
            this.listeleme_belirle_sagtik.Name = "listeleme_belirle_sagtik";
            this.listeleme_belirle_sagtik.Size = new System.Drawing.Size(176, 22);
            this.listeleme_belirle_sagtik.Text = "Listeleme Belirle";
            // 
            // listeleme_islemleri_sagtik
            // 
            this.listeleme_islemleri_sagtik.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeleme_belirle_sagtik,
            this.hepsini_listele_sagtik});
            this.listeleme_islemleri_sagtik.Name = "listeleme_islemleri_sagtik";
            this.listeleme_islemleri_sagtik.Size = new System.Drawing.Size(223, 22);
            this.listeleme_islemleri_sagtik.Text = "Listeleme İşlemleri";
            // 
            // hepsini_listele_sagtik
            // 
            this.hepsini_listele_sagtik.Name = "hepsini_listele_sagtik";
            this.hepsini_listele_sagtik.Size = new System.Drawing.Size(176, 22);
            this.hepsini_listele_sagtik.Text = "Hepsini Listele";
            // 
            // otomatik_arama_sagtik
            // 
            this.otomatik_arama_sagtik.Name = "otomatik_arama_sagtik";
            this.otomatik_arama_sagtik.Size = new System.Drawing.Size(223, 22);
            this.otomatik_arama_sagtik.Text = "Otomatik Arama";
            // 
            // gelismis_arama_sagtik
            // 
            this.gelismis_arama_sagtik.Name = "gelismis_arama_sagtik";
            this.gelismis_arama_sagtik.Size = new System.Drawing.Size(223, 22);
            this.gelismis_arama_sagtik.Text = "Gelişmiş Arama";
            // 
            // iptal_et_sagtik
            // 
            this.iptal_et_sagtik.Name = "iptal_et_sagtik";
            this.iptal_et_sagtik.Size = new System.Drawing.Size(223, 22);
            this.iptal_et_sagtik.Text = "İptal Et";
            this.iptal_et_sagtik.Click += new System.EventHandler(this.iptal_et_menu_Click);
            // 
            // kiralayan_arama_sagtik
            // 
            this.kiralayan_arama_sagtik.Name = "kiralayan_arama_sagtik";
            this.kiralayan_arama_sagtik.Size = new System.Drawing.Size(223, 22);
            this.kiralayan_arama_sagtik.Text = "Kirala İşlemlerini Arama";
            this.kiralayan_arama_sagtik.Click += new System.EventHandler(this.ara_pb_Click);
            // 
            // sagtikmenu
            // 
            this.sagtikmenu.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sagtikmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kiralayan_arama_sagtik,
            this.iptal_et_sagtik,
            this.gelismis_arama_sagtik,
            this.otomatik_arama_sagtik,
            this.listeleme_islemleri_sagtik,
            this.yardim_sagtik});
            this.sagtikmenu.Name = "sagtikmenu";
            this.sagtikmenu.Size = new System.Drawing.Size(224, 158);
            // 
            // yardim_toolstrip
            // 
            this.yardim_toolstrip.Name = "yardim_toolstrip";
            this.yardim_toolstrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.yardim_toolstrip.Size = new System.Drawing.Size(63, 22);
            this.yardim_toolstrip.Text = "Yardım";
            this.yardim_toolstrip.Click += new System.EventHandler(this.yardim_toolstrip_Click);
            // 
            // hepsini_listele_menu
            // 
            this.hepsini_listele_menu.Name = "hepsini_listele_menu";
            this.hepsini_listele_menu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
            this.hepsini_listele_menu.ShowShortcutKeys = false;
            this.hepsini_listele_menu.Size = new System.Drawing.Size(168, 22);
            this.hepsini_listele_menu.Text = "Hepsini Listele";
            this.hepsini_listele_menu.Click += new System.EventHandler(this.tumunu_listele_pb_Click);
            // 
            // ilk_belirle_combo
            // 
            this.ilk_belirle_combo.Name = "ilk_belirle_combo";
            this.ilk_belirle_combo.Size = new System.Drawing.Size(121, 23);
            this.ilk_belirle_combo.TextChanged += new System.EventHandler(this.ilk_belirle_combo_TextChanged);
            // 
            // listeleme_belirle_menu
            // 
            this.listeleme_belirle_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ilk_belirle_combo});
            this.listeleme_belirle_menu.Name = "listeleme_belirle_menu";
            this.listeleme_belirle_menu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.listeleme_belirle_menu.ShowShortcutKeys = false;
            this.listeleme_belirle_menu.Size = new System.Drawing.Size(168, 22);
            this.listeleme_belirle_menu.Text = "Listeleme Belirle";
            // 
            // listeleme_islemleri_menu
            // 
            this.listeleme_islemleri_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeleme_belirle_menu,
            this.hepsini_listele_menu});
            this.listeleme_islemleri_menu.Name = "listeleme_islemleri_menu";
            this.listeleme_islemleri_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.listeleme_islemleri_menu.Size = new System.Drawing.Size(134, 22);
            this.listeleme_islemleri_menu.Text = "Listeleme İşlemleri";
            // 
            // otomatik_arama_menu
            // 
            this.otomatik_arama_menu.Name = "otomatik_arama_menu";
            this.otomatik_arama_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.otomatik_arama_menu.Size = new System.Drawing.Size(116, 22);
            this.otomatik_arama_menu.Text = "Otomatik Arama";
            this.otomatik_arama_menu.Click += new System.EventHandler(this.otomatik_arama_menu_Click);
            // 
            // gelismis_arama_menu
            // 
            this.gelismis_arama_menu.Checked = true;
            this.gelismis_arama_menu.CheckOnClick = true;
            this.gelismis_arama_menu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gelismis_arama_menu.Name = "gelismis_arama_menu";
            this.gelismis_arama_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.gelismis_arama_menu.Size = new System.Drawing.Size(111, 22);
            this.gelismis_arama_menu.Text = "Gelişmiş Arama";
            this.gelismis_arama_menu.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.gelismis_arama_menu.Click += new System.EventHandler(this.gelismis_arama_menu_Click);
            // 
            // iptal_et_menu
            // 
            this.iptal_et_menu.Name = "iptal_et_menu";
            this.iptal_et_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.iptal_et_menu.Size = new System.Drawing.Size(67, 22);
            this.iptal_et_menu.Text = "İptal Et";
            this.iptal_et_menu.Click += new System.EventHandler(this.iptal_et_menu_Click);
            // 
            // arama_islemleri_gb
            // 
            this.arama_islemleri_gb.Controls.Add(this.label1);
            this.arama_islemleri_gb.Controls.Add(this.ilk_label);
            this.arama_islemleri_gb.Controls.Add(this.ilk_combo);
            this.arama_islemleri_gb.Controls.Add(this.konu_combo);
            this.arama_islemleri_gb.Controls.Add(this.ilk_pb);
            this.arama_islemleri_gb.Controls.Add(this.tumunu_listele_pb);
            this.arama_islemleri_gb.Controls.Add(this.arama_tb);
            this.arama_islemleri_gb.Controls.Add(this.otomatik_arama_cb);
            this.arama_islemleri_gb.Controls.Add(this.checkBox2);
            this.arama_islemleri_gb.Controls.Add(this.gelismis_arama_secenekleri_cb);
            this.arama_islemleri_gb.Controls.Add(this.ara_pb);
            this.arama_islemleri_gb.Controls.Add(this.konu_pb);
            this.arama_islemleri_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.arama_islemleri_gb.Location = new System.Drawing.Point(12, 29);
            this.arama_islemleri_gb.Name = "arama_islemleri_gb";
            this.arama_islemleri_gb.Size = new System.Drawing.Size(783, 84);
            this.arama_islemleri_gb.TabIndex = 32;
            this.arama_islemleri_gb.TabStop = false;
            this.arama_islemleri_gb.Text = "Arama ve Listeleme İşlemleri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(460, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 18);
            this.label1.TabIndex = 66;
            this.label1.Text = "Listeleme Arama İşlemine bağlıdır.";
            // 
            // ilk_label
            // 
            this.ilk_label.AutoSize = true;
            this.ilk_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ilk_label.Location = new System.Drawing.Point(501, 28);
            this.ilk_label.Name = "ilk_label";
            this.ilk_label.Size = new System.Drawing.Size(46, 23);
            this.ilk_label.TabIndex = 65;
            this.ilk_label.Text = "İlk :";
            // 
            // ilk_combo
            // 
            this.ilk_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ilk_combo.FormattingEnabled = true;
            this.ilk_combo.Location = new System.Drawing.Point(553, 25);
            this.ilk_combo.Name = "ilk_combo";
            this.ilk_combo.Size = new System.Drawing.Size(123, 26);
            this.ilk_combo.TabIndex = 64;
            this.ilk_combo.SelectedIndexChanged += new System.EventHandler(this.ilk_combo_SelectedIndexChanged);
            // 
            // konu_combo
            // 
            this.konu_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.konu_combo.FormattingEnabled = true;
            this.konu_combo.Location = new System.Drawing.Point(44, 25);
            this.konu_combo.Name = "konu_combo";
            this.konu_combo.Size = new System.Drawing.Size(204, 26);
            this.konu_combo.TabIndex = 63;
            this.konu_combo.SelectedIndexChanged += new System.EventHandler(this.konu_combo_SelectedIndexChanged);
            // 
            // ilk_pb
            // 
            this.ilk_pb.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ilk_pb.Location = new System.Drawing.Point(460, 25);
            this.ilk_pb.Name = "ilk_pb";
            this.ilk_pb.Size = new System.Drawing.Size(32, 27);
            this.ilk_pb.TabIndex = 62;
            this.ilk_pb.TabStop = false;
            // 
            // tumunu_listele_pb
            // 
            this.tumunu_listele_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tumunu_listele_pb.Location = new System.Drawing.Point(699, 19);
            this.tumunu_listele_pb.Name = "tumunu_listele_pb";
            this.tumunu_listele_pb.Size = new System.Drawing.Size(78, 55);
            this.tumunu_listele_pb.TabIndex = 62;
            this.tumunu_listele_pb.TabStop = false;
            this.tumunu_listele_pb.Click += new System.EventHandler(this.tumunu_listele_pb_Click);
            this.tumunu_listele_pb.MouseLeave += new System.EventHandler(this.tumunu_listele_pb_MouseLeave);
            this.tumunu_listele_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tumunu_listele_pb_MouseMove);
            // 
            // arama_tb
            // 
            this.arama_tb.Location = new System.Drawing.Point(254, 24);
            this.arama_tb.Name = "arama_tb";
            this.arama_tb.Size = new System.Drawing.Size(141, 26);
            this.arama_tb.TabIndex = 61;
            this.arama_tb.TextChanged += new System.EventHandler(this.arama_tb_TextChanged);
            // 
            // otomatik_arama_cb
            // 
            this.otomatik_arama_cb.AutoSize = true;
            this.otomatik_arama_cb.Location = new System.Drawing.Point(254, 56);
            this.otomatik_arama_cb.Name = "otomatik_arama_cb";
            this.otomatik_arama_cb.Size = new System.Drawing.Size(123, 22);
            this.otomatik_arama_cb.TabIndex = 60;
            this.otomatik_arama_cb.Text = "Otomatik Arama";
            this.otomatik_arama_cb.UseVisualStyleBackColor = true;
            this.otomatik_arama_cb.CheckedChanged += new System.EventHandler(this.otomatik_arama_cb_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(254, 55);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(91, 22);
            this.checkBox2.TabIndex = 60;
            this.checkBox2.Text = "checkBox1";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // gelismis_arama_secenekleri_cb
            // 
            this.gelismis_arama_secenekleri_cb.AutoSize = true;
            this.gelismis_arama_secenekleri_cb.Location = new System.Drawing.Point(44, 56);
            this.gelismis_arama_secenekleri_cb.Name = "gelismis_arama_secenekleri_cb";
            this.gelismis_arama_secenekleri_cb.Size = new System.Drawing.Size(118, 22);
            this.gelismis_arama_secenekleri_cb.TabIndex = 60;
            this.gelismis_arama_secenekleri_cb.Text = "Gelişmiş Arama";
            this.gelismis_arama_secenekleri_cb.UseVisualStyleBackColor = true;
            this.gelismis_arama_secenekleri_cb.CheckedChanged += new System.EventHandler(this.gelismis_arama_secenekleri_cb_CheckedChanged_1);
            // 
            // ara_pb
            // 
            this.ara_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ara_pb.Location = new System.Drawing.Point(401, 24);
            this.ara_pb.Name = "ara_pb";
            this.ara_pb.Size = new System.Drawing.Size(32, 27);
            this.ara_pb.TabIndex = 58;
            this.ara_pb.TabStop = false;
            this.ara_pb.Click += new System.EventHandler(this.ara_pb_Click);
            // 
            // konu_pb
            // 
            this.konu_pb.Location = new System.Drawing.Point(6, 25);
            this.konu_pb.Name = "konu_pb";
            this.konu_pb.Size = new System.Drawing.Size(32, 24);
            this.konu_pb.TabIndex = 56;
            this.konu_pb.TabStop = false;
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
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablolari_listele_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.tablolari_listele_dgv.Location = new System.Drawing.Point(12, 119);
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
            this.tablolari_listele_dgv.Size = new System.Drawing.Size(783, 323);
            this.tablolari_listele_dgv.TabIndex = 31;
            // 
            // kiralama_islemleri_arama_menu
            // 
            this.kiralama_islemleri_arama_menu.BackColor = System.Drawing.SystemColors.Highlight;
            this.kiralama_islemleri_arama_menu.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kiralama_islemleri_arama_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kiralayan_arama_menu,
            this.iptal_et_menu,
            this.gelismis_arama_menu,
            this.otomatik_arama_menu,
            this.listeleme_islemleri_menu,
            this.yardim_toolstrip});
            this.kiralama_islemleri_arama_menu.Location = new System.Drawing.Point(0, 0);
            this.kiralama_islemleri_arama_menu.Name = "kiralama_islemleri_arama_menu";
            this.kiralama_islemleri_arama_menu.Size = new System.Drawing.Size(809, 26);
            this.kiralama_islemleri_arama_menu.TabIndex = 33;
            this.kiralama_islemleri_arama_menu.Text = "menuStrip1";
            // 
            // kiralayan_arama_menu
            // 
            this.kiralayan_arama_menu.Name = "kiralayan_arama_menu";
            this.kiralayan_arama_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.kiralayan_arama_menu.Size = new System.Drawing.Size(167, 22);
            this.kiralayan_arama_menu.Text = "Kirala İşlemlerini Arama";
            this.kiralayan_arama_menu.Click += new System.EventHandler(this.ara_pb_Click);
            // 
            // kiralama_islemleri_arama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 456);
            this.ContextMenuStrip = this.sagtikmenu;
            this.Controls.Add(this.arama_islemleri_gb);
            this.Controls.Add(this.tablolari_listele_dgv);
            this.Controls.Add(this.kiralama_islemleri_arama_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "kiralama_islemleri_arama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiralama İşlemleri Arama";
            this.Load += new System.EventHandler(this.kiralama_islemleri_arama_Load);
            this.sagtikmenu.ResumeLayout(false);
            this.arama_islemleri_gb.ResumeLayout(false);
            this.arama_islemleri_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ilk_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tumunu_listele_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ara_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.konu_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablolari_listele_dgv)).EndInit();
            this.kiralama_islemleri_arama_menu.ResumeLayout(false);
            this.kiralama_islemleri_arama_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem yardim_sagtik;
        private System.Windows.Forms.ToolStripComboBox ilk_belirle_combo_sagtik;
        private System.Windows.Forms.ToolStripMenuItem listeleme_belirle_sagtik;
        private System.Windows.Forms.ToolStripMenuItem listeleme_islemleri_sagtik;
        private System.Windows.Forms.ToolStripMenuItem hepsini_listele_sagtik;
        private System.Windows.Forms.ToolStripMenuItem otomatik_arama_sagtik;
        private System.Windows.Forms.ToolStripMenuItem gelismis_arama_sagtik;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_sagtik;
        private System.Windows.Forms.ToolStripMenuItem kiralayan_arama_sagtik;
        private System.Windows.Forms.ContextMenuStrip sagtikmenu;
        private System.Windows.Forms.ToolStripMenuItem yardim_toolstrip;
        private System.Windows.Forms.ToolStripMenuItem hepsini_listele_menu;
        private System.Windows.Forms.ToolStripComboBox ilk_belirle_combo;
        private System.Windows.Forms.ToolStripMenuItem listeleme_belirle_menu;
        private System.Windows.Forms.ToolStripMenuItem listeleme_islemleri_menu;
        private System.Windows.Forms.ToolStripMenuItem otomatik_arama_menu;
        private System.Windows.Forms.ToolStripMenuItem gelismis_arama_menu;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_menu;
        private System.Windows.Forms.GroupBox arama_islemleri_gb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ilk_label;
        private System.Windows.Forms.ComboBox ilk_combo;
        private System.Windows.Forms.ComboBox konu_combo;
        private System.Windows.Forms.PictureBox ilk_pb;
        private System.Windows.Forms.PictureBox tumunu_listele_pb;
        private System.Windows.Forms.TextBox arama_tb;
        private System.Windows.Forms.CheckBox otomatik_arama_cb;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox gelismis_arama_secenekleri_cb;
        private System.Windows.Forms.PictureBox ara_pb;
        private System.Windows.Forms.PictureBox konu_pb;
        private System.Windows.Forms.DataGridView tablolari_listele_dgv;
        private System.Windows.Forms.MenuStrip kiralama_islemleri_arama_menu;
        private System.Windows.Forms.ToolStripMenuItem kiralayan_arama_menu;
    }
}