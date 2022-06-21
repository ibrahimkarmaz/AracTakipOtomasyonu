namespace WindowsFormsApplication1
{
    partial class musteri_cikar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(musteri_cikar));
            this.yardim_toolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.acik_alt_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.musteri_bilgileri_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.kapali_alt_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.musteri_cıkar_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.arac_menu = new System.Windows.Forms.MenuStrip();
            this.yardim_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.kapali_alt_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.acik_alt_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.musteri_bilgileri_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.musteri_cikar_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.sagtikmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iptalet_pb = new System.Windows.Forms.PictureBox();
            this.musteri_cikar_pb = new System.Windows.Forms.PictureBox();
            this.musteri_hakkinda_bilgi_pb2 = new System.Windows.Forms.PictureBox();
            this.bilgi_label = new System.Windows.Forms.Label();
            this.musteri_hakkinda_bilgi_pb = new System.Windows.Forms.PictureBox();
            this.musteri_hakkinda_bilgi_label = new System.Windows.Forms.Label();
            this.tc_pb = new System.Windows.Forms.PictureBox();
            this.tc_combo = new System.Windows.Forms.ComboBox();
            this.tc_label = new System.Windows.Forms.Label();
            this.arac_cikar_gb = new System.Windows.Forms.GroupBox();
            this.arac_menu.SuspendLayout();
            this.sagtikmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteri_cikar_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteri_hakkinda_bilgi_pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteri_hakkinda_bilgi_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc_pb)).BeginInit();
            this.arac_cikar_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // yardim_toolstrip
            // 
            this.yardim_toolstrip.Name = "yardim_toolstrip";
            this.yardim_toolstrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.yardim_toolstrip.Size = new System.Drawing.Size(63, 22);
            this.yardim_toolstrip.Text = "Yardım";
            this.yardim_toolstrip.Click += new System.EventHandler(this.yardim_toolstrip_Click);
            // 
            // acik_alt_menu
            // 
            this.acik_alt_menu.Name = "acik_alt_menu";
            this.acik_alt_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.acik_alt_menu.ShowShortcutKeys = false;
            this.acik_alt_menu.Size = new System.Drawing.Size(102, 22);
            this.acik_alt_menu.Text = "Aç";
            this.acik_alt_menu.Click += new System.EventHandler(this.musteri_hakkinda_bilgi_label_Click);
            // 
            // musteri_bilgileri_menu
            // 
            this.musteri_bilgileri_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acik_alt_menu,
            this.kapali_alt_menu});
            this.musteri_bilgileri_menu.Name = "musteri_bilgileri_menu";
            this.musteri_bilgileri_menu.Size = new System.Drawing.Size(107, 22);
            this.musteri_bilgileri_menu.Text = "Müşteri Bilgisi";
            // 
            // kapali_alt_menu
            // 
            this.kapali_alt_menu.Name = "kapali_alt_menu";
            this.kapali_alt_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.kapali_alt_menu.ShowShortcutKeys = false;
            this.kapali_alt_menu.Size = new System.Drawing.Size(102, 22);
            this.kapali_alt_menu.Text = "Kapat";
            this.kapali_alt_menu.Click += new System.EventHandler(this.musteri_hakkinda_bilgi_label_Click);
            // 
            // iptal_et_menu
            // 
            this.iptal_et_menu.Name = "iptal_et_menu";
            this.iptal_et_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.iptal_et_menu.Size = new System.Drawing.Size(67, 22);
            this.iptal_et_menu.Text = "İptal Et";
            this.iptal_et_menu.Click += new System.EventHandler(this.iptalet_pb_Click);
            // 
            // musteri_cıkar_menu
            // 
            this.musteri_cıkar_menu.Name = "musteri_cıkar_menu";
            this.musteri_cıkar_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.musteri_cıkar_menu.Size = new System.Drawing.Size(102, 22);
            this.musteri_cıkar_menu.Text = "Müşteri Çıkar";
            this.musteri_cıkar_menu.Click += new System.EventHandler(this.musteri_cikar_pb_Click);
            // 
            // arac_menu
            // 
            this.arac_menu.BackColor = System.Drawing.SystemColors.Highlight;
            this.arac_menu.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.arac_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musteri_cıkar_menu,
            this.iptal_et_menu,
            this.musteri_bilgileri_menu,
            this.yardim_toolstrip});
            this.arac_menu.Location = new System.Drawing.Point(0, 0);
            this.arac_menu.Name = "arac_menu";
            this.arac_menu.Size = new System.Drawing.Size(414, 26);
            this.arac_menu.TabIndex = 92;
            this.arac_menu.Text = "menuStrip1";
            // 
            // yardim_sagtik
            // 
            this.yardim_sagtik.Name = "yardim_sagtik";
            this.yardim_sagtik.Size = new System.Drawing.Size(163, 22);
            this.yardim_sagtik.Text = "Yardım";
            this.yardim_sagtik.Click += new System.EventHandler(this.yardim_toolstrip_Click);
            // 
            // kapali_alt_sagtik
            // 
            this.kapali_alt_sagtik.Name = "kapali_alt_sagtik";
            this.kapali_alt_sagtik.Size = new System.Drawing.Size(110, 22);
            this.kapali_alt_sagtik.Text = "Kapat";
            this.kapali_alt_sagtik.Click += new System.EventHandler(this.musteri_hakkinda_bilgi_label_Click);
            // 
            // acik_alt_sagtik
            // 
            this.acik_alt_sagtik.Name = "acik_alt_sagtik";
            this.acik_alt_sagtik.Size = new System.Drawing.Size(110, 22);
            this.acik_alt_sagtik.Text = "Aç";
            this.acik_alt_sagtik.Click += new System.EventHandler(this.musteri_hakkinda_bilgi_label_Click);
            // 
            // musteri_bilgileri_sagtik
            // 
            this.musteri_bilgileri_sagtik.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acik_alt_sagtik,
            this.kapali_alt_sagtik});
            this.musteri_bilgileri_sagtik.Name = "musteri_bilgileri_sagtik";
            this.musteri_bilgileri_sagtik.Size = new System.Drawing.Size(163, 22);
            this.musteri_bilgileri_sagtik.Text = "Müşteri Bilgisi";
            // 
            // iptal_et_sagtik
            // 
            this.iptal_et_sagtik.Name = "iptal_et_sagtik";
            this.iptal_et_sagtik.Size = new System.Drawing.Size(163, 22);
            this.iptal_et_sagtik.Text = "İptal Et";
            this.iptal_et_sagtik.Click += new System.EventHandler(this.iptalet_pb_Click);
            // 
            // musteri_cikar_sagtik
            // 
            this.musteri_cikar_sagtik.Name = "musteri_cikar_sagtik";
            this.musteri_cikar_sagtik.Size = new System.Drawing.Size(163, 22);
            this.musteri_cikar_sagtik.Text = "Müşteri Çıkar";
            this.musteri_cikar_sagtik.Click += new System.EventHandler(this.musteri_cikar_pb_Click);
            // 
            // sagtikmenu
            // 
            this.sagtikmenu.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sagtikmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musteri_cikar_sagtik,
            this.iptal_et_sagtik,
            this.musteri_bilgileri_sagtik,
            this.yardim_sagtik});
            this.sagtikmenu.Name = "sagtikmenu";
            this.sagtikmenu.Size = new System.Drawing.Size(164, 92);
            // 
            // iptalet_pb
            // 
            this.iptalet_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iptalet_pb.Location = new System.Drawing.Point(234, 422);
            this.iptalet_pb.Name = "iptalet_pb";
            this.iptalet_pb.Size = new System.Drawing.Size(78, 55);
            this.iptalet_pb.TabIndex = 91;
            this.iptalet_pb.TabStop = false;
            this.iptalet_pb.Click += new System.EventHandler(this.iptalet_pb_Click);
            this.iptalet_pb.MouseLeave += new System.EventHandler(this.iptalet_pb_MouseLeave);
            this.iptalet_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iptalet_pb_MouseMove);
            // 
            // musteri_cikar_pb
            // 
            this.musteri_cikar_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.musteri_cikar_pb.Location = new System.Drawing.Point(318, 422);
            this.musteri_cikar_pb.Name = "musteri_cikar_pb";
            this.musteri_cikar_pb.Size = new System.Drawing.Size(78, 55);
            this.musteri_cikar_pb.TabIndex = 90;
            this.musteri_cikar_pb.TabStop = false;
            this.musteri_cikar_pb.Click += new System.EventHandler(this.musteri_cikar_pb_Click);
            this.musteri_cikar_pb.MouseLeave += new System.EventHandler(this.musteri_cikar_pb_MouseLeave);
            this.musteri_cikar_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.musteri_cikar_pb_MouseMove);
            // 
            // musteri_hakkinda_bilgi_pb2
            // 
            this.musteri_hakkinda_bilgi_pb2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.musteri_hakkinda_bilgi_pb2.Location = new System.Drawing.Point(352, 65);
            this.musteri_hakkinda_bilgi_pb2.Name = "musteri_hakkinda_bilgi_pb2";
            this.musteri_hakkinda_bilgi_pb2.Size = new System.Drawing.Size(32, 24);
            this.musteri_hakkinda_bilgi_pb2.TabIndex = 87;
            this.musteri_hakkinda_bilgi_pb2.TabStop = false;
            this.musteri_hakkinda_bilgi_pb2.Click += new System.EventHandler(this.musteri_hakkinda_bilgi_label_Click);
            this.musteri_hakkinda_bilgi_pb2.MouseLeave += new System.EventHandler(this.musteri_hakkinda_bilgi_label_MouseLeave);
            this.musteri_hakkinda_bilgi_pb2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.musteri_hakkinda_bilgi_label_MouseMove);
            // 
            // bilgi_label
            // 
            this.bilgi_label.AutoSize = true;
            this.bilgi_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bilgi_label.Location = new System.Drawing.Point(6, 92);
            this.bilgi_label.Name = "bilgi_label";
            this.bilgi_label.Size = new System.Drawing.Size(35, 18);
            this.bilgi_label.TabIndex = 86;
            this.bilgi_label.Text = "bilgi";
            // 
            // musteri_hakkinda_bilgi_pb
            // 
            this.musteri_hakkinda_bilgi_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.musteri_hakkinda_bilgi_pb.Location = new System.Drawing.Point(6, 65);
            this.musteri_hakkinda_bilgi_pb.Name = "musteri_hakkinda_bilgi_pb";
            this.musteri_hakkinda_bilgi_pb.Size = new System.Drawing.Size(32, 24);
            this.musteri_hakkinda_bilgi_pb.TabIndex = 84;
            this.musteri_hakkinda_bilgi_pb.TabStop = false;
            this.musteri_hakkinda_bilgi_pb.Click += new System.EventHandler(this.musteri_hakkinda_bilgi_label_Click);
            this.musteri_hakkinda_bilgi_pb.MouseLeave += new System.EventHandler(this.musteri_hakkinda_bilgi_label_MouseLeave);
            this.musteri_hakkinda_bilgi_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.musteri_hakkinda_bilgi_label_MouseMove);
            // 
            // musteri_hakkinda_bilgi_label
            // 
            this.musteri_hakkinda_bilgi_label.AutoSize = true;
            this.musteri_hakkinda_bilgi_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.musteri_hakkinda_bilgi_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.musteri_hakkinda_bilgi_label.Location = new System.Drawing.Point(82, 64);
            this.musteri_hakkinda_bilgi_label.Name = "musteri_hakkinda_bilgi_label";
            this.musteri_hakkinda_bilgi_label.Size = new System.Drawing.Size(228, 23);
            this.musteri_hakkinda_bilgi_label.TabIndex = 85;
            this.musteri_hakkinda_bilgi_label.Text = "Müşteri Hakkında Bilgi[Açık]";
            this.musteri_hakkinda_bilgi_label.Click += new System.EventHandler(this.musteri_hakkinda_bilgi_label_Click);
            this.musteri_hakkinda_bilgi_label.MouseLeave += new System.EventHandler(this.musteri_hakkinda_bilgi_label_MouseLeave);
            this.musteri_hakkinda_bilgi_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.musteri_hakkinda_bilgi_label_MouseMove);
            // 
            // tc_pb
            // 
            this.tc_pb.Location = new System.Drawing.Point(6, 25);
            this.tc_pb.Name = "tc_pb";
            this.tc_pb.Size = new System.Drawing.Size(32, 24);
            this.tc_pb.TabIndex = 81;
            this.tc_pb.TabStop = false;
            // 
            // tc_combo
            // 
            this.tc_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tc_combo.FormattingEnabled = true;
            this.tc_combo.Location = new System.Drawing.Point(206, 27);
            this.tc_combo.Name = "tc_combo";
            this.tc_combo.Size = new System.Drawing.Size(178, 26);
            this.tc_combo.TabIndex = 83;
            this.tc_combo.SelectedIndexChanged += new System.EventHandler(this.tc_combo_SelectedIndexChanged);
            // 
            // tc_label
            // 
            this.tc_label.AutoSize = true;
            this.tc_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tc_label.Location = new System.Drawing.Point(44, 26);
            this.tc_label.Name = "tc_label";
            this.tc_label.Size = new System.Drawing.Size(126, 23);
            this.tc_label.TabIndex = 82;
            this.tc_label.Text = "TC No Seçiniz:";
            // 
            // arac_cikar_gb
            // 
            this.arac_cikar_gb.Controls.Add(this.musteri_hakkinda_bilgi_pb2);
            this.arac_cikar_gb.Controls.Add(this.bilgi_label);
            this.arac_cikar_gb.Controls.Add(this.musteri_hakkinda_bilgi_pb);
            this.arac_cikar_gb.Controls.Add(this.musteri_hakkinda_bilgi_label);
            this.arac_cikar_gb.Controls.Add(this.tc_pb);
            this.arac_cikar_gb.Controls.Add(this.tc_combo);
            this.arac_cikar_gb.Controls.Add(this.tc_label);
            this.arac_cikar_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.arac_cikar_gb.Location = new System.Drawing.Point(12, 29);
            this.arac_cikar_gb.Name = "arac_cikar_gb";
            this.arac_cikar_gb.Size = new System.Drawing.Size(390, 382);
            this.arac_cikar_gb.TabIndex = 89;
            this.arac_cikar_gb.TabStop = false;
            this.arac_cikar_gb.Text = "Araç Çıkar";
            // 
            // musteri_cikar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 489);
            this.ContextMenuStrip = this.sagtikmenu;
            this.Controls.Add(this.arac_menu);
            this.Controls.Add(this.iptalet_pb);
            this.Controls.Add(this.musteri_cikar_pb);
            this.Controls.Add(this.arac_cikar_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "musteri_cikar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Çıkar";
            this.Load += new System.EventHandler(this.musteri_cikar_Load);
            this.arac_menu.ResumeLayout(false);
            this.arac_menu.PerformLayout();
            this.sagtikmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteri_cikar_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteri_hakkinda_bilgi_pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteri_hakkinda_bilgi_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc_pb)).EndInit();
            this.arac_cikar_gb.ResumeLayout(false);
            this.arac_cikar_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem yardim_toolstrip;
        private System.Windows.Forms.ToolStripMenuItem acik_alt_menu;
        private System.Windows.Forms.ToolStripMenuItem musteri_bilgileri_menu;
        private System.Windows.Forms.ToolStripMenuItem kapali_alt_menu;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_menu;
        private System.Windows.Forms.ToolStripMenuItem musteri_cıkar_menu;
        private System.Windows.Forms.MenuStrip arac_menu;
        private System.Windows.Forms.ToolStripMenuItem yardim_sagtik;
        private System.Windows.Forms.ToolStripMenuItem kapali_alt_sagtik;
        private System.Windows.Forms.ToolStripMenuItem acik_alt_sagtik;
        private System.Windows.Forms.ToolStripMenuItem musteri_bilgileri_sagtik;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_sagtik;
        private System.Windows.Forms.ToolStripMenuItem musteri_cikar_sagtik;
        private System.Windows.Forms.ContextMenuStrip sagtikmenu;
        private System.Windows.Forms.PictureBox iptalet_pb;
        private System.Windows.Forms.PictureBox musteri_cikar_pb;
        private System.Windows.Forms.PictureBox musteri_hakkinda_bilgi_pb2;
        private System.Windows.Forms.Label bilgi_label;
        private System.Windows.Forms.PictureBox musteri_hakkinda_bilgi_pb;
        private System.Windows.Forms.Label musteri_hakkinda_bilgi_label;
        private System.Windows.Forms.PictureBox tc_pb;
        private System.Windows.Forms.ComboBox tc_combo;
        private System.Windows.Forms.Label tc_label;
        private System.Windows.Forms.GroupBox arac_cikar_gb;
    }
}