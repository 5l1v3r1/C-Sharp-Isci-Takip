using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace işci_takip
{
    public partial class Form1 : Form
    {
        OleDbConnection bag = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=işcitakip.accdb");
        DataTable tablo = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            groupBox1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
            button1.Enabled = true ;
            groupBox1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            db.baglan();
            //string Yenikayıt = string.Format("insert into işci(Tc kimlik,Adi,Soyadi,Telno,Adres,Maaş,İsciGirisTarih)values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
            string Yenikayıt = string.Format("insert into işci(TcKimlik,Adi,Soyadi,Telno,Adres,Maaş,İsciGiris)values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, textBox4.Text,textBox6.Text ,textBox7.Text );
            try
            {
                new OleDbCommand(Yenikayıt, db.baglanti).ExecuteNonQuery();
                MessageBox.Show("KAYIT YAPILDI");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            
            

            }
            catch
            {
                    MessageBox.Show("KAYIT YAPILAMADI");
            }
            db.kes();
            
        }



        private void button4_Click(object sender, EventArgs e)
        {
                   
                string sorgu = string.Format("delete from işci where ={0}");
                db.baglan();
                int silininkayıt = new OleDbCommand(sorgu, db.baglanti).ExecuteNonQuery();
                button4_Click(null, null);
                db.kes();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From işci ", bag);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Tc Kimlik";
            dataGridView1.Columns[2].HeaderText = "Adı";
            dataGridView1.Columns[3].HeaderText = "Soyadı";
            dataGridView1.Columns[4].HeaderText = "Tel No";
            dataGridView1.Columns[5].HeaderText = "Adres";
            dataGridView1.Columns[6].HeaderText = "Maaş";
            dataGridView1.Columns[7].HeaderText = "Başlangıç Tarihi";
             
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }



     }

  }