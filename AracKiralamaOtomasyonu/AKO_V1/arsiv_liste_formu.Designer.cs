namespace WindowsFormsApplication1
{
    partial class arsiv_liste_formu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(arsiv_liste_formu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tablolari_listele_dgv = new System.Windows.Forms.DataGridView();
            this.arsiv_islemleri_sagtik = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.musteri_arsivden_cikar_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.araci_arsivden_cikar_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.seciliyi_goster_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.iptal_et_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.yardim_sagtik = new System.Windows.Forms.ToolStripMenuItem();
            this.arsivleri_listele = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablolari_listele_dgv)).BeginInit();
            this.arsiv_islemleri_sagtik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arsivleri_listele)).BeginInit();
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
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablolari_listele_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.tablolari_listele_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.tablolari_listele_dgv.Size = new System.Drawing.Size(720, 444);
            this.tablolari_listele_dgv.TabIndex = 3;
            // 
            // arsiv_islemleri_sagtik
            // 
            this.arsiv_islemleri_sagtik.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.arsiv_islemleri_sagtik.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musteri_arsivden_cikar_sagtik,
            this.araci_arsivden_cikar_sagtik,
            this.seciliyi_goster_sagtik,
            this.iptal_et_sagtik,
            this.yardim_sagtik});
            this.arsiv_islemleri_sagtik.Name = "sagtikmenu";
            this.arsiv_islemleri_sagtik.Size = new System.Drawing.Size(249, 136);
            // 
            // musteri_arsivden_cikar_sagtik
            // 
            this.musteri_arsivden_cikar_sagtik.Image = ((System.Drawing.Image)(resources.GetObject("musteri_arsivden_cikar_sagtik.Image")));
            this.musteri_arsivden_cikar_sagtik.Name = "musteri_arsivden_cikar_sagtik";
            this.musteri_arsivden_cikar_sagtik.Size = new System.Drawing.Size(248, 22);
            this.musteri_arsivden_cikar_sagtik.Text = "Müşteriyi Arşivden Çıkar";
            this.musteri_arsivden_cikar_sagtik.Visible = false;
            this.musteri_arsivden_cikar_sagtik.Click += new System.EventHandler(this.musteri_arsivden_cikar_sagtik_Click);
            // 
            // araci_arsivden_cikar_sagtik
            // 
            this.araci_arsivden_cikar_sagtik.Image = ((System.Drawing.Image)(resources.GetObject("araci_arsivden_cikar_sagtik.Image")));
            this.araci_arsivden_cikar_sagtik.Name = "araci_arsivden_cikar_sagtik";
            this.araci_arsivden_cikar_sagtik.Size = new System.Drawing.Size(248, 22);
            this.araci_arsivden_cikar_sagtik.Text = "Aracı Arşivden Çıkar";
            this.araci_arsivden_cikar_sagtik.Visible = false;
            this.araci_arsivden_cikar_sagtik.Click += new System.EventHandler(this.araci_arsivden_cikar_sagtik_Click);
            // 
            // seciliyi_goster_sagtik
            // 
            this.seciliyi_goster_sagtik.Image = ((System.Drawing.Image)(resources.GetObject("seciliyi_goster_sagtik.Image")));
            this.seciliyi_goster_sagtik.Name = "seciliyi_goster_sagtik";
            this.seciliyi_goster_sagtik.Size = new System.Drawing.Size(248, 22);
            this.seciliyi_goster_sagtik.Text = "Bilgileri Göster[Seçili Satır]";
            this.seciliyi_goster_sagtik.Click += new System.EventHandler(this.seciliyi_goster_sagtik_Click);
            // 
            // iptal_et_sagtik
            // 
            this.iptal_et_sagtik.Image = ((System.Drawing.Image)(resources.GetObject("iptal_et_sagtik.Image")));
            this.iptal_et_sagtik.Name = "iptal_et_sagtik";
            this.iptal_et_sagtik.Size = new System.Drawing.Size(248, 22);
            this.iptal_et_sagtik.Text = "İptal Et";
            this.iptal_et_sagtik.Click += new System.EventHandler(this.iptal_et_sagtik_Click);
            // 
            // yardim_sagtik
            // 
            this.yardim_sagtik.Image = ((System.Drawing.Image)(resources.GetObject("yardim_sagtik.Image")));
            this.yardim_sagtik.Name = "yardim_sagtik";
            this.yardim_sagtik.Size = new System.Drawing.Size(248, 22);
            this.yardim_sagtik.Text = "Yardım";
            this.yardim_sagtik.Click += new System.EventHandler(this.yardim_sagtik_Click);
            // 
            // arsivleri_listele
            // 
            this.arsivleri_listele.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.arsivleri_listele.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.arsivleri_listele.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.arsivleri_listele.ContextMenuStrip = this.arsiv_islemleri_sagtik;
            this.arsivleri_listele.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.arsivleri_listele.DefaultCellStyle = dataGridViewCellStyle5;
            this.arsivleri_listele.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arsivleri_listele.Location = new System.Drawing.Point(0, 0);
            this.arsivleri_listele.Name = "arsivleri_listele";
            this.arsivleri_listele.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.arsivleri_listele.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.arsivleri_listele.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.arsivleri_listele.Size = new System.Drawing.Size(720, 444);
            this.arsivleri_listele.TabIndex = 6;
            // 
            // arsiv_liste_formu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 444);
            this.Controls.Add(this.arsivleri_listele);
            this.Controls.Add(this.tablolari_listele_dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "arsiv_liste_formu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "arsiv_liste_formu";
            this.Load += new System.EventHandler(this.arsiv_liste_formu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablolari_listele_dgv)).EndInit();
            this.arsiv_islemleri_sagtik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.arsivleri_listele)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablolari_listele_dgv;
        private System.Windows.Forms.ContextMenuStrip arsiv_islemleri_sagtik;
        private System.Windows.Forms.ToolStripMenuItem musteri_arsivden_cikar_sagtik;
        private System.Windows.Forms.ToolStripMenuItem iptal_et_sagtik;
        private System.Windows.Forms.ToolStripMenuItem yardim_sagtik;
        private System.Windows.Forms.DataGridView arsivleri_listele;
        private System.Windows.Forms.ToolStripMenuItem araci_arsivden_cikar_sagtik;
        private System.Windows.Forms.ToolStripMenuItem seciliyi_goster_sagtik;
    }
}