using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week3
{
    public partial class Week3 : Form
    {
        Rectangle aRect;
        Rectangle anEllipse;
        Rectangle moving;
        int x = 0, y = 0;
        Graphics g;
        public Week3()
        {
            InitializeComponent();
            aRect = new Rectangle(100, 100, 200, 200);
            anEllipse = new Rectangle(150, 150, 200, 100);
            moving = new Rectangle(x, y, 10, 10);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 500;
            this.Height = 500;
            this.BackColor = Color.White;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            g = e.Graphics;
            // Creates a red brush
            Brush redBrush = new SolidBrush(Color.Red);
            // Fill rectangle
            g.FillRectangle(redBrush, aRect);
            // Creates a green brush
            Brush greenBrush = new SolidBrush(Color.Green);
            // Fill the ellipse
            g.FillEllipse(greenBrush, anEllipse);

            Rectangle moving = new Rectangle(0, 0, 30, 30);

            int x = 0;
            int y = 0;
            while (x < 500)
            {
                moving.Location = this.PointToScreen(new Point(x, y));
                ControlPaint.FillReversibleRectangle(moving, Color.Red);
                System.Threading.Thread.Sleep(10);
                ControlPaint.FillReversibleRectangle(moving, Color.Red);

                x += 2; // Adjust this number to change speed
                y += 2;
            }
        }
    }
}
