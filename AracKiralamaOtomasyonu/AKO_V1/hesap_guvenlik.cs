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
    public partial class hesap_guvenlik : Form
    {
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        Random uret = new Random();//RASGELE SAYI ÜRETİR
        MailMessage eposta = new MailMessage();//E POSTAYA BİLGİ GÖNDERME İŞLEMLERİ

        public hesap_guvenlik()
        {
            InitializeComponent();
        }
        int secilen1, secilen2, secilen3, secilen4, secilen5;//SEÇİLEN RESİM NUMARASINI TUTMA DEĞİŞKENLERI
        private void hesap_guvenlik_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            mail_gonder(mail_adresini_al());//İÇERDEKİ MAİL ADRESİNİ VERİTABANINDAN ALIR DIŞARDA KI MAİL GÖNDERİR.
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void fotograflari_al_ve_duzenle()
        {//VARSAYILAN GÖRSELLER
            soru_pb.Image = Image.FromFile(@"image\soru_cevap.png");
            cevap_pb.Image = Image.FromFile(@"image\soru_cevap.png");
            onayla_pb.Image = Image.FromFile(@"image\guvenlik_onay1.png");
            iptal_et_pb.Image = Image.FromFile(@"image\guvenlik_onay_iptal1.png");
            kod_pb.Image = Image.FromFile(@"image\mail_parola.png");

            guvenlik_kayit.Image = Image.FromFile(@"image\onayla1.png");
            guvenlik_kayit_sagtik.Image = Image.FromFile(@"image\onayla1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            tekrar_gonder_menu.Image = Image.FromFile(@"image\tekrar.png");
            tekrar_gonder_sagtik.Image = Image.FromFile(@"image\tekrar.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");

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
            onayla_pb.SizeMode = iptal_et_pb.SizeMode = kod_pb.SizeMode = soru_pb.SizeMode = cevap_pb.SizeMode = cizgi_resim1_pb.SizeMode = cizgi_resim2_pb.SizeMode = cizgi_resim3_pb.SizeMode = cizgi_resim4_pb.SizeMode = cizgi_resim5_pb.SizeMode = yuz1_pb.SizeMode = yuz2_pb.SizeMode = yuz3_pb.SizeMode = yuz4_pb.SizeMode = yuz5_pb.SizeMode = hayvan1_pb.SizeMode = hayvan2_pb.SizeMode = hayvan3_pb.SizeMode = hayvan4_pb.SizeMode = hayvan5_pb.SizeMode = film_karakter1_pb.SizeMode = film_karakter2_pb.SizeMode = film_karakter3_pb.SizeMode = film_karakter4_pb.SizeMode = film_karakter5_pb.SizeMode = silah1_pb.SizeMode = silah2_pb.SizeMode = silah3_pb.SizeMode = silah4_pb.SizeMode = silah5_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {//GÜVENLIK SORULARI
            soru_combo.Items.Add("Annenizin kızlık soyadı nedir ?");
            soru_combo.Items.Add("İlk evcil hayvanınızın adı nedir ?");
            soru_combo.Items.Add("İlk aracınızın modeli nedir ?");
            soru_combo.Items.Add("Hangi şehirde doğdunuz ?");
            soru_combo.Items.Add("Çocukluk lakabınız nedir ?");
            soru_combo.Items.Add("İlkokul öğretmenizin adı nedir ?");
            soru_combo.Items.Add("En sevdiğiniz kişinin adı nedir ?");
            soru_combo.Items.Add("En sevdiğiniz rengin adı nedir ?");
            soru_combo.SelectedIndex = 3;//HANGİ ŞEHİRDE DOĞDUNUZ SEÇİM KUTUSUNDAN SEÇİLDİ
            cevap_tb.MaxLength = 20;//EN FAZLA HARF GİRİŞİ
            secilen1 = secilen2 = secilen3 = secilen4 = secilen5 = 1;//VARSAYILAN SEÇİMLER
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI OLUŞAN HATALARI DÜZENLEME
            guvenlik_islemleri_gb.ForeColor =yuz_gb.ForeColor=cizgi_karakter_gb.ForeColor=hayvan_gb.ForeColor=film_karakter_gb.ForeColor=silah_gb.ForeColor=mail_onay_gb.ForeColor=soru_cevap_gb.ForeColor= this.ForeColor;
        }
        private void onayla_pb_MouseMove(object sender, MouseEventArgs e)
        {
            onayla_pb.Image = Image.FromFile(@"image\guvenlik_onay2.png");//GÖRSEL EFEKT
        }

        private void onayla_pb_MouseLeave(object sender, EventArgs e)
        {
            onayla_pb.Image = Image.FromFile(@"image\guvenlik_onay1.png");//VARSAYILAN GÖRSEL
        }

        private void iptal_et_pb_MouseMove(object sender, MouseEventArgs e)
        {
            iptal_et_pb.Image = Image.FromFile(@"image\guvenlik_onay_iptal2.png");//GÖRSEL EFEKT
        }

        private void iptal_et_pb_MouseLeave(object sender, EventArgs e)
        {
            iptal_et_pb.Image = Image.FromFile(@"image\guvenlik_onay_iptal1.png");//VARSAYILAN GÖRSEL
        }

        private void iptal_et_pb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }

        private void tekrar_gonder_label_MouseMove(object sender, MouseEventArgs e)
        {
            tekrar_gonder_label.ForeColor = Color.Red;//YAZI RENGİ DEĞİŞTİRME
        }

        private void tekrar_gonder_label_MouseLeave(object sender, EventArgs e)
        {
            tekrar_gonder_label.ForeColor = this.ForeColor;//VARSAYILAN RENK
        }
        string guvenlik_kodu = "";
        private void guvenlik_kodu_olustur(int kacbasamakli)//ÇAĞRILIRKEN GİRİLEN RAKAMA GÖRE GÜVENLİK KODU OLUŞTURMA FOKSİYONU 
        {
            guvenlik_kodu = "";//GÜVENLIK KODU SIFIRLAMA
            for (int i = 0; i < kacbasamakli; i++)//KAÇ BASAMAKLI
            {
                guvenlik_kodu += uret.Next(0, 9).ToString();//RASGELE 0-9 ARASI SAYI ÜRETİLİR.
            }
        }
        private string mail_adresini_al()//GİRİŞ YAPILAN KULLANICININ BİLGİSİ
        {
            string mail_adres_bilgisi = "";//ADRESİ TUTULACAK YER
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(eposta) as mail_adresi from personel_tablosu where tcno='" + giris_penceresi.tcno + "'", baglanti);//ADRESİN ALINDIĞI KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    mail_adres_bilgisi = oku["mail_adresi"].ToString();//ADRES EKLENDI
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
            return mail_adres_bilgisi;//ADRES BİLGİSİ DÖNDÜRÜRDÜ
        }

        private void mail_gonder(string mail_adresi)
        {
            try
            {
                guvenlik_kodu_olustur(6);//6 BASAMAKLI GÜVENLİK KODU OLUŞTURMA FOKSİYONU
                eposta.From = new MailAddress("halilprogram@hotmail.com");//gönderen
                eposta.To.Add(mail_adresi.ToString());//gönderilecek kişi
                eposta.Subject = "HESAP GÜVENLİK KODU";//konu
                eposta.Body = "Kod:" + guvenlik_kodu + "\n\nNot:Bu meseja geri dönüş yapmayınız."; //GÖNDERİLEN BİLGİ

                SmtpClient smtp = new SmtpClient();

                smtp.Credentials = new System.Net.NetworkCredential("halilprogram@hotmail.com", "Halil123456");//gönderen kişinin e posta bilgileri
                smtp.Host = "smtp.live.com";//sunucu
                smtp.EnableSsl = true;//protekol
                smtp.Port = 587;

                smtp.Send(eposta);//gönderme işlemi
                mail_adresi_label.Text = "Gönderildi:" + mail_adresi.ToString();//KULLANICIYI BİLGİLENDİRME
                mail_adresi_label.ForeColor = Color.Black;//RENK
            }
            catch (Exception)
            {
                mail_adresi_label.Text = "Kodunuz:Gönderilemedi(İnternet veya e-posta kaynaklı).";//KULLANICIYI BİLGİLENDİRME
                mail_adresi_label.ForeColor = Color.Red;//HATA RENGİ
            }
        }
        private void tekrar_gonder_label_Click(object sender, EventArgs e)
        {
            mail_gonder(mail_adresini_al());//TEKRAR GÖNDERME 
            if (mail_adresi_label.Text.Contains("Gönderildi") == true)//DOĞRULAMA
            {
                MessageBox.Show("E-POSTA GÖNDERİLDİ.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Information);//KULLANICIYI BİLGİLENDIRME
            }
        }
        private void kod_tb_TextChanged(object sender, EventArgs e)
        {//KOD METİN KUTUSUNA HER KARAKTER GİRİLDİĞİNDE ÇALIŞIR
            if (kod_tb.Text == guvenlik_kodu)//KOD VE GİRİLEN KARKATER DOĞRU İSE;
            {
                kod_tb.ReadOnly = true;//KODLAR DEĞİŞTİLMEZ(DOĞRU OLD. İÇİN)
                tekrar_gonder_label.Enabled = false;//TEKRAR KOD GÖNDERİMİ İPTAL OLUR
            }
        }
        private void guvenliklik_sorularini_kaydet()//GÜVENLIK SORULARININ VERİTABALINA KAYDETME FOKSİYONU
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("update hesap_kurtarma_tablosu set guvenlik_sorusu='"+soru_combo.Text+"',guvenlik_cevabi='"+cevap_tb.Text+"',secilen_yuz="+secilen1+",secilen_cizgi_film_karakteri="+secilen2+",secilen_hayvan="+secilen3+",secilen_film_karakteri="+secilen4+",secilen_silah="+secilen5+" where tcno='"+giris_penceresi.tcno+"'" , baglanti);//KAYDETME KOMUTU
                komut.ExecuteNonQuery();//KOMUTU ÇALIŞTIRMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show("HESAP GÜVENLİK BİLGİLERİNİZ GÜNCELLENDE/KAYDEDİLDİ.", "HESAP GÜVENLİK", MessageBoxButtons.OK, MessageBoxIcon.Information);//KULLANICIYA BİLGİ VERME
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void onayla_pb_Click(object sender, EventArgs e)//Güvenlik Bilgilerini Güncelleme ve Kayıt İşlemleri
        {
            if (cevap_tb.Text != "")//SORUYUNUN CEVABI VAR MI KONTRIL
            {
                if (kod_tb.ReadOnly == true)//KOD DOĞRU İSE METİN KUTUSU SADECE OKUNABİLİR OLACAK BUNDAN DOLAYI OKUNABİLİR İSE DEMİŞİM
                {
                    secilen_resimleri_kontrol_et();//RESİMLERİ KONTROL EDİP BİLGİLERİ DEĞİŞKENLERE ATANDI
                    guvenliklik_sorularini_kaydet();//KAYIT İŞLEMLERİ FOKSİYONU
                }
                else
                {
                    MessageBox.Show("E-POSTAYA GÖNDERİLEN KODU DOĞRULAYINIZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//KOD DOĞRURULMADI UYARISI
                }
            }
            else
            {
                MessageBox.Show("SORUYU CEVAPLAMAYI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//CEVAP VERİLMEDİ UYARISI
            }
        }
        private void secilen_resimleri_kontrol_et()//SEÇİMLEN RESİMLERİ DEĞİŞKENLERI ATAMA FOKSİYONU
        {
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

        private void yuz1_pb_Click(object sender, EventArgs e)
        {
            yuz1_rb.Checked = true;//RESİM SEÇME
        }

        private void yuz2_pb_Click(object sender, EventArgs e)
        {
            yuz2_rb.Checked = true;//RESİM SEÇME
        }

        private void yuz3_pb_Click(object sender, EventArgs e)
        {
            yuz3_rb.Checked = true;//RESİM SEÇME
        }

        private void yuz4_pb_Click(object sender, EventArgs e)
        {
            yuz4_rb.Checked = true;//RESİM SEÇME
        }

        private void yuz5_pb_Click(object sender, EventArgs e)
        {
            yuz5_rb.Checked = true;//RESİM SEÇME
        }

        private void cizgi_resim1_pb_Click(object sender, EventArgs e)
        {
            cizgi_resim1_rb.Checked = true;//RESİM SEÇME
        }

        private void cizgi_resim2_pb_Click(object sender, EventArgs e)
        {
            cizgi_resim2_rb.Checked = true;//RESİM SEÇME
        }

        private void cizgi_resim3_pb_Click(object sender, EventArgs e)
        {
            cizgi_resim3_rb.Checked = true;//RESİM SEÇME
        }

        private void cizgi_resim4_pb_Click(object sender, EventArgs e)
        {
            cizgi_resim4_rb.Checked = true;//RESİM SEÇME
        }

        private void cizgi_resim5_pb_Click(object sender, EventArgs e)
        {
            cizgi_resim5_rb.Checked = true;//RESİM SEÇME
        }

        private void hayvan1_pb_Click(object sender, EventArgs e)
        {
            hayvan1_rb.Checked = true;//RESİM SEÇME
        }

        private void hayvan2_pb_Click(object sender, EventArgs e)
        {
            hayvan2_rb.Checked = true;//RESİM SEÇME
        }

        private void hayvan3_pb_Click(object sender, EventArgs e)
        {
            hayvan3_rb.Checked = true;//RESİM SEÇME
        }

        private void hayvan4_pb_Click(object sender, EventArgs e)
        {
            hayvan4_rb.Checked = true;//RESİM SEÇME
        }

        private void hayvan5_pb_Click(object sender, EventArgs e)
        {
            hayvan5_rb.Checked = true;//RESİM SEÇME
        }

        private void film_karakter1_pb_Click(object sender, EventArgs e)
        {
            film_karakter1_rb.Checked = true;//RESİM SEÇME
        }

        private void film_karakter2_pb_Click(object sender, EventArgs e)
        {
            film_karakter2_rb.Checked = true;//RESİM SEÇME
        }

        private void film_karakter3_pb_Click(object sender, EventArgs e)
        {
            film_karakter3_rb.Checked = true;//RESİM SEÇME
        }

        private void film_karakter4_pb_Click(object sender, EventArgs e)
        {
            film_karakter4_rb.Checked = true;//RESİM SEÇME
        }

        private void film_karakter5_pb_Click(object sender, EventArgs e)
        {
            film_karakter5_rb.Checked = true;//RESİM SEÇME
        }

        private void silah1_pb_Click(object sender, EventArgs e)
        {
            silah1_rb.Checked = true;//RESİM SEÇME
        }

        private void silah2_pb_Click(object sender, EventArgs e)
        {
            silah2_rb.Checked = true;//RESİM SEÇME
        }

        private void silah3_pb_Click(object sender, EventArgs e)
        {
            silah3_rb.Checked = true;//RESİM SEÇME
        }

        private void silah4_pb_Click(object sender, EventArgs e)
        {
            silah4_rb.Checked = true;//RESİM SEÇME
        }

        private void silah5_pb_Click(object sender, EventArgs e)
        {
            silah5_rb.Checked = true;//RESİM SEÇME
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESINI AÇMA
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
