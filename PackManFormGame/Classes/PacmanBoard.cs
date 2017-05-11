
using System.Windows.Forms;
using System.Drawing;
using System;

namespace PackManFormGame
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
            lock (this)
            {
               // g.Clear(BgColor);
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

        public void DrawPacMan(int x, int y, Color color, Direction dir)
        {
            Brush b = new SolidBrush(color);
            Rectangle rect = new Rectangle((int)(x * cellWidth + 8), (int)(y * cellHeight + 8), (int)cellWidth * 4 - 16, (int)cellHeight * 4 - 16);
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

        //public void ClearPacMan(int x, int y, Direction dir)
        //{
        //    DrawPacMan(x, y, BgColor, dir);
        //    /*
        //    Brush b = new SolidBrush(BgColor);
        //    lock (this)
        //    {
        //        g.FillRectangle(b, x * cellWidth, y * cellHeight, cellWidth, cellHeight);
        //    }
        //     * */

        //}
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
