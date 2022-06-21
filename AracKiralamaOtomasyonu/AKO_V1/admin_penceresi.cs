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
    public partial class admin_penceresi : Form
    {
        public admin_penceresi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"server=DESKTOP-5DGSRBQ;database=AKO;Trusted_Connection=yes");//VERİTABANINA BAĞLANTI ADRESİ
        SqlDataAdapter Komutlar;//TABLOLARIN ÇEKİLMESİNDE KULLANILAN KOMUT
        SqlCommand komut;//SQL İFADELERİNİ ÇALIŞTIRAN KOMUT
        DataSet veriseti = new DataSet();//ÇEKİLEN TABLOLARI SAKLAMAK İÇİN GEREK KOMUT
        private void admin_penceresi_Load(object sender, EventArgs e)
        {
            fotograflari_al_ve_duzenle();//FOTOĞRAFLARI GÖSTERME FOKSİYONU
            personel_listesini_getir();
            personel_listesininin_duzeni();
            if (ana_pencere.renkler_uygulanacakmi == true)//FARKLI PENCERELERDE RENK DEĞİŞTİRİLECEK MI(ANA PENCEREYE BAĞLIDIR.)
            {
                this.BackColor = ana_pencere.arkaplan_rengi;//BU PENCERENİN ARKAPLAN RENGİNİ DEĞİŞTİRİR.
                this.ForeColor = ana_pencere.yazi_rengi;//BU PENCERENİN YAZI RENGİNİ DEĞİŞTİRİR.
                renklendirme_sorunlarini_duzenle();//RENKLENDİRME İŞLEMİ SONUCUNDA OLUŞAN SORUNLARI DÜZENLEME
            }
        }
        private void fotograflari_al_ve_duzenle()
        {
            onay_bekleyenler_pb.Image = Image.FromFile(@"image\onay_bekleyenler1.png");
            personel_yetkilerini_duzenle_pb.Image = Image.FromFile(@"image\yetkiler1.png");
            personel_cikar_pb.Image = Image.FromFile(@"image\personel_cikar1.png");
            personel_arsivi_pb.Image = Image.FromFile(@"image\personel_arsiv1.png");
      
            onay_bekleyenler_pb.SizeMode =personel_yetkilerini_duzenle_pb.SizeMode=personel_cikar_pb.SizeMode=personel_arsivi_pb.SizeMode= PictureBoxSizeMode.StretchImage;//FOTOĞRAFLARI KUTU BOYUTUNA AYARLAMA KOMUTU
        }
        private void renklendirme_sorunlarini_duzenle()
        {
            tablolari_listele_dgv.BackgroundColor = this.BackColor;
            tablolari_listele_dgv.ForeColor = Color.Black;
            admin_islemleri_gb.ForeColor = this.ForeColor;
        }
        private void personel_listesini_getir()
        {
            veriseti.Clear();//TABLOLARI SİLER 
            baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
            Komutlar = new SqlDataAdapter("select tcno,ad,soyad,case cinsiyet when 1 then 'Erkek' when 0 then 'Kadın'end as 'cinsiyet_guncellemesi',il,ilce,dogum_yeri,dogum_tarihi,cep_telefonu,ev_telefonu,eposta,ev_adresi from personel_tablosu where arsiv=1 and gorevno=2", baglanti);
            Komutlar.Fill(veriseti, "personel_tablosu");
            baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
            tablolari_listele_dgv.DataSource = veriseti.Tables["personel_tablosu"];

        }
        private void personel_listesininin_duzeni()
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
            tablolari_listele_dgv.Columns["cinsiyet_guncellemesi"].HeaderText = "CİNSİYET";
            tablolari_listele_dgv.Columns["il"].HeaderText = "İL";
            tablolari_listele_dgv.Columns["ilce"].HeaderText = "İLÇE";
            tablolari_listele_dgv.Columns["dogum_yeri"].HeaderText = "DOĞUM YERİ";
            tablolari_listele_dgv.Columns["dogum_tarihi"].HeaderText = "DOĞUM TARİHİ";
            tablolari_listele_dgv.Columns["cep_telefonu"].HeaderText = "CEP TELEFONU";
            tablolari_listele_dgv.Columns["ev_telefonu"].HeaderText = "EV TELEFONU";
            tablolari_listele_dgv.Columns["eposta"].HeaderText = "E-POSTA ADRESİ";//VERİTABANINDA GÖZÜKEN ALAN ADI DEĞİŞTİRİLİR.
            tablolari_listele_dgv.Columns["ev_adresi"].HeaderText = "EV ADRESİ";
        }

        private void onay_bekleyenler_pb_Click(object sender, EventArgs e)
        {
            bekleyen_onay_listesi onay_bekleyen_listesi = new bekleyen_onay_listesi();
            onay_bekleyen_listesi.ShowDialog();
            personel_listesini_getir();//Güncelleme İşlemleri
        }

        private void onay_bekleyenler_pb_MouseMove(object sender, MouseEventArgs e)
        {
            onay_bekleyenler_pb.Image = Image.FromFile(@"image\onay_bekleyenler2.png");
            onay_bekleyenler_label.ForeColor = onay_bekleyenler_bilgi_label.ForeColor = Color.Red;
        }

        private void onay_bekleyenler_pb_MouseLeave(object sender, EventArgs e)
        {
            onay_bekleyenler_pb.Image = Image.FromFile(@"image\onay_bekleyenler1.png");
            onay_bekleyenler_label.ForeColor = onay_bekleyenler_bilgi_label.ForeColor = this.ForeColor;
        }

        private void personel_yetkilerini_duzenle_pb_Click(object sender, EventArgs e)
        {
            personel_yetkileri personel_yetkileri_penceresi = new personel_yetkileri();
            personel_yetkileri_penceresi.ShowDialog();
        }

        private void personel_yetkilerini_duzenle_pb_MouseMove(object sender, MouseEventArgs e)
        {
            personel_yetkilerini_duzenle_pb.Image = Image.FromFile(@"image\yetkiler2.png");
            personel_yetkilerini_duzenle_label.ForeColor = personel_yetkilerini_duzenle_bilgi_label.ForeColor = Color.Red;
        }

        private void personel_yetkilerini_duzenle_pb_MouseLeave(object sender, EventArgs e)
        {
            personel_yetkilerini_duzenle_pb.Image = Image.FromFile(@"image\yetkiler1.png");
            personel_yetkilerini_duzenle_label.ForeColor = personel_yetkilerini_duzenle_bilgi_label.ForeColor = this.ForeColor;
        }

        private void personel_cikar_pb_Click(object sender, EventArgs e)
        {
            if (tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() != "")
            {
                if (MessageBox.Show("SEÇİLEN TC NO:" + tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() + " PERSONEL ÇIKARILSIN MI ?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cikar();
                }
            }
            else
            {
                MessageBox.Show("PERSONEL ADAY SEÇİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void cikar()
        {
            try
            {
                baglanti.Open();//VERİTABANINA BAĞLANTI AÇILDI
                komut = new SqlCommand("execute tum_arsivi_pasif_olarak_degistir '" + tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI

                MessageBox.Show(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() + " TC KİMLİK NOLU ADI:" + tablolari_listele_dgv.CurrentRow.Cells[1].Value.ToString() + " SOYADI:" + tablolari_listele_dgv.CurrentRow.Cells[2].Value.ToString() + "\nPERSONEL ÇIKARILDI.", "PERSONEL ÇIKARMA İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personel_listesini_getir();
            }
            catch (Exception HATA)
            {
                baglanti.Close();//VERİTABANI BAĞLANTISI KAPATILDI
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
        }

        private void personel_cikar_pb_MouseMove(object sender, MouseEventArgs e)
        {
            personel_cikar_pb.Image = Image.FromFile(@"image\personel_cikar2.png");
            personel_cikar_label.ForeColor = personel_cikar_bilgi_label.ForeColor = Color.Red;
        }

        private void personel_cikar_pb_MouseLeave(object sender, EventArgs e)
        {
            personel_cikar_pb.Image = Image.FromFile(@"image\personel_cikar1.png");
            personel_cikar_label.ForeColor = personel_cikar_bilgi_label.ForeColor = this.ForeColor;
        }

        private void personel_arsivi_pb_Click(object sender, EventArgs e)
        {
            ana_pencere.hangi_arsiv_listesi= "personel_tablosu";
            arsiv_liste_formu kiralama_arsiv_penceresi = new arsiv_liste_formu();
            kiralama_arsiv_penceresi.ShowDialog();
        }

        private void personel_arsivi_pb_MouseMove(object sender, MouseEventArgs e)
        {
            personel_arsivi_pb.Image = Image.FromFile(@"image\personel_arsiv2.png");
            personel_arsivi_label.ForeColor = personel_arsivi_bilgi_label.ForeColor = Color.Red;
        }

        private void personel_arsivi_pb_MouseLeave(object sender, EventArgs e)
        {
            personel_arsivi_pb.Image = Image.FromFile(@"image\personel_arsiv1.png");
            personel_arsivi_label.ForeColor = personel_arsivi_bilgi_label.ForeColor = this.ForeColor;
        }
    }
}
