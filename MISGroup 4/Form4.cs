using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MISGroup_4.Modules;
using MISGroup_4.Helpers;
using System.Linq;
using MISGroup_4.Models;
using System.Drawing.Printing;

namespace MISGroup_4
{
    public partial class Form4 : Form
    {
        PrintPreviewDialog prntprw = new PrintPreviewDialog();
        PrintDocument pntdoc = new PrintDocument();
        public static Form4 instance;
        private bool IsView = false;
        private Student student;
        public Form1 form1;
       
       
        public Form4(Form1 _form1)
        {
            form1 = _form1;
            InitializeComponent();
            instance = this;
        }
        public Form4(string studentId)
        {
            InitializeComponent();
            IsView = true;
            GetStudent(studentId);
            
        }

        

        private void GetStudent(string studentId)
        {
            try
            {
                student = new StudentInfo().Get(studentId);
                var temp = new IdTemplate();
                var properties = temp.Get(student);
              
                if(properties.Count > 0)
                {
                    //this.Controls.Clear();
                    panelBack.Controls.Clear();
                    panelFront.Controls.Clear();


                    properties.ForEach(prop =>
                    {
                        //Check Control if panel
                        if (prop.GetType() == typeof(Panel))
                        {
                            if ((string)prop.Tag == "front-background")
                            {
                                panelFront.BackgroundImage = prop.BackgroundImage;
                                panelFront.BackgroundImageLayout = ImageLayout.Stretch;
                            }
                            else
                            {
                                panelBack.BackgroundImage = prop.BackgroundImage;
                                panelBack.BackgroundImageLayout = ImageLayout.Stretch;

                            }

                        }
                        else
                        {

                            if ((string)prop.Tag == "front")
                                panelFront.Controls.Add(prop);
                            else
                                panelBack.Controls.Add(prop);


                        }


                        //panel1.Controls.Add(prop);
                    });

                }
                else
                {
                   
                    StudentId.Text = student.StudentId;
                    Program.Text = student.Program;
                    Fullname.Text = student.Fullname;
                    GuardianName.Text = student.GuardianName;
                    Address.Text = student.Address;
                    Contact.Text = student.Contact;
                    ProfilePicture.Image = student.ProfilePicture;
                    Signature.Image = student.Signature;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click_1(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
       

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var temp =  new List<Control>();
            using (Form1 form = new Form1(this))
            {
                this.panel1.Controls.OfType<Control>().ToList().ForEach(prop =>
                {
                    if(prop.GetType() != typeof(Button))
                    {
                        temp.Add(prop);
                        if(prop.GetType() == typeof(Panel))
                        {
                            prop.Controls.OfType<Control>().ToList().ForEach(p =>
                            {
                                temp.Add(p);

                            });
                        }
                    }
                });
                form.GetIdTemplate(temp);
                form.ShowDialog();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
        public void GetIdTemp(List<Control> properties)
        {
            panelFront.Controls.Clear();
            panelBack.Controls.Clear();

            properties.ForEach(prop =>
            {
                //Check Control if panel
                if (prop.GetType() == typeof(Panel))
                {
                    if ((string)prop.Tag == "front-background")
                    {
                        panelFront.BackgroundImage = prop.BackgroundImage;
                        panelFront.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        panelBack.BackgroundImage = prop.BackgroundImage;
                        panelBack.BackgroundImageLayout = ImageLayout.Stretch;

                    }

                }
                else
                {
                   
                    if ((string)prop.Tag == "front")
                        panelFront.Controls.Add(prop);
                    else
                        panelBack.Controls.Add(prop);


                }
               

                //panel1.Controls.Add(prop);
            });
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                
            
        }
        
        private void Print_Click(object sender, EventArgs e)
        {
            Print(this.panel1);
        }
        public void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panel1 = pnl;
            getprintarea(pnl);
            prntprw.Document = pntdoc;
            pntdoc.PrintPage += new PrintPageEventHandler(pntdoc_printpage);
            prntprw.ShowDialog();
        }
        public void pntdoc_printpage (object sender,PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memorying,(pagearea.Width/2)-(this.panel1.Width/2),this.panel1.Location.Y);
        }
        Bitmap memorying;
        public void getprintarea(Panel pnl)
        {
            memorying = new Bitmap(pnl.Width,pnl.Height);
            pnl.DrawToBitmap(memorying, new Rectangle(0, 0, pnl.Width, pnl.Height));


        }

        private void print_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }

    
}
