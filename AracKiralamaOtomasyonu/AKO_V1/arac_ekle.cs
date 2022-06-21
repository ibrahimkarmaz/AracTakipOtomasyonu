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
    public partial class arac_ekle : Form
    {
        public arac_ekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        private void arac_ekle_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            markalari_getir();
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
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
            arac_ekle_pb.Image = Image.FromFile(@"image\arac_ekle1.png");
            arac_ekle_menu.Image = Image.FromFile(@"image\ekle.png");
            arac_ekle_sagtik.Image = Image.FromFile(@"image\ekle.png");
            temzile_pb.Image = Image.FromFile(@"image\arac_temizle1.png");
            temizle_menu.Image = Image.FromFile(@"image\temizle.png");
            temizle_sagtik.Image = Image.FromFile(@"image\temizle.png");
            arac_iptal_et_pb.Image = Image.FromFile(@"image\arac_iptal1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");
            //GÖRSELLERI KUTUYA SIĞDIRMA
            arac_ekle_pb.SizeMode = arac_iptal_et_pb.SizeMode = plaka_no_pb.SizeMode = marka_pb.SizeMode = model_pb.SizeMode = yil_pb.SizeMode = kategori_pb.SizeMode = renk_pb.SizeMode = km_pb.SizeMode = yakit_turu_pb.SizeMode = yakit_doluluk_pb.SizeMode = koltuk_sayisi_pb.SizeMode = kapi_sayisi_pb.SizeMode = kira_ucreti_pb.SizeMode = kaza_durumu_pb.SizeMode = aciklama_pb.SizeMode = vites_turu_pb.SizeMode =temzile_pb.SizeMode= PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            aciklama_tb.MaxLength = 255;//EN FAZLA GİRİLEBİLEN KARAKTER SAYISI
            km_tb.MaxLength = kira_ucreti_tb.MaxLength = plaka_no_tb.MaxLength = 9;//EN FAZLA GİRİLEBİLEN KARAKTER SAYISI
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
        {//RENKLENDIRME SONRASI SORUNLARI DÜZENLEME
            arac_ekle_gb.ForeColor = this.ForeColor;
        }
        private void markalari_getir()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select distinct marka AS Marka from marka_model_tablosu", baglanti);//MARKALARI GETİREN KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    marka_combo.Items.Add(oku["Marka"]);//MARKALARI SEÇİM KUTUSUNA EKLEME
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

        private void modelleri_getir()
        {
            model_combo.Items.Clear();//MODELLERI SİLME YENİ MODELLER İÇİN
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select distinct(model) AS Model from marka_model_tablosu where marka='" + marka_combo.SelectedItem + "'", baglanti);//MARKAYA GÖRE MODEL GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    model_combo.Items.Add(oku["Model"]);//MODELLERI SEÇİM KUTUSUNA EKLEME
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

        private void yili_getir()
        {//MARKA VE MODELE GÖRE ÜRETİLME YILINI GETİRME FOKSİYONU
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(yil) AS marka_model_yili from marka_model_tablosu where marka='" + marka_combo.SelectedItem + "' and model='" + model_combo.SelectedItem + "'", baglanti);//MARKA VE MODELE GÖRE ÜRETİLME YILINI GETİR KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    yil_tb.Text = oku["marka_model_yili"].ToString();//GETİRİLEN BİLGİ YIL KUTUSUNA EKLEME
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
            modelleri_getir();//MARKA SEÇİLDİĞİNDE MARKAYA AIT MODELLERİ ÇEKER
        }

        private void model_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            yili_getir();//MODEL SEÇİLDİĞİNDE MARKA MODELE GÖRE YILI ÇEKER
        }

        private void aciklama_tb_TextChanged(object sender, EventArgs e)
        {//AÇIKLAMA SAYISINI GÖSTERİRKEN OLUŞAN GÖRSEL HATAYI DÜZENLEME
            if (aciklama_tb.TextLength >= 10 && aciklama_tb.TextLength <= 99)
            {
                karkater_sayisi_kalan_label.Location = new Point(683, 229);
            }
            else if (aciklama_tb.TextLength >= 100)
            {
                karkater_sayisi_kalan_label.Location = new Point(674, 229);
            }
            else
            {
                karkater_sayisi_kalan_label.Location = new Point(688, 229);
            }
            karkater_sayisi_kalan_label.Text = aciklama_tb.TextLength.ToString() + "/255";
        }

        private void yakit_doluluk_nud_ValueChanged(object sender, EventArgs e)
        {//DEĞER DEĞİŞTİĞİNDE ÇALIŞIR
            try
            {
                yakit_doluluk_progress.Value = Convert.ToInt32(yakit_doluluk_nud.Value);//GİRİLEN DEĞERİ DOLULUK KUTUSUNA AKTARMA
            }
            catch (Exception HATA)
            {
                yakit_doluluk_progress.Value = 0;
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void arac_ekle_pb_MouseMove(object sender, MouseEventArgs e)
        {
            arac_ekle_pb.Image = Image.FromFile(@"image\arac_ekle2.png");//GÖRSEL EFEKT
        }

        private void arac_ekle_pb_MouseLeave(object sender, EventArgs e)
        {
            arac_ekle_pb.Image = Image.FromFile(@"image\arac_ekle1.png");//VARSAYILAN GÖRSEL
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
        bool arac_plakasi_varmi = false;
        private void arac_plakasi_kontrol()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from arac_tablosu where plaka='" + plaka_no_tb.Text + "'", baglanti);//ARAÇ PLAKASI VAR MI DİYE KONTROL EDEN KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    arac_plakasi_varmi = true;//PLAKA VAR
                }
                else
                {
                    arac_plakasi_varmi = false;//PLAKA YOK
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void arac_ekle_pb_Click(object sender, EventArgs e)
        {
            if (plaka_no_tb.Text != "")//PLAKA BOŞ OLMAZ
            {
                if (plaka_no_tb.Text.Length >= 7)//PLAKA EN AZ 7 KARAKTERLI OLMALI
                {
                    arac_plakasi_kontrol();//PLAKA VARMI DİYE KONTROL EDEN FOKSİYON
                    if (arac_plakasi_varmi!=true)//EĞER YOKSA DEVAM EDER
                    {
                        if (km_tb.Text != "")//KUTU BOŞ GEÇİLEMEZ
                        {
                            if (kira_ucreti_tb.Text != "")//KUTU BOŞ GEÇİLEMEZ
                            {
                                veritabanina_arac_ekle();
                            }
                            else
                            {
                                MessageBox.Show("KİRA ÜCRETİNİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//EKSİK BİLGİLERİ MESAJ İLE BİLGİ VERİR
                            }
                        }
                        else
                        {
                            MessageBox.Show("KİLOMETRE(KM) BİLGİLERİNİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//EKSİK BİLGİLERİ MESAJ İLE BİLGİ VERİR
                        }
                    }
                    else
                    {
                        MessageBox.Show("PLAKA NUMARASI BULUNMAKTADIR.\nARAÇ EĞER SİSTEMDE DEĞİLSE ARŞİVDEN ÇIKARABİLİRSİNİZ.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//EKSİK BİLGİLERİ MESAJ İLE BİLGİ VERİR
                    }
                    
                }
                else
                {
                    MessageBox.Show("PLAKA NUMARANIZ EKSİKTİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//EKSİK BİLGİLERİ MESAJ İLE BİLGİ VERİR
                }
            }
            else
            {
                MessageBox.Show("PLAKA NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//EKSİK BİLGİLERİ MESAJ İLE BİLGİ VERİR
            }
        }
        private void veritabanina_arac_ekle()//YENİ ARAÇ EKLENIR
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                if (kaza_durumu_var_rb.Checked == true)//KAZA VARMI
                {
                    komut = new SqlCommand("insert into arac_tablosu values('" + plaka_no_tb.Text + "','" + marka_combo.SelectedItem + "','" + model_combo.SelectedItem + "','" + yil_tb.Text + "','" + renk_combo.SelectedItem + "','" + kategori_combo.SelectedItem + "'," + km_tb.Text + ",'" + yakit_turu_combo.SelectedItem + "'," + yakit_doluluk_progress.Value + ",'" + vites_turu_combo.SelectedItem + "'," + koltuk_sayisi_combo.SelectedItem + "," + kapi_sayisi_combo.SelectedItem + "," + kira_ucreti_tb.Text + ",1,'" + aciklama_tb.Text + "',1)", baglanti);//EKLEME KOMUTU
                }
                else if (kaza_durumu_yok_rb.Checked == true)//KAZA VARMI
                {
                    komut = new SqlCommand("insert into arac_tablosu values('" + plaka_no_tb.Text + "','" + marka_combo.SelectedItem + "','" + model_combo.SelectedItem + "','" + yil_tb.Text + "','" + renk_combo.SelectedItem + "','" + kategori_combo.SelectedItem + "'," + km_tb.Text + ",'" + yakit_turu_combo.SelectedItem + "'," + yakit_doluluk_progress.Value + ",'" + vites_turu_combo.SelectedItem + "'," + koltuk_sayisi_combo.SelectedItem + "," + kapi_sayisi_combo.SelectedItem + "," + kira_ucreti_tb.Text + ",0,'" + aciklama_tb.Text + "',1)", baglanti);//EKLEME KOMUTU
                }

                komut.ExecuteNonQuery();//KOMUTLARI ÇALIŞTIRMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(plaka_no_tb.Text + " PLAKA NOLU MARKASI:" + marka_combo.SelectedItem + " MODELI:" + model_combo.SelectedItem + "\nARAÇ EKLENMİŞTİR.", "ARAÇ EKLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);//EKLEME HAKKINDA BİLGİ
                temizle();//TEKRAR GİRİŞ YAPILABİLMESİ İÇİN VARSAYILANA DÖNÜNÜR(KUTULA SİLİNİR SEÇİM KUTUSU DÜZENLENIR)
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void temizle()//KUTULAR NUMARA DEĞERLERI SEÇİM KUTULARI BAŞLANGICA DÖNER
        {
            plaka_no_tb.Text = km_tb.Text = kira_ucreti_tb.Text = aciklama_tb.Text = "";//KUTULARI SİLME
            yakit_doluluk_nud.Value = 0;//NUMARAYI SIFIRLAMA
            kaza_durumu_yok_rb.Checked = true;//KAZA DURUMUNU VARSAYILAN YAPMA
            marka_combo.SelectedIndex =model_combo.SelectedIndex= kategori_combo.SelectedIndex = koltuk_sayisi_combo.SelectedIndex = kapi_sayisi_combo.SelectedIndex =yakit_turu_combo.SelectedIndex=vites_turu_combo.SelectedIndex= renk_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
        }

        private void km_tb_TextChanged(object sender, EventArgs e)
        {//KM KARAKTER GİRİRDİĞİNDE ÇALIŞIR
            try
            {
                if (km_tb.Text != "")//KM BOŞ OLAMAZ
                {
                    km_tb.Text = (Convert.ToUInt64(km_tb.Text) * 1).ToString();//ÇARPMA UYGULANIR ÇARPMA YAPILIR VE HATA OLMAZSA DEVAM EDER. ALIRSA HATA BÖLÜMÜNE GİRER
                }
            }
            catch (Exception)
            {
                MessageBox.Show("SADECE SAYISAL VERİ GİRİŞİ YAPINIZ...", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ
                km_tb.Text = "";//HATA ALINDIĞI İÇİN KUTU SIFIRLANIR
            }
        }

        private void kira_ucreti_tb_TextChanged(object sender, EventArgs e)
        {//KUTUYA KARAKTER GİRİŞİ YAPILDIĞINDA ÇALIŞIR
            try
            {
                if (kira_ucreti_tb.Text != "")//KUTU BOŞ DEĞİLSE
                {
                    kira_ucreti_tb.Text = (Convert.ToUInt64(kira_ucreti_tb.Text) * 1).ToString();//ÇARPMA İŞLEMİ YAPILIR HATA VERMEZDE DEVAM EDER EDERSE HATA BÖLÜMÜNE GİRER
                }
            }
            catch (Exception)
            {
                MessageBox.Show("SADECE SAYISAL VERİ GİRİŞİ YAPINIZ...", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ VERDI
                kira_ucreti_tb.Text = "";//KUTUYU SİLME
            }
        }

        private void temzile_pb_Click(object sender, EventArgs e)
        {
            temizle();//İLK AÇILISI DÖNDÜRME
        }

        private void temzile_pb_MouseMove(object sender, MouseEventArgs e)
        {
            temzile_pb.Image = Image.FromFile(@"image\arac_temizle2.png");//GÖRSEL EFEKT
        }

        private void temzile_pb_MouseLeave(object sender, EventArgs e)
        {
            temzile_pb.Image = Image.FromFile(@"image\arac_temizle1.png");//VARSAYILAN GÖRSEL
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESI AÇMA
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
