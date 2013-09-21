using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace _01_Download_Manager
{
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //store save path
            string log01 = txtsavepath.Text;
            string dtl = "mawaliya.dat";
            FileStream fs = new FileStream(dtl, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(log01);
            sw.Close();
            fs.Close();

        }

        private void setting_Load(object sender, EventArgs e)
        {
            txtsavepath.Text = Application.ExecutablePath+"fes\\";
        }
    }
}
