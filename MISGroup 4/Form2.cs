using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using MISGroup_4.Helpers;
using MySql.Data.MySqlClient;


namespace MISGroup_4
{

    public partial class Form2 : Form
    {
        public static Form2 instance;
        VideoCaptureDevice frame;
        FilterInfoCollection Devices;
        private bool isEdit = false;
        public Form2()
        {
            InitializeComponent();
            instance = this;
        }

        public Form2(string _studentId)
        {
            InitializeComponent();
            isEdit = true;
            GetStudent(_studentId);
        }


        private void GetStudent(string studentId)
        {
            try
            {
                string con_string = "server=localhost;database=mis;port=3306;username=root;password=mark_123";

                using (var conn = new MySqlConnection(con_string))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("select * from students where rfid = @rfid", conn))
                    {
                        cmd.Parameters.AddWithValue("@rfid", studentId);
                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            Rfid.Enabled = false;
                            textBox7.Enabled = false;
                            //string course = textBox9.Text;
                            //string student_id = textBox7.Text;
                            //string first_name = textBox1.Text;
                            //string last_name = textBox3.Text;
                            //string middle_name = textBox2.Text;
                            //string ext_name = textBox4.Text;
                            //string guardian_name = textBox8.Text;
                            //string address = textBox5.Text;
                            //string contact = textBox6.Text;
                            while (rd.Read())
                            {
                                Rfid.Text = rd.GetString("rfid");
                                textBox7.Text = rd.GetString("student_id");
                                textBox9.Text = rd.GetString("program");
                                textBox1.Text = rd.GetString("first_name");
                                textBox3.Text = rd.GetString("last_name");
                                textBox2.Text = rd.GetString("middle_name");
                                textBox4.Text = rd.GetString("ext_name");
                                textBox6.Text = rd.GetString("contact");
                                textBox8.Text = rd.GetString("guardian_name");
                                textBox5.Text = rd.GetString("address");
                                pictureBox3.Image = ImageLoader.ImageFromStream((byte[])rd["profile_picture"]);
                                pictureBox2.Image = ImageLoader.ImageFromStream((byte[])rd["Signature"]);
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

        void Start_cam()
        {
            Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            frame = new VideoCaptureDevice(Devices[0].MonikerString);
            frame.NewFrame += new AForge.Video.NewFrameEventHandler(NewFrame_event);
            frame.Start();
        }
      
        void NewFrame_event(object send, NewFrameEventArgs eventArgs)
        {

            pictureBox1.Image = (Image)eventArgs.Frame.Clone();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start_cam();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "PNG files(*.png)|*.png| All files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) ;
                {
                    imagelocation = dialog.FileName;
                    pictureBox2.ImageLocation = imagelocation;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            pictureBox3.Image = pictureBox1.Image;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            string con_string = "server=localhost;Database=mis;port=3306;username=root;password=mark_123";
            MySqlConnection conn = new MySqlConnection(con_string);

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox9.Text) ||
               string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox3.Text) ||
               string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox8.Text) ||
               string.IsNullOrEmpty(textBox5.Text) ||
               string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Please Don't Leave Empty", "Empty Inputs");
                return;
            }
            else
            {
                try
                {
                    conn.Open();
                    string rfid = Rfid.Text;
                    string course = textBox9.Text;
                    string student_id = textBox7.Text;
                    string first_name = textBox1.Text;
                    string last_name = textBox3.Text;
                    string middle_name = textBox2.Text;
                    string ext_name = textBox4.Text;
                    string guardian_name = textBox8.Text;
                    string address = textBox5.Text;
                    string contact = textBox6.Text;
                    string query;

                    if(isEdit)
                    {
                        query = "update students set program = @program, first_name = @first_name, last_name = @last_name, middle_name = @middle_name, ext_name = @ext_name, guardian_name= @guardian_name, contact = @contact, address = @address, profile_picture = @profile_picture, Signature = @Signature  student_id = @student_id where rfid = @rfid";
                    } else
                    {
                         query = "insert into students(rfid,student_id,program,first_name,last_name,middle_name,ext_name,guardian_name,contact,address,profile_picture,Signature) VALUES (@rfid,@student_id,@program,@first_name,@last_name,@middle_name,@ext_name,@guardian_name,@contact,@address, @profile_picture,@Signature) ";
                    }
                  

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@rfid", rfid);
                        cmd.Parameters.AddWithValue("@student_id", student_id);
                        cmd.Parameters.AddWithValue("@program", course);
                        cmd.Parameters.AddWithValue("@first_name", first_name);
                        cmd.Parameters.AddWithValue("@last_name", last_name);
                        cmd.Parameters.AddWithValue("@middle_name", middle_name);
                        cmd.Parameters.AddWithValue("@ext_name", ext_name);
                        cmd.Parameters.AddWithValue("@guardian_name", guardian_name);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@profile_picture", ImageLoader.ImageBuffer(pictureBox3.Image));
                        cmd.Parameters.AddWithValue("@Signature", ImageLoader.ImageBuffer(pictureBox2.Image));
                      

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                       
                    }
                    if (isEdit)
                        MessageBox.Show("Success", "Data Updated");
                    else
                        MessageBox.Show("Success", "Data Added");


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                conn.Close();
            }
            Form3.Instance.DisplayData("");

        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Rfid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }
    }
}
