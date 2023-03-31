using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MISGroup_4.Helpers;
using MISGroup_4.Models;
using MISGroup_4.Modules;

namespace MISGroup_4
{
    public partial class Form1 : Form
    {
        public Form4 form4;
        public Form1(Form4 _form4)
        {
            form4= _form4;
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK);
                {
                    imagelocation = dialog.FileName;
                    panelFront.BackgroundImage = ImageLoader.ResizeImage(imagelocation, panelFront.Size);
                    panelFront.BackgroundImageLayout = ImageLayout.Stretch;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //public void GetIdTemplate(string studentId)
        //{
        //    var idTemp = new IdTemplate();
        //    var student = new StudentInfo().Get(studentId);
        //    idTemp.Get(student).ForEach(prop =>
        //    {
        //        panelFront.Controls.Add(prop);
        //        ControlMoverOrResizer.Init(prop);
        //    });

        //}

        public void GetIdTemplate(List<Control> properties)
        {
            properties.ForEach(prop =>
            {
                //Check Control if panel
                if(prop.GetType() == typeof(Panel))
                {
                    if((string)prop.Tag == "front-background")
                    {
                        panelFront.BackgroundImage = prop.BackgroundImage; 
                        panelFront.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        panelBack.BackgroundImage = prop.BackgroundImage;
                        panelBack.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    


                } else
                {
                    ControlMoverOrResizer.Init(prop);
                    
                    if ((string)prop.Tag == "front")
                        panelFront.Controls.Add(prop);
                    else
                        panelBack.Controls.Add(prop);


                }


                //panelFront.Controls.Add(prop);
            });
        }

        private void btnSaveTempalte_Click(object sender, EventArgs e)
        {
            var properties = new List<Control>();
            panelFront.Controls.OfType<Control>().ToList().ForEach(control =>
            {

                properties.Add(control);
                    
                //controls.Append($"{control.GetType().ToString()} \n")
            });
            panelBack.Controls.OfType<Control>().ToList().ForEach(control =>
            {

                properties.Add(control);
                

                //controls.Append($"{control.GetType().ToString()} \n")
            });

            //Eh ang Background sa Front
            
            
            panelFront.Tag = "front-background";
            panelBack.Tag = "back-background";
            properties.Add(panelFront);
            properties.Add(panelBack);
            

            var tmp = new IdTemplate();
            tmp.SaveTemplate(properties); 
            //MessageBox.Show(controls.ToString());
        }

        private void panelFront_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var temp = new List<Control>();

          
            this.panel2.Controls.OfType<Control>().ToList().ForEach(prop =>
            {
                if (prop.GetType() != typeof(Button))
                {
                    temp.Add(prop);
                    if (prop.GetType() == typeof(Panel))
                    {
                        prop.Controls.OfType<Control>().ToList().ForEach(p =>
                        {
                            temp.Add(p);

                        });
                    }
                }
            });

            form4.GetIdTemp(temp);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) ;
                {
                    imagelocation = dialog.FileName;
                    panelBack.BackgroundImage = ImageLoader.ResizeImage(imagelocation, panelBack.Size);
                    panelBack.BackgroundImageLayout = ImageLayout.Stretch;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
