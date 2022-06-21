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
    public partial class kiralama_islemleri_arama : Form
    {
        public kiralama_islemleri_arama()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlDataAdapter Komutlar;//TABLOLARIN ÇEKİLMESİNDE KULLANILAN KOMUT
        DataSet veriseti = new DataSet();//ÇEKİLEN TABLOLARI SAKLAMAK İÇİN GEREK KOMUT
        string aranacak_alan = "", aranacak_bilgi = "", gosterme_adeti = "", sql_kod = "select kiralama_tarihi,fiyat,tcno,ad,soyad,cep1,cep2,eposta,ehliyet_no,ehliyet_turu,plaka,marka,model,kategori,kira_ucreti from kiralama_tablosu inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id inner join arac_tablosu on kiralama_tablosu.arac_id=arac_tablosu.arac_id where kiralama_tablosu.arsiv=1";

        private void kiralama_islemleri_arama_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME
            arama_sonrasi_duzen();//ALAN ADI VE BOYUTLANDIRMA AYARLARI FOKSİYONU
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
            tumunu_listele_pb.Image = Image.FromFile(@"image\kiralama_listesi1.png");


            kiralayan_arama_menu.Image = Image.FromFile(@"image\arama1.png");
            kiralayan_arama_sagtik.Image = Image.FromFile(@"image\arama1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            gelismis_arama_menu.Image = Image.FromFile(@"image\yukari.png");
            gelismis_arama_sagtik.Image = Image.FromFile(@"image\yukari.png");
            otomatik_arama_menu.Image = Image.FromFile(@"image\otomatik_arama.png");
            otomatik_arama_sagtik.Image = Image.FromFile(@"image\otomatik_arama.png");
            listeleme_islemleri_menu.Image = Image.FromFile(@"image\liste.png");
            listeleme_islemleri_sagtik.Image = Image.FromFile(@"image\liste.png");
            listeleme_belirle_menu.Image = Image.FromFile(@"image\kiralama_listesi1.png");
            listeleme_belirle_sagtik.Image = Image.FromFile(@"image\kiralama_listesi1.png");
            hepsini_listele_menu.Image = Image.FromFile(@"image\kiralama_listesi1.png");
            hepsini_listele_sagtik.Image = Image.FromFile(@"image\kiralama_listesi1.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");

            konu_pb.SizeMode = ara_pb.SizeMode = ilk_pb.SizeMode = tumunu_listele_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {//ARAMA KONUSU
            konu_combo.Items.Add("TC NUMARASINA GÖRE");
            konu_combo.Items.Add("PLAKA NUMARASINA GÖRE");
            konu_combo.Items.Add("EHLİYET NUMARASINA GÖRE");
            konu_combo.Items.Add("CEP TELEFONUNA(1) GÖRE");
            konu_combo.Items.Add("CEP TELEFONUNA(2) GÖRE");
            konu_combo.Items.Add("KİRALAMA TARİHİNE GÖRE");
            konu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            //KAÇ SATIR GÖSTERİLECEK
            ilk_combo.Items.Add("1");
            ilk_combo.Items.Add("5");
            ilk_belirle_combo.Items.Add("1");
            ilk_belirle_combo.Items.Add("5");
            ilk_belirle_combo_sagtik.Items.Add("1");
            ilk_belirle_combo_sagtik.Items.Add("5");
            for (int i = 10; i <= 100; i += 10)
            {
                ilk_combo.Items.Add(i.ToString());
                ilk_belirle_combo.Items.Add(i.ToString());
                ilk_belirle_combo_sagtik.Items.Add(i.ToString());
            }
            ilk_combo.Items.Add("HEPSİ");
            ilk_belirle_combo.Items.Add("HEPSİ");
            ilk_belirle_combo_sagtik.Items.Add("HEPSİ");

            ilk_combo.SelectedIndex = ilk_combo.Items.Count - 1;//Diğerleri değişe bilir ama son eleman "hepsi" değişmez.
            ilk_belirle_combo.SelectedIndex = ilk_belirle_combo.Items.Count - 1;//Diğerleri değişe bilir ama son eleman "hepsi" değişmez.
            ilk_belirle_combo_sagtik.SelectedIndex = ilk_belirle_combo.Items.Count - 1;//Diğerleri değişe bilir ama son eleman "hepsi" değişmez.
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI OLUŞAN SORUNLARI DÜZENLEME
            arama_islemleri_gb.ForeColor= this.ForeColor;
            tablolari_listele_dgv.BackgroundColor = this.BackColor;
            tablolari_listele_dgv.ForeColor = Color.Black;

        }
        private void gelismis_arama_secenekleri_cb_CheckedChanged_1(object sender, EventArgs e)
        {
            konu_combo.Items.Clear();//KONULARI SİLME
            if (gelismis_arama_secenekleri_cb.Checked == true)//GELİŞMİŞ ARAMA VARSA
            {//YENİ ARAMA KONULARI
                konu_combo.Items.Add("TC NUMARASINA GÖRE");
                konu_combo.Items.Add("MÜŞTERİ ADINA GÖRE");
                konu_combo.Items.Add("MÜŞTERİ SOYADINA GÖRE");
                konu_combo.Items.Add("CEP TELEFONUNA(1) GÖRE");
                konu_combo.Items.Add("CEP TELEFONUNA(2) GÖRE");
                konu_combo.Items.Add("PLAKA NUMARASINA GÖRE");
                konu_combo.Items.Add("EHLİYET NUMARASINA GÖRE");
                konu_combo.Items.Add("MARKAYA GÖRE");
                konu_combo.Items.Add("MODELE GÖRE");
                konu_combo.Items.Add("KİRALAMA TARİHİNE GÖRE");
                konu_combo.Items.Add("KATEGORİYE GÖRE");
                konu_combo.Items.Add("KİRA ÜCRETİNE GÖRE");
            }
            else//GELİŞMİŞ ARAMA YOKSA
            {//VARSAYILAN ARAMALAR
                konu_combo.Items.Add("TC NUMARASINA GÖRE");
                konu_combo.Items.Add("PLAKA NUMARASINA GÖRE");
                konu_combo.Items.Add("EHLİYET NUMARASINA GÖRE");
                konu_combo.Items.Add("CEP TELEFONUNA(1) GÖRE");
                konu_combo.Items.Add("CEP TELEFONUNA(2) GÖRE");
                konu_combo.Items.Add("KİRALAMA TARİHİNE GÖRE");
            }
            konu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
        }

        private void konu_combo_SelectedIndexChanged(object sender, EventArgs e)
        {//ALAN ADI BELİRLEME
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
            else if (konu_combo.Text == "CEP TELEFONUNA(1) GÖRE")
            {
                aranacak_alan = "cep1";
            }
            else if (konu_combo.Text == "CEP TELEFONUNA(2) GÖRE")
            {
                aranacak_alan = "cep2";
            }
            else if (konu_combo.Text == "PLAKA NUMARASINA GÖRE")
            {
                aranacak_alan = "plaka";
            }
            else if (konu_combo.Text == "EHLİYET NUMARASINA GÖRE")
            {
                aranacak_alan = "ehliyet_no";
            }
            else if (konu_combo.Text == "MARKAYA GÖRE")
            {
                aranacak_alan = "marka";
            }
            else if (konu_combo.Text == "MODELE GÖRE")
            {
                aranacak_alan = "model";
            }
            else if (konu_combo.Text == "KİRALAMA TARİHİNE GÖRE")
            {
                aranacak_alan = "kiralama_tarihi";
            }
            else if (konu_combo.Text == "KATEGORİYE GÖRE")
            {
                aranacak_alan = "kategori";
            }
            else if (konu_combo.Text == "KİRA ÜCRETİNE GÖRE")
            {
                aranacak_alan = "kira_ucreti";
            }
        }

        private void ara_pb_Click(object sender, EventArgs e)
        {
            if (arama_tb.Text != "")//ARAMA BOŞ DEĞİLSE
            {
                kodu_yenile();//YENİ SQL KOMUTU
                arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME
            }
            else
            {
                MessageBox.Show("ARAMA BİLGİLERİNİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//ARAMA İŞLEMİ İÇİN BİLGİ GEREKLİ UYARISI
            }
        }
        private void kodu_yenile()//ARAMA KOMUTUNU YENİLEME FOKSİYONU
        {
            if (otomatik_arama_cb.Checked == true)//OTOMATİK ARAMADA LİKE KULLANILIR
            {
                sql_kod = "select " + gosterme_adeti + " kiralama_tarihi,fiyat,tcno,ad,soyad,cep1,cep2,eposta,ehliyet_no,ehliyet_turu,plaka,marka,model,kategori,kira_ucreti from kiralama_tablosu inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id inner join arac_tablosu on kiralama_tablosu.arac_id=arac_tablosu.arac_id  where " + aranacak_alan + " like '%" + aranacak_bilgi + "%' and kiralama_tablosu.arsiv=1";
            }
            else if (otomatik_arama_cb.Checked == false)//NORMALDE İSE DİREK AYNISI VARSA BİLGİ GELİR
            {
                sql_kod = "select " + gosterme_adeti + " kiralama_tarihi,fiyat,tcno,ad,soyad,cep1,cep2,eposta,ehliyet_no,ehliyet_turu,plaka,marka,model,kategori,kira_ucreti from kiralama_tablosu inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id inner join arac_tablosu on kiralama_tablosu.arac_id=arac_tablosu.arac_id   where " + aranacak_alan + "='" + aranacak_bilgi + "' and kiralama_tablosu.arsiv=1";
            }
        }
        private void arama_islemleri()
        {
            veriseti.Clear();//TABLOLARI SİLER 
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                Komutlar = new SqlDataAdapter(sql_kod, baglanti);//KOMUTLARIN EKLENDIĞI
                Komutlar.Fill(veriseti, "kiralama_tablosu");//SAKLANDIĞI
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                tablolari_listele_dgv.DataSource = veriseti.Tables["kiralama_tablosu"];//TABLONUN GÖSTERİLDİĞİ YER
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
            tablolari_listele_dgv.Columns["cep1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["cep2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["eposta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ehliyet_no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ehliyet_turu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["plaka"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["marka"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["kategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["kira_ucreti"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["kiralama_tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["fiyat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ

            tablolari_listele_dgv.Columns["tcno"].HeaderText = "TC NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ad"].HeaderText = "AD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞ
            tablolari_listele_dgv.Columns["soyad"].HeaderText = "SOYAD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["cep1"].HeaderText = "CEP TELEFONU(1)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["cep2"].HeaderText = "CEP TELEFONU(2)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["eposta"].HeaderText = "E-POSTA ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ehliyet_no"].HeaderText = "EHLİYET NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ehliyet_turu"].HeaderText = "EHLİYET TÜRÜ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["plaka"].HeaderText = "PLAKA NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["marka"].HeaderText = "MARKA";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["model"].HeaderText = "MODEL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["kategori"].HeaderText = "KATEGORİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["kira_ucreti"].HeaderText = "KİRA ÜCRETİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["kiralama_tarihi"].HeaderText = "KİRALAMA TARİHİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["fiyat"].HeaderText = "ÜCRET";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
        }
        private void ilk_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //KAÇ SATIR GÖSTERME KOMUTU VE MENÜLERE EKLEME
            gosterme_adeti = "";
            if (ilk_combo.Text == "HEPSİ")
            {
                gosterme_adeti = "";
            }
            else if (ilk_combo.Text != "HEPSİ")
            {
                gosterme_adeti = "top "+ilk_combo.SelectedItem;// TOP ADET TOP 5 GİBİ
            }
            ilk_belirle_combo.SelectedItem = ilk_combo.SelectedItem;//MENÜLERDE GÖSTERME
            ilk_belirle_combo_sagtik.SelectedItem = ilk_combo.SelectedItem;//MENÜLERDE GÖSTERME
        }

        private void arama_tb_TextChanged(object sender, EventArgs e)
        {
            aranacak_bilgi = arama_tb.Text;
            if (otomatik_arama_cb.Checked == true)//OTOMATIK ARAMA İŞARETLI İSE
            {
                kodu_yenile();//YENİ SQL KOMUTU
                arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME
            }
        }

        private void otomatik_arama_cb_CheckedChanged(object sender, EventArgs e)
        {//OTOMATİK ARAMA İŞARETİ DEĞİŞTİĞİNDE ÇALIŞIR
            if (otomatik_arama_cb.Checked == true)//OTOMATİK ARAMA AÇIKSA
            {
                ara_pb.Visible = false;//ARAMAYI GİZLE
                kiralayan_arama_menu.Enabled = false;//MENÜLERDE KULLANDIRMA
                kiralayan_arama_sagtik.Enabled = false;//MENÜLERDE KULLANDIRMA
            }
            else
            {
                ara_pb.Visible = true;//ARAMAYI GÖSTER
                kiralayan_arama_menu.Enabled = true;//MENÜLERİ KULLANDIR
                kiralayan_arama_sagtik.Enabled = true;//MENÜLERİ KULLANDIR
            }
        }

        private void tumunu_listele_pb_Click(object sender, EventArgs e)
        {
            sql_kod = "select kiralama_tarihi,fiyat,tcno,ad,soyad,cep1,cep2,eposta,ehliyet_no,ehliyet_turu,plaka,marka,model,kategori,kira_ucreti from kiralama_tablosu inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id inner join arac_tablosu on kiralama_tablosu.arac_id=arac_tablosu.arac_id where kiralama_tablosu.arsiv=1";//TÜM LİSTEYİ GÖSTERME KODU
            arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME
        }

        private void tumunu_listele_pb_MouseMove(object sender, MouseEventArgs e)
        {
            tumunu_listele_pb.Image = Image.FromFile(@"image\kiralama_listesi2.png");//GÖRSEL EFEKT
        }

        private void tumunu_listele_pb_MouseLeave(object sender, EventArgs e)
        {
            tumunu_listele_pb.Image = Image.FromFile(@"image\kiralama_listesi1.png");//VARSAYILAN GÖRSEL
        }
        private void ilk_belirle_combo_TextChanged(object sender, EventArgs e)
        {
            ilk_combo.SelectedItem = ilk_belirle_combo.SelectedItem;//MENÜLER VE PENCERE ARASINDA SAYI DEĞİŞTİRME
            ilk_belirle_combo_sagtik.SelectedItem = ilk_belirle_combo.SelectedItem;//MENÜLER VE PENCERE ARASINDA SAYI DEĞİŞTİRME
        }

        private void ilk_belirle_combo_sagtik_TextChanged(object sender, EventArgs e)
        {
            ilk_belirle_combo.SelectedItem = ilk_belirle_combo_sagtik.SelectedItem;//MENÜLER VE PENCERE ARASINDA SAYI DEĞİŞTİRME
            ilk_combo.SelectedItem = ilk_belirle_combo_sagtik.SelectedItem;//MENÜLER VE PENCERE ARASINDA SAYI DEĞİŞTİRME
        }

        private void iptal_et_menu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }

        private void gelismis_arama_menu_Click(object sender, EventArgs e)
        {//MENÜDE ÇALIŞIYOR
            if (gelismis_arama_secenekleri_cb.Checked == false)//KAPALI İSE
            {
                gelismis_arama_secenekleri_cb.Checked = true;//AÇ
            }
            else//AÇIK İSE
            {
                gelismis_arama_secenekleri_cb.Checked = false;//KAPAT
            }
        }

        private void otomatik_arama_menu_Click(object sender, EventArgs e)
        {//MENÜDE ÇALIŞIYOR
            if (otomatik_arama_cb.Checked == false)//KAPALI İSE
            {
                otomatik_arama_cb.Checked = true;//AÇ
            }
            else//AÇIK İSE
            {
                otomatik_arama_cb.Checked = false;//KAPAT
            }
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESI AÇMA
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }

    }
}
