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
    public partial class ozellestir : Form
    {
        public ozellestir()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        private void ozellestir_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            arkaplan_ve_yazi_ayarlari();//VARSAYILAN RENKLERI GETİRME
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            varsayilan_renkler();//STR RENKLER
        }
        private void fotograflari_al_ve_duzenle()
        {//VARSAYILAN GÖRSELLER
            ozellestir_pb.Image = Image.FromFile(@"image\ozellestirme1.png");
            renk_duzenle_menu.Image = renk_duzenle_sagtik.Image = Image.FromFile(@"image\tekrar.png");
            ozellestirme_iptal_pb.Image = Image.FromFile(@"image\ozellestirme_iptal1.png");
            iptal_et_menu.Image = iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            renk_paletleri_menu.Image = renk_paletleri_sagtik.Image = Image.FromFile(@"image\renk_paleti.png");
            arkaplan_renk_paleti_menu.Image = arkaplan_renk_paleti_sagtik.Image = Image.FromFile(@"image\renk_paleti2.png");
            yazi_renk_paleti_menu.Image = yazi_renk_paleti_sagtik.Image = Image.FromFile(@"image\renk_paleti3.png");
            hazir_tema_menu.Image = hazir_tema_sagtik.Image =varsayilan_tema_menu.Image=varsayilan_tema_sagtik.Image= Image.FromFile(@"image\tema1.png");
            koyu_tema_menu.Image = koyu_tema_sagtik.Image = Image.FromFile(@"image\tema2.png");
            rasgele_tema_olustur_menu.Image = rasgele_tema_olustur_sagtik.Image=Image.FromFile(@"image\tema3.png");
            yardim_sagtik.Image = yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");


            ozellestir_pb.SizeMode = ozellestirme_iptal_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI SORUNLARI DÜZENLEME
            tema_gb.ForeColor=Prova_gb.ForeColor = this.ForeColor;
            arkaplan_renk_paleti_btn.ForeColor = koyu_tema_btn.ForeColor = rasgele_tema_btn.ForeColor = varsayilan_tema_btn.ForeColor = yazi_renk_paleti_btn.ForeColor = Color.Black;
            tum_pencereler_cb.Checked = true;
        }
        private void arkaplan_ve_yazi_ayarlari()
        {//ARKAPLAN VE YAZI RENKERINI AYARLAMA İŞLEMLERİ
            arkaplan_kirmizi_tonu_hsb.Value = ana_pencere.arkaplan_rengi.R;
            arkaplan_yesil_tonu_hsb.Value = ana_pencere.arkaplan_rengi.G;
            arkaplan_mavi_tonu_hsb.Value = ana_pencere.arkaplan_rengi.B;
            arkaplan_kirmizi_tonu_tb.Text = arkaplan_kirmizi_tonu_hsb.Value.ToString();
            arkaplan_yesil_tonu_tb.Text = arkaplan_yesil_tonu_hsb.Value.ToString();
            arkaplan_mavi_tonu_tb.Text = arkaplan_mavi_tonu_hsb.Value.ToString();
            arkaplan_renk_ayarlari();

            yazi_rengi_kirmizi_tonu_hsb.Value = ana_pencere.yazi_rengi.R;
            yazi_rengi_yesil_tonu_hsb.Value = ana_pencere.yazi_rengi.G;
            yazi_rengi_mavi_tonu_hsb.Value = ana_pencere.yazi_rengi.B;
            yazi_rengi_kirmizi_tonu_tb.Text = yazi_rengi_kirmizi_tonu_hsb.Value.ToString();
            yazi_rengi_yesil_tonu_tb.Text = yazi_rengi_yesil_tonu_hsb.Value.ToString();
            yazi_rengi_mavi_tonu_tb.Text = yazi_rengi_mavi_tonu_hsb.Value.ToString();
            yazi_renk_ayarlari();
        }
        private void varsayilan_renkler()
        {//RENKLER YOK İSE STANDART RENKLER KULLANILIR ARKAPLAN BEYAZ YAZI SİYAH
            arkaplan_kirmizi_tonu_hsb.Value = arkaplan_yesil_tonu_hsb.Value = arkaplan_mavi_tonu_hsb.Value = 255;
            arkaplan_kirmizi_tonu_tb.Text = arkaplan_kirmizi_tonu_hsb.Value.ToString();
            arkaplan_yesil_tonu_tb.Text = arkaplan_yesil_tonu_hsb.Value.ToString();
            arkaplan_mavi_tonu_tb.Text = arkaplan_mavi_tonu_hsb.Value.ToString();
            arkaplan_renk_ayarlari();

            yazi_rengi_kirmizi_tonu_hsb.Value = yazi_rengi_yesil_tonu_hsb.Value = yazi_rengi_mavi_tonu_hsb.Value = 0;
            yazi_rengi_kirmizi_tonu_tb.Text = yazi_rengi_kirmizi_tonu_hsb.Value.ToString();
            yazi_rengi_yesil_tonu_tb.Text = yazi_rengi_yesil_tonu_hsb.Value.ToString();
            yazi_rengi_mavi_tonu_tb.Text = yazi_rengi_mavi_tonu_hsb.Value.ToString();
        }

        private void arkaplan_renk_paleti_btn_Click(object sender, EventArgs e)
        {
            ColorDialog arkaplan_renk_paleti = new ColorDialog();//PALET OLUŞTURMA
            arkaplan_renk_paleti.FullOpen = true;
            if (arkaplan_renk_paleti.ShowDialog() == DialogResult.OK)//RENK SEÇİLDİ İSE
            {
                arkaplan_kirmizi_tonu_hsb.Value = arkaplan_renk_paleti.Color.R;//KIRMIZI TONUNU AL VE DEĞERE YAPIŞTIR
                arkaplan_yesil_tonu_hsb.Value = arkaplan_renk_paleti.Color.G;//YEŞİL  TONUNU AL VE DEĞERE YAPIŞTIR
                arkaplan_mavi_tonu_hsb.Value = arkaplan_renk_paleti.Color.B;//MAVİ  TONUNU AL VE DEĞERE YAPIŞTIR
                arkaplan_renk_ayarlari();
            }
        }
        private void arkaplan_renk_ayarlari()//VERİLER DEĞİŞTİKÇE GETİREN FOKSİYON
        {
            Prova_gb.BackColor = Color.FromArgb(arkaplan_kirmizi_tonu_hsb.Value, arkaplan_yesil_tonu_hsb.Value, arkaplan_mavi_tonu_hsb.Value);
            arkaplan_kirmizi_tonu_tb.Text = arkaplan_kirmizi_tonu_hsb.Value.ToString();
            arkaplan_yesil_tonu_tb.Text = arkaplan_yesil_tonu_hsb.Value.ToString();
            arkaplan_mavi_tonu_tb.Text = arkaplan_mavi_tonu_hsb.Value.ToString();
        }
        private void arkaplan_kirmizi_tonu_hsb_Scroll(object sender, ScrollEventArgs e)
        {
            arkaplan_renk_ayarlari();//RENKLERİ DEĞİŞTİRME FOKSİYONU
        }

        private void arkaplan_yesil_tonu_hsb_Scroll(object sender, ScrollEventArgs e)
        {
            arkaplan_renk_ayarlari();//RENKLERİ DEĞİŞTİRME FOKSİYONU
        }

        private void arkaplan_mavi_tonu_hsb_Scroll(object sender, ScrollEventArgs e)
        {
            arkaplan_renk_ayarlari();//RENKLERİ DEĞİŞTİRME FOKSİYONU
        }

        private void arkaplan_kirmizi_tonu_tb_TextChanged(object sender, EventArgs e)
        {//METİN KUTUSUNA GİRİLEN DEĞERLER 0-255 ARASI OLMALI RENK KODLARI EN FAZLA BUNLARA İZİN VERDİĞİ İÇİN
            try
            {
                if (Convert.ToByte(arkaplan_kirmizi_tonu_tb.Text) >= 0 && Convert.ToByte(arkaplan_kirmizi_tonu_tb.Text) <= 255)
                {
                    arkaplan_kirmizi_tonu_hsb.Value = Convert.ToByte(arkaplan_kirmizi_tonu_tb.Text);
                    arkaplan_renk_ayarlari();
                }
            }
            catch (Exception)
            {
                arkaplan_kirmizi_tonu_tb.Text = "0";
                arkaplan_kirmizi_tonu_hsb.Value = 0;
                MessageBox.Show("0 ile 255[DAHİL] ARASINDA SAYI DEĞERLERI GİRİNİZ...", "DEĞER ARALIĞI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                arkaplan_renk_ayarlari();
            }
        }

        private void arkaplan_yesil_tonu_tb_TextChanged(object sender, EventArgs e)
        {//METİN KUTUSUNA GİRİLEN DEĞERLER 0-255 ARASI OLMALI RENK KODLARI EN FAZLA BUNLARA İZİN VERDİĞİ İÇİN
            try
            {
                if (Convert.ToByte(arkaplan_yesil_tonu_tb.Text) >= 0 && Convert.ToByte(arkaplan_yesil_tonu_tb.Text) <= 255)
                {
                    arkaplan_yesil_tonu_hsb.Value = Convert.ToByte(arkaplan_yesil_tonu_tb.Text);
                    arkaplan_renk_ayarlari();
                }
            }
            catch (Exception)
            {
                arkaplan_yesil_tonu_tb.Text = "0";
                arkaplan_yesil_tonu_hsb.Value = 0;
                MessageBox.Show("0 ile 255[DAHİL] ARASINDA SAYI DEĞERLERI GİRİNİZ...", "DEĞER ARALIĞI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                arkaplan_renk_ayarlari();
            }
        }

        private void arkaplan_mavi_tonu_tb_TextChanged(object sender, EventArgs e)
        {//METİN KUTUSUNA GİRİLEN DEĞERLER 0-255 ARASI OLMALI RENK KODLARI EN FAZLA BUNLARA İZİN VERDİĞİ İÇİN
            try
            {
                if (Convert.ToByte(arkaplan_mavi_tonu_tb.Text) >= 0 && Convert.ToByte(arkaplan_mavi_tonu_tb.Text) <= 255)
                {
                    arkaplan_mavi_tonu_hsb.Value = Convert.ToByte(arkaplan_mavi_tonu_tb.Text);
                    arkaplan_renk_ayarlari();
                }
            }
            catch (Exception)
            {
                arkaplan_mavi_tonu_tb.Text = "0";
                arkaplan_mavi_tonu_hsb.Value = 0;
                MessageBox.Show("0 ile 255[DAHİL] ARASINDA SAYI DEĞERLERI GİRİNİZ...", "DEĞER ARALIĞI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                arkaplan_renk_ayarlari();
            }
        }

        private void yazi_renk_ayarlari()//PROVA EKRANIN GÖSTERME YAZI RENGİ
        {
            Prova_gb.ForeColor = Color.FromArgb(yazi_rengi_kirmizi_tonu_hsb.Value, yazi_rengi_yesil_tonu_hsb.Value, yazi_rengi_mavi_tonu_hsb.Value);
            yazi_rengi_kirmizi_tonu_tb.Text = yazi_rengi_kirmizi_tonu_hsb.Value.ToString();
            yazi_rengi_yesil_tonu_tb.Text = yazi_rengi_yesil_tonu_hsb.Value.ToString();
            yazi_rengi_mavi_tonu_tb.Text = yazi_rengi_mavi_tonu_hsb.Value.ToString();
        }
        private void yazi_rengi_kirmizi_tonu_hsb_Scroll(object sender, ScrollEventArgs e)
        {
            yazi_renk_ayarlari();//YAZI RENK AYARLARI
        }

        private void yazi_rengi_yesil_tonu_hsb_Scroll(object sender, ScrollEventArgs e)
        {
            yazi_renk_ayarlari();//YAZI RENK AYARLARI
        }

        private void yazi_rengi_mavi_tonu_hsb_Scroll(object sender, ScrollEventArgs e)
        {
            yazi_renk_ayarlari();//YAZI RENK AYARLARI
        }

        private void yazi_rengi_kirmizi_tonu_tb_TextChanged(object sender, EventArgs e)
        {//METİN KUTUSUNA GİRİLEN DEĞERLER 0-255 ARASI OLMALI RENK KODLARI EN FAZLA BUNLARA İZİN VERDİĞİ İÇİN
            try
            {
                if (Convert.ToByte(yazi_rengi_kirmizi_tonu_tb.Text) >= 0 && Convert.ToByte(yazi_rengi_kirmizi_tonu_tb.Text) <= 255)
                {

                    yazi_rengi_kirmizi_tonu_hsb.Value = Convert.ToByte(yazi_rengi_kirmizi_tonu_tb.Text);
                    yazi_renk_ayarlari();
                }
            }
            catch (Exception)
            {
                yazi_rengi_kirmizi_tonu_tb.Text = "0";
                yazi_rengi_kirmizi_tonu_hsb.Value = 0;
                MessageBox.Show("0 ile 255[DAHİL] ARASINDA SAYI DEĞERLERI GİRİNİZ...", "DEĞER ARALIĞI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                yazi_renk_ayarlari();
            }
        }

        private void yazi_rengi_yesil_tonu_tb_TextChanged(object sender, EventArgs e)
        {//METİN KUTUSUNA GİRİLEN DEĞERLER 0-255 ARASI OLMALI RENK KODLARI EN FAZLA BUNLARA İZİN VERDİĞİ İÇİN
            try
            {
                if (Convert.ToByte(yazi_rengi_yesil_tonu_tb.Text) >= 0 && Convert.ToByte(yazi_rengi_yesil_tonu_tb.Text) <= 255)
                {

                    yazi_rengi_yesil_tonu_hsb.Value = Convert.ToByte(yazi_rengi_yesil_tonu_tb.Text);
                    yazi_renk_ayarlari();
                }
            }
            catch (Exception)
            {
                yazi_rengi_yesil_tonu_tb.Text = "0";
                yazi_rengi_yesil_tonu_hsb.Value = 0;
                MessageBox.Show("0 ile 255[DAHİL] ARASINDA SAYI DEĞERLERI GİRİNİZ...", "DEĞER ARALIĞI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                yazi_renk_ayarlari();
            }
        }

        private void yazi_rengi_mavi_tonu_tb_TextChanged(object sender, EventArgs e)
        {//METİN KUTUSUNA GİRİLEN DEĞERLER 0-255 ARASI OLMALI RENK KODLARI EN FAZLA BUNLARA İZİN VERDİĞİ İÇİN
            try
            {
                if (Convert.ToByte(yazi_rengi_mavi_tonu_tb.Text) >= 0 && Convert.ToByte(yazi_rengi_mavi_tonu_tb.Text) <= 255)
                {

                    yazi_rengi_mavi_tonu_hsb.Value = Convert.ToByte(yazi_rengi_mavi_tonu_tb.Text);
                    yazi_renk_ayarlari();
                }
            }
            catch (Exception)
            {
                yazi_rengi_mavi_tonu_tb.Text = "0";
                yazi_rengi_mavi_tonu_hsb.Value = 0;
                MessageBox.Show("0 ile 255[DAHİL] ARASINDA SAYI DEĞERLERI GİRİNİZ...", "DEĞER ARALIĞI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                yazi_renk_ayarlari();
            }
        }

        private void yazi_renk_paleti_btn_Click(object sender, EventArgs e)
        {
            ColorDialog yazi_renk_paleti = new ColorDialog();//PALET OLUŞTURMA KODU
            yazi_renk_paleti.FullOpen = true;//TAM PENCERE AÇMA
            if (yazi_renk_paleti.ShowDialog() == DialogResult.OK)//RENK SEÇİLDİ İSE
            {

                yazi_rengi_kirmizi_tonu_hsb.Value = yazi_renk_paleti.Color.R;//RENKLERI AYARLA
                yazi_rengi_yesil_tonu_hsb.Value = yazi_renk_paleti.Color.G;//RENKLERI AYARLA
                yazi_rengi_mavi_tonu_hsb.Value = yazi_renk_paleti.Color.B;//RENKLERI AYARLA
                yazi_renk_ayarlari();
            }
        }

        private void varsayilan_tema_btn_Click(object sender, EventArgs e)
        {
            varsayilan_renkler();//ARKAPLAN:BEYAZ YAZI:SİYAH OLANLAR
        }

        private void koyu_tema_btn_Click(object sender, EventArgs e)
        {//KOYU TEMA RENK DEĞERLERİ
            arkaplan_kirmizi_tonu_hsb.Value = 50;
            arkaplan_yesil_tonu_hsb.Value = 50;
            arkaplan_mavi_tonu_hsb.Value = 50;
            yazi_rengi_kirmizi_tonu_hsb.Value = 255;
            yazi_rengi_yesil_tonu_hsb.Value = 255;
            yazi_rengi_mavi_tonu_hsb.Value = 255;
            arkaplan_renk_ayarlari();
            yazi_renk_ayarlari();
        }
        Random tema_olustur = new Random();
        private void rasgele_tema_btn_Click(object sender, EventArgs e)
        {//RASGELE OLUŞTURMA TEMA
            arkaplan_kirmizi_tonu_hsb.Value = tema_olustur.Next(256);
            arkaplan_yesil_tonu_hsb.Value = tema_olustur.Next(256);
            arkaplan_mavi_tonu_hsb.Value = tema_olustur.Next(256);
            yazi_rengi_kirmizi_tonu_hsb.Value = tema_olustur.Next(256);
            yazi_rengi_yesil_tonu_hsb.Value = tema_olustur.Next(256);
            yazi_rengi_mavi_tonu_hsb.Value = tema_olustur.Next(256);
            arkaplan_renk_ayarlari();
            yazi_renk_ayarlari();
        }

        private void ozellestir_pb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ARKAPLAN VE YAZI RENGİ DEĞİŞTİRİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//KAYIT ÖNCESİ SORU
            {
                renkleri_degistir();//RENKLERI KEYDETME
            }
        }
        private void renkleri_degistir()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                if (anapencere_cb.Checked == true)//SADECE ANAPENCEREDE UYGULANACAKSA
                {
                    komut = new SqlCommand("update ozellestirme_tablosu set arkaplan_r=" + arkaplan_kirmizi_tonu_hsb.Value + ",arkaplan_g=" + arkaplan_yesil_tonu_hsb.Value + ",arkaplan_b=" + arkaplan_mavi_tonu_hsb.Value + ",yazi_rengi_r=" + yazi_rengi_kirmizi_tonu_hsb.Value + ",yazi_rengi_g=" + yazi_rengi_yesil_tonu_hsb.Value + ",yazi_rengi_b=" + yazi_rengi_mavi_tonu_hsb.Value + ",uygulanacak_form=0 where tcno='"+giris_penceresi.tcno+"'", baglanti);//RENK KODLARI
                }
                else if (tum_pencereler_cb.Checked == true)//TÜM PENCERELERDE UYGULANACAKSA
                {
                    komut = new SqlCommand("update ozellestirme_tablosu set arkaplan_r=" + arkaplan_kirmizi_tonu_hsb.Value + ",arkaplan_g=" + arkaplan_yesil_tonu_hsb.Value + ",arkaplan_b=" + arkaplan_mavi_tonu_hsb.Value + ",yazi_rengi_r=" + yazi_rengi_kirmizi_tonu_hsb.Value + ",yazi_rengi_g=" + yazi_rengi_yesil_tonu_hsb.Value + ",yazi_rengi_b=" + yazi_rengi_mavi_tonu_hsb.Value + ",uygulanacak_form=1 where tcno='"+giris_penceresi.tcno+"'", baglanti);//RENK KODLARI
                }
                komut.ExecuteNonQuery();//KOMUTLARI ÇALIŞTIRMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                MessageBox.Show("ARKAPLAN VE YAZI RENGİ DEĞİŞTİRİLDİ.", "RENK İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);//BİLGİLENDİRME
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void ozellestir_pb_MouseMove(object sender, MouseEventArgs e)
        {
            ozellestir_pb.Image = Image.FromFile(@"image\ozellestirme2.png");//GÖRSEL EFEKT 
        }

        private void ozellestir_pb_MouseLeave(object sender, EventArgs e)
        {
            ozellestir_pb.Image = Image.FromFile(@"image\ozellestirme1.png");//VARSAYILAN GÖRSEL
        }

        private void ozellestirme_iptal_pb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }

        private void ozellestirme_iptal_pb_MouseMove(object sender, MouseEventArgs e)
        {
            ozellestirme_iptal_pb.Image = Image.FromFile(@"image\ozellestirme_iptal2.png");//GÖRSEL EFEKT
        }

        private void ozellestirme_iptal_pb_MouseLeave(object sender, EventArgs e)
        {
            ozellestirme_iptal_pb.Image = Image.FromFile(@"image\ozellestirme_iptal1.png");//VARSAYILAN GÖRSEL
        }

        private void arkaplan_renk_paleti_btn_MouseMove(object sender, MouseEventArgs e)
        {//BUTON RENKLERI 
            arkaplan_renk_paleti_btn.BackColor = Color.Black;
            arkaplan_renk_paleti_btn.ForeColor = Color.Red;
        }

        private void arkaplan_renk_paleti_btn_MouseLeave(object sender, EventArgs e)
        {//BUTON RENKLERI 
            arkaplan_renk_paleti_btn.BackColor = Color.White;
            arkaplan_renk_paleti_btn.ForeColor = Color.Black;
        }

        private void yazi_renk_paleti_btn_MouseMove(object sender, MouseEventArgs e)
        {//BUTON RENKLERI 
            yazi_renk_paleti_btn.BackColor = Color.Black;
            yazi_renk_paleti_btn.ForeColor = Color.Red;
        }

        private void yazi_renk_paleti_btn_MouseLeave(object sender, EventArgs e)
        {//BUTON RENKLERI 
            yazi_renk_paleti_btn.BackColor = Color.White;
            yazi_renk_paleti_btn.ForeColor = Color.Black;
        }

        private void varsayilan_tema_btn_MouseMove(object sender, MouseEventArgs e)
        {//BUTON RENKLERI 
            varsayilan_tema_btn.BackColor = Color.Black;
            varsayilan_tema_btn.ForeColor = Color.Red;
        }

        private void varsayilan_tema_btn_MouseLeave(object sender, EventArgs e)
        {//BUTON RENKLERI 
            varsayilan_tema_btn.BackColor = Color.White;
            varsayilan_tema_btn.ForeColor = Color.Black;
        }

        private void koyu_tema_btn_MouseMove(object sender, MouseEventArgs e)
        {//BUTON RENKLERI 
            koyu_tema_btn.BackColor = Color.Black;
            koyu_tema_btn.ForeColor = Color.Red;
        }

        private void koyu_tema_btn_MouseLeave(object sender, EventArgs e)
        {//BUTON RENKLERI 
            koyu_tema_btn.BackColor = Color.White;
            koyu_tema_btn.ForeColor = Color.Black;
        }

        private void rasgele_tema_btn_MouseMove(object sender, MouseEventArgs e)
        {//BUTON RENKLERI 
            rasgele_tema_btn.BackColor = Color.Black;
            rasgele_tema_btn.ForeColor = Color.Red;
        }

        private void rasgele_tema_btn_MouseLeave(object sender, EventArgs e)
        {//BUTON RENKLERI 
            rasgele_tema_btn.BackColor = Color.White;
            rasgele_tema_btn.ForeColor = Color.Black;
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESINI AÇMA KOMUTLARI
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }

    }
}
