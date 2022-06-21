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
    public partial class musteri_cikar : Form
    {
        public musteri_cikar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        string musteri_id = "";//MÜŞTERİ ID SAKLANIR
        private void musteri_cikar_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            tcleri_getir();//MÜŞTERİLERİ GETİRME
            kiralayan_tc_sil();//KİRALAYAN MÜŞTERİLER ÜZERİNDE İŞLEM YAPILMAMASI İÇİN SİLİNİR 
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            secilen_tc();//SEÇİLEN TC HAKKINDA BİLGİ VERİLİR
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void fotograflari_al_ve_duzenle()
        {//VARSAYILAN GÖRSELLER
            musteri_cikar_pb.Image = Image.FromFile(@"image\musteri_cikar1.png");
            musteri_cıkar_menu.Image = Image.FromFile(@"image\cikar.png");
            musteri_cikar_sagtik.Image = Image.FromFile(@"image\cikar.png");
            iptalet_pb.Image = Image.FromFile(@"image\musteri_iptal1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            musteri_bilgileri_menu.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");
            musteri_bilgileri_sagtik.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");
            acik_alt_menu.Image = Image.FromFile(@"image\acik_goz.png");
            acik_alt_sagtik.Image = Image.FromFile(@"image\acik_goz.png");
            kapali_alt_menu.Image = Image.FromFile(@"image\kapali_goz.png");
            kapali_alt_sagtik.Image = Image.FromFile(@"image\kapali_goz.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");

            tc_pb.Image = Image.FromFile(@"image\plakano.png");
            musteri_hakkinda_bilgi_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");
            musteri_hakkinda_bilgi_pb2.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");

            musteri_cikar_pb.SizeMode = iptalet_pb.SizeMode = tc_pb.SizeMode = musteri_hakkinda_bilgi_pb.SizeMode = musteri_hakkinda_bilgi_pb2.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            bilgi_label.Text = "";
            if (tc_combo.Items.Count > 0)
            {
                tc_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
            kapali_alt_menu.Visible = true;//BİLGİ GÖSTERİP GÖSTERMEME İŞLEMLERİ
            kapali_alt_sagtik.Visible = true;//BİLGİ GÖSTERİP GÖSTERMEME İŞLEMLERİ
            acik_alt_menu.Visible = false;//BİLGİ GÖSTERİP GÖSTERMEME İŞLEMLERİ
            acik_alt_sagtik.Visible = false;//BİLGİ GÖSTERİP GÖSTERMEME İŞLEMLERİ
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI OLUŞAN SORUNLARI DÜZENLEME
            arac_cikar_gb.ForeColor = this.ForeColor;
        }
        private void tcleri_getir()
        {//MÜŞTERİLERİ GETİRME İŞLEMLER
            tc_combo.Items.Clear();//GÜNCELLEME İÇİN TEMİZLİK
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(tcno) AS TCNO from musteri_tablosu where arsiv=1", baglanti);//MÜŞTERİLERİ GETİRME
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    tc_combo.Items.Add(oku["TCNO"]);//SEÇİM KUTUSUNA TCLERİ EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void kiralayan_tc_sil()//KİRALAYAN TC GETİRME
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select distinct(musteri_tablosu.tcno) as TCNO from kiralama_tablosu inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id where kiralama_tablosu.arsiv=1", baglanti);//KİRALAYAN TC GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    tc_combo.Items.Remove(oku["TCNO"]);//SİLME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                if (tc_combo.Items.Count > 0)//VARSA
                {
                    tc_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
                }
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void musteri_hakkinda_bilgi_label_Click(object sender, EventArgs e)
        {//BİLGİLERİ GÖSTERME/GİZLEME BOYUTLANDIRMA VB
            if (musteri_hakkinda_bilgi_label.Text == "Müşteri Hakkında Bilgi[Açık]")//AÇIK İSE
            {
                musteri_hakkinda_bilgi_label.Text = "Müşteri Hakkında Bilgi[Kapali]";//YENİ AD
                arac_cikar_gb.Height = 100;//YENİ YÜKSEKLİK
                bilgi_label.Visible = false;//BİLGİLERİ GİZLER
                musteri_cikar_pb.Location = new Point(318, 130);//YENİ KONUM
                iptalet_pb.Location = new Point(234, 130);//YENİ KONUM
                kapali_alt_menu.Visible = false;//MENÜ GİZLEME
                kapali_alt_sagtik.Visible = false;//SAĞTIK MENÜ GİZLEME
                acik_alt_menu.Visible = true;//DİĞER MENÜYÜ GÖSTERME
                acik_alt_sagtik.Visible = true;//DİĞER MENÜYÜ GÖSTERME
                this.Height = 240;//YENİ PENCERE YÜKSEKLİĞİ
            }
            else if (musteri_hakkinda_bilgi_label.Text == "Müşteri Hakkında Bilgi[Kapali]")//KAPALI İSE
            {
                musteri_hakkinda_bilgi_label.Text = "Müşteri Hakkında Bilgi[Açık]";//VARSAYILAN AD
                arac_cikar_gb.Height = 382;//VARSAYILAN KONUM
                bilgi_label.Visible = true;//VARSAYILAN GİZLİLİK
                musteri_cikar_pb.Location = new Point(318, 416);//VARSAYILAN KONUM
                iptalet_pb.Location = new Point(234, 416);//VARSAYILAN KONUM
                kapali_alt_menu.Visible = true;//VARSAYILAN GÖSTERME
                kapali_alt_sagtik.Visible = true;//VARSAYILAN GÖSTERME
                acik_alt_menu.Visible = false;//VARSAYILAN GİZLİLİK
                acik_alt_sagtik.Visible = false;//VARSAYILAN GİZLİLİK
                this.Height = 522;//VARSAYILAN PENCERE BOYUTU
            }
        }

        private void musteri_hakkinda_bilgi_label_MouseMove(object sender, MouseEventArgs e)
        {
            musteri_hakkinda_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ DEĞİŞTİRME
            musteri_hakkinda_bilgi_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi2.png");//GÖRSEL EFEKT OLUŞTURMA
            musteri_hakkinda_bilgi_pb2.Image = Image.FromFile(@"image\yuvarlak_bilgi2.png");//GÖRSEL EFEKT OLUŞTURMA
        }

        private void musteri_hakkinda_bilgi_label_MouseLeave(object sender, EventArgs e)
        {
            musteri_hakkinda_bilgi_label.ForeColor = this.ForeColor;//VARSAYILAN YAZI RENGİ
            musteri_hakkinda_bilgi_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");//VARSAYILAN GÖRSEL
            musteri_hakkinda_bilgi_pb2.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");//VARSAYILAN GÖRSEL
        }

        private void tc_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilen_tc();//SEÇİLEN MÜŞTERİ HAKKINDA BİLGİ VERME
        }
        private void secilen_tc()//MÜŞTERİ BİLGİLERİ FOKSİYON
        {
            try
            {
                bilgi_label.Text = "";//YENİ BİLGİ İÇİN TEMİZLİK
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from musteri_tablosu where tcno='" + tc_combo.SelectedItem + "'", baglanti);//TC GÖRE BİLGİLERİ ÇEKME
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    musteri_id = oku["musteri_id"].ToString();//İŞLEMLERDE KULLANILMAK İÇİN SAKLAMAK
                    //PENCEREYE BİLGİ VERME
                    bilgi_label.Text += "TC NO:" + oku["tcno"].ToString() + "\nAd Soyad:" + oku["ad"].ToString() + " " + oku["soyad"].ToString();
                    if (Convert.ToByte(oku["cinsiyet"]) == 0)
                    {
                        bilgi_label.Text += "\nCinsiyet:Kadın";
                    }
                    else if (Convert.ToByte(oku["cinsiyet"]) == 1)
                    {
                        bilgi_label.Text += "\nCinsiyet:Erkek";
                    }
                    bilgi_label.Text += "\nİl/İlçe:" + oku["il"].ToString() + "/" + oku["ilce"].ToString() + "\nCep Telefonu(1):" + oku["cep1"].ToString() + "\nCep Telefonu(2):" + oku["cep2"].ToString() + "\nE-Posta Adresi:" + oku["eposta"].ToString() + "\nEv Adresi:" + oku["adres"].ToString() + "\nEhliyet No/Türü/Tarihi:" + oku["ehliyet_no"].ToString() + "/" + oku["ehliyet_turu"].ToString() + "/" + oku["ehliyet_tarihi"].ToString() + "\nAçıklama:" + oku["aciklama"].ToString();
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void iptalet_pb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }

        private void iptalet_pb_MouseMove(object sender, MouseEventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\musteri_iptal2.png");//GÖRSEL EFEKT
        }

        private void iptalet_pb_MouseLeave(object sender, EventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\musteri_iptal1.png");//VARSAYILAN RESİM
        }

        private void musteri_cikar_pb_Click(object sender, EventArgs e)
        {
            if (tc_combo.Items.Count > 0)//MÜŞTERİ VARSA
            {
                if (MessageBox.Show("SEÇİLEN TC NO:" + tc_combo.SelectedItem + " MÜŞTERİLENDEN ÇIKARILSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//ÇIKARILSIN MI SORUSU EVET İSE
                {
                    veritabanina_musteri_cikar();//MÜŞTERİ ÇIKARMA İŞLEM FOKSİYONU
                }
            }
            else
            {
                MessageBox.Show("MÜŞTERİ BULUNAMADI.", "MÜŞTERİ İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI 
                bilgi_label.Text = "";
            }
        }
        private void veritabanina_musteri_cikar()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("update musteri_tablosu set arsiv=0 where musteri_id=" + musteri_id, baglanti);//MÜŞTERİ ADI GÖRE ÇIKARMA KOMUTU
                komut.ExecuteNonQuery();
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(tc_combo.SelectedItem + " TC NOLU MÜŞTERİ ÇIKARILMIŞTIR.", "MÜŞTERİ ÇIKARMA", MessageBoxButtons.OK, MessageBoxIcon.Information);//BİLGİ VERME
                tcleri_getir();
                if (tc_combo.Items.Count > 0)//VAR MI
                {
                    tc_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
                }
                else
                {
                    bilgi_label.Text = "";//YOKSA SİLME
                }

            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void musteri_cikar_pb_MouseMove(object sender, MouseEventArgs e)
        {
            musteri_cikar_pb.Image = Image.FromFile(@"image\musteri_cikar2.png");//GÖRSEL EFEKT
        }

        private void musteri_cikar_pb_MouseLeave(object sender, EventArgs e)
        {
            musteri_cikar_pb.Image = Image.FromFile(@"image\musteri_cikar1.png");//VARSAYILAN GÖRSEL
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESI
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
