using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week2
{
    public partial class Week2 : Form
    {
        public Week2()
        {
            InitializeComponent();
            this.Size = new Size(600, 600);
            this.Text = "Recursive Midpoint Triangles";
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Using PointF (Float) instead of Point (Integer) for precision
            PointF p1 = new PointF(100, 100);
            PointF p2 = new PointF(500, 100);
            PointF p3 = new PointF(300, 446);

            using (Pen blackPen = new Pen(Color.Black))
            {
                DrawTriangleRecursive(g, blackPen, p1, p2, p3);
            }
        }

        // This is the recursive method
        private void DrawTriangleRecursive(Graphics g, Pen p, PointF a, PointF b, PointF c)
        {
            g.DrawLine(p, a, b);
            g.DrawLine(p, b, c);
            g.DrawLine(p, c, a);
            float sideLength = (float)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

            if (sideLength < 30.0f)
            {
                return; // Stops the recursion
            }
            PointF m1 = GetMidPoint(a, b); // Midpoint of top side
            PointF m2 = GetMidPoint(b, c); // Midpoint of right side
            PointF m3 = GetMidPoint(c, a); // Midpoint of left side

            DrawTriangleRecursive(g, p, m1, m2, m3);
        }
        private PointF GetMidPoint(PointF p1, PointF p2)
        {
            return new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }
    }
}
