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
    public partial class kiralama_islemleri : Form
    {
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        string arac_id = "", musteri_id = "";//KİRALAMA İŞLEMİNDE KULLANILAN ADI DEĞİŞKENLERI
        public kiralama_islemleri()
        {
            InitializeComponent();
        }

        private void kiralama_islemleri_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            plakalari_getir();//PLAKALARI GETİRİR
            plaka_sil();//PLAKALARI SİLME
            tcleri_getir();//MÜŞTERİLERİ GETİRME
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
            tc_no_pb.Image = Image.FromFile(@"image\kullanici.png");
            plaka_pb.Image = Image.FromFile(@"image\plakano.png");
            kiralama_tarihi_pb.Image = Image.FromFile(@"image\tarih.png");
            geri_alis_tarihi_pb.Image = Image.FromFile(@"image\tarih.png");
            odeme_turu_pb.Image = Image.FromFile(@"image\yontem.png");
            fiyat_pb.Image = Image.FromFile(@"image\tl.png");

            kirala_pb.Image = Image.FromFile(@"image\kiralama_islemleri1.png");
            arac_kirala_menu.Image = Image.FromFile(@"image\ekle.png");
            arac_kirala_sagtik.Image = Image.FromFile(@"image\ekle.png");
            iptalet_pb.Image = Image.FromFile(@"image\kiralama_iptal_et1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");

            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");

            tc_no_pb.SizeMode = kirala_pb.SizeMode = fiyat_pb.SizeMode = kiralama_tarihi_pb.SizeMode = geri_alis_tarihi_pb.SizeMode = iptalet_pb.SizeMode = plaka_pb.SizeMode = odeme_turu_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU

            kiralama_tarihi_dt.Enabled = false;//DEĞİŞTİREMEZ TARİH
            geri_alis_tarihi_dt.MinDate = DateTime.Now;//GELİ ALIŞ TARİHİ BELİRLEME
            geri_alis_tarihi_dt.MaxDate = DateTime.Today.AddMonths(1);//1 AY EN FAZLA KİRALAMA İZNİ
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            if (plaka_combo.Items.Count > 0)
            {
                plaka_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
            if (tc_combo.Items.Count > 0)
            {
                tc_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
            //ÖDEME TÜRLERİ
            odeme_turu_combo.Items.Clear();
            odeme_turu_combo.Items.Add("PEŞİN");
            odeme_turu_combo.Items.Add("TAKSİT");
            odeme_turu_combo.Items.Add("HAVALE-EFT");
            odeme_turu_combo.Items.Add("ANLAŞMALI");
            odeme_turu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            if (tc_combo.Items.Count==0)//TC YOKSA SİL
            {
                musteri_bilgi_label.Text = "";
            }
            if (plaka_combo.Items.Count == 0)//PLAKA YOKSA SİL
            {
                arac_bilgi_label.Text = "";
            }
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI SORUNLARI DÜZENLEME
            arac_bilgileri_gb.ForeColor = kiralama_bilgileri_gb.ForeColor = musteri_bilgileri_gb.ForeColor = this.ForeColor;
        }
        private void plakalari_getir()//SİSTEM OLAN ARÇALARI GETİRME
        {
            plaka_combo.Items.Clear();
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(plaka) AS Plaka from arac_tablosu where arsiv=1", baglanti);//PLAKA KODLARI
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    plaka_combo.Items.Add(oku["Plaka"]);//SEÇİM KUTUSUNA PLAKALARA EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void plaka_sil()//KİRALANAN ARAÇLARI SİLEN FOKSİYON
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(plaka) AS Plaka from arac_tablosu inner join kiralama_tablosu on arac_tablosu.arac_id=kiralama_tablosu.arac_id where kiralama_tablosu.arsiv=1", baglanti);//KİRALANAN ARAÇLARIN KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUNUYOR
                {
                   plaka_combo.Items.Remove(oku["Plaka"]);//KİRALANAN ARAÇLARI SİLME
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

        private void tcleri_getir()
        {
            tc_combo.Items.Clear();//TC SİLME
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(tcno) AS TCNO from musteri_tablosu where arsiv=1", baglanti);//MÜŞTERİLERİ GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUNUYOR
                {
                    tc_combo.Items.Add(oku["TCNO"]);//TC EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
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
            iptalet_pb.Image = Image.FromFile(@"image\kiralama_iptal_et2.png");//GÖRSLE EFEKT
        }

        private void iptalet_pb_MouseLeave(object sender, EventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\kiralama_iptal_et1.png");//VARSAYILAN GÖRSELLER
        }

        private void kirala_pb_Click(object sender, EventArgs e)
        {
            if (tc_combo.Items.Count > 0 && plaka_combo.Items.Count > 0)//MÜŞTERİ ARAÇ VAR İSE
            {
                if ((gunluk_arac_kirasi * Convert.ToInt32((geri_alis_tarihi_dt.Value - kiralama_tarihi_dt.Value).TotalDays)>0))//EN AZ 1 GÜNLÜK KİRALANDI MI
                {
                    arac_kiralandi();//ARAÇI KİRALAMA
                    plaka_sil();//KİRALANDIĞI İÇİN PLAKA SİLİNİYOR MÜŞTERİ SİLİNMEZ BİRDEN FAZLA ARAÇ ALABİLİR ÇÜNKÜ
                }
                else
                {
                    MessageBox.Show("EN AZ 1 GÜN KİRALANABİLİR.", "TARİH BELİRSİZLİĞİ", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA 1 GÜNLÜK KIRALAMA
                }            
            }
            else
            {
                MessageBox.Show("MÜŞTERİ VEYA ARAÇ BULUNAMADIĞI İÇİN KİRALAMA İŞLEMİ GERÇEKLEŞTİREMEDİ.", "ARAÇ İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI BİLGİ
                this.Close();//PENCEREYI KAPATMA
            }
        }
        private void arac_kiralandi()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("insert into kiralama_tablosu(musteri_id,arac_id,kiralama_tarihi,geri_alis_tarihi,odeme_turu,fiyat,arsiv) values(" + musteri_id + "," + arac_id + ",'" + kiralama_tarihi_dt.Value.ToShortDateString() + "','" + geri_alis_tarihi_dt.Value.ToShortDateString() + "','" + odeme_turu_combo.Text + "'," + fiyat_tb.Text + ",1)", baglanti);//KİRALAMA İŞLEMLERİ KOMUTU
                komut.ExecuteNonQuery();//KOMUTU ÇALIŞTIRMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show("KİRALAMA İŞLEMİ BAŞARILI BİR ŞEKİLDE GERÇEKLEŞTI.", "KİRALAMA İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);//BİLGİ VERME

            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void kirala_pb_MouseMove(object sender, MouseEventArgs e)
        {
            kirala_pb.Image = Image.FromFile(@"image\kiralama_islemleri2.png");//GÖRSLE EFEKT
        }

        private void kirala_pb_MouseLeave(object sender, EventArgs e)
        {
            kirala_pb.Image = Image.FromFile(@"image\kiralama_islemleri1.png");//VARSAYILAN GÖRSEL
        }

        private void tc_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilen_tc();//TC HAKKINDA BİLGİ VERİR
            geri_alis_tarihi_dt.ResetText();//TARİHİ SIFIRLAR
        }
        private void secilen_tc()
        {
            try
            {
                musteri_bilgi_label.Text = "";
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from musteri_tablosu where tcno='" + tc_combo.SelectedItem + "'", baglanti);//SEÇİLEN TC HAKKINDA BİLGİ KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    musteri_id = oku["musteri_id"].ToString();//İŞLEMLER İÇİN SAKLANIR
                    //MÜŞTERİ HAKKINDA BİLGİ VERİR..
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

        private void plaka_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilen_plaka();//SEÇİLEN PLAKA HAKKINDA BİLGİ VEREN FOKSİYON
            geri_alis_tarihi_dt.ResetText();//TARİHİ SIFIRLAR
        }
        int gunluk_arac_kirasi;
        private void secilen_plaka()
        {
            try
            {
                arac_bilgi_label.Text = "";//YAZIYI SIFIRLAMA
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from arac_tablosu where plaka='" + plaka_combo.SelectedItem + "'", baglanti);//PLAKAYA GÖRE BİLGİLENDİRME
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    arac_id = oku["arac_id"].ToString();//BİLGİYİ SAKLAYARAK KULLANILIR
                    //BİLGİLENDİRME İŞLEMLERİ
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

        private void kiralama_tarihi_dt_ValueChanged(object sender, EventArgs e)
        {//TARİH DEĞİŞTİĞİNDE FİYAT İŞLEMLERİ UYGULANIR
            fiyat_belirle();//FİYAT BELİRLEME FOKSİYONU
        }
        private void fiyat_belirle()
        {
            if ((geri_alis_tarihi_dt.Value - kiralama_tarihi_dt.Value).TotalDays > 0)//KİRALAM GÜNÜ 1 VE 1 DEN FAZLA OLMALI
            {
                fiyat_tb.Text = (gunluk_arac_kirasi * Convert.ToInt32((geri_alis_tarihi_dt.Value - kiralama_tarihi_dt.Value).TotalDays)).ToString();//FİYAT BELİRLEME VE GÖSTERME
            }
            else
            {
                fiyat_tb.Clear();//FİYATI SİLME
            }
        }

        private void geri_alis_tarihi_dt_ValueChanged(object sender, EventArgs e)
        {
            fiyat_belirle();//FİYAT BELİRLEME FOKSİYONU
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM ET FOKSİYONU
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
