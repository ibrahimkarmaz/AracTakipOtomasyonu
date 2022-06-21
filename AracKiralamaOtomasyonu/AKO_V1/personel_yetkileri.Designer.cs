namespace WindowsFormsApplication1
{
    partial class personel_yetkileri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(personel_yetkileri));
            this.yetkilendir_gb = new System.Windows.Forms.GroupBox();
            this.personel_yetkileri_pb = new System.Windows.Forms.PictureBox();
            this.yetki_turu_combo = new System.Windows.Forms.ComboBox();
            this.yetki_turu_label = new System.Windows.Forms.Label();
            this.yetki_turu_pb = new System.Windows.Forms.PictureBox();
            this.yetki_birak_btn = new System.Windows.Forms.Button();
            this.yeni_yetki_btn = new System.Windows.Forms.Button();
            this.personel_yetkileri_label = new System.Windows.Forms.Label();
            this.personel_yetkileri_list = new System.Windows.Forms.ListBox();
            this.yetkilerin_listesi_list = new System.Windows.Forms.ListBox();
            this.iptalet_pb = new System.Windows.Forms.PictureBox();
            this.yetkilendir_pb = new System.Windows.Forms.PictureBox();
            this.personel_gb = new System.Windows.Forms.GroupBox();
            this.bilgi_label = new System.Windows.Forms.Label();
            this.tc_pb = new System.Windows.Forms.PictureBox();
            this.tc_combo = new System.Windows.Forms.ComboBox();
            this.tc_label = new System.Windows.Forms.Label();
            this.yetki_menu = new System.Windows.Forms.MenuStrip();
            this.yetki_duzenle_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.yardim_toolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.sagtikmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yetki_duzenle_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.yardim_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.yetkilendir_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personel_yetkileri_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yetki_turu_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yetkilendir_pb)).BeginInit();
            this.personel_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tc_pb)).BeginInit();
            this.yetki_menu.SuspendLayout();
            this.sagtikmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // yetkilendir_gb
            // 
            this.yetkilendir_gb.Controls.Add(this.personel_yetkileri_pb);
            this.yetkilendir_gb.Controls.Add(this.yetki_turu_combo);
            this.yetkilendir_gb.Controls.Add(this.yetki_turu_label);
            this.yetkilendir_gb.Controls.Add(this.yetki_turu_pb);
            this.yetkilendir_gb.Controls.Add(this.yetki_birak_btn);
            this.yetkilendir_gb.Controls.Add(this.yeni_yetki_btn);
            this.yetkilendir_gb.Controls.Add(this.personel_yetkileri_label);
            this.yetkilendir_gb.Controls.Add(this.personel_yetkileri_list);
            this.yetkilendir_gb.Controls.Add(this.yetkilerin_listesi_list);
            this.yetkilendir_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yetkilendir_gb.Location = new System.Drawing.Point(12, 29);
            this.yetkilendir_gb.Name = "yetkilendir_gb";
            this.yetkilendir_gb.Size = new System.Drawing.Size(678, 326);
            this.yetkilendir_gb.TabIndex = 1;
            this.yetkilendir_gb.TabStop = false;
            this.yetkilendir_gb.Text = "Yetkilendirme İşlemleri";
            // 
            // personel_yetkileri_pb
            // 
            this.personel_yetkileri_pb.Location = new System.Drawing.Point(367, 37);
            this.personel_yetkileri_pb.Name = "personel_yetkileri_pb";
            this.personel_yetkileri_pb.Size = new System.Drawing.Size(32, 24);
            this.personel_yetkileri_pb.TabIndex = 52;
            this.personel_yetkileri_pb.TabStop = false;
            // 
            // yetki_turu_combo
            // 
            this.yetki_turu_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yetki_turu_combo.FormattingEnabled = true;
            this.yetki_turu_combo.Location = new System.Drawing.Point(144, 37);
            this.yetki_turu_combo.Name = "yetki_turu_combo";
            this.yetki_turu_combo.Size = new System.Drawing.Size(161, 26);
            this.yetki_turu_combo.TabIndex = 51;
            this.yetki_turu_combo.SelectedIndexChanged += new System.EventHandler(this.yetki_turu_combo_SelectedIndexChanged);
            // 
            // yetki_turu_label
            // 
            this.yetki_turu_label.AutoSize = true;
            this.yetki_turu_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yetki_turu_label.Location = new System.Drawing.Point(44, 38);
            this.yetki_turu_label.Name = "yetki_turu_label";
            this.yetki_turu_label.Size = new System.Drawing.Size(99, 23);
            this.yetki_turu_label.TabIndex = 50;
            this.yetki_turu_label.Text = "Yetki Türü:";
            // 
            // yetki_turu_pb
            // 
            this.yetki_turu_pb.Location = new System.Drawing.Point(6, 37);
            this.yetki_turu_pb.Name = "yetki_turu_pb";
            this.yetki_turu_pb.Size = new System.Drawing.Size(32, 24);
            this.yetki_turu_pb.TabIndex = 49;
            this.yetki_turu_pb.TabStop = false;
            // 
            // yetki_birak_btn
            // 
            this.yetki_birak_btn.Location = new System.Drawing.Point(311, 186);
            this.yetki_birak_btn.Name = "yetki_birak_btn";
            this.yetki_birak_btn.Size = new System.Drawing.Size(50, 37);
            this.yetki_birak_btn.TabIndex = 48;
            this.yetki_birak_btn.Text = "<<";
            this.yetki_birak_btn.UseVisualStyleBackColor = true;
            this.yetki_birak_btn.Click += new System.EventHandler(this.yetki_birak_btn_Click);
            // 
            // yeni_yetki_btn
            // 
            this.yeni_yetki_btn.Location = new System.Drawing.Point(311, 141);
            this.yeni_yetki_btn.Name = "yeni_yetki_btn";
            this.yeni_yetki_btn.Size = new System.Drawing.Size(50, 37);
            this.yeni_yetki_btn.TabIndex = 44;
            this.yeni_yetki_btn.Text = ">>";
            this.yeni_yetki_btn.UseVisualStyleBackColor = true;
            this.yeni_yetki_btn.Click += new System.EventHandler(this.yeni_yetki_btn_Click);
            // 
            // personel_yetkileri_label
            // 
            this.personel_yetkileri_label.AutoSize = true;
            this.personel_yetkileri_label.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personel_yetkileri_label.Location = new System.Drawing.Point(405, 38);
            this.personel_yetkileri_label.Name = "personel_yetkileri_label";
            this.personel_yetkileri_label.Size = new System.Drawing.Size(146, 23);
            this.personel_yetkileri_label.TabIndex = 47;
            this.personel_yetkileri_label.Text = "Personel Yetkileri:";
            // 
            // personel_yetkileri_list
            // 
            this.personel_yetkileri_list.FormattingEnabled = true;
            this.personel_yetkileri_list.ItemHeight = 18;
            this.personel_yetkileri_list.Location = new System.Drawing.Point(367, 74);
            this.personel_yetkileri_list.Name = "personel_yetkileri_list";
            this.personel_yetkileri_list.Size = new System.Drawing.Size(299, 238);
            this.personel_yetkileri_list.TabIndex = 46;
            // 
            // yetkilerin_listesi_list
            // 
            this.yetkilerin_listesi_list.FormattingEnabled = true;
            this.yetkilerin_listesi_list.ItemHeight = 18;
            this.yetkilerin_listesi_list.Location = new System.Drawing.Point(6, 74);
            this.yetkilerin_listesi_list.Name = "yetkilerin_listesi_list";
            this.yetkilerin_listesi_list.Size = new System.Drawing.Size(299, 238);
            this.yetkilerin_listesi_list.TabIndex = 0;
            // 
            // iptalet_pb
            // 
            this.iptalet_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iptalet_pb.Location = new System.Drawing.Point(895, 300);
            this.iptalet_pb.Name = "iptalet_pb";
            this.iptalet_pb.Size = new System.Drawing.Size(78, 55);
            this.iptalet_pb.TabIndex = 67;
            this.iptalet_pb.TabStop = false;
            this.iptalet_pb.Click += new System.EventHandler(this.iptalet_pb_Click);
            this.iptalet_pb.MouseLeave += new System.EventHandler(this.iptalet_pb_MouseLeave);
            this.iptalet_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iptalet_pb_MouseMove);
            // 
            // yetkilendir_pb
            // 
            this.yetkilendir_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yetkilendir_pb.Location = new System.Drawing.Point(979, 300);
            this.yetkilendir_pb.Name = "yetkilendir_pb";
            this.yetkilendir_pb.Size = new System.Drawing.Size(78, 55);
            this.yetkilendir_pb.TabIndex = 66;
            this.yetkilendir_pb.TabStop = false;
            this.yetkilendir_pb.Click += new System.EventHandler(this.yetkilendir_pb_Click);
            this.yetkilendir_pb.MouseLeave += new System.EventHandler(this.yetkilendir_pb_MouseLeave);
            this.yetkilendir_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.yetkilendir_pb_MouseMove);
            // 
            // personel_gb
            // 
            this.personel_gb.Controls.Add(this.bilgi_label);
            this.personel_gb.Controls.Add(this.tc_pb);
            this.personel_gb.Controls.Add(this.tc_combo);
            this.personel_gb.Controls.Add(this.tc_label);
            this.personel_gb.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personel_gb.Location = new System.Drawing.Point(696, 29);
            this.personel_gb.Name = "personel_gb";
            this.personel_gb.Size = new System.Drawing.Size(361, 113);
            this.personel_gb.TabIndex = 90;
            this.personel_gb.TabStop = false;
            this.personel_gb.Text = "Personel İşlemleri";
            // 
            // bilgi_label
            // 
            this.bilgi_label.AutoSize = true;
            this.bilgi_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bilgi_label.Location = new System.Drawing.Point(6, 61);
            this.bilgi_label.Name = "bilgi_label";
            this.bilgi_label.Size = new System.Drawing.Size(35, 18);
            this.bilgi_label.TabIndex = 86;
            this.bilgi_label.Text = "bilgi";
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
            this.tc_combo.Location = new System.Drawing.Point(176, 23);
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
            // yetki_menu
            // 
            this.yetki_menu.BackColor = System.Drawing.SystemColors.Highlight;
            this.yetki_menu.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yetki_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yetki_duzenle_menu,
            this.iptal_et_menu,
            this.yardim_toolstrip});
            this.yetki_menu.Location = new System.Drawing.Point(0, 0);
            this.yetki_menu.Name = "yetki_menu";
            this.yetki_menu.Size = new System.Drawing.Size(1070, 26);
            this.yetki_menu.TabIndex = 93;
            this.yetki_menu.Text = "menuStrip1";
            // 
            // yetki_duzenle_menu
            // 
            this.yetki_duzenle_menu.Name = "yetki_duzenle_menu";
            this.yetki_duzenle_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.yetki_duzenle_menu.Size = new System.Drawing.Size(104, 22);
            this.yetki_duzenle_menu.Text = "Yetkilendirme";
            this.yetki_duzenle_menu.Click += new System.EventHandler(this.yetkilendir_pb_Click);
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
            this.yetki_duzenle_sagtik,
            this.iptal_et_sagtik,
            this.yardim_sagtik});
            this.sagtikmenu.Name = "sagtikmenu";
            this.sagtikmenu.Size = new System.Drawing.Size(161, 92);
            // 
            // yetki_duzenle_sagtik
            // 
            this.yetki_duzenle_sagtik.Name = "yetki_duzenle_sagtik";
            this.yetki_duzenle_sagtik.Size = new System.Drawing.Size(160, 22);
            this.yetki_duzenle_sagtik.Text = "Yetkilendirme";
            this.yetki_duzenle_sagtik.Click += new System.EventHandler(this.yetkilendir_pb_Click);
            // 
            // iptal_et_sagtik
            // 
            this.iptal_et_sagtik.Name = "iptal_et_sagtik";
            this.iptal_et_sagtik.Size = new System.Drawing.Size(160, 22);
            this.iptal_et_sagtik.Text = "İptal Et";
            this.iptal_et_sagtik.Click += new System.EventHandler(this.iptalet_pb_Click);
            // 
            // yardim_sagtik
            // 
            this.yardim_sagtik.Name = "yardim_sagtik";
            this.yardim_sagtik.Size = new System.Drawing.Size(160, 22);
            this.yardim_sagtik.Text = "Yardım";
            this.yardim_sagtik.Click += new System.EventHandler(this.yardim_toolstrip_Click);
            // 
            // personel_yetkileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1070, 367);
            this.ContextMenuStrip = this.sagtikmenu;
            this.Controls.Add(this.yetki_menu);
            this.Controls.Add(this.personel_gb);
            this.Controls.Add(this.iptalet_pb);
            this.Controls.Add(this.yetkilendir_pb);
            this.Controls.Add(this.yetkilendir_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "personel_yetkileri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Yetkileri";
            this.Load += new System.EventHandler(this.personel_yetkileri_Load);
            this.yetkilendir_gb.ResumeLayout(false);
            this.yetkilendir_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personel_yetkileri_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yetki_turu_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptalet_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yetkilendir_pb)).EndInit();
            this.personel_gb.ResumeLayout(false);
            this.personel_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tc_pb)).EndInit();
            this.yetki_menu.ResumeLayout(false);
            this.yetki_menu.PerformLayout();
            this.sagtikmenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox yetkilendir_gb;
        private System.Windows.Forms.Button yetki_birak_btn;
        private System.Windows.Forms.Button yeni_yetki_btn;
        private System.Windows.Forms.Label personel_yetkileri_label;
        private System.Windows.Forms.ListBox personel_yetkileri_list;
        private System.Windows.Forms.ListBox yetkilerin_listesi_list;
        private System.Windows.Forms.ComboBox yetki_turu_combo;
        private System.Windows.Forms.Label yetki_turu_label;
        private System.Windows.Forms.PictureBox yetki_turu_pb;
        private System.Windows.Forms.PictureBox iptalet_pb;
        private System.Windows.Forms.PictureBox yetkilendir_pb;
        private System.Windows.Forms.GroupBox personel_gb;
        private System.Windows.Forms.Label bilgi_label;
        private System.Windows.Forms.PictureBox tc_pb;
        private System.Windows.Forms.ComboBox tc_combo;
        private System.Windows.Forms.Label tc_label;
        private System.Windows.Forms.PictureBox personel_yetkileri_pb;
        private System.Windows.Forms.MenuStrip yetki_menu;
        private System.Windows.Forms.ToolStripMenuItem yetki_duzenle_menu;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_menu;
        private System.Windows.Forms.ToolStripMenuItem yardim_toolstrip;
        private System.Windows.Forms.ContextMenuStrip sagtikmenu;
        private System.Windows.Forms.ToolStripMenuItem yetki_duzenle_sagtik;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_sagtik;
        private System.Windows.Forms.ToolStripMenuItem yardim_sagtik;
    }
}