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
    public partial class liste_formu : Form
    {
        public liste_formu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlDataAdapter Komutlar;//TABLOLARIN ÇEKİLMESİNDE KULLANILAN KOMUT
        DataSet veriseti = new DataSet();//ÇEKİLEN TABLOLARI SAKLAMAK İÇİN GEREK KOMUT
        private void liste_formu_Load(object sender, EventArgs e)
        {
            if (ana_pencere.renkler_uygulanacakmi==true)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                if (ana_pencere.hangi_tablo.ToString() == "musteri_tablosu")//SİSTEMDEKİ MÜŞTERİ BİLGİLERİ ÇEKEN YER
                {
                    Komutlar = new SqlDataAdapter("select tcno,ad,soyad,case cinsiyet when 1 then 'Erkek' when 0 then 'Kadın'end as 'cinsiyet_guncellemesi',il,ilce,cep1,cep2,eposta,adres,ehliyet_no,ehliyet_turu,ehliyet_tarihi,aciklama from musteri_tablosu where arsiv=1", baglanti);//SİSTEMDEKİ MÜŞTERİ BİLGİLERİ ÇEKEN KOMUT
                }
                else
                {
                    Komutlar = new SqlDataAdapter("select * from " + ana_pencere.hangi_tablo.ToString() + " where arsiv=1", baglanti);//DİĞER TABLOLAR
                }
                Komutlar.Fill(veriseti, ana_pencere.hangi_tablo.ToString());//TABLOARI KOPYALAMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                tablolari_listele_dgv.DataSource = veriseti.Tables[ana_pencere.hangi_tablo.ToString()];//TABLOYU PENCEREYE EKLEME
            }
            catch (Exception)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }


            if (ana_pencere.hangi_tablo.ToString() == "arac_tablosu")//ARAÇ TABLOSU DÜZENLEMELERİ
            {
                this.Text = "Araç Listesi";//PENCERE ADI
                tablolari_listele_dgv.Columns["arac_id"].Visible = false;//GEREKSİZDİR GİZLENİR
                tablolari_listele_dgv.Columns["arsiv"].Visible = false;//GEREKSİZDİR GİZLENİR
                tablolari_listele_dgv.Columns["plaka"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["marka"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["yil"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["renk"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["kategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["km"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["yakit_turu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["yakit_doluluk_yuzdesi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["vites_turu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["koltuk_sayisi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["kapi_sayisi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["kira_ucreti"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["hasar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["aciklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;


                tablolari_listele_dgv.Columns["plaka"].HeaderText = "PLAKA NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.;
                tablolari_listele_dgv.Columns["marka"].HeaderText = "MARKA";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["model"].HeaderText = "MODEL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["yil"].HeaderText = "YIL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["renk"].HeaderText = "RENK";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["kategori"].HeaderText = "KATEGORİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["km"].HeaderText = "KİLOMETRE(KM)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["yakit_turu"].HeaderText = "YAKİT TÜRÜ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["yakit_doluluk_yuzdesi"].HeaderText = "YAKİT(%)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["vites_turu"].HeaderText = "VİTES TÜRÜ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["koltuk_sayisi"].HeaderText = "KOLTUK SAYISI";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["kapi_sayisi"].HeaderText = "KAPI SAYISI";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["kira_ucreti"].HeaderText = "KİRA ÜCRETİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["hasar"].HeaderText = "KAZA DURUMU";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["aciklama"].HeaderText = "AÇIKLAMA";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            }
            else if (ana_pencere.hangi_tablo.ToString() == "musteri_tablosu")//MÜŞTERİ TABLOSU DÜZENLEMELERİ
            {
                this.Text = "Müşteri Listesi";//PENCERE ADI
                tablolari_listele_dgv.Columns["tcno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["ad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["soyad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["il"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["ilce"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["cep1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["cep2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["eposta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["adres"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["ehliyet_no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["ehliyet_turu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["ehliyet_tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
                tablolari_listele_dgv.Columns["aciklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;


                tablolari_listele_dgv.Columns["tcno"].HeaderText = "TC NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.İ
                tablolari_listele_dgv.Columns["ad"].HeaderText = "AD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞ
                tablolari_listele_dgv.Columns["soyad"].HeaderText = "SOYAD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
                tablolari_listele_dgv.Columns["cinsiyet_guncellemesi"].HeaderText = "CİNSİYET";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
                tablolari_listele_dgv.Columns["il"].HeaderText = "İL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
                tablolari_listele_dgv.Columns["ilce"].HeaderText = "İLÇE";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
                tablolari_listele_dgv.Columns["cep1"].HeaderText = "CEP TELEFONU(1)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["cep2"].HeaderText = "CEP TELEFONU(2)";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["eposta"].HeaderText = "E-POSTA ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["adres"].HeaderText = "EV ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
                tablolari_listele_dgv.Columns["ehliyet_no"].HeaderText = "EHLİYET NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["ehliyet_turu"].HeaderText = "EHLİYET TÜRÜ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
                tablolari_listele_dgv.Columns["ehliyet_tarihi"].HeaderText = "EHLİYET TARİHİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
                tablolari_listele_dgv.Columns["aciklama"].HeaderText = "AÇIKLAMA";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            }
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI SORUNLARI DÜZENLEME
            tablolari_listele_dgv.BackgroundColor = this.BackColor;
        }
    }
}
