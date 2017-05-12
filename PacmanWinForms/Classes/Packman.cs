using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanWinForms
{
    public class Pacman
    {
        public Point Point;
        public Direction Direction;
        public Point[] perimeter = new Point[12];
        public Point[] core = new Point[4];
        public Point[] edges = new Point[4];
        public Pacman(Point point, Direction direction)
        {
            this.Point = point;
            this.Direction = direction;
            edgesInit(point);
            posInit(point);
            coreInit(point);
        }

        public void edgesInit(Point p)
        {
            edges[0] = p;
            edges[1] = new Point(p.X + 3, p.Y);
            edges[2] = new Point(p.X + 3, p.Y + 3);
            edges[3] = new Point(p.X, p.Y + 3);
        }

        public void posInit(Point p)
        {
            // Akra

            perimeter[0] = p;
            perimeter[1] = new Point(p.X + 1, p.Y);
            perimeter[2] = new Point(p.X + 2, p.Y);

            perimeter[3] = new Point(p.X + 3, p.Y);
            perimeter[4] = new Point(p.X + 3, p.Y + 1);
            perimeter[5] = new Point(p.X + 3, p.Y + 2);

            perimeter[6] = new Point(p.X + 3, p.Y + 3);
            perimeter[7] = new Point(p.X + 2, p.Y + 3);
            perimeter[8] = new Point(p.X + 1, p.Y + 3);

            perimeter[9] = new Point(p.X, p.Y + 3);
            perimeter[10] = new Point(p.X, p.Y + 2);
            perimeter[11] = new Point(p.X, p.Y + 1);
        }

        public void coreInit(Point p)
        {
            core[0] = new Point(p.X + 2, p.Y + 2);
            core[1] = new Point(p.X + 2, p.Y + 3);
            core[2] = new Point(p.X + 3, p.Y + 3);
            core[3] = new Point(p.X + 3, p.Y + 2);
        }
    }
}
