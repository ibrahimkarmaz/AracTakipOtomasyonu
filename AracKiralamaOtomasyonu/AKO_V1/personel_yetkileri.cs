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
    public partial class personel_yetkileri : Form
    {
        public personel_yetkileri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        SqlDataReader oku;//VERİ ÇEKİLME İŞLEMİ VARSA KULLANILAN KOMUTLERDEN BİRİSİ
        private void personel_yetkileri_Load(object sender, EventArgs e)
        {
            tcleri_getir();//PERSONELLERI GETİRME
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
            yetkilendir_pb.Image = Image.FromFile(@"image\personel_yetki1.png");
            yetki_duzenle_menu.Image = Image.FromFile(@"image\onayla1.png");
            yetki_duzenle_sagtik.Image = Image.FromFile(@"image\onayla1.png");
            iptalet_pb.Image = Image.FromFile(@"image\personel_yetki_iptal_et1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");

            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");

            yetki_turu_pb.Image = Image.FromFile(@"image\yontem.png");
            personel_yetkileri_pb.Image = Image.FromFile(@"image\personel.png");
            tc_pb.Image = Image.FromFile(@"image\kullanici.png");

            yetkilendir_pb.SizeMode = iptalet_pb.SizeMode =yetki_turu_pb.SizeMode=personel_yetkileri_pb.SizeMode=tc_pb.SizeMode= PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {//YETKİ TÜRLERİ
            yetki_turu_combo.Items.Add("ARAÇ İŞLEMLERİ");
            yetki_turu_combo.Items.Add("MÜŞTERİ İŞLEMLERİ");
            yetki_turu_combo.Items.Add("KİRALAMA İŞLEMLERİ");
            yetki_turu_combo.Items.Add("ARŞİV VE İSTATİSTİK İŞLEMLERİ");
            yetki_turu_combo.Items.Add("TÜM İŞLEMLER");
            yetki_turu_combo.SelectedIndex = yetki_turu_combo.Items.Count - 1;

            bilgi_label.Text = "";
            if (tc_combo.Items.Count > 0)
            {
                tc_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
            }
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI SORUNLARI DÜZENLEME
            personel_gb.ForeColor = yetkilendir_gb.ForeColor = this.ForeColor;
            yeni_yetki_btn.ForeColor = yetki_birak_btn.ForeColor = Color.Black;
        }
        private void tcleri_getir()//PERSONELLERİ GETİRME
        {
            tc_combo.Items.Clear();
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(tcno) AS TCNO from personel_tablosu where arsiv=1", baglanti);//PERSONEL TCLERİ GETİRME KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//OKUMA
                {
                    tc_combo.Items.Add(oku["TCNO"]);//EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        string tcno="";//SEÇİLEN TC HAKKINDA BİLGİLERİ SAKLAR
        
        private void yetki_turu_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            yetkilerin_listesi_list.Items.Clear();//YETKİLERİ TEMİZLER
            if (yetki_turu_combo.Text == "ARAÇ İŞLEMLERİ")//YETKİ TÜRLERİ
            {
                yetkilerin_listesi_list.Items.Add("ARAÇ ARAMA");
                yetkilerin_listesi_list.Items.Add("ARAÇ EKLE");
                yetkilerin_listesi_list.Items.Add("ARAÇ BİLGİLERİNİ DÜZENLEME");
                yetkilerin_listesi_list.Items.Add("ARAÇ ÇIKAR");
                yetkilerin_listesi_list.Items.Add("ARAÇ LİSTESİ");
            }
            else if (yetki_turu_combo.Text == "MÜŞTERİ İŞLEMLERİ")//YETKİ TÜRLERİ
            {
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ ARAMA");
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ EKLE");
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ BİLGİLERİNİ DÜZENLEME");
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ ÇIKAR");
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ LİSTESİ");
            }
            else if (yetki_turu_combo.Text == "KİRALAMA İŞLEMLERİ")//YETKİ TÜRLERİ
            {
                yetkilerin_listesi_list.Items.Add("TESLİM AL");
                yetkilerin_listesi_list.Items.Add("KİRALAMA İŞLEMLERİ ARAMA");
                yetkilerin_listesi_list.Items.Add("KİRALAMA İŞLEMLERİ");
                yetkilerin_listesi_list.Items.Add("KİRALAMA BİLGİLERİNİ DÜZENLEME");
                yetkilerin_listesi_list.Items.Add("KİRALAMA İŞLEMİNİ İPTAL ET");
            }
            else if (yetki_turu_combo.Text == "ARŞİV VE İSTATİSTİK İŞLEMLERİ")//YETKİ TÜRLERİ
            {
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ ARŞİVİ");
                yetkilerin_listesi_list.Items.Add("ARAÇ ARŞİVİ");
                yetkilerin_listesi_list.Items.Add("KİRALAMA ARŞİVİ");
                yetkilerin_listesi_list.Items.Add("İSTATİSTİK");
            }
            else if (yetki_turu_combo.Text == "TÜM İŞLEMLER")//TÜM YETKİLER
            {
                yetkilerin_listesi_list.Items.Add("ARAÇ ARAMA");
                yetkilerin_listesi_list.Items.Add("ARAÇ EKLE");
                yetkilerin_listesi_list.Items.Add("ARAÇ BİLGİLERİNİ DÜZENLEME");
                yetkilerin_listesi_list.Items.Add("ARAÇ ÇIKAR");
                yetkilerin_listesi_list.Items.Add("ARAÇ LİSTESİ");
                yetkilerin_listesi_list.Items.Add("TESLİM AL");
                yetkilerin_listesi_list.Items.Add("KİRALAMA İŞLEMLERİ ARAMA");
                yetkilerin_listesi_list.Items.Add("KİRALAMA İŞLEMLERİ");
                yetkilerin_listesi_list.Items.Add("KİRALAMA BİLGİLERİNİ DÜZENLEME");
                yetkilerin_listesi_list.Items.Add("KİRALAMA İŞLEMİNİ İPTAL ET");
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ ARAMA");
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ EKLE");
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ BİLGİLERİNİ DÜZENLEME");
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ ÇIKAR");
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ LİSTESİ");
                yetkilerin_listesi_list.Items.Add("MÜŞTERİ ARŞİVİ");
                yetkilerin_listesi_list.Items.Add("ARAÇ ARŞİVİ");
                yetkilerin_listesi_list.Items.Add("KİRALAMA ARŞİVİ");
                yetkilerin_listesi_list.Items.Add("İSTATİSTİK");
            }
            birincisecimkutusundakibilgilerisil();//YETKİLER SİLME
        }
        private void birincisecimkutusundakibilgilerisil()
        {
            for (int i = 0; i < personel_yetkileri_list.Items.Count; i++)//PERSONEL YETKİLERİ LİSTESİ KONTROL EDİLİR EĞER VARSA YETKİLER LİSTESİNDEN SİLME İŞLEMİ YAPAR
            {
                if (yetkilerin_listesi_list.Items.Contains(personel_yetkileri_list.Items[i]) != false)//YETKİ VAR MI
                {
                    yetkilerin_listesi_list.Items.Remove(personel_yetkileri_list.Items[i]);//SİLİNME
                }
            }
        }

        private void yeni_yetki_btn_Click(object sender, EventArgs e)
        {
            if (yetkilerin_listesi_list.Text != "")//YETKİLER LİSTESİNDEN SEÇİLİ Mİ ?
            {
                personel_yetkileri_list.Items.Add(yetkilerin_listesi_list.Items[yetkilerin_listesi_list.SelectedIndex]);//YETKİYİ PERSONELE AKTARILIR
                yetkilerin_listesi_list.Items.RemoveAt(yetkilerin_listesi_list.SelectedIndex);//VE YETKİLER LİSTESİNDEN SİLİNİR
            }
            else
            {
                MessageBox.Show("YENİ YETKİ SEÇİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//BİLGİ VERİLİR
            }
        }

        private void yetki_birak_btn_Click(object sender, EventArgs e)
        {
            if (personel_yetkileri_list.Text != "")//PERSONEL YETKİLERİ SEÇİLİ Mİ
            {
                yetkilerin_listesi_list.Items.Add(personel_yetkileri_list.Items[personel_yetkileri_list.SelectedIndex]);//SEÇİLEN YETKİLERİ BİRAKMA
                personel_yetkileri_list.Items.RemoveAt(personel_yetkileri_list.SelectedIndex);//SİLME
            }
            else
            {
                MessageBox.Show("BİRAKMAK İÇİN VAR OLAN YETKİNİZİ SEÇİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SEÇME UYARISI
            }
        }
      

        private void tc_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilen_tc();//SEÇİLEN PERSONEL TC HAKKINDA BİLGİ VERME
        }
        string yetkileri_kaydet = "";//YETKİLERİ KAYDETME DEĞİŞKENİ
        private void secilen_tc()
        {
            try
            {
                bilgi_label.Text = "";//BİLGİLERİ YAZDIMAK İÇİN KULLANILAN BİRLEŞTİRME DEĞİŞKENI
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select * from personel_tablosu where tcno='" + tc_combo.SelectedItem + "'", baglanti);//PERSONEL BİLGİ KOMUTU
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    tcno = oku["tcno"].ToString();//TC SAKLAMA
                    bilgi_label.Text += "TC NO:" + oku["tcno"].ToString() + "\nAd Soyad:" + oku["ad"].ToString() + " " + oku["soyad"].ToString();//BİLGİLERİ GÖSTERME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                yetkileri_kaydet = "";
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("select RTRIM(yetkiler) as Yetkiler from personel_yetkileri where tcno='" + tc_combo.SelectedItem + "'", baglanti);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                if (oku.Read())//EĞER VERİLER OKUNUYORSA DOĞRU BLOĞUNA GİRER.
                {
                    yetkileri_kaydet = oku["Yetkiler"].ToString();//YETKİLERİ EKLEME
                }
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                yetkileri_goster();//YETKİLERİ GÖSTERİR
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }
        private void yetkileri_goster()
        {
            personel_yetkileri_list.Items.Clear();//TÜM YETKİLERİ SİLER
            yetkilerin_listesi_list.Items.Clear();//TÜM YETKİLERİ SİLER
            yetki_turu_combo.SelectedIndex = yetki_turu_combo.Items.Count - 2;//YETKİ SEÇER
            yetki_turu_combo.SelectedIndex = yetki_turu_combo.Items.Count - 1;//YETKİ SEÇER
            foreach (string vt_personelin_yetkileri in yetkileri_kaydet.Split('-'))//YETKİLERİ AYIRIP LİSTEYE EKLEME İŞLEMLERI
            {
                personel_yetkileri_list.Items.Add(yetkilerin_listesi_list.Items[yetkilerin_listesi_list.Items.IndexOf(vt_personelin_yetkileri)]);
                yetkilerin_listesi_list.Items.RemoveAt(yetkilerin_listesi_list.Items.IndexOf(vt_personelin_yetkileri));
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
            iptalet_pb.Image = Image.FromFile(@"image\personel_yetki_iptal_et2.png");//GÖRSEL EFEKT
        }

        private void iptalet_pb_MouseLeave(object sender, EventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\personel_yetki_iptal_et1.png");//VARSAYILAN GÖRSEL
        }

        private void yetkilendir_pb_Click(object sender, EventArgs e)
        {
            if (personel_yetkileri_list.Items.Count>=3)//EN AZ 3 YETKİ BULUNMALI
            {
                yetkileri_kaydet = "";
                for (int i = 0; i < personel_yetkileri_list.Items.Count; i++)
                {
                    yetkileri_kaydet += personel_yetkileri_list.Items[i];//YETKİLERİ KAYDETME
                    if (personel_yetkileri_list.Items.Count - 1 != i)
                    {
                        yetkileri_kaydet += "-";//AYIRMA
                    }
                }
                yetkileri_duzenle();//DÜZENLEME
            }
            else
            {
                MessageBox.Show("EN AZ 3 YETKİ GEREKMEKTEDİR...", "YETKİ UYARISI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//UYARI
            }
           
        }
        
        private void yetkileri_duzenle()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("update personel_yetkileri set yetkiler='"+yetkileri_kaydet+"' where tcno='"+tc_combo.Text+"'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(tc_combo.SelectedItem + " TC NOLU PERSONELİN YETKİLERİ DÜZENLENDI.", "PERSONEL YETKİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void yetkilendir_pb_MouseMove(object sender, MouseEventArgs e)
        {
            yetkilendir_pb.Image = Image.FromFile(@"image\personel_yetki2.png");//GÖRSEL EFEKT
        }

        private void yetkilendir_pb_MouseLeave(object sender, EventArgs e)
        {
            yetkilendir_pb.Image = Image.FromFile(@"image\personel_yetki1.png");//VARSAYILAN GÖRSEL
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PENCERESINI AÇMA
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }
    }
}
