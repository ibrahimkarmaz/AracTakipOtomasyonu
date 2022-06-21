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
using System.Net.Mail;

namespace WindowsFormsApplication1
{
    public partial class parolami_unuttum : Form
    {
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        Random uret = new Random();
        MailMessage eposta = new MailMessage();
        public parolami_unuttum()
        {
            InitializeComponent();
        }

        private void parolami_unuttum_Load(object sender, EventArgs e)
        {
            //Mesaj gönderme ile şifre değişikliği yapma(Admine veya müdüre) Onlar ise bakacak onaylarlarsa e postaya mesaj göndersin şifreyi.(Yeni Şifre oluşturulsun oyle gönderirsin.)
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
        }
        private void fotograflari_al_ve_duzenle()
        {
            //GÖRSELLERİN ÇEKİLDİĞİ YER
            kullanici_adi_pb.Image = Image.FromFile(@"image\kullanici.png");
            yontem_pb.Image = Image.FromFile(@"image\yontem.png");
            devam_et_pb.Image = Image.FromFile(@"image\devam_et1.png");

            soru_pb.Image = Image.FromFile(@"image\soru_cevap.png");
            cevap_pb.Image = Image.FromFile(@"image\soru_cevap.png");

            kod_pb.Image = Image.FromFile(@"image\mail_parola.png");
            parola1_pb.Image = Image.FromFile(@"image\yeni_parola_tb.png");
            parola2_pb.Image = Image.FromFile(@"image\yeni_parola_tb.png");
            uyari_pb.Image = Image.FromFile(@"image\uyari.png");
            parola_goster1_pb.Image = Image.FromFile(@"image\goz1.png");
            parola_goster2_pb.Image = Image.FromFile(@"image\goz1.png");


            yuz1_pb.Image = Image.FromFile(@"image\guvenlik_image\yuz1.png");
            yuz2_pb.Image = Image.FromFile(@"image\guvenlik_image\yuz2.png");
            yuz3_pb.Image = Image.FromFile(@"image\guvenlik_image\yuz3.png");
            yuz4_pb.Image = Image.FromFile(@"image\guvenlik_image\yuz4.png");
            yuz5_pb.Image = Image.FromFile(@"image\guvenlik_image\yuz5.png");

            cizgi_resim1_pb.Image = Image.FromFile(@"image\guvenlik_image\cizgi_karakter1.png");
            cizgi_resim2_pb.Image = Image.FromFile(@"image\guvenlik_image\cizgi_karakter2.png");
            cizgi_resim3_pb.Image = Image.FromFile(@"image\guvenlik_image\cizgi_karakter3.png");
            cizgi_resim4_pb.Image = Image.FromFile(@"image\guvenlik_image\cizgi_karakter4.png");
            cizgi_resim5_pb.Image = Image.FromFile(@"image\guvenlik_image\cizgi_karakter5.png");

            hayvan1_pb.Image = Image.FromFile(@"image\guvenlik_image\hayvan1.png");
            hayvan2_pb.Image = Image.FromFile(@"image\guvenlik_image\hayvan2.png");
            hayvan3_pb.Image = Image.FromFile(@"image\guvenlik_image\hayvan3.png");
            hayvan4_pb.Image = Image.FromFile(@"image\guvenlik_image\hayvan4.png");
            hayvan5_pb.Image = Image.FromFile(@"image\guvenlik_image\hayvan5.png");

            film_karakter1_pb.Image = Image.FromFile(@"image\guvenlik_image\karakter1.png");
            film_karakter2_pb.Image = Image.FromFile(@"image\guvenlik_image\karakter2.png");
            film_karakter3_pb.Image = Image.FromFile(@"image\guvenlik_image\karakter3.png");
            film_karakter4_pb.Image = Image.FromFile(@"image\guvenlik_image\karakter4.png");
            film_karakter5_pb.Image = Image.FromFile(@"image\guvenlik_image\karakter5.png");

            silah1_pb.Image = Image.FromFile(@"image\guvenlik_image\silah1.png");
            silah2_pb.Image = Image.FromFile(@"image\guvenlik_image\silah2.png");
            silah3_pb.Image = Image.FromFile(@"image\guvenlik_image\silah3.png");
            silah4_pb.Image = Image.FromFile(@"image\guvenlik_image\silah4.png");
            silah5_pb.Image = Image.FromFile(@"image\guvenlik_image\silah5.png");
            kullanici_adi_pb.SizeMode = yontem_pb.SizeMode = devam_et_pb.SizeMode = parola_goster1_pb.SizeMode = parola_goster2_pb.SizeMode = parola1_pb.SizeMode = parola2_pb.SizeMode = uyari_pb.SizeMode = kod_pb.SizeMode = soru_pb.SizeMode = cevap_pb.SizeMode = cizgi_resim1_pb.SizeMode = cizgi_resim2_pb.SizeMode = cizgi_resim3_pb.SizeMode = cizgi_resim4_pb.SizeMode = cizgi_resim5_pb.SizeMode = yuz1_pb.SizeMode = yuz2_pb.SizeMode = yuz3_pb.SizeMode = yuz4_pb.SizeMode = yuz5_pb.SizeMode = hayvan1_pb.SizeMode = hayvan2_pb.SizeMode = hayvan3_pb.SizeMode = hayvan4_pb.SizeMode = hayvan5_pb.SizeMode = film_karakter1_pb.SizeMode = film_karakter2_pb.SizeMode = film_karakter3_pb.SizeMode = film_karakter4_pb.SizeMode = film_karakter5_pb.SizeMode = silah1_pb.SizeMode = silah2_pb.SizeMode = silah3_pb.SizeMode = silah4_pb.SizeMode = silah5_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }

        private void kisitlamalar_ve_duzenlemeler()
        {
            kullanici_adi_tb.MaxLength = parola1_tb.MaxLength = parola2_tb.MaxLength = 14;//VERİTABANINDAN KAYNAKLI EN FAZLA YAZILABİLECEK KARAKTER KISITLAMASI
            cevap_tb.MaxLength = 20;//VERİTABANINDAN KAYNAKLI EN FAZLA YAZILABİLECEK KARAKTER KISITLAMASI
            parola1_tb.UseSystemPasswordChar = true;//PAROLANIN GÖSTERİLDİĞİ YER
            parola2_tb.UseSystemPasswordChar = true;//PAROLANIN GÖSTERİLDİĞİ YER

            kullanici_adi_tb.Text = "Kullanıcı Adı";

            yontem_combo.Items.Add("E-Posta");
            yontem_combo.Items.Add("Güvenlik Soruları");
            yontem_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME //SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 

            mail_onay_gb.Visible = yeni_parola_gb.Visible = soru_cevap_gb.Visible = false;//GRUPLARI GİZLEME
            this.Width = 360;//İLK GENİŞLİK
            this.Height = 160;//İLK YÜKSEKLİK
        }
        string guvenlik_kodu = "";//OLUŞTURULAN KODU SAKLAMA DEĞİŞKENİ
        private void guvenlik_kodu_olustur(int kacbasamakli)//ÇAĞRILIRKEN GİRİLEN RAKAMA GÖRE GÜVENLİK KODU OLUŞTURMA FOKSİYONU //ÇAĞRILIRKEN GİRİLEN RAKAMA GÖRE GÜVENLİK KODU OLUŞTURMA FOKSİYONU 
        {
            guvenlik_kodu = "";//VERİYİ SIFIRLAMA
            for (int i = 0; i < kacbasamakli; i++)//GÜVENLİK KODU KAÇ BASAMAKLI OLACAKSA DÖNGÜYE GİRER 
            {
                guvenlik_kodu += uret.Next(0, 9).ToString();//RASGELE 0-9 ARASI SAYI ÜRETİLİR.//RASGELE 0-9 ARASI SAYI ÜRETİLİR.
            }
        }
        private void mail_gonder(string mail_adresi)//SEÇİM KUTUSUNDAN E-POSTA PAROLA DEĞİŞTİRMEYİ SEÇTİĞİNDE ÇALIŞIR..
        {
            try
            {
                guvenlik_kodu_olustur(6);//6 BASAMAKLI GÜVENLİK KODU OLUŞTURMA FOKSİYONU//6 BASAMAKLI GÜVENLİK KODU OLUŞTURMA FOKSİYONU
                eposta.From = new MailAddress("halilprogram@hotmail.com");//GÖNDEREN KİŞİ 
                eposta.To.Add(mail_adresi.ToString());//GÖNDERİLECEK KİŞİ
                eposta.Subject = "HESAP KURTARMA KODU";//KONU
                eposta.Body = "Kod:" + guvenlik_kodu + "\n\nNot:Bu meseja geri dönüş yapmayınız.";

                SmtpClient smtp = new SmtpClient();

                smtp.Credentials = new System.Net.NetworkCredential("halilprogram@hotmail.com", "Halil123456");//GÖNDERENİN E-POSTA ADRESİ VE PAROLASI
                smtp.Host = "smtp.live.com";//SUNUCU
                smtp.EnableSsl = true;//PROTEKOL
                smtp.Port = 587;

                smtp.Send(eposta);//GÖNDERME İŞLEMİ
                mail_adresi_label.Text = "Gönderildi:" + mail_adresi.ToString();//PENCEREYİ BİLGİLENDİRME
                mail_adresi_label.ForeColor = Color.Black;//GÖNDERİLDİ RENGİ
            }
            catch (Exception)
            {
                mail_adresi_label.Text = "Kodunuz:Gönderilemedi(İnternet veya e-posta kaynaklı).";//PENCEREYİ BİLGİLENDİRME
                mail_adresi_label.ForeColor = Color.Red;//HATA RENGİ
            }
        }
        private void devam_et_pb_Click(object sender, EventArgs e)
        {
            kontrol_et_ve_gec();//HANGİ İŞLEME GÖRE NE YAPILACAĞI FOKSİYONU (E-POSTA, GÜVENLİK SORULARI)
        }
        int deger1, deger2, deger3, deger4, deger5, secilen1, secilen2, secilen3, secilen4, secilen5;
        string sorunun_cevap = "", mail_adresi_str = "";
        private bool kontrol_et_ve_gec()
        {
            deger1 = deger2 = deger3 = deger4 = deger5 = secilen1 = secilen2 = secilen3 = secilen4 = secilen5 = 1;//GÜVENLİK İŞLEMLERİNDE SEÇİLEN RESİMLERİN BİLGİSİ
            try
            {
                if (kullanici_adi_tb.Text != "")
                {
                    if (yontem_combo.SelectedIndex == 0)//E POSTA İÇİN ÇALIŞACAK KODLAR
                    {
                        baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                        komut = new SqlCommand("select personel_tablosu.eposta from hesap_tablosu inner join personel_tablosu on hesap_tablosu.tcno=personel_tablosu.tcno where kullanici_adi='" + kullanici_adi_tb.Text + "' and hesap_tablosu.arsiv=1", baglanti);
                        oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                        if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                        {
                            mail_adresi_str = oku["eposta"].ToString();//ÇEKİLEN VERİLERDEN EPOSTA BİLGİSİ ALINIYOR
                            mail_gonder(mail_adresi_str);//PAROLA DEĞİŞTİRME E-POSTASI GÖNDERİLİYOR
                            parola_belirleme_gb.Visible = false;//İLK GRUP GİZLENİYOR
                            mail_onay_gb.Location = new Point(12, 12);//YENİ GRUP KONUMU BELİRLENİYOR
                            this.Width = 396;//PENCERE GENİŞLİĞİ BELİRLENİYOR
                            this.Height = 140;//PENCERE YÜKSEKLİĞİ BELİRLENİYOR
                            mail_onay_gb.Visible = true;//VE YENİ GRUP KUTUSU GÖSTERİLİYOR
                        }
                        else
                        {
                            MessageBox.Show("KULLANICI BULUNAMADI.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//bilgilendirme
                        }
                        baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                    }
                    else if (yontem_combo.SelectedIndex == 1)//GÜVENLİK İÇİN ÇALIŞTIRILACAK KODLAR
                    {
                        baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                        komut = new SqlCommand("select * from hesap_tablosu inner join hesap_kurtarma_tablosu on hesap_tablosu.tcno=hesap_kurtarma_tablosu.tcno where kullanici_adi='" + kullanici_adi_tb.Text + "' and hesap_tablosu.arsiv=1", baglanti);//HESAP KURTARMA BİLGİLERİ KOMUTLARI
                        oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                        if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                        {
                            if (oku["guvenlik_sorusu"].ToString() != "")//EĞER GÜVENLIK SORUSU VARSA DOĞRU BLOĞUNA GİRER[KULLANILABİLMESİ İÇİN:SİSTEME GİRİP GÜVENLİK SORULARINI CEVAPLAMALIYDI.]
                            {
                                parola_belirleme_gb.Visible = false;//İLK GRUP GİZLENİYOR
                                soru_cevap_gb.Location = new Point(12, 12);//YENİ GRUP KONUMU BELİRLENİYOR
                                this.Width = 410;//PENCERE GENİŞLİĞİ BELİRLENİYOR
                                this.Height = 607;//PENCERE YÜKSEKLİĞİ BELİRLENİYOR
                                soru_cevap_gb.Visible = true;//YENİ GRUP KUTUSU GÖSTERİLİYOR
                                //GÜVENLİK BİLGİLERİ ÇEKİLİYOR...
                                soru_veri_label.Text = oku["guvenlik_sorusu"].ToString();
                                sorunun_cevap = oku["guvenlik_cevabi"].ToString();
                                deger1 = Convert.ToInt32(oku["secilen_yuz"]);
                                deger2 = Convert.ToInt32(oku["secilen_cizgi_film_karakteri"]);
                                deger3 = Convert.ToInt32(oku["secilen_hayvan"]);
                                deger4 = Convert.ToInt32(oku["secilen_film_karakteri"]);
                                deger5 = Convert.ToInt32(oku["secilen_silah"]);

                            }
                            else
                            {
                                if (MessageBox.Show("GÜVENLİK SORULARINIZ SİSTEME GÖZÜKMEMEKTEDİR.\n\nE-POSTA İLE PAROLAYI DÜZENLEMEK İÇİN TAMAM'A TIKLAYINIZ.", "SORU", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)//GÜVENLİK BİLGİLERİ YOKSA E POSTA İLE PAROLA DEĞİŞTİRME UYGULANSIN MI DİYE SORULUYOR TAMAM İSE
                                {
                                    yontem_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
                                    baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                                    kontrol_et_ve_gec();//TEKRAR FOKSİYON ÇAĞRILIYOR.
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("KULLANICI BULUNAMADI.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//VAR OLMAYAN KULLANICI HATASI 
                        }
                        baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                    }
                }
                else
                {
                    MessageBox.Show("KULLANICI ADINIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI
                }
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
            return true;

        }
        private void devam_et_pb_MouseMove(object sender, MouseEventArgs e)
        {
            devam_et_pb.Image = Image.FromFile(@"image\devam_et2.png");//EFEKT GÖRSELLERİ
        }

        private void devam_et_pb_MouseLeave(object sender, EventArgs e)
        {
            devam_et_pb.Image = Image.FromFile(@"image\devam_et1.png");//EFEKT GÖRSELLERİ ESKİ HALINE DÖNÜŞ
        }
        private void secilen_resimleri_kontrol_et()
        {
            //GÖRSELLERDEN HANGİ RESİMLERİN SEÇİLDİĞİ HAKKINDA BİLGİLER
            //Yüz ifadesi secilenler
            if (yuz1_rb.Checked == true)
            {
                secilen1 = 1;
            }
            else if (yuz2_rb.Checked == true)
            {
                secilen1 = 2;
            }
            else if (yuz3_rb.Checked == true)
            {
                secilen1 = 3;
            }
            else if (yuz4_rb.Checked == true)
            {
                secilen1 = 4;
            }
            else if (yuz5_rb.Checked == true)
            {
                secilen1 = 5;
            }

            //Çizgi dizi karakterinde secilenler
            if (cizgi_resim1_rb.Checked == true)
            {
                secilen2 = 1;
            }
            else if (cizgi_resim2_rb.Checked == true)
            {
                secilen2 = 2;
            }
            else if (cizgi_resim3_rb.Checked == true)
            {
                secilen2 = 3;
            }
            else if (cizgi_resim4_rb.Checked == true)
            {
                secilen2 = 4;
            }
            else if (cizgi_resim5_rb.Checked == true)
            {
                secilen2 = 5;
            }

            //Hayvan Seçimi
            if (hayvan1_rb.Checked == true)
            {
                secilen3 = 1;
            }
            else if (hayvan2_rb.Checked == true)
            {
                secilen3 = 2;
            }
            else if (hayvan3_rb.Checked == true)
            {
                secilen3 = 3;
            }
            else if (hayvan4_rb.Checked == true)
            {
                secilen3 = 4;
            }
            else if (hayvan5_rb.Checked == true)
            {
                secilen3 = 5;
            }

            //Film Karakter seçimi
            if (film_karakter1_rb.Checked == true)
            {
                secilen4 = 1;
            }
            else if (film_karakter2_rb.Checked == true)
            {
                secilen4 = 2;
            }
            else if (film_karakter3_rb.Checked == true)
            {
                secilen4 = 3;
            }
            else if (film_karakter4_rb.Checked == true)
            {
                secilen4 = 4;
            }
            else if (film_karakter5_rb.Checked == true)
            {
                secilen4 = 5;
            }

            //Silah seçimi
            if (silah1_rb.Checked == true)
            {
                secilen5 = 1;
            }
            else if (silah2_rb.Checked == true)
            {
                secilen5 = 2;
            }
            else if (silah3_rb.Checked == true)
            {
                secilen5 = 3;
            }
            else if (silah4_rb.Checked == true)
            {
                secilen5 = 4;
            }
            else if (silah5_rb.Checked == true)
            {
                secilen5 = 5;
            }

        }

        private void tekrar_gonder_label_Click(object sender, EventArgs e)
        {
            mail_gonder(mail_adresi_str);//TEKRAR PAROLA YENİLEME KODU GÖNDERİR.
        }

        private void tekrar_gonder_label_MouseMove(object sender, MouseEventArgs e)
        {
            tekrar_gonder_label.ForeColor = Color.Red;//YAZI RENGİNİ DEĞİŞTİRİR.
        }

        private void tekrar_gonder_label_MouseLeave(object sender, EventArgs e)
        {
            tekrar_gonder_label.ForeColor = Color.Black;//YAZI RENGİNİ İLK HALINE DÖNDÜRÜR.
        }

        private void kod_tb_TextChanged(object sender, EventArgs e)//KOD KUTUSUNA KARAKTER GİRDİĞİNDE ÇALIŞIR.
        {
            if (kod_tb.Text == guvenlik_kodu)//E-POSTAYA GÖNDERİLEN GÜVENLİK KODU DOĞRU İSE;
            {
                mail_onay_gb.Visible = false;//ONAY GRUP GİZLENİYOR
                yeni_parola_gb.Location = new Point(12, 12);//PAROLA BELİRLEME GRUP YERİ DEĞİŞTİRİLİYOR
                this.Width = 396;//PENCERE GENİŞLİĞİ AYARLANIYOR
                this.Height = 240;//PENCERE YÜKSEKLİĞİ AYARLANIYOR
                yeni_parola_gb.Visible = true;//VE GRUP GÖSTERİLİYOR
            }
        }
        //RESİM SEÇİMLERİNİ BELİRLEME SATIR 375'DEN 500'DE KADAR OLAN BÖLÜM...
        private void yuz1_pb_Click(object sender, EventArgs e)
        {
            yuz1_rb.Checked = true;
        }

        private void yuz2_pb_Click(object sender, EventArgs e)
        {
            yuz2_rb.Checked = true;
        }

        private void yuz3_pb_Click(object sender, EventArgs e)
        {
            yuz3_rb.Checked = true;
        }

        private void yuz4_pb_Click(object sender, EventArgs e)
        {
            yuz4_rb.Checked = true;
        }

        private void yuz5_pb_Click(object sender, EventArgs e)
        {
            yuz5_rb.Checked = true;
        }

        private void cizgi_resim1_pb_Click(object sender, EventArgs e)
        {
            cizgi_resim1_rb.Checked = true;
        }

        private void cizgi_resim2_pb_Click(object sender, EventArgs e)
        {
            cizgi_resim2_rb.Checked = true;
        }

        private void cizgi_resim3_pb_Click(object sender, EventArgs e)
        {
            cizgi_resim3_rb.Checked = true;
        }

        private void cizgi_resim4_pb_Click(object sender, EventArgs e)
        {
            cizgi_resim4_rb.Checked = true;
        }

        private void cizgi_resim5_pb_Click(object sender, EventArgs e)
        {
            cizgi_resim5_rb.Checked = true;
        }

        private void hayvan1_pb_Click(object sender, EventArgs e)
        {
            hayvan1_rb.Checked = true;
        }

        private void hayvan2_pb_Click(object sender, EventArgs e)
        {
            hayvan2_rb.Checked = true;
        }

        private void hayvan3_pb_Click(object sender, EventArgs e)
        {
            hayvan3_rb.Checked = true;
        }

        private void hayvan4_pb_Click(object sender, EventArgs e)
        {
            hayvan4_rb.Checked = true;
        }

        private void hayvan5_pb_Click(object sender, EventArgs e)
        {
            hayvan5_rb.Checked = true;
        }

        private void film_karakter1_pb_Click(object sender, EventArgs e)
        {
            film_karakter1_rb.Checked = true;
        }

        private void film_karakter2_pb_Click(object sender, EventArgs e)
        {
            film_karakter2_rb.Checked = true;
        }

        private void film_karakter3_pb_Click(object sender, EventArgs e)
        {
            film_karakter3_rb.Checked = true;
        }

        private void film_karakter4_pb_Click(object sender, EventArgs e)
        {
            film_karakter4_rb.Checked = true;
        }

        private void film_karakter5_pb_Click(object sender, EventArgs e)
        {
            film_karakter5_rb.Checked = true;
        }

        private void silah1_pb_Click(object sender, EventArgs e)
        {
            silah1_rb.Checked = true;
        }

        private void silah2_pb_Click(object sender, EventArgs e)
        {
            silah2_rb.Checked = true;
        }

        private void silah3_pb_Click(object sender, EventArgs e)
        {
            silah3_rb.Checked = true;
        }

        private void silah4_pb_Click(object sender, EventArgs e)
        {
            silah4_rb.Checked = true;
        }

        private void silah5_pb_Click(object sender, EventArgs e)
        {
            silah5_rb.Checked = true;
        }

        sbyte sayac = 3;//3 HAK VERİLDİ.
        private void guven_onay_label_Click(object sender, EventArgs e)
        {
            secilen_resimleri_kontrol_et();//SEÇİLEN RESİMLER HANGİLERİ BELİRLEYEN FOKSİYON
            if (cevap_tb.Text == sorunun_cevap && secilen1 == deger1 && secilen2 == deger2 && secilen3 == deger3 && secilen4 == deger4 && secilen5 == deger5)//SEÇİLEN RESİMLER VE BİLGİLER VERİTABANINDA Kİ İLE AYNI MI DİYE KONTROL EDİLİYOR
            {
                soru_cevap_gb.Visible = false;//GRUP GİZLENİYOR
                yeni_parola_gb.Location = new Point(12, 12);//PAROLA DEĞİŞTİRME GRUBU KONUMU AYARLANIYOR
                this.Width = 396;//PENCERE GENİŞLİĞİ AYARLANIYOR
                this.Height = 240;//PENCERE YÜKSEKLİĞİ AYARLANIYOR
                yeni_parola_gb.Visible = true;//YENİ PAROLA GRUP GÖSTERİLİYOR
            }
            else//EĞER BİLGİLER DOĞRU DEĞİLSE
            {
                sayac--;//1 HAKKI GİDİYOR
                if (sayac != 0)//HAKKI OLDUĞU SÜRECE GİRİYOR
                {
                    MessageBox.Show("GÜVENLİK BİLGİLERİNİZ DOĞRU DEĞİLDİR.\nBİLGİLERİNİZİ KONTROL EDİNİZ.\n\n" + sayac + " HAKKINIZ KALMIŞTIR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VE KALAN HAKKI HAKKINDA BİLGİ VERİLİYOR
                }
                else
                {
                    MessageBox.Show("KONTROL SINIRLAMASI OLUŞTURULDU.\nDAHA SONRA TEKRAR DENEYİNİZ.", "SINIRLAMA", MessageBoxButtons.OK, MessageBoxIcon.Error);//0 HAK KALDIĞINDA ÇALIŞAN BİLGİ
                    this.Close();//PENCEREYİ KAPATIR.
                }
            }
        }

        private void guven_onay_label_MouseMove(object sender, MouseEventArgs e)
        {
            guven_onay_label.ForeColor = Color.Red;//YAZI RENGİNİ DEĞİŞTİRİYOR
        }

        private void guven_onay_label_MouseLeave(object sender, EventArgs e)
        {
            guven_onay_label.ForeColor = Color.Black;//YAZI RENGİNİ ESKI HALINE GETİRİYOR
        }
        bool aktif_pasif = false;//PAROLA GÖSTER/GİZLE DEĞİŞKENİ
        private void parola_goster1_pb_Click(object sender, EventArgs e)
        {
            if (aktif_pasif == false)
            {
                parola1_tb.UseSystemPasswordChar = false;//PAROLAYI GÖSTERİR
                parola2_tb.UseSystemPasswordChar = false;//PAROLAYI GÖSTERİR
                parola_goster1_pb.Image = Image.FromFile(@"image\goz2.png");//GÖRSELLERİ DEĞİŞTİRİR
                parola_goster2_pb.Image = Image.FromFile(@"image\goz2.png");//GÖRSELLERİ DEĞİŞTİRİR
                aktif_pasif = true;//DİĞER TIKLAMA İÇİN HAZIRLAR
            }
            else
            {
                parola1_tb.UseSystemPasswordChar = true;//PAROLAYI GİZLER
                parola2_tb.UseSystemPasswordChar = true;//PAROLAYI GİZLER
                parola_goster1_pb.Image = Image.FromFile(@"image\goz1.png");//GÖRSELLERİ DEĞİŞTİRİR
                parola_goster2_pb.Image = Image.FromFile(@"image\goz1.png");//GÖRSELLERİ DEĞİŞTİRİR
                aktif_pasif = false;//DİĞER TIKLAMA İÇİN HAZIRLAR
            }
        }

        private void onayla_label_Click(object sender, EventArgs e)
        {
            if (parola1_tb.Text.Length>=8 || parola2_tb.Text.Length>=8)//PAROLA DEĞİŞTİRİRKEN 8 KARAKTERDEN FAZLA GİRİRMESINI SAĞLAR
            {
                if (parola1_tb.Text == parola2_tb.Text)//PAROLA AYNI MI KONTROL EDER
                {
                    parola_yenileme();//PAROLA YENİLEME FOKSİYONU
                }
                else
                {
                    MessageBox.Show("YENİ PAROLA İLE PAROLA TEKRAR AYNI DEĞİLDİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//PAROLAR AYNI DEĞİL UYARISI VERİR.
                }
            }
            else
            { 
                MessageBox.Show("YENİ PAROLANIZ 8 HANE VEYA DAHA FAZLA OLMALI", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//8 KARAKTERDEN AZ UYARISI
            }
            
        }
        private void parola_yenileme()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("update hesap_tablosu set parola='"+parola1_tb.Text+"' where kullanici_adi='" + kullanici_adi_tb.Text + "'", baglanti);//YENİ PAROLA BİLGİLERİ SQL KOMUT
                komut.ExecuteNonQuery();//KOMUTU ÇALIŞTIRIR.
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show("PAROLANIZ YENİLENDİ.", "PAROLA YENİLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);//YENİLENME HAKKINDA BİLGİ VERİR.
                this.Close();//PENCREYİ KAPATIR.
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void onayla_label_MouseMove(object sender, MouseEventArgs e)
        {
            onayla_label.ForeColor = Color.Red;//YAZI RENGİ DEĞİŞTİRİR
        }

        private void onayla_label_MouseLeave(object sender, EventArgs e)
        {
            onayla_label.ForeColor = Color.Black;//YAZI RENGİ ESKİYE DÖNDÜRÜR
        }

        private void iptal_et_label_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR//İPTAL EDİLSİN MI SORUSUNU SORAR EVET İSE PENCEREYİ KAPATIR.
            {
                this.Close();//PENCEREYİ KAPATIR
            }
        }

        private void iptal_et_label_MouseMove(object sender, MouseEventArgs e)
        {
            iptal_et_label.ForeColor = Color.Red;//YAZI RENGİ DEĞİŞTİRİR
        }

        private void iptal_et_label_MouseLeave(object sender, EventArgs e)
        {
            iptal_et_label.ForeColor = Color.Black;//YAZI RENGİ ESKİYE DÖNDÜRÜR
        }

        private void iptalet_label_MouseMove(object sender, MouseEventArgs e)
        {
            iptalet_label.ForeColor = Color.Red;//YAZI RENGİ DEĞİŞTİRİR
        }

        private void iptalet_label_MouseLeave(object sender, EventArgs e)
        {
            iptalet_label.ForeColor = Color.Black;//YAZI RENGİ ESKİYE DÖNDÜRÜR
        }
    }
}
