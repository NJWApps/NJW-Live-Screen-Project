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
            int screen = 1;
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (arg.Length == 1)
                {
                    try
                    {
                        screen = int.Parse(arg);
                        //MessageBox.Show(screen.ToString());
                    }
                    catch (Exception)
                    {

                    }

                }

            }
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
    }
}
