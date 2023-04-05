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
    // Check if control is a panel
    if (prop is Panel)
    {
        if (prop.Tag as string == "front-background")
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
        ControlMoverOrResizer.Init(prop);

        if (prop.Tag != null && prop.Tag.ToString() == "front")
            panelFront.Controls.Add(prop);
        else
            panelBack.Controls.Add(prop);

        // Save control's original position in Tag property
        if (prop.Tag == null)
        {
            prop.Tag = prop.Location;
        }
        else if (prop.Tag is string tagString)
        {
            string[] tagValues = tagString.Split(',');
            if (tagValues.Length == 2 && int.TryParse(tagValues[0], out int x) && int.TryParse(tagValues[1], out int y))
            {
                prop.Tag = new Point(x, y);
            }
        }

        // Restrict controls within panel
        prop.MouseDown += (sender, e) =>
        {
            var control = sender as Control;
            var panel = control.Parent as Panel;

            if (panel != null)
            {
                var maxPosX = panel.ClientSize.Width - control.Width;
                var maxPosY = panel.ClientSize.Height - control.Height;

                // Record mouse position relative to control
                var mouseOffset = e.Location;

                // Convert mouse position to panel coordinates
                mouseOffset.Offset(control.Location);

                // Store mouse offset in Tag property
                control.Tag = mouseOffset;
            }
        };

        prop.MouseMove += (sender, e) =>
        {
            var control = sender as Control;
            var panel = control.Parent as Panel;

            if (panel != null && e.Button == MouseButtons.Left)
            {
                // Get mouse offset from Tag property
                var mouseOffset = control.Tag is Point tagPoint ? tagPoint : Point.Empty;

                // Calculate new control position based on mouse offset and mouse position
                var newLocation = panel.PointToClient(MousePosition);
                newLocation.Offset(-mouseOffset.X, -mouseOffset.Y);

                // Restrict control movement within panel
                newLocation.X = Math.Max(0, Math.Min(newLocation.X, panel.ClientSize.Width - control.Width));
                newLocation.Y = Math.Max(0, Math.Min(newLocation.Y, panel.ClientSize.Height - control.Height));

                // Update control position
                control.Location = newLocation;
            }
        };

        // Restore control's original position if it was dragged outside the panel
       prop.MouseUp += (sender, e) =>
{
    var control = sender as Control;
    var panel = control.Parent as Panel;

    if (panel != null)
    {
        var maxPosX = panel.ClientSize.Width - control.Width;
        var maxPosY = panel.ClientSize.Height - control.Height;

        if(control.Location.X < 0 || control.Location.Y < 0 ||
           control.Location.X > maxPosX || control.Location.Y > maxPosY)
        {
            if (control.Tag is Point tagPoint)
            {
                control.Location = tagPoint;
            }
            else if (control.Tag is string tagString)
            {
                string[] parts = tagString.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                {
                    control.Location = new Point(x, y);
                }
            }
          }
 else
            {
                // Save new control position in Tag property
                control.Tag = control.Location;
            }
        }
    };

    }
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
