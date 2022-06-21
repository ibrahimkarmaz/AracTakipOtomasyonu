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
    public partial class arac_cikar : Form
    {
        public arac_cikar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        string arac_id = "";
        private void arac_cikar_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            plakalari_getir();//PLAKALARI GETİRİR
            kiralanan_plakalari_sil();//ARAÇ KİRALANMIŞ İSE İŞLEM YAPILMAMASINI SAĞLAR VE SEÇİM KUTUSUNDAN SİLER
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            secilen_plaka();
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }

        private void fotograflari_al_ve_duzenle()
        {
            //GÖRSELLER
            arac_cikar_pb.Image = Image.FromFile(@"image\arac_cikar1.png");
            arac_cikar_menu.Image = Image.FromFile(@"image\cikar.png");
            arac_cikar_sagtik.Image = Image.FromFile(@"image\cikar.png");
            iptalet_pb.Image = Image.FromFile(@"image\arac_iptal1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            arac_bilgileri_menu.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");
            arac_bilgileri_sagtik.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");
            acik_alt_menu.Image = Image.FromFile(@"image\acik_goz.png");
            acik_alt_sagtik.Image = Image.FromFile(@"image\acik_goz.png");
            kapali_alt_menu.Image = Image.FromFile(@"image\kapali_goz.png");
            kapali_alt_sagtik.Image = Image.FromFile(@"image\kapali_goz.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");

            plaka_pb.Image = Image.FromFile(@"image\plakano.png");
            arac_hakkinda_bilgi_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");
            arac_hakkinda_bilgi_pb2.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");
            //GÖRSELLERİ SIĞDIRMA
            arac_cikar_pb.SizeMode = iptalet_pb.SizeMode = plaka_pb.SizeMode = arac_hakkinda_bilgi_pb2.SizeMode = arac_hakkinda_bilgi_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            bilgi_label.Text = "";//SEÇİLEN ARAÇ HAKKINDA BİLGİ VERİR
            if (plaka_combo.Items.Count > 0)
            {
                plaka_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
            //BİLGİLERİN GÖSTERİLİP GÖSTERİLMİYECEĞİ İŞLEMLERİ
            kapali_alt_menu.Visible = true;
            kapali_alt_sagtik.Visible = true;
            acik_alt_menu.Visible = false;
            acik_alt_sagtik.Visible = false;
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI OLUŞAN SORUNLARI DÜZENLEME
            arac_cikar_gb.ForeColor = this.ForeColor;
        }
        private void plakalari_getir()
        {
            plaka_combo.Items.Clear();
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(plaka) AS Plaka from arac_tablosu where arsiv=1", baglanti);//PLAKA ÇEKME KOMUTLARI
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUNUYOR
                {
                    plaka_combo.Items.Add(oku["Plaka"]);//PLAKA SEÇİM KUTUSUNA AKTARILIYOR
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void kiralanan_plakalari_sil()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select plaka as Plaka from kiralama_tablosu inner join arac_tablosu on kiralama_tablosu.arac_id =arac_tablosu.arac_id where kiralama_tablosu.arsiv=1", baglanti);//KİRALANAN PLAKALARI GETİREN KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUYOR
                {
                    plaka_combo.Items.Remove(oku["Plaka"]);//KİRALANAN ARAÇLARI SİLİYOR
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                if (plaka_combo.Items.Count > 0)//ELEMAN VAR MI KONTROL
                {
                    plaka_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
                }
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void secilen_plaka()
        {
            try
            {
                bilgi_label.Text = "";//PENCEREDE BİLGİ VERME NESNESİ
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from arac_tablosu where plaka='" + plaka_combo.SelectedItem + "'", baglanti);//PLAKAYA GÖRE BİLGİLERİ ALIYOR
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    arac_id = oku["arac_id"].ToString();//ÇIKARMA İŞLEMİ YAPILIRSA DİYE PK ALINIYOR
                    //ARAÇ HAKKINDA BİLGİLER PENCEREDE GÖSTERİLİYOR
                    bilgi_label.Text += "Marka:" + oku["marka"].ToString() + "\nModel:" + oku["model"].ToString() + "\nKategori:" + oku["kategori"].ToString() + "\nRenk:" + oku["renk"].ToString() + "\nDepo Doluluk Yüzdesi(%):" + oku["yakit_doluluk_yuzdesi"] + "\nKiloMetre[KM]:" + oku["km"].ToString() + "\nVites Türü:" + oku["vites_turu"].ToString() + "\nKoltuk Sayısı:" + oku["koltuk_sayisi"].ToString() + "\nKapı Sayısı:" + oku["kapi_sayisi"].ToString() + "\nKira Ücreti:" + oku["kira_ucreti"].ToString();
                    if (Convert.ToByte(oku["hasar"]) == 0)
                    {
                        bilgi_label.Text += "\nKaza Durumu:Yok";
                    }
                    else if (Convert.ToByte(oku["hasar"]) == 1)
                    {
                        bilgi_label.Text += "\nKaza Durumu:Var";
                    }
                    bilgi_label.Text += "\nAçıklama:" + oku["aciklama"].ToString();
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void plaka_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilen_plaka();//SEÇİLEN PLAKA HAKKINDA BİLGİLER VEREN FOKSİYON
        }
        private void arac_hakkinda_bilgi_label_Click(object sender, EventArgs e)
        {
            if (arac_hakkinda_bilgi_label.Text == "Araç Hakkında Bilgi[Açık]")//EĞER BİLGİLER AÇIKSA KAPATIR
            {
                arac_hakkinda_bilgi_label.Text = "Araç Hakkında Bilgi[Kapali]";//YENİ AD
                arac_cikar_gb.Height = 100;//YENİ YÜKSEKLİK
                bilgi_label.Visible = false;//BİLGİLERİ GİZLER
                arac_cikar_pb.Location = new Point(279, 130);//YENİ KONUM
                iptalet_pb.Location = new Point(195, 130);//YENİ KONUM
                kapali_alt_menu.Visible = false;//MENÜLERDE GİZLEME GÖSTERME İŞLEMLERİ YAPILIR
                kapali_alt_sagtik.Visible = false;//MENÜLERDE GİZLEME GÖSTERME İŞLEMLERİ YAPILIR
                acik_alt_menu.Visible = true;//MENÜLERDE GİZLEME GÖSTERME İŞLEMLERİ YAPILIR
                acik_alt_sagtik.Visible = true;//MENÜLERDE GİZLEME GÖSTERME İŞLEMLERİ YAPILIR
                this.Height = 240;//PENCERE YÜKSEKLİĞİ YENİLENİR.
            }
            else if (arac_hakkinda_bilgi_label.Text == "Araç Hakkında Bilgi[Kapali]")//EĞER BİLGİLER KAPALI İSE AÇAR
            {
                arac_hakkinda_bilgi_label.Text = "Araç Hakkında Bilgi[Açık]";//VARSAYİLAN YAZI
                arac_cikar_gb.Height = 382;//VARSAYİLAN YÜKSEKLİK
                bilgi_label.Visible = true;//BİLGİLERİ GÖSTERİR
                arac_cikar_pb.Location = new Point(279, 416);//VARSAYİLAN KONUM
                iptalet_pb.Location = new Point(195, 416);//VARSAYİLAN KONUM
                kapali_alt_menu.Visible = true;//MENÜLERDE GİZLEME GÖSTERME İŞLEMLERİ YAPILIR
                kapali_alt_sagtik.Visible = true;//MENÜLERDE GİZLEME GÖSTERME İŞLEMLERİ YAPILIR
                acik_alt_menu.Visible = false;//MENÜLERDE GİZLEME GÖSTERME İŞLEMLERİ YAPILIR
                acik_alt_sagtik.Visible = false;//MENÜLERDE GİZLEME GÖSTERME İŞLEMLERİ YAPILIR
                this.Height = 522;//VARSAYİLAN PENCERE YÜKSEKLİĞİ.
            }

        }

        private void arac_hakkinda_bilgi_label_MouseMove(object sender, MouseEventArgs e)
        {
            arac_hakkinda_bilgi_label.ForeColor = Color.Red;//YAZI RENGİ DEĞİŞTİRİLİR
            arac_hakkinda_bilgi_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi2.png");//EFEKT OLUŞTURMA GÖRSELİ
            arac_hakkinda_bilgi_pb2.Image = Image.FromFile(@"image\yuvarlak_bilgi2.png");//EFEKT OLUŞTURMA GÖRSELİ
        }

        private void arac_hakkinda_bilgi_label_MouseLeave(object sender, EventArgs e)
        {
            arac_hakkinda_bilgi_label.ForeColor = this.ForeColor;//VARSAYILAN REKLER
            arac_hakkinda_bilgi_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");//VARSAYILAN GÖRSEL
            arac_hakkinda_bilgi_pb2.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");//VARSAYILAN GÖRSEL
        }

        private void iptalet_pb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }

        private void iptalet_pb_MouseMove(object sender, MouseEventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\arac_iptal2.png");//GÖRSEL EFEKT OLUŞTURMA
        }

        private void iptalet_pb_MouseLeave(object sender, EventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\arac_iptal1.png");//VARSAYILAN GÖRSEL
        }

        private void arac_cikar_pb_Click(object sender, EventArgs e)
        {
            if (plaka_combo.Items.Count>0)//ARAÇ PLAKASI VAR MI KONTROL
            {
                if (MessageBox.Show("SEÇİLEN PLAKA NO:" + plaka_combo.SelectedItem + " ARAÇLARDAN ÇIKARILSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//PLAKA VARSA PLAKAYI GÖSTERİR VE ÇIKARMA İŞLEMİ YAPILSIN MI DİYE SORAR EVET İSE;
                {
                    veritabanina_arac_cikar();//ARAÇ ÇIKARMA İŞLEMLERİ FOKSİYONU
                }
            }
            else
            {
                MessageBox.Show("ARAÇ BULUNAMADI.", "ARAÇ İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//PLAKA YOKSA BİLGİ VERİRİR.
                bilgi_label.Text = "";//PLAKA BİLGİLERİ KALMASIN DİYE SİLİNİR.
            }
            
        }
        private void veritabanina_arac_cikar()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("update arac_tablosu set arsiv=0 where arac_id=" + arac_id, baglanti);//PLAKA AİT BİLGİLER SİSTEMDEN ÇIKARILIR(ARŞİVLENİR.)
                komut.ExecuteNonQuery();//KOMUTLARI ÇALIŞTIRMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(plaka_combo.SelectedItem + " PLAKA NOLU ARAÇ ÇIKARILMIŞTIR.", "ARAÇ ÇIKARMA", MessageBoxButtons.OK, MessageBoxIcon.Information);//ÇIKARILMA HAKKINDA BİLGİ VERME
                plakalari_getir();//PLAKALARI GETİRİR
                if (plaka_combo.Items.Count > 0)//ELEMEN VAR MI
                {
                    plaka_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
                }
                else
                {
                    bilgi_label.Text = "";//SİLME İŞLEMİ
                }

            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void arac_cikar_pb_MouseMove(object sender, MouseEventArgs e)
        {
            arac_cikar_pb.Image = Image.FromFile(@"image\arac_cikar2.png");//EFEKT GÖRSELİ
        }

        private void arac_cikar_pb_MouseLeave(object sender, EventArgs e)
        {
            arac_cikar_pb.Image = Image.FromFile(@"image\arac_cikar1.png");//VARSAYILAN GÖRSEL
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {
            //YARDIM PENCERESİNİ AÇMA KOMUTLARI
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }

    }
}
