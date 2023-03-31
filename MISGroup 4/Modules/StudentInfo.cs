using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MISGroup_4.Helpers;
using MISGroup_4.Models;
using MySql.Data.MySqlClient;
namespace MISGroup_4.Modules
{
    public class StudentInfo:Database
    {
        public List<Student> GetStudents(string search)
        {
            var studentList = new List<Student>();
            try
            {
                string con_string = "server=localhost;database=mis;port=3306;username=root;password=mark_123";

                using (var conn = new MySqlConnection(con_string))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("select * from students where rfid LIKE @rfid  or first_name LIKE @first_name or last_name LIKE @last_name or student_id LIKE @student_id", conn))
                    {
                        cmd.Parameters.AddWithValue("@student_id", $"%{search}%");
                        cmd.Parameters.AddWithValue("@first_name", $"%{search}%");
                        cmd.Parameters.AddWithValue("@last_name", $"%{search}%");
                        cmd.Parameters.AddWithValue("@rfid", $"%{search}%");
                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                studentList.Add(new Student
                                {
                                    rfid = rd.GetString("rfid"),
                                    StudentId = rd.GetString("student_id"),
                                    Program = rd.GetString("program"),
                                    Firstname = rd.GetString("first_name"),
                                    Lastname = rd.GetString("last_name"),
                                    Middlename = rd.GetString("middle_name"),
                                    Extname = rd.GetString("ext_name"),
                                    Contact = rd.GetString("contact"),
                                    GuardianName = rd.GetString("guardian_name"),
                                    Address = rd.GetString("address"),
                                    
                                  

                                });
                            }
                        }
                                    

                        
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return studentList;
        }


        public Student Get(string _id)
        {
            var student = new Student();
            try
            {
                using (con = new MySqlConnection(ConnString))
                {
                    using (cmd = new MySqlCommand("SELECT * FROM students where rfid = @rfid", con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@rfid", _id);
                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.HasRows)
                            {
                                while (rd.Read())
                                {
                                    student.rfid = rd.GetString("rfid");
                                    student.StudentId = rd.GetString("student_id");
                                    student.Program = rd.GetString("program");
                                    student.Lastname = rd.GetString("last_name");
                                    student.Firstname = rd.GetString("first_name");
                                    student.Middlename = rd.GetString("middle_name");
                                    student.Extname = rd.GetString("ext_name");
                                    student.GuardianName = rd.GetString("guardian_name");
                                    student.Address = rd.GetString("address");
                                    student.Contact = rd.GetString("contact");
                                    student.ProfilePicture = ImageLoader.ImageFromStream((byte[])rd["profile_picture"]);
                                    student.Signature = ImageLoader.ImageFromStream((byte[])rd["Signature"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Student Get: {ex.Message}" );
                
            }
                return student;
        }
    }
}
