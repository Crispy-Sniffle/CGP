using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week7
{
    public class Tmatrix
    {
        public static PointF[] matrixRotate(float angleDegrees, PointF[] points)
        {
            PointF[] rotatedPoints = new PointF[points.Length];

            double radians = angleDegrees * Math.PI / 180.0;
            float cosTheta = (float)Math.Cos(radians);
            float sinTheta = (float)Math.Sin(radians);

            // Applying the 2D rotation matrix to every point
            for (int i = 0; i < points.Length; i++)
            {
                float x = points[i].X;
                float y = points[i].Y;

                rotatedPoints[i] = new PointF(
                    (x * cosTheta) - (y * sinTheta),
                    (x * sinTheta) + (y * cosTheta)
                );
            }

            return rotatedPoints;
        }
    }
    public partial class Week7 : Form
    {
        public Week7()
        {
            this.Text = "Custom Tmatrix Rotation";
            this.Size = new Size(500, 500);
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
 
            PointF[] originalSquare = {
                new PointF(100, 50),  // Top-Left
                new PointF(200, 50),  // Top-Right
                new PointF(200, 150), // Bottom-Right
                new PointF(100, 150)  // Bottom-Left
            };

            using (Pen bluePen = new Pen(Color.Blue, 2))
            {
                g.DrawPolygon(bluePen, originalSquare);
                g.DrawString("Original", new Font("Arial", 10), Brushes.Blue, 100, 30);
            }

            PointF[] rotatedSquare = Tmatrix.matrixRotate(45, originalSquare);

            using (Pen redPen = new Pen(Color.Red, 2))
            {
                g.DrawPolygon(redPen, rotatedSquare);
                g.DrawString("Rotated 45°", new Font("Arial", 10), Brushes.Red, rotatedSquare[0].X, rotatedSquare[0].Y - 20);
            }
        }
    }
}
