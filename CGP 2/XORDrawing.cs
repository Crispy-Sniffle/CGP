using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGP_2
{
        public partial class XORDrawing : Form
        {
            Rectangle aRect;
            Rectangle anEllipse;
            Rectangle moving;
            int x = 0, y = 0;
            Graphics g;

            public XORDrawing()
            {
                InitializeComponent();
                // set up the rectangle objects using client (form) coordinates
                aRect = new Rectangle(100, 100, 200, 200);
                anEllipse = new Rectangle(150, 150, 200, 100);
                moving = new Rectangle(x, y, 10, 10);

                // size and position the frame
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
                // Create a red brush
                Brush redBrush = new SolidBrush(Color.Red);
                // Fill rectangle 
                g.FillRectangle(redBrush, aRect);
                // Create a green brush
                Brush greenBrush = new SolidBrush(Color.Green);
                // Fill ellipse 
                g.FillEllipse(greenBrush, anEllipse);
            Rectangle moving = new Rectangle(0, 0, 30, 30);

            // Initialize coordinates
            int x = 0;
            int y = 0;

            // a) Define a while loop
            while (x < 500)
            {
                // b) Redefine the current location using PointToScreen
                // We must convert form coordinates (relative to window) to Screen coordinates (monitor pixels)
                // because FillReversibleRectangle draws directly on the desktop screen.
                moving.Location = this.PointToScreen(new Point(x, y));

                // c) Draw the square (First XOR draws the shape)
                ControlPaint.FillReversibleRectangle(moving, Color.Red);

                // d) Pause so the motion is visible
                System.Threading.Thread.Sleep(10);

                // e) Repeat the call (Second XOR erases the shape)
                ControlPaint.FillReversibleRectangle(moving, Color.Red);

                // f) Increment x and y
                x += 2; // Adjust this number to change speed
                y += 2;
            }

        }
    }
}
