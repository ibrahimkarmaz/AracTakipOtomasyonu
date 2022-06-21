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
    public partial class arac_duzenle : Form
    {
        public arac_duzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        string arac_id = "", marka_bilgi = "", model_bilgi = "";
        private void arac_duzenle_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            markalari_getir();//ARAÇLARIN MARKA VE MODELINI GETİREN FOKSİYON
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            plakalari_getir();//PLAKALARI GETİRİR
            kiralanan_plakalari_sil();//KİRALANAN ARAÇLARI SEÇİM KUTUSUNDAN SİLEN FOKSİYON
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void fotograflari_al_ve_duzenle()
        {
            //VARSAYILAN GÖRSELLER
            eski_plaka_pb.Image = Image.FromFile(@"image\plakano.png");
            plaka_no_pb.Image = Image.FromFile(@"image\plakano.png");
            marka_pb.Image = Image.FromFile(@"image\marka_model.png");
            model_pb.Image = Image.FromFile(@"image\marka_model.png");
            yil_pb.Image = Image.FromFile(@"image\yil.png");
            kategori_pb.Image = Image.FromFile(@"image\kategori.png");
            renk_pb.Image = Image.FromFile(@"image\renk.png");
            km_pb.Image = Image.FromFile(@"image\km.png");
            yakit_turu_pb.Image = Image.FromFile(@"image\yakit_turu.png");
            yakit_doluluk_pb.Image = Image.FromFile(@"image\yakit_doluluk.png");
            vites_turu_pb.Image = Image.FromFile(@"image\vites_turu.png");
            koltuk_sayisi_pb.Image = Image.FromFile(@"image\koltuk_sayisi.png");
            kapi_sayisi_pb.Image = Image.FromFile(@"image\kapi_sayisi.png");
            kira_ucreti_pb.Image = Image.FromFile(@"image\kira_ucreti.png");
            kaza_durumu_pb.Image = Image.FromFile(@"image\kaza_durumu.png");
            aciklama_pb.Image = Image.FromFile(@"image\bilgi_verme.png");

            arac_duzenle_pb.Image = Image.FromFile(@"image\arac_duzenle1.png");
            arac_duzenle_menu.Image = Image.FromFile(@"image\tekrar.png");
            arac_duzenle_sagtik.Image = Image.FromFile(@"image\tekrar.png");
            arac_iptal_et_pb.Image = Image.FromFile(@"image\arac_iptal1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");
            //GÖRSELLERİ SIĞDIRMA
            arac_duzenle_pb.SizeMode = arac_iptal_et_pb.SizeMode = plaka_no_pb.SizeMode = marka_pb.SizeMode = model_pb.SizeMode = yil_pb.SizeMode = kategori_pb.SizeMode = renk_pb.SizeMode = km_pb.SizeMode = yakit_turu_pb.SizeMode = yakit_doluluk_pb.SizeMode = koltuk_sayisi_pb.SizeMode = kapi_sayisi_pb.SizeMode = kira_ucreti_pb.SizeMode = kaza_durumu_pb.SizeMode = aciklama_pb.SizeMode = vites_turu_pb.SizeMode = eski_plaka_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            aciklama_tb.MaxLength = 255;//EN FAZLA GİRİLEN KARAKTER SAYISI
            km_tb.MaxLength = kira_ucreti_tb.MaxLength = plaka_no_tb.MaxLength = 9;//EN FAZLA GİRİLEN KARAKTER SAYISI
            //Katagori
            kategori_combo.Items.Add("Otomobil");
            kategori_combo.Items.Add("Taksi");
            kategori_combo.Items.Add("Minibüs");
            kategori_combo.Items.Add("Otobüs");
            kategori_combo.Items.Add("Kamyonet");
            kategori_combo.Items.Add("Kamyon");
            kategori_combo.Items.Add("Çekici");
            kategori_combo.Items.Add("Arazi Taşıtı");
            kategori_combo.Items.Add("Motosiklet");
            kategori_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 


            //Renkler
            renk_combo.Items.Add("Beyaz");
            renk_combo.Items.Add("Siyah");
            renk_combo.Items.Add("Lacivert");
            renk_combo.Items.Add("Turuncu");
            renk_combo.Items.Add("Kırmızı");
            renk_combo.Items.Add("Yeşil");
            renk_combo.Items.Add("Sarı");
            renk_combo.Items.Add("Gri");
            renk_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            //Yakit Türü
            yakit_turu_combo.Items.Add("Dizel");
            yakit_turu_combo.Items.Add("Benzin");
            yakit_turu_combo.Items.Add("Benzin+Lpg");
            yakit_turu_combo.Items.Add("Lpg");
            yakit_turu_combo.Items.Add("Elektirik");
            yakit_turu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            //Vites Türü
            vites_turu_combo.Items.Add("Düz");
            vites_turu_combo.Items.Add("Otomatik");
            vites_turu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            //Koltuk Sayısı
            for (int i = 0; i < 60; i++)
            {
                koltuk_sayisi_combo.Items.Add((i + 1).ToString());
            }
            koltuk_sayisi_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            //Kapi Sayısı
            for (int a = 0; a < 10; a++)
            {
                kapi_sayisi_combo.Items.Add((a + 1).ToString());
            }
            kapi_sayisi_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONUCU OLUŞAN HATALARI DÜZENLEME
            arac_ekle_gb.ForeColor = this.ForeColor;
        }
        private void plakalari_getir()
        {
            try
            {
                eski_plaka_combo.Items.Clear();//PLAKALARI TEKRAR EKLERKEN ÇAKIŞMASINLAR DİYE SİLİNİYOR
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(plaka) AS Plaka from arac_tablosu where arsiv=1", baglanti);//PLAKALARI ÇEKME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    eski_plaka_combo.Items.Add(oku["Plaka"]);//PLAKALARI SEÇİM KUTUSUNA EKLEME
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
                komut = new SqlCommand("select plaka as Plaka from kiralama_tablosu inner join arac_tablosu on kiralama_tablosu.arac_id =arac_tablosu.arac_id where kiralama_tablosu.arsiv=1", baglanti);//KİRALANAN ARAÇLARI GETİRİR
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUNUYOR
                {
                    eski_plaka_combo.Items.Remove(oku["Plaka"]);//EĞER ARAÇ VAR İSE SİLİNİR
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                if (eski_plaka_combo.Items.Count > 0)//ELEMAN VAR MI DİYE KONTROL EDİLİR
                {
                    eski_plaka_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
                }
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void secilen_plaka()
        {//SEÇİLEN PLAKA HAKKINDA BİLGİ
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from arac_tablosu where plaka='" + eski_plaka_combo.SelectedItem + "'", baglanti);//PLAKAYA BAĞLI OLARAK BİLGİ ÇEKİLİR
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    arac_id = oku["arac_id"].ToString();//DÜZENLEME İŞLEMİNDE KULLANILIR
                    //ÇEKİLEN BİLGİLER SEÇİM KUTULARI ,YAZI KUTULARINA VE RADİO BUTONLARA AKTARILIR.
                    plaka_no_tb.Text = eski_plaka_combo.SelectedItem.ToString();
                    marka_bilgi = oku["marka"].ToString();
                    model_bilgi = oku["model"].ToString();
                    kategori_combo.SelectedIndex = kategori_combo.Items.IndexOf(oku["kategori"].ToString());
                    renk_combo.SelectedIndex = renk_combo.Items.IndexOf(oku["renk"].ToString());
                    km_tb.Text = oku["km"].ToString();

                    yakit_turu_combo.SelectedIndex = yakit_turu_combo.Items.IndexOf(oku["yakit_turu"].ToString());
                    yakit_doluluk_nud.Value = Convert.ToUInt32(oku["yakit_doluluk_yuzdesi"]);
                    vites_turu_combo.SelectedIndex = vites_turu_combo.Items.IndexOf(oku["vites_turu"].ToString());
                    koltuk_sayisi_combo.SelectedIndex = koltuk_sayisi_combo.Items.IndexOf(oku["koltuk_sayisi"].ToString());
                    kapi_sayisi_combo.SelectedIndex = kapi_sayisi_combo.Items.IndexOf(oku["kapi_sayisi"].ToString());
                    kira_ucreti_tb.Text = oku["kira_ucreti"].ToString();
                    if (Convert.ToByte(oku["hasar"]) == 0)
                    {
                        kaza_durumu_yok_rb.Checked = true;
                    }
                    else if (Convert.ToByte(oku["hasar"]) == 1)
                    {
                        kaza_durumu_var_rb.Checked = true;
                    }
                    aciklama_tb.Text = oku["aciklama"].ToString();
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                marka_combo.SelectedIndex = marka_combo.Items.IndexOf(marka_bilgi);//MARKA SEÇME
                model_combo.SelectedIndex = model_combo.Items.IndexOf(model_bilgi);//MODEL SEÇME
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void markalari_getir()//VERİTABANINDA KAYITLI MARKALARI GETİREN FOKSİYON
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select distinct marka AS Marka from marka_model_tablosu", baglanti);//BENZERSİZ ŞEKİLDE MARKALRI GETİREN KOMUT 
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA İŞLEMİ
                {
                    marka_combo.Items.Add(oku["Marka"]);//SEÇİM KUTUSUNA EKLENIYOR
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                marka_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void modelleri_getir()//MARKA SEÇİLDİĞİNDE MODEL GELİR
        {
            model_combo.Items.Clear();//HER MARKA DEĞİŞTİĞİNDE MODELDE DEĞİŞECEĞİ İÇİN SİLİNİR.
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select distinct(model) AS Model from marka_model_tablosu where marka='" + marka_combo.SelectedItem + "'", baglanti);//MARKANIN MODELLERINI GETİREN KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    model_combo.Items.Add(oku["Model"]);//MODELLERI EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                model_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void yili_getir()//SEÇİM MARKA MODELE GÖRE ÜRETİLME YILI GELİR.
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(yil) AS marka_model_yili from marka_model_tablosu where marka='" + marka_combo.SelectedItem + "' and model='" + model_combo.SelectedItem + "'", baglanti);//MARKA MODELE GÖRE ÜRETİLME YILINI GETİREN KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    yil_tb.Text = oku["marka_model_yili"].ToString();//YILI METİN KUTUSUNA EKLER
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void marka_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            modelleri_getir();//MARKA SEÇİLDİĞİNDE ÇALIŞIR MODELLERI GETİREN FOKSİYON
        }

        private void model_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            yili_getir();//MODEL SEÇİLDİĞİNDE ÇALIŞIR YILI GETİREN FOKSİYON
        }

        private void aciklama_tb_TextChanged(object sender, EventArgs e)
        {
            //AÇIKLAMA YAZILDIĞINDA GÖRÜNTÜ GRUP KUTUSUNDAN TAŞMASINI ENGELLER
            if (aciklama_tb.TextLength >= 10 && aciklama_tb.TextLength <= 99)
            {
                karkater_sayisi_kalan_label.Location = new Point(683, 259);
            }
            else if (aciklama_tb.TextLength >= 100)
            {
                karkater_sayisi_kalan_label.Location = new Point(674, 259);
            }
            else
            {
                karkater_sayisi_kalan_label.Location = new Point(688, 259);
            }
            karkater_sayisi_kalan_label.Text = aciklama_tb.TextLength.ToString() + "/255";//KAÇ KARAKTER YAZILDI BİLGİSİ
        }
        private void yakit_doluluk_nud_ValueChanged(object sender, EventArgs e)
        {//NUMARA DEĞİŞTİKÇE İŞLEM YAPAR
            try
            {
                yakit_doluluk_progress.Value = Convert.ToInt32(yakit_doluluk_nud.Value);//DEĞERİ DOLUM KUTUSUNA EKLER
            }
            catch (Exception)
            {
                Console.WriteLine("HATA OLUŞTU");
            }
        }
        private void arac_iptal_et_pb_MouseMove(object sender, MouseEventArgs e)
        {
            arac_iptal_et_pb.Image = Image.FromFile(@"image\arac_iptal2.png");//GÖRSEL EFEKT
        }

        private void arac_iptal_et_pb_MouseLeave(object sender, EventArgs e)
        {
            arac_iptal_et_pb.Image = Image.FromFile(@"image\arac_iptal1.png");//VARSAYILAN GÖRSEL
        }

        private void arac_iptal_et_pb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }
        bool arac_plakasi_varmi = false;//PLAKA KONTROL EDİLİR
        private void arac_plakasi_kontrol()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from arac_tablosu where plaka='" + plaka_no_tb.Text + "'", baglanti);//ARAÇ PLAKASI VAR MI DİYE KONTROL EDİLİR
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    arac_plakasi_varmi = true;//VARSA TRUE
                }
                else
                {
                    arac_plakasi_varmi = false;//YOKSA FALSE
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void arac_duzenle_pb_Click(object sender, EventArgs e)
        {
            if (eski_plaka_combo.Items.Count>0)//ARAÇ VARMI
            {
                if (plaka_no_tb.Text != "")//PLAKA KUTUSU BOŞ OLMAZ
                {
                    if (plaka_no_tb.Text.Length >= 7)//PLAKA KUTUSU EN AZ 7 KARKATERLI OLMALI
                    {
                        arac_plakasi_kontrol();//SİSTEMDE AYNI PLAKADAN VAR MI
                        if (arac_plakasi_varmi != true || eski_plaka_combo.Text==plaka_no_tb.Text)//ARAÇ PLAKASI YOKSA DEVAM ET
                        {
                            if (km_tb.Text != "")//KM KUTUSU BOŞ OLAMAZ
                            {
                                if (kira_ucreti_tb.Text != "")//KİRA ÜCRETİ BOŞ OLAMAZ
                                {
                                    veritabanina_arac_duzenle();
                                }
                                else
                                {
                                    MessageBox.Show("KİRA ÜCRETİNİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//EKSİKLER HAKKINDA MESAJ PENCERESI İLE BİLGİ VERME//EKSİKLER HAKKINDA MESAJ PENCERESI İLE BİLGİ VERME
                                }
                            }
                            else
                            {
                                MessageBox.Show("KİLOMETRE(KM) BİLGİLERİNİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//EKSİKLER HAKKINDA MESAJ PENCERESI İLE BİLGİ VERME
                            }
                        }
                        else
                        {
                            MessageBox.Show("PLAKA NUMARASI BULUNMAKTADIR.\nFARKLI PLAKA NUMARASI GİRİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//EKSİKLER HAKKINDA MESAJ PENCERESI İLE BİLGİ VERME
                        }

                    }
                    else
                    {
                        MessageBox.Show("PLAKA NUMARANIZ EKSİKTİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//EKSİKLER HAKKINDA MESAJ PENCERESI İLE BİLGİ VERME
                    }
                }
                else
                {
                    MessageBox.Show("PLAKA NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//EKSİKLER HAKKINDA MESAJ PENCERESI İLE BİLGİ VERME
                }
            }
            else
            {
                MessageBox.Show("ARAÇ BULUNAMADI.", "ARAÇ İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//EKSİKLER HAKKINDA MESAJ PENCERESI İLE BİLGİ VERME
            }
            
        }
        private void veritabanina_arac_duzenle()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                if (kaza_durumu_var_rb.Checked == true)//KAZA VARMI 
                {
                    komut = new SqlCommand("update arac_tablosu set plaka='" + plaka_no_tb.Text + "',marka='" + marka_combo.SelectedItem + "',model='" + model_combo.SelectedItem + "',yil='" + yil_tb.Text + "',renk='" + renk_combo.SelectedItem + "',kategori='" + kategori_combo.SelectedItem + "',km=" + km_tb.Text + ",yakit_turu='" + yakit_turu_combo.SelectedItem + "',yakit_doluluk_yuzdesi=" + yakit_doluluk_progress.Value + ",vites_turu='" + vites_turu_combo.SelectedItem + "',koltuk_sayisi=" + koltuk_sayisi_combo.SelectedItem + ",kapi_sayisi=" + kapi_sayisi_combo.SelectedItem + ",kira_ucreti=" + kira_ucreti_tb.Text + ",hasar=1,aciklama='" + aciklama_tb.Text + "',arsiv=1 where arac_id=" + arac_id, baglanti);//EKLENECEK BİLGİLERİN KOMUTU
                }
                else if (kaza_durumu_yok_rb.Checked == true)//KAZA VARMI 
                {
                    komut = new SqlCommand("update arac_tablosu set plaka='" + plaka_no_tb.Text + "',marka='" + marka_combo.SelectedItem + "',model='" + model_combo.SelectedItem + "',yil='" + yil_tb.Text + "',renk='" + renk_combo.SelectedItem + "',kategori='" + kategori_combo.SelectedItem + "',km=" + km_tb.Text + ",yakit_turu='" + yakit_turu_combo.SelectedItem + "',yakit_doluluk_yuzdesi=" + yakit_doluluk_progress.Value + ",vites_turu='" + vites_turu_combo.SelectedItem + "',koltuk_sayisi=" + koltuk_sayisi_combo.SelectedItem + ",kapi_sayisi=" + kapi_sayisi_combo.SelectedItem + ",kira_ucreti=" + kira_ucreti_tb.Text + ",hasar=0,aciklama='" + aciklama_tb.Text + "',arsiv=1 where arac_id=" + arac_id, baglanti);//EKLENECEK BİLGİLERİN KOMUTU
                }
                komut.ExecuteNonQuery();//KOMUTLARI ÇALIŞTIRIR
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(plaka_no_tb.Text + " PLAKA NOLU MARKASI:" + marka_combo.SelectedItem + " MODELI:" + model_combo.SelectedItem + "\nARAÇ DÜZENLENMİŞTİR.", "ARAÇ DÜZENLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                plaka_islemlerini_guncelle();
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void plaka_islemlerini_guncelle()
        {
            plakalari_getir();//PLAKALARI GETİRİR
            kiralanan_plakalari_sil();//KİRALANAN ARAÇLARI SEÇİM KUTUSUNDAN SİLEN FOKSİYON
        }
        private void arac_duzenle_pb_MouseMove(object sender, MouseEventArgs e)
        {
            arac_duzenle_pb.Image = Image.FromFile(@"image\arac_duzenle2.png");//GÖRSEL EFEKT
        }

        private void arac_duzenle_pb_MouseLeave(object sender, EventArgs e)
        {
            arac_duzenle_pb.Image = Image.FromFile(@"image\arac_duzenle1.png");//VARSAYILAN GÖRSEL
        }
        private void km_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {//KM KARAKTER GİRDİĞİNDE ÇALIŞIR
                if (km_tb.Text != "")
                {
                    km_tb.Text = (Convert.ToUInt64(km_tb.Text) * 1).ToString();//1 İLE ÇARPIM HATA VERİRSE KUTUYU SİLİYOR VERMEZSE DEVAM EDİYOR
                }
            }
            catch (Exception)
            {
                MessageBox.Show("SADECE SAYISAL VERİ GİRİŞİ YAPINIZ...", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA NEDENINI MESAJ OLARAK VERİR
                km_tb.Text = "";//KUTUYU SIFIRLAR
            }
        }

        private void kira_ucreti_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {//KİRA ÜCRETİNE KARKATER GİRİRDİĞİN ÇALIŞIR
                if (kira_ucreti_tb.Text != "")
                {
                    kira_ucreti_tb.Text = (Convert.ToUInt64(kira_ucreti_tb.Text) * 1).ToString();//1 İLE ÇARPIM HATA VERİRSE KUTUYU SİLİYOR VERMEZSE DEVAM EDİYOR
                }
            }
            catch (Exception)
            {
                MessageBox.Show("SADECE SAYISAL VERİ GİRİŞİ YAPINIZ...", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA NEDENINI MESAJ OLARAK VERİR
                kira_ucreti_tb.Text = "";//SIFIRLAR
            }
        }

        private void eski_plaka_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eski_plaka_combo.Items.Count > 0)//PLAKA YOKSA PLAKA SEÇME
            {
                secilen_plaka();//PLAKA BİLGİLERİNİ GETİRME
            }
        }

        private void eski_plaka_label_Click(object sender, EventArgs e)
        {

        }

        private void eski_plaka_pb_Click(object sender, EventArgs e)
        {

        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESINI AÇAR
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
