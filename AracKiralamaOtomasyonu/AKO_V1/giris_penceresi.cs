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
    public partial class giris_penceresi : Form
    {
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ//VERİTABANI ADRES KODU
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT//SQL KODLARI YAZDIĞIMIZ YER
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ//EĞER VERİ ÇEKİLECEKSE KULLANILAN KOMUT
        public giris_penceresi()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU//Görsellerin çağrıldığı foksiyon
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME//Nesneler için kısıtlama ve düzenleme işlemlerinin çağrıldığı foksiyon
        }
        private void fotograflari_al_ve_duzenle()
        {//Genel olarak görsellerin eklendiği yer
            kapat_pb.Image = Image.FromFile(@"image\iptal_et1.png");
            gorev_pb.Image = Image.FromFile(@"image\myspace.png");
            kullanici_adi_pb.Image = Image.FromFile(@"image\kullanici.png");
            parola_pb.Image = Image.FromFile(@"image\password.png");
            giris_yap_pb.Image = Image.FromFile(@"image\open.png");
            giris_fotograf_pb.Image = Image.FromFile(@"image\giris.png");
            cikis_yap_pb.Image = Image.FromFile(@"image\quit.png");
            yeni_uye_basvurusu_pb.Image = Image.FromFile(@"image\basvuru.png");
            uye_sorgulama_pb.Image = Image.FromFile(@"image\basvuru_sorgula.png");
            uye_yenileme_pb.Image = Image.FromFile(@"image\basvuru_yenileme.png");
            parola_unuttum_pb.Image = Image.FromFile(@"image\parola_yenileme.png");
            yardim_pb.Image = Image.FromFile(@"image\yardim.png");
            oneri_hata_pb.Image = Image.FromFile(@"image\oneri_hata.png");

            //Görsellerin sabitlendiği yer.(Boyutsal olarak)
            kapat_pb.SizeMode=gorev_pb.SizeMode = kullanici_adi_pb.SizeMode = parola_pb.SizeMode = giris_yap_pb.SizeMode = giris_fotograf_pb.SizeMode = cikis_yap_pb.SizeMode = yeni_uye_basvurusu_pb.SizeMode = uye_sorgulama_pb.SizeMode = uye_yenileme_pb.SizeMode = parola_unuttum_pb.SizeMode = yardim_pb.SizeMode = oneri_hata_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            gorev_combo.Items.Add("YÖNETİCİ");//GÖREV 1
            gorev_combo.Items.Add("PERSONEL");//GÖREV 2
            gorev_combo.SelectedIndex = 1;//GÖREV 2'Yİ SEÇME KODU YANI 'PERSONELİ'
            kullanici_adi_tb.Text = "Kullanıcı Adı";
            parola_tb.Text = "Parola";
            parola_tb.UseSystemPasswordChar = true;//PAROLANIN GÖZÜKMESİNİ ENGELLER
            kullanici_adi_tb.MaxLength = parola_tb.MaxLength = 14;//VERİTABANI ALAN SINIRLARI İÇİN EN FAZLA HARF 
            
        }
       
        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)//Label ve picturebox aynı işlemi kullanıyor.
        {
            //GÖRSELİN VEYA YAZININ ÜZERİNE GELDİĞİNDE EFEKT DURUMUNUN GÖZÜKMESİ
            giris_yap_pb.Image = Image.FromFile(@"image\open2.png");
            giris_yap_label.ForeColor = Color.Red;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            //GÖRSELİN VEYA YAZININ ÜZERİNE GELDİĞİNDE EFEKT DURUMUNUN GÖZÜKMESİ VARSAYILANA DÖNMESİ
            giris_yap_pb.Image = Image.FromFile(@"image\open.png");
            giris_yap_label.ForeColor = Color.Black;
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)//Label ve picturebox aynı işlemi kullanıyor.
        {
            //GÖRSELİN VEYA YAZININ ÜZERİNE GELDİĞİNDE EFEKT DURUMUNUN GÖZÜKMESİ
            cikis_yap_pb.Image = Image.FromFile(@"image\quit2.png");
            cikis_yap_label.ForeColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            //GÖRSELİN VEYA YAZININ ÜZERİNE GELDİĞİNDE EFEKT DURUMUNUN GÖZÜKMESİ VARSAYILANA DÖNMESİ
            cikis_yap_pb.Image = Image.FromFile(@"image\quit.png");
            cikis_yap_label.ForeColor = Color.Black;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //ÖNERİ/HATA BİLDİRİM PENCERESİNİ AÇAR
            oneri_hata_bildirimi bildirim = new oneri_hata_bildirimi();
            bildirim.ShowDialog();
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            yeni_uye_label.ForeColor = Color.Red;//yazı rengini değiştirir.
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            yeni_uye_label.ForeColor = Color.Black;//yazı rengini değiştirir.
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            parola_unuttum_label.ForeColor = Color.Red;//yazı rengini değiştirir.
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            parola_unuttum_label.ForeColor = Color.Black;//yazı rengini değiştirir.
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            yardim_label.ForeColor = Color.Red;//yazı rengini değiştirir.
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            yardim_label.ForeColor = Color.Black;//yazı rengini değiştirir.
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            oneri_hata_label.ForeColor = Color.Red;//yazı rengini değiştirir.
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            oneri_hata_label.ForeColor = Color.Black;//yazı rengini değiştirir.
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            cikis_yap();//ÇIKIŞ İŞLEMLERİ İÇİN FOKTİYONU ÇAĞIRIR
        }
        private void cikis_yap()
        {
            if (MessageBox.Show("ÇIKIŞ YAPILSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//PENCERE KAPATILSIN MI 'EVET' İSE KAPATIYOR//PENCERE KAPATILSIN MI 'EVET' İSE KAPATIYOR//ÇIKIŞ İÇİN SORU SORULUR EĞER CEVAP EVET İSE;
            {
                Application.Exit();//PROGRAM TAMAMEN KAPATILIR.
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            //ÜYE OL PENCERESİNİ AÇAR
            uye_ol uye_ol_ac = new uye_ol();
            uye_ol_ac.ShowDialog();
        }

        private void giris_yap_pb_Click(object sender, EventArgs e)
        {
            giris_islemleri();//GİRİŞ FOKSİYONUNU ÇAĞIRIR.
        }
        public static string tcno = "";//DİĞER PENCERELERDE KİMİN GİRİŞ YAPDIĞINI ÖZELLİKLERİNİ KULLANILMASI İÇİN EKLENDİ
        private void giris_islemleri()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANINA BAĞLANTI İSTEĞİ
                komut = new SqlCommand("select * from hesap_tablosu where kullanici_adi='" + kullanici_adi_tb.Text + "' and parola='" + parola_tb.Text + "' and gorev_no=" + (gorev_combo.SelectedIndex + 1) + "and arsiv=1", baglanti);//AKTİF OLAN PERSONELLER ARASINDA GÖREVİ VE KULLANICI ADI PAROLASI UYUYOR OLAN VERİYİ GETİRSİN.
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT//ÇALIŞTIRSIN VE VERİLERİ GETİRSİN.
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.//EĞER VERİ VARSA AŞAĞIDA KI KOMUTLARI ÇALIŞTIRSIN
                {
                    tcno = oku["tcno"].ToString();//DİĞER PENCERELERDE KULLANILACAK BİLGİ
                    //ANAPENCEREYİ PENCEREYİ AÇMA KOMUTU
                    ana_pencere ana_pencereyi_ac = new ana_pencere();
                    ana_pencereyi_ac.Show();
                    this.Hide();//BU PENCEREYİ GİZLEME KODU
                }
                else
                {
                    MessageBox.Show("GÖREV,KULLANICI ADI VEYA PAROLA YANLIŞTIR", "GİRİŞ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);//EĞER GİRİŞ YAPILAMADI İSE NEDENLERINI PENCEREDE GÖSTERME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//HATA VERMEMESİ İÇİN BAĞLANTIYI KAPATMA
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//EĞER HATA VERİRSE BAĞLANTIYI KAPATMA NEDENİ:BAĞLI YERE TEKRAR BAĞLANAMASSIN.
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.//HATA BİLGİSİ GÖSTERME
            }
        }

        private void uye_durumu_sorgulama_label_MouseMove(object sender, MouseEventArgs e)
        {
            uye_durumu_sorgulama_label.ForeColor = Color.Red;//YAZI RENGİNİ DEĞİŞTİRİR.
        }

        private void uye_durumu_sorgulama_label_MouseLeave(object sender, EventArgs e)
        {
            uye_durumu_sorgulama_label.ForeColor = Color.Black;//YAZI RENGİNİ DEĞİŞTİRİR.
        }

        private void uyelik_yenileme_label_MouseMove(object sender, MouseEventArgs e)
        {
            uyelik_yenileme_label.ForeColor = Color.Red;//YAZI RENGİNİ DEĞİŞTİRİR.
        }

        private void uyelik_yenileme_label_MouseLeave(object sender, EventArgs e)
        {
            uyelik_yenileme_label.ForeColor = Color.Black;//YAZI RENGİNİ DEĞİŞTİRİR.
        }

        private void uye_durumu_sorgulama_label_Click(object sender, EventArgs e)
        {
            //ÜYE DURUMUNU SORGULAMA PENCERESİNİ AÇAR
            uye_durumu_sorgulama uye_sorgula = new uye_durumu_sorgulama();
            uye_sorgula.ShowDialog();
        }

        private void uyelik_yenileme_label_Click(object sender, EventArgs e)
        {
            //ÜYE YENİLEME PENCERESİNİ AÇAR
            uye_yenile uye_yenileme =new uye_yenile();
            uye_yenileme.ShowDialog();
        }

        private void parola_unuttum_label_Click(object sender, EventArgs e)
        {
            //PAROLAMI UNUTTUM PENCERESİNİ AÇAR
            parolami_unuttum parola_yenileme = new parolami_unuttum();
            parola_yenileme.ShowDialog();
        }

        private void giris_penceresi_FormClosing(object sender, FormClosingEventArgs e)
        {
            //OLAY ÖZELLİĞİDİR EĞER X DÜĞMESİNE BASILDIĞINDA OTOMATIK PROGRAMI KAPATIR.
            Application.Exit();
        }

        private void giris_penceresi_KeyDown(object sender, KeyEventArgs e)
        {
            //OLAY ÖZELLİĞİDİR
            if (e.KeyCode == Keys.Enter)//EĞER KLAVYEDEN ENTER BASILDI İSE
            {
                giris_islemleri();//GİRİŞ FOKSİYONUNU ÇAĞIRIR
            }
            else if (e.KeyCode == Keys.Escape)//EĞER KLAVYEDEN ESC BASILDI İSE
            {
                cikis_yap();//ÇIKIŞ FOKSİYONUNU ÇAĞIRIR
            }
        }

        private void kapat_pb_Click(object sender, EventArgs e)
        {
            cikis_yap();//ÇIKIŞ FOKSİYONU
        }

        private void kapat_pb_MouseMove(object sender, MouseEventArgs e)
        {
            kapat_pb.Image = Image.FromFile(@"image\iptal_et2.png");//EFEKT EKLER
        }

        private void kapat_pb_MouseLeave(object sender, EventArgs e)
        {
            kapat_pb.Image = Image.FromFile(@"image\iptal_et1.png");//EFEKTYI ESKI HALINE GETİRİR.
        }

        private void yardim_label_Click(object sender, EventArgs e)
        {
            //YARDIM PENCERESİNİ AÇAR
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
