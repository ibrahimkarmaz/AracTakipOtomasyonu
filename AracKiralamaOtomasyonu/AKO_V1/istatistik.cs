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
    public partial class istatistik : Form
    {
        public istatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        private void istatistik_Load(object sender, EventArgs e)
        {
            istatistik_bilgileri();
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
                {
                    this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                    this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                }
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
            }
        }
        private void istatistik_bilgileri()//İSTATİKTİKLER HAKKINDA BİLGİ VERME FOKSİYONU
        {
            try
            {
                istatistik_bilgileri_label.Text = "İSTATİSTİK BİLGİLERİ\n\n";
                //en fazla kiralanan araç
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select plaka,marka,model,yil,renk,kategori from arac_tablosu where arac_id=(select top 1 arac_id from kiralama_tablosu group by arac_id order by count(arac_id)  desc)", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    istatistik_bilgileri_label.Text += "Bugüne kadar en fazla kiralanan araç bilgileri;\nPlaka:" + oku["plaka"].ToString() + " Marka/Model/Yıl:" + oku["marka"].ToString() + "/" + oku["model"].ToString() + "/" + oku["yil"].ToString() + " " + oku["renk"].ToString() + " " + oku["kategori"].ToString();
                }
                else
                {
                    istatistik_bilgileri_label.Text += "Bugüne kadar en fazla kiralanan araç bulunamadı.";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                //en fazla araç kiralayan müşteri
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select tcno,ad,soyad from musteri_tablosu where musteri_id=(select top 1 musteri_id from kiralama_tablosu group by musteri_id order by count(musteri_id)  desc)", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    istatistik_bilgileri_label.Text += "\n\nBugüne kadar en fazla araç kiralayan müşteri;\nTC No:" + oku["tcno"].ToString() + " Adı Soyadı:" + oku["ad"].ToString() + " " + oku["soyad"].ToString();
                }
                else
                {
                    istatistik_bilgileri_label.Text += "\n\nBugüne kadar en fazla araç kiralayan müşteri bulunamadı.";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                //kiralanan araçlar üzerinden bügüne kadarki toplam kazanç(arsivde olanlardan)
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select sum(fiyat) as 'toplam_kazanc' from kiralama_tablosu where teslim_alis_durumu=1 and arsiv=0", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    istatistik_bilgileri_label.Text += "\n\nBugüne kadar kiralanip teslim alınmış araçlar üzerinizde ki toplam kazanç;" + oku["toplam_kazanc"].ToString() + " TL";
                }
                else
                {
                    istatistik_bilgileri_label.Text += "\n\nBugüne kadar kiralanip teslim alınmış araçlar üzerinizde ki toplam kazanç bulunamadı.";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                //Bugüne kadar ki toplam kiralanan araç sayısı
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select COUNT(*) as 'kiralanan_arac_sayisi' from kiralama_tablosu", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    istatistik_bilgileri_label.Text += "\n\nBugüne kadar kiralanan toplam araç sayısı;" + oku["kiralanan_arac_sayisi"].ToString();
                }
                else
                {
                    istatistik_bilgileri_label.Text += "\n\nBugüne kadar kiralanan toplam araç sayısı bulunamadı.";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                //teslim alinan araç sayısı
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select COUNT(*) as 'teslim_alinan' from kiralama_tablosu where arsiv=1 and teslim_alis_durumu=1", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    istatistik_bilgileri_label.Text += "\n\nBugüne kadar kiralanip teslim alınmış araç sayısı;" + oku["teslim_alinan"].ToString();
                }
                else
                {
                    istatistik_bilgileri_label.Text += "\n\nBugüne kadar kiralanip teslim alınmış araç sayısı bulunamadı.";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                //iptal edilen araç sayısı
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select COUNT(*) as 'iptal_edilen' from kiralama_tablosu where arsiv=1 and teslim_alis_durumu=0", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    istatistik_bilgileri_label.Text += "\n\nBugüne kadar kiralanip iptal edilen araç sayısı;" + oku["iptal_edilen"].ToString();
                }
                else
                {
                    istatistik_bilgileri_label.Text += "\n\nBugüne kadar kiralanip iptal edilen araç sayısı bulunamadı.";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                /*
                 * Sistemde bulunan toplam araç sayısı(aktif)+
                 * sistemde bulunan araçların ortalama kira fiyati+*/
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select count(*) as 'aktif_araclar',AVG(kira_ucreti) as 'ort_kira',max(kira_ucreti) as 'en_fazla',min(kira_ucreti) as 'en_az' from arac_tablosu where arsiv=1", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    istatistik_bilgileri_label.Text += "\n\nSistemde bulunan toplam araç sayısı;" + oku["aktif_araclar"].ToString() + "(Aktif olan)\n\nAraçların ortalama,en az ve en fazla kira bilgileri sırasıyla;" + oku["ort_kira"].ToString() + "/" + oku["en_az"].ToString() + "/" + oku["en_fazla"].ToString();
                }
                else
                {
                    istatistik_bilgileri_label.Text += "\n\nistemde bulunan toplam araç sayısı bulunamadı\nAraçların ortalama,en az ve en fazla kira bilgileri bulunamadı.";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI


                //Arşivde bulunan toplam araç sayısı
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select COUNT(*) as 'arsivde_bulunan_arac_sayisi' from arac_tablosu where arsiv=0", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    istatistik_bilgileri_label.Text += "\n\nArşivde bulunan toplam araç sayısı;" + oku["arsivde_bulunan_arac_sayisi"].ToString();
                }
                else
                {
                    istatistik_bilgileri_label.Text += "\n\nArşivde bulunan toplam araç sayısı bulunamadı.";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                /* hasarlı araç sayısı(5/100 gibi) sistemde bulunan ve arşivde bulunan olarak 2 ye ayır
                 * Arşivde olan ve olmayanlar:*/
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select COUNT(*) as 'toplam_arac',(select COUNT(*) as 'kazali_arac' from arac_tablosu where arsiv=1 and hasar=1) as 'kazali_arac',(select COUNT(*) as 'toplam_arac_x' from arac_tablosu where arsiv=0) as 'toplam_arac_arsiv',(select COUNT(*) as 'kazali_arac_x' from arac_tablosu where arsiv=0 and hasar=1) as 'kazali_arac_arsiv' from arac_tablosu where arsiv=1 ", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    istatistik_bilgileri_label.Text += "\n\nSistemde bulunan araçların kaçta kaçı kazalı(Kazalı Araç/Araç Sayısı);" + oku["kazali_arac"].ToString() + "/" + oku["toplam_arac"].ToString() + "\n\nArşivde bulunan araçların kaçta kaçı kazalı(Kazalı Araç/Araç Sayısı);" + oku["kazali_arac_arsiv"].ToString() + "/" + oku["toplam_arac_arsiv"].ToString();
                }
                else
                {
                    istatistik_bilgileri_label.Text += "\n\nSistemde veya Arşivde kazalı araç bulunamadı.";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                /* -sistemde bulunan toplam müşteri sayısı(aktif)+
                  * arşivde bulunan toplam müşteri sayısı+
                  * müşterilerin en fazla hangi il de oturuyor.+*/
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select count(*) as 'aktif_musteri',(select count(*) as 'xx' from musteri_tablosu where arsiv=0) as 'pasif_musteri' , (select top 1 il as 'en_fazla_il' from musteri_tablosu  group by il) as 'en_fazla_il' from musteri_tablosu where arsiv=1", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    istatistik_bilgileri_label.Text += "\n\nSistemde bulunan toplam müşteri sayısı;" + oku["aktif_musteri"].ToString() + "\n\nArşivde bulunan toplam müşteri sayısı;" + oku["pasif_musteri"].ToString() + "\n\nMüşterilen en fazla hangi il'de yaşıyor;" + oku["en_fazla_il"].ToString();
                }
                else
                {
                    istatistik_bilgileri_label.Text += "\n\nSistemde veya Arşivde müşteri bulunamadı.";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI


                //müşterilerin cinsiyeti(%67 erkek-%33 kadın gibi)
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select (COUNT(*)*100/(select COUNT(*) from musteri_tablosu)) as 'erkek_yuzdesi',((select COUNT(*) as 'kadin' from musteri_tablosu where cinsiyet=0)*100/(select COUNT(*) from musteri_tablosu)) as 'kadin_yuzdesi' from musteri_tablosu where cinsiyet=1", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    istatistik_bilgileri_label.Text += "\n\nMüşterilerin %" + oku["erkek_yuzdesi"].ToString() + " Erkek %" + oku["kadin_yuzdesi"].ToString() + " Kadındır.";
                }
                else
                {
                    istatistik_bilgileri_label.Text += "\n\nMüşteri cinsiyete göre yüzdesi bulunamadı.";
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                MessageBox.Show(HATA.ToString());
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
        }
    }
}
