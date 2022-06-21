using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class musteri_arama : Form
    {
        public musteri_arama()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlDataAdapter Komutlar;//TABLOLARIN ÇEKİLMESİNDE KULLANILAN KOMUT
        DataSet veriseti = new DataSet();//ÇEKİLEN TABLOLARI SAKLAMAK İÇİN GEREK KOMUT
        string aranacak_alan = "", aranacak_bilgi = "", gosterme_adeti = "", sql_kod = "select tcno,ad,soyad,case cinsiyet when 1 then 'Erkek' when 0 then 'Kadın'end as 'cinsiyet_guncellemesi',il,ilce,cep1,cep2,eposta,adres,ehliyet_no,ehliyet_turu,ehliyet_tarihi,aciklama from musteri_tablosu where arsiv=1";

        private void musteri_arama_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME
            arama_sonrasi_duzen();//ALAN ADLARI BOYUTLARI DÜZENLEME
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void fotograflari_al_ve_duzenle()
        {//VARSAYILAN GÖRSELLER
            konu_pb.Image = Image.FromFile(@"image\kullanici.png");
            ara_pb.Image = Image.FromFile(@"image\arama1.png");
            ilk_pb.Image = Image.FromFile(@"image\liste_ilk.png");
            tumunu_listele_pb.Image = Image.FromFile(@"image\musteri_listesi1.png");

            musteri_ara_menu.Image = Image.FromFile(@"image\arama1.png");
            musteri_ara_sagtik.Image = Image.FromFile(@"image\arama1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            gelismis_arama_menu.Image = Image.FromFile(@"image\yukari.png");
            gelismis_arama_sagtik.Image = Image.FromFile(@"image\yukari.png");
            otomatik_arama_menu.Image = Image.FromFile(@"image\otomatik_arama.png");
            otomatik_arama_sagtik.Image = Image.FromFile(@"image\otomatik_arama.png");
            listeleme_islemleri_menu.Image = Image.FromFile(@"image\liste.png");
            listeleme_islemleri_sagtik.Image = Image.FromFile(@"image\liste.png");
            listeleme_belirle_menu.Image = Image.FromFile(@"image\musteri_listesi1.png");
            listeleme_belirle_sagtik.Image = Image.FromFile(@"image\musteri_listesi1.png");
            hepsini_listele_menu.Image = Image.FromFile(@"image\musteri_listesi1.png");
            hepsini_listele_sagtik.Image = Image.FromFile(@"image\musteri_listesi1.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");

            konu_pb.SizeMode = ara_pb.SizeMode = ilk_pb.SizeMode = tumunu_listele_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {//ARAMA KONULARI
            konu_combo.Items.Add("TC NUMARASINA GÖRE");
            konu_combo.Items.Add("CEP TELEFONUNA(1) GÖRE");
            konu_combo.Items.Add("CEP TELEFONUNA(2) GÖRE");
            konu_combo.Items.Add("EHLİYET NUMARASINA GÖRE");
            konu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            //KAÇ SATIR GÖSTERİLECEK 
            ilk_combo.Items.Add("1");
            ilk_combo.Items.Add("5");
            for (int i = 10; i <= 100; i += 10)
            {
                ilk_combo.Items.Add(i.ToString());
            }
            ilk_combo.Items.Add("HEPSİ");

            ilk_belirle_combo.Items.Add("1");
            ilk_belirle_combo.Items.Add("5");
            for (int i = 10; i <= 100; i += 10)
            {
                ilk_belirle_combo.Items.Add(i.ToString());
            }
            ilk_belirle_combo.Items.Add("HEPSİ");

            ilk_belirle_combo_sagtik.Items.Add("1");
            ilk_belirle_combo_sagtik.Items.Add("5");
            for (int i = 10; i <= 100; i += 10)
            {
                ilk_belirle_combo_sagtik.Items.Add(i.ToString());
            }
            ilk_belirle_combo_sagtik.Items.Add("HEPSİ");
            ilk_combo.SelectedIndex = ilk_combo.Items.Count - 1;//Diğerleri değişe bilir ama son eleman "hepsi" değişmez.
            ilk_belirle_combo.SelectedIndex = ilk_belirle_combo.Items.Count - 1;//Diğerleri değişe bilir ama son eleman "hepsi" değişmez.
            ilk_belirle_combo_sagtik.SelectedIndex = ilk_belirle_combo.Items.Count - 1;//Diğerleri değişe bilir ama son eleman "hepsi" değişmez.
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI HATALARI DÜZENLEME
            arama_islemleri_gb.ForeColor = this.ForeColor;
            tablolari_listele_dgv.BackgroundColor = this.BackColor;
            tablolari_listele_dgv.ForeColor = Color.Black;
        }
        private void gelismis_arama_secenekleri_cb_CheckedChanged(object sender, EventArgs e)
        {
            konu_combo.Items.Clear();//ARAMA KONULARI SİLİNDİ
            if (gelismis_arama_secenekleri_cb.Checked == true)
            {//GELİŞMİŞ ARAMA KONULARI
                konu_combo.Items.Add("TC NUMARASINA GÖRE");
                konu_combo.Items.Add("MÜŞTERİ ADINA GÖRE");
                konu_combo.Items.Add("MÜŞTERİ SOYADINA GÖRE");
                konu_combo.Items.Add("İLE GÖRE");
                konu_combo.Items.Add("İLÇEYE GÖRE");
                konu_combo.Items.Add("CEP TELEFONUNA(1) GÖRE");
                konu_combo.Items.Add("CEP TELEFONUNA(2) GÖRE");
                konu_combo.Items.Add("MÜŞTERİ E-POSTA ADRESİNE GÖRE");
                konu_combo.Items.Add("EHLİYET NUMARASINA GÖRE");
                konu_combo.Items.Add("EHLİYET TÜRÜNE GÖRE");
            }
            else
            {//VARSAYILAN ARAMA KONULARI
                konu_combo.Items.Add("TC NUMARASINA GÖRE");
                konu_combo.Items.Add("CEP TELEFONUNA(1) GÖRE");
                konu_combo.Items.Add("CEP TELEFONUNA(2) GÖRE");
                konu_combo.Items.Add("EHLİYET NUMARASINA GÖRE");
            }
            konu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
        }
        private void arama_islemleri()
        {
            veriseti.Clear();//TABLOLARI SİLER 
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                Komutlar = new SqlDataAdapter(sql_kod, baglanti);//SQL KOMUTLARI
                Komutlar.Fill(veriseti, "musteri_tablosu");//TABLOYU SAKLAMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                tablolari_listele_dgv.DataSource = veriseti.Tables["musteri_tablosu"];//SAKLANAN TABLOYU GÖSTERME
            }
            catch (Exception)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
        }
        private void arama_sonrasi_duzen()
        {
            tablolari_listele_dgv.Columns["tcno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["soyad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["il"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ilce"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["cep1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["cep2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["eposta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["adres"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ehliyet_no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ehliyet_turu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ehliyet_tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["aciklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;


            tablolari_listele_dgv.Columns["tcno"].HeaderText = "TC NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ad"].HeaderText = "AD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞ
            tablolari_listele_dgv.Columns["soyad"].HeaderText = "SOYAD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["cinsiyet_guncellemesi"].HeaderText = "CİNSİYET";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["il"].HeaderText = "İL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["ilce"].HeaderText = "İLÇE";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["cep1"].HeaderText = "CEP TELEFONU(1)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["cep2"].HeaderText = "CEP TELEFONU(2)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["eposta"].HeaderText = "E-POSTA ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["adres"].HeaderText = "EV ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["ehliyet_no"].HeaderText = "EHLİYET NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ehliyet_turu"].HeaderText = "EHLİYET TÜRÜ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ehliyet_tarihi"].HeaderText = "EHLİYET TARİHİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["aciklama"].HeaderText = "AÇIKLAMA";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
        }

        private void konu_combo_SelectedIndexChanged(object sender, EventArgs e)
        {//HANGİ ALANDA ARAMA YAPACAĞINI BELİRLENİR SAKLANIR
            aranacak_alan = "";
            if (konu_combo.Text == "TC NUMARASINA GÖRE")
            {
                aranacak_alan = "tcno";
            }
            else if (konu_combo.Text == "MÜŞTERİ ADINA GÖRE")
            {
                aranacak_alan = "ad";
            }
            else if (konu_combo.Text == "MÜŞTERİ SOYADINA GÖRE")
            {
                aranacak_alan = "soyad";
            }
            else if (konu_combo.Text == "İLE GÖRE")
            {
                aranacak_alan = "il";
            }
            else if (konu_combo.Text == "İLÇEYE GÖRE")
            {
                aranacak_alan = "ilce";
            }
            else if (konu_combo.Text == "CEP TELEFONUNA(1) GÖRE")
            {
                aranacak_alan = "cep1";
            }
            else if (konu_combo.Text == "CEP TELEFONUNA(2) GÖRE")
            {
                aranacak_alan = "cep2";
            }
            else if (konu_combo.Text == "MÜŞTERİ E-POSTA ADRESİNE GÖRE")
            {
                aranacak_alan = "eposta";
            }
            else if (konu_combo.Text == "EHLİYET NUMARASINA GÖRE")
            {
                aranacak_alan = "ehliyet_no";
            }
            else if (konu_combo.Text == "EHLİYET TÜRÜNE GÖRE")
            {
                aranacak_alan = "ehliyet_turu";
            }
        }

        private void arama_tb_TextChanged(object sender, EventArgs e)
        {
            aranacak_bilgi = arama_tb.Text;//ARAMA BİLGİSİ AKTARILIR
            if (otomatik_arama_cb.Checked == true)//OTOMATIKSE İSE ÇALIŞIR BURASI
            {
                kodu_yenile();//YENİ SQL KOMUTU
                arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME
            }
        }
        private void kodu_yenile()//YENİ SQL KOMUTLARI OLUŞTURAN FOKSİYON
        {
            if (otomatik_arama_cb.Checked == true)//LİKE İLE ÇALIŞIR
            {
                sql_kod = "select " + gosterme_adeti + " tcno,ad,soyad,case cinsiyet when 1 then 'Erkek' when 0 then 'Kadın' end as 'cinsiyet_guncellemesi',il,ilce,cep1,cep2,eposta,adres,ehliyet_no,ehliyet_turu,ehliyet_tarihi,aciklama from musteri_tablosu where " + aranacak_alan + " like '%" + aranacak_bilgi + "%' and arsiv=1";//OTOMATİK ARAMA KODLARI
            }
            else if (otomatik_arama_cb.Checked == false)//BİRE BİR VARSA DEĞER GELİR.
            {
                sql_kod = "select " + gosterme_adeti + " tcno,ad,soyad,case cinsiyet when 1 then 'Erkek' when 0 then 'Kadın' end as 'cinsiyet_guncellemesi',il,ilce,cep1,cep2,eposta,adres,ehliyet_no,ehliyet_turu,ehliyet_tarihi,aciklama from musteri_tablosu where " + aranacak_alan + "='" + aranacak_bilgi + "' and arsiv=1";//NORMAL ARAMA KODLARI
            }
        }
        private void ilk_combo_SelectedIndexChanged(object sender, EventArgs e)
        {//GÖSTERME ADETİNİ BELİRLEME FOKSİYONU
            gosterme_adeti = "";
            if (ilk_combo.Text == "HEPSİ")
            {
                gosterme_adeti = "";
            }
            else if (ilk_combo.Text != "HEPSİ")
            {
                gosterme_adeti = "top " + ilk_combo.SelectedItem;//TOP 5
            }
            ilk_belirle_combo.SelectedItem = ilk_combo.SelectedItem;//MENÜLERDE GÖSTERME
            ilk_belirle_combo_sagtik.SelectedItem = ilk_combo.SelectedItem;//MENÜLERDE GÖSTERME
        }

        private void ara_pb_Click(object sender, EventArgs e)
        {
            if(arama_tb.Text != "")
            {
                kodu_yenile();//YENİ SQL KOMUTU
                arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME
            }
            else
            {
                MessageBox.Show("ARAMA BİLGİLERİNİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//ARAMA İŞLEMİ İÇİN BİLGİ GEREKLİ UYARISI
            }
        }

        private void tumunu_listele_pb_Click(object sender, EventArgs e)
        {
            sql_kod = "select tcno,ad,soyad,case cinsiyet when 1 then 'Erkek' when 0 then 'Kadın'end as 'cinsiyet_guncellemesi',il,ilce,cep1,cep2,eposta,adres,ehliyet_no,ehliyet_turu,ehliyet_tarihi,aciklama from musteri_tablosu where arsiv=1";//TÜM TABLOYU GÖSTERME
            arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME
        }

        private void otomatik_arama_cb_CheckedChanged(object sender, EventArgs e)
        {//İŞARET İŞLEMRİ YAPILDIĞINDA ÇALIŞIR
            if (otomatik_arama_cb.Checked == true)//OTOMATİK ARAMA AKTİF
            {
                ara_pb.Visible = false;//NORMAL ARAMA GİZLENDİ
                musteri_ara_menu.Enabled = false;//MENÜLERDEKİ ARAMA KULLANILAMAZ YAPILDI
                musteri_ara_sagtik.Enabled = false;//MENÜLERDEKİ ARAMA KULLANILAMAZ YAPILDI
            }
            else
            {
                ara_pb.Visible = true;//NORMAL ARAMA GÖSTERİLDİ
                musteri_ara_menu.Enabled = true;//MENÜLERDEKİ ARAMA KULLANİLABİLİR YAPILDI
                musteri_ara_sagtik.Enabled = true;//MENÜLERDEKİ ARAMA KULLANİLABİLİR YAPILDI
            }
        }

        private void iptal_et_menu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }

        private void ilk_belirle_combo_TextChanged(object sender, EventArgs e)
        {
            ilk_combo.SelectedItem = ilk_belirle_combo.SelectedItem;//MENÜLER PENCERELER ARASI BİLGİ AKTARMA
            ilk_belirle_combo_sagtik.SelectedItem = ilk_belirle_combo.SelectedItem;//MENÜLER PENCERELER ARASI BİLGİ AKTARMA
        }

        private void ilk_belirle_combo_sagtik_TextChanged(object sender, EventArgs e)
        {
            ilk_belirle_combo.SelectedItem = ilk_belirle_combo_sagtik.SelectedItem;//MENÜLER PENCERELER ARASI BİLGİ AKTARMA
            ilk_combo.SelectedItem = ilk_belirle_combo_sagtik.SelectedItem;///MENÜLER PENCERELER ARASI BİLGİ AKTARMA
        }

        private void gelismis_arama_menu_Click(object sender, EventArgs e)
        {//GELİŞMİŞ ARAMA
            if (gelismis_arama_secenekleri_cb.Checked == false)//KAPALI İSE
            {
                gelismis_arama_secenekleri_cb.Checked = true;//AÇAR
            }
            else//AÇIK İSE
            {
                gelismis_arama_secenekleri_cb.Checked = false;//KAPATILIR
            }
        }

        private void otomatik_arama_menu_Click(object sender, EventArgs e)
        {//OTOMATİK ARAMA
            if (otomatik_arama_cb.Checked == false)//KAPALI İSE
            {
                otomatik_arama_cb.Checked = true;//AÇAR
            }
            else//AÇIK İSE
            {
                otomatik_arama_cb.Checked = false;//KAPATILIR
            }
        }

        private void tumunu_listele_pb_MouseMove(object sender, MouseEventArgs e)
        {
            tumunu_listele_pb.Image = Image.FromFile(@"image\musteri_listesi2.png");//GÖRSEL EFEKT
        }

        private void tumunu_listele_pb_MouseLeave(object sender, EventArgs e)
        {
            tumunu_listele_pb.Image = Image.FromFile(@"image\musteri_listesi1.png");//VARSAYILAN GÖRSEL
        }

        private void ilk_belirle_combo_Click(object sender, EventArgs e)
        {

        }

        private void ara_pb_MouseMove(object sender, MouseEventArgs e)
        {
            ara_pb.Image = Image.FromFile(@"image\arama2.png");//GÖRSEL EFEKT
        }

        private void ara_pb_MouseLeave(object sender, EventArgs e)
        {
            ara_pb.Image = Image.FromFile(@"image\arama1.png");//VARSAYILAN GÖRSEL
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESINI AÇAR
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
