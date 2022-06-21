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
    public partial class kiralama_islemini_teslim_al_veya_iptal_et : Form
    {//**HEM TESLİM AL HEMDE İPTAL İŞLEMİ İÇİN KULLANILMIŞTIR.
        public kiralama_islemini_teslim_al_veya_iptal_et()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        string kiralayan_musteri_id = "", kiralanan_arac_id = "", secilen_tcye_ait_bilgiler = "", secilen_plakaya_ait_bilgiler = "", kiralama_id = "";
        private void kiralama_islemini_iptal_et_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kiralayan_tcleri_getir();
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
            kiralayan_tc_pb.Image = Image.FromFile(@"image\acik_goz.png");
            kiralayan_tc_bilgi_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");
            kiranalan_arac_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");

            kirala_pb.Image = Image.FromFile(@"image\kiralama_islemleri_iptal_et1.png");
            kiralama_iptal_et_menu.Image = Image.FromFile(@"image\cikar.png");
            kiralama_iptal_et_sagtik.Image = Image.FromFile(@"image\cikar.png");
            iptalet_pb.Image = Image.FromFile(@"image\kiralama_iptal_et1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");

            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");

            aciklama_pb.Image = Image.FromFile(@"image\bilgi_verme.png");

            if (ana_pencere.tetikle==true)//TESLİM AL İŞLEMLERİ
            {
                kirala_pb.Image = Image.FromFile(@"image\teslim_al1.png");//VARSAYILAN GÖRSELİNİ DEĞİŞTİRME
                kiralama_iptal_et_menu.Image = Image.FromFile(@"image\anahtar.png");//VARSAYILAN GÖRSELİNİ DEĞİŞTİRME
                kiralama_iptal_et_sagtik.Image = Image.FromFile(@"image\anahtar.png");//VARSAYILAN GÖRSELİNİ DEĞİŞTİRME
            }

            kiralayan_tc_pb.SizeMode = kiralayan_tc_bilgi_pb.SizeMode = kiranalan_arac_pb.SizeMode = kirala_pb.SizeMode = iptalet_pb.SizeMode = aciklama_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            this.Text = "Kiralama İşlemini İptal Et";//PENCERE ADI
            if (kiralayan_tc_combo.Items.Count > 0)
            {
                kiralayan_tc_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
            if (kiralanan_arac_combo.Items.Count>0)
            {
                 kiralanan_arac_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
            aciklama_tb.MaxLength = 255;//EN FAZLA GİRİLEBİLECEK KARAKTER SAYISI
            if (ana_pencere.tetikle==true)//TESLİM AL İŞLEMLERİ
            {
                this.Text = "Teslim Al";//PENCERE ADI
                tum_kiralananlari_teslim_al_cb.Visible = true;//3DEN FAZLA İSE ALINIR
               
                musteriyi_cikar_cb.Visible = true;//1 MÜŞTERİ 1 ARAÇ KALDI İSE ÇIKARILIR
                aciklama_label.Text = "Açıklama:";//DEĞİŞTİRME
                kiralama_iptal_et_menu.Text = "Teslim Al";//DEĞİŞTİRME
                kiralama_iptal_et_sagtik.Text = "Teslim Al";//DEĞİŞTİRME
            }
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI OLUŞAN SORUNLARI DÜZENLEME
            degistirilecekler_gb.ForeColor=tum_kiralananlari_teslim_al_cb.ForeColor = musteriyi_cikar_cb.ForeColor = this.ForeColor;
        }

        private void aciklama_tb_TextChanged(object sender, EventArgs e)
        {
            karkater_sayisi_kalan_label.Text = aciklama_tb.TextLength.ToString() + "/255";//AÇIKLAMADA NE KADAR YAZDIĞI VE KALDIĞI
        }
        private void kiralayan_tcleri_getir()
        {

            kiralayan_tc_combo.Items.Clear();//SEÇİM KUTUSUNU SİLME
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select distinct(tcno) from kiralama_tablosu inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id where kiralama_tablosu.arsiv=1", baglanti);//ARAÇ KİRALAYANLARI GETİRME
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    kiralayan_tc_combo.Items.Add(oku["tcno"]);//SEÇİM KUTUSUNA EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void kiralanan_plakalari_getir()//KİRALANAN ARAÇLARI GETİRME
        {
            kiralanan_arac_combo.Items.Clear();//SEÇİM KUTUSUNU SİLME
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(plaka) as Plaka from kiralama_tablosu inner join arac_tablosu on kiralama_tablosu.arac_id=arac_tablosu.arac_id inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id where musteri_tablosu.tcno='" + kiralayan_tc_combo.Text + "' and kiralama_tablosu.arsiv=1", baglanti);//PLAKA GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMALAR
                {
                    kiralanan_arac_combo.Items.Add(oku["Plaka"]);//SEÇİM KUTUSUNA EKLE
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                if (kiralanan_arac_combo.Items.Count > 0)
                {
                    kiralanan_arac_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
                }
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void kiralayan_tc_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            kiralanan_plakalari_getir();//PLAKALARI GETİRİR
            secilen_tc_bilgi();//SEÇİLEN TC HAKKINDA BİLGİ
            if (kiralanan_arac_combo.Items.Count != 1)//EĞER ARAÇ 1'DEN FAZLA İSE ARAÇ ÇIKARILAMAZ
            {
                musteriyi_cikar_cb.Enabled = false;
                musteriyi_cikar_cb.Checked = false;
            }
            else//1 İSE ÇIKARILABİLİR
            {
                musteriyi_cikar_cb.Enabled = true;
            }
            if (kiralanan_arac_combo.Items.Count < 3)//3'DEN FAZLA İSE TÜM ARAÇLAR TESLİM ALINIR
            {
                tum_kiralananlari_teslim_al_cb.Enabled = false;
                tum_kiralananlari_teslim_al_cb.Checked = false;
            }
            else
            {
                tum_kiralananlari_teslim_al_cb.Enabled = true;
            }
        }
        private void secilen_tc_bilgi()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from musteri_tablosu where tcno='" + kiralayan_tc_combo.SelectedItem + "'", baglanti);//TC HAKKINDA BİLGİ KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    kiralayan_musteri_id = oku["musteri_id"].ToString();//MÜŞTERİ ADİ SAKLANIR KULLANILMAK İÇİN(MÜŞTERİ DEĞİŞTİRİLEBİLİR.)
                    if (Convert.ToByte(oku["cinsiyet"]) == 0)//CİNSİYEYE GÖRE BİLGİLENDİRME İŞLEMLERİ
                    {
                        secilen_tcye_ait_bilgiler = "TC NO:" + oku["tcno"].ToString() + "\nAd Soyad:" + oku["ad"].ToString() + " " + oku["soyad"].ToString() + "\nCinsiyet:Kadın" + "\nİl/İlçe:" + oku["il"].ToString() + "/" + oku["ilce"].ToString() + "\nCep Telefonu(1):" + oku["cep1"].ToString() + "\nCep Telefonu(2):" + oku["cep2"].ToString() + "\nE-Posta Adresi:" + oku["eposta"].ToString() + "\nEv Adresi:" + oku["adres"].ToString() + "\nEhliyet No/Türü/Tarihi:" + oku["ehliyet_no"].ToString() + "/" + oku["ehliyet_turu"].ToString() + "/" + oku["ehliyet_tarihi"].ToString() + "\nAçıklama:" + oku["aciklama"].ToString();
                    }
                    else if (Convert.ToByte(oku["cinsiyet"]) == 1)//CİNSİYEYE GÖRE BİLGİLENDİRME İŞLEMLERİ
                    {
                        secilen_tcye_ait_bilgiler = "TC NO:" + oku["tcno"].ToString() + "\nAd Soyad:" + oku["ad"].ToString() + " " + oku["soyad"].ToString() + "\nCinsiyet:Erkek" + "\nİl/İlçe:" + oku["il"].ToString() + "/" + oku["ilce"].ToString() + "\nCep Telefonu(1):" + oku["cep1"].ToString() + "\nCep Telefonu(2):" + oku["cep2"].ToString() + "\nE-Posta Adresi:" + oku["eposta"].ToString() + "\nEv Adresi:" + oku["adres"].ToString() + "\nEhliyet No/Türü/Tarihi:" + oku["ehliyet_no"].ToString() + "/" + oku["ehliyet_turu"].ToString() + "/" + oku["ehliyet_tarihi"].ToString() + "\nAçıklama:" + oku["aciklama"].ToString();
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

        private void kiralayan_tc_bilgi_pb_Click(object sender, EventArgs e)
        {
            if (kiralayan_tc_combo.Items.Count!=0)//KİRALAYAN TC BOŞ DEĞİLSE
            {
                 MessageBox.Show(secilen_tcye_ait_bilgiler, "MÜŞTERİ BİLGİLERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);//MÜŞTERİ HAKKKINDA BİLGİ VERİR
            }
            else
            {
                MessageBox.Show("KİRALAYAN MÜŞTERİ BULUNAMADIĞI İÇİN MÜŞTERİ HAKKINDA BİLGİ VERİLEMEDİ", "MÜŞTERİ BİLGİLERİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//BULUNAMADI UYARISI
            }

        }

        private void kiralayan_tc_bilgi_pb_MouseMove(object sender, MouseEventArgs e)
        {
            kiralayan_tc_bilgi_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi2.png");//GÖRSEL EFEKT
        }

        private void kiralayan_tc_bilgi_pb_MouseLeave(object sender, EventArgs e)
        {
            kiralayan_tc_bilgi_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");//VARSAYILAN GÖRSEL
        }

        private void kiralanan_arac_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            kiralanan_secilen_plaka();
        }
        private void kiralanan_secilen_plaka()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from arac_tablosu where plaka='" + kiralanan_arac_combo.SelectedItem + "'", baglanti);//SEÇİLEN PLAKA GÖRE BİLGİLENDİRME
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    kiralanan_arac_id = oku["arac_id"].ToString();//ARAÇ DEĞİŞTİRMEDE KULLANILIR
                    if (Convert.ToByte(oku["hasar"]) == 0)//KAZA DURUMUNA GÖRE BİLGİLENDİRME
                    {
                        secilen_plakaya_ait_bilgiler = "Plaka No:" + oku["plaka"].ToString() + "\nMarka:" + oku["marka"].ToString() + "\nModel:" + oku["model"].ToString() + "\nKategori:" + oku["kategori"].ToString() + "\nRenk:" + oku["renk"].ToString() + "\nDepo Doluluk Yüzdesi(%):" + oku["yakit_doluluk_yuzdesi"] + "\nKiloMetre[KM]:" + oku["km"].ToString() + "\nVites Türü:" + oku["vites_turu"].ToString() + "\nKoltuk Sayısı:" + oku["koltuk_sayisi"].ToString() + "\nKapı Sayısı:" + oku["kapi_sayisi"].ToString() + "\nKira Ücreti:" + oku["kira_ucreti"].ToString() + "\nKaza Durumu:Yok" + "\nAçıklama:" + oku["aciklama"].ToString();
                    }
                    else if (Convert.ToByte(oku["hasar"]) == 1)//KAZA DURUMUNA GÖRE BİLGİLENDİRME
                    {
                        secilen_plakaya_ait_bilgiler = "Plaka No:" + oku["plaka"].ToString() + "\nMarka:" + oku["marka"].ToString() + "\nModel:" + oku["model"].ToString() + "\nKategori:" + oku["kategori"].ToString() + "\nRenk:" + oku["renk"].ToString() + "\nDepo Doluluk Yüzdesi(%):" + oku["yakit_doluluk_yuzdesi"] + "\nKiloMetre[KM]:" + oku["km"].ToString() + "\nVites Türü:" + oku["vites_turu"].ToString() + "\nKoltuk Sayısı:" + oku["koltuk_sayisi"].ToString() + "\nKapı Sayısı:" + oku["kapi_sayisi"].ToString() + "\nKira Ücreti:" + oku["kira_ucreti"].ToString() + "\nKaza Durumu:Var" + "\nAçıklama:" + oku["aciklama"].ToString();
                    }
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                ozet_bilgi_label.Text = "";
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from kiralama_tablosu inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id inner join arac_tablosu on kiralama_tablosu.arac_id=arac_tablosu.arac_id where kiralama_tablosu.arac_id=" + kiralanan_arac_id + " and kiralama_tablosu.arsiv=1", baglanti);//ÖZET BİLGİSİ KOMUT
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    kiralama_id = oku["kiralama_id"].ToString();
                    ozet_bilgi_label.Text += oku["ad"].ToString() + " " + oku["soyad"].ToString() + " Kiraladığı " + oku["marka"].ToString() + "/" + oku["model"].ToString() + " Aracın Detayları;" + oku["kiralama_tarihi"].ToString() + " Tarihinde kiralanan araç\n" + oku["geri_alis_tarihi"].ToString() + " geri getirilecektir.(Kira Fiyati:" + oku["fiyat"].ToString() + ")";//ÖZET BİLGİSİ
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void kiranalan_arac_pb_Click(object sender, EventArgs e)
        {
            if (kiralanan_arac_combo.Items.Count!=0)//ARAÇ VARMI 
            {
                MessageBox.Show(secilen_plakaya_ait_bilgiler, "ARAÇ BİLGİLERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);//SEÇİLEN ARAÇ HAKKINDA BİLGİ VERİR
            }
            else
            {
                MessageBox.Show("KİRALANAN ARAÇ BULUNAMADIĞI İÇİN ARAÇ HAKKINDA BİLGİ VERİLEMEDİ", "ARAÇ BİLGİLERİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//ARAÇ BULUNAMADI UYARISI
            }  
        }

        private void kiranalan_arac_pb_MouseMove(object sender, MouseEventArgs e)
        {
            kiranalan_arac_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi2.png");//GÖRSEL EFEKT
        }

        private void kiranalan_arac_pb_MouseLeave(object sender, EventArgs e)
        {
            kiranalan_arac_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");//VARSAYILAN GÖRSEL
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
            iptalet_pb.Image = Image.FromFile(@"image\kiralama_iptal_et2.png");//GÖRSEL EFEKT
        }

        private void iptalet_pb_MouseLeave(object sender, EventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\kiralama_iptal_et1.png");//VARSAYILAN GÖRSEL
        }
        string bilgilendirme_basligi="";
        private void kirala_pb_Click(object sender, EventArgs e)
        {
            if (kiralayan_tc_combo.Items.Count > 0 && kiralanan_arac_combo.Items.Count > 0)//MÜŞTERİ VEYA ARAÇ VAR MI
            {
                if (aciklama_tb.Text!="" && aciklama_tb.Text.Count()>=12)//AÇIKLAMA BOŞ DEĞİL VE EN AZ 12 KARAKTERLI BİR ŞEY YAZILMALI
                {
                    if (ana_pencere.tetikle==true)
                    {//TESLİM AL İŞLEMLERİ
                        bilgilendirme_basligi = "TESLİM ALMA İŞLEMLERİ";
                        teslim_al();
                        ozet_bilgi_label.Text = "";
                    }
                    else if (ana_pencere.tetikle == false)
                    {//İPTAL İŞLEMLERİ
                        bilgilendirme_basligi = "İPTAL İŞLEMLERİ";
                        arac_cikar();
                        ozet_bilgi_label.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("AÇIKLAMA BULUNAMADI VEYA 12 KARAKTERDEN AZ GİRİLDİ...", bilgilendirme_basligi, MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI
                }
            }
            else
            {
                MessageBox.Show("KİRALAYAN MÜŞTERİ VEYA KİRALANAN ARAÇ BULUNAMADIĞI İÇİN İPTAL İŞLEMİ GERÇEKLEŞTİREMEDİ.", bilgilendirme_basligi, MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI
                this.Close();
            }
        }
        private void arac_cikar()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("update kiralama_tablosu set aciklama='"+aciklama_tb.Text+"',teslim_alis_durumu=0,arsiv=0 where kiralama_id="+kiralama_id, baglanti);//ARAÇ İPTAL EDİLİR
                komut.ExecuteNonQuery();//KOMUT ÇALIŞTIRMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                kiralayan_tcleri_getir();//YENİLEME
                kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
                if (kiralayan_tc_combo.Items.Count==0)//MÜŞTERİ YOKSA
                {
                    kiralanan_arac_combo.Items.Clear();//ARAÇLARI SİL
                }
                aciklama_tb.Clear();
                MessageBox.Show("KİRALANAN ARAÇ BAŞARILI BİR ŞEKİLDE İPTAL EDİLDİ.", bilgilendirme_basligi, MessageBoxButtons.OK, MessageBoxIcon.Information);//BİLGİ VERME
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void teslim_al()
        {
            try
            {
                if (tum_kiralananlari_teslim_al_cb.Checked==true)//3DEN FAZLA İSE TÜMÜNÜ TESLİM ALMA
                {
                    for (int i = 0; i < kiralanan_arac_combo.Items.Count; i++)//TESLİM ALMA SIRASIYLA
                    {
                        kiralanan_arac_combo.SelectedIndex = i;
                        baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                        komut = new SqlCommand("update kiralama_tablosu set aciklama='" + aciklama_tb.Text + "',teslim_alis_durumu=1,arsiv=0 where kiralama_id=" + kiralama_id, baglanti);//TESLİM ALMA KOMUTU
                        komut.ExecuteNonQuery();//KOMUTLARI ÇALIŞTIRMA
                        baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                    }
                    MessageBox.Show("KİRALANAN ARAÇLAR BAŞARILI BİR ŞEKİLDE TESLİM ALINDI.", bilgilendirme_basligi, MessageBoxButtons.OK, MessageBoxIcon.Information);//BİLGİ VERME  
                }
                else if (tum_kiralananlari_teslim_al_cb.Checked==false)
                {
                    baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                    komut = new SqlCommand("update kiralama_tablosu set aciklama='" + aciklama_tb.Text + "',teslim_alis_durumu=1,arsiv=0 where kiralama_id=" + kiralama_id, baglanti);//SADECE SEÇİLEN ARAÇ TESLİM ALINDI
                    komut.ExecuteNonQuery();//KOMUTLARI ÇALIŞTIRMA
                    baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                    MessageBox.Show("KİRALANAN ARAÇ BAŞARILI BİR ŞEKİLDE TESLİM ALINDI.", bilgilendirme_basligi, MessageBoxButtons.OK, MessageBoxIcon.Information);          //BİLGİ VERME
                }

                if (musteriyi_cikar_cb.Checked==true)
                {
                    baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                    komut = new SqlCommand("update musteri_tablosu set arsiv=0 where musteri_id=" + kiralayan_musteri_id, baglanti);//1 TANE ARAÇ ALINDI İSE VEYA TÜM ARAÇLAR SİLİNECEK VE MÜŞTERİ ÇIKARILACAK İSE ÇALIŞAN KOMUT
                    komut.ExecuteNonQuery();//KOMUT ÇALIŞTIRMA
                    baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                    MessageBox.Show(kiralayan_tc_combo.SelectedItem + " TC NOLU MÜŞTERİ ÇIKARILMIŞTIR.", "MÜŞTERİ ÇIKARMA", MessageBoxButtons.OK, MessageBoxIcon.Information);//BİLGİ VERME
                }
               
                kiralayan_tcleri_getir();//GÜNCELLEME
                kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
                if (kiralayan_tc_combo.Items.Count==0)//MÜŞTERİ YOKSA
                {
                    kiralanan_arac_combo.Items.Clear();//ARAÇLARI SİL
                }
                aciklama_tb.Clear();//AÇIKLAMAYI TEMİZLE
                
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void kirala_pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (ana_pencere.tetikle==true)//TESLİM AL
            {
                kirala_pb.Image = Image.FromFile(@"image\teslim_al2.png");//GÖRSEL EFEKT
            }
            else if (ana_pencere.tetikle==false)//İPTAL ET
            {
                kirala_pb.Image = Image.FromFile(@"image\kiralama_islemleri_iptal_et2.png");//GÖRSEL EFEKT
            }
        }

        private void kirala_pb_MouseLeave(object sender, EventArgs e)
        {
            if (ana_pencere.tetikle==true)//TESLİM AL
            {
                kirala_pb.Image = Image.FromFile(@"image\teslim_al1.png");//VARSAYILAN GÖRSEL
            }
            else if (ana_pencere.tetikle == false)//İPTAL ET
            {
                kirala_pb.Image = Image.FromFile(@"image\kiralama_islemleri_iptal_et1.png");//VARSAYILAN GÖRSEL
            }
            
        }

        private void tum_kiralananlari_teslim_al_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (tum_kiralananlari_teslim_al_cb.Checked==true)//EĞER 3 DEN FAZLA ARAÇ VAR İSE ÇALIŞIR
            {
                musteriyi_cikar_cb.Enabled = true;//TÜM 3 DEN FAZLA ARAÇ VAR İSE TÜM KİRALANAN ARAÇLARI TESLİM AL BAĞLIDIR
            }
            else
            {
                musteriyi_cikar_cb.Checked = false;//SEÇİMİ FALSE YAPAR
                musteriyi_cikar_cb.Enabled = false;//MÜŞTERİ ÇIKARMAYI GİZLER
            }
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESINI AÇAR
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
