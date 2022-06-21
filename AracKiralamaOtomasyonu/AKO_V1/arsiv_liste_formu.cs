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
    public partial class arsiv_liste_formu : Form
    {
        public arsiv_liste_formu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlDataAdapter Komutlar;//TABLOLARIN ÇEKİLMESİNDE KULLANILAN KOMUT
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        DataSet veriseti = new DataSet();//ÇEKİLEN TABLOLARI SAKLAMAK İÇİN GEREK KOMUT
        private void arsiv_liste_formu_Load(object sender, EventArgs e)
        {
            hangi_arsiv();//ARŞİV AÇILIRKEN HANGİ TABLO ÇEKİLECEĞİ FOKSİYON
            arsivin_gosterilme_bicimi();//SEÇİLEN TABLOYA GÖRE DÜZENLEME FOKSİYONU
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void hangi_arsiv()
        {
            try
            {
                veriseti.Clear();//TABLOLARI SİLER //FARKLI TABLO GELECEK VEYA GÜNCELLEME İŞLEMİ YAPILACAK İSE SİLİNİR
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                if (ana_pencere.hangi_arsiv_listesi.ToString() == "musteri_tablosu")//İSTENİLEN ARŞİV İSE GİRİŞ YAPILIR VE KOMUTLAR YAZILIR
                {
                    Komutlar = new SqlDataAdapter("select tcno,ad,soyad,case cinsiyet when 1 then 'Erkek' when 0 then 'Kadın'end as 'cinsiyet_guncellemesi',il,ilce,cep1,cep2,eposta,adres,ehliyet_no,ehliyet_turu,ehliyet_tarihi,aciklama from musteri_tablosu where arsiv=0", baglanti);
                }
                else if (ana_pencere.hangi_arsiv_listesi.ToString() == "kiralama_tablosu")//İSTENİLEN ARŞİV İSE GİRİŞ YAPILIR VE KOMUTLAR YAZILIR
                {
                    Komutlar = new SqlDataAdapter("select kiralama_tarihi,geri_alis_tarihi,odeme_turu,fiyat,kiralama_tablosu.aciklama,CASE teslim_alis_durumu WHEN 1 THEN 'Teslim Alındı' WHEN 0 THEN 'İptal Edildi' end as 'cikis_durumu',tcno,ad,soyad,cep1,cep2,eposta,ehliyet_no,ehliyet_turu,plaka,marka,model,kategori,kira_ucreti from kiralama_tablosu inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id inner join arac_tablosu on kiralama_tablosu.arac_id=arac_tablosu.arac_id where kiralama_tablosu.arsiv=0", baglanti);
                }
                else if (ana_pencere.hangi_arsiv_listesi.ToString() == "personel_tablosu")//İSTENİLEN ARŞİV İSE GİRİŞ YAPILIR VE KOMUTLAR YAZILIR
                {
                    Komutlar = new SqlDataAdapter("select tcno,ad,soyad,case cinsiyet when 1 then 'Erkek' when 0 then 'Kadın'end as 'cinsiyet_guncellemesi',il,ilce,dogum_yeri,dogum_tarihi,cep_telefonu,ev_telefonu,eposta,ev_adresi from personel_tablosu where arsiv=0 and gorevno=2", baglanti);
                }
                else if (ana_pencere.hangi_arsiv_listesi.ToString() == "arac_tablosu")//İSTENİLEN ARŞİV İSE GİRİŞ YAPILIR VE KOMUTLAR YAZILIR
                {
                    Komutlar = new SqlDataAdapter("select *,CASE hasar WHEN 0 THEN 'Kaza Yok'WHEN 1 THEN 'Kaza Var' END AS kaza_durumu from arac_tablosu where arsiv=0", baglanti);
                }
                else
                {
                    Komutlar = new SqlDataAdapter("select * from " + ana_pencere.hangi_arsiv_listesi.ToString() + " where arsiv=0", baglanti);//TABLO BULUNAMADI İSE GİRİŞ YAPILIR VE KOMUTLAR YAZILIR
                }
                Komutlar.Fill(veriseti, ana_pencere.hangi_arsiv_listesi.ToString());//SEÇİLEN TABLOYU İŞLER
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                arsivleri_listele.DataSource = veriseti.Tables[ana_pencere.hangi_arsiv_listesi.ToString()];//TABLOYU PENCEREDE GÖSTERİR.

            }
            catch (Exception)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
        }
        private void arsivin_gosterilme_bicimi()
        {
            if (ana_pencere.hangi_arsiv_listesi.ToString() == "musteri_tablosu")//TABLOYA GÖRE ALAN ADLARI VE BOYUTLANDIRMA İŞLEMLERİ
            {
                this.Text = "MÜŞTERİ ARŞİV LİSTESİ";
                arsivleri_listele.Columns["tcno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["soyad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["il"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ilce"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["cep1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["cep2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["eposta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["adres"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ehliyet_no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ehliyet_turu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ehliyet_tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["aciklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;


                arsivleri_listele.Columns["tcno"].HeaderText = "TC NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["ad"].HeaderText = "AD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞ
                arsivleri_listele.Columns["soyad"].HeaderText = "SOYAD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
                arsivleri_listele.Columns["cinsiyet_guncellemesi"].HeaderText = "CİNSİYET";
                arsivleri_listele.Columns["il"].HeaderText = "İL";
                arsivleri_listele.Columns["ilce"].HeaderText = "İLÇE";
                arsivleri_listele.Columns["cep1"].HeaderText = "CEP TELEFONU(1)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["cep2"].HeaderText = "CEP TELEFONU(2)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["eposta"].HeaderText = "E-POSTA ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["adres"].HeaderText = "EV ADRESİ";
                arsivleri_listele.Columns["ehliyet_no"].HeaderText = "EHLİYET NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["ehliyet_turu"].HeaderText = "EHLİYET TÜRÜ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["ehliyet_tarihi"].HeaderText = "EHLİYET TARİHİ";
                arsivleri_listele.Columns["aciklama"].HeaderText = "AÇIKLAMA";
                musteri_arsivden_cikar_sagtik.Visible = true;
            }
            else if (ana_pencere.hangi_arsiv_listesi.ToString() == "arac_tablosu")//TABLOYA GÖRE ALAN ADLARI VE BOYUTLANDIRMA İŞLEMLERİ
            {
                this.Text = "ARAÇ ARŞİV LİSTESİ";//ARŞİV ADI
                arsivleri_listele.Columns["arac_id"].Visible = false;//GEREKSİZLER
                arsivleri_listele.Columns["arsiv"].Visible = false;//GEREKSİZLER
                arsivleri_listele.Columns["hasar"].Visible = false;//GEREKSİZLER
                arsivleri_listele.Columns["plaka"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["marka"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["yil"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["renk"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["kategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["km"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["yakit_turu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["yakit_doluluk_yuzdesi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["vites_turu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["koltuk_sayisi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["kapi_sayisi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["kira_ucreti"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["kaza_durumu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["aciklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;


                arsivleri_listele.Columns["plaka"].HeaderText = "PLAKA NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.;
                arsivleri_listele.Columns["marka"].HeaderText = "MARKA";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["model"].HeaderText = "MODEL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["yil"].HeaderText = "YIL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["renk"].HeaderText = "RENK";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["kategori"].HeaderText = "KATEGORİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["km"].HeaderText = "KİLOMETRE(KM)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["yakit_turu"].HeaderText = "YAKİT TÜRÜ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["yakit_doluluk_yuzdesi"].HeaderText = "YAKİT(%)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["vites_turu"].HeaderText = "VİTES TÜRÜ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["koltuk_sayisi"].HeaderText = "KOLTUK SAYISI";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["kapi_sayisi"].HeaderText = "KAPI SAYISI";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["kira_ucreti"].HeaderText = "KİRA ÜCRETİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["kaza_durumu"].HeaderText = "KAZA DURUMU";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["aciklama"].HeaderText = "AÇIKLAMA";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                araci_arsivden_cikar_sagtik.Visible = true;//ARŞİVDEN ÇIKARMA İŞLEMLERİ
            }
            else if (ana_pencere.hangi_arsiv_listesi.ToString() == "kiralama_tablosu")//TABLOYA GÖRE ALAN ADLARI VE BOYUTLANDIRMA İŞLEMLERİ
            {
                this.Text = "KİRALAMA ARŞİV LİSTESİ";//ARŞİV ADI
                arsivleri_listele.Columns["tcno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["soyad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["cep1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["cep2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["eposta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ehliyet_no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ehliyet_turu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["plaka"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["marka"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["kategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["kira_ucreti"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["kiralama_tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["fiyat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["geri_alis_tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["odeme_turu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["aciklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["cikis_durumu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ

                arsivleri_listele.Columns["tcno"].HeaderText = "TC NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["ad"].HeaderText = "AD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞ
                arsivleri_listele.Columns["soyad"].HeaderText = "SOYAD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
                arsivleri_listele.Columns["cep1"].HeaderText = "CEP TELEFONU(1)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["cep2"].HeaderText = "CEP TELEFONU(2)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["eposta"].HeaderText = "E-POSTA ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["ehliyet_no"].HeaderText = "EHLİYET NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["ehliyet_turu"].HeaderText = "EHLİYET TÜRÜ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["plaka"].HeaderText = "PLAKA NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.;
                arsivleri_listele.Columns["marka"].HeaderText = "MARKA";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["model"].HeaderText = "MODEL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["kategori"].HeaderText = "KATEGORİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["kira_ucreti"].HeaderText = "KİRA ÜCRETİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["kiralama_tarihi"].HeaderText = "KİRALAMA TARİHİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["fiyat"].HeaderText = "ÜCRET";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["geri_alis_tarihi"].HeaderText = "ARAÇ İADE TARİHİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["odeme_turu"].HeaderText = "ÖDEME TÜRÜ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["cikis_durumu"].HeaderText = "DURUM";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["aciklama"].HeaderText = "AÇIKLAMA";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            }
            else if (ana_pencere.hangi_arsiv_listesi.ToString() == "personel_tablosu")//TABLOYA GÖRE ALAN ADLARI VE BOYUTLANDIRMA İŞLEMLERİ
            {
                this.Text = "PERSONEL ARŞİV LİSTESİ";//ARŞİV ADI
                arsivleri_listele.Columns["tcno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["soyad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["il"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ilce"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["dogum_yeri"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["dogum_tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["cep_telefonu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ev_telefonu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["eposta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                arsivleri_listele.Columns["ev_adresi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ


                arsivleri_listele.Columns["tcno"].HeaderText = "TC NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["ad"].HeaderText = "AD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞ
                arsivleri_listele.Columns["soyad"].HeaderText = "SOYAD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
                arsivleri_listele.Columns["cinsiyet_guncellemesi"].HeaderText = "CİNSİYET";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["il"].HeaderText = "İL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["ilce"].HeaderText = "İLÇE";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["dogum_yeri"].HeaderText = "DOĞUM YERİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["dogum_tarihi"].HeaderText = "DOĞUM TARİHİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["cep_telefonu"].HeaderText = "CEP TELEFONU";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["ev_telefonu"].HeaderText = "EV TELEFONU";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["eposta"].HeaderText = "E-POSTA ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                arsivleri_listele.Columns["ev_adresi"].HeaderText = "EV ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            }
        }
        private void musteri_arsivden_cikar_sagtik_Click(object sender, EventArgs e)
        {
            try
            {
                if (arsivleri_listele.CurrentRow.Cells[0].Value.ToString() != "")//SEÇİLEN ELEMAN TC SI BOŞ DEĞİLSE
                {
                    if (MessageBox.Show("SEÇİLEN TC NO:" + arsivleri_listele.CurrentRow.Cells[0].Value.ToString() + " MÜŞTERİ ÇIKARILSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SİSTEME GİRİŞİ ARŞİVDEN ÇIKISI YAPILSIN MI EVET İSE
                    {
                        //True İse Müşteri False İse Araç için
                        arsivden_cikar(true);//MÜŞTERİYİ ARŞİVDEN ÇIKARIR
                    }
                }
                else
                {
                    MessageBox.Show("TABLODAN SEÇİM YAPINIZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SEÇİM HATASI BİLGİSİ
                }
            }
            catch (Exception)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show("BİLGİLER GÖRÜNTÜLEMEDİ.\nTEKRAR SEÇİM YAPINIZ.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA İŞLEM DURUMU BİLGİSİ
            }
          
        }
        private void arsivden_cikar(bool deger)//ARŞİVDEN ÇIKARMA FOKSİYONU
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                if (deger == true)//TRUE İSE MÜŞTERİ ÇIKARMA
                {
                    komut = new SqlCommand("update musteri_tablosu set arsiv=1 where tcno='" + arsivleri_listele.CurrentRow.Cells[0].Value.ToString() + "'", baglanti);
                }
                else if (deger == false)//FALSE İSE ARAÇ ÇIKARMA
                {
                    komut = new SqlCommand("update arac_tablosu set arsiv=1 where plaka='" + arsivleri_listele.CurrentRow.Cells[1].Value.ToString() + "'", baglanti);
                }
                komut.ExecuteNonQuery();//KOMUTLAR ÇALIŞIR
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                
                //TRUE FALSE GÖRE KULLANICIYA BİLGİ VERİR
                if (deger==true)
                {
                    MessageBox.Show(arsivleri_listele.CurrentRow.Cells[0].Value.ToString() + " TC KİMLİK NOLU ADI:" + arsivleri_listele.CurrentRow.Cells[1].Value.ToString() + " SOYADI:" + arsivleri_listele.CurrentRow.Cells[2].Value.ToString() + "\nMÜŞTERİ ARŞIVDEN ÇIKARILDI.", "ARŞİVDEN MÜŞTERİ ÇIKARMA İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (deger==false)
                {
                    MessageBox.Show(arsivleri_listele.CurrentRow.Cells[1].Value.ToString() + " PLAKA NOLU MARKASI:" + arsivleri_listele.CurrentRow.Cells[2].Value.ToString() + " MODELI:" + arsivleri_listele.CurrentRow.Cells[3].Value.ToString() + "\nARAÇ ARŞIVDEN ÇIKARILDI.", "ARŞİVDEN ARAÇ ÇIKARMA İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                hangi_arsiv();//ARŞİVİ YENİLER (ÇIKARMA İŞLEMİ OLDUĞU İÇİN)
               
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void araci_arsivden_cikar_sagtik_Click(object sender, EventArgs e)
        {
            try
            {
                if (arsivleri_listele.CurrentRow.Cells[0].Value.ToString() != "")//BOŞ DEĞİLSE GİRİŞ YAPAILIR 
                {
                    if (MessageBox.Show("SEÇİLEN PLAKA:" + arsivleri_listele.CurrentRow.Cells[1].Value.ToString() + " ARAÇ ÇIKARILSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//ARAÇ BİLGİSİ GÖSTERİLİR SORU SORULUR EVET İSE GİRİŞ YAPILIR
                    {
                        //True İse Müşteri False İse Araç için
                        arsivden_cikar(false);//ARAÇ ÇIKARILIR
                    }
                }
                else
                {
                    MessageBox.Show("TABLODAN SEÇİM YAPINIZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI VERİR
                }
            }
            catch (Exception)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show("BİLGİLER GÖRÜNTÜLEMEDİ.\nTEKRAR SEÇİM YAPINIZ.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA VERİR.
            }
        }

        private void seciliyi_goster_sagtik_Click(object sender, EventArgs e)
        {//SEÇİLEN SATIRI TEK PENCEREDE GÖSTERİR
            try
            {
                string birlestir_ve_goster = "SEÇİLEN SATIR HAKKINDA BİLGİLENDİRME:";//BİLGİ BAŞLIĞI
                for (int i = 0; i < arsivleri_listele.ColumnCount; i++)//KAÇ SATIR VAR
                {
                    birlestir_ve_goster += "\n" + arsivleri_listele.CurrentRow.Cells[i].Value.ToString();//SATIRLARI ALT ALTA YERLEŞTIR
                }
                MessageBox.Show(birlestir_ve_goster, "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);//BİLGİ VER
            }
            catch (Exception)
            {
                MessageBox.Show("BİLGİLER GÖRÜNTÜLEMEDİ.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//SORUN BİLDİRME
            }
        }

        private void iptal_et_sagtik_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI HATA DÜZENLEME
            arsivleri_listele.BackgroundColor = this.BackColor;
        }

        private void yardim_sagtik_Click(object sender, EventArgs e)
        {//YARDIM PENCERESINI AÇAR
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
