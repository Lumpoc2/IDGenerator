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
    public partial class registration : Form
    {
        private static registration _intance;
        public static registration Instance
        {
            get
            {
                if (_intance == null)
                    _intance = new registration();
                return _intance;
            }
        }

        public registration()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            string con_string = "server=localhost;Database=mis;port=3306;username=root;password=mark_123";
            MySqlConnection conn = new MySqlConnection(con_string);

            if (string.IsNullOrEmpty(Firstnametxt.Text) || string.IsNullOrEmpty(lastnametxt.Text) ||
               string.IsNullOrEmpty(emailtxt.Text) || string.IsNullOrEmpty(passwordtxt.Text))

            {
                MessageBox.Show("Please Don't Leave Empty", "Empty Inputs");
                return;
            }
            else
            {
                try
                {
                    conn.Open();

                    string first_name = Firstnametxt.Text;
                    string last_name = lastnametxt.Text;
                    string email = emailtxt.Text;
                    string password = passwordtxt.Text;
                    string query;

                    query = "insert into register(firstname,lastname,email,password) VALUES ('" + first_name + "', '" +last_name + "', '" + email + "', '" + password + "') ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@firstname", first_name);
                        cmd.Parameters.AddWithValue("@lastname", last_name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);


                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                    MessageBox.Show("Success", "Data Added");


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                conn.Close();
            }
        }

        private void registration_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login da = new login();
            da.Show();
            this.Hide();
        }
    }
}