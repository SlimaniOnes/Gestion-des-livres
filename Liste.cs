
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
    public partial class Liste : Form
    {
        MySqlConnection connMysql;

        public static String M;

        string myConnectionString = "server=127.0.0.1;uid=root;database=applicationgestionbibliotheque";
        MySqlCommand Mysqlcmd;



        public Liste()
        {
            InitializeComponent();
            actualiser();
        }


        public void connection()
        {
            try
            {
                connMysql = new MySqlConnection(myConnectionString);
                connMysql.Open();

            }
            catch (Exception)
            { MessageBox.Show("Probleme de connecxion"); }
        }


        public  void actualiser()
        {
            connection();
            try
            {

                listView1.Items.Clear();
                Mysqlcmd = new MySqlCommand("Select * From livre", connMysql);
                using (MySqlDataReader Lire = Mysqlcmd.ExecuteReader())
                {
                    while (Lire.Read())
                    {
                        String ISBN = Lire["ISBN"].ToString();
                        String Titre = Lire["Titre"].ToString();
                        String Auteur = Lire["Auteur"].ToString();
                        String AnneeSortie = Lire["AnneeSortie"].ToString();
                        String Type = Lire["Type"].ToString();
                        String Editeur = Lire["Editeur"].ToString();

                        listView1.Items.Add(new ListViewItem(new[] { ISBN, Titre, Auteur, AnneeSortie, Type, Editeur }));
                    }



                }
            }
            catch (Exception)
            { MessageBox.Show("Probleme"); }
        }



        private void Liste_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                connection();
                try
                {
                    listView1.Items.Clear();

                    Mysqlcmd = new MySqlCommand("SELECT * FROM livre WHERE Editeur like '%" + textBox1.Text + "%' OR Titre like '%" + textBox1.Text + "%' OR Auteur like '%" + textBox1.Text + "%'OR AnneeSortie like '%" + textBox1.Text + "%'OR Type like '%" + textBox1.Text + "%'", connMysql);
                    using (MySqlDataReader Lire = Mysqlcmd.ExecuteReader())
                    {
                        while (Lire.Read())
                        {
                            String ISBN = Lire["ISBN"].ToString();
                            String Titre = Lire["Titre"].ToString();
                            String Auteur = Lire["Auteur"].ToString();
                            String AnneeSortie = Lire["AnneeSortie"].ToString();
                            String Type = Lire["Type"].ToString();
                            String Editeur = Lire["Editeur"].ToString();



                            listView1.Items.Add(new ListViewItem(new[] { ISBN, Titre, Auteur, AnneeSortie, Type, Editeur }));
                        }



                    }
                }
                catch (Exception)
                { MessageBox.Show("Probleme"); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            actualiser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection();
            if (listView1.SelectedIndices.Count == 1)
            {
                textBox2.Text = listView1.Items[0].SubItems[0].Text;
                textBox3.Text = listView1.Items[0].SubItems[1].Text;
                textBox4.Text = listView1.Items[0].SubItems[2].Text;
                textBox5.Text = listView1.Items[0].SubItems[3].Text;
                comboBox1.SelectedItem = listView1.Items[0].SubItems[4].Text;
                textBox7.Text = listView1.Items[0].SubItems[5].Text;
            }
            // Displays the MessageBox.
            try
            {

                string message = "Update ce Livre de ISBN" + textBox2.Text;
                string caption = "R u sure";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);

                if (result == DialogResult.Yes)
                {


                    try
                    {
                        M = "UPDATE livre SET Titre='" + textBox3.Text + "',Auteur='"
                               + textBox4.Text + "',AnneeSortie='" + textBox5.Text +
                               "',Type='" + comboBox1.SelectedItem.ToString() + "',Editeur='" + textBox7.Text +
                               "' WHERE ISBN = '" + textBox2.Text + "'";



                        Mysqlcmd = new MySqlCommand(M, connMysql);
                        Mysqlcmd.ExecuteNonQuery();
                        MessageBox.Show("modification de livre que son ISBN est " + textBox2.Text + " terminer");
                    }


                    catch (Exception)
                    {
                        MessageBox.Show("erreur à la modification");
                    }
                }
                actualiser();




            }
            catch (Exception)
            {
                MessageBox.Show("erreur");
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 1)
            {
                String selected = listView1.SelectedItems[0].Text;



                string message = "supprimer ce livre de isbn" + selected;
                string caption = "R u sure";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);

                if (result == DialogResult.Yes)
                {


                    connection();


                    try
                    {
                        M = "delete from livre where ISBN=" + selected;
                        Mysqlcmd = new MySqlCommand(M, connMysql);
                        Mysqlcmd.ExecuteNonQuery();

                        MessageBox.Show("Livre deleted");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    actualiser();


                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            connection();

            // Displays the MessageBox.
            try
            {
                if (listView1.SelectedIndices.Count == 1)
                {
                    int ind = listView1.SelectedIndices[0];
                    textBox2.Text = listView1.Items[ind].SubItems[0].Text;
                    string message = "Update ce Livre de ISBN" + textBox2.Text;
                    string caption = "R u sure";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);

                    if (result == DialogResult.Yes)
                    {

                        try
                        {
                            if (listView1.SelectedIndices.Count == 1)
                            {
                                int ins= listView1.SelectedIndices[0];
                                textBox2.Text = listView1.Items[ins].SubItems[0].Text;
                                textBox3.Text = listView1.Items[ins].SubItems[1].Text;
                                textBox4.Text = listView1.Items[ins].SubItems[2].Text;
                                textBox5.Text = listView1.Items[ins].SubItems[3].Text;
                                comboBox1.SelectedItem = listView1.Items[ins].SubItems[4].Text;
                                textBox7.Text = listView1.Items[ins].SubItems[5].Text;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("erreur");
                        }

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("erreur");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 1)
                {
                    int ind = listView1.SelectedIndices[0];
                    textBox2.Text = listView1.Items[ind].SubItems[0].Text;
                    textBox3.Text = listView1.Items[ind].SubItems[1].Text;
                    textBox4.Text = listView1.Items[ind].SubItems[2].Text;
                    textBox5.Text = listView1.Items[ind].SubItems[3].Text;
                    comboBox1.SelectedItem = listView1.Items[ind].SubItems[4].Text;
                    textBox7.Text = listView1.Items[ind].SubItems[5].Text;
                }
                M = "UPDATE livre SET Titre='" + textBox3.Text + "',Auteur='"
                                  + textBox4.Text + "',AnneeSortie='" + textBox5.Text +
                                  "',Type='" + comboBox1.SelectedItem.ToString() + "',Editeur='" + textBox7.Text +
                                  "' WHERE ISBN = '" + listView1.Items[0].SubItems[0].Text + "'";



                Mysqlcmd = new MySqlCommand(M, connMysql);
                Mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("modification de livre que son ISBN est " + textBox2.Text + " terminer");

                actualiser();
                textBox2.Text ="";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.SelectedItem = "";
                textBox7.Text = "";
            }


            catch (Exception)
            {
                MessageBox.Show("erreur à la modification");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 1)
            {
                String selected = listView1.SelectedItems[0].Text;



                string message = "supprimer ce livre de isbn" + selected;
                string caption = "R u sure";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);

                if (result == DialogResult.Yes)
                {


                    connection();


                    try
                    {
                        M = "delete from livre where ISBN=" + selected;
                        Mysqlcmd = new MySqlCommand(M, connMysql);
                        Mysqlcmd.ExecuteNonQuery();

                        MessageBox.Show("Livre deleted");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    actualiser();


                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
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