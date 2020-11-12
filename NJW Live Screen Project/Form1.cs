using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NJW_Live_Screen_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Rectangle rect;
        private Bitmap areaCapture;
        int screen = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Stop();
            //using (Form2 form = new Form2())
            //{

            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        this.pictureBox1.Image = form.sentCapture; //this line returns an error that sentCapture does not exist
            //    }
            //}
            
            //foreach (string arg in Environment.GetCommandLineArgs())
            //{
            //    if (arg.Length == 1)
            //    {
            //        try
            //        {
            //            screen = int.Parse(arg);
            //            //MessageBox.Show(screen.ToString());
            //        }
            //        catch (Exception)
            //        {

            //        }

            //    }

            //}
            try
            {
rect = new Rectangle(Screen.AllScreens[screen].WorkingArea.Location.X, Screen.AllScreens[screen].WorkingArea.Location.Y, Screen.AllScreens[screen].Bounds.Width, Screen.AllScreens[screen].Bounds.Height);
            areaCapture = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(areaCapture))
            {
                //g.CopyFromScreen(Point.Empty, Point.Empty, rect.Size);
                g.CopyFromScreen(Screen.AllScreens[screen].WorkingArea.Location.X, Screen.AllScreens[screen].WorkingArea.Location.Y, 0, 0, rect.Size);
            }
            pictureBox1.Image = areaCapture;
            }
            catch (Exception)
            {

              
            }
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideToolStripMenuItem.Text == "Hide")
            {
                hideToolStripMenuItem.Text = "Show";
                this.Hide();
            }
            else
            {
                hideToolStripMenuItem.Text = "Hide";
                this.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int screens = Screen.AllScreens.Length;
            switch (screens)
            {
                case 1:

                    break;
                case 2:
                    toolStripMenuItem3.Visible = true;
                    toolStripMenuItem7.Visible = true;


                    break;
                case 3:
                    toolStripMenuItem3.Visible = true;
                    toolStripMenuItem7.Visible = true;
                    toolStripMenuItem4.Visible = true;
                    toolStripMenuItem8.Visible = true;

                    break;
                case 4:
                    toolStripMenuItem3.Visible = true;
                    toolStripMenuItem7.Visible = true;
                    toolStripMenuItem4.Visible = true;
                    toolStripMenuItem8.Visible = true;
                    toolStripMenuItem5.Visible = true;
                    toolStripMenuItem9.Visible = true;
              

                    break;
                default:
                    break;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            screen = 0;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            screen = 1;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            screen = 2;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            screen = 3;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            this.Height = Screen.AllScreens[0].Bounds.Height;
            this.Width = Screen.AllScreens[0].Bounds.Width;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Location = Screen.AllScreens[1].WorkingArea.Location;
            this.Height = Screen.AllScreens[1].Bounds.Height;
            this.Width = Screen.AllScreens[1].Bounds.Width;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Location = Screen.AllScreens[2].WorkingArea.Location;
            this.Height = Screen.AllScreens[2].Bounds.Height;
            this.Width = Screen.AllScreens[2].Bounds.Width;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Location = Screen.AllScreens[3].WorkingArea.Location;
            this.Height = Screen.AllScreens[3].Bounds.Height;
            this.Width = Screen.AllScreens[3].Bounds.Width;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
