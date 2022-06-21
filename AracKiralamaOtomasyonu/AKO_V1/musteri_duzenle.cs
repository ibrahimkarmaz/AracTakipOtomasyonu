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
    public partial class musteri_duzenle : Form
    {
        public musteri_duzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        private void musteri_duzenle_Load(object sender, EventArgs e)
        {
            mail_uzantisi_cek();//MAİL UZANTISINI ÇEKME
            illeri_cek();//İLLERİ GETİRME
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            tcleri_getir();//MÜŞTERİLERİ GETİRME
            kiralayan_tc_sil();//ARAÇ KİRALADA İSE DEĞİŞİKLİK YAPILAMAZ
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }

        }
        private void fotograflari_al_ve_duzenle()
        {//VARSAYILAN GÖRSELLER
            musteri_tc_pb.Image = Image.FromFile(@"image\kullanici.png");
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

            musteri_duzenle_pb.Image = Image.FromFile(@"image\musteri_duzenle1.png");
            musteri_duzenle_menu.Image = Image.FromFile(@"image\yenile1.png");
            musteri_duzenle_sagtik.Image = Image.FromFile(@"image\yenile1.png");
            musteri_iptal_et_pb.Image = Image.FromFile(@"image\musteri_iptal1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");

            musteri_tc_pb.SizeMode = tc_pb.SizeMode = ad_pb.SizeMode = soyad_pb.SizeMode = cinsiyet_pb.SizeMode = il_pb.SizeMode = ilce_pb.SizeMode = cep1_pb.SizeMode = cep2_pb.SizeMode = mail_pb.SizeMode = adres_pb.SizeMode = ehliyet_no_pb.SizeMode = ehliyet_tarihi_pb.SizeMode = ehliyet_turu_pb.SizeMode = aciklama_pb.SizeMode = musteri_iptal_et_pb.SizeMode = musteri_duzenle_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void mail_uzantisi_cek()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(uzanti_adi) AS uzanti from mail_uzantisi", baglanti);//MAİL UZANTISI ÇEKME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA İŞLEMLERI
                {
                    mail_uzantisi_combo.Items.Add(oku["uzanti"]);//SEÇİM KUTUSUNA EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                mail_uzantisi_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
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
                komut = new SqlCommand("select RTRIM(sehir) AS sehir from iller", baglanti);//ŞEHİRLERİ ÇEKME
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    il_combo.Items.Add(oku["sehir"]);//SEÇİM KUTUSUNA EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                il_combo.SelectedIndex = 33;
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            ehliyet_no_tb.MaxLength = 6;//EN FAZLA GİRİBİLECEK KARAKTER
            ad_tb.MaxLength = soyad_tb.MaxLength = 20;//EN FAZLA GİRİBİLECEK KARAKTER
            mail_tb.MaxLength = 50;//EN FAZLA GİRİBİLECEK KARAKTER
            adres_tb.MaxLength = 150;//EN FAZLA GİRİBİLECEK KARAKTER
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
            ehliyet_tarihi_dt.MaxDate = DateTime.Today;//BUGÜNKİ TARİH

        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI HATALARI DÜZENLEME
            musteri_bilgileri_gb.ForeColor = ehliyet_no_gb.ForeColor = this.ForeColor;
        }
        private void tcleri_getir()
        {
            try
            {
                musteri_tc_combo.Items.Clear();
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from musteri_tablosu where arsiv=1", baglanti);//TÜM MÜŞTERİLERİN TC GETİRME FOKSİYON
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    musteri_tc_combo.Items.Add(oku["tcno"]);//SEÇİM KUTUSUNA EKLE
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void kiralayan_tc_sil()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select distinct(musteri_tablosu.tcno) as TCNO from kiralama_tablosu inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id where kiralama_tablosu.arsiv=1", baglanti);//ARAÇ KİRALAYANLARI GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    musteri_tc_combo.Items.Remove(oku["TCNO"]);//SİLME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                if (musteri_tc_combo.Items.Count > 0)
                {
                    musteri_tc_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
                }
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void il_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilce_combo.Items.Clear();//İLÇELERİ SİLME (İLLERE GÖRE DEĞİŞİYOR ÇÜNKÜ :D)
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(ilce) as ilce from ilceler where sehir='" + (il_combo.SelectedIndex + 1).ToString() + "'", baglanti);//İLLERE GÖRE İLÇELERİ GETİREN KOMUT
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
            musteri_iptal_et_pb.Image = Image.FromFile(@"image\musteri_iptal1.png");//VARSAYILAN GÖRSEL
        }

        private void musteri_tc_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (musteri_tc_combo.Items.Count > 0)//MÜŞTERİ VARSA
            {
                secilen_tc();//BİLGİLERİNİ GETİRME FOKSİYONU
            }
        }
        string musteri_id = "";//MÜŞTERI IDISINI SAKLAMA
        private void secilen_tc()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from musteri_tablosu where tcno='" + musteri_tc_combo.SelectedItem + "'", baglanti);//MÜŞTERİ TC BİLGİLERİ GÖRE BİLGİLERİ GETİRME
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    musteri_id = oku["musteri_id"].ToString();//MÜŞTERİ ID SAKLAMA
                    //MÜŞTERİ BİLGİLERİNİ KUTU, SEÇİM KUTUSUNA VE İŞRATET KUTULARINA AKTARMA
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
                    cep1_masketb.Text = oku["cep1"].ToString();
                    cep2_masketb.Text = oku["cep2"].ToString();
                    mail_tb.Text = (oku["eposta"].ToString().Split('@'))[0];
                    mail_uzantisi_combo.SelectedIndex = mail_uzantisi_combo.Items.IndexOf((oku["eposta"].ToString().Split('@'))[1]);
                    adres_tb.Text = oku["adres"].ToString();
                    ehliyet_no_tb.Text = oku["ehliyet_no"].ToString();
                    ehliyet_turu_combo.SelectedIndex = ehliyet_turu_combo.Items.IndexOf(oku["ehliyet_turu"].ToString());
                    ehliyet_tarihi_dt.Value = Convert.ToDateTime(oku["ehliyet_tarihi"].ToString());
                    aciklama_tb.Text = oku["aciklama"].ToString();
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        bool ehliyet_no_varmi = false;//EHLİYET KONTOLU (AYNI EKLİYETTEN BİRDEN FAZLA MÜŞTERİDE OLAMAZ)
        private void ehliyet_no_kontrol()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from musteri_tablosu where ehliyet_no='"+ehliyet_no_tb.Text+"' and tcno<>'"+musteri_tc_combo.Text+"'",baglanti);//MÜŞTERİ TC İLE AYNI OLMAYAN EHLİYETLERI GETİRME
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    ehliyet_no_varmi = true;//VARSA TRUE
                }
                else
                {
                    ehliyet_no_varmi = false;//YOKSA FALSE
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void musteri_duzenle_pb_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tc_masketb.Text) == false)//TC BOŞ MU
            {
                if (tc_masketb.Text.Count() == 11)//TC EKSİKMİ
                {
                    if (ad_tb.Text != "")//ADI VARMI
                    {
                        if (soyad_tb.Text != "")//SOYADI VARMI
                        {
                            if (cep1_masketb.Text != "(   )    -")//CEP TELEFONU 1 VAR MI
                            {
                                if (cep1_masketb.Text.Count() == 14)//TELEFON NO EKSİKMİ
                                {
                                    if (cep2_masketb.Text != "(   )    -")//CEP TELEFONU 2 VAR MI
                                    {
                                        if (cep2_masketb.Text.Count() == 14)//TELEFON NO EKSİKMİ
                                        {
                                            if (mail_tb.Text != "")//E-POSTA ADRESI VARMY
                                            {
                                                if (adres_tb.Text != "")//ADRES VAR MI
                                                {
                                                    if (ehliyet_no_tb.Text != "")//EHLİYET VARMI
                                                    {
                                                        if (ehliyet_no_tb.Text.Count() == 6)//EHLİYET EKSİK MI
                                                        {
                                                            ehliyet_no_kontrol();//VERİTABANINDA EHLİYET VAR MI
                                                            if (ehliyet_no_varmi != true)//EHLİYET KONTROL
                                                            {
                                                                veritabanina_musteri_duzenle();//MÜŞTERİ BİLGİLERİ DÜZENLEME FOKSİYONU
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("EHLİYET NUMARASI BULUNMAKTADIR.\nFARKLI EHLİYET NUMARASI GİRİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("EHLİYET NO BİLGİNİZ EKSİKTİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI
                                                        }

                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("EHLİYET NO BİLGİNİZİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("ADRES BİLGİLERİNİZİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("E-POSTA ADRES BİLGİLERİNİZİ DOLDURUNUZ VE SEÇİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("CEP TELEFONU(2) NUMARANIZ EKSİKTİR", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("CEP TELEFONU(2) NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("CEP TELEFONU(1) NUMARANIZ EKSİKTİR", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI//UYARI VERME MESAJ PENCERESI
                                }
                            }
                            else
                            {
                                MessageBox.Show("CEP TELEFONU(1) NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("SOYADINIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI
                        }
                    }
                    else
                    {
                        MessageBox.Show("ADINIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI
                    }
                }
                else
                {
                    MessageBox.Show("TC KİMLİK NUMARANIZ EKSİKTİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI
                }
            }
            else
            {
                MessageBox.Show("TC KİMLİK NUMARANIZI DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERME MESAJ PENCERESI
            }
        }
        private void veritabanina_musteri_duzenle()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                if (erkek_cb.Checked == true)//ERKEK KOMUTLARI
                {
                    komut = new SqlCommand("update musteri_tablosu set tcno='" + tc_masketb.Text + "', ad='" + ad_tb.Text + "', soyad='" + soyad_tb.Text + "', cinsiyet=1, il='" + il_combo.Text + "', ilce='" + ilce_combo.Text + "', cep1='" + cep1_masketb.Text + "', cep2='" + cep2_masketb.Text + "', eposta='" + (mail_tb.Text + "@" + mail_uzantisi_combo.Text) + "', adres='" + adres_tb.Text + "', ehliyet_no='" + ehliyet_no_tb.Text + "', ehliyet_turu='" + ehliyet_turu_combo.Text + "', ehliyet_tarihi='" + ehliyet_tarihi_dt.Text + "', aciklama='" + aciklama_tb.Text + "', arsiv=1 where musteri_id=" + musteri_id, baglanti);//YENİ BİLGİLERİ GÖRE DÜZENLEME KOMUTU
                }
                else if (kadin_cb.Checked == true)//KADIN KOMUTLARI
                {
                    komut = new SqlCommand("update musteri_tablosu set tcno='" + tc_masketb.Text + "', ad='" + ad_tb.Text + "', soyad='" + soyad_tb.Text + "', cinsiyet=0, il='" + il_combo.Text + "', ilce='" + ilce_combo.Text + "', cep1='" + cep1_masketb.Text + "', cep2='" + cep2_masketb.Text + "', eposta='" + (mail_tb.Text + "@" + mail_uzantisi_combo.Text) + "', adres='" + adres_tb.Text + "', ehliyet_no='" + ehliyet_no_tb.Text + "', ehliyet_turu='" + ehliyet_turu_combo.Text + "', ehliyet_tarihi='" + ehliyet_tarihi_dt.Text + "', aciklama='" + aciklama_tb.Text + "', arsiv=1 where musteri_id=" + musteri_id, baglanti);//YENİ BİLGİLERİ GÖRE DÜZENLEME KOMUTU
                }
                komut.ExecuteNonQuery();//KOMUTLARI ÇALIŞTIRMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                MessageBox.Show(tc_masketb.Text + " TC KİMLİK NOLU ADI:" + ad_tb.Text.ToUpper() + " SOYADI:" + soyad_tb.Text.ToUpper() + "\nMÜŞTERİMİZİN BİLGİLERİ DÜZENLENMİŞTİR.", "MÜŞTERİ DÜZENLEME İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tc_islemlerini_guncelle();//TC ÜZERİNDE İŞLEM YAPAR
            }
            catch (Exception)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show("MÜŞTERİ TC KİMLİK NUMARASI BULUNMAKTADIR.\nFARKLI TC KİMLİK NUMARASI GİRİNİZ...", "MÜŞTERİ DÜZENLEME İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tc_islemlerini_guncelle()
        {
            tcleri_getir();//TEKRAR TC GETİRİR GÜNCELLEME YAPAR
            kiralayan_tc_sil();//ARAÇ KİRALAYAN MÜŞTERİLERİ SİLER
        }
        private void musteri_duzenle_pb_MouseMove(object sender, MouseEventArgs e)
        {
            musteri_duzenle_pb.Image = Image.FromFile(@"image\musteri_duzenle2.png");//GÖRSEL EFEKT
        }

        private void musteri_duzenle_pb_MouseLeave(object sender, EventArgs e)
        {
            musteri_duzenle_pb.Image = Image.FromFile(@"image\musteri_duzenle1.png");//VARSAYILAN GÖRSEL
        }

        private void aciklama_tb_TextChanged(object sender, EventArgs e)
        {//OLUŞAN GÖRSEL HATAYI DÜZENLENIR
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
            karkater_sayisi_kalan_label.Text = aciklama_tb.Text.Count().ToString() + "/255";
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESINI AÇMA
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
