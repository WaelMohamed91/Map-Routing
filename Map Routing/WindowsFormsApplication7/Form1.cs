using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Sel_speed_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Fixedspeed obj = new Fixedspeed();
            panel1.Controls.Add(obj);
        }
    }
}
