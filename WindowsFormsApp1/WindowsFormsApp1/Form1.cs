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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form  
    {
        SqlConnection con = new SqlConnection("Data Source = 303-6\\SQLSERVER; Initial Catalog = BD; Integrated Security = true;");

        public Form1()

        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand(@"SELECT distinct [Nazvanie_JK], [Status_stroitelstva_JK], (select COUNT([Nazvanie_JK]) from [dbo].[houses_in_complexes] as h2 where h1.Nazvanie_JK = h2.Nazvanie_JK) as [Кол-во домов], [Gorod]
FROM[dbo].[houses_in_complexes] as h1", con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
                while (dr.Read())
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nazvanie = textBox1.Text;
            string status = textBox2.Text;
            string kolvo = textBox3.Text;
            String gorod = textBox4.Text;
            dataGridView1.Rows.Add(nazvanie, status, kolvo, gorod);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
