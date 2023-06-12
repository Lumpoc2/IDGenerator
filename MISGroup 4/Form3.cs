using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISGroup_4.Modules;
using MySql.Data.MySqlClient;
using MISGroup_4.Helpers;


namespace MISGroup_4
{
    public partial class Form3 : Form
    {
        public static Form3 instance;
        public login Login;
        public Form3(login _login)
        {
            Login = _login;
            InitializeComponent();
            instance = this;
        }
        private static Form3 _intance;
        public static Form3 Instance
        {
            get
            {
                if (_intance == null)
                    _intance = new Form3();
                return _intance;
            }
        }


        public Form3()
        {
            InitializeComponent();
            DisplayData(Searchtxt.Text);
            displayname();
           
        }
      
           
 
       
        public void DisplayData(string search)
        {
            var students = new StudentInfo().GetStudents(search);
            dataGridView1.Rows.Clear();

            students.ForEach(student =>
            {
                dataGridView1.Rows.Add(
                    student.rfid,
                    student.StudentId,
                    student.Program,
                    student.Firstname,
                    student.Lastname,
                    student.Middlename,
                    student.Extname,
                    student.Extname,
                    student.Contact,
                    student.GuardianName,
                    student.Address,
                    student.ProfilePicture,
                    student.Signature);

            });

            try
            {
                string con_string = "server=localhost;database=mis;port=3306;username=root;password=mark_123";

                using (var conn = new MySqlConnection(con_string))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("select * from students where rfid LIKE @rfid  or  student_id LIKE @student_id or first_name LIKE @first_name or last_name LIKE @last_name", conn))
                    {

                        cmd.Parameters.AddWithValue("@student_id", $"%{search}%");
                        cmd.Parameters.AddWithValue("@first_name", $"%{search}%");
                        cmd.Parameters.AddWithValue("@last_name", $"%{search}%");
                        cmd.Parameters.AddWithValue("@rfid", $"%{search}%");
                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            dataGridView1.Rows.Clear();
                            while (rd.Read())
                            {
                                dataGridView1.Rows.Add(
                                    rd.GetString("rfid"),
                                    rd.GetString("student_id"),
                                    rd.GetString("program"),
                                    rd.GetString("first_name"),
                                    rd.GetString("last_name"),
                                    rd.GetString("middle_name"),
                                    rd.GetString("ext_name"),
                                    rd.GetString("contact"),
                                    rd.GetString("guardian_name"),
                                    rd.GetString("address"));
                            }

                        }
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void displayname()
        {

            {


                //string con_string = "server=localhost;Database=mis;port=3306;username=root;password=mark_123";


                //using var con = new MySqlConnection(con_string);
                //con.Open();

                //var sql = "INSERT INTO register(firstname, lastname) VALUES('"+Namelbl.Text+"','"+lastnamelbl.Text+"')";
                //using var cmd = new MySqlCommand(sql, con);

                //cmd.ExecuteNonQuery();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;


        }
        public void display(string query, DataGridView dgv)
        {

        }
        private void Add_Click(object sender, EventArgs e)
        {

        }




        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Delete":
                    DialogResult confirm = MessageBox.Show("Are you sure you want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {

                        string id = dataGridView1.CurrentRow.Cells["RFID"].Value.ToString();
                        try
                        {
                            string con_string = "server=localhost;database=mis;port=3306;username=root;password=mark_123";

                            using (var conn = new MySqlConnection(con_string))
                            {
                                conn.Open();
                                using (var cmd = new MySqlCommand("Delete from students Where rfid=@rfid", conn))
                                {
                                    cmd.Parameters.AddWithValue("@rfid", id);
                                    int result = cmd.ExecuteNonQuery();
                                    if (result > 0)
                                    {
                                        MessageBox.Show("Data Deleted Successfull");
                                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Data Not  Deleted");
                                    }
                                }


                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                case "Edit":
                    string student_id = dataGridView1.CurrentRow.Cells["RFID"].Value.ToString();
                    using (var form = new Form2(student_id))
                    {
                        form.ShowDialog();
                    }
                    break;
                case "View":
                    string ViewID = dataGridView1.CurrentRow.Cells["RFID"].Value.ToString();
                    using (Form4 form = new Form4(ViewID))
                    {
                        form.ShowDialog();
                    }

                    break;
                default:
                    break;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {


        }
        public void searchData(string valueToFind)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DisplayData(Searchtxt.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstnamelbl_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con1 = new MySqlConnection("server=localhost;Database=mis;port=3306;username=root;password=mark_123");
            con1.Open();

            MySqlCommand cmd1 = new MySqlCommand("SELECT student_id, program, first_name, last_name, middle_name, ext_name, contact, guardian_name, address, profile_picture, Signature from students where rfid= @rfid");
            cmd1.Connection = con1;
            cmd1.Parameters.AddWithValue("@rfid", (Scanrfidtxt.Text));

            MySqlDataReader da = cmd1.ExecuteReader();
            while (da.Read())
            {
                studentidtxt.Text = da.GetString(0).ToString() + (" ");
                coursetxt.Text = da.GetValue(1).ToString() + (" ");
                firstnametxt.Text = da.GetValue(2).ToString() + (" ");
                lastnametxt.Text = da.GetValue(3).ToString() + (" ");
                middlenametxt.Text = da.GetValue(4).ToString() + (" ");
                extensiontxt.Text = da.GetValue(5).ToString() + (" ");
                Contacttxt.Text = da.GetValue(6).ToString() + (" ");
                Guardiantxt.Text = da.GetValue(7).ToString() + (" ");
                addresstxt.Text = da.GetValue(8).ToString() + (" ");




                profilepic.Image = ImageLoader.ImageFromStream((byte[])da["profile_picture"]);
                signaturepic.Image = ImageLoader.ImageFromStream((byte[])da["Signature"]);

            }

            con1.Close();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Searchtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DisplayData(Searchtxt.Text);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }   

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Guide form = new Guide();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
          
                about frm = new about();
            frm.Show();
            this.Hide();
        }

        private void Getinfotxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            {
               
            }
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
          about About = new about();
            About.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Logout?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                login MainMenu = new login();
                MainMenu.Show();
                this.Hide();

            }
            else if (result == DialogResult.No)
            {
                //.
            }

        }

        private void Scanrfidtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') // Check if the Enter key was pressed
            {
                // Get the RFID value from the TextBox and do something with it
                int rfid;
                if (int.TryParse(Scanrfidtxt.Text, out rfid))
                {
                    MySqlConnection con1 = new MySqlConnection("server=localhost;Database=mis;port=3306;username=root;password=mark_123");
                    con1.Open();

                    MySqlCommand cmd1 = new MySqlCommand("SELECT student_id, program, first_name, last_name, middle_name, ext_name, contact, guardian_name, address, profile_picture, Signature from students where rfid= @rfid");
                    cmd1.Connection = con1;
                    cmd1.Parameters.AddWithValue("@rfid", (Scanrfidtxt.Text));

                    MySqlDataReader da = cmd1.ExecuteReader();
                    while (da.Read())
                    {
                        studentidtxt.Text = da.GetString(0).ToString() + (" ");
                        coursetxt.Text = da.GetValue(1).ToString() + (" ");
                        firstnametxt.Text = da.GetValue(2).ToString() + (" ");
                        lastnametxt.Text = da.GetValue(3).ToString() + (" ");
                        middlenametxt.Text = da.GetValue(4).ToString() + (" ");
                        extensiontxt.Text = da.GetValue(5).ToString() + (" ");
                        Contacttxt.Text = da.GetValue(6).ToString() + (" ");
                        Guardiantxt.Text = da.GetValue(7).ToString() + (" ");
                        addresstxt.Text = da.GetValue(8).ToString() + (" ");




                        profilepic.Image = ImageLoader.ImageFromStream((byte[])da["profile_picture"]);
                        signaturepic.Image = ImageLoader.ImageFromStream((byte[])da["Signature"]);

                    }

                    con1.Close();
                }
                else
                {
                    // Handle invalid input string
                }

                // Clear the TextBox
                Scanrfidtxt.Clear();

                // Prevent the Enter key from being processed by the TextBox
                e.Handled = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
   
