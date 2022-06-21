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
    public partial class arac_arama : Form
    {
        public arac_arama()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlDataAdapter Komutlar;//TABLOLARIN ÇEKİLMESİNDE KULLANILAN KOMUT
        DataSet veriseti = new DataSet();//ÇEKİLEN TABLOLARI SAKLAMAK İÇİN GEREK KOMUT
        string aranacak_alan = "", aranacak_bilgi = "", gosterme_adeti = "", sql_kod = "select * from arac_tablosu where arsiv=1";//SIRASIYLA ALAN ADI,KULLANICININ YAZDIĞI BİLGİ,GÖSTERM ADETİ,SQL KOMUTU(SQL KOMUTU DEĞİŞKENDİR)
        private void arac_arama_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            kisitlamalar_ve_duzenlemeler();//NESNELERI KISITLAMA VE DÜZENLEME
            arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME//ARAMA YAPIP TABLODA GÖSTERME
            arama_sonrasi_duzen();//ADLARI GENİŞLİK VB AYARLAYAN FOKSİYON
            if (ana_pencere.renkler_uygulanacakmi==true)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void fotograflari_al_ve_duzenle()
        {
            //GÖRSELLER
            konu_pb.Image = Image.FromFile(@"image\kullanici.png");
            ara_pb.Image = Image.FromFile(@"image\arama1.png");
            ilk_pb.Image = Image.FromFile(@"image\liste_ilk.png");
            tumunu_listele_pb.Image = Image.FromFile(@"image\arac_listesi1.png");

            arac_ara_menu.Image = Image.FromFile(@"image\arama1.png");
            arac_ara_sagtik.Image = Image.FromFile(@"image\arama1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            gelismis_arama_menu.Image = Image.FromFile(@"image\yukari.png");
            gelismis_arama_sagtik.Image = Image.FromFile(@"image\yukari.png");
            otomatik_arama_menu.Image = Image.FromFile(@"image\otomatik_arama.png");
            otomatik_arama_sagtik.Image = Image.FromFile(@"image\otomatik_arama.png");
            listeleme_islemleri_menu.Image = Image.FromFile(@"image\liste.png");
            listeleme_islemleri_sagtik.Image = Image.FromFile(@"image\liste.png");
            listeleme_belirle_menu.Image = Image.FromFile(@"image\arac_listesi1.png");
            listeleme_belirle_sagtik.Image = Image.FromFile(@"image\arac_listesi1.png");
            hepsini_listele_menu.Image = Image.FromFile(@"image\arac_listesi1.png");
            hepsini_listele_sagtik.Image = Image.FromFile(@"image\arac_listesi1.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");
            
            //GÖRSELLERİN SIĞDIRMA İŞLEMLERİ
            konu_pb.SizeMode = ara_pb.SizeMode = ilk_pb.SizeMode = tumunu_listele_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void kisitlamalar_ve_duzenlemeler()
        {
            //ARAMA İŞLEMLERİ VE SEÇİMİ
            konu_combo.Items.Add("PLAKA NUMARASINA GÖRE");
            konu_combo.Items.Add("MARKAYA GÖRE");
            konu_combo.Items.Add("KİRA ÜCRETİNE GÖRE");
            konu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 

            //KAÇ SATIR GÖSTERİLECEĞİ(MENU VE SAĞTIK MENULER DAHİL EDİLDİ)
            ilk_combo.Items.Add("1");
            ilk_combo.Items.Add("5");
            for (int i = 10; i <= 100; i += 10)
            {
                ilk_combo.Items.Add(i.ToString());
            }
            ilk_combo.Items.Add("HEPSİ");

            ilk_belirle_combo.Items.Add("1");
            ilk_belirle_combo.Items.Add("5");
            for (int i = 10; i <= 100; i += 10)
            {
                ilk_belirle_combo.Items.Add(i.ToString());
            }
            ilk_belirle_combo.Items.Add("HEPSİ");

            ilk_belirle_combo_sagtik.Items.Add("1");
            ilk_belirle_combo_sagtik.Items.Add("5");
            for (int i = 10; i <= 100; i += 10)
            {
                ilk_belirle_combo_sagtik.Items.Add(i.ToString());
            }
            ilk_belirle_combo_sagtik.Items.Add("HEPSİ");
            ilk_combo.SelectedIndex = ilk_combo.Items.Count - 1;//Diğerleri değişe bilir ama son eleman "hepsi" değişmez.
            ilk_belirle_combo.SelectedIndex = ilk_belirle_combo.Items.Count - 1;
            ilk_belirle_combo_sagtik.SelectedIndex = ilk_belirle_combo.Items.Count - 1;
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDİRME SORUNLARINI GİDERME
            arama_islemleri_gb.ForeColor = this.ForeColor;
            tablolari_listele_dgv.ForeColor = Color.Black;
            tablolari_listele_dgv.BackgroundColor = this.BackColor;
        }
        private void gelismis_arama_secenekleri_cb_CheckedChanged(object sender, EventArgs e)
        {
            konu_combo.Items.Clear();//ARAMALERİ YENİLEME İÇİN SİLİNİR
            if (gelismis_arama_secenekleri_cb.Checked == true)
            {//DAHA FAZLA ARAMA İÇİN
                konu_combo.Items.Add("PLAKA NUMARASINA GÖRE");
                konu_combo.Items.Add("MARKAYA GÖRE");
                konu_combo.Items.Add("MODELE GÖRE");
                konu_combo.Items.Add("ARAÇ YILANA GÖRE");
                konu_combo.Items.Add("ARAÇ RENGİNE GÖRE");
                konu_combo.Items.Add("KATEGORİYE GÖRE");
                konu_combo.Items.Add("KİLOMETRESİNE GÖRE");
                konu_combo.Items.Add("YAKİT TÜRÜNE GÖRE");
                konu_combo.Items.Add("VİTES TÜRÜNE GÖRE");
                konu_combo.Items.Add("KİRA ÜCRETİNE GÖRE");
            }
            else
            {//VARSAYİLAN ARAMALAR İÇİN
                konu_combo.Items.Add("PLAKA NUMARASINA GÖRE");
                konu_combo.Items.Add("MARKAYA GÖRE");
                konu_combo.Items.Add("KİRA ÜCRETİNE GÖRE");
            }
            konu_combo.SelectedIndex = 0;//SEÇİM KUTUSUNDAKİ 1.SIRADAKI VERİYİ SEÇME 
        }

        private void otomatik_arama_cb_CheckedChanged(object sender, EventArgs e)
        {
            //SADECE ARAMA İÇİN YAZILAN KUTU İLE ARAMA YAPMAK İÇİN
            if (otomatik_arama_cb.Checked == true)//TRUE İSE
            {
                //ARAMA RESMİ VE MENULERI KULLANILMAZ HALE GETİRİR
                ara_pb.Visible = false;
                arac_ara_menu.Enabled = false;
                arac_ara_sagtik.Enabled = false;
            }
            else//FALSE İSE
            {//ARAMA RESMİ VE MENULERI KULLANILIR
                ara_pb.Visible = true;
                arac_ara_menu.Enabled = true;
                arac_ara_sagtik.Enabled = true;
            }

        }
        private void arama_islemleri()
        {
            veriseti.Clear();//TABLOLARI SİLER //TABLOYU SİLİNİR YENİ TABLO İÇİN
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                Komutlar = new SqlDataAdapter(sql_kod, baglanti);//SQL KOMUTUNA GÖRE ARAMA YAPILIR
                Komutlar.Fill(veriseti, "arac_tablosu");//ARANAN BİLGİLER SAKLANIR
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                tablolari_listele_dgv.DataSource = veriseti.Tables["arac_tablosu"];//SAKLANAN BİLGİLER TABLODA GÖSTERİLİR
            }
            catch (Exception)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            }
        }
        private void arama_sonrasi_duzen()
        {
            tablolari_listele_dgv.Columns["arac_id"].Visible = false;
            tablolari_listele_dgv.Columns["arsiv"].Visible = false;
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

        private void ara_pb_Click(object sender, EventArgs e)
        {
            if (arama_tb.Text != "")
            {
                kodu_yenile();//YENİ SQL KOMUTU
                arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME
            }
            else
            {
                MessageBox.Show("ARAMA BİLGİLERİNİ DOLDURUNUZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//ARAMA İŞLEMİ İÇİN BİLGİ GEREKLİ UYARISI
            }

        }
        private void kodu_yenile()
        {
            if (otomatik_arama_cb.Checked==true)//EĞER OTOMATİK ARAMA VAR İSE 
            {
                sql_kod = "select " + gosterme_adeti + " * from arac_tablosu where " + aranacak_alan + " like '%" + aranacak_bilgi + "%' and arsiv=1";//ARALIKLI ARAMA YAPAN KOMUT
            }
            else if (otomatik_arama_cb.Checked == false)//OTOMATİK ARAMA DEĞİLSE
            {
                sql_kod = "select " + gosterme_adeti + " * from arac_tablosu where " + aranacak_alan + "='" + aranacak_bilgi + "' and arsiv=1";//BİRE BİR AYNISI VARSA GELİR
            }
        }
        private void konu_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ALAN ADINI BELİRLEME
            aranacak_alan = "";
            if (konu_combo.Text == "PLAKA NUMARASINA GÖRE")
            {
                aranacak_alan = "plaka";
            }
            else if (konu_combo.Text == "MARKAYA GÖRE")
            {
                aranacak_alan = "marka";
            }
            else if (konu_combo.Text == "MODELE GÖRE")
            {
                aranacak_alan = "model";
            }
            else if (konu_combo.Text == "ARAÇ YILANA GÖRE")
            {
                aranacak_alan = "yil";
            }
            else if (konu_combo.Text == "ARAÇ RENGİNE GÖRE")
            {
                aranacak_alan = "renk";
            }
            else if (konu_combo.Text == "KATEGORİYE GÖRE")
            {
                aranacak_alan = "kategori";
            }
            else if (konu_combo.Text == "KİLOMETRESİNE GÖRE")
            {
                aranacak_alan = "km";
            }
            else if (konu_combo.Text == "YAKİT TÜRÜNE GÖRE")
            {
                aranacak_alan = "yakit_turu";
            }
            else if (konu_combo.Text == "VİTES TÜRÜNE GÖRE")
            {
                aranacak_alan = "vites_turu";
            }
            else if (konu_combo.Text == "KİRA ÜCRETİNE GÖRE")
            {
                aranacak_alan = "kira_ucreti";
            }
        }

        private void arama_tb_TextChanged(object sender, EventArgs e)
        {//KARAKTER GİRİRDİĞİNDE ÇALIŞIR
            aranacak_bilgi = arama_tb.Text;
            if (otomatik_arama_cb.Checked==true)//OTOMATİK ARAMA AÇIK İSE
            {
                kodu_yenile();//YENİ SQL KOMUTU
                arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME
            }
        }

        private void ilk_combo_SelectedIndexChanged(object sender, EventArgs e)
        {//KAÇ SATIR GÖSTERİLECEĞİNİ BELİRLER
            gosterme_adeti = "";
            if (ilk_combo.Text == "HEPSİ")
            {
                gosterme_adeti = "";
            }
            else if (ilk_combo.Text != "HEPSİ")
            {
                gosterme_adeti = "top " + ilk_combo.SelectedItem;
            }
            ilk_belirle_combo.SelectedItem = ilk_combo.SelectedItem;
            ilk_belirle_combo_sagtik.SelectedItem = ilk_combo.SelectedItem;
        }

        private void ilk_uygula_pb_Click(object sender, EventArgs e)
        {
            sql_kod = "select * from arac_tablosu where arsiv=1";//TÜM TABLOYU GETİRME
            arama_islemleri();//ARAMA YAPIP TABLODA GÖSTERME
        }

        private void ara_pb_MouseMove(object sender, MouseEventArgs e)
        {
            ara_pb.Image = Image.FromFile(@"image\arama2.png");//GÖRSEL İLE EFEKT OLUŞTURMA
        }

        private void ara_pb_MouseLeave(object sender, EventArgs e)
        {
            ara_pb.Image = Image.FromFile(@"image\arama1.png");//VARSAYILAN GÖRSEL
        }

        private void tumunu_listele_pb_MouseMove(object sender, MouseEventArgs e)
        {
            tumunu_listele_pb.Image = Image.FromFile(@"image\arac_listesi2.png");//GÖRSEL İLE EFEKT OLUŞTURMA
        }

        private void tumunu_listele_pb_MouseLeave(object sender, EventArgs e)
        {
            tumunu_listele_pb.Image = Image.FromFile(@"image\arac_listesi1.png");//VARSAYILAN GÖRSEL
        }

        private void iptal_et_menu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }

        private void gelismis_arama_menu_Click(object sender, EventArgs e)
        {//GELİŞMİŞ ARAMA İŞARETLEME İŞLEMLERİ
            if (gelismis_arama_secenekleri_cb.Checked == false)
            {
                gelismis_arama_secenekleri_cb.Checked = true;
            }
            else
            {
                gelismis_arama_secenekleri_cb.Checked = false;
            }
        }

        private void otomatik_arama_menu_Click(object sender, EventArgs e)
        {//OTOMATİK ARAMA İŞARETLEME İŞLEMLERİ
            if (otomatik_arama_cb.Checked==false)
            {
                otomatik_arama_cb.Checked = true;
                arac_ara_menu.Enabled = false;
            }
            else
            {
                otomatik_arama_cb.Checked = false;
                arac_ara_menu.Enabled = true;
            }
        }

        private void ilk_belirle_combo_TextChanged(object sender, EventArgs e)
        {
            ilk_combo.SelectedItem = ilk_belirle_combo.SelectedItem;//KAÇ SATIR OLACAĞINI DİĞER MENULERE AKTARMA VS
            ilk_belirle_combo_sagtik.SelectedItem = ilk_belirle_combo.SelectedItem;//KAÇ SATIR OLACAĞINI DİĞER MENULERE AKTARMA VS
        }

        private void ilk_belirle_combo_sagtik_TextChanged(object sender, EventArgs e)
        {
            ilk_belirle_combo.SelectedItem = ilk_belirle_combo_sagtik.SelectedItem;//KAÇ SATIR OLACAĞINI DİĞER MENULERE AKTARMA VS
            ilk_combo.SelectedItem = ilk_belirle_combo_sagtik.SelectedItem;//KAÇ SATIR OLACAĞINI DİĞER MENULERE AKTARMA VS
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();//YARDIM PENCERESINI AÇMA
        }
    }
}
