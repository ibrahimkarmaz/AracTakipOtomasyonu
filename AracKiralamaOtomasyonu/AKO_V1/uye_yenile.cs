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
    public partial class uye_yenile : Form
    {
        public uye_yenile()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        private void uye_yenile_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
        }
        private void fotograflari_al_ve_duzenle()
        {
            //FOTOĞRAFLARI ÇEKTIĞIMIZ YER
            tc_pb.Image = Image.FromFile(@"image\kullanici.png");
            yenile_pb.Image = Image.FromFile(@"image\yenile1.png");
            tc_pb.SizeMode = yenile_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }

        private void yenile_pb_MouseMove(object sender, MouseEventArgs e)
        {
            yenile_pb.Image = Image.FromFile(@"image\yenile2.png");//EFEKT GÖRSELİ
        }

        private void yenile_pb_MouseLeave(object sender, EventArgs e)
        {
            yenile_pb.Image = Image.FromFile(@"image\yenile1.png");
        }

        private void yenile_pb_Click(object sender, EventArgs e)
        {
            uyeligi_yenileme();//YENİLEME İŞLEMİ FOKSİYONU
        }
        private void uyeligi_yenileme()//PERSONELLİKLER ÇIKARILMIŞ VEYA ONAY İŞLEMLERİNDE REDDEDİLMİŞ PERSONELLERİN TEKRAR BAŞVURU YAPSASINI SAĞLANYAN FOKSİYON
        {
            try
            {
                bool yenilensinmi_bool = false;//ÇIKARILMIŞ VEYA REDDEDİLMİŞ Mİ GİBİ İŞLEMLER İÇİN DEĞİŞKEN
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from onay_tablosu where tcno='" + tc_masketb.Text + "' and durum=0 and arsiv=0", baglanti);//ÇIKARILMIŞ VEYA REDDEDİLMİŞ Mİ GİBİ İŞLEMLER KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    if (MessageBox.Show("ÜYELİK YENİLENSİN Mİ ?", "ÜYELİK YENİLEME", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)//EĞER VERİ VARSA YENİLEME İŞLEMİ YAPILSIN MI SORUSUNU SORUYOR 
                    {
                        yenilensinmi_bool = true;//YENİLEME İŞLEMİ YAPILMASI İÇİN TRUE OLARAK DEĞİŞTİRİLDİ.
                    }
                }
                else
                {
                    MessageBox.Show("KULLANICI BULUNAMADI,ONAY BEKLİYOR VEYA AKTİF KULLANICI OLABİLİR.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//SAĞDA YAZILI BİLGİLERDEN DOLAYI HATA VERDİ.
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//VERİTABANI BAĞLANTISI KAPATILDI

                if (yenilensinmi_bool==true)//YENİLEME İŞLEMİ DOĞRU İSE GİRDİĞİ YER
                {
                    baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANINA BAĞLANTI AÇILDI
                    komut = new SqlCommand("update onay_tablosu set durum=0,arsiv=1 where tcno='" + tc_masketb.Text+"'", baglanti);//TEKRAR BAŞVURU YAPILDI.
                    komut.ExecuteNonQuery();//KOMUTLAR ÇALIŞTIRILDI.
                    baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                    MessageBox.Show("ÜYELİK BAŞVURUSU YENİLENDİ.", "ÜYELİK YENİLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);//KULLANİCİYA BİLGİ VERİLDİ.
                }
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
    }
}
