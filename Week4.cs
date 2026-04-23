using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week4
{
    public partial class Week4 : Form
    {
        Rectangle rect;
        int x = 0;
        int y = 200;
        int dx = 2;
        int dy = 2;
        System.Windows.Forms.Timer animationTimer;

        public Week4()
        {
            InitializeComponent();
            this.Width = 400;
            this.Height = 400;
            this.DoubleBuffered = true;

            rect = new Rectangle(x, y, 50, 50);

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 10; // 10 milliseconds
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {

            x += dx;
            y += dy;

            if (x <= 0 || x + rect.Width >= this.ClientSize.Width) dx *= -1;
            if (y <= 0 || y + rect.Height >= this.ClientSize.Height) dy *= -1;

            rect.Location = new Point(x, y);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            using (Pen blackPen = new Pen(Color.Black))
            using (Brush redBrush = new SolidBrush(Color.Red))
            {
                Font myFont = new Font("Helvetica", 9);
                g.DrawRectangle(blackPen, rect);
                g.DrawString("Moving rectangle", myFont, redBrush, 150, 150);
            }
        }
    }
}
