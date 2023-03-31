using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MISGroup_4
{
    public partial class about : Form
    {
        private static about _intance;
        public static about Instance
        {
            get
            {
                if (_intance == null)
                    _intance = new about();
                return _intance;
            }
        }
        public about()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void about_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;

            System.Drawing.Drawing2D.GraphicsPath gs = new System.Drawing.Drawing2D.GraphicsPath();
            gs.AddEllipse(0, 0, pictureBox2.Width - 3, pictureBox2.Height - 3);
            Region sg = new Region(gs);
            pictureBox2.Region = sg;

            System.Drawing.Drawing2D.GraphicsPath gb = new System.Drawing.Drawing2D.GraphicsPath();
            gb.AddEllipse(0, 0, pictureBox3.Width - 3, pictureBox3.Height - 3);
            Region gr = new Region(gb);
            pictureBox3.Region = gr;

            System.Drawing.Drawing2D.GraphicsPath rp = new System.Drawing.Drawing2D.GraphicsPath();
            rp.AddEllipse(0, 0, pictureBox4.Width - 3, pictureBox4.Height - 3);
            Region sb = new Region(rp);
            pictureBox4.Region = sb;

            System.Drawing.Drawing2D.GraphicsPath lo = new System.Drawing.Drawing2D.GraphicsPath();
            lo.AddEllipse(0, 0, pictureBox5.Width - 3, pictureBox5.Height - 3);
            Region ge = new Region(lo);
            pictureBox5.Region = ge;

            System.Drawing.Drawing2D.GraphicsPath li = new System.Drawing.Drawing2D.GraphicsPath();
            li.AddEllipse(0, 0, pictureBox6.Width - 3, pictureBox6.Height - 3);
            Region le = new Region(li);
            pictureBox6.Region = le;

            System.Drawing.Drawing2D.GraphicsPath sh = new System.Drawing.Drawing2D.GraphicsPath();
            sh.AddEllipse(0, 0, pictureBox7.Width - 3, pictureBox7.Height - 3);
            Region lu = new Region(sh);
            pictureBox7.Region = lu;

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 da = new Form3();
            da.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
