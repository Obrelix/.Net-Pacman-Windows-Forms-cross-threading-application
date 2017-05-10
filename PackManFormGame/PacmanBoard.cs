
using System.Windows.Forms;
using System.Drawing;

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
                g.Clear(BgColor);
            }
        }

        public void Clear()
        {
            lock (this)
            {
                g.Clear(BgColor);
            }
        }

        public void DrawXY(int x, int y, Color color)
        {
            Brush b = new SolidBrush(color);
            lock (this)
            {
                g.FillEllipse(b, x * cellWidth + 3, y * cellHeight + 3, cellWidth * 4 - 6, cellHeight * 4 - 6);
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

        public void DrawXY(Point p, Color color)
        {
            DrawXY(p.X, p.Y, color);
        }

        public void ClearXY(int x, int y)
        {
            DrawXY(x, y, BgColor);
            /*
            Brush b = new SolidBrush(BgColor);
            lock (this)
            {
                g.FillRectangle(b, x * cellWidth, y * cellHeight, cellWidth, cellHeight);
            }
             * */

        }
        public void ClearXY(Point p)
        {
            DrawXY(p.X, p.Y, BgColor);
        }
    }
}
