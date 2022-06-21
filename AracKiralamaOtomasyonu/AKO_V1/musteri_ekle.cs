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
    public partial class musteri_ekle : Form
    {
        public musteri_ekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        private void musteri_ekle_Load(object sender, EventArgs e)
        {
            mail_uzantisi_cek();//MAİL UZANTILARI ÇEKME FOKSİYONU
            illeri_cek();//İLLERİ ÇEKME FOKSİYONU
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
            tc_pb.Image = Image.FromFile(@"image\kullanici.png");
            ad_pb.Image = Image.FromFile(@"image\isim.png");
            soyad_pb.Image = Image.FromFile(@"image\isim.png");
            cinsiyet_pb.Image = Image.FromFile(@"image\cinsiyet.png");
            il_pb.Image = Image.FromFile(@"image\sehir.png");
            ilce_pb.Image = Image.FromFile(@"image\sehir.png");
            cep1_pb.Image = Image.FromFile(@"image\ceptelefonu.png");
            cep2_pb.Image = Image.FromFile(@"image\ceptelefonu.png");
            mail_pb.Image = Image.FromFile(@"image\mail.png");
            adres_pb.Image = Image.FromFile(@"image\evadresi.png");
            ehliyet_no_pb.Image = Image.FromFile(@"image\ehliyet.png");
            ehliyet_tarihi_pb.Image = Image.FromFile(@"image\ehliyet.png");
            ehliyet_turu_pb.Image = Image.FromFile(@"image\ehliyet.png");
            aciklama_pb.Image = Image.FromFile(@"image\bilgi_verme.png");

            musteri_ekle_pb.Image = Image.FromFile(@"image\musteri_ekle1.png");
            musteri_ekle_menu.Image = Image.FromFile(@"image\ekle.png");
            musteri_ekle_sagtik.Image = Image.FromFile(@"image\ekle.png");
            temizle_pb.Image = Image.FromFile(@"image\musteri_temizle1.png");
            temizle_menu.Image = Image.FromFile(@"image\temizle.png");
            temizle_sagtik.Image = Image.FromFile(@"image\temizle.png");
            musteri_iptal_et_pb.Image = Image.FromFile(@"image\musteri_iptal1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");

            tc_pb.SizeMode = ad_pb.SizeMode = soyad_pb.SizeMode = cinsiyet_pb.SizeMode = il_pb.SizeMode = ilce_pb.SizeMode = cep1_pb.SizeMode = cep2_pb.SizeMode = mail_pb.SizeMode = adres_pb.SizeMode = ehliyet_no_pb.SizeMode = ehliyet_tarihi_pb.SizeMode = ehliyet_turu_pb.SizeMode = aciklama_pb.SizeMode = musteri_iptal_et_pb.SizeMode = musteri_ekle_pb.SizeMode = temizle_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            ehliyet_no_tb.MaxLength = 6;//EN FAZLA GİRİLEBİLECEK KARAKTER
            ad_tb.MaxLength = soyad_tb.MaxLength = 20;//EN FAZLA GİRİLEBİLECEK KARAKTER
            mail_tb.MaxLength = 50;//EN FAZLA GİRİLEBİLECEK KARAKTER
            adres_tb.MaxLength = 150;//EN FAZLA GİRİLEBİLECEK KARAKTER
            //EHLİYET TÜRLERİ
            ehliyet_turu_combo.Items.Add("M");
            ehliyet_turu_combo.Items.Add("A1");
            ehliyet_turu_combo.Items.Add("A2");
            ehliyet_turu_combo.Items.Add("A");
            ehliyet_turu_combo.Items.Add("B1");
            ehliyet_turu_combo.Items.Add("B");
            ehliyet_turu_combo.Items.Add("BE");
            ehliyet_turu_combo.Items.Add("C1");
            ehliyet_turu_combo.Items.Add("C1E");
            ehliyet_turu_combo.Items.Add("C");
            ehliyet_turu_combo.Items.Add("CE");
            ehliyet_turu_combo.Items.Add("D1");
            ehliyet_turu_combo.Items.Add("D1E");
            ehliyet_turu_combo.Items.Add("D");
            ehliyet_turu_combo.Items.Add("DE");
            ehliyet_turu_combo.Items.Add("F");
            ehliyet_turu_combo.Items.Add("G");
            ehliyet_turu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            ehliyet_tarihi_dt.MaxDate = DateTime.Today;//EHLİYET TARIHI EN FAZLA BUGÜN OLABİLİR
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI SORUNLARI DÜZENLEME
            musteri_bilgileri_gb.ForeColor = ehliyet_no_gb.ForeColor = this.ForeColor;
        }
        private void mail_uzantisi_cek()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(uzanti_adi) AS uzanti from mail_uzantisi", baglanti);//MAİL UZANTILARI GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    mail_uzantisi_combo.Items.Add(oku["uzanti"]);//EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                mail_uzantisi_combo.SelectedIndex = 1;//SEÇME
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }

        }
        private void illeri_cek()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(sehir) AS sehir from iller", baglanti);//İLLERİ ÇEKME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    il_combo.Items.Add(oku["sehir"]);//ŞEHİRLERİ SEÇİM KUTUSUNA EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                il_combo.SelectedIndex = 33;//İSTANBULU SEÇME
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }


        private void il_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilce_combo.Items.Clear();//İLÇELERİ TEMİZLEME(TEKRAR İLÇE GELECEK FARKLI)
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(ilce) as ilce from ilceler where sehir='" + (il_combo.SelectedIndex + 1).ToString() + "'", baglanti);//İLE GÖRE İLÇE GELECEK
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    ilce_combo.Items.Add(oku["ilce"]);//EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                ilce_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void musteri_iptal_et_pb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }

        private void musteri_iptal_et_pb_MouseMove(object sender, MouseEventArgs e)
        {
            musteri_iptal_et_pb.Image = Image.FromFile(@"image\musteri_iptal2.png");//GÖRSEL EFEKT
        }

        private void musteri_iptal_et_pb_MouseLeave(object sender, EventArgs e)
        {
            musteri_iptal_et_pb.Image = Image.FromFile(@"image\musteri_iptal1.png");//VARSAYILAN GÖRSLE
        }
        bool ehliyet_no_varmi = false;//EHLİYET KONTOLU (AYNI EKLİYETTEN BİRDEN FAZLA MÜŞTERİDE OLAMAZ)
        private void ehliyet_no_kontrol()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from musteri_tablosu where ehliyet_no='" + ehliyet_no_tb.Text + "'", baglanti);//EHLİYET NUMARASI VAR MI DİYE KONTROL ET
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    ehliyet_no_varmi = true;//VAR
                }
                else
                {
                    ehliyet_no_varmi = false;//YOK
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void musteri_ekle_pb_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tc_masketb.Text) == false)//TC VARMI
            {
                if (tc_masketb.Text.Count() == 11)//TC ESKİK MI
                {
                    if (ad_tb.Text != "")//AD VAR MI
                    {
                        if (soyad_tb.Text != "")//SOYAD VARMI
                        {
                            if (cep1_masketb.Text != "(   )    -")//CEP TELEFONU VAR MI
                            {
                                if (cep1_masketb.Text.Count() == 14)//CEP TELEFONU EKSİL Mİ
                                {
                                    if (cep2_masketb.Text != "(   )    -")//CEP TELEFONU VAR MI
                                    {
                                        if (cep2_masketb.Text.Count() == 14)//CEP TELEFONU EKSİL Mİ
                                        {
                                            if (mail_tb.Text != "")//E -POSTA VARMI
                                            {
                                                if (adres_tb.Text != "")//ADRES VARMI
                                                {
                                                    if (ehliyet_no_tb.Text != "")//EHLİYET VARMI
                                                    {
                                                        if (ehliyet_no_tb.Text.Count() == 6)//EHLİYET EKSİKMİ
                                                        {
                                                            ehliyet_no_kontrol();//EHLİYETİ BAŞKASI KULLANIYORMU
                                                            if (ehliyet_no_varmi != true)//KULLANMIYORSA
                                                            {
                                                                veritabanina_musteri_ekle();//EKLEME İŞLEMLERI
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("EHLİYET NUMARASI BULUNMAKTADIR.\nFARKLI EHLİYET NUMARASI GİRİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("EHLİYET NO BİLGİNİZ EKSİKTİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("EHLİYET NO BİLGİNİZİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("ADRES BİLGİLERİNİZİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("E-POSTA ADRES BİLGİLERİNİZİ DOLDURUNUZ VE SEÇİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("CEP TELEFONU(2) NUMARANIZ EKSİKTİR", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("CEP TELEFONU(2) NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("CEP TELEFONU(1) NUMARANIZ EKSİKTİR", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                                }
                            }
                            else
                            {
                                MessageBox.Show("CEP TELEFONU(1) NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                            }
                        }
                        else
                        {
                            MessageBox.Show("SOYADINIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                        }
                    }
                    else
                    {
                        MessageBox.Show("ADINIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                    }
                }
                else
                {
                    MessageBox.Show("TC KİMLİK NUMARANIZ EKSİKTİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
                }
            }
            else
            {
                MessageBox.Show("TC KİMLİK NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//MESAJ İLE UYARI VERİLİR
            }
        }
        private void veritabanina_musteri_ekle()
        {//MÜŞTERİ EKLEME FOKSİYONU
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                if (erkek_cb.Checked == true)//ERKEK İSE
                {
                    komut = new SqlCommand("insert into musteri_tablosu values('" + tc_masketb.Text + "','" + ad_tb.Text + "','" + soyad_tb.Text + "',1,'" + il_combo.Text + "','" + ilce_combo.Text + "','" + cep1_masketb.Text + "','" + cep2_masketb.Text + "','" + (mail_tb.Text + "@" + mail_uzantisi_combo.Text) + "','" + adres_tb.Text + "','" + ehliyet_no_tb.Text + "','" + ehliyet_turu_combo.Text + "','" + ehliyet_tarihi_dt.Text + "','" + aciklama_tb.Text + "',1)", baglanti);//EKLEME KOMUTLARI
                }
                else if (kadin_cb.Checked == true)//KADIN İSE
                {
                    komut = new SqlCommand("insert into musteri_tablosu values('" + tc_masketb.Text + "','" + ad_tb.Text + "','" + soyad_tb.Text + "',0,'" + il_combo.Text + "','" + ilce_combo.Text + "','" + cep1_masketb.Text + "','" + cep2_masketb.Text + "','" + (mail_tb.Text + "@" + mail_uzantisi_combo.Text) + "','" + adres_tb.Text + "','" + ehliyet_no_tb.Text + "','" + ehliyet_turu_combo.Text + "','" + ehliyet_tarihi_dt.Text + "','" + aciklama_tb.Text + "',1)", baglanti);//EKLEME KOMUTLARI
                }
                komut.ExecuteNonQuery();//KOMUTLARI ÇALIŞTIRMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                MessageBox.Show(tc_masketb.Text + " TC KİMLİK NOLU ADI:" + ad_tb.Text.ToUpper() + " SOYADI:" + soyad_tb.Text.ToUpper() + "\nMÜŞTERİMİZ SİSTEME EKLENMIŞTIR.", "MÜŞTERİ EKLEME İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();//YENİ GİRİŞ İÇİN BAŞLANGIÇ DURUMUNU DÖNDÜRME FOKSİYONU
            }
            catch (Exception)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show("MÜŞTERİ TC KİMLİK NUMARASI BULUNMAKTADIR.\nMÜŞTERİ EĞER SİSTEMDE DEĞİLSE ARŞİVDEN ÇIKARABİLİRSİNİZ.", "MÜŞTERİ EKLEME İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void musteri_ekle_pb_MouseMove(object sender, MouseEventArgs e)
        {
            musteri_ekle_pb.Image = Image.FromFile(@"image\musteri_ekle2.png");//GÖRSEL EFEKT
        }

        private void musteri_ekle_pb_MouseLeave(object sender, EventArgs e)
        {
            musteri_ekle_pb.Image = Image.FromFile(@"image\musteri_ekle1.png");//VARSAYILAN EFEKT
        }

        private void aciklama_tb_TextChanged(object sender, EventArgs e)
        {//GÖRSEL SORUNU DÜZENLEME
            if (aciklama_tb.TextLength >= 10 && aciklama_tb.TextLength <= 99)
            {
                karkater_sayisi_kalan_label.Location = new Point(723, 304);
            }
            else if (aciklama_tb.TextLength >= 100)
            {
                karkater_sayisi_kalan_label.Location = new Point(714, 304);
            }
            else
            {
                karkater_sayisi_kalan_label.Location = new Point(728, 304);
            }
            karkater_sayisi_kalan_label.Text = aciklama_tb.Text.Count().ToString() + "/255";//KAÇ KARAKTER YAZILDI
        }

        private void temizle_pb_Click(object sender, EventArgs e)
        {
            temizle();//VARSAYILAN KUTULAR SEÇİMLER
        }
        private void temizle()//HER ŞEYİ İLK AÇILISA GÖNDÜRÜR
        {
            tc_masketb.Text = ad_tb.Text = soyad_tb.Text = cep1_masketb.Text = cep2_masketb.Text = mail_tb.Text = adres_tb.Text = ehliyet_no_tb.Text = aciklama_tb.Text = "";//KUTULARI TEMİZLEME
            erkek_cb.Checked = true;//VARSAYILAN SEÇİM
            il_combo.SelectedIndex = 33;//İLLER ARASINDAN İSTANBULU SEÇME
            ilce_combo.SelectedIndex =ehliyet_turu_combo.SelectedIndex= 0;//İLÇE EHLİYET TURLERINININ İLKİNİ SEÇME
            ehliyet_tarihi_dt.Value = DateTime.Today;//GÜNÜ SEÇME
            mail_uzantisi_combo.SelectedIndex = 1;//MAİL UZANTISI SEÇME
        }

        private void temizle_pb_MouseMove(object sender, MouseEventArgs e)
        {
            temizle_pb.Image = Image.FromFile(@"image\musteri_temizle2.png");//GÖRSEL EFEKT
        }

        private void temizle_pb_MouseLeave(object sender, EventArgs e)
        {
            temizle_pb.Image = Image.FromFile(@"image\musteri_temizle1.png");//VARSAYILAN EFEKT
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCRESINI AÇAR
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
