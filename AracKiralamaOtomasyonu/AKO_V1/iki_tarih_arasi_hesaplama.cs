using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class iki_tarih_arasi_hesaplama : Form
    {
        public iki_tarih_arasi_hesaplama()
        {
            InitializeComponent();
        }

        private void iki_tarih_arasi_hesaplama_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU);
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void fotograflari_al_ve_duzenle()
        {//VARSAYILAN GÖRSELLER
            tarih1_pb.Image = Image.FromFile(@"image\tarih.png");
            tarih2_pb.Image = Image.FromFile(@"image\tarih.png");
            tarih1_pb.SizeMode = tarih2_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU

        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI OLUŞAN HATALARI DÜZENLEME
            tarih_gb.ForeColor=this.ForeColor;
        }
        private void hesaplama_ve_bilgilendirme()
        {//TARİH İŞLEMLERİ
            TimeSpan hesaplama = Convert.ToDateTime(tarih2_dt.Value) - Convert.ToDateTime(tarih1_dt.Value);//ALTTAKI TARİHTEN ÜSTTEKİ TARİHİ ÇIKARMA
            tarih_bilgileri_label.Text = "Yıl:" + ((Math.Floor(Convert.ToDouble(hesaplama.TotalDays.ToString()))) / 365).ToString();//YILA GÖRE
            tarih_bilgileri_label.Text += "\nAy:" + ((Math.Floor(Convert.ToDouble(hesaplama.TotalDays.ToString())))/30).ToString();//AYA GÖRE BİLGİ
            tarih_bilgileri_label.Text += "\nGün:" + (Math.Floor(Convert.ToDouble(hesaplama.TotalDays.ToString()))).ToString();//GÜNE GÖRE BİLGİ
            tarih_bilgileri_label.Text += "\nSaat:" + (Math.Floor(Convert.ToDouble(hesaplama.TotalHours.ToString()))).ToString();//SAATE GÖRE BİLGİ
            tarih_bilgileri_label.Text += "\nDakika:" + (Math.Floor(Convert.ToDouble(hesaplama.TotalMinutes.ToString()))).ToString();//DAKİKAYA GÖRE BİLGİ
            tarih_bilgileri_label.Text += "\nSaniye:" + (Math.Floor(Convert.ToDouble(hesaplama.TotalSeconds.ToString()))).ToString();//SANİYEYE GÖRE BİLGİ
        }

        private void tarih1_dt_ValueChanged(object sender, EventArgs e)
        {//TARİH SEÇİLDİĞİNDE ÇALIŞIR
            hesaplama_ve_bilgilendirme();//TARİHLERİ HESAPLAR BİLGİ VERİR
        }

        private void tarih2_dt_ValueChanged(object sender, EventArgs e)
        {//TARİH SEÇİLDİĞİNDE ÇALIŞIR
            hesaplama_ve_bilgilendirme();//TARİHLERİ HESAPLAR BİLGİ VERİR
        }

    }
}
