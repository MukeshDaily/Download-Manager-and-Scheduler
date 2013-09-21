/*Copyright ©  2010-2011 01FES  
 * www.01fes.com
 * Created by mukesh kumar mawaliya(0&1)
 * previous version 0001 for dot net framework 3.5 [2010]
 * previous version 0010 for dot net framework 4 [2011]
 * Update Version  0011 for dot net framework 4   [2011]
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
namespace _01_Download_Manager
{
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright © 2010-2011 01FES\nCreated by mukesh kumar mawaliya(0&1)\n www.01fes.com\n version 0010");
            System.Diagnostics.Process.Start("http://www.01fes.com/");

        }

        private void button4_Click(object sender, EventArgs e)
        {
           System.Diagnostics.Process.Start("http://www.01fes.com/01connect.php");
     
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            download d = new download();
           d.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            db_refresh();
            
           
            /*
            TestObject test2 = new TestObject()
            {
                Link = "ha",
                Path = "as",
                Size = "ad",
                Time = "asd",
                Status = "a"
            };

            List<TestObject> list = new List<TestObject>();
            list.Add(test1);
            list.Add(test2);
           
            dataGridView1.DataSource = list;
         */
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            db_refresh();
        }
        private void db_refresh() 
        {
            this.dataGridView1.Rows.Clear();
            string dtl = "01.dat";

            FileStream fs = new FileStream(dtl, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string history = sr.ReadLine();
            history += sr.ReadToEnd();

            string[] his = history.Split('`');
            foreach (string h in his)
            {
                string[] da = h.Split('~');
                this.dataGridView1.Rows.Add(da[0], da[1], da[2], da[3], da[4], da[5]);
            }
            fs.Close();
            
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

            //01 add to complete download file as database
            string log01 = "www.01fes.com ~ Update ~0MB ~0MB ~0% ~ 0:0:0 0:0 \n";
            string dtl = "01.dat";
            FileStream fs = new FileStream(dtl, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(log01);
            sw.Close();
            fs.Close();


            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setting stng = new setting();
            stng.Show();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmReminder rem = new frmReminder();
            rem.Show();
        }

        
    }


    /*
    class TestObject
    {
        public string Link { get; set; }
        public string Path { get; set; }
        public string Size { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
    }
    */

}
