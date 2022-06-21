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
    public partial class kiralama_islemleri_duzenle : Form
    {
        public kiralama_islemleri_duzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        string arac_id = "", musteri_id = "", kiralayan_musteri_id = "", kiralanan_arac_id = "", secilen_tcye_ait_bilgiler = "", secilen_plakaya_ait_bilgiler = "",kiralama_id="";
        int gunluk_arac_kirasi, kiralanan_aracin_gunluk_arac_kirasi;
        DateTime geri_alis_tarihi_bilgisi;
        private void kiralama_islemleri_duzenle_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            tcleri_getir();//MÜŞTERİLE GETİRME
            kiralayan_tcleri_getir();//ARAÇ KİRALAYAN MÜŞTERİLERİ GETİRME
            plakalari_getir();//PLAKALARI GETİRİR
            plaka_sil();//KİRALANAN ARAÇLARI SİLME
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
            tc_no_pb.Image = Image.FromFile(@"image\kullanici.png");
            plaka_pb.Image = Image.FromFile(@"image\plakano.png");
            kiralama_tarihi_pb.Image = Image.FromFile(@"image\tarih.png");
            geri_alis_tarihi_pb.Image = Image.FromFile(@"image\tarih.png");
            odeme_turu_pb.Image = Image.FromFile(@"image\yontem.png");
            fiyat_pb.Image = Image.FromFile(@"image\tl.png");

            kirala_pb.Image = Image.FromFile(@"image\kiralama_islemleri_duzenle1.png");
            kiralama_duzenle_menu.Image = Image.FromFile(@"image\yenile1.png");
            kiralama_duzenle_sagtik.Image = Image.FromFile(@"image\yenile1.png");
            iptalet_pb.Image = Image.FromFile(@"image\kiralama_iptal_et1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");

            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");

            kiralayan_tc_pb.SizeMode = kiralayan_tc_bilgi_pb.SizeMode = kiranalan_arac_pb.SizeMode = tc_no_pb.SizeMode = kirala_pb.SizeMode = fiyat_pb.SizeMode = kiralama_tarihi_pb.SizeMode = geri_alis_tarihi_pb.SizeMode = iptalet_pb.SizeMode = plaka_pb.SizeMode = odeme_turu_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            if (tc_combo.Items.Count > 0)
            {
                tc_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }

            if (kiralayan_tc_combo.Items.Count > 0)
            {
                kiralayan_tc_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
            if (plaka_combo.Items.Count > 0)
            {
                plaka_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
            //ÖDEME TÜRLERİ
            odeme_turu_combo.Items.Clear();
            odeme_turu_combo.Items.Add("PEŞİN");
            odeme_turu_combo.Items.Add("TAKSİT");
            odeme_turu_combo.Items.Add("HAVALE-EFT");
            odeme_turu_combo.Items.Add("ANLAŞMALI");
            odeme_turu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            if (tc_combo.Items.Count == 0)
            {
                musteri_bilgi_label.Text = "";
            }
            if (plaka_combo.Items.Count == 0)
            {
                arac_bilgi_label.Text = "";
            }
            musteri_bilgileri_gb.Enabled = false;//MÜŞTERİ BİLGİLERİ GRUBUNU GİZLER
            arac_bilgileri_gb.Enabled = false;//ARAÇ BİLGİLERİ GRUBUNU GİZLER

            kiralama_tarihi_dt.Enabled = false;//KİRALAMA TARİHİ KULLANILMAZ
            geri_alis_tarihi_dt.MinDate =Convert.ToDateTime(kiralama_tarihi_dt.Value.ToShortDateString()).AddDays(1);//GERİ DÖNÜŞ TARİHİNE 1 GÜN EKLEME İŞLEMLERDE 1 GÜN EKSİK OLD. İÇİN
            geri_alis_tarihi_dt.MaxDate = DateTime.Today.AddMonths(1);//1 AY EKLEME 
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI SORUNLARI DÜZENLEME
            arac_bilgileri_gb.ForeColor = kiralama_bilgileri_gb.ForeColor = musteri_bilgileri_gb.ForeColor =degistirilecekler_gb.ForeColor=arac_degistir_cb.ForeColor=musteri_degistir_cb.ForeColor= this.ForeColor;
        }
        private void kiralanan_plakalari_getir()
        {
            kiralanan_arac_combo.Items.Clear();//KİRALANAN ARAÇLARI SİLME
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(plaka) as Plaka from kiralama_tablosu inner join arac_tablosu on kiralama_tablosu.arac_id=arac_tablosu.arac_id inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id where musteri_tablosu.tcno='" + kiralayan_tc_combo.Text + "' and kiralama_tablosu.arsiv=1", baglanti);//MÜŞTERİNİN KIRALADIĞI ARAÇLAR
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    kiralanan_arac_combo.Items.Add(oku["Plaka"]);//KİRALANAN ARAÇLARI EKLEME
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
        private void plakalari_getir()
        {
            plaka_combo.Items.Clear();//PLAKALARI SİLME
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(plaka) AS Plaka from arac_tablosu where arsiv=1", baglanti);//PLAKA GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    plaka_combo.Items.Add(oku["Plaka"]);//EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void plaka_sil()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(plaka) AS Plaka from arac_tablosu inner join kiralama_tablosu on arac_tablosu.arac_id=kiralama_tablosu.arac_id where kiralama_tablosu.arsiv=1", baglanti);//KİRALANAN ARAÇLARI SİLME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    plaka_combo.Items.Remove(oku["Plaka"]);//SİLME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void kiralayan_tcleri_getir()
        {
            kiralayan_tc_combo.Items.Clear();//KİRALANAN ARAÇLARIN SİLİNDİ YENİLENME OLURSA DİYE
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select distinct(tcno) from kiralama_tablosu inner join musteri_tablosu on kiralama_tablosu.musteri_id=musteri_tablosu.musteri_id where kiralama_tablosu.arsiv=1", baglanti);//KİRALANAN ARAÇLARI GETİRME
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    kiralayan_tc_combo.Items.Add(oku["tcno"]);//SEÇİM KUTUSUNA EKLEM
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void tcleri_getir()//MÜŞTERİ GETİRME FOKSİYONU
        {
            tc_combo.Items.Clear();//MÜŞTERİLERİ SİLME GÜNCELLEME İÇİN
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(tcno) AS TCNO from musteri_tablosu where arsiv=1", baglanti);//MÜŞTERİ TC GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    tc_combo.Items.Add(oku["TCNO"]);//SEÇİM KUTUSUNA EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void plaka_combo_SelectedIndexChanged(object sender, EventArgs e)
        {//PLAKA SEÇİLDİĞİNDE ÇALIŞIR
            secilen_plaka();//PLAKA HAKKINDA BİLGİ
            fiyat_belirle();//YENİ FİYAT
        }
        private void secilen_plaka()
        {
            try
            {
                arac_bilgi_label.Text = "";//BİLGİLERİ SİLME
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from arac_tablosu where plaka='" + plaka_combo.SelectedItem + "'", baglanti);//PLAKAYA GÖRE ARAÇ BİLGİLERİ GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    arac_id = oku["arac_id"].ToString();//DEĞİŞTİRME SİLME İŞLEMLERİNDE KULLANILIR
                    //PENCEREYE BİLGİ VERME
                    arac_bilgi_label.Text += "Marka:" + oku["marka"].ToString() + "\nModel:" + oku["model"].ToString() + "\nKategori:" + oku["kategori"].ToString() + "\nRenk:" + oku["renk"].ToString() + "\nDepo Doluluk Yüzdesi(%):" + oku["yakit_doluluk_yuzdesi"] + "\nKiloMetre[KM]:" + oku["km"].ToString() + "\nVites Türü:" + oku["vites_turu"].ToString() + "\nKoltuk Sayısı:" + oku["koltuk_sayisi"].ToString() + "\nKapı Sayısı:" + oku["kapi_sayisi"].ToString() + "\nKira Ücreti:" + oku["kira_ucreti"].ToString();
                    if (Convert.ToByte(oku["hasar"]) == 0)
                    {
                        arac_bilgi_label.Text += "\nKaza Durumu:Yok";
                    }
                    else if (Convert.ToByte(oku["hasar"]) == 1)
                    {
                        arac_bilgi_label.Text += "\nKaza Durumu:Var";
                    }
                    arac_bilgi_label.Text += "\nAçıklama:" + oku["aciklama"].ToString();
                    gunluk_arac_kirasi = Convert.ToInt32(oku["kira_ucreti"]);
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void tc_combo_SelectedIndexChanged(object sender, EventArgs e)
        {//TC DEĞİŞTİĞİNDE ÇALIŞIR
            secilen_tc();//SEÇİLEN TC HAKKINDA BİLGİ VERME FOKSİYONU
            geri_alis_tarihi_dt.ResetText();//TARİH SIFIRLANIR
        }
        private void secilen_tc()
        {
            try
            {
                musteri_bilgi_label.Text = "";//BİLGİLER SİLİNİR
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from musteri_tablosu where tcno='" + tc_combo.SelectedItem + "'", baglanti);//TC GÖRE MÜŞTERİ BİLGİLERİ GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    musteri_id = oku["musteri_id"].ToString();//GÜNCELLEME İŞLEMİNDE KULLANILABİLİR
                    //PENCEREYE MÜŞTERİ HAKKINDA BİLGİ VERME
                    musteri_bilgi_label.Text += "TC NO:" + oku["tcno"].ToString() + "\nAd Soyad:" + oku["ad"].ToString() + " " + oku["soyad"].ToString();
                    if (Convert.ToByte(oku["cinsiyet"]) == 0)
                    {
                        musteri_bilgi_label.Text += "\nCinsiyet:Kadın";
                    }
                    else if (Convert.ToByte(oku["cinsiyet"]) == 1)
                    {
                        musteri_bilgi_label.Text += "\nCinsiyet:Erkek";
                    }
                    musteri_bilgi_label.Text += "\nİl/İlçe:" + oku["il"].ToString() + "/" + oku["ilce"].ToString() + "\nCep Telefonu(1):" + oku["cep1"].ToString() + "\nCep Telefonu(2):" + oku["cep2"].ToString() + "\nE-Posta Adresi:" + oku["eposta"].ToString() + "\nEv Adresi:" + oku["adres"].ToString() + "\nEhliyet No/Türü/Tarihi:" + oku["ehliyet_no"].ToString() + "/" + oku["ehliyet_turu"].ToString() + "/" + oku["ehliyet_tarihi"].ToString() + "\nAçıklama:" + oku["aciklama"].ToString();
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void geri_alis_tarihi_dt_ValueChanged(object sender, EventArgs e)
        {//TARİH DEĞİŞTİRKÇE
            fiyat_belirle();//YENİ FIYAT BELİRLEME
        }
        int gun_hesapla = 0;
        private void fiyat_belirle()
        {
            gun_hesapla = Convert.ToInt32((geri_alis_tarihi_dt.Value - kiralama_tarihi_dt.Value).TotalDays);//GÜN SAYISI
           
            if (arac_bilgileri_gb.Enabled == true)//ARAÇ BİLGİRİ GÖZÜKÜYOR MU
            {
                if (gun_hesapla> 0)//GÜN 0 DAN FAZLAMA
                {
                    fiyat_tb.Text = (gunluk_arac_kirasi * gun_hesapla).ToString();//FİYAT BELİRLEME
                }
                else
                {
                    fiyat_tb.Clear();//FİYATI SİLME
                }
            }
            else if (arac_bilgileri_gb.Enabled == false)//ARAÇ BİLGİSİ GÖZÜKÜYOR MU
            {
                if (gun_hesapla > 0)//0 DAN BÜYÜK MU
                {
                    fiyat_tb.Text = (kiralanan_aracin_gunluk_arac_kirasi * gun_hesapla).ToString();//FİYAT HESAPLAMA
                }
                else
                {
                    fiyat_tb.Clear();//FİYAT SİLME
                }
            }
            
        }

        private void kirala_pb_Click(object sender, EventArgs e)
        {
            if (kiralayan_tc_combo.Items.Count > 0 && kiralanan_arac_combo.Items.Count > 0)//MÜŞTERİ ARAÇ VAR MI
            {
                if ((Convert.ToInt32((geri_alis_tarihi_dt.Value - kiralama_tarihi_dt.Value).TotalDays) > 0))//KİRALAMA 1 GÜN VEYA DAHA FAZLA OLMALI
                {
                    if (musteri_degistir_cb.Checked==false && arac_degistir_cb.Checked==false)//MÜŞTERİ VEYA ARAÇ DEĞİŞTİRİLDİMİ
                    {
                        arac_duzenle_ilk_adimlar();//DURUMA GÖRE İŞLEM YAPAN FOKSİYON
                    }
                    else if (musteri_degistir_cb.Checked == true && arac_degistir_cb.Checked == true)//MÜŞTERİ VEYA ARAÇ DEĞİŞTİRİLDİMİ
                    {
                        if (tc_combo.Items.Count > 0 && plaka_combo.Items.Count>0)//MÜŞTERİ VEYA ARAÇ VAR MI
                        {
                            arac_duzenle_ilk_adimlar();//DURUMA GÖRE İŞLEM YAPAN FOKSİYON
                        }
                        else
                        {
                            MessageBox.Show("SEÇMEK İSTEDİĞİNİZ MÜŞTERİ VEYA ARAÇ BULUNAMADIĞI İÇİN DÜZENLEME İŞLEMİ GERÇEKLEŞTİREMEDİ.", "DÜZENLEME İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI BİLGİLENDİRME
                        }
                    }
                    else if (musteri_degistir_cb.Checked == true)//MÜŞTERİ DEĞİŞTİRİLDİMİ
                    {
                        if (tc_combo.Items.Count > 0)//MÜŞTERİ VAR MI
                        {
                            arac_duzenle_ilk_adimlar();//DURUMA GÖRE İŞLEM YAPAN FOKSİYON
                        }
                        else
                        {
                            MessageBox.Show("SEÇMEK İSTEDİĞİNİZ MÜŞTERİ BULUNAMADIĞI İÇİN DÜZENLEME İŞLEMİ GERÇEKLEŞTİREMEDİ.", "DÜZENLEME İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI BİLGİ
                        }
                    }
                    else if (arac_degistir_cb.Checked == true)//ARAÇ DEĞİŞTİRİLDİMİ
                    {
                        if (plaka_combo.Items.Count > 0)//ARAÇ VAR MI
                        {
                            arac_duzenle_ilk_adimlar();//DURUMA GÖRE İŞLEM YAPAN FOKSİYON
                        }
                        else
                        {
                            MessageBox.Show("SEÇMEK İSTEDİĞİNİZ ARAÇ BULUNAMADIĞI İÇİN DÜZENLEME İŞLEMİ GERÇEKLEŞTİREMEDİ.", "DÜZENLEME İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("EN AZ 1 GÜN KİRALANABİLİR.", "TARİH BELİRSİZLİĞİ", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİLENDIRME
                }
            }
            else
            {
                MessageBox.Show("KİRALAYAN MÜŞTERİ VEYA KİRALANAN ARAÇ BULUNAMADIĞI İÇİN DÜZENLEME İŞLEMİ GERÇEKLEŞTİREMEDİ.", "ARAÇ İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI BİLGİSİ
                this.Close();//PENCERE KAPATMA
            }
        }
        private void arac_duzenle_ilk_adimlar()
        {
            arac_duzenle();//ARAÇ BİLGİLERİ DÜZENLEME FOKSİYON
            tcleri_getir();//MÜŞTERİLERİ GETİRME FOKSİYON
            kiralayan_tcleri_getir();//ARAÇ KİRALAYAN MÜŞTERİLERİ GETİRME FOKSİYON
            plakalari_getir();//PLAKALARI GETİRİR FOKSİYON
            plaka_sil();//PLAKA SİLME FOKSİYON
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME FOKSİYON
            musteri_degistir_cb.Checked = arac_degistir_cb.Checked = false;//İŞARETLERİ SIFIRLAMA
        }
        private void arac_duzenle()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                if (musteri_degistir_cb.Checked == false && arac_degistir_cb.Checked == false)//MÜŞTERİ ARAÇ DEĞİŞMEDİĞİ YER
                {
                    komut = new SqlCommand("update kiralama_tablosu set geri_alis_tarihi='" + geri_alis_tarihi_dt.Value.ToShortDateString() + "',odeme_turu='" + odeme_turu_combo.Text + "',fiyat=" + fiyat_tb.Text + " where kiralama_id=" + kiralama_id, baglanti);//MÜŞTERİ ARAÇ HARICI DEĞİŞTİRME KOMUTLARI
                }
                else if (musteri_degistir_cb.Checked == true && arac_degistir_cb.Checked == true)//MÜŞTERİ VE ARAÇ DEĞİŞTİ İSE ÇALIŞIR
                {
                    komut = new SqlCommand("update kiralama_tablosu set musteri_id=" + musteri_id + ",arac_id=" + arac_id + ",geri_alis_tarihi='" + geri_alis_tarihi_dt.Value.ToShortDateString() + "',odeme_turu='" + odeme_turu_combo.Text + "',fiyat=" + fiyat_tb.Text + " where kiralama_id=" + kiralama_id, baglanti);//TÜM BİLGİNİN DEĞİŞTİĞİ YER(MÜŞTERİ ARAÇ DAHİL)
                }
                else if (musteri_degistir_cb.Checked==true)//MÜŞTERİNİN DEĞİŞTİĞİ YER
                {
                    komut = new SqlCommand("update kiralama_tablosu set musteri_id=" + musteri_id + ",geri_alis_tarihi='" + geri_alis_tarihi_dt.Value.ToShortDateString() + "',odeme_turu='" + odeme_turu_combo.Text + "',fiyat=" + fiyat_tb.Text + " where kiralama_id=" + kiralama_id, baglanti);//MÜŞTERİ DAHİL DEĞİŞTİRME KOMUTLARI
                }
                else if (arac_degistir_cb.Checked==true)//ARAÇLARIN DEĞİŞTİĞİ YER
                {
                    komut = new SqlCommand("update kiralama_tablosu set arac_id=" + arac_id + ",geri_alis_tarihi='" + geri_alis_tarihi_dt.Value.ToShortDateString() + "',odeme_turu='" + odeme_turu_combo.Text + "',fiyat=" + fiyat_tb.Text + " where kiralama_id=" + kiralama_id, baglanti);//ARAÇ DAHİL DEĞİŞTİRME KOMUTLARI
                }
                komut.ExecuteNonQuery();//KOMUTLARIN ÇALIŞTIĞI YER
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show("KİRALAMA BİLGİLERİ BAŞARILI BİR ŞEKİLDE DÜZENLENDİ.", "KİRALAMA BİLGİLERİNİ DÜZENLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            secilen_tc_bilgi();//SEÇİLEN PLAKA HAKKINDA BİLGİ VERME
            arac_degistir_cb.Checked = false;//ARAÇ DEĞİŞTİRMEYİ İŞARETLEMEYİ KALDIRMA
            tc_degistiginde_uygula();//ARAÇ BİLGİLERİNİN GÖSTERİLİP GÖSTERİLMEYECEĞİ FOKSİYON
        }

        private void secilen_tc_bilgi()//SEÇİLEN MÜŞTERİ TC HAKKINDA BİLGİ VERME FOKSİYON
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from musteri_tablosu where tcno='" + kiralayan_tc_combo.SelectedItem + "'", baglanti);//TC GÖRE BİLGİLERİ ÇEKME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    kiralayan_musteri_id = oku["musteri_id"].ToString();//İŞLEMLERDE KULLLANILIR
                    //BİLGİLERİ KULLANICIYA GÖSTERME İŞLEMLERİ
                    if (Convert.ToByte(oku["cinsiyet"]) == 0)
                    {
                        secilen_tcye_ait_bilgiler = "TC NO:" + oku["tcno"].ToString() + "\nAd Soyad:" + oku["ad"].ToString() + " " + oku["soyad"].ToString() + "\nCinsiyet:Kadın" + "\nİl/İlçe:" + oku["il"].ToString() + "/" + oku["ilce"].ToString() + "\nCep Telefonu(1):" + oku["cep1"].ToString() + "\nCep Telefonu(2):" + oku["cep2"].ToString() + "\nE-Posta Adresi:" + oku["eposta"].ToString() + "\nEv Adresi:" + oku["adres"].ToString() + "\nEhliyet No/Türü/Tarihi:" + oku["ehliyet_no"].ToString() + "/" + oku["ehliyet_turu"].ToString() + "/" + oku["ehliyet_tarihi"].ToString() + "\nAçıklama:" + oku["aciklama"].ToString();
                    }
                    else if (Convert.ToByte(oku["cinsiyet"]) == 1)
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
            MessageBox.Show(secilen_tcye_ait_bilgiler, "MÜŞTERİ BİLGİLERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);//MÜŞTERİ HAKKINDA BİLGİ VERME
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
            kiralanan_secilen_plaka();//SEÇİLEN PLAKA HAKINDA BİLGİ VERME FOKSİYONU
        }
        private void kiralanan_secilen_plaka()//SEÇİLEN PLAKA HAKINDA BİLGİ VERME FOKSİYONU
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from arac_tablosu where plaka='" + kiralanan_arac_combo.SelectedItem + "'", baglanti);//SEÇİLEN PLAKA HAKKINDA BİLGİ
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    kiralanan_arac_id = oku["arac_id"].ToString();//İŞLEMLERDE KULLANILIR
                    //KULLANICIYA BİLGİ VERME İŞLEMLERİ
                    if (Convert.ToByte(oku["hasar"]) == 0)
                    {
                        secilen_plakaya_ait_bilgiler = "Plaka No:" + oku["plaka"].ToString() + "\nMarka:" + oku["marka"].ToString() + "\nModel:" + oku["model"].ToString() + "\nKategori:" + oku["kategori"].ToString() + "\nRenk:" + oku["renk"].ToString() + "\nDepo Doluluk Yüzdesi(%):" + oku["yakit_doluluk_yuzdesi"] + "\nKiloMetre[KM]:" + oku["km"].ToString() + "\nVites Türü:" + oku["vites_turu"].ToString() + "\nKoltuk Sayısı:" + oku["koltuk_sayisi"].ToString() + "\nKapı Sayısı:" + oku["kapi_sayisi"].ToString() + "\nKira Ücreti:" + oku["kira_ucreti"].ToString() + "\nKaza Durumu:Yok" + "\nAçıklama:" + oku["aciklama"].ToString();
                    }
                    else if (Convert.ToByte(oku["hasar"]) == 1)
                    {
                        secilen_plakaya_ait_bilgiler = "Plaka No:" + oku["plaka"].ToString() + "\nMarka:" + oku["marka"].ToString() + "\nModel:" + oku["model"].ToString() + "\nKategori:" + oku["kategori"].ToString() + "\nRenk:" + oku["renk"].ToString() + "\nDepo Doluluk Yüzdesi(%):" + oku["yakit_doluluk_yuzdesi"] + "\nKiloMetre[KM]:" + oku["km"].ToString() + "\nVites Türü:" + oku["vites_turu"].ToString() + "\nKoltuk Sayısı:" + oku["koltuk_sayisi"].ToString() + "\nKapı Sayısı:" + oku["kapi_sayisi"].ToString() + "\nKira Ücreti:" + oku["kira_ucreti"].ToString() + "\nKaza Durumu:Var" + "\nAçıklama:" + oku["aciklama"].ToString();
                    }
                    kiralanan_aracin_gunluk_arac_kirasi = Convert.ToInt32(oku["kira_ucreti"]);
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from kiralama_tablosu where arac_id=" + kiralanan_arac_id + " and arsiv=1", baglanti);//ARAÇ İD GÖRE BİLGİLERİ ALMA
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    kiralama_id = oku["kiralama_id"].ToString();//İŞLEMLERDE KULLANILACAK
                    kiralama_tarihi_dt.Value = Convert.ToDateTime(oku["kiralama_tarihi"]);//DT EKLEME
                    geri_alis_tarihi_bilgisi = Convert.ToDateTime(oku["geri_alis_tarihi"]);//DT EKLEME
                    odeme_turu_combo.SelectedIndex = odeme_turu_combo.Items.IndexOf(oku["odeme_turu"]);//ÖDEME TÜRÜNÜ SEÇTİRME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                geri_alis_tarihi_dt.Value = geri_alis_tarihi_bilgisi;//DT BİLGİSİ
                geri_alis_tarihi_dt.MinDate = Convert.ToDateTime(kiralama_tarihi_dt.Value.ToShortDateString()).AddDays(1);//1 GÜN EKLEME
                fiyat_belirle();//YENİ FİYAT BELİRLEME

            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void kiranalan_arac_pb_Click(object sender, EventArgs e)
        {
            MessageBox.Show(secilen_plakaya_ait_bilgiler, "ARAÇ BİLGİLERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);//ARAÇ HAKKINDA BİLGİ VERME
        }

        private void kiranalan_arac_pb_MouseMove(object sender, MouseEventArgs e)
        {
            kiranalan_arac_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi2.png");//GÖRSEL EFEKT
        }

        private void kiranalan_arac_pb_MouseLeave(object sender, EventArgs e)
        {
            kiranalan_arac_pb.Image = Image.FromFile(@"image\yuvarlak_bilgi1.png");//VARSAYILAN GÖRSEL
        }

        private void musteri_degistir_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (musteri_degistir_cb.Checked == true)//MÜŞTERİ İŞARETLİ İSE
            {
                musteri_bilgileri_gb.Enabled = true;//MÜŞTERİ BİLGİLERİ GÖSTER
                kiralayan_tc_combo.Enabled = false;//MÜŞTERİ TC KUTUSUNU KULLANILMAZ YAP
            }
            else if (musteri_degistir_cb.Checked == false)
            {
                musteri_bilgileri_gb.Enabled = false;//MÜŞTERİ BİLGİLERİ GİZLE
                kiralayan_tc_combo.Enabled = true;//MÜŞTERİ TC KUTUSUNU KULLANILIR YAP
            }
        }

        private void arac_degistir_cb_CheckedChanged(object sender, EventArgs e)
        {
            tc_degistiginde_uygula();//ARAÇ BİLGİLERİNİN GÖSTERİLİP GÖSTERİLMEYECEĞİ FOKSİYON
        }
        private void tc_degistiginde_uygula()
        {
            if (arac_degistir_cb.Checked == true)//ARAÇ DEĞİŞTİRME İŞARETLİ İSE
            {
                arac_bilgileri_gb.Enabled = true;//ARAÇ BİLGİLERİ GÖSTERİR
                kiralanan_arac_combo.Enabled = false;//KİRALANAN ARAÇ SEÇİM KUTUSUNU KULLANDIRMAZ
            }
            else if (arac_degistir_cb.Checked == false)//ARAÇ DEĞİŞTİRME İŞARETLİ DEĞİL İSE
            {
                arac_bilgileri_gb.Enabled = false;//ARAÇ BİLGİLERİ GİZLER
                kiralanan_arac_combo.Enabled = true;//KİRALANAN ARAÇ SEÇİM KUTUSUNU KULLANDIRILIR
            }
            fiyat_belirle();//YENİ FİYAT BELİRLENİR
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

        private void kirala_pb_MouseMove(object sender, MouseEventArgs e)
        {
            kirala_pb.Image = Image.FromFile(@"image\kiralama_islemleri_duzenle2.png");//GÖRSEL EFEKT
        }

        private void kirala_pb_MouseLeave(object sender, EventArgs e)
        {
            kirala_pb.Image = Image.FromFile(@"image\kiralama_islemleri_duzenle1.png");//VARSAYILAN GÖRSEL
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESINI AÇMA
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
