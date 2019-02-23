using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security;

namespace Library.Windows.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 9, 9)); // adjust these parameters to get the lookyou want.
        }

        
        #region controlButtons
        #region colorir PMinimize
        private void PMinimize_MouseDown(object sender, MouseEventArgs e)
        {
            PMinimize.BackgroundImage = global::Resources.Properties.Resources.window_minimize3;
        }

        private void PMinimize_MouseHover(object sender, EventArgs e)
        {
            PMinimize.BackgroundImage = global::Resources.Properties.Resources.window_minimize2;
        }

        private void PMinimize_MouseLeave(object sender, EventArgs e)
        {
            PMinimize.BackgroundImage = global::Resources.Properties.Resources.window_minimize1;
        }

        private void PMinimize_MouseUp(object sender, MouseEventArgs e)
        {
            PMinimize.BackgroundImage = global::Resources.Properties.Resources.window_minimize2;
        }
        #endregion

        #region colorir PMaximize
        private void PMaximize_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.Fixed)
            {
                if (this.WindowState == FormWindowState.Maximized)
                    PMaximize.BackgroundImage = global::Resources.Properties.Resources.window_restore3;
                else
                    PMaximize.BackgroundImage = global::Resources.Properties.Resources.window_maximize3;
            }
        }

        private void PMaximize_MouseHover(object sender, EventArgs e)
        {
            if (!this.Fixed)
            {
                if (this.WindowState == FormWindowState.Maximized)
                    PMaximize.BackgroundImage = global::Resources.Properties.Resources.window_restore2;
                else
                    PMaximize.BackgroundImage = global::Resources.Properties.Resources.window_maximize2;
            }
        }

        private void PMaximize_MouseLeave(object sender, EventArgs e)
        {
            if (!this.Fixed)
            {
                if (this.WindowState == FormWindowState.Maximized)
                    PMaximize.BackgroundImage = global::Resources.Properties.Resources.window_restore1;
                else
                    PMaximize.BackgroundImage = global::Resources.Properties.Resources.window_maximize1;
            }
        }

        private void PMaximize_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.Fixed)
            {
                if (this.WindowState == FormWindowState.Maximized)
                    PMaximize.BackgroundImage = global::Resources.Properties.Resources.window_restore2;
                else
                    PMaximize.BackgroundImage = global::Resources.Properties.Resources.window_maximize2;
            }
        }
        #endregion

        #region colorir PClose
        private void PClose_MouseDown(object sender, MouseEventArgs e)
        {
            PClose.BackgroundImage = global::Resources.Properties.Resources.window_close3;
        }

        private void PClose_MouseHover(object sender, EventArgs e)
        {
            PClose.BackgroundImage = global::Resources.Properties.Resources.window_close2;
        }

        private void PClose_MouseLeave(object sender, EventArgs e)
        {
            PClose.BackgroundImage = global::Resources.Properties.Resources.window_close1;
        }

        private void PClose_MouseUp(object sender, MouseEventArgs e)
        {
            PClose.BackgroundImage = global::Resources.Properties.Resources.window_close2;
        }
        #endregion

        private void PMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PMaximize_Click(object sender, EventArgs e)
        {
            if (!this.Fixed)
            {
                if (this.WindowState == FormWindowState.Maximized)
                    this.WindowState = FormWindowState.Normal;
                else
                    this.WindowState = FormWindowState.Maximized;

                if (this.WindowState == FormWindowState.Maximized)
                    PMaximize.BackgroundImage = global::Resources.Properties.Resources.window_restore1;
                else
                    PMaximize.BackgroundImage = global::Resources.Properties.Resources.window_maximize1;
            }
        }

        private void PClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region header
        private bool mouse_is_down = false;
        private Point mouse_pos;

        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_pos.X = e.X;
            mouse_pos.Y = e.Y;
            mouse_is_down = true;
        }

        private void HeaderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        private void HeaderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down)
            {
                Point current_pos = Control.MousePosition;
                current_pos.X = current_pos.X - mouse_pos.X; // .Offset(mouseOffset.X, mouseOffset.Y);
                current_pos.Y = current_pos.Y - mouse_pos.Y;
                this.Location = current_pos;
            }
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            mouse_is_down = false;
        }
        #endregion


        int minHeigth = 42;
        int minWidth = 125;

        #region TopLeft
        private void PBTopLeft_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_pos.X = e.X;
            mouse_pos.Y = e.Y;
            mouse_is_down = true;
        }

        private void PBTopLeft_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        private void PBTopLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down && !this.Fixed)
            {
                Point current_pos = Control.MousePosition;
                current_pos.X = Control.MousePosition.X;
                current_pos.Y = Control.MousePosition.Y;

                int newHeigth = this.Height - (current_pos.Y - this.Location.Y);
                int newWidth = this.Width - (current_pos.X - this.Location.X);

                if (newHeigth >= minHeigth)
                    this.Height = newHeigth;
                else
                    this.Height = minHeigth;

                if (newWidth >= minWidth)
                    this.Width = newWidth;
                else
                    this.Width = minWidth;


                this.Location = current_pos;
            }
        }
        #endregion

        #region TopCenter
        private void PBTopCenter_MouseDown(object sender, MouseEventArgs e)
        {
            //mouse_pos.X = e.X;
            mouse_pos.Y = e.Y;
            mouse_is_down = true;
        }

        private void PBTopCenter_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        private void PBTopCenter_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down && !this.Fixed)
            {
                Point current_pos = Control.MousePosition;
                current_pos.X = this.Location.X;
                current_pos.Y = Control.MousePosition.Y;

                int newHeigth = this.Height - (current_pos.Y - this.Location.Y);

                if (newHeigth >= minHeigth)
                    this.Height = newHeigth;
                else
                    this.Height = minHeigth;

                this.Location = current_pos;
            }
        }
        #endregion

        #region TopRight
        private void PBTopRight_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_pos.X = e.X;
            mouse_pos.Y = e.Y;
            mouse_is_down = true;
        }

        private void PBTopRight_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        private void PBTopRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down && !this.Fixed)
            {
                Point current_pos = Control.MousePosition;
                current_pos.X = this.Location.X;
                current_pos.Y = Control.MousePosition.Y;

                int newHeigth = this.Height - (current_pos.Y - this.Location.Y);
                int newWidth = Control.MousePosition.X - this.Location.X;


                if (newHeigth >= minHeigth)
                    this.Height = newHeigth;
                else
                    this.Height = minHeigth;

                if (newWidth >= minWidth)
                    this.Width = newWidth;
                else
                    this.Width = minWidth;


                this.Location = current_pos;
            }
        }
        #endregion

        
        #region MiddleLeft
        private void PBMiddleLeft_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_pos.X = e.X;
            //mouse_pos.Y = e.Y;
            mouse_is_down = true;
        }

        private void PBMiddleLeft_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        private void PBMiddleLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down && !this.Fixed)
            {
                Point current_pos = Control.MousePosition;
                current_pos.X = Control.MousePosition.X;
                current_pos.Y = this.Location.Y;

                int newWidth = this.Width - (current_pos.X - this.Location.X);
                
                if (newWidth >= minWidth)
                    this.Width = newWidth;
                else
                    this.Width = minWidth;

                this.Location = current_pos;
            }
        }
        #endregion

        #region MiddleRight
        private void PBMiddleRight_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_pos.X = e.X;
            mouse_is_down = true;
        }

        private void PBMiddleRight_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        private void PBMiddleRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down && !this.Fixed)
            {
                int newWidth = Control.MousePosition.X - this.Location.X;
                
                if (newWidth >= minWidth)
                    this.Width = newWidth;
                else
                    this.Width = minWidth;
            }
        }
        #endregion


        #region BottonLeft
        private void PBBottonLeft_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_pos.X = e.X;
            mouse_pos.Y = e.Y;
            mouse_is_down = true;
        }

        private void PBBottonLeft_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        private void PBBottonLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down && !this.Fixed)
            {
                Point current_pos = Control.MousePosition;
                current_pos.X = Control.MousePosition.X;
                current_pos.Y = this.Location.Y;

                int newWidth = this.Width - (current_pos.X - this.Location.X);
                int newHeigth = Control.MousePosition.Y - this.Location.Y;


                if (newHeigth >= minHeigth)
                    this.Height = newHeigth;
                else
                    this.Height = minHeigth;

                if (newWidth >= minWidth)
                    this.Width = newWidth;
                else
                    this.Width = minWidth;


                this.Location = current_pos;
            }
        }
        #endregion

        #region BottonCenter
        private void PBBottonCenter_MouseDown(object sender, MouseEventArgs e)
        {
            //mouse_pos.X = e.X;
            mouse_pos.Y = e.Y;
            mouse_is_down = true;
        }

        private void PBBottonCenter_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        private void PBBottonCenter_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down && !this.Fixed)
            {
                int newHeigth = Control.MousePosition.Y - this.Location.Y;

                if (newHeigth >= minHeigth)
                    this.Height = newHeigth;
                else
                    this.Height = minHeigth;
            }
        }
        #endregion

        #region BottonRight
        private void PBBottonRight_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_pos.X = e.X;
            mouse_pos.Y = e.Y;
            mouse_is_down = true;
        }

        private void PBBottonRight_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        private void PBBottonRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down && !this.Fixed)
            {
                int newWidth = Control.MousePosition.X - this.Location.X;
                int newHeigth = Control.MousePosition.Y - this.Location.Y;
                
                if (newHeigth >= minHeigth)
                    this.Height = newHeigth;
                else
                    this.Height = minHeigth;

                if (newWidth >= minWidth)
                    this.Width = newWidth;
                else
                    this.Width = minWidth;
            }
        }
        #endregion



        private void Form1_Load(object sender, EventArgs e)
        {
            if (!this.Fixed)
            {
                this.PBTopLeft.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                this.PBTopCenter.Cursor = System.Windows.Forms.Cursors.SizeNS;
                this.PBTopRight.Cursor = System.Windows.Forms.Cursors.SizeNESW;
                this.PBMiddle1Left.Cursor = System.Windows.Forms.Cursors.SizeWE;
                this.PBMiddle1Right.Cursor = System.Windows.Forms.Cursors.SizeWE;
                this.PBMiddle2Left.Cursor = System.Windows.Forms.Cursors.SizeWE;
                this.PBMiddle2Right.Cursor = System.Windows.Forms.Cursors.SizeWE;
                this.PBBottonLeft.Cursor = System.Windows.Forms.Cursors.SizeNESW;
                this.PBBottonCenter.Cursor = System.Windows.Forms.Cursors.SizeNS;
                this.PBBottonRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            }
            this.label1.Text = this.Text;


            if (!this.MaximizeBox & this.MinimizeBox)
                this.PMaximize.Enabled = false;

            if (this.MaximizeBox & !this.MinimizeBox)
                this.PMinimize.Enabled = false;

            if (!this.MaximizeBox & !this.MinimizeBox)
            {
                this.PMaximize.Visible = false;
                this.PMinimize.Visible = false;
            }


            if (this.ShowIcon)
            {
                this.pictureBox1.Image = this.Icon.ToBitmap();
            }
            else
            {
                this.pictureBox1.Width = 0;
                this.pictureBox1.Height = 0;

                Point current_pos = new Point();
                current_pos.X = this.label1.Location.X - 26;
                current_pos.Y = this.label1.Location.Y;

                this.label1.Location = current_pos;
            }
        }

        
        

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Region = System.Drawing.Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width + 1, Height + 10, 9, 9));   
        }
    }



    internal class NativeMethods    
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        internal static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner            
            int nTopRect, // y-coordinate of upper-left corner            
            int nRightRect, // x-coordinate of lower-right corner            
            int nBottomRect, // y-coordinate of lower-right corner            
            int nWidthEllipse, // height of ellipse            
            int nHeightEllipse // width of ellipse             
        );
    }

}
