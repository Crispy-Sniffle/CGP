using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week5
{
    public partial class Week5 : Form
    {
        private Point[] pointsTable = new Point[]
        {
            new Point(50, 50),     // Point 0: Top-Left
            new Point(250, 50),    // Point 1: Top-Middle
            new Point(450, 50),    // Point 2: Top-Right
            
            new Point(250, 100),   // Point 3: Top-Right Box (Bottom-Left corner)
            new Point(450, 100),   // Point 4: Top-Right Box (Bottom-Right corner)
            
            new Point(50, 150),    // Point 5: Middle-Left
            new Point(250, 150),   // Point 6: Middle-Center
            new Point(450, 150),   // Point 7: Middle-Right
            
            new Point(50, 250),    // Point 8: Bottom-Left
            new Point(450, 250)    // Point 9: Bottom-Right
        };

        
        private int[,] lineTable = new int[,]
        {
            { 0, 2 }, // Top continuous edge
            { 0, 8 }, // Left continuous edge
            { 8, 9 }, // Bottom continuous edge
            { 5, 7 }, // Middle horizontal divider
            { 1, 6 }, // Middle vertical divider
            { 3, 4 }, // Bottom edge of the small top-right box
            { 2, 4 }, // Right edge of the small top-right box
            { 7, 9 }  // Right edge of the large bottom box
        };

        public Week5()
        {
            InitializeComponent();
            this.Size = new Size(550, 350);
            this.Text = "Connect the Dots!";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            using (Pen myPen = new Pen(Color.Black, 2))
            {
                // One time loop for this Table
                for (int i = 0; i < lineTable.GetLength(0); i++)
                {
                    int startIndex = lineTable[i, 0];
                    int endIndex = lineTable[i, 1];

                    // One single DrawLine statement drawing from Point A to Point B
                    g.DrawLine(myPen, pointsTable[startIndex], pointsTable[endIndex]);
                }
            }
        }
    }
}
