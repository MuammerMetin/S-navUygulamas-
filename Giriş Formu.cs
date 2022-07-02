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

namespace TestMatikProje
{
    public partial class Giriş_Formu : Form

    {
        public Giriş_Formu()
        {
              InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=MUAMMER\\SQLEXPRESS;Initial Catalog=TestMatik;Integrated Security=True");




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sql = "Select * From Kullanıcılarr where Ad=@Ad AND Sifre=@Sifre";
                SqlParameter prm1=new SqlParameter("Ad" , textBox1.Text);
                SqlParameter prm2 = new SqlParameter("Sifre", textBox2.Text);
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    AnaForm fr = new AnaForm();
                    fr.Show();
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Giriş");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lütfen Veritabanı Yöneticisi İle İletişime Geçiniz");
        }
      
      
        
        private void Giriş_Formu_Load(object sender, EventArgs e)
        {

        }
    }
}
