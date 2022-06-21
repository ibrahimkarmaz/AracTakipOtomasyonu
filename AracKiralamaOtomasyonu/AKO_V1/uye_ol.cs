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
    public partial class uye_ol : Form
    {
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ//VERİTABANI BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT//SQL İFADELERİNİN YAZILACAĞI YER
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ//VERİ ÇEKİLECEK İSE KULLANILAN KOMUT

        public uye_ol()
        {
            InitializeComponent();
        }

        private void uye_ol_Load(object sender, EventArgs e)
        {
            erkek_cb.Checked = true;//2 SEÇENEK ARASINDAN BİRİSİNİ SEÇME
            mail_uzantisi_cek();//MAİL UZANTILARI FOKSİYONU
            illeri_cek();//İLLERİ EKLEME FOKSİYONU
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU//PENCEREDE GÖSTERİLEN RESİM VE DÜZENİ
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME//NESNELERE EKLENEN ÖZELLİKLER

        }
        private void fotograflari_al_ve_duzenle()
        {
            //PENCERE EKLENEN GÖRSELLER.
            tc_pb.Image = Image.FromFile(@"image\kullanici.png");
            ad_pb.Image = Image.FromFile(@"image\isim.png");
            soyad_pb.Image = Image.FromFile(@"image\isim.png");
            cinsiyet_pb.Image = Image.FromFile(@"image\cinsiyet.png");
            il_pb.Image = Image.FromFile(@"image\sehir.png");
            ilce_pb.Image = Image.FromFile(@"image\sehir.png");
            dogum_yeri_pb.Image = Image.FromFile(@"image\yer.png");
            dogum_tarihi_pb.Image = Image.FromFile(@"image\tarih.png");
            cep_pb.Image = Image.FromFile(@"image\ceptelefonu.png");
            ev_pb.Image = Image.FromFile(@"image\evtelefonu.png");
            mail_pb.Image = Image.FromFile(@"image\mail.png");
            adres_pb.Image = Image.FromFile(@"image\evadresi.png");
            kullanici_pb.Image = Image.FromFile(@"image\kullanici.png");
            parola1_pb.Image = Image.FromFile(@"image\password.png");
            parola2_pb.Image = Image.FromFile(@"image\password.png");
            onayla_pb.Image = Image.FromFile(@"image\ekle1.png");
            onayla_menu.Image = Image.FromFile(@"image\onayla1.png");
            uye_basvurusu_yap_sagtik.Image = Image.FromFile(@"image\onayla1.png");
            iptalet_pb.Image = Image.FromFile(@"image\iptal1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");
            uyari_pb.Image = Image.FromFile(@"image\uyari.png");
            parola_goster1_pb.Image = Image.FromFile(@"image\goz1.png");
            parola_goster2_pb.Image = Image.FromFile(@"image\goz1.png");

            //GÖRSELLERİN NESNE İÇİNE SIĞDIRIRMASI İÇİN GEREKEN KOMUT.
            tc_pb.SizeMode = ad_pb.SizeMode = soyad_pb.SizeMode = cinsiyet_pb.SizeMode = il_pb.SizeMode = ilce_pb.SizeMode = dogum_yeri_pb.SizeMode = dogum_tarihi_pb.SizeMode = cep_pb.SizeMode = ev_pb.SizeMode = mail_pb.SizeMode = adres_pb.SizeMode = kullanici_pb.SizeMode = parola1_pb.SizeMode = parola2_pb.SizeMode = onayla_pb.SizeMode = iptalet_pb.SizeMode = uyari_pb.SizeMode = parola_goster1_pb.SizeMode = parola_goster2_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void mail_uzantisi_cek()
        {
            try//HATA ÖNLEME KODU
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTISI//VERİTABANINA BAĞLANTI
                komut = new SqlCommand("select RTRIM(uzanti_adi) AS uzanti from mail_uzantisi", baglanti);//VERİLERİ ÇEKME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT//ÇALIŞTIRMA VE ALMA
                while (oku.Read())//EĞER BİLGİ VARSA (BİRDEN FAZLA) ÇALIŞTIR
                {
                    mail_uzantisi_combo.Items.Add(oku["uzanti"]);//VERİLEN MAİL SEÇİM KUTUSUNA EKLENMESİ
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA//BAĞLANTI KAPATMA
                mail_uzantisi_combo.SelectedIndex = 1;//2. MAİL UZANTISINI SEÇME
            }
            catch (Exception HATA)//HATA OLACAKSA GİRECEĞİ YER
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA//BAĞLANTIYI KAPATMA
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.//PENCEREDE HATAYI GÖRTERME //HATA HAKKINDA BİLGİ VERME
            }

        }
        private void illeri_cek()
        {
            try//HATA ENGELLEYİCİ
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTISI//VERİTABANI BAĞLANTISI
                komut = new SqlCommand("select RTRIM(sehir) AS sehir from iller", baglanti);// ŞEHİRLERİ ÇEKTİĞİMİZ KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT//ÇALIŞTIRIP VERİLERİ TUTUĞUMUZ KOMUT
                while (oku.Read())//VERİ VARSA ÇALIŞACAK YER
                {
                    il_combo.Items.Add(oku["sehir"]);//İL SEÇİM KUTUSUNA EKLEME İŞLEMİ.
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA
                il_combo.SelectedIndex = 33;//İL SEÇİM KUTUSUNDA SEÇİLEN İL 'İSTANBUL'
            }
            catch (Exception HATA)//HATA OLURSA GİRECEĞİ YER
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA//BAĞLANTI KAPATMA
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.//PENCEREDE HATAYI GÖRTERME //HATA BİLGİSİNİ GÖSTERME
            }
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            ad_tb.MaxLength = soyad_tb.MaxLength = dogum_yeri_tb.MaxLength = 20;//VERİTABANINDAN KAYNALI EN FAZLA GİRİLEN KARAKTER
            mail_tb.MaxLength = 50;//VERİTABANINDAN KAYNALI EN FAZLA GİRİLEN KARAKTER
            adres_tb.MaxLength = 150;//VERİTABANINDAN KAYNALI EN FAZLA GİRİLEN KARAKTER
            kullanici_adi_tb.MaxLength = parola1_tb.MaxLength = parola2_tb.MaxLength = 14;//VERİTABANINDAN KAYNALI EN FAZLA GİRİLEN KARAKTER
            DateTime onsekizyil = DateTime.Now.AddYears(-18);//YAŞ SINIRI PROGRAMI 18 YAŞINDAN ALTINDA OLANLAR KULLANAMAYACAĞI İÇİN BU KISITLAMA GETİRİRDİ.
            zaman_datetime.Value = onsekizyil;//GÖRSELLEŞTİRİRDİ.

            zaman_datetime.MaxDate = onsekizyil;//şimdiki tarihten 18 yıl öncesi doğun kişiler programı kullanabilir.(Yasal işlemler için 18 yaş)
            parola1_tb.UseSystemPasswordChar = true;//PAROLA GİZLENDİ
            parola2_tb.UseSystemPasswordChar = true;//PAROLA GİZLENDİ
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//İL SEÇİMLERİNE GÖRE ÇALIŞAN BİLGİLER
        {
            ilce_combo.Items.Clear();//İLÇELER SİLİNİR
            try//HATA ENGELLEME
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTISI//VERİTABANI BAĞLANTISI//VERİTABANI BAĞLANTISI
                komut = new SqlCommand("select RTRIM(ilce) as ilce from ilceler where sehir='" + (il_combo.SelectedIndex + 1).ToString() + "'", baglanti);//İLE GÖRE İLÇE BİLGİLERİNİ SEÇME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT//KOMUTU ÇALIŞTIRMA VE VERİLERİ SAKLAMA
                while (oku.Read())//VARSA VERİLERİ ÇALIŞTIRMA
                {
                    ilce_combo.Items.Add(oku["ilce"]);//VERİLERİ İLÇE SEÇİM KUTUSUNA EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA//VERİTABANI BAĞLANTISINI KAPATMA//VERİTABANI BAĞLANTISINI KAPATMA
                ilce_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME //İLK İLÇEYİ SEÇME
            }
            catch (Exception HATA)//HATA VARSA ÇALIŞACAK YER
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.//PENCEREDE HATAYI GÖRTERME //PENCEREDE HATAYI GÖRTERME //PENCEREDE HATAYI GÖRTERME 
            }
        }

        private void pictureBox16_MouseMove(object sender, MouseEventArgs e)
        {
            onayla_pb.Image = Image.FromFile(@"image\ekle2.png");//EFEKT GÖRSELİ
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            onayla_pb.Image = Image.FromFile(@"image\ekle1.png");//EFEKT GÖRSELİ ESKI HALINE GETİRME//EFEKT GÖRSELİ ESKI HALINE GETİRME
        }

        private void pictureBox17_MouseMove(object sender, MouseEventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\iptal2.png");//EFEKT GÖRSELİ
        }

        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\iptal1.png");//EFEKT GÖRSELİ ESKI HALINE GETİRME
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR//ÇIKIŞ İSLEMİ İÇİN ONAY ALMA
            {
                this.Close();//PENCEREYİ KAPATMA KOMUTU
            }

        }
        bool kullanici_adi_varmi = false;//VERİTABANINDA KULLANICININ VAR OLUP OLMAMASI İÇİN YAPILAN KONTROL DEĞERİ
        private void kullanici_adi_kontrol()//VERİTABANINDA KULLANICININ VAR OLUP OLMAMASI İÇİN YAPILAN KONTROL FOKSİYONU
        {
            try//HATA ENGELLEYİCİ
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTISI
                komut = new SqlCommand("select * from hesap_tablosu where kullanici_adi='" + kullanici_adi_tb.Text + "'", baglanti);//SİSTEMDE AYNI KULLANICI ADI İLE VERİ VARMI
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT//KOMUTUN ÇALIŞIP VERİNİN SAKLANDIĞI YER
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.//VARSA ÇALIŞTI YER
                {
                    kullanici_adi_varmi = true;//KULLANICI VARSA 'DOĞRU' OLDUĞU YER (SİSTEME EKLERKEN ENGELLEME)
                }
                else
                {
                    kullanici_adi_varmi = false;//KULLANICININ 'YANLIŞ' OLDUĞU YER (SİSTEME EKLEMEDE SORUN YOK)
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA
            }
            catch (Exception HATA)//HATA OLURSA ÇALIŞACAK YER
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void onayla_pb_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tc_masketb.Text) == false)//TC NONUN BOŞ OLMAMA DURUMU
            {
                if (tc_masketb.Text.Count() == 11)//TC NONUN EKSİK GİRİRME DURUMU
                {
                    if (ad_tb.Text != "")//AD BİLGİSİNİN BOŞ OLMAMASI
                    {
                        if (soyad_tb.Text != "")//SOYAD BİLGİSİNİN BOŞ OLMAMASI
                        {
                            if (dogum_yeri_tb.Text != "")// DOĞUM YERİ BİLGİSİNİN BOŞ OLMAMASI
                            {
                                if (cep_masketb.Text != "(   )    -")//CEP TELEFONUNU BİLGİSİNİN BOŞ OLMAMASI
                                {
                                    if (cep_masketb.Text.Count() == 14)//CEP TELEFONUNU EKSİK OLMAMASI
                                    {
                                        if (ev_masketb.Text != "(   )    -")//EV TELEFONUNUN BİLGİSİNİN BOŞ OLMAMASI
                                        {
                                            if (ev_masketb.Text.Count() == 14)//EV TELEFONUNUN EKSİK OLMAMASI
                                            {
                                                if (mail_tb.Text != "")//E POSTA ADRESİNİN BİLGİSİNİN BOŞ OLMAMASI
                                                {
                                                    if (adres_tb.Text != "")//ADRESİN BİLGİSİNİN BOŞ OLMAMASI
                                                    {
                                                        if (kullanici_adi_tb.Text.Count() >= 8 && kullanici_adi_tb.Text.Count() <= 14)//KULLANICI ADININ 8-14 KARAKTER ARASI OLMASI
                                                        {
                                                            kullanici_adi_kontrol();//KULLANICI KONTROL FOKSIYONU
                                                            if (kullanici_adi_varmi != true)//EĞER SİSTEMDE YOKSA DEVAM ET
                                                            {
                                                                if (parola1_tb.Text.Count() >= 8 && parola1_tb.Text.Count() <= 14)//PAROLA 8-14 KARAKTERLI OLMALI
                                                                {
                                                                    if (parola2_tb.Text.Count() >= 8 && parola2_tb.Text.Count() <= 14)//PAROLA 8-14 KARAKTERLI OLMALI
                                                                    {
                                                                        if (parola1_tb.Text == parola2_tb.Text)//PAROLA DOĞRULANMALI
                                                                        {
                                                                            if (bilgi_uyari_checkbox.Checked == true)//BİLGİLENDİRME VE UYARILARI ANLADIM
                                                                            {
                                                                                kaydet();//SİSTEME BAŞVURU FOKSİYONU
                                                                            }
                                                                            else
                                                                            {
                                                                                MessageBox.Show("BİLGİLENDİRME VE UYARILARI OKUDUM/ANLADIM İŞARETLEYINIZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI//HATALI GİRİŞTE VERİLEN UYARI MESAJI//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            MessageBox.Show("PAROLA İLE PAROLA TEKRAR AYNI DEĞİLDİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("PAROLA TEKRAR EN AZ 8 HANELİ OLMALI...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("PAROLA EN AZ 8 HANELİ OLMALI...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("BU KULLANICI ADI KULLANILMAKTADIR\nFARKLI BİR KULLANICI ADI GİRİNİZ... ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);//KULLANICI VARDIR HATASI
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("KULLANICI ADI EN AZ 8 HANELİ OLMALI...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("ADRES BİLGİLERİNİZİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("E-POSTA ADRES BİLGİLERİNİZİ DOLDURUNUZ VE SEÇİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("EV TELEFONU NUMARANIZ EKSİKTİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("EV TELEFONU NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("CEP TELEFONU NUMARANIZ EKSİKTİR", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("CEP TELEFONU NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                                }
                            }
                            else
                            {
                                MessageBox.Show("DOĞUM YERİNİZİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                            }
                        }
                        else
                        {
                            MessageBox.Show("SOYADINIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                        }
                    }
                    else
                    {
                        MessageBox.Show("ADINIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                    }
                }
                else
                {
                    MessageBox.Show("TC KİMLİK NUMARANIZ EKSİKTİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
                }
            }
            else
            {
                MessageBox.Show("TC KİMLİK NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//HATALI GİRİŞTE VERİLEN UYARI MESAJI
            }
        }

        private void kaydet()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTISI
                if (erkek_cb.Checked == true)//ERKEK İÇİN ÇALISILACAK YER
                {
                    komut = new SqlCommand("insert into personel_tablosu values('" + tc_masketb.Text + "','" + ad_tb.Text + "','" + soyad_tb.Text + "',1,'" + il_combo.Text + "','" + ilce_combo.Text + "','" + dogum_yeri_tb.Text + "','" + zaman_datetime.Value.ToShortDateString() + "','" + cep_masketb.Text + "','" + ev_masketb.Text + "','" + (mail_tb.Text + "@" + mail_uzantisi_combo.Text) + "','" + adres_tb.Text + "',2,0)", baglanti);//ERKEK PERSONEL BAŞVURU BİLGİLERİ
                }
                else if (kadin_cb.Checked == true)//KADIN İÇİN ÇALISILACAK YER
                {
                    komut = new SqlCommand("insert into personel_tablosu values('" + tc_masketb.Text + "','" + ad_tb.Text + "','" + soyad_tb.Text + "',0,'" + il_combo.Text + "','" + ilce_combo.Text + "','" + dogum_yeri_tb.Text + "','" + zaman_datetime.Value.ToShortDateString() + "','" + cep_masketb.Text + "','" + ev_masketb.Text + "','" + (mail_tb.Text + "@" + mail_uzantisi_combo.Text) + "','" + adres_tb.Text + "',2,0)", baglanti);//KADIN PERSONEL BAŞVURU BİLGİLERİ
                }
                komut.ExecuteNonQuery();//SQL İFADELERİNİN ÇALIŞTIRIRDIĞI YER//SQL İFADELERİNİN ÇALIŞTIRIRDIĞI YER
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA
                //Hesaplanın eklendiği kod
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTISI
                komut = new SqlCommand("insert into hesap_tablosu values('" + tc_masketb.Text + "','" + kullanici_adi_tb.Text + "','" + parola1_tb.Text + "',2,0)", baglanti);//SİSTEME GİRİŞ İÇİN GEREKEN HESAP BİLGİLERİ KULLANICI ADI VS
                komut.ExecuteNonQuery();//SQL İFADELERİNİN ÇALIŞTIRIRDIĞI YER
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA
                //onaylama_islemleri
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTISI
                komut = new SqlCommand("insert into onay_tablosu values('" + tc_masketb.Text + "',0,1)", baglanti);//BAŞVURU İÇİN ONAY TABLOLARINA EKLEME
                komut.ExecuteNonQuery();//SQL İFADELERİNİN ÇALIŞTIRIRDIĞI YER
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA

                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTISI
                komut = new SqlCommand("insert into hesap_kurtarma_tablosu(tcno,arsiv) values('" + tc_masketb.Text + "',0)", baglanti);//HESAP KURTARMA İŞLEMİNİN GERÇEKLEŞMESİ İÇİN KULLANILAN KOMUT
                komut.ExecuteNonQuery();//SQL İFADELERİNİN ÇALIŞTIRIRDIĞI YER
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA

                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTISI
                komut = new SqlCommand("insert into ozellestirme_tablosu values('" + tc_masketb.Text + "',255,255,255,0,0,0,1)", baglanti);//RENK ÖZELLİĞİ ARKAPLAN:BEYAZ YAZI:SİYAH TÜM PENCERELERDE UYGULANIR
                komut.ExecuteNonQuery();//SQL İFADELERİNİN ÇALIŞTIRIRDIĞI YER
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA

                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTISI
                komut = new SqlCommand("insert into personel_yetkileri values('" + tc_masketb.Text + "','ARAÇ ARAMA-ARAÇ EKLE-ARAÇ LİSTESİ-MÜŞTERİ ARAMA-MÜŞTERİ EKLE-MÜŞTERİ LİSTESİ-TESLİM AL-KİRALAMA İŞLEMLERİ ARAMA-KİRALAMA İŞLEMLERİ-KİRALAMA İŞLEMİNİ İPTAL ET')", baglanti);//PERSONEL YETKİLERİ
                komut.ExecuteNonQuery();//SQL İFADELERİNİN ÇALIŞTIRIRDIĞI YER
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA

                string resim_uzantisi=@"image\profil_fotograflari\varsayilanlar\varsayilan0.png";//İLK RESİM
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTISI
                komut = new SqlCommand("insert into profil_fotograf_tablosu values('" + tc_masketb.Text + "','VARSAYILAN FOTOĞRAF','" + resim_uzantisi + "')", baglanti);//RESİM UZANTISI
                komut.ExecuteNonQuery();//SQL İFADELERİNİN ÇALIŞTIRIRDIĞI YER
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA

                MessageBox.Show(tc_masketb.Text + " TC KİMLİK NOLU ADI:" + ad_tb.Text.ToUpper() + " SOYADI:" + soyad_tb.Text.ToUpper() + "\nBAŞVURU YAPILMIŞTIR.", "BAŞVURU İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);//PERSONEL BAŞVURU YAPTIĞI HAKKINDA MESAJ BİLGİ.
                this.Close();//SPAM OLMASIN DİYE PENCEREYİ KAPATMA.
            }
            catch (Exception)//HATA VARSA AŞAĞAYA
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISINI KAPATMA
                MessageBox.Show("BAŞVURU BAŞARISIZ OLDU.\nKULLANICI ONAY BEKLİYOR VEYA REDDEDİLMİŞ OLABİLİR.\n\nYAPILABİLECEKLER:\n1-'ÜYELİK DURUMU SORGULAMA' PENCERESİNDEN DURUMUNUZU ÖĞRENEBİLİRSİNİZ...\n2-'ÜYELİK YENİLE' PENCERESİNDEN BAŞVURUNUZU TEKRARLAYABİLİRSİNİZ.", "BAŞVURU İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Error);//İLK BAŞTA TC HATA VEREBİLİR (VAR OLDUĞUNDAN) ONU ENGELLEME VE BİLGİLENDİRME
            }
        }
        bool aktif_pasif = false;//Parolanın karakter olarak mi veya '*' olacağını belirleme değişkeni
        private void parola_goster1_pb_Click(object sender, EventArgs e)
        {
            if (aktif_pasif == false)
            {
                parola1_tb.UseSystemPasswordChar = false;//PAROLAYI KARAKTERLERE DÖNÜŞTÜRME
                parola2_tb.UseSystemPasswordChar = false;//PAROLAYI KARAKTERLERE DÖNÜŞTÜRME
                parola_goster1_pb.Image = Image.FromFile(@"image\goz2.png");//EFEKT GÖRSELİ
                parola_goster2_pb.Image = Image.FromFile(@"image\goz2.png");//EFEKT GÖRSELİ
                aktif_pasif = true;//PAROLA GÖZÜKÜYOR
            }
            else
            {
                parola1_tb.UseSystemPasswordChar = true;//PAROLAYI '*' DÖNÜŞTÜRME
                parola2_tb.UseSystemPasswordChar = true; //PAROLAYI '*' DÖNÜŞTÜRME
                parola_goster1_pb.Image = Image.FromFile(@"image\goz1.png");//EFEKT GÖRSELİ ESKI HALINE GETİRME
                parola_goster2_pb.Image = Image.FromFile(@"image\goz1.png");//EFEKT GÖRSELİ ESKI HALINE GETİRME
                aktif_pasif = false;//PAROLA GİZLE
            }
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {
            //YARDIM PENCERESİNİ AÇAR
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
