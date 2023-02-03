using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationGestionBibliotheque
{
    public partial class Ajouter : Form
    {  MySqlConnection connMysql;
      
        public static String M;

        string myConnectionString = "server=127.0.0.1;uid=root;database=applicationgestionbibliotheque";
        MySqlCommand Mysqlcmd;
        String textinsert;

        public Ajouter()
        {
            InitializeComponent();
        }


         public void connection()
        {
            connMysql = new MySqlConnection(myConnectionString);
            connMysql.Open();


        }


        private void button2_Click(object sender, EventArgs e)
        {
              textinsert = "insert into livre values(" + textBox2.Text + ",'" +
                textBox3.Text + "','" +
                textBox4.Text + "'," +
                textBox5.Text + ",'" +
                comboBox1.SelectedItem.ToString() + "','" +
              textBox7.Text + "')";
              try
              {
                  connection();
                  if (textBox2.Text == "")
                  { MessageBox.Show("aucun utilisateur pour ajouter"); }
                  else
                  {
                      Mysqlcmd = new MySqlCommand(textinsert, connMysql);
                      Mysqlcmd.ExecuteNonQuery();
                      MessageBox.Show("Ajout dans la base My sql terminer");

                   

                  }
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
        
        }

        private void Ajouter_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedItem = "";
            textBox7.Text = "";
        }
        }
    }

