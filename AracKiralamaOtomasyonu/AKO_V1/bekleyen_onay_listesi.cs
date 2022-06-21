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
    public partial class bekleyen_onay_listesi : Form
    {
        public bekleyen_onay_listesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlDataAdapter Komutlar;//TABLOLARIN ÇEKİLMESİNDE KULLANILAN KOMUT
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        DataSet veriseti = new DataSet();//ÇEKİLEN TABLOLARI SAKLAMAK İÇİN GEREK KOMUT
        private void bekleyen_onay_listesi_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            onay_bekleyenleri_getir();//PERSONEL İÇİN ONAY BEKLEYENLERI GETİREN FOKSİYON
            onay_bekleyenleri_duzenle();//ALAN ADI VE BOYUTLANDIRMA FOKSİYONU
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void fotograflari_al_ve_duzenle()
        {//VARSAYILAN GÖRSELLER
            onayla_pb.Image = Image.FromFile(@"image\onayla1.png");
            aday_onayla_menu.Image = Image.FromFile(@"image\onayla1.png");
            aday_onayla_sagtik.Image = Image.FromFile(@"image\onayla1.png");
            iptalet_pb.Image = Image.FromFile(@"image\iptal_et1.png");
            reddet_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            reddet_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_menu.Image = Image.FromFile(@"image\iptal_et1.png");
            iptal_et_sagtik.Image = Image.FromFile(@"image\iptal_et1.png");
            yardim_toolstrip.Image = Image.FromFile(@"image\yardim.png");
            yardim_sagtik.Image = Image.FromFile(@"image\yardim.png");
         
            onayla_pb.SizeMode = iptalet_pb.SizeMode = PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void renklendirme_sorunlarini_duzenle()
        {//RENKLENDIRME SONRASI OLUŞAN HATALARI DÜZENLEME
            tablolari_listele_dgv.BackgroundColor = this.BackColor;
            tablolari_listele_dgv.ForeColor = Color.Black;
        }
        private void onay_bekleyenleri_getir()
        {
            veriseti.Clear();//TABLOLARI SİLER
            baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
            Komutlar = new SqlDataAdapter("select onay_tablosu.tcno,ad,soyad,case cinsiyet when 1 then 'Erkek' when 0 then 'Kadın'end as 'cinsiyet_guncellemesi',il,ilce,dogum_yeri,dogum_tarihi,cep_telefonu,ev_telefonu,eposta,ev_adresi from onay_tablosu inner join personel_tablosu on onay_tablosu.tcno=personel_tablosu.tcno where onay_tablosu.arsiv=1 and durum=0 and gorevno=2", baglanti);
            Komutlar.Fill(veriseti, "onay_tablosu");//TABLO EKLEME
            baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            tablolari_listele_dgv.DataSource = veriseti.Tables["onay_tablosu"];//TABLOYU GÖSTERME

        }
        private void onay_bekleyenleri_duzenle()
        {
            tablolari_listele_dgv.Columns["tcno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["soyad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["il"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ilce"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["dogum_yeri"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["dogum_tarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["cep_telefonu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ev_telefonu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["eposta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ
            tablolari_listele_dgv.Columns["ev_adresi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//OTOMATİK BOYUTLANDIRMA İŞLEMLERİ


            tablolari_listele_dgv.Columns["tcno"].HeaderText = "TC NO";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ad"].HeaderText = "AD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞ
            tablolari_listele_dgv.Columns["soyad"].HeaderText = "SOYAD";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["cinsiyet_guncellemesi"].HeaderText = "CİNSİYET";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["il"].HeaderText = "İL";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["ilce"].HeaderText = "İLÇE";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["dogum_yeri"].HeaderText = "DOĞUM YERİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["dogum_tarihi"].HeaderText = "DOĞUM TARİHİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["cep_telefonu"].HeaderText = "CEP TELEFONU";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["ev_telefonu"].HeaderText = "EV TELEFONU";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
            tablolari_listele_dgv.Columns["eposta"].HeaderText = "E-POSTA ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ev_adresi"].HeaderText = "EV ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR
        }

        private void onayla_pb_Click(object sender, EventArgs e)
        {
            if (tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() != "")//BİLGİ VARMI KONTROL
            {
                if (MessageBox.Show("SEÇİLEN TC NO:" + tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() + " PERSONEL ADAYI ONAYLANSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//BİLGİ VARSA EVET İSE SORUNUN CEVABI GİRİŞ YAPAR
                {
                    onayla();//PERSONEL ONAYLANIR
                }
            }
            else
            {
                MessageBox.Show("PERSONEL ADAY SEÇİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//PERSONEL SEÇİMİ YAPIN UYARISI
            }
        }
        private void onayla()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("execute tum_arsivi_degistir '" + tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() + "'", baglanti);//PROSEDUR KULLANILDI AMAÇ PERSONELE AIT TÜM ARŞİVLERİ ÇIKARMA
                komut.ExecuteNonQuery();//PROSEDUR ÇALIŞTIRIRDI
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                MessageBox.Show(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() + " TC KİMLİK NOLU ADI:" + tablolari_listele_dgv.CurrentRow.Cells[1].Value.ToString() + " SOYADI:" + tablolari_listele_dgv.CurrentRow.Cells[2].Value.ToString() + "\nBAŞVURU ONAYLANDI.", "ONAYLAMA İŞLEMLELERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);//BİLGİ VERİRDİ.
                onay_bekleyenleri_getir();//TABLO GÜNCELLENDI
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void onayla_pb_MouseLeave(object sender, EventArgs e)
        {
            onayla_pb.Image = Image.FromFile(@"image\onayla1.png");//VARSAYILAN GÖRSEL
        }

        private void onayla_pb_MouseMove(object sender, MouseEventArgs e)
        {
            onayla_pb.Image = Image.FromFile(@"image\onayla2.png");//GÖRSEL EFEKT 
        }

        private void iptalet_pb_Click(object sender, EventArgs e)
        {
            try
            {
                if (tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() != "")//TABLODA BİR ŞEY VAR MI
                {
                    if (MessageBox.Show("SEÇİLEN TC NO:" + tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() + " PERSONEL ADAYI REDDEDILSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//CEVAP EVET İSE
                    {
                        reddet();//PERSONEL BAŞVURUSU REDDEDILDI FOKSİYONU
                    }
                }
                else
                {
                    MessageBox.Show("PERSONEL ADAY SEÇİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);//SEÇİM YAP UYARISI
                }

            }
            catch (Exception)
            {
                
            }
            
        }
        private void reddet()//PERSONEL REDDİ FOKSİYON
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("execute tum_arsivi_pasif_olarak_degistir '" + tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() + "'", baglanti);//TÜM PERSONELI PASİFLESTİRİR
                komut.ExecuteNonQuery();//PROSEDURU ÇALIŞTIRMA
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                MessageBox.Show(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() + " TC KİMLİK NOLU ADI:" + tablolari_listele_dgv.CurrentRow.Cells[1].Value.ToString() + " SOYADI:" + tablolari_listele_dgv.CurrentRow.Cells[2].Value.ToString() + "\nBAŞVURU REDDEDİLDİ.", "ONAYLAMA İŞLEMLELERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onay_bekleyenleri_getir();//TABLOYU GÜNCELLEME
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void iptalet_pb_MouseMove(object sender, MouseEventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\iptal_et2.png");//GÖRSLE EFEKT
        }

        private void iptalet_pb_MouseLeave(object sender, EventArgs e)
        {
            iptalet_pb.Image = Image.FromFile(@"image\iptal_et1.png");//VARSAYILAN GÖRSEL
        }

        private void iptal_et_menu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İPTAL EDİLSİN Mİ ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//SORULAN SORUYA EVET CEVABI VERİLİRSE PENCERE KAPATILIR
            {
                this.Close();
            }
        }

        private void yardim_toolstrip_Click(object sender, EventArgs e)
        {//YARDIM PECERESINI AÇAR
            yardim_pencersi yardim_al = new yardim_pencersi();
            yardim_al.ShowDialog();
        }

    }
}
