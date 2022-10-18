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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-5FU8Q6M;Initial Catalog=TestBenzin;Integrated Security=True");
        
        void listele()
        {

            //Kurşunsuz 95
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From tblbenzın where petroltur='Kurşunsuz95'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblKursunsuz95.Text = dr[3].ToString(); //3. satır satış fiyatını listeler.
                LblKursunsuz95Alıs.Text = dr[2].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString()); //veritabanı stok satırından(4.satır) progres bar değeri çekildi.
                LblKursunsuz95Litre.Text = dr[4].ToString();  //stok satırından değeri label a yazdırma(1000 olarak).
            }
            baglanti.Close();


            //Kurşunsuz 97
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * From tblbenzın where petroltur='Kurşunsuz97'", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblKursunsuz97.Text = dr2[3].ToString();//3. satır satış fiyatını listeler.
                LblKursunsuz97Alıs.Text = dr2[2].ToString();
                progressBar2.Value = int.Parse(dr2[4].ToString()); //veritabanı stok satırından(4.satır) progres bar değeri çekildi.
                LblKursunsuz97Litre.Text = dr2[4].ToString();//stok satırından değeri label a yazdırma(1000 olarak).
            }
            baglanti.Close();


            //Euro Dizel 10
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select * From tblbenzın where petroltur='EuroDizel10'", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader(); //3. satır satış fiyatını listeler.
            while (dr3.Read())
            {
                LblEuroDizel10.Text = dr3[3].ToString();
                LblEuroDizel10Alıs.Text = dr3[2].ToString();
                progressBar3.Value = int.Parse(dr3[4].ToString()); //veritabanı stok satırından(4.satır) progres bar değeri çekildi.
                LblEuroDizelLitre.Text = dr3[4].ToString();//stok satırından değeri label a yazdırma(1000 olarak).
            }
            baglanti.Close();

            //Yeni Pro Dizel
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select * From tblbenzın where petroltur='YeniProDizel'", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblYeniProDizel.Text = dr4[3].ToString();
                LblYeniProDizelAlıs.Text = dr4[2].ToString();
                progressBar4.Value = int.Parse(dr4[4].ToString()); //veritabanı stok satırından(4.satır) progres bar değeri çekildi.
                LblYeniProDizelLitre.Text = dr4[4].ToString();//stok satırından değeri label a yazdırma(1000 olarak).
            }
            baglanti.Close();

            //Gaz
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select * From tblbenzın where petroltur='Gaz'", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblGaz.Text = dr5[3].ToString();
                LblGazAlıs.Text = dr5[2].ToString();
                progressBar5.Value = int.Parse(dr5[4].ToString()); //veritabanı stok satırından(4.satır) progres bar değeri çekildi.
                LblGazLitre.Text = dr5[4].ToString();//stok satırından değeri label a yazdırma(1000 olarak).
            }
            baglanti.Close();

            //VERİTABANINDAN KASADA Kİ MİKTARI YAZDIRMA İŞLEMİ
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select * from tblkasa", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblKasa.Text = dr6[0].ToString();
            }

            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(LblKursunsuz95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            TxtKursunsuzFiyat.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar;
            kursunsuz97 = Convert.ToDouble(LblKursunsuz97.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = kursunsuz97 * litre;
            TxtKursunsuz97Fiyat.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double eurodizel, litre, tutar;
            eurodizel = Convert.ToDouble(LblEuroDizel10.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = eurodizel * litre;
            TxtEuroDizelFiyat.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double yeniprodizel, litre, tutar;
            yeniprodizel = Convert.ToDouble(LblYeniProDizel.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = yeniprodizel * litre;
            TxtProDizelFiyat.Text = tutar.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(LblGaz.Text);
            litre = Convert.ToDouble(numericUpDown5.Value);
            tutar = gaz * litre;
            TxtGazFiyat.Text = tutar.ToString();
        }

        private void BtnDepoDoldur_Click(object sender, EventArgs e)
        {
            // NUMERICUPDOWN 0'DAN FARKLIYSA SATIN ALANIN PLAKASI BENZIN TURU LITRE VE FIYAT BILGILERINI HAREKET TABLOSUNA EKLEME
            if (numericUpDown1.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into tblhareket(plaka,benzınturu,lıtre,fıyat) values(@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut.Parameters.AddWithValue("@p2", "Kurşunsuz 95");
                komut.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtKursunsuzFiyat.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();


                //SATIŞTAN SONRA KASADA Kİ PARA MIKTARINI ARTTIRMA
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(TxtKursunsuzFiyat.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();


              

                //BENZIN STOĞUNU DÜŞÜRME İŞLEMİ
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='kurşunsuz95'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();
            }


            // NUMERICUPDOWN 0'DAN FARKLIYSA SATIN ALANIN PLAKASI BENZIN TURU LITRE VE FIYAT BILGILERINI HAREKET TABLOSUNA EKLEME
            if (numericUpDown2.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut4 = new SqlCommand("insert into tblhareket(plaka,benzınturu,lıtre,fıyat) values(@p1,@p2,@p3,@p4)", baglanti);
                komut4.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut4.Parameters.AddWithValue("@p2", "Kurşunsuz 97");
                komut4.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                komut4.Parameters.AddWithValue("@p4", decimal.Parse(TxtKursunsuz97Fiyat.Text));
                komut4.ExecuteNonQuery();
                baglanti.Close();


                //SATIŞTAN SONRA KASADA Kİ PARA MIKTARINI ARTTIRMA
                baglanti.Open();
                SqlCommand komut5 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut5.Parameters.AddWithValue("@p1", decimal.Parse(TxtKursunsuz97Fiyat.Text));
                komut5.ExecuteNonQuery();
                baglanti.Close();

              



                //BENZIN STOĞUNU DÜŞÜRME İŞLEMİ
                baglanti.Open();
                SqlCommand komut6 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='kurşunsuz97'", baglanti);
                komut6.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                komut6.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();

            }

            // NUMERICUPDOWN 0'DAN FARKLIYSA SATIN ALANIN PLAKASI BENZIN TURU LITRE VE FIYAT BILGILERINI HAREKET TABLOSUNA EKLEME
            if (numericUpDown3.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut7 = new SqlCommand("insert into tblhareket(plaka,benzınturu,lıtre,fıyat) values(@p1,@p2,@p3,@p4)", baglanti);
                komut7.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut7.Parameters.AddWithValue("@p2", "Euro Dizel 10");
                komut7.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                komut7.Parameters.AddWithValue("@p4", decimal.Parse(TxtEuroDizelFiyat.Text));
                komut7.ExecuteNonQuery();
                baglanti.Close();


                //SATIŞTAN SONRA KASADA Kİ PARA MIKTARINI ARTTIRMA
                baglanti.Open();
                SqlCommand komut8 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut8.Parameters.AddWithValue("@p1", decimal.Parse(TxtEuroDizelFiyat.Text));
                komut8.ExecuteNonQuery();
                baglanti.Close();

               

                //BENZIN STOĞUNU DÜŞÜRME İŞLEMİ
                baglanti.Open();
                SqlCommand komut9 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='EuroDizel10'", baglanti);
                komut9.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                komut9.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();

            }

            if (numericUpDown4.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut10 = new SqlCommand("insert into tblhareket(plaka,benzınturu,lıtre,fıyat) values(@p1,@p2,@p3,@p4)", baglanti);
                komut10.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut10.Parameters.AddWithValue("@p2", "Yeni Pro Dizel");
                komut10.Parameters.AddWithValue("@p3", numericUpDown4.Value);
                komut10.Parameters.AddWithValue("@p4", decimal.Parse(TxtProDizelFiyat.Text));
                komut10.ExecuteNonQuery();
                baglanti.Close();


                //SATIŞTAN SONRA KASADA Kİ PARA MIKTARINI ARTTIRMA
                baglanti.Open();
                SqlCommand komut11 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut11.Parameters.AddWithValue("@p1", decimal.Parse(TxtProDizelFiyat.Text));
                komut11.ExecuteNonQuery();
                baglanti.Close();

                

                //BENZIN STOĞUNU DÜŞÜRME İŞLEMİ
                baglanti.Open();
                SqlCommand komut12 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='YeniProDizel'", baglanti);
                komut12.Parameters.AddWithValue("@p1", numericUpDown4.Value);
                komut12.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();

            }

            if (numericUpDown5.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut13 = new SqlCommand("insert into tblhareket(plaka,benzınturu,lıtre,fıyat) values(@p1,@p2,@p3,@p4)", baglanti);
                komut13.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut13.Parameters.AddWithValue("@p2", "Gaz");
                komut13.Parameters.AddWithValue("@p3", numericUpDown5.Value);
                komut13.Parameters.AddWithValue("@p4", decimal.Parse(TxtGazFiyat.Text));
                komut13.ExecuteNonQuery();
                baglanti.Close();


                //SATIŞTAN SONRA KASADA Kİ PARA MIKTARINI ARTTIRMA
                baglanti.Open();
                SqlCommand komut14 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut14.Parameters.AddWithValue("@p1", decimal.Parse(TxtGazFiyat.Text));
                komut14.ExecuteNonQuery();
                baglanti.Close();

                

                //BENZIN STOĞUNU DÜŞÜRME İŞLEMİ
                baglanti.Open();
                SqlCommand komut15 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='Gaz'", baglanti);
                komut15.Parameters.AddWithValue("@p1", numericUpDown5.Value);
                komut15.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kurşunsuz 95 Benzin alma işlemi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tblbenzın set stok=stok+@p1 where petroltur='Kurşunsuz95'", baglanti);
            komut.Parameters.AddWithValue("@p1", numericUpDown6.Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Benzin eklendi");

            //SATIN ALMADAN SONRA KASADA Kİ PARA MIKTARINI AZALTMA
            baglanti.Open();
            SqlCommand komut16 = new SqlCommand("update tblkasa set mıktar=mıktar-@p1", baglanti);
            komut16.Parameters.AddWithValue("@p1", decimal.Parse(TxtKursunsuzFiyatAlıs.Text));
            komut16.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kurşunsuz 97 Benzin alma işlemi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tblbenzın set stok=stok+@p1 where petroltur='Kurşunsuz97'", baglanti);
            komut.Parameters.AddWithValue("@p1", numericUpDown7.Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Benzin eklendi");

            //SATIN ALMADAN SONRA KASADA Kİ PARA MIKTARINI AZALTMA
            baglanti.Open();
            SqlCommand komut17 = new SqlCommand("update tblkasa set mıktar=mıktar-@p1", baglanti);
            komut17.Parameters.AddWithValue("@p1", decimal.Parse(TxtKursunsuz97FiyatAlıs.Text));
            komut17.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Euro Dizel 10 Benzin alma işlemi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tblbenzın set stok=stok+@p1 where petroltur='EuroDizel10'", baglanti);
            komut.Parameters.AddWithValue("@p1", numericUpDown8.Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Benzin eklendi");

            //SATIN ALMADAN SONRA KASADA Kİ PARA MIKTARINI AZALTMA
            baglanti.Open();
            SqlCommand komut18 = new SqlCommand("update tblkasa set mıktar=mıktar-@p1", baglanti);
            komut18.Parameters.AddWithValue("@p1", decimal.Parse(TxtEuroDizelFiyatAlıs.Text));
            komut18.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //YeniProDizel Benzin alma işlemi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tblbenzın set stok=stok+@p1 where petroltur='YeniProDizel'", baglanti);
            komut.Parameters.AddWithValue("@p1", numericUpDown9.Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Benzin eklendi");

            //SATIN ALMADAN SONRA KASADA Kİ PARA MIKTARINI AZALTMA
            baglanti.Open();
            SqlCommand komut19 = new SqlCommand("update tblkasa set mıktar=mıktar-@p1", baglanti);
            komut19.Parameters.AddWithValue("@p1", decimal.Parse(TxtProDizelFiyatAlıs.Text));
            komut19.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Gaz Benzin alma işlemi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tblbenzın set stok=stok+@p1 where petroltur='Gaz'", baglanti);
            komut.Parameters.AddWithValue("@p1", numericUpDown10.Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Benzin eklendi");

            //SATIN ALMADAN SONRA KASADA Kİ PARA MIKTARINI AZALTMA
            baglanti.Open();
            SqlCommand komut20 = new SqlCommand("update tblkasa set mıktar=mıktar-@p1", baglanti);
            komut20.Parameters.AddWithValue("@p1", decimal.Parse(TxtGazFiyatAlıs.Text));
            komut20.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(LblKursunsuz95Alıs.Text);
            litre = Convert.ToDouble(numericUpDown6.Value);
            tutar = kursunsuz95 * litre;
            TxtKursunsuzFiyatAlıs.Text = tutar.ToString();
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar;
            kursunsuz97 = Convert.ToDouble(LblKursunsuz97Alıs.Text);
            litre = Convert.ToDouble(numericUpDown7.Value);
            tutar = kursunsuz97 * litre;
            TxtKursunsuz97FiyatAlıs.Text = tutar.ToString();
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            double EuroDizel, litre, tutar;
            EuroDizel = Convert.ToDouble(LblEuroDizel10Alıs.Text);
            litre = Convert.ToDouble(numericUpDown8.Value);
            tutar = EuroDizel * litre;
            TxtEuroDizelFiyatAlıs.Text = tutar.ToString();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            double ProDizel, litre, tutar;
            ProDizel = Convert.ToDouble(LblYeniProDizelAlıs.Text);
            litre = Convert.ToDouble(numericUpDown9.Value);
            tutar = ProDizel * litre;
            TxtProDizelFiyatAlıs.Text = tutar.ToString();
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(LblGazAlıs.Text);
            litre = Convert.ToDouble(numericUpDown10.Value);
            tutar = gaz * litre;
            TxtGazFiyatAlıs.Text = tutar.ToString();
        }
    }
}
