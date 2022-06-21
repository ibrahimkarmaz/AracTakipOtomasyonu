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
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class profil_bilgilerini_degistir : Form
    {
        public profil_bilgilerini_degistir()
        {
            InitializeComponent();
        }
        /*GÖREV NO 4 BU SABİT DEĞİŞECEK
         görev no bilgilerini ilk sayfadan çekmek mantıklı*/
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        string eski_tc="";//TC BİLGİSİNİ SAKLAMA
        private void profil_bilgilerini_degistir_Load(object sender, EventArgs e)
        {
            erkek_cb.Checked = true;//SEÇİM YAPMA
            mail_uzantisi_cek();//MAİL UZANTISINI ÇEKME
            illeri_cek();//İLLERİ ÇEKME
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            profil_bilgileri_getir();//PROFİL BİLGİLERİ GETİRME
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void profil_bilgileri_getir()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from personel_tablosu where tcno='"+giris_penceresi.tcno+"'", baglanti);//KULLANICI TCYE GÖRE BİLGİ ÇEKME
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {//BİLGİLERİN AKTARILDIĞI YER
                    tc_masketb.Text = oku["tcno"].ToString();
                    ad_tb.Text = oku["ad"].ToString();
                    soyad_tb.Text = oku["soyad"].ToString();
                    if (Convert.ToByte(oku["cinsiyet"]) == 1)
                    {
                        erkek_cb.Checked = true;
                    }
                    else if (Convert.ToByte(oku["cinsiyet"]) == 0)
                    {
                        kadin_cb.Checked = true;
                    }
                    dogum_yeri_tb.Text = oku["dogum_yeri"].ToString();
                    zaman_datetime.Value = Convert.ToDateTime(oku["dogum_tarihi"].ToString());
                    cep_masketb.Text = oku["cep_telefonu"].ToString();
                    ev_masketb.Text = oku["ev_telefonu"].ToString();
                    mail_tb.Text = (oku["eposta"].ToString().Split('@'))[0];
                    mail_uzantisi_combo.SelectedIndex = mail_uzantisi_combo.Items.IndexOf((oku["eposta"].ToString().Split('@'))[1]);
                    adres_tb.Text = oku["ev_adresi"].ToString();
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from profil_fotograf_tablosu where tcno='" + giris_penceresi.tcno + "'", baglanti);//FOTOĞRAFIN ÇEKİLDİĞİ KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    yeniyol = oku["fotograf_uzantisi"].ToString();//FOTOĞRAF YOLU
                    profil_fotografi_combo.SelectedIndex = profil_fotografi_combo.Items.IndexOf(oku["fotograf_adi"]);//FOTOĞRAF ADI
                    profil_fotografi_pb.ImageLocation = oku["fotograf_uzantisi"].ToString();//FOTOĞRAFI EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
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
            dogum_yeri_pb.Image = Image.FromFile(@"image\yer.png");
            dogum_tarihi_pb.Image = Image.FromFile(@"image\tarih.png");
            cep_pb.Image = Image.FromFile(@"image\ceptelefonu.png");
            ev_pb.Image = Image.FromFile(@"image\evtelefonu.png");
            mail_pb.Image = Image.FromFile(@"image\mail.png");
            adres_pb.Image = Image.FromFile(@"image\evadresi.png");
            duzenle_pb.Image = Image.FromFile(@"image\duzenle1.png");
            duzenle_menu.Image = Image.FromFile(@"image\tekrar.png");
            duzenle_sagtik.Image = Image.FromFile(@"image\tekrar.png");
            iptalet_pb.Image = Image.FromFile(@"image\iptal1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");
            tc_pb.SizeMode = ad_pb.SizeMode = soyad_pb.SizeMode = cinsiyet_pb.SizeMode = il_pb.SizeMode = ilce_pb.SizeMode = dogum_yeri_pb.SizeMode = dogum_tarihi_pb.SizeMode = cep_pb.SizeMode = ev_pb.SizeMode = mail_pb.SizeMode = adres_pb.SizeMode = duzenle_pb.SizeMode = iptalet_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI SORUNLARI DÜZENLEME
            fotograf_gb.ForeColor =profil_bilgileri_gb.ForeColor= this.ForeColor;
        }
        
        private void mail_uzantisi_cek()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(uzanti_adi) AS uzanti from mail_uzantisi", baglanti);//MAİL UZANTILARINI ÇEKME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    mail_uzantisi_combo.Items.Add(oku["uzanti"]);//EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                mail_uzantisi_combo.SelectedIndex = 1;
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
                komut = new SqlCommand("select RTRIM(sehir) AS sehir from iller", baglanti);//İLLERİ ÇEKER
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())
                {
                    il_combo.Items.Add(oku["sehir"]);//EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                il_combo.SelectedIndex = 33;//İSTANBUL SEÇİLİR
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            ad_tb.MaxLength = soyad_tb.MaxLength = dogum_yeri_tb.MaxLength = 20;//EN FAZLA KARAKTER
            mail_tb.MaxLength = 50;//EN FAZLA KARAKTER
            adres_tb.MaxLength = 150;//EN FAZLA KARAKTER
            DateTime onsekizyil = DateTime.Now.AddYears(-18);//KULLANICI 18 YAŞINDAN BÜYÜK OLMA DURUMU
            zaman_datetime.Value = onsekizyil;//EKLEME

            zaman_datetime.MaxDate = onsekizyil;//MAX DEĞER YAPMA
            //VARSAYILAN PROFİL FOTOĞRAFLARI
            profil_fotografi_combo.Items.Add("VARSAYILAN FOTOĞRAF");
            profil_fotografi_combo.Items.Add("TÜRKİYE BAYRAĞI[DİKDÖRTGEN]");
            profil_fotografi_combo.Items.Add("TÜRKİYE BAYRAĞI[ÇEMBER]");
            profil_fotografi_combo.Items.Add("AZERBAYCAN BAYRAĞI[DİKDÖRTGEN]");
            profil_fotografi_combo.Items.Add("KRAL [SATRANÇ]");
            profil_fotografi_combo.Items.Add("VEZİR [SATRANÇ]");
            profil_fotografi_combo.Items.Add("FİL [SATRANÇ]");
            profil_fotografi_combo.Items.Add("AT [SATRANÇ]");
            profil_fotografi_combo.Items.Add("KALE [SATRANÇ]");
            profil_fotografi_combo.Items.Add("PİYON [SATRANÇ]");
            profil_fotografi_combo.Items.Add("İLKBAHAR YAPRAĞI");
            profil_fotografi_combo.Items.Add("SONBAHAR YAPRAĞI");
            profil_fotografi_combo.Items.Add("MAVİ KELEBEK");
            profil_fotografi_combo.Items.Add("RENKLI KELEBEK");
            profil_fotografi_combo.Items.Add("GORGİ [KÖPEK]");
            profil_fotografi_combo.Items.Add("KEDİ");
            profil_fotografi_combo.Items.Add("TAVŞAN");
            profil_fotografi_combo.Items.Add("KAPLUMBAĞA");
            profil_fotografi_combo.Items.Add("GÜVERCİN");
            profil_fotografi_combo.Items.Add("FENİX KUŞU");
            profil_fotografi_combo.Items.Add("MÜZİK İŞARETİ");
            profil_fotografi_combo.Items.Add("SPOR");
            profil_fotografi_combo.Items.Add("MASKE");
            profil_fotografi_combo.Items.Add("FİKİR");
            profil_fotografi_combo.Items.Add("HAYALET [KARAKTER]");
            profil_fotografi_combo.Items.Add("MARİO [KARAKTER]");
            profil_fotografi_combo.Items.Add("SAMURAY KASKI [KARAKTER]");
            profil_fotografi_combo.Items.Add("KORSAN İŞARETİ [KARAKTER]");
            profil_fotografi_combo.Items.Add("GÜLEN KAFE");
            profil_fotografi_combo.Items.Add("GÜLEN YUMURTA");
            profil_fotografi_combo.Items.Add("YÜKLENEN FOTOĞRAF");
            profil_fotografi_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
        }

        private void profil_fotografi_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (profil_fotografi_combo.SelectedIndex!=profil_fotografi_combo.Items.Count-1)//EĞER YÜKLENEN FOTOĞRAF DEĞİLSE
            {
                profil_fotografi_pb.Image = Image.FromFile(@"image\profil_fotograflari\varsayilanlar\varsayilan" + profil_fotografi_combo.SelectedIndex + ".png");//SIRA NUMARASI İLE FOTOĞRAFI GÖSTER
            }
            else
            {
                if (yeniyol=="")
                {
                    profil_fotografi_combo.SelectedIndex = profil_fotografi_combo.Items.Count - 2;//YÜKLENEN FOTOĞRAF YOK İSE VARSAYILAN FOTOĞRAFLARI GÖSTER
                }
                else
                {
                    profil_fotografi_pb.ImageLocation = yeniyol;//YÜKLENEN FOTOĞRAFI GÖSTER
                }

            }
            
        }
        OpenFileDialog DosyaAc = new OpenFileDialog();//FOTOĞRAF YÜKLEME PENCERESI
        string yeniyol="",dosyayolu="";//SAKLAMA DEĞİŞKENLERI
        private void fotograf_yuke_label_Click(object sender, EventArgs e)
        {
            DosyaAc.Filter = "Resim Uzantıları (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";//SEÇİLEBİLİR SEÇİM UZANTILARI
            if (DosyaAc.ShowDialog()==DialogResult.OK)//SEÇİLDİ İSE
            {
                yeniyol = Application.StartupPath + @"\image\profil_fotograflari\sonradan_yuklenenler\" + Guid.NewGuid().ToString() + ".png";//YENİ YOL BELİRLE
                dosyayolu = DosyaAc.FileName;//SEÇİLEN DOSYA YOLU
                profil_fotografi_combo.SelectedIndex = profil_fotografi_combo.Items.Count - 1;//FOTOĞRAF YÜKLENDI SEÇENEĞİ
                profil_fotografi_pb.ImageLocation = dosyayolu;//SEÇİLEN FOTOĞRAFI GÖSTER
                profil_fotografi_combo.Enabled = false;//FOTOĞRAF EKLENDİ İSE SEÇİMLERİ KAPAT
            }
        }

        private void fotograf_yuke_label_MouseMove(object sender, MouseEventArgs e)
        {
            fotograf_yuke_label.ForeColor = Color.Red;//YAZI RENGİ DEĞİŞTİRME
        }

        private void fotograf_yuke_label_MouseLeave(object sender, EventArgs e)
        {
            fotograf_yuke_label.ForeColor = this.ForeColor;//VARSAYILAN RENK
        }

        private void il_combo_SelectedIndexChanged(object sender, EventArgs e)
        {//İL SEÇİLDİĞİNDE ÇALIŞIR
            ilce_combo.Items.Clear();//İLÇELER SİLİNİR YENİ İLÇELER İÇİN
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(ilce) as ilce from ilceler where sehir='" + (il_combo.SelectedIndex + 1).ToString() + "'", baglanti);//İLE GÖRE İLÇELERİ GETİRME
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

        private void duzenle_pb_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tc_masketb.Text) == false)//TC BOŞ MU KONTROL
            {
                if (tc_masketb.Text.Count() == 11)//TC EKSİKMİ
                {
                    if (ad_tb.Text != "")//AD BOŞ MU
                    {
                        if (soyad_tb.Text != "")//SOYAD BOŞMU
                        {
                            if (dogum_yeri_tb.Text != "")//DOĞUM YERİ BOŞMU
                            {
                                if (cep_masketb.Text != "(   )    -")//CEP TELEFONU BİLGİ BOŞMU
                                {
                                    if (cep_masketb.Text.Count() == 14)//CEP TELEFONU EKSİKMİ
                                    {
                                        if (ev_masketb.Text != "(   )    -")//EV TELEFONU BOŞMU
                                        {
                                            if (ev_masketb.Text.Count() == 14)//EV TELEFONU EKSİKMİ
                                            {
                                                if (mail_tb.Text != "")//E POSTA ADRESİ BOŞMU
                                                {
                                                    if (adres_tb.Text != "")//EV ADRESİ BOŞMU
                                                    {
                                                        duzenle();//PROFİL BİLGİLERİNİ DÜZENLEME
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("ADRES BİLGİLERİNİZİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SORUNLAR HAKKINDA UYARI VERİR
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("E-POSTA ADRES BİLGİLERİNİZİ DOLDURUNUZ VE SEÇİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SORUNLAR HAKKINDA UYARI VERİR
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("EV TELEFONU NUMARANIZ EKSİKTİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SORUNLAR HAKKINDA UYARI VERİR
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("EV TELEFONU NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SORUNLAR HAKKINDA UYARI VERİR
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("CEP TELEFONU NUMARANIZ EKSİKTİR", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SORUNLAR HAKKINDA UYARI VERİR
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("CEP TELEFONU NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SORUNLAR HAKKINDA UYARI VERİR
                                }
                            }
                            else
                            {
                                MessageBox.Show("DOĞUM YERİNİZİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SORUNLAR HAKKINDA UYARI VERİR
                            }
                        }
                        else
                        {
                            MessageBox.Show("SOYADINIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SORUNLAR HAKKINDA UYARI VERİR
                        }
                    }
                    else
                    {
                        MessageBox.Show("ADINIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SORUNLAR HAKKINDA UYARI VERİR
                    }
                }
                else
                {
                    MessageBox.Show("TC KİMLİK NUMARANIZ EKSİKTİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SORUNLAR HAKKINDA UYARI VERİR
                }
            }
            else
            {
                MessageBox.Show("TC KİMLİK NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SORUNLAR HAKKINDA UYARI VERİR
            }
        }

        private void duzenle()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                if (erkek_cb.Checked == true)//CİNSİYETE GÖRE EKLEME İŞLEMLERI UYGULANIR
                {
                    if (degistir_cb.Checked==true)//EĞER TC DEĞİŞMİŞ İSE:
                    {
                        komut = new SqlCommand("update personel_tablosu set tcno='" + tc_masketb.Text + "',ad='" + ad_tb.Text + "',soyad='" + soyad_tb.Text + "',cinsiyet=1,il='" + il_combo.Text + "',ilce='" + ilce_combo.Text + "',dogum_yeri='" + dogum_yeri_tb.Text + "',dogum_tarihi='" + zaman_datetime.Value.ToShortDateString() + "',cep_telefonu='" + cep_masketb.Text + "',ev_telefonu='" + ev_masketb.Text + "',eposta='" + (mail_tb.Text + "@" + mail_uzantisi_combo.Text) + "',ev_adresi='" + adres_tb.Text + "',arsiv=1 where tcno='" + eski_tc + "'", baglanti);//PROFİL BİLGİLERİNİ DEĞİŞTİRME KOMUTU
                    }
                    else//DEĞİŞMEDİYSE:
                    {
                        komut = new SqlCommand("update personel_tablosu set ad='" + ad_tb.Text + "',soyad='" + soyad_tb.Text + "',cinsiyet=1,il='" + il_combo.Text + "',ilce='" + ilce_combo.Text + "',dogum_yeri='" + dogum_yeri_tb.Text + "',dogum_tarihi='" + zaman_datetime.Value.ToShortDateString() + "',cep_telefonu='" + cep_masketb.Text + "',ev_telefonu='" + ev_masketb.Text + "',eposta='" + (mail_tb.Text + "@" + mail_uzantisi_combo.Text) + "',ev_adresi='" + adres_tb.Text + "',arsiv=1 where tcno='" + tc_masketb.Text + "'", baglanti);//PROFİL BİLGİLERİNİ DEĞİŞTİRME KOMUTU
                    }
                }
                else if (kadin_cb.Checked == true)//CİNSİYETE GÖRE EKLEME İŞLEMLERI UYGULANIR
                {
                    if (degistir_cb.Checked == true)//EĞER TC DEĞİŞMİŞ İSE:
                    {
                        komut = new SqlCommand("update personel_tablosu set tcno='" + tc_masketb.Text + "',ad='" + ad_tb.Text + "',soyad='" + soyad_tb.Text + "',cinsiyet=0,il='" + il_combo.Text + "',ilce='" + ilce_combo.Text + "',dogum_yeri='" + dogum_yeri_tb.Text + "',dogum_tarihi='" + zaman_datetime.Value.ToShortDateString() + "',cep_telefonu='" + cep_masketb.Text + "',ev_telefonu='" + ev_masketb.Text + "',eposta='" + (mail_tb.Text + "@" + mail_uzantisi_combo.Text) + "',ev_adresi='" + adres_tb.Text + "',arsiv=1 where tcno='" + eski_tc + "'", baglanti);//PROFİL BİLGİLERİNİ DEĞİŞTİRME KOMUTU
                    }
                    else//DEĞİŞMEDİYSE:
                    {
                        komut = new SqlCommand("update personel_tablosu set ad='" + ad_tb.Text + "',soyad='" + soyad_tb.Text + "',cinsiyet=0,il='" + il_combo.Text + "',ilce='" + ilce_combo.Text + "',dogum_yeri='" + dogum_yeri_tb.Text + "',dogum_tarihi='" + zaman_datetime.Value.ToShortDateString() + "',cep_telefonu='" + cep_masketb.Text + "',ev_telefonu='" + ev_masketb.Text + "',eposta='" + (mail_tb.Text + "@" + mail_uzantisi_combo.Text) + "',ev_adresi='" + adres_tb.Text + "',arsiv=1 where tcno='" + tc_masketb.Text + "'", baglanti);//PROFİL BİLGİLERİNİ DEĞİŞTİRME KOMUTU
                    }
                }
                komut.ExecuteNonQuery();//KOMUTLARI ÇALIŞTIRMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                if (degistir_cb.Checked==true)//TC DEĞİŞTİ Mİ
                {
                    //Tüm Türkiye Cumhuriyeti Kimlik Numaraları Değiştirildi.
                    baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                    komut = new SqlCommand("execute tum_tc_degistir '"+eski_tc+"','"+tc_masketb.Text+"'", baglanti);//PROSEDUR TCYE BAĞLI OLAN TÜM TABLOLARI DEĞİŞTİRİR
                    komut.ExecuteNonQuery();//KOMUT ÇALIŞTIRMA
                    baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                    //profil resimleri kaydedildi tc değişti ise ona göre kayıt yapıldı.(NOT:TC DEĞİŞTİ ÜSTE ONDAN DOLAYI MASKE KUTUSUNDAN TC ALINDI.)
                    if (profil_fotografi_combo.SelectedIndex != profil_fotografi_combo.Items.Count - 1)
                    {//varsayilan resimler kaydedildi.
                        baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                        komut = new SqlCommand("update profil_fotograf_tablosu set fotograf_adi='" + profil_fotografi_combo.Text + "',fotograf_uzantisi='" + (@"image\profil_fotograflari\varsayilanlar\varsayilan" + profil_fotografi_combo.SelectedIndex + ".png") + "' where tcno='" + tc_masketb.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                    }
                    else
                    {//sonradan eklenen resimleri kopyalanıp veritabanına yeni kopya adresi kaydedildi.
                        File.Copy(dosyayolu, yeniyol);
                        baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                        komut = new SqlCommand("update profil_fotograf_tablosu set fotograf_adi='" + profil_fotografi_combo.Text + "',fotograf_uzantisi='" + yeniyol + "' where tcno='" + tc_masketb.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                    }
                }
                else
                {//kayitlar üstekiler gibi fakat değişmeyen tc üzerinde kayıtlar yapıldı.
                    if (profil_fotografi_combo.SelectedIndex != profil_fotografi_combo.Items.Count - 1)
                    {
                        baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                        komut = new SqlCommand("update profil_fotograf_tablosu set fotograf_adi='" + profil_fotografi_combo.Text + "' ,fotograf_uzantisi='" + (@"image\profil_fotograflari\varsayilanlar\varsayilan" + profil_fotografi_combo.SelectedIndex.ToString() + ".png") + "' where tcno='" + tc_masketb.Text+"'", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                    }
                    else
                    {
                        File.Copy(dosyayolu, yeniyol);
                        baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                        komut = new SqlCommand("update profil_fotograf_tablosu set fotograf_adi='" + profil_fotografi_combo.Text + "' ,fotograf_uzantisi='" +yeniyol + "' where tcno='" + tc_masketb.Text+"'", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                    }
                }
                MessageBox.Show("PROFİL BİLGİLERİ DÜZENLENDİ.", "PROFİL DÜZENLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void duzenle_pb_MouseMove(object sender, MouseEventArgs e)
        {
            duzenle_pb.Image = Image.FromFile(@"image\duzenle2.png");//EFEKT GÖRSELI
        }

        private void duzenle_pb_MouseLeave(object sender, EventArgs e)
        {
            duzenle_pb.Image = Image.FromFile(@"image\duzenle1.png");//VARSAYILAN GÖRSEL
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
            iptalet_pb.Image = Image.FromFile(@"image\iptal2.png");//GÖRSEL EFEKT
        }

        private void iptalet_pb_MouseLeave(object sender, EventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\iptal1.png");//VARSAYILAN GÖRSEL
        }

        private void degistir_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (degistir_cb.Checked==true)//DEĞİŞTİRME UYGULANINCA
            {
                if (MessageBox.Show("TÜRKİYE CUMHURİYETİ KİMLİK NUMARASINI DEĞİŞTİRMEK İSTEDİĞİNİZİ ONAYLIYOR MUSUNUZ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//TC DEĞİŞTİRMEYİ KABUL EDİYORSA
                {
                    tc_masketb.ReadOnly = false;//TC KUTUSUNU DEĞİŞTİRİLEBİLİR YAPIYOR
                    eski_tc = tc_masketb.Text;//ESKİ TCYİ KAYDEDIYOR
                }
                else
                {
                    eski_tc = tc_masketb.Text;//ESKİ TCYİ KAYDEDIYOR
                    degistir_cb.Checked = false;//SEÇİMİ İPTAL EDİYOR
                }
                
            }
            else if (degistir_cb.Checked==false)
            {
                 tc_masketb.ReadOnly = true;//İŞARET İPTAL EDİLİRSE SADECE OKUNABİLİR OLUYOR
                 tc_masketb.Text = eski_tc;//ESKİ TC KUTUYA GERİ GELİYOR
            }
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESINI AÇMA
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
