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
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class ana_pencere : Form
    {
        public ana_pencere()
        {
            InitializeComponent();
        }
        
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        SqlDataAdapter Komutlar;//TABLOLARIN ÇEKİLMESİNDE KULLANILAN KOMUT//TABLOLARIN ÇEKİLMESİNDE KULLANILAN KOMUT
        DataSet veriseti = new DataSet();//ÇEKİLEN TABLOLARI SAKLAMAK İÇİN GEREK KOMUT//TABLOLARIN ÇEKİLDİĞİNDE SAKLANDIĞI YER
        ArrayList yetkiler = new ArrayList();//YETKİLER İÇİN LİSTE OLUŞTURURDU KONTROL AMAÇLI(ÖRNEĞİN KİRALAMA İŞLEMLERİNE TIKLANDIĞINDA KULLANICININ YETKİSİ ARATILIR VARSA PENCERE AÇILIR YOKSA AÇILMAZ BİLGİ VERİLİR.)
        bool guvenlik_durumu = false;

        public static Color arkaplan_rengi = new Color();
        public static Color yazi_rengi = new Color();
        public static bool renkler_uygulanacakmi=false;
        private void ana_pencere_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            profil_fotografini_ve_ad_soyadi_getir();//KULLANICININ ADINI, SOYADINI VE SEÇİLEN FOTOĞRAFI GETİREN FOKSİYON
            musteri_arac_getir();
            musteri_arac_getir_sonrasi_duzenle();
            arkaplan_ve_yazi_ayarlari();//KULLANICININ SEÇTİĞİ ARKAPLAN VE YAZI RENGİNİ GETİRİR VE DEĞİŞTİRİR. FOKSİYONU
            grup_kutularinin_rengini_degistir();//RENK DEĞİŞTİRME SONUCU OLUŞAN RENK HATALARINI DÜZENLEME FOKSİYONU
            guvenlik_kontrolu();//GÜVENLİK SORULARINI CEVAPLADIMI DİYE KONTROL EDEN FOKSİYON
            yetkileri_getir_ve_yetkiler_listesine_aktar();//PERSONEL YETKİLERİNİ GETİREN FOKSİYON
        }
        private void yetkileri_getir_ve_yetkiler_listesine_aktar()
        {
            try
            {
                yetkiler.Clear();//YETKİLERİN SIFIRLANIR
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(yetkiler) as Yetkiler from personel_yetkileri where tcno='" + giris_penceresi.tcno + "'", baglanti);//KULLANICIYA AİT YETKİLERİ GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    yetkiler.AddRange(oku["Yetkiler"].ToString().Split('-'));//YETKİLER SPLİT İLE AYRILIR VE YETKİLER LİSTESİNE EKLENİR.
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private bool yetki_kontrolu(string kontol_edilecek)//YETKİ İZNİ GEREKTİREN HERHANGİ BİR PENCEREYE TIKLANDIĞINDA ÇAĞRILIR
        {
            return yetkiler.Contains(kontol_edilecek.ToUpper());//EĞER GÖNDERİLEN YETKİ BİLGİSİ VARSA TRUE(DOĞRU) DÖNER VE PENCERE AÇILIR
        }
        
        private void guvenlik_kontrolu()//GÜVENLIK SORULARINI FOKSİYON
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from hesap_kurtarma_tablosu where tcno='" + giris_penceresi.tcno + "'", baglanti);//GÜVENLÜK SORULARINI CEPME FOKSİYONU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    if (oku["guvenlik_sorusu"].ToString()=="")//GÜVENLİK SORUSU VAR MI
                    {
                        guvenlik_durumu = true;//SORUSU YOKTUR YANI GÜVENLIK SORULARINI CEVAPLAMADIĞI İÇİN GÜVENLİK PENCERESİ AÇILACAK
                    }
                    else
                    {
                        guvenlik_durumu = false;//SORUSU VAR HERHANGİ BİR İŞLEM YAPILMAYACAK 
                    }
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                if (guvenlik_durumu == true)//GÜVENLIK SORULARINI CEVAPLAMADIĞI 
                {
                    MessageBox.Show("GÜVENLİK BİLGİLENİZİ DOĞRULAYINIZ.\n\nPAROLANIZI UNUTMANIZ HALINDE KUTARMANIZA KATKI SAĞLAR.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//BİLGİ VERİLDİ.
                    //GÜVENLİK PENCERESİ AÇILACAK
                    hesap_guvenlik hesap_guvenlik_penceresi = new hesap_guvenlik();
                    hesap_guvenlik_penceresi.ShowDialog();
                }
            }
            catch (Exception)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }

        }
        private void profil_fotografini_ve_ad_soyadi_getir()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select UPPER(ad+' '+soyad) as kullanici_adi_soyadi,fotograf_uzantisi,gorevno from personel_tablosu inner join profil_fotograf_tablosu on personel_tablosu.tcno=profil_fotograf_tablosu.tcno where personel_tablosu.tcno='"+giris_penceresi.tcno+"'", baglanti);//KULLANICI ADI SOYAD VE FOTOĞRAF BİLGİLERİNIN ALINDIĞI KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    ad_soyad_label.Text = oku["kullanici_adi_soyadi"].ToString();//AD SOYADİN PENCEREDE GÖZÜKTÜĞÜ YER
                    profil_fotografi_pb.ImageLocation = oku["fotograf_uzantisi"].ToString();//FOTOĞRAFİN UZANTİSİ VE EKLENDİ
                    if (Convert.ToByte(oku["gorevno"])==1)//EĞER YÖNETİCİ İSE
                    {
                        ad_soyad_label.Cursor = Cursors.Hand;//AD SOYAD AKTİF ET
                        yonetici_paneli_menu.Visible = true;//YÖNETİCİYİ ÜST MENÜDE GÖSTER
                        yonetici_paneli_sagtik.Visible = true;//YÖNETİCİYİ SAĞ TIK MENÜDE GÖSTER
                    }
                    else
                    {
                        ad_soyad_label.Cursor = Cursors.Default;//AD SOYAD PASİF KALSIN
                        yonetici_paneli_menu.Visible = false;//YÖNETİCİYİ ÜST MENÜDE GİZLE
                        yonetici_paneli_sagtik.Visible = false;//YÖNETİCİYİ SAĞ TIK MENÜDE GİZLE
                    }
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void arkaplan_ve_yazi_ayarlari()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from ozellestirme_tablosu where tcno='" + giris_penceresi.tcno + "'", baglanti);//ARKAPLAN YAZI RGB KODLARI ALINDIĞI KOMUTLAR
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    arkaplan_rengi = this.BackColor = Color.FromArgb(Convert.ToByte(oku["arkaplan_r"]), Convert.ToByte(oku["arkaplan_g"]), Convert.ToByte(oku["arkaplan_b"]));//ARKAPLAN RGB EKLEDİĞİ VE SAKLANDIĞI YER
                    yazi_rengi = this.ForeColor = Color.FromArgb(Convert.ToByte(oku["yazi_rengi_r"]), Convert.ToByte(oku["yazi_rengi_g"]), Convert.ToByte(oku["yazi_rengi_b"]));//YAZI RGB EKLEDİĞİ VE SAKLANDIĞI YER
                    if (Convert.ToByte(oku["uygulanacak_form"])==1)//RENKLERİN PENCERELERİN KULLANINIP KULLANILMAMASI
                    {
                        renkler_uygulanacakmi = true;//TÜM PENCERELERDE RENKLERİ KULLAN
                    }
                    else
                    {
                        renkler_uygulanacakmi = false;//SADECE ANAPENCEREDE RENKLERİ KULLAN
                    }
                }
                else
                {
                    arkaplan_rengi = this.BackColor = Color.FromArgb(255, 255, 255);//VARSİYALAN ARKAPLAN RENGİ
                    yazi_rengi = this.ForeColor = Color.FromArgb(0, 0, 0);//VARSAYİLAN YAZI RENGİ
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
        }
        private void grup_kutularinin_rengini_degistir()//RENKENDİRME SONRASI SIKINTILARI DÜZENLEME
        {//Datagrid ve darartma label renkleri değiştirildi veya sabit kaldı
            profil_gb.ForeColor=arac_islemleri_gb.ForeColor = arsiv_ve_istatiktikler_gb.ForeColor = kiralama_islemleri_gb.ForeColor = musteri_islemleri_gb.ForeColor = tarih_saat_gb.ForeColor = mesajlar_gb.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
            tablolari_listele_dgv.BackgroundColor = arkaplan_rengi;
            arac_daralt_genislet_label.ForeColor = kiralama_islemleri_daralt_genislet_label.ForeColor = musteri_daralt_genislet_label.ForeColor = arsiv_ist_p_detay_daralt_genislet_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
            tablolari_listele_dgv.ForeColor = Color.Black;
        }
        private void fotograflari_al_ve_duzenle()
        {
            //FOTOĞRAFLARIN DOSYADAN ÇEKİLDİĞİ YER
            arac_arama_pb.Image = Image.FromFile(@"image\arac_arama1.png");
            arac_ekle_pb.Image = Image.FromFile(@"image\arac_ekle1.png");
            arac_duzenle_pb.Image = Image.FromFile(@"image\arac_duzenle1.png");
            arac_cikar_pb.Image = Image.FromFile(@"image\arac_cikar1.png");
            arac_listesi_pb.Image = Image.FromFile(@"image\arac_listesi1.png");

            musteri_arama_pb.Image = Image.FromFile(@"image\musteri_arama1.png");
            musteri_ekle_pb.Image = Image.FromFile(@"image\musteri_ekle1.png");
            musteri_duzenleme_pb.Image = Image.FromFile(@"image\musteri_duzenle1.png");
            musteri_cikar_pb.Image = Image.FromFile(@"image\musteri_cikar1.png");
            musteri_listesi_pb.Image = Image.FromFile(@"image\musteri_listesi1.png");

            teslim_al_pb.Image = Image.FromFile(@"image\teslim_al1.png");
            kiralama_islemleri_arama_pb.Image = Image.FromFile(@"image\kiralama_islemleri_arama1.png");
            kiralama_islemleri_pb.Image = Image.FromFile(@"image\kiralama_islemleri1.png");
            kiralama_bilgileri_duzenle_pb.Image = Image.FromFile(@"image\kiralama_islemleri_duzenle1.png");
            kiralama_islemleri_iptal_et_pb.Image = Image.FromFile(@"image\kiralama_islemleri_iptal_et1.png");

            musteri_arsiv_pb.Image = Image.FromFile(@"image\musteri_arsiv1.png");
            arac_arsivi_pb.Image = Image.FromFile(@"image\arac_arsiv1.png");
            kiralama_arsivi_pb.Image = Image.FromFile(@"image\kiralama_arsiv1.png");
            istatistik_pb.Image = Image.FromFile(@"image\istatistik1.png");
            program_detaylari_pb.Image = Image.FromFile(@"image\program_hakkinda_bilgi1.png");

            takvim_pb.Image = Image.FromFile(@"image\tarih.png");
            saat_pb.Image = Image.FromFile(@"image\saat.png");
            hesap_makinesini_ac_pb.Image = Image.FromFile(@"image\hesap_makinesi1.png");
            iki_tarih_arasi_pb.Image = Image.FromFile(@"image\tarih_araligi1.png");
            //FOTOĞRAFLARIN KUTULARA SIĞDIRIRDIĞI YER
           iki_tarih_arasi_pb.SizeMode= hesap_makinesini_ac_pb.SizeMode=takvim_pb.SizeMode = saat_pb.SizeMode = musteri_arsiv_pb.SizeMode = arac_arsivi_pb.SizeMode = kiralama_arsivi_pb.SizeMode = istatistik_pb.SizeMode = program_detaylari_pb.SizeMode = arac_arama_pb.SizeMode = arac_ekle_pb.SizeMode = arac_duzenle_pb.SizeMode = arac_cikar_pb.SizeMode = arac_listesi_pb.SizeMode = musteri_arama_pb.SizeMode = musteri_ekle_pb.SizeMode = musteri_duzenleme_pb.SizeMode = musteri_cikar_pb.SizeMode = musteri_listesi_pb.SizeMode = teslim_al_pb.SizeMode = kiralama_islemleri_arama_pb.SizeMode = kiralama_islemleri_pb.SizeMode = kiralama_bilgileri_duzenle_pb.SizeMode = kiralama_islemleri_iptal_et_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        bool calissinmi = false;
        private void kisitlamalar_ve_duzenlemeler()
        {
            tarih_saat_surekli_goster.Interval = 1000;//ZAMANLAYICIYI(TİMER) HER 1 SANİYEDE 1 ÇALIŞMASI İÇİN GEREKLİ
            zaman_islemleri();//TİMER ÇALIŞIP ÇALIŞMAMA DURUMU FOKSİYONU
        }
        
        private void zaman_islemleri()
        {
            if (calissinmi==true)//DOĞRU İSE
            {
                tarih_saat_surekli_goster.Start();//TİMER BAŞLATILIR
            }
            else//YANLIŞ İSE
            {
                tarih_saat_surekli_goster.Stop();//TİMER DURDURULUR
            }

        }
        private void musteri_arac_getir()
        {
            try
            {
                veriseti.Clear();//TEMİZLEME
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                Komutlar = new SqlDataAdapter("select kiralama_tarihi,fiyat,tcno,ad,soyad,cep1,cep2,eposta,ehliyet_no,ehliyet_turu,plaka,marka,model,kategori,kira_ucreti from kiralama_tablosu inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id inner join arac_tablosu on kiralama_tablosu.arac_id=arac_tablosu.arac_id where kiralama_tablosu.arsiv=1",baglanti);//KİRALAYAN MÜŞTERİ KİRALANAN ARAÇLARI GETİREN KOMUT
                Komutlar.Fill(veriseti, "kiralama_tablosu");//GETİRİLEN TABLOYU KAYDEDEN DEĞİŞKEN 
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                tablolari_listele_dgv.DataSource = veriseti.Tables["kiralama_tablosu"];//KAYDEDILEN DEĞİŞKENİ LİSTEYE AKTARMA

            }
            catch (Exception)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
        }
        private void musteri_arac_getir_sonrasi_duzenle()
        {
            tablolari_listele_dgv.Columns["tcno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["soyad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["cep1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//Columns["model"].HeaderText = "MODEL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["cep2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["eposta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ehliyet_no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ehliyet_turu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["plaka"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["marka"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["kategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["kira_ucreti"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["kiralama_tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["fiyat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ

            tablolari_listele_dgv.Columns["tcno"].HeaderText = "TC NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ad"].HeaderText = "AD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞ
            tablolari_listele_dgv.Columns["soyad"].HeaderText = "SOYAD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["cep1"].HeaderText = "CEP TELEFONU(1)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["cep2"].HeaderText = "CEP TELEFONU(2)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["eposta"].HeaderText = "E-POSTA ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ehliyet_no"].HeaderText = "EHLİYET NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ehliyet_turu"].HeaderText = "EHLİYET TÜRÜ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["plaka"].HeaderText = "PLAKA NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["marka"].HeaderText = "MARKA";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["model"].HeaderText = "MODEL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["kategori"].HeaderText = "KATEGORİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["kira_ucreti"].HeaderText = "KİRA ÜCRETİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["kiralama_tarihi"].HeaderText = "KİRALAMA TARİHİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["fiyat"].HeaderText = "ÜCRET";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
        }

        private void arac_arama_pb_MouseMove(object sender, MouseEventArgs e)
        {
            arac_arama_pb.Image = Image.FromFile(@"image\arac_arama2.png");//RESİMLER İLE GÖRSEL EFEKT 
            arac_arama_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR//YAZI RENGİNİ KIRMIZI YAPAR
            arac_arama_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void arac_arama_pb_MouseLeave(object sender, EventArgs e)
        {
            arac_arama_pb.Image = Image.FromFile(@"image\arac_arama1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA//GÖRSEL EFEKTI VARSAYILAN YAPMA
            arac_arama_label.ForeColor = arac_arama_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void arac_arama_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(arac_arama_label.Text)==true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                arac_arama arac_arama_penceresi = new arac_arama();
                arac_arama_penceresi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            }
        }

        private void arac_ekle_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(arac_ekle_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                arac_ekle arac_ekle_penceresi = new arac_ekle();
                arac_ekle_penceresi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            }
            
        }

        private void arac_ekle_pb_MouseMove(object sender, MouseEventArgs e)
        {
            arac_ekle_pb.Image = Image.FromFile(@"image\arac_ekle2.png");//RESİMLER İLE GÖRSEL EFEKT 
            arac_ekle_label.ForeColor = arac_ekle_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void arac_ekle_pb_MouseLeave(object sender, EventArgs e)
        {
            arac_ekle_pb.Image = Image.FromFile(@"image\arac_ekle1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            arac_ekle_label.ForeColor = arac_ekle_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void arac_duzenle_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(arac_duzenle_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                arac_duzenle arac_duzenleme_penceresi = new arac_duzenle();
                arac_duzenleme_penceresi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            }
        }

        private void arac_duzenle_pb_MouseMove(object sender, MouseEventArgs e)
        {
            arac_duzenle_pb.Image = Image.FromFile(@"image\arac_duzenle2.png");//RESİMLER İLE GÖRSEL EFEKT 
            arac_duzenle_label.ForeColor = arac_duzenle_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void arac_duzenle_pb_MouseLeave(object sender, EventArgs e)
        {
            arac_duzenle_pb.Image = Image.FromFile(@"image\arac_duzenle1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            arac_duzenle_label.ForeColor = arac_duzenle_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void arac_cikar_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(arac_cikar_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                arac_cikar arac_cikar_penceresi = new arac_cikar();
                arac_cikar_penceresi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            }
        }

        private void arac_cikar_pb_MouseMove(object sender, MouseEventArgs e)
        {
            arac_cikar_pb.Image = Image.FromFile(@"image\arac_cikar2.png");//RESİMLER İLE GÖRSEL EFEKT 
            arac_cikar_label.ForeColor = arac_cikar_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void arac_cikar_pb_MouseLeave(object sender, EventArgs e)
        {
            arac_cikar_pb.Image = Image.FromFile(@"image\arac_cikar1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            arac_cikar_label.ForeColor = arac_cikar_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }
        public static string hangi_tablo = "";
        private void arac_listesi_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(arac_listesi_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                hangi_tablo = "arac_tablosu";
                liste_formu arac_listesi = new liste_formu();
                arac_listesi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            }
        }

        private void arac_listesi_pb_MouseMove(object sender, MouseEventArgs e)
        {
            arac_listesi_pb.Image = Image.FromFile(@"image\arac_listesi2.png");//RESİMLER İLE GÖRSEL EFEKT 
            arac_listesi_label.ForeColor = arac_listesi_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void arac_listesi_pb_MouseLeave(object sender, EventArgs e)
        {
            arac_listesi_pb.Image = Image.FromFile(@"image\arac_listesi1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            arac_listesi_label.ForeColor = arac_listesi_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }
        private void datagridview_ayarlari()
        {
            if (arac_daralt_genislet_label.Text == ">" && kiralama_islemleri_daralt_genislet_label.Text == ">" && musteri_daralt_genislet_label.Text == "<" && arsiv_ist_p_detay_daralt_genislet_label.Text == "<")//HESPİ KAPALI MI
            {
                tablolari_listele_dgv.Location = new Point(148, 156);//KİRALAMA İŞLEMLERİNİ GÖSTEREN TABLONUN YENİ YERİ
                tablolari_listele_dgv.Width = 1074;//KİRALAMA İŞLEMLERİNİ GÖSTEREN TABLONUN YENİ BOYUTU
            }
            else if ((arac_daralt_genislet_label.Text == "<" || kiralama_islemleri_daralt_genislet_label.Text == "<") && musteri_daralt_genislet_label.Text == "<" && arsiv_ist_p_detay_daralt_genislet_label.Text == "<")//BAZİLARİ KAPALI MI
            {
                tablolari_listele_dgv.Location = new Point(422, 156);//KİRALAMA İŞLEMLERİNİ GÖSTEREN TABLONUN YENİ YERİ
                tablolari_listele_dgv.Width = 800;//KİRALAMA İŞLEMLERİNİ GÖSTEREN TABLONUN YENİ BOYUTU
            }
            else if (arac_daralt_genislet_label.Text == ">" && kiralama_islemleri_daralt_genislet_label.Text == ">" && (musteri_daralt_genislet_label.Text == ">" || arsiv_ist_p_detay_daralt_genislet_label.Text == ">"))//BAZİLARİ KAPALI MI
            {
                tablolari_listele_dgv.Location = new Point(148, 156);//KİRALAMA İŞLEMLERİNİ GÖSTEREN TABLONUN YENİ YERİ
                tablolari_listele_dgv.Width = 800;//KİRALAMA İŞLEMLERİNİ GÖSTEREN TABLONUN YENİ BOYUTU
            }
            else if (arac_daralt_genislet_label.Text == "<" || kiralama_islemleri_daralt_genislet_label.Text == "<" || musteri_daralt_genislet_label.Text == ">" || arsiv_ist_p_detay_daralt_genislet_label.Text == ">")//HESPİ AÇIK MI
            {
                tablolari_listele_dgv.Location = new Point(422, 156);//KİRALAMA İŞLEMLERİNİ GÖSTEREN TABLONUN YENİ YERİ
                tablolari_listele_dgv.Width = 526;//KİRALAMA İŞLEMLERİNİ GÖSTEREN TABLONUN YENİ BOYUTU
            }

            if (musteri_daralt_genislet_label.Text=="<")//SAĞDA BULUNAN MÜŞTERİ DARARTILMIŞ İSE TARİH SAATİ GRUBUNU GÖSTERİLİR
            {
                tarih_saat_gb.Visible = true;
            }
            else//SAĞDA BULUNAN MÜŞTERİ DARARTILMAMISSA İSE TARİH SAATİ GRUBUNU GÖSTERİLMEZ
            {
                tarih_saat_gb.Visible = false;
            }

            if (arac_daralt_genislet_label.Text == ">")//SOLDA KALAN ARAÇLAR DARARTILMIŞ İSE 
            {
                mesajlar_gb.Visible = true;//HESAPLAMA İŞLEMLERİ İÇİN GRUP GÖSTERİLİR
            }
            else
            {
                mesajlar_gb.Visible = false;//HESAPLAMA İŞLEMLERİ İÇİN GRUP GİZLENİR.
            }
        
        }
        private void label1_Click(object sender, EventArgs e)
        {//ARAÇLARIN DARARTILIP GENİŞLETME İŞLEMLERİ
            if (arac_daralt_genislet_label.Text == "<")//TIKLANDIĞINDA İŞARET DOĞRU İSE DARARTMA İŞLEMİ UYGULANIR
            {
                arac_islemleri_gb.Width = 93;//YENİ GENİŞLİK
                arac_islemleri_gb.Height = 344;//YENİ YÜKSEKLİK
                arac_islemleri_gb.Text = "A.İşlem";//PENCERE İSMİ
                arac_arama_label.Visible = arac_arama_bilgi_label.Visible = arac_ekle_label.Visible = arac_ekle_bilgi_label.Visible = arac_duzenle_label.Visible = arac_duzenle_bilgi_label.Visible = arac_cikar_label.Visible = arac_cikar_bilgi_label.Visible = arac_listesi_label.Visible = arac_listesi_bilgi_label.Visible = false;//LABEL GİZLEME (GÖRÜNTÜ BOZUKLUĞUNDAN)
                arac_daralt_genislet_label.Text = ">";//LABELİN ADINI DEĞİŞTİRME
                arac_daralt_genislet_label.Location = new Point(105, 190);//YENİ KONUMU
            }
            else if (arac_daralt_genislet_label.Text == ">")//TIKLANDIĞINDA İŞARET DOĞRU İSE DARARTMA İŞLEMİ UYGULANIR
            {
                arac_islemleri_gb.Width = 370;//VARSAYILAN GENİŞLİK
                arac_islemleri_gb.Height = 344;//VARSAYILAN YÜKSEKLİK
                arac_islemleri_gb.Text = "Araç İşlem Pencereleri";//PENCERE İSMİ VARSAYILAN
                arac_arama_label.Visible = arac_arama_bilgi_label.Visible = arac_ekle_label.Visible = arac_ekle_bilgi_label.Visible = arac_duzenle_label.Visible = arac_duzenle_bilgi_label.Visible = arac_cikar_label.Visible = arac_cikar_bilgi_label.Visible = arac_listesi_label.Visible = arac_listesi_bilgi_label.Visible = true;//LABEL GÖSTERME
                arac_daralt_genislet_label.Text = "<";//LABELİN ADINI DEĞİŞTİRME(VARSAYILAN)
                arac_daralt_genislet_label.Location = new Point(386, 190);//VARSAYILAN KONUMU
            }
            datagridview_ayarlari();//KİRALAMA TABLOSUNU BOYUTLARINI GÜNCELLEME FOKSİYONU
        }

        private void arac_darat_genislet_label_MouseMove(object sender, MouseEventArgs e)
        {
            if (arac_daralt_genislet_label.Text == "<")//ÜSTÜNE GELİNDİĞİNDE EFEKT OLUŞTURMA KOMUTLARI
            {
                arac_daralt_genislet_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
                arac_daralt_genislet_label.Location = new Point(382, 190);
            }
            else if (arac_daralt_genislet_label.Text == ">")//ÜSTÜNE GELİNDİĞİNDE EFEKT OLUŞTURMA KOMUTLARI
            {
                arac_daralt_genislet_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
                arac_daralt_genislet_label.Location = new Point(109, 190);
            }
        }

        private void arac_darat_genislet_label_MouseLeave(object sender, EventArgs e)
        {
            if (arac_daralt_genislet_label.Text == "<")//ÜSTÜNE GELİNDİĞİNDE EFEKT OLUŞTURMA KOMUTLARI
            {
                arac_daralt_genislet_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
                arac_daralt_genislet_label.Location = new Point(386, 190);
            }
            else if (arac_daralt_genislet_label.Text == ">")//ÜSTÜNE GELİNDİĞİNDE EFEKT OLUŞTURMA KOMUTLARI
            {
                arac_daralt_genislet_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
                arac_daralt_genislet_label.Location = new Point(105, 190);
            }

        }

        private void musteri_arama_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(musteri_arama_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                musteri_arama musteri_arama_penceresi = new musteri_arama();
                musteri_arama_penceresi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void musteri_arama_pb_MouseMove(object sender, MouseEventArgs e)
        {
            musteri_arama_pb.Image = Image.FromFile(@"image\musteri_arama2.png");//RESİMLER İLE GÖRSEL EFEKT 
            musteri_arama_label.ForeColor = musteri_arama_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void musteri_arama_pb_MouseLeave(object sender, EventArgs e)
        {
            musteri_arama_pb.Image = Image.FromFile(@"image\musteri_arama1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            musteri_arama_label.ForeColor = musteri_arama_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void musteri_ekle_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(musteri_ekle_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                musteri_ekle musteri_ekle_penceresi = new musteri_ekle();
                musteri_ekle_penceresi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void musteri_ekle_pb_MouseMove(object sender, MouseEventArgs e)
        {
            musteri_ekle_pb.Image = Image.FromFile(@"image\musteri_ekle2.png");//RESİMLER İLE GÖRSEL EFEKT 
            musteri_ekle_label.ForeColor = musteri_ekle_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void musteri_ekle_pb_MouseLeave(object sender, EventArgs e)
        {
            musteri_ekle_pb.Image = Image.FromFile(@"image\musteri_ekle1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            musteri_ekle_label.ForeColor = musteri_ekle_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void musteri_duzenleme_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(musteri_duzenleme_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                musteri_duzenle musteri_duzenle_pencere = new musteri_duzenle();
                musteri_duzenle_pencere.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void musteri_duzenleme_pb_MouseMove(object sender, MouseEventArgs e)
        {
            musteri_duzenleme_pb.Image = Image.FromFile(@"image\musteri_duzenle2.png");//RESİMLER İLE GÖRSEL EFEKT 
            musteri_duzenleme_label.ForeColor = musteri_duzenleme_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void musteri_duzenleme_pb_MouseLeave(object sender, EventArgs e)
        {
            musteri_duzenleme_pb.Image = Image.FromFile(@"image\musteri_duzenle1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            musteri_duzenleme_label.ForeColor = musteri_duzenleme_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void musteri_cikar_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(musteri_cikar_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                musteri_cikar musteri_cikarma_penceresi = new musteri_cikar();
                musteri_cikarma_penceresi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void musteri_cikar_pb_MouseMove(object sender, MouseEventArgs e)
        {
            musteri_cikar_pb.Image = Image.FromFile(@"image\musteri_cikar2.png");//RESİMLER İLE GÖRSEL EFEKT 
            musteri_cikar_label.ForeColor = musteri_cikar_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void musteri_cikar_pb_MouseLeave(object sender, EventArgs e)
        {
            musteri_cikar_pb.Image = Image.FromFile(@"image\musteri_cikar1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            musteri_cikar_label.ForeColor = musteri_cikar_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void musteri_listesi_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(musteri_listesi_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                hangi_tablo = "musteri_tablosu";
                liste_formu arac_listesi = new liste_formu();
                arac_listesi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void musteri_listesi_pb_MouseMove(object sender, MouseEventArgs e)
        {
            musteri_listesi_pb.Image = Image.FromFile(@"image\musteri_listesi2.png");//RESİMLER İLE GÖRSEL EFEKT 
            musteri_listesi_label.ForeColor = musteri_listesi_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void musteri_listesi_pb_MouseLeave(object sender, EventArgs e)
        {
            musteri_listesi_pb.Image = Image.FromFile(@"image\musteri_listesi1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            musteri_listesi_label.ForeColor = musteri_listesi_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void musteri_darart_label_Click(object sender, EventArgs e)
        {
            if (musteri_daralt_genislet_label.Text == ">")//İŞARET DOĞRU İSE ÇALIŞACAK 
            {
                musteri_islemleri_gb.Width = 93;//YENİ GENİŞLİK
                musteri_islemleri_gb.Height = 344;//YENİ YÜKSEKLİK
                musteri_islemleri_gb.Text = "M.İşlem";//YENİ AD
                musteri_islemleri_gb.Location = new Point(1265, 29); //YENİ KONUM
                musteri_arama_label.Visible = musteri_arama_bilgi_label.Visible = musteri_ekle_label.Visible = musteri_ekle_bilgi_label.Visible = musteri_duzenleme_label.Visible = musteri_duzenleme_bilgi_label.Visible = musteri_cikar_label.Visible = musteri_cikar_bilgi_label.Visible = musteri_listesi_label.Visible = musteri_listesi_bilgi_label.Visible = false;//LABEL GİZLEME
                musteri_daralt_genislet_label.Text = "<";//YENİ AD
                musteri_daralt_genislet_label.Location = new Point(1231, 190);//YENİ KONUM
                calissinmi = true;//TİMER İŞLEMLERİ
                zaman_islemleri();//TİMER ÇALIŞMA DURUMU
            }
            else if (musteri_daralt_genislet_label.Text == "<")//İŞARET DOĞRU İSE ÇALIŞACAK 
            {
                musteri_islemleri_gb.Width = 370;//VARSAYİLAN GENİŞLİK
                musteri_islemleri_gb.Height = 344;//VARSAYİLAN YÜKSEKLİK
                musteri_islemleri_gb.Text = "Müşteri İşlem Pencereleri";//VARSAYİLAN AD
                musteri_islemleri_gb.Location = new Point(988, 29);//VARSAYİLAN KONUM
                musteri_arama_label.Visible = musteri_arama_bilgi_label.Visible = musteri_ekle_label.Visible = musteri_ekle_bilgi_label.Visible = musteri_duzenleme_label.Visible = musteri_duzenleme_bilgi_label.Visible = musteri_cikar_label.Visible = musteri_cikar_bilgi_label.Visible = musteri_listesi_label.Visible = musteri_listesi_bilgi_label.Visible = true;//LABEL GÖSTERME
                musteri_daralt_genislet_label.Text = ">";//VARSAYİLAN AD
                musteri_daralt_genislet_label.Location = new Point(954, 190);//VARSAYİLAN KONUM
                calissinmi = false;//TİMER İŞLEMLERİ
                zaman_islemleri();//TİMER ÇALIŞMA DURUMU
            }
            datagridview_ayarlari();//KİRALAMA TABLOSU AYARLARI FOKSİYONU
        }

        private void musteri_daralt_genislet_label_MouseMove(object sender, MouseEventArgs e)
        {
            if (musteri_daralt_genislet_label.Text == ">")//İŞARET DOĞRU İSE ÜZERİNE GELDİĞİN EFEKT OLUŞTURUR
            {
                musteri_daralt_genislet_label.Location = new Point(958, 190);
                musteri_daralt_genislet_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
            }
            else if (musteri_daralt_genislet_label.Text == "<")//İŞARET DOĞRU İSE ÜZERİNE GELDİĞİN EFEKT OLUŞTURUR
            {
                musteri_daralt_genislet_label.Location = new Point(1227, 190);
                musteri_daralt_genislet_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
            }

        }

        private void musteri_daralt_genislet_label_MouseLeave(object sender, EventArgs e)
        {
            if (musteri_daralt_genislet_label.Text == ">")//İŞARET DOĞRU İSE ÜZERİNE GELDİĞİN EFEKT OLUŞTURUR
            {
                musteri_daralt_genislet_label.Location = new Point(954, 190);
                musteri_daralt_genislet_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
            }
            else if (musteri_daralt_genislet_label.Text == "<")//İŞARET DOĞRU İSE ÜZERİNE GELDİĞİN EFEKT OLUŞTURUR
            {
                musteri_daralt_genislet_label.Location = new Point(1231, 190);
                musteri_daralt_genislet_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
            }

        }
        public static bool tetikle;
        private void teslim_al_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(teslim_al_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                tetikle = true;
                kiralama_islemini_teslim_al_veya_iptal_et teslim_al_penceresi = new kiralama_islemini_teslim_al_veya_iptal_et();
                teslim_al_penceresi.ShowDialog();
                musteri_arac_getir();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            }
        }

        private void teslim_al_pb_MouseMove(object sender, MouseEventArgs e)
        {
            teslim_al_pb.Image = Image.FromFile(@"image\teslim_al2.png");//RESİMLER İLE GÖRSEL EFEKT 
            teslim_al_label.ForeColor = teslim_al_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void teslim_al_pb_MouseLeave(object sender, EventArgs e)
        {
            teslim_al_pb.Image = Image.FromFile(@"image\teslim_al1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            teslim_al_label.ForeColor = teslim_al_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void kiralama_islemleri_arama_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(kiralama_islemleri_arama_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                kiralama_islemleri_arama kiralama_islemleri_uzerinde_arama_yap = new kiralama_islemleri_arama();
                kiralama_islemleri_uzerinde_arama_yap.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            }
        }

        private void kiralama_islemleri_arama_pb_MouseMove(object sender, MouseEventArgs e)
        {
            kiralama_islemleri_arama_pb.Image = Image.FromFile(@"image\kiralama_islemleri_arama2.png");//RESİMLER İLE GÖRSEL EFEKT 
            kiralama_islemleri_arama_label.ForeColor = kiralama_islemleri_arama_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void kiralama_islemleri_arama_pb_MouseLeave(object sender, EventArgs e)
        {
            kiralama_islemleri_arama_pb.Image = Image.FromFile(@"image\kiralama_islemleri_arama1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            kiralama_islemleri_arama_label.ForeColor = kiralama_islemleri_arama_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void kiralama_islemleri_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(kiralama_islemleri_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                kiralama_islemleri kiralama_islemleri_penceresi = new kiralama_islemleri();
                kiralama_islemleri_penceresi.ShowDialog();
                musteri_arac_getir();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void kiralama_islemleri_pb_MouseMove(object sender, MouseEventArgs e)
        {
            kiralama_islemleri_pb.Image = Image.FromFile(@"image\kiralama_islemleri2.png");//RESİMLER İLE GÖRSEL EFEKT 
            kiralama_islemleri_label.ForeColor = kiralama_islemleri_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void kiralama_islemleri_pb_MouseLeave(object sender, EventArgs e)
        {
            kiralama_islemleri_pb.Image = Image.FromFile(@"image\kiralama_islemleri1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            kiralama_islemleri_label.ForeColor = kiralama_islemleri_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void kiralama_bilgileri_duzenle_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(kiralama_bilgilerini_duzenle_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                kiralama_islemleri_duzenle kiralama_bilgilerini_duzenle_penceresi = new kiralama_islemleri_duzenle();
                kiralama_bilgilerini_duzenle_penceresi.ShowDialog();
                musteri_arac_getir();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void kiralama_bilgileri_duzenle_pb_MouseMove(object sender, MouseEventArgs e)
        {
            kiralama_bilgileri_duzenle_pb.Image = Image.FromFile(@"image\kiralama_islemleri_duzenle2.png");//RESİMLER İLE GÖRSEL EFEKT 
            kiralama_bilgilerini_duzenle_label.ForeColor = kiralama_bilgilerini_duzenle_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void kiralama_bilgileri_duzenle_pb_MouseLeave(object sender, EventArgs e)
        {
            kiralama_bilgileri_duzenle_pb.Image = Image.FromFile(@"image\kiralama_islemleri_duzenle1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            kiralama_bilgilerini_duzenle_label.ForeColor = kiralama_bilgilerini_duzenle_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void kiralama_islemleri_iptal_et_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(kiralama_iptal_et_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                tetikle = false;
                kiralama_islemini_teslim_al_veya_iptal_et kiralama_iptal_penceresi = new kiralama_islemini_teslim_al_veya_iptal_et();
                kiralama_iptal_penceresi.ShowDialog();
                musteri_arac_getir();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void kiralama_islemleri_iptal_et_pb_MouseMove(object sender, MouseEventArgs e)
        {
            kiralama_islemleri_iptal_et_pb.Image = Image.FromFile(@"image\kiralama_islemleri_iptal_et2.png");//RESİMLER İLE GÖRSEL EFEKT 
            kiralama_iptal_et_label.ForeColor = kiralama_iptal_et_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void kiralama_islemleri_iptal_et_pb_MouseLeave(object sender, EventArgs e)
        {
            kiralama_islemleri_iptal_et_pb.Image = Image.FromFile(@"image\kiralama_islemleri_iptal_et1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            kiralama_iptal_et_label.ForeColor = kiralama_iptal_et_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void kiralama_islemleri_daralt_genislet_label_Click(object sender, EventArgs e)
        {
            if (kiralama_islemleri_daralt_genislet_label.Text == "<")//TIKLANDIĞINDA İŞARET DOĞRU İSE DARARTMA İŞLEMİ UYGULANIR
            {
                kiralama_islemleri_gb.Width = 93;//YENİ GENİŞLİK
                kiralama_islemleri_gb.Height = 344;//YENİ YÜKSEKLİK
                kiralama_islemleri_gb.Text = "K.İşlem";//YENİ AD
                teslim_al_label.Visible = teslim_al_bilgi_label.Visible = kiralama_islemleri_arama_label.Visible = kiralama_islemleri_arama_bilgi_label.Visible = kiralama_islemleri_label.Visible = kiralama_islemleri_bilgi_label.Visible = kiralama_bilgilerini_duzenle_label.Visible = kiralama_bilgilerini_duzenle_bilgi_label.Visible = kiralama_iptal_et_label.Visible = kiralama_iptal_et_bilgi_label.Visible = false;//LABEL GİZLEME
                kiralama_islemleri_daralt_genislet_label.Text = ">";//YENİ AD
                kiralama_islemleri_daralt_genislet_label.Location = new Point(105, 540); //YENİ KONUM
            }
            else if (kiralama_islemleri_daralt_genislet_label.Text == ">")//TIKLANDIĞINDA İŞARET DOĞRU İSE DARARTMA İŞLEMİ UYGULANIR
            {
                kiralama_islemleri_gb.Width = 370;//VARSAYILAN GENİŞLİK
                kiralama_islemleri_gb.Height = 344;//VARSAYILAN YÜKSEKLİK
                kiralama_islemleri_gb.Text = "Kiralama İşlem Pencereleri"; //VARSAYILAN AD
                teslim_al_label.Visible = teslim_al_bilgi_label.Visible = kiralama_islemleri_arama_label.Visible = kiralama_islemleri_arama_bilgi_label.Visible = kiralama_islemleri_label.Visible = kiralama_islemleri_bilgi_label.Visible = kiralama_bilgilerini_duzenle_label.Visible = kiralama_bilgilerini_duzenle_bilgi_label.Visible = kiralama_iptal_et_label.Visible = kiralama_iptal_et_bilgi_label.Visible = true;//LABEL GÖSTERME
                kiralama_islemleri_daralt_genislet_label.Text = "<";//VARSAYILAN AD
                kiralama_islemleri_daralt_genislet_label.Location = new Point(386, 540); //VARSAYILAN KONUM
            }
            datagridview_ayarlari();//KİRALAMA TABLOSU GÖRSELLERİNİ DÜZENLEME 
        }

        private void kiralama_islemleri_daralt_genislet_label_MouseMove(object sender, MouseEventArgs e)
        {
            if (kiralama_islemleri_daralt_genislet_label.Text == "<")//İŞARETİN ÜSTÜNE GELİNDİĞİNDE EFEKT OLUŞTURMA
            {
                kiralama_islemleri_daralt_genislet_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
                kiralama_islemleri_daralt_genislet_label.Location = new Point(382, 540);
            }
            else if (kiralama_islemleri_daralt_genislet_label.Text == ">")//İŞARETİN ÜSTÜNE GELİNDİĞİNDE EFEKT OLUŞTURMA
            {

                kiralama_islemleri_daralt_genislet_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
                kiralama_islemleri_daralt_genislet_label.Location = new Point(109, 540);
            }
        }

        private void kiralama_islemleri_daralt_genislet_label_MouseLeave(object sender, EventArgs e)
        {
            if (kiralama_islemleri_daralt_genislet_label.Text == "<")//İŞARETİN ÜSTÜNE GELİNDİĞİNDE EFEKT OLUŞTURMA
            {
                kiralama_islemleri_daralt_genislet_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
                kiralama_islemleri_daralt_genislet_label.Location = new Point(386, 540);
            }
            else if (kiralama_islemleri_daralt_genislet_label.Text == ">")//İŞARETİN ÜSTÜNE GELİNDİĞİNDE EFEKT OLUŞTURMA
            {
                kiralama_islemleri_daralt_genislet_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
                kiralama_islemleri_daralt_genislet_label.Location = new Point(105, 540);
            }
        }
        public static string hangi_arsiv_listesi="";
        private void musteri_arsiv_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(musteri_arsiv_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                hangi_arsiv_listesi = "musteri_tablosu";
                arsiv_liste_formu musteri_arsiv_penceresi = new arsiv_liste_formu();
                musteri_arsiv_penceresi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void musteri_arsiv_pb_MouseMove(object sender, MouseEventArgs e)
        {
            musteri_arsiv_pb.Image = Image.FromFile(@"image\musteri_arsiv2.png");//RESİMLER İLE GÖRSEL EFEKT 
            musteri_arsiv_label.ForeColor = musteri_arsiv_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void musteri_arsiv_pb_MouseLeave(object sender, EventArgs e)
        {
            musteri_arsiv_pb.Image = Image.FromFile(@"image\musteri_arsiv1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            musteri_arsiv_label.ForeColor = musteri_arsiv_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void arac_arsivi_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(arac_arama_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                hangi_arsiv_listesi = "arac_tablosu";
                arsiv_liste_formu arac_arsiv_penceresi = new arsiv_liste_formu();
                arac_arsiv_penceresi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void arac_arsivi_pb_MouseMove(object sender, MouseEventArgs e)
        {
            arac_arsivi_pb.Image = Image.FromFile(@"image\arac_arsiv2.png");//RESİMLER İLE GÖRSEL EFEKT 
            arac_arsivi_label.ForeColor = arac_arsivi_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void arac_arsivi_pb_MouseLeave(object sender, EventArgs e)
        {
            arac_arsivi_pb.Image = Image.FromFile(@"image\arac_arsiv1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            arac_arsivi_label.ForeColor = arac_arsivi_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void kiralama_arsivi_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(kiralama_arsivi_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                hangi_arsiv_listesi = "kiralama_tablosu";
                arsiv_liste_formu kiralama_arsiv_penceresi = new arsiv_liste_formu();
                kiralama_arsiv_penceresi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void kiralama_arsivi_pb_MouseMove(object sender, MouseEventArgs e)
        {
            kiralama_arsivi_pb.Image = Image.FromFile(@"image\kiralama_arsiv2.png");//RESİMLER İLE GÖRSEL EFEKT 
            kiralama_arsivi_label.ForeColor = kiralama_arsivi_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void kiralama_arsivi_pb_MouseLeave(object sender, EventArgs e)
        {
            kiralama_arsivi_pb.Image = Image.FromFile(@"image\kiralama_arsiv1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            kiralama_arsivi_label.ForeColor = kiralama_arsivi_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void istatistik_pb_Click(object sender, EventArgs e)
        {
            if (yetki_kontrolu(istatistik_label.Text) == true)//EĞER YETKİ VARSA TIKLANILAN PENCEREYI AÇAR
            {
                istatistik istatistik_penceresi = new istatistik();
                istatistik_penceresi.ShowDialog();
            }
            else
            {
                MessageBox.Show("YETKİNİZ BULUNMAMAKTADIR...", "YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//YETKİ YOKSA UYARI VERİR.
            } 
        }

        private void istatistik_pb_MouseMove(object sender, MouseEventArgs e)
        {
            istatistik_pb.Image = Image.FromFile(@"image\istatistik2.png");//RESİMLER İLE GÖRSEL EFEKT 
            istatistik_label.ForeColor = istatistik_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void istatistik_pb_MouseLeave(object sender, EventArgs e)
        {
            istatistik_pb.Image = Image.FromFile(@"image\istatistik1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            istatistik_label.ForeColor = istatistik_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void program_detaylari_pb_Click(object sender, EventArgs e)
        {
            program_detaylari program_detaylari_penceresi = new program_detaylari();
            program_detaylari_penceresi.ShowDialog();//PENCERE AÇMA KOMUTU
        }

        private void program_detaylari_pb_MouseMove(object sender, MouseEventArgs e)
        {
            program_detaylari_pb.Image = Image.FromFile(@"image\program_hakkinda_bilgi2.png");//RESİMLER İLE GÖRSEL EFEKT 
            program_detaylari_label.ForeColor = program_detaylari_bilgi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void program_detaylari_pb_MouseLeave(object sender, EventArgs e)
        {
            program_detaylari_pb.Image = Image.FromFile(@"image\program_hakkinda_bilgi1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
            program_detaylari_label.ForeColor = program_detaylari_bilgi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void arsiv_ist_p_detay_daralt_genislet_label_Click(object sender, EventArgs e)
        {
            if (arsiv_ist_p_detay_daralt_genislet_label.Text == ">")//İŞARET DOĞRU İSE ÇALIŞIR
            {
                arsiv_ve_istatiktikler_gb.Width = 93;//YENİ GENİŞLİK
                arsiv_ve_istatiktikler_gb.Height = 344;//YENİ YÜKSEKLİK
                arsiv_ve_istatiktikler_gb.Text = "AİPDP";//YENİ AD
                arsiv_ve_istatiktikler_gb.Location = new Point(1265, 379);//YENİ KONUM
                musteri_arsiv_label.Visible = musteri_arsiv_bilgi_label.Visible = arac_arsivi_label.Visible = arac_arsivi_bilgi_label.Visible = kiralama_arsivi_label.Visible = kiralama_arsivi_bilgi_label.Visible = istatistik_label.Visible = istatistik_bilgi_label.Visible = program_detaylari_label.Visible = program_detaylari_bilgi_label.Visible = false;//LABEL GİZLEME
                arsiv_ist_p_detay_daralt_genislet_label.Text = "<";//YENİ AD
                arsiv_ist_p_detay_daralt_genislet_label.Location = new Point(1231, 540); //YENİ KONUM
            }
            else if (arsiv_ist_p_detay_daralt_genislet_label.Text == "<")//İŞARET DOĞRU İSE ÇALIŞIR
            {
                arsiv_ve_istatiktikler_gb.Width = 370;//VARSAYİLAN GENİŞLİK
                arsiv_ve_istatiktikler_gb.Height = 344;//VARSAYİLAN YÜKSEKLİK
                arsiv_ve_istatiktikler_gb.Text = "Arşivler,İstatiktik ve Program Detayları Pencereleri";//VARSAYİLAN AD
                arsiv_ve_istatiktikler_gb.Location = new Point(988, 379); //VARSAYİLAN KONUM
                musteri_arsiv_label.Visible = musteri_arsiv_bilgi_label.Visible = arac_arsivi_label.Visible = arac_arsivi_bilgi_label.Visible = kiralama_arsivi_label.Visible = kiralama_arsivi_bilgi_label.Visible = istatistik_label.Visible = istatistik_bilgi_label.Visible = program_detaylari_label.Visible = program_detaylari_bilgi_label.Visible = true;//LABEL GÖSTERME
                arsiv_ist_p_detay_daralt_genislet_label.Text = ">";//VARSAYİLAN AD
                arsiv_ist_p_detay_daralt_genislet_label.Location = new Point(954, 540);//VARSAYİLAN KONUM
            }
            datagridview_ayarlari();//KİRALAMA TABLOSUNUN AYARLARI FOKSİYON
        }

        private void arsiv_ist_p_detay_daralt_genislet_label_MouseMove(object sender, MouseEventArgs e)
        {
            if (arsiv_ist_p_detay_daralt_genislet_label.Text == ">")//İŞARET ÜZERİNE GELDİĞİNDE EFEKT OLUŞTURUR
            {
                arsiv_ist_p_detay_daralt_genislet_label.Location = new Point(958, 540);
                arsiv_ist_p_detay_daralt_genislet_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
            }
            else if (arsiv_ist_p_detay_daralt_genislet_label.Text == "<")//İŞARET ÜZERİNE GELDİĞİNDE EFEKT OLUŞTURUR
            {
                arsiv_ist_p_detay_daralt_genislet_label.Location = new Point(1227, 540);
                arsiv_ist_p_detay_daralt_genislet_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
            }
        }

        private void arsiv_ist_p_detay_daralt_genislet_label_MouseLeave(object sender, EventArgs e)
        {
            if (arsiv_ist_p_detay_daralt_genislet_label.Text == ">")//İŞARET ÜZERİNE GELDİĞİNDE EFEKT OLUŞTURUR
            {
                arsiv_ist_p_detay_daralt_genislet_label.Location = new Point(954, 540);
                arsiv_ist_p_detay_daralt_genislet_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
            }
            else if (arsiv_ist_p_detay_daralt_genislet_label.Text == "<")//İŞARET ÜZERİNE GELDİĞİNDE EFEKT OLUŞTURUR
            {
                arsiv_ist_p_detay_daralt_genislet_label.Location = new Point(1231, 540);
                arsiv_ist_p_detay_daralt_genislet_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
            }
        }

        private void profil_degistir_label_Click(object sender, EventArgs e)
        {
            profil_bilgilerini_degistir profil_duzenleme_penceresi = new profil_bilgilerini_degistir();
            profil_duzenleme_penceresi.ShowDialog();
        }

        private void profil_degistir_label_MouseMove(object sender, MouseEventArgs e)
        {
            profil_degistir_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void profil_degistir_label_MouseLeave(object sender, EventArgs e)
        {
            profil_degistir_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void guvenlik_sorulari_label_Click(object sender, EventArgs e)
        {
            hesap_guvenlik hesap_guvenlik_penceresi = new hesap_guvenlik();
            hesap_guvenlik_penceresi.ShowDialog();
        }

        private void guvenlik_sorulari_label_MouseMove(object sender, MouseEventArgs e)
        {
            guvenlik_sorulari_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void guvenlik_sorulari_label_MouseLeave(object sender, EventArgs e)
        {
            guvenlik_sorulari_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void ozellestir_label_Click(object sender, EventArgs e)
        {
            ozellestir ozellestir_penceresi = new ozellestir();
            ozellestir_penceresi.ShowDialog();
        }

        private void ozellestir_label_MouseMove(object sender, MouseEventArgs e)
        {
            ozellestir_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void ozellestir_label_MouseLeave(object sender, EventArgs e)
        {
            ozellestir_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void yardim_label_Click(object sender, EventArgs e)
        {
            //pencere açma
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }

        private void yardim_label_MouseMove(object sender, MouseEventArgs e)
        {
            yardim_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void yardim_label_MouseLeave(object sender, EventArgs e)
        {
            yardim_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void oturum_kapat_label_Click(object sender, EventArgs e)
        {
            giris_penceresi oturumu_kapat = new giris_penceresi();//GİRİŞ PENCERESİNİ KONUMLANDIRMA
            oturumu_kapat.Show();//GİRİŞ PENCERESİNİ AÇMA
            this.Hide();//BU PENCREYİ GİZLEME
            //SONUÇ:OTURUM KAPATMA
        }

        private void oturum_kapat_label_MouseMove(object sender, MouseEventArgs e)
        {
            oturum_kapat_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void oturum_kapat_label_MouseLeave(object sender, EventArgs e)
        {
            oturum_kapat_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }

        private void ana_pencere_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();//PROGRAMI KAPATMA
        }

        private void parola_yenile_label_Click(object sender, EventArgs e)
        {
            parola_yenile parola_yenile_penceresi = new parola_yenile();
            parola_yenile_penceresi.ShowDialog();//PENCERE AÇMA
        }

        private void parola_yenile_label_MouseMove(object sender, MouseEventArgs e)
        {
            parola_yenile_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
        }

        private void parola_yenile_label_MouseLeave(object sender, EventArgs e)
        {
            parola_yenile_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
        }
        private void tarih_saat_surekli_goster_Tick(object sender, EventArgs e)
        {//TİMER İŞLEMLERİ
            tarih_bilgisi_label.Text = DateTime.Today.ToString("dddd, dd MMMM yyyy");//ÇALIŞTIĞINDA TARİH Hİ GÖSTERİR BİÇİM:GÜN AD,GÜN SAYI AY AD YIL SAYI
            saat_bilgisi_label.Text = DateTime.Now.ToString("HH:mm:ss");//ZAMAN GÖSTERMİ SAAT,DK,SANİYE
        }

        private void hesap_makinesini_ac_label_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");//WİN HESAP MAK. AÇAR
        }

        private void hesap_makinesini_ac_label_MouseMove(object sender, MouseEventArgs e)
        {
            hesap_makinesini_ac_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
            hesap_makinesini_ac_pb.Image = Image.FromFile(@"image\hesap_makinesi2.png");//RESİMLER İLE GÖRSEL EFEKT 
        }

        private void hesap_makinesini_ac_label_MouseLeave(object sender, EventArgs e)
        {
            hesap_makinesini_ac_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
            hesap_makinesini_ac_pb.Image = Image.FromFile(@"image\hesap_makinesi1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
        }

        private void sayfaya_yonelt_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("WEB SİTESİNE YÖNLENDİRME YAPILSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//CEVAP EVET İSE
            {
                System.Diagnostics.Process.Start("https://www.hesaplama.net/");//BROWSERDAN WEB SAYFASINA YÖNLENDİRİLİR
            }
        }

        private void iki_tarih_arasi_label_Click(object sender, EventArgs e)
        {
            iki_tarih_arasi_hesaplama iki_tarih_arasi_hesaplama_pencere = new iki_tarih_arasi_hesaplama();
            iki_tarih_arasi_hesaplama_pencere.ShowDialog();//PENCERE AÇAR
        }

        private void iki_tarih_arasi_label_MouseMove(object sender, MouseEventArgs e)
        {
            iki_tarih_arasi_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
            iki_tarih_arasi_pb.Image = Image.FromFile(@"image\tarih_araligi2.png");//RESİMLER İLE GÖRSEL EFEKT 
        }

        private void iki_tarih_arasi_label_MouseLeave(object sender, EventArgs e)
        {
            iki_tarih_arasi_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
            iki_tarih_arasi_pb.Image = Image.FromFile(@"image\tarih_araligi1.png");//GÖRSEL EFEKTI VARSAYILAN YAPMA
        }

        private void ad_soyad_label_Click(object sender, EventArgs e)
        {
            if (ad_soyad_label.Cursor==Cursors.Hand)//GİREN KİŞİ YÖNETİCİ İSE
            {
                admin_penceresi adminim = new admin_penceresi();
                adminim.ShowDialog();//YÖNETİCİ PENCERESİNİ AÇAR
            }
        }

        private void ad_soyad_label_MouseMove(object sender, MouseEventArgs e)
        {
            if (ad_soyad_label.Cursor == Cursors.Hand)//YÖNETİCİ İÇİN
            {
                ad_soyad_label.ForeColor = Color.Red;//YAZI RENGİNİ KIRMIZI YAPAR
            }
        }

        private void ad_soyad_label_MouseLeave(object sender, EventArgs e)
        {
            if (ad_soyad_label.Cursor == Cursors.Hand)//YÖNETİCİ İÇİN
            {
                ad_soyad_label.ForeColor = yazi_rengi;//YAZI RENGİNİ VARSAYILAN YAPMA.
            }
        }

        private void yetkilerimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //KULLANICIYA YETKİLERİNİ GÖSTERME İŞLEMLERİ
            string yetkileri_goster = "YETKİLERİNİZ:";
            foreach (string yetki_listesi in yetkiler)
            {
                yetkileri_goster += "\n" + yetki_listesi;
            }
            MessageBox.Show(yetkileri_goster,"YETKİLER",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void sayfaya_yonelt_linklabel_LinkClicked(object sender, EventArgs e)
        {
            if (MessageBox.Show("WEB SİTESİNE YÖNLENDİRME YAPILSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//CEVAP EVET İSE
            {
                System.Diagnostics.Process.Start("https://www.hesaplama.net/");//BROWSERDAN FARKLI PENCEREYE YÖNLENDİRİLİR
            }
        }
        private void cikis_yap_menu(object sender, EventArgs e)
        {
            if (MessageBox.Show("ÇIKIŞ YAPILSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//PENCERE KAPATILSIN MI 'EVET' İSE KAPATIYOR//PENCERE KAPATILSIN MI 'EVET' İSE KAPATIYOR
            {
                Application.Exit();//PROGRAM KAPATILIR
            }
        }

        private void ogretici_menu_Click(object sender, EventArgs e)
        {
            ogretici ogretici_penceresi = new ogretici();
            ogretici_penceresi.ShowDialog();//YENİ PENCERE AÇILIR
        }

        private void yardim_al_menu_Click(object sender, EventArgs e)
        {
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();//YENİ PENCERE AÇILIR
        }
    }
}
