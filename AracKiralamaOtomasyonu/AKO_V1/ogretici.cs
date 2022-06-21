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
    public partial class ogretici : Form
    {
        public ogretici()
        {
            InitializeComponent();
        }

        private void ogretici_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void fotograflari_al_ve_duzenle()
        {//VARSAYILAN GÖRSELLER
            bilgi_simgesi1_pb.Image = Image.FromFile(@"image\bilgi_verme.png");
            bilgi_simgesi2_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");
            atla_pb.Image = Image.FromFile(@"image\devam_et1.png");
            atla_menu.Image = Image.FromFile(@"image\devam_et1.png");
            iptal_et_pb.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            bilgi_verme_pb.Image = Image.FromFile(@"image\bilgi_verme.png");
            bilgi_verme_pb.SizeMode = atla_pb.SizeMode = iptal_et_pb.SizeMode = bilgi_simgesi1_pb.SizeMode = bilgi_simgesi2_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }

        private void kisitlamalar_ve_duzenlemeler()
        {//İLK SEÇİM İÇİN EKLEMELER
            hikaye_combo.Items.Add("Bremen Mızıkacıları");
            hikaye_combo.Items.Add("Güzel ve Çirkin");
            hikaye_combo.Items.Add("Pinokyo");
            hikaye_combo.Items.Add("Kırmızı Başlıklı Kız");
            hikaye_combo.Items.Add("Fareli Köyün Kavalcısı");
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI SORUNLARI DÜZENLEME
            egitim_islemleri_durumu_gb.ForeColor = ogretici1_gb.ForeColor = ogretici2_gb.ForeColor = this.ForeColor;
        }
        private void bilgi_simgesi2_pb_Click(object sender, EventArgs e)
        {
            seviye = 1;//ÖĞRETİM SEVİYESİ
            seviyeler();//SEVİYE KONTROL
        }
        byte seviye = 1;
        private void seviyeler()
        {
            if (seviye == 1)//SEVİYE DOĞRU İRE GİRİŞ YAPILIR
            {//YENİ EĞİTİME GEÇİLİR
                if (hikaye_combo.Text != "")
                {
                    MessageBox.Show(hikaye_combo.Text.ToUpper() + " MASALINI SEÇTİNİZ VE ÖĞRENDİNİZ.", hikaye_combo.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);//BİLGİLENDIRME
                    ogretici1_gb.Visible = false;
                    ogretici2_gb.Location = new Point(12, 29);
                    ogretici2_gb.Visible = true;
                    seviye = 2;
                    egitim_progress.Value += 10;
                    egitim_label.Text = "Tamamlanan Eğitim(%"+egitim_progress.Value.ToString()+")";
                }
                else
                {
                    MessageBox.Show("MASAL SEÇİNİZ...", "UYRAI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (seviye == 2)//SEVİYE DOĞRU İRE GİRİŞ YAPILIR
            {

                if (kutu_tb.Text.ToUpper() == "MERHABA")
                {
                    MessageBox.Show("BAŞARILI BİR ŞEKİLDE KAYDETTİNİZ.", "YAZI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    yaziyi_iptal_et_menu.Visible = true;
                    yaziyi_iptal_et_menu.Enabled = false;
                    yaziyi_kaydet_menu.ShortcutKeys = Keys.Control | Keys.F1;
                    yaziyi_iptal_et_menu.ShortcutKeys = Keys.Control | Keys.F2;//İnternet üzerinden bulundu.
                    kutu_tb.Text = "";
                    Bilgilendirme2_label.Text = "Üst Menü Standartları 1:Ekleme ve İptal Etme işlemleri [Ctrl+F1 ve Ctrl+F2]";
                    diger_uygulamalar_label.Text = "Uygulama 2:Aşağıda ki kutucuğa 'Merhaba AKO' yaz ve Ctrl+F1'e Tıklayıp Yazıyı Kaydet\ndaha sonra Ctrl+F2'e Tıklayıp Yazıyı İptal Et";
                    ogretici2_gb.Height = 170;
                    kutu_tb.Location = new Point(kutu_tb.Location.X, kutu_tb.Location.Y + 20);
                    seviye = 3;
                    egitim_islemleri_durumu_gb.Location = new Point(egitim_islemleri_durumu_gb.Location.X, egitim_islemleri_durumu_gb.Location.Y + 20);
                    this.Height += 20;
                    egitim_progress.Value += 10;
                    egitim_label.Text = "Tamamlanan Eğitim(%" + egitim_progress.Value.ToString() + ")";
                }
                else
                {
                    MessageBox.Show("MERHABA YAZINIZ...", "UYRAI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (seviye == 3)//SEVİYE DOĞRU İRE GİRİŞ YAPILIR
            {

                if (kutu_tb.Text.ToUpper() == "MERHABA AKO")
                {
                    if (kutu_tb.ReadOnly == false)
                    {
                        kutu_tb.ReadOnly = true;
                        yaziyi_kaydet_menu.Enabled = false;
                        yaziyi_iptal_et_menu.Enabled = true;
                        MessageBox.Show("BAŞARILI BİR ŞEKİLDE KAYDETTİNİZ.", "YAZI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        egitim_progress.Value += 10;
                        egitim_label.Text = "Tamamlanan Eğitim(%" + egitim_progress.Value.ToString() + ")";

                    }
                    else if (kutu_tb.ReadOnly == true)//SEVİYE DOĞRU İRE GİRİŞ YAPILIR
                    {
                        seviye = 4;
                        temizle_menu.Visible = true;
                        yaziyi_kaydet_menu.ShortcutKeys = Keys.Control | Keys.F1;
                        temizle_menu.ShortcutKeys = Keys.Control | Keys.F2;
                        yaziyi_iptal_et_menu.ShortcutKeys = Keys.Control | Keys.F3;
                        temizle_menu.Enabled = false;
                        yaziyi_iptal_et_menu.Enabled = false;
                        kutu_tb.ReadOnly = false;
                        kutu_tb.Text = "";
                        yaziyi_kaydet_menu.Enabled = true;
                        Bilgilendirme2_label.Text = "Üst Menü Standartları 2:Ekleme,Temizleme ve İptal Etme işlemleri [Ctrl+F1,Ctrl+F2 ve Ctrl+F3] ";
                        diger_uygulamalar_label.Text = "Uygulama 3:Aşağıda ki kutucuğa Öğretici yaz ve Ctrl+F1'e Tıklayıp 'Yazıyı Kaydet'\ndaha sonra Ctrl+F3'e Tıklayıp 'Yazıyı İptal Et'\nson olarak Ctrl+F2'e  Tıklayıp 'Temizle'";

                        kutu_tb.Location = new Point(kutu_tb.Location.X, kutu_tb.Location.Y + 20);
                        egitim_islemleri_durumu_gb.Location = new Point(egitim_islemleri_durumu_gb.Location.X, egitim_islemleri_durumu_gb.Location.Y + 20);
                        this.Height += 20;
                        ogretici2_gb.Height = 190;
                        egitim_progress.Value += 10;
                        egitim_label.Text = "Tamamlanan Eğitim(%" + egitim_progress.Value.ToString() + ")";
                        MessageBox.Show("BAŞARILI BİR ŞEKİLDE İPTAL ETTİNİZ.", "YAZI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("MERHABA AKO YAZINIZ...", "UYRAI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (seviye == 4)//SEVİYE DOĞRU İRE GİRİŞ YAPILIR
            {
                if (kutu_tb.Text.ToUpper() == "ÖĞRETİCİ")
                {
                    if (temizle_menu.Enabled == false)
                    {
                        if (kutu_tb.ReadOnly == false)
                        {
                            kutu_tb.ReadOnly = true;
                            yaziyi_kaydet_menu.Enabled = false;
                            yaziyi_iptal_et_menu.Enabled = true;
                            egitim_progress.Value += 10;
                            egitim_label.Text = "Tamamlanan Eğitim(%" + egitim_progress.Value.ToString() + ")";
                            MessageBox.Show("BAŞARILI BİR ŞEKİLDE KAYDETTİNİZ.", "YAZI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (kutu_tb.ReadOnly == true)
                        {
                            kutu_tb.ReadOnly = false;
                            yaziyi_iptal_et_menu.Enabled = false;
                            temizle_menu.Enabled = true;
                            egitim_progress.Value += 10;
                            egitim_label.Text = "Tamamlanan Eğitim(%" + egitim_progress.Value.ToString() + ")";
                            MessageBox.Show("BAŞARILI BİR ŞEKİLDE İPTAL ETTİNİZ.", "YAZI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (temizle_menu.Enabled == true)
                    {
                        kutu_tb.Clear();
                        temizle_menu.Enabled = false;
                        yaziyi_kaydet_menu.Enabled = false;
                        anlamini_ogren.Visible = true;
                        Bilgilendirme2_label.Text = "Diğer Üst Menülerin Kullanımı:Crtl+İlk Baş Harfi'dir.";
                        diger_uygulamalar_label.Text = "Uygulama 4:Aşağıda ki kutucuğa 'ibrahim' yaz ve Ctrl+A'ya Tıklayıp 'Anlamını Öğren'";
                        seviye = 5;
                        egitim_progress.Value += 10;
                        egitim_label.Text = "Tamamlanan Eğitim(%" + egitim_progress.Value.ToString() + ")";
                        MessageBox.Show("BAŞARILI BİR ŞEKİLDE KUTUYU TEMİZLEDİNİZ.", "YAZI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("ÖĞRETİCİ YAZINIZ...", "UYRAI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (seviye == 5)//SEVİYE DOĞRU İRE GİRİŞ YAPILIR
            {
                if (kutu_tb.Text.ToUpper()=="İBRAHİM")
                {
                    egitim_progress.Value += 10;
                    egitim_label.Text = "Tamamlanan Eğitim(%" + egitim_progress.Value.ToString() + ")";
                    seviye = 6;
                    kutu_tb.Visible = false;
                    anlamini_ogren.Enabled = false;
                    diger_isimlerin_anlamlari_menu.Visible = true;
                    Bilgilendirme2_label.Text = "Üst Menülerin Alt Menülerinin Kullanımı:Crtl+Shift+İlk Baş Harfi'dir.";
                    diger_uygulamalar_label.Text = "Uygulama 5:'Diğer İsimlerin Anlamı' Altında Bulunan Menülerde \nMücahit Ve İlkay İsimleri bulunmaktadır.\nBunlaradan Birisini Seçerek Ctrl+Shift+Baş Harf'ya Tıklayıp ismin Anlamını Öğrenin.";
                    MessageBox.Show("BAŞARILI BİR ŞEKİLDE 'ANLAMINI ÖĞREN'E ULAŞTINIZ.", "YAZI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İBRAHİM YAZINIZ...", "UYRAI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (seviye == 6)//SEVİYE DOĞRU İRE GİRİŞ YAPILIR
            {
                egitim_progress.Value += 10;
                egitim_label.Text = "Tamamlanan Eğitim(%" + egitim_progress.Value.ToString() + ")";
                seviye = 7;
                diger_isimlerin_anlamlari_menu.Enabled = false;
                ogretici2_gb.ContextMenuStrip = ogretici_sagtik;
                Bilgilendirme2_label.Text = "Sağ Tık Menü:Üst Menüler gibi işleme sahiptir.";
                diger_uygulamalar_label.Text = "Uygulama 6:Farenin Sağ Tuşuna Tıklayın.Açılan Menüden 'Ve Bitiyor :)' tıklayın.";
                MessageBox.Show("BAŞARILI BİR ŞEKİLDE 'DİĞER İSİMLERİN ANLAMLARINA' ULAŞTINIZ.", "YAZI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (seviye == 7)//SEVİYE DOĞRU İRE GİRİŞ YAPILIR
            {
                egitim_progress.Value += 10;
                egitim_label.Text = "Tamamlanan Eğitim(%" + egitim_progress.Value.ToString() + ")";
                Bilgilendirme2_label.Text = "EĞİTİMİNİZ BİTMİŞTİR.";
                diger_uygulamalar_label.Text = "";
                ogretici_sagtik.Enabled = false;
                MessageBox.Show("BAŞARILI BİR ŞEKİLDE SAĞTIK MENÜYÜ ÖĞRENDİNİZ.", "YAZI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void direk_gec()
        {//EĞİTİM SEVİYESİNİ DİREK ATLAMA
            if (seviye == 1)
            {
                ogretici1_gb.Visible = false;
                ogretici2_gb.Location = new Point(12, 29);
                ogretici2_gb.Visible = true;
                seviye = 2;
            }
            else if (seviye == 2)
            {
                yaziyi_iptal_et_menu.Visible = true;
                yaziyi_iptal_et_menu.Enabled = false;
                yaziyi_kaydet_menu.ShortcutKeys = Keys.Control | Keys.F1;
                yaziyi_iptal_et_menu.ShortcutKeys = Keys.Control | Keys.F2;//İnternet üzerinden bulundu.
                kutu_tb.Text = "";
                Bilgilendirme2_label.Text = "Üst Menü Standartları 1:Ekleme ve İptal Etme işlemleri [Ctrl+F1 ve Ctrl+F2]";
                diger_uygulamalar_label.Text = "Uygulama 2:Aşağıda ki kutucuğa 'Merhaba AKO' yaz ve Ctrl+F1'e Tıklayıp Yazıyı Kaydet\ndaha sonra Ctrl+F2'e Tıklayıp Yazıyı İptal Et";
                ogretici2_gb.Height = 170;
                kutu_tb.Location = new Point(kutu_tb.Location.X, kutu_tb.Location.Y + 20);
                seviye = 3;
                egitim_islemleri_durumu_gb.Location = new Point(egitim_islemleri_durumu_gb.Location.X, egitim_islemleri_durumu_gb.Location.Y + 20);
                this.Height += 20;
            }
            else if (seviye == 3)
            {
                seviye = 4;
                temizle_menu.Visible = true;
                yaziyi_kaydet_menu.ShortcutKeys = Keys.Control | Keys.F1;
                temizle_menu.ShortcutKeys = Keys.Control | Keys.F2;
                yaziyi_iptal_et_menu.ShortcutKeys = Keys.Control | Keys.F3;
                temizle_menu.Enabled = false;
                yaziyi_iptal_et_menu.Enabled = false;
                kutu_tb.ReadOnly = false;
                kutu_tb.Text = "";
                yaziyi_kaydet_menu.Enabled = true;
                Bilgilendirme2_label.Text = "Üst Menü Standartları 2:Ekleme,Temizleme ve İptal Etme işlemleri [Ctrl+F1,Ctrl+F2 ve Ctrl+F3] ";
                diger_uygulamalar_label.Text = "Uygulama 3:Aşağıda ki kutucuğa Öğretici yaz ve Ctrl+F1'e Tıklayıp 'Yazıyı Kaydet'\ndaha sonra Ctrl+F3'e Tıklayıp 'Yazıyı İptal Et'\nson olarak Ctrl+F2'e  Tıklayıp 'Temizle'";

                kutu_tb.Location = new Point(kutu_tb.Location.X, kutu_tb.Location.Y + 20);
                egitim_islemleri_durumu_gb.Location = new Point(egitim_islemleri_durumu_gb.Location.X, egitim_islemleri_durumu_gb.Location.Y + 20);
                this.Height += 20;
                ogretici2_gb.Height = 190;
            }
            else if (seviye == 4)
            {
                kutu_tb.Clear();
                temizle_menu.Enabled = false;
                yaziyi_kaydet_menu.Enabled = false;
                anlamini_ogren.Visible = true;
                Bilgilendirme2_label.Text = "Diğer Üst Menülerin Kullanımı:Crtl+İlk Baş Harfi'dir.";
                diger_uygulamalar_label.Text = "Uygulama 4:Aşağıda ki kutucuğa 'ibrahim' yaz ve Ctrl+A'ya Tıklayıp 'Anlamını Öğren'";
                seviye = 5;
            }
            else if (seviye==5)
            {
                seviye = 6;
                kutu_tb.Visible = false;
                anlamini_ogren.Enabled = false;
                diger_isimlerin_anlamlari_menu.Visible = true;
                Bilgilendirme2_label.Text = "Üst Menülerin Alt Menülerinin Kullanımı:Crtl+Shift+İlk Baş Harfi'dir.";
                diger_uygulamalar_label.Text = "Uygulama 5:'Diğer İsimlerin Anlamı' Altında Bulunan Menülerde \nMücahit Ve İlkay İsimleri bulunmaktadır.\nBunlaradan Birisini Seçerek Ctrl+Shift+Baş Harf'ya Tıklayıp ismin Anlamını Öğrenin.";
            }
            else if (seviye==6)
            {
                seviye = 7;
                diger_isimlerin_anlamlari_menu.Enabled = false;
                ogretici2_gb.ContextMenuStrip = ogretici_sagtik;
                Bilgilendirme2_label.Text = "Sağ Tık Menü:Üst Menüler gibi işleme sahiptir.";
                diger_uygulamalar_label.Text = "Uygulama 6:Farenin Sağ Tuşuna Tıklayın.Açılan Menüden 'Ve Bitiyor :)' tıklayın.";
            }
            else if (seviye==7)
            {
                Bilgilendirme2_label.Text = "EĞİTİMİNİZ BİTMİŞTİR.";
                diger_uygulamalar_label.Text = "";
                ogretici_sagtik.Enabled= false;
            }
        }

        private void bilgi_simgesi2_pb_MouseMove(object sender, MouseEventArgs e)
        {
            bilgi_simgesi2_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi2.png");
        }

        private void bilgi_simgesi2_pb_MouseLeave(object sender, EventArgs e)
        {
            bilgi_simgesi2_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");
        }

        private void atla_pb_Click(object sender, EventArgs e)
        {
            direk_gec();
        }

        private void atla_pb_MouseMove(object sender, MouseEventArgs e)
        {
            atla_pb.Image = Image.FromFile(@"image\devam_et2.png");//GÖRSEL EFEKTLER
        }

        private void atla_pb_MouseLeave(object sender, EventArgs e)
        {
            atla_pb.Image = Image.FromFile(@"image\devam_et1.png");//VARSAYILAN GÖRSELLER
        }

        private void iptal_et_pb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }

        private void iptal_et_pb_MouseMove(object sender, MouseEventArgs e)
        {
            iptal_et_pb.Image = Image.FromFile(@"image\iptal_et2.png");//GÖRSEL EFEKTLER
        }

        private void iptal_et_pb_MouseLeave(object sender, EventArgs e)
        {
            iptal_et_pb.Image = Image.FromFile(@"image\iptal_et1.png");//VARSAYILAN GÖRSELLER
        }

        private void yaziyi_kaydet_menu_Click(object sender, EventArgs e)
        {
            seviyeler();
        }

        private void yaziyi_iptal_et_menu_Click(object sender, EventArgs e)
        {
            seviyeler();
        }

        private void temizle_menu_Click(object sender, EventArgs e)
        {
            seviyeler();
        }

        private void anlamini_ogren_Click(object sender, EventArgs e)
        {
            seviyeler();
        }

        private void mucahit_menu_Click(object sender, EventArgs e)
        {
            seviyeler();
        }

        private void ilkay_menu_Click(object sender, EventArgs e)
        {
            seviyeler();
        }

        private void ve_bitiyor_sagtik_Click(object sender, EventArgs e)
        {
            seviyeler();
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESINI AÇMA
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
