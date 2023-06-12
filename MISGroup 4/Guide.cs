using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MISGroup_4
{
    public partial class Guide : Form
    {
        
        private static Guide _intance;
        public static Guide Instance
        {
            get
            {
                if (_intance == null)
                    _intance = new Guide();
                return _intance;
            }
        }
        public Guide()
        {
            InitializeComponent();
        }

        private void Guide_Load(object sender, EventArgs e)
        {

        }
    }
}
