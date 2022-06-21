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
    public partial class parola_yenile : Form
    {
        public parola_yenile()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        string parola = "";//VERİTABANINDA Kİ PAROLAYI SAKLAMAK İÇİN KULLANILIYOR
        private void parola_yenile_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            gecerli_parolayi_getir();//VERİTABANINDA Kİ PAROLA
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void gecerli_parolayi_getir()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(parola) as PS from hesap_tablosu where tcno='" + giris_penceresi.tcno + "'", baglanti);//PAROLAYI ÇEKME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    parola = oku["PS"].ToString();//PAROLAYI SAKLAMA DEĞİŞKENİ
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void fotograflari_al_ve_duzenle()
        {//VARSAYILAN GÖRSELLER
            gecerli_parola_pb.Image = Image.FromFile(@"image\password.png");
            parola1_pb.Image = Image.FromFile(@"image\yeni_parola_tb.png");
            parola2_pb.Image = Image.FromFile(@"image\yeni_parola_tb.png");
            uyari_pb.Image = Image.FromFile(@"image\uyari.png");
            parola_goster1_pb.Image = Image.FromFile(@"image\goz1.png");
            parola_goster2_pb.Image = Image.FromFile(@"image\goz1.png");
            gecerli_parolayi_goster_pb.Image = Image.FromFile(@"image\goz1.png");
            gecerli_parola_pb.SizeMode = gecerli_parolayi_goster_pb.SizeMode=parola_goster1_pb.SizeMode = parola_goster2_pb.SizeMode = parola1_pb.SizeMode = parola2_pb.SizeMode = uyari_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }

        private void kisitlamalar_ve_duzenlemeler()
        {//PAROLALARI GİZLEME İŞLEMLERİ YAPILDI
            parola1_tb.UseSystemPasswordChar = true;
            parola2_tb.UseSystemPasswordChar = true;
            gecerli_parola_tb.UseSystemPasswordChar = true;
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKENDIRME SONRASI SORUNLARI DÜZENLEME
            yeni_parola_gb.ForeColor = this.ForeColor;
        }
        bool aktif_pasif=false,pasif_aktif2 = false;
        private void parola_goster1_pb_Click(object sender, EventArgs e)
        {//YENİ PAROLA VE PAROLA TEKRARLARIN KARAKTER GÖSTERME GİZLEME İŞLEMLERİ
            if (aktif_pasif == false)
            {
                parola1_tb.UseSystemPasswordChar = false;
                parola2_tb.UseSystemPasswordChar = false;
                parola_goster1_pb.Image = Image.FromFile(@"image\goz2.png");
                parola_goster2_pb.Image = Image.FromFile(@"image\goz2.png");
                aktif_pasif = true;
            }
            else
            {
                parola1_tb.UseSystemPasswordChar = true;
                parola2_tb.UseSystemPasswordChar = true;
                parola_goster1_pb.Image = Image.FromFile(@"image\goz1.png");
                parola_goster2_pb.Image = Image.FromFile(@"image\goz1.png");
                aktif_pasif = false;
            }
        }

        private void parola_goster2_pb_Click(object sender, EventArgs e)
        {//YENİ PAROLA VE PAROLA TEKRARLARIN KARAKTER GÖSTERME GİZLEME İŞLEMLERİ
            if (aktif_pasif == false)
            {
                parola1_tb.UseSystemPasswordChar = false;
                parola2_tb.UseSystemPasswordChar = false;
                parola_goster1_pb.Image = Image.FromFile(@"image\goz2.png");
                parola_goster2_pb.Image = Image.FromFile(@"image\goz2.png");
                aktif_pasif = true;
            }
            else
            {
                parola1_tb.UseSystemPasswordChar = true;
                parola2_tb.UseSystemPasswordChar = true;
                parola_goster1_pb.Image = Image.FromFile(@"image\goz1.png");
                parola_goster2_pb.Image = Image.FromFile(@"image\goz1.png");
                aktif_pasif = false;
            }
        }
        private void gecerli_parolayi_goster_pb_Click(object sender, EventArgs e)
        {//GEÇERLI PAROLA KARAKTER GÖSTERME GİZLEME İŞLEMLERİ
            if (pasif_aktif2 == false)
            {
                gecerli_parola_tb.UseSystemPasswordChar = false;
                gecerli_parolayi_goster_pb.Image = Image.FromFile(@"image\goz2.png");
                pasif_aktif2 = true;
            }
            else
            {
                gecerli_parola_tb.UseSystemPasswordChar = true;
                gecerli_parolayi_goster_pb.Image = Image.FromFile(@"image\goz1.png");
                pasif_aktif2 = false;
            }
        }

        private void iptal_et_label_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }

        private void iptal_et_label_MouseMove(object sender, MouseEventArgs e)
        {
            iptal_et_label.ForeColor = Color.Red;//YAZI RENGİ DEĞİŞTİRME
        }

        private void iptal_et_label_MouseLeave(object sender, EventArgs e)
        {
            iptal_et_label.ForeColor = this.ForeColor;//VARSAYILAN YAZI RENGİ
        }

        private void onayla_label_Click(object sender, EventArgs e)
        {
            if (parola==gecerli_parola_tb.Text)//GEÇERLİ PAROLA DOĞRU MU
            {
                if (parola1_tb.Text.Length >= 8 || parola2_tb.Text.Length >= 8)//YENİ PAROLA 8 KARAKTERDEN FAZLA OLMALI(EN FAZLA GİRİLEN KARAKTER SAYISI 14 İLE SINIRLANDI KUTULAR)
                {
                    if (parola1_tb.Text == parola2_tb.Text)//YENİ PAROLA VE PAROLA TEKRAR DOĞRUMU
                    {
                        parola_yenileme();//PAROLAYI YENİLEME
                    }
                    else
                    {
                        MessageBox.Show("YENİ PAROLA İLE PAROLA TEKRAR AYNI DEĞİLDİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//PAROLA UYUSMAZLIĞI
                    }
                }
                else
                {
                    MessageBox.Show("YENİ PAROLANIZ 8 HANE VEYA DAHA FAZLA OLMALI", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//8 HANELI OLMALI
                }
            }
            else
            {
                MessageBox.Show("GEÇERLİ PAROLA HATALI", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//GEÇERLI PAROLA HATALI
            }
           
        }
        private void parola_yenileme()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("update hesap_tablosu set parola='" + parola1_tb.Text + "' where tcno='" + giris_penceresi.tcno+ "'", baglanti);//GEÇERLI PAROLAYI DEĞİŞTİRME KOMUTU
                komut.ExecuteNonQuery();//KOMUTLARI ÇALIŞTIRMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show("PAROLANIZ YENİLENDİ.", "PAROLA YENİLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);//KULLANICIYA BİLGİ VERME
                this.Close();//PENCEREYI KAPATMA
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void onayla_label_MouseMove(object sender, MouseEventArgs e)
        {
            onayla_label.ForeColor = Color.Red;//YAZI RENGİNİ DEĞİŞTİRME
        }

        private void onayla_label_MouseLeave(object sender, EventArgs e)
        {
            onayla_label.ForeColor = this.ForeColor;//VARSAYILAN YAZI
        }
    }
}
