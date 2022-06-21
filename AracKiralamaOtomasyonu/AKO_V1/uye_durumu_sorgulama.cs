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
    public partial class uye_durumu_sorgulama : Form
    {
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ//VERİTABANI BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT//SQL KOMUTLARI
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ//VERİLER ÇEKİLECEK İSE KULLANILAN KOMUT
        public uye_durumu_sorgulama()
        {
            InitializeComponent();
        }

        private void uye_durumu_sorgulama_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU//fotoğraf gösterme düzenleme
        }
        private void fotograflari_al_ve_duzenle()
        {
            //fotoğraf gösterme
            tc_pb.Image = Image.FromFile(@"image\kullanici.png");
            ara_pb.Image = Image.FromFile(@"image\arama1.png");

            tc_pb.SizeMode =ara_pb.SizeMode= PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU//fotoğraf sığdırme
        }

        private void ara_pb_MouseMove(object sender, MouseEventArgs e)
        {
            ara_pb.Image = Image.FromFile(@"image\arama2.png");//EFEKT GÖRSELİ
        }

        private void ara_pb_MouseLeave(object sender, EventArgs e)
        {
            ara_pb.Image = Image.FromFile(@"image\arama1.png");//EFEKT GÖRSELİ ESKIYE ÇEVİRME
        }

        private void ara_pb_Click(object sender, EventArgs e)
        {
            sorgulama();//ÜYE DURUMUNU SORGULAMA FOKSİYONU
        }
        private void sorgulama()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI//VERİTABANI BAĞLANTI
                komut = new SqlCommand("select * from onay_tablosu where tcno='" + tc_masketb.Text + "'", baglanti);//DURUMU SORGULAMA
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT//ÇALIŞTIRMA VER ÇEKME
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.//VERİ VARSA GİR
                {
                    //DURUMA GÖRE YAPILACAKLAR
                    if (Convert.ToInt32(oku["durum"])==0 && Convert.ToInt32(oku["arsiv"])==1)//DURUM 0 ARSİV 1 İSE;
                    {
                        durum_label.Text = "Durum:Onaylanmayı bekliyor...";
                    }
                    else if (Convert.ToInt32(oku["durum"]) == 1 && Convert.ToInt32(oku["arsiv"]) == 1)//DURUM 1 ARSİV 1 İSE;
                    {
                        durum_label.Text = "Durum:Onaylandı.\nÜye Başvurusu yaparken girdiğiniz\nKullanici adı ve parolanızı\nkullanarak giriş yapabilirsiniz.";
                    }
                    else if (Convert.ToInt32(oku["durum"]) == 0 && Convert.ToInt32(oku["arsiv"]) == 0)//DURUM 0 ARSİV 0 İSE;
                    {
                        durum_label.Text = "Durum:Reddedildi.\nTekrar Başvuru için Üyelik Yenile'ye gidebilirsiniz.";
                    }
                }
                else//OLMAMASI DURUMU
                {
                    durum_label.Text = "Durum:BAŞVURU BULUNAMADI...";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//BAĞLANTIYI KAPATMA
            }
            catch (Exception HATA)//HATA DURUMUNDA
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI//BAĞLANTIYI KAPATMA
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.//HATAYI GÖSTER
            }
        }
    }
}
