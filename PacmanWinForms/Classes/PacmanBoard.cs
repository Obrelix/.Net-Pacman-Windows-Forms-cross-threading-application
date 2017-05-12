
using System.Windows.Forms;
using System.Drawing;
using System;

namespace PacmanWinForms
{
    public class PacmanBoard
    {
        public int Rows;
        public int Cols;
        public Color BgColor;

        private Panel pnl;
        private Graphics g;
        private float cellHeight;
        private float cellWidth;
        private static int state = 1;
        PictureBox[] picsGhosts = new PictureBox[4];

        public PacmanBoard(Panel pnl, int rows = 64, int cols = 58, Color? bgColor = null)
        {
            // Color? <=> nullable <Color>
            this.Rows = rows;
            this.Cols = cols;
            this.BgColor = bgColor ?? Color.Black;
            this.pnl = pnl;
            //Resize();
        }

        public void Resize()
        {
            cellHeight = pnl.Height / (float)Rows;
            cellWidth = pnl.Width / (float)Cols;
            g = pnl.CreateGraphics();
            picGostsInit();
            lock (this)
            {
                pnl.Controls.Remove(picsGhosts[0]);
                //g.Clear(BgColor);
                //picsGhosts[0].Location = new Point((int)(28 * cellWidth + 6), (int)(34 * cellHeight + 6));
                //picsGhosts[0].Size = new Size((int)(cellWidth * 4 - 12), (int)(cellHeight * 4 - 12));
                pnl.Controls.Add(picsGhosts[0]);
            }

        }

        public void Clear()
        {
            lock (this)
            {
                g.Clear(BgColor);
            }
        }

        

        public void DrawRect(Point p, Color col)
        {
            Brush b = new SolidBrush(col);
            lock (this)
            {
                g.FillRectangle(b, p.X * cellWidth, p.Y * cellHeight , cellWidth, cellHeight);
            }
        }

        public void DrawDot(Point p, Color col)
        {
            float dotWidth = 2 * cellWidth / 5;
            float dotHeight = 2 * cellHeight / 5;
            Brush b = new SolidBrush(col);
            lock (this)
            {
                g.FillRectangle(b, p.X * cellWidth - dotWidth/2, p.Y * cellHeight - dotHeight/2, dotWidth, dotHeight);
            }
        }

        private void picGostsInit()
        {
            pnl.SuspendLayout();
            picsGhosts[0] = new PictureBox();
            picsGhosts[1] = new PictureBox();
            picsGhosts[2] = new PictureBox();
            picsGhosts[3] = new PictureBox();
            //((System.ComponentModel.ISupportInitialize)(this.picsGhosts[0])).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.picsGhosts[1])).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.picsGhosts[2])).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.picsGhosts[3])).BeginInit();

            picsGhosts[0].BackgroundImage = Properties.Resources.RedGhost;
            picsGhosts[0].BackgroundImageLayout = ImageLayout.Stretch;
            //picsGhosts[0].Location = new Point((int)(28 * cellWidth + 6), (int)(34 * cellHeight + 6));
            picsGhosts[0].Name = "picRedG";
            picsGhosts[0].Size = new Size((int)(cellWidth * 4 - 12), (int)(cellHeight * 4 - 12));

            picsGhosts[1].BackgroundImage = Properties.Resources.BlueGhost;
            picsGhosts[1].BackgroundImageLayout = ImageLayout.Stretch;
            picsGhosts[1].Location = new Point(0, 0);
            picsGhosts[1].Name = "picBlueG";
            picsGhosts[1].Size = new Size((int)(cellWidth * 4 - 12), (int)(cellHeight * 4 - 12));

            picsGhosts[2].BackgroundImage = Properties.Resources.YellowGhost;
            picsGhosts[2].BackgroundImageLayout = ImageLayout.Stretch;
            picsGhosts[2].Location = new Point(0, 0);
            picsGhosts[2].Name = "picYellowG";
            picsGhosts[2].Size = new Size((int)(cellWidth * 4 - 12), (int)(cellHeight * 4 - 12));

            picsGhosts[3].BackgroundImage = Properties.Resources.PinkGhost;
            picsGhosts[3].BackgroundImageLayout = ImageLayout.Stretch;
            picsGhosts[3].Location = new Point(0, 0);
            picsGhosts[3].Name = "picPinkG";
            picsGhosts[3].Size = new Size((int)(cellWidth * 4 - 12), (int)(cellHeight * 4 - 12));

            
            lock (this)
            {
                pnl.Controls.Add(picsGhosts[0]);
                //pnl.Controls.Add(picsGhosts[1]);
                //pnl.Controls.Add(picsGhosts[2]);
                //pnl.Controls.Add(picsGhosts[3]);
            }
            pnl.ResumeLayout(false);
        }

        public void DrawGhost(int x, int y, string color, Direction dir)
        {

        }

        public void DrawPacMan(int x, int y, Color color, Direction dir)
        {
            Brush b = new SolidBrush(color);
            Rectangle rect = new Rectangle((int)(x * cellWidth + 4), (int)(y * cellHeight + 4), (int)(cellWidth * 4 - 8), (int)(cellHeight * 4 - 8));
            int startAngle, sweepAngle;
            calculateAngles(dir, out startAngle, out sweepAngle);
            lock (this)
            {
                g.FillPie(b, rect, startAngle, sweepAngle);

            }
        }

        private void calculateAngles(Direction dir, out int startAngle, out int sweepAngle)
        {
            int stAngle, swAngle ;
            if(state == 1)
            {
                stAngle = 0; swAngle = 380;
                state++;
            }
            else if(state == 2)
            {
                stAngle = 25; swAngle = 310;
                state++;
            }
            else if (state == 3)
            {
                stAngle = 58; swAngle = 240;
                state++;
            }
            else 
            {
                stAngle = 25; swAngle = 310;
                state = 1;
            }



            startAngle = stAngle; sweepAngle = swAngle;
            switch (dir)
            {
                case Direction.RIGHT:
                    
                    break;
                case Direction.LEFT:
                    startAngle += 180;
                    break;
                case Direction.UP:
                    startAngle -= 90;
                    break;
                case Direction.DOWN:
                    startAngle += 90;
                    break;
                case Direction.STOP:
                    startAngle = 0; sweepAngle = 380;
                    break;
            }

        }

        public void DrawPacMan(Point p, Color color, Direction dir)
        {
            DrawPacMan(p.X, p.Y, color, dir);
        }
        
        public void ClearPacMan(Point p)
        {
            
            Brush b = new SolidBrush(BgColor);
            lock (this)
            {
                g.FillEllipse(b, p.X * cellWidth, p.Y * cellHeight, cellWidth * 4, cellHeight * 4);
            }
        }
    }
}
