using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MISGroup_4
{
    public partial class login : Form
    {
        private static login _intance;
        public static login Instance
        {
            get
            {
                if (_intance == null)
                    _intance = new login();
                return _intance;
            }
        }
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            registration registeruser = new registration();
            registeruser.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             string con_string = "server=localhost;Database=mis;port=3306;username=root;password=mark_123";

            string query = "Select * from register Where email = '" + usernametxt.Text.Trim() + "' and password = '" + passwordtxt.Text.Trim() + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, con_string);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                Form3 MainMenu = new Form3();
                MainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username Or Password");

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (passwordtxt.PasswordChar == '\0')
            {
                button5.BringToFront();
                passwordtxt.PasswordChar = '*';
            }
        }

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            if (passwordtxt.PasswordChar == '*')
            {
                button4.BringToFront();
                passwordtxt.PasswordChar = '\0';
            }
        }
    }
}
