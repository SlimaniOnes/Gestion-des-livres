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
    public partial class Form1 : Form
    {
        Liste l;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void quitterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous quitter l'application?",
                     "close Form",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Warning) == DialogResult.Yes)
            
            { Application.Exit() ;}
            }
        
    



   

        private void listeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (l == null)
            {
                l = new Liste();
                l.MdiParent = this;
                l.FormClosed += l_FormClosed;
                l.Show();
            }
            else
            {
                l.Activate();
            }
        }

        void l_FormClosed(object sender, FormClosedEventArgs e)
        {
            l = null;
            //throw new NotImplementedException();
        }

        private void reduireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Minimized;
        }

        private void agrandirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform2 in charr)
                chform2.WindowState = FormWindowState.Normal;
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.Close();
        }

        private void ajouterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Ajouter a = new Ajouter();
            a.MdiParent = this;
            a.Show();
        }






    }
}
