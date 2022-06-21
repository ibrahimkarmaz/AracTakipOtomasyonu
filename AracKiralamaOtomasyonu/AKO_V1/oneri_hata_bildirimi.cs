using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace WindowsFormsApplication1
{
    public partial class oneri_hata_bildirimi : Form
    {
        Random sayi_uret = new Random();
        string[] islem = { "+", "-", "*", "/" };
        MailMessage eposta = new MailMessage();
        public oneri_hata_bildirimi()
        {
            InitializeComponent();
        }

        private void oneri_hata_bildirimi_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME 
            matematiksel_guvenlik_sorusu();//TOPLAMA, ÇIKARMA, ÇARPMA VE BÖLME SORULARININ FOKSİYONU
        }
        private void fotograflari_al_ve_duzenle()
        {
            //PENCERE GÖRSELLERİ
            konu_pb.Image = Image.FromFile(@"image\konu.png");
            icerik_pb.Image = Image.FromFile(@"image\mesaj.png");
            gonder_pb.Image = Image.FromFile(@"image\gonder1.png");
            mesaj_gonder_menu.Image = Image.FromFile(@"image\onayla1.png");
            mesaj_gonder_sagtik.Image = Image.FromFile(@"image\onayla1.png");
            iptalet_pb.Image = Image.FromFile(@"image\mesaj_iptal1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            mat_pb.Image = Image.FromFile(@"image\matematik.png");
            yenile_pb.Image = Image.FromFile(@"image\yenile1.png");
            yenile_menu.Image = Image.FromFile(@"image\yenile1.png");
            yenile_sagtik.Image = Image.FromFile(@"image\yenile1.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");
            

            //PENCERE GÖRSELLERİNİ SIĞDIRMA
            konu_pb.SizeMode =icerik_pb.SizeMode=gonder_pb.SizeMode=iptalet_pb.SizeMode=mat_pb.SizeMode=yenile_pb.SizeMode= PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            icerik_tb.MaxLength = 255;//VERİTABANINDAN KAYNAKLI EN FAZLA KARAKTER
            ilk_rasgele_sayi_tb.ReadOnly = true;//RASGELE RAKAMI VEYA SAYIYI SADECE OKUNABİLİR
            ilk_rasgele_sayi_tb.TextAlign = HorizontalAlignment.Center;//RASGELE RAKAMI VEYA SAYIYI ORTALAR
            ikinci_rasgele_sayi_tb.ReadOnly = true;//RASGELE RAKAMI VEYA SAYIYI SADECE OKUNABİLİR
            ikinci_rasgele_sayi_tb.TextAlign = HorizontalAlignment.Center;//RASGELE RAKAMI VEYA SAYIYI ORTALAR
            sonuc_tb.MaxLength = 3;//VERİTABANINDAN KAYNAKLI EN FAZLA KARAKTER
            sonuc_tb.TextAlign = HorizontalAlignment.Center;//YAZILACAK SONUCU ORTALAR
            konu_combo.Items.Add("ÖNERİ BİLDİRİMİ");
            konu_combo.Items.Add("HATA BİLDİRİMİ");
            konu_combo.Items.Add("DİĞER BİLDİRİM(LER)");
            konu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            //konu_combo.TextAlign = HorizontalAlignment.Center;
        }
        private void mail_gonder()//MAİL GÖNDERİLİR.
        {
            try//HATA ENGELLEYİCİ
            {
                eposta.From = new MailAddress("halilprogram@hotmail.com");//gönderen
                eposta.To.Add("karmazprogramming@hotmail.com");//gönderilecek kişi
                eposta.Subject = konu_combo.Text;//KONU
                eposta.Body = icerik_tb.Text;//İÇERİK BİLGİSİ

                SmtpClient smtp = new SmtpClient();

                smtp.Credentials = new System.Net.NetworkCredential("halilprogram@hotmail.com", "Halil123456");//gönderen kişinin e posta bilgileri
                smtp.Host = "smtp.live.com";//sunucu
                smtp.EnableSsl = true;//protekol
                smtp.Port = 587;

                smtp.Send(eposta);//gönderme işlemi
                MessageBox.Show("E-POSTA GÖNDERİLDİ.\n", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Information);//KULLANICIYI BİLGİLENDİRME
            }
            catch (Exception)
            {
                MessageBox.Show("E-POSTA GÖNDERİLEMEDİ.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Error);//KULLANICIYI HATA HAKKINDA BİLGİLENDİRME
            }
            this.Close();
        }
        private void yenile_pb_Click(object sender, EventArgs e)
        {
            matematiksel_guvenlik_sorusu();//GÜVENLIK SORUSUNU OLUŞTURMA FOKSİYONU
        }
       
        private void matematiksel_guvenlik_sorusu()
        {
            ilk_rasgele_sayi_tb.Text = sayi_uret.Next(1, 11).ToString();//RASGELE 1-10[DAHİL] ARASINDA SAYI OLUŞTURUP METİN KUTUSUNA AKTARIYOR
            ikinci_rasgele_sayi_tb.Text = sayi_uret.Next(1, 11).ToString();//RASGELE 1-10[DAHİL] ARASINDA SAYI OLUŞTURUP METİN KUTUSUNA AKTARIYOR
            isaret_label.Text=(islem[sayi_uret.Next(0,islem.Length)]).ToString();//İŞLEM SEÇİLİYOR(+,-,*,/)
            if (isaret_label.Text == "/" && (Convert.ToInt32(ilk_rasgele_sayi_tb.Text) % Convert.ToInt32(ikinci_rasgele_sayi_tb.Text))!=0)//EĞER İŞLEM BÖLME İSE TAM BÖLÜNÜYOR MU DİYE KONTROL EDİLİYOR
            {
                matematiksel_guvenlik_sorusu();//EĞER TAM BÖLÜNMÜYORSA TEKRAR GÜVENLIK SORUSU OLUŞTURULUYOR
            }
        }

        private void yenile_pb_MouseMove(object sender, MouseEventArgs e)
        {
            yenile_pb.Image = Image.FromFile(@"image\yenile2.png");//EFETK GÖRSELİ
        }

        private void yenile_pb_MouseLeave(object sender, EventArgs e)
        {
            yenile_pb.Image = Image.FromFile(@"image\yenile1.png");//EFETK GÖRSELİ ESKI HALINE ÇEVİRME
        }
        
        private void gonder_pb_Click(object sender, EventArgs e)
        {
            if (icerik_tb.Text!="")//içerik boşmu diye kontrol ediliyor
            {
                if (isaret_label.Text == "+" && sonuc_tb.Text!="")//işarete göre farklı işlemler yapılıyor
                {
                    if ((Convert.ToInt32(ilk_rasgele_sayi_tb.Text) + Convert.ToInt32(ikinci_rasgele_sayi_tb.Text)) == Convert.ToInt32(sonuc_tb.Text))//MATEMATİKSEL İŞLEM KONTROL EDİLİYOR
                    {
                        mail_gonder();//DOĞRU İSE MAİL GÖNDERİYOR//DOĞRU İSE MAİL GÖNDERİYOR
                    }
                    else
                    {
                        MessageBox.Show("MATEMATİKSEL SONUÇ YANLIŞTIR.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//YANLIŞ İSE UYARI VERİYOR
                    }
                }
                else if (isaret_label.Text == "-" && sonuc_tb.Text != "")//işarete göre farklı işlemler yapılıyor
                {
                    if ((Convert.ToInt32(ilk_rasgele_sayi_tb.Text) - Convert.ToInt32(ikinci_rasgele_sayi_tb.Text)) == Convert.ToInt32(sonuc_tb.Text))//MATEMATİKSEL İŞLEM KONTROL EDİLİYOR
                    {
                        mail_gonder();//DOĞRU İSE MAİL GÖNDERİYOR
                    }
                    else
                    {
                        MessageBox.Show("MATEMATİKSEL SONUÇ YANLIŞTIR.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//YANLIŞ İSE UYARI VERİYOR
                    }
                }
                else if (isaret_label.Text == "*" && sonuc_tb.Text != "")//işarete göre farklı işlemler yapılıyor
                {
                    if ((Convert.ToInt32(ilk_rasgele_sayi_tb.Text) * Convert.ToInt32(ikinci_rasgele_sayi_tb.Text)) == Convert.ToInt32(sonuc_tb.Text))//MATEMATİKSEL İŞLEM KONTROL EDİLİYOR
                    {
                        mail_gonder();//DOĞRU İSE MAİL GÖNDERİYOR
                    }
                    else
                    {
                        MessageBox.Show("MATEMATİKSEL SONUÇ YANLIŞTIR.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//YANLIŞ İSE UYARI VERİYOR
                    }
                }
                else if (isaret_label.Text == "/" && sonuc_tb.Text != "")//işarete göre farklı işlemler yapılıyor
                {
                    if ((Convert.ToInt32(ilk_rasgele_sayi_tb.Text) / Convert.ToInt32(ikinci_rasgele_sayi_tb.Text)) == Convert.ToInt32(sonuc_tb.Text))//MATEMATİKSEL İŞLEM KONTROL EDİLİYOR
                    {
                        mail_gonder();//DOĞRU İSE MAİL GÖNDERİYOR
                    }
                    else
                    {
                        MessageBox.Show("MATEMATİKSEL SONUÇ YANLIŞTIR.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//YANLIŞ İSE UYARI VERİYOR
                    }
                }
                else
                {
                    MessageBox.Show("MATEMATİKSEL SONUÇ BÖLÜMÜNÜ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//BOŞ İSE UYARI VERİYOR
                }
            }
            else
            {
                MessageBox.Show("İÇERİK BİLGİSİNİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//KONU İÇERİĞİNİ DOLDURMASI İÇİN UYARI
            }
        }

        private void gonder_pb_MouseMove(object sender, MouseEventArgs e)
        {
            gonder_pb.Image = Image.FromFile(@"image\gonder2.png");//EFETK GÖRSELİ
        }

        private void gonder_pb_MouseLeave(object sender, EventArgs e)
        {
            gonder_pb.Image = Image.FromFile(@"image\gonder1.png");//EFETK GÖRSELİ ESKI HALINE ÇEVİRME
        }

        private void iptalet_pb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ÇIKIŞ YAPILSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//PENCERE KAPATILSIN MI 'EVET' İSE KAPATIYOR//PENCERE KAPATILSIN MI 'EVET' İSE KAPATIYOR
            {
                this.Close();
            }
        }

        private void iptalet_pb_MouseMove(object sender, MouseEventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\mesaj_iptal2.png");//EFETK GÖRSELİ
        }

        private void iptalet_pb_MouseLeave(object sender, EventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\mesaj_iptal1.png");//EFETK GÖRSELİ ESKI HALINE ÇEVİRME
        }

        private void icerik_tb_TextChanged(object sender, EventArgs e)
        {
            karkater_sayisi_kalan_label.Text = icerik_tb.TextLength.ToString() + "/255";//İÇERİKTE YAZILAN KARAKTER SAYISI
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {
            //YARDIM PENCERESİNİ AÇAR.
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
