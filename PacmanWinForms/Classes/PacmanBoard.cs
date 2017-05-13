
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
        private Control.ControlCollection c;
        private float cellHeight;
        private float cellWidth;
        private static int state = 1;
        //PictureBox[] picsGhosts = new PictureBox[4];
        PictureBox redGhost;

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
            c = pnl.Controls;

            lock (this)
            {
                //g.Clear(BgColor);
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

        public void DrawDoor(Point p, Color col)
        {
            Brush b = new SolidBrush(col);
            lock (this)
            {
                g.FillRectangle(b, p.X * cellWidth, p.Y * cellHeight + cellHeight/4, cellWidth, cellHeight/2);
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
        public void DrawBonus(Point p, Color col)
        {
            float dotWidth =  cellWidth + cellWidth/2;
            float dotHeight =  cellHeight + cellHeight/2;
            Brush b = new SolidBrush(col);
            lock (this)
            {
                g.FillRectangle(b, p.X * cellWidth - dotWidth / 2, p.Y * cellHeight - dotHeight / 2, dotWidth, dotHeight);
            }
        }



        public void DrawGhost(int x, int y, Direction dir, string color = "red")
        {

            redGhost = new PictureBox();
            redGhost.BackgroundImage = Properties.Resources.RedGhost;
            redGhost.BackgroundImageLayout = ImageLayout.Stretch;
            redGhost.Name = "picRedG";
            redGhost.Size = new Size((int)(cellWidth * 4 - 4), (int)(cellHeight * 4 - 4));
            redGhost.Location = new Point((int)(x * cellWidth + 2) , (int)(y * cellHeight + 2));
            try
            {
                lock (this)
                {
                    c.Add(redGhost);
                }
            }
            catch { }
            
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

        public void DrawGhost(Point P, Direction dir, string color = "red")
        {
            DrawGhost(P.X, P.Y, dir, color);
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

        public void ClearRedGhost()
        {
            lock (this)
            {
                c.Remove(redGhost);
            }
        }
    }
}
