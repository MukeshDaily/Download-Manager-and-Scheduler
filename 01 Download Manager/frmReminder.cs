using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace _01_Download_Manager
{
    public partial class frmReminder : Form
    {
        string temp;

        [DllImport("user32.dll")]
        public static extern void LockWorkStation();
        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);


        public frmReminder()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
             String tmpdate = dateTimePicker1.Value.ToShortDateString();
             label1.Text = tmpdate;
                  
        }
     

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                label2.Text = label1.Text + " " + comboBox1.Text + ":" + comboBox2.Text + ":00" + " " + comboBox3.Text;

                timer1.Enabled = true;
            }
            else 
            {
                MessageBox.Show(" Plz select time!");
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            temp = Convert.ToString(DateTime.Now);
            if (temp == label2.Text) 
            {
                timer1.Enabled = false;
                

                if (comboBox7.Text == "Lock")
                {
                    LockWorkStation();

                }

                else if (comboBox7.Text == "Stand By")
                {
                    Application.SetSuspendState(PowerState.Suspend, true, true);

                }
                else if (comboBox7.Text == "Hibernate")
                {
                    Application.SetSuspendState(PowerState.Hibernate, true, true);

                }
                else if (comboBox7.Text == "Shut Down")
                {

                    ExitWindowsEx(0, 0);
                }
                else if ( txtUrlfes.Text != "")
                {

                    download dwn = new download();
                    dwn.txtUrl.Text = txtUrlfes.Text;
                    dwn.Show();
                    dwn.future_start();
                }
                else
                {
                    MessageBox.Show(richTextBox1.Text);
 
                }
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String tmpdate = dateTimePicker1.Value.ToShortDateString();
            label1.Text = tmpdate;
        }

       
    }
}
