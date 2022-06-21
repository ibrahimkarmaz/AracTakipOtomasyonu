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
    public partial class yardim_pencersi : Form
    {
        public yardim_pencersi()
        {
            InitializeComponent();
        }
        //BU PENCERE BETA AŞAMASINDADIR.
        private void yardim_pencersi_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
            }
        }
        private void fotograflari_al_ve_duzenle()
        {//GÖRSELLERİN EKLENDİĞİ YER
            ara_pb.Image = Image.FromFile(@"image\arama1.png");

            ara_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void ara_pb_Click(object sender, EventArgs e)
        {
            if (arama_tb.Text.ToUpper() == "MENÜLER")//ARANACAK KONU VARSA BİLGİ VERİR.
            {
                yardim_bilgileri_tb.Text = @"Üst Menü Standartları 1:Ekleme ve İptal Etme işlemleri [Ctrl+F1 ve Ctrl+F2]

Üst Menü Standartları 2:Ekleme,Temizleme ve İptal Etme işlemleri [Ctrl+F1,Ctrl+F2 ve Ctrl+F3]

Diğer Üst Menülerin Kullanımı:Crtl+İlk Baş Harfi'dir.

Üst Menülerin Alt Menülerinin Kullanımı:Crtl+Shift+İlk Baş Harfi'dir.

Sağ Tık Menü:Üst Menüler gibi işleme sahiptir.[FARENİN SAĞ TIKI İLE ÇALIŞIR.]";
            }
            else if (arama_tb.Text.ToUpper() == "GİRİŞ YAPAMIYORUM")//ARANACAK KONU VARSA BİLGİ VERİR.
            {
                yardim_bilgileri_tb.Text = @"GÖREV,KULLANICI ADI VE PAROLADAN EMİN OLUN.
parolanızı değiştirip tekrar deneyebilirsiniz.";
            }
        }

        private void ara_pb_MouseMove(object sender, MouseEventArgs e)
        {
            ara_pb.Image = Image.FromFile(@"image\arama2.png");//GÖRSEL EFEKTİ
        }

        private void ara_pb_MouseLeave(object sender, EventArgs e)
        {
            ara_pb.Image = Image.FromFile(@"image\arama1.png");//GÖRSEL EFEKTİ GERİ ALIR.
        }
    }
}
