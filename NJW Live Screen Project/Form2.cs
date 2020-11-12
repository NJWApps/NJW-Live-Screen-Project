using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NJW_Live_Screen_Project
{
    public partial class Form2 : Form
    {
        Rectangle rect;
        private Bitmap areaCapture;
        public Bitmap sentCapture
        {
            get { return areaCapture; }
        }
        public Form2()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = string.Empty;
            this.ShowInTaskbar = false;

            //this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            this.Opacity = 0.01;
            
        }

        //private void Form2_MouseDown(object sender, MouseEventArgs e)
        //{
        //    rect = new Rectangle(e.X, e.Y, 0, 0);
        //    this.Invalidate();
        //}

        //private void Form2_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        rect = new Rectangle(rect.Left, rect.Top, e.X - rect.Left, e.Y - rect.Top);
        //    }
        //    this.Invalidate();
        //}

        //private void Form2_Paint(object sender, PaintEventArgs e)
        //{
        //    using (Pen pen = new Pen(Color.CadetBlue, 3))
        //    {
        //        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
        //        e.Graphics.DrawRectangle(pen, rect);
        //    }
        //}

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
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
            //MessageBox.Show(screen.ToString());

            try
            {
                this.Location = Screen.AllScreens[screen].WorkingArea.Location;
                this.Height = Screen.AllScreens[screen].Bounds.Height;
                this.Width = Screen.AllScreens[screen].Bounds.Width;
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception)
            {
                Environment.Exit(1);
            }

            rect = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            areaCapture = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(areaCapture))
            {
                //g.CopyFromScreen(Point.Empty, Point.Empty, rect.Size);
                g.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, rect.Size);
            }
            DialogResult = DialogResult.OK;
        }
    }
    }

