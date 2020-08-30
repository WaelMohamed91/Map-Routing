using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Fixedspeed : UserControl
    {
        public Fixedspeed()
        {
            InitializeComponent();
        }

        private void fixed_speed_Click(object sender, EventArgs e)
        {
            Speed obj_FS = new Speed();
            obj_FS.Show();
        }
    }
}
