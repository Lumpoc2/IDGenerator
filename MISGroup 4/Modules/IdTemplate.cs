using MISGroup_4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using MISGroup_4.Helpers;

namespace MISGroup_4.Modules
{
    public class IdTemplate : Database
    {

        public List<Control> Get(Student student)
        {
            var idProperties = new List<Control>();
            try
            {
                using (con = new MySqlConnection(ConnString))
                {
                    using (cmd = new MySqlCommand("SELECT * FROM id_properties", con))
                    {
                        con.Open();
                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.HasRows)
                            {
                                while (rd.Read())
                                {
                                    idProperties.Add(GetControlClass(rd, student));
                                   // MessageBox.Show($"{rd.GetString("name")}");
                                }
                            }
                            //Kung empty ang table id_propersties
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"get:{ex.Message}");
            }

            return idProperties;
        }


        public void SaveTemplate(List<Control> properties)
        {
            string query = null;
            try
            {
                StringBuilder queryBuilder = new StringBuilder();
                using (con = new MySqlConnection(ConnString))
                {
                    using (cmd = new MySqlCommand("", con))
                    {
                        con.Open();
                        var tr = con.BeginTransaction();
                        cmd.CommandText = "DELETE FROM id_properties";
                        cmd.ExecuteNonQuery();
                        
                        properties.ForEach(prop => {

                            string[] propType = prop.GetType().ToString().Split(".");
                            string size = $"{prop.Size.Width}, {prop.Size.Height}";
                            string location = $"{prop.Location.X}, {prop.Location.Y}";
                            cmd.CommandText = "INSERT INTO id_properties (name, object_type, assigned_panel, size, location,background ,image) VALUES (@name, @object_type, @assigned_panel, @size, @location, @background, @image)";
                            cmd.Parameters.AddWithValue("@name", prop.Name);
                            cmd.Parameters.AddWithValue("@object_type", propType[propType.Length - 1]);
                            cmd.Parameters.AddWithValue("@assigned_panel",prop.Tag);
                            cmd.Parameters.AddWithValue("@size",size);
                            cmd.Parameters.AddWithValue("@location",location);
                            cmd.Parameters.AddWithValue("@background", (string)prop.Tag != null ? prop.Tag.ToString() : null);
                        cmd.Parameters.AddWithValue("@image", (string)prop.Tag != null ? ImageLoader.ImageBuffer(prop.BackgroundImage):null);
                                
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                         
                        });

                        tr.Commit();
                        MessageBox.Show("Success");
                        
                    }
                }

            }
            catch(Exception ex)
            {
                
                MessageBox.Show(ex.Message + $"{query}");
            }
        }

        private Control GetControlClass( MySqlDataReader rd, Student student)
        {
            Control obj = new Control();
            string[] size = rd.GetString("size").Split(',');
            string[] location = rd.GetString("location").Split(',');


            switch (rd.GetString("object_type"))
            {


                case "Label":
                    obj = new Label
                    {
                        Name = rd.GetString("name"),
                        Text = GetPropertyValue(rd.GetString("name"), student),
                        Size = new Size(int.Parse(size[0]), int.Parse(size[1])),
                        Location = new Point(int.Parse(location[0]), int.Parse(location[1])),
                        Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                       
                     
                    }; 
                    break;


                    break;
                case "PictureBox":

                    obj = new PictureBox
                    {
                        Name = rd.GetString("name"),
                        Size = new Size(int.Parse(size[0]), int.Parse(size[1])),
                        Location = new Point(int.Parse(location[0]), int.Parse(location[1])),
                        BackgroundImage = rd.GetString("assigned_panel") == "front"? student.ProfilePicture:student.Signature,
                        BackgroundImageLayout = ImageLayout.Stretch,

                    };
              
                    //MessageBox.Show($"{obj.Location.ToString()} {obj.Name}");
                    break;
                case "Panel":
                    obj = new Panel
                    {
                        Name = rd.GetString("name"),
                        Size = new Size(int.Parse(size[0]), int.Parse(size[1])),
                       Location = new Point(int.Parse(location[0]), int.Parse(location[1])),
                       Tag = rd.GetString("assigned_panel"),
                        //BackgroundImage = rd.GetString("assigned_panel") == "front" ?student.Signature: student.ProfilePicture ,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        BackgroundImage = ImageLoader.ImageFromStream((byte[])rd["image"]),
                        

                    };
                    // MessageBox.Show($"{obj.BackgroundImage}
                   
                    break;

            }
            obj.Tag = rd.GetString("assigned_panel");
            return obj;
        }

        private string GetPropertyValue(string controlName, Object obj)
        {

            Type t = obj.GetType();
            foreach (var prop in t.GetProperties())
                if (prop.Name == controlName)
                    return (string)prop.GetValue(obj);
           return null;
        }

       
    }
}