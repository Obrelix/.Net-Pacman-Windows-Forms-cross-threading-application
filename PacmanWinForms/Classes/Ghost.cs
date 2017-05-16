using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanWinForms
{
    public class Ghost
    {
        public Point Point;
        public Direction Direction;
        private Point[] Perimeter = new Point[12];
        private Point[] Core = new Point[4];

        public Ghost(Point point, Direction direction)
        {
            this.Point = point;
            this.Direction = direction;
        }

        public Point[] perimeter(Point p)
        {
            // Akra

            Perimeter[0] = p;
            Perimeter[1] = new Point(p.X + 1, p.Y);
            Perimeter[2] = new Point(p.X + 2, p.Y);

            Perimeter[3] = new Point(p.X + 3, p.Y);
            Perimeter[4] = new Point(p.X + 3, p.Y + 1);
            Perimeter[5] = new Point(p.X + 3, p.Y + 2);

            Perimeter[6] = new Point(p.X + 3, p.Y + 3);
            Perimeter[7] = new Point(p.X + 2, p.Y + 3);
            Perimeter[8] = new Point(p.X + 1, p.Y + 3);

            Perimeter[9] = new Point(p.X, p.Y + 3);
            Perimeter[10] = new Point(p.X, p.Y + 2);
            Perimeter[11] = new Point(p.X, p.Y + 1);
            return Perimeter;
        }

        public Point[] core(Point p)
        {
            Core[0] = new Point(p.X + 2, p.Y + 2);
            Core[1] = new Point(p.X + 2, p.Y + 3);
            Core[2] = new Point(p.X + 3, p.Y + 3);
            Core[3] = new Point(p.X + 3, p.Y + 2);
            return Core;
        }


    }

    public class GhostRun
    {


        public Point Point = new Point();
        public Direction ghostDirection = Direction.UP;
        Task ghostRunner;
        private int _delay = 70;
        public GhostState gState;
        Ghost ghost;

        public GameState State = GameState.GAMEOVER;

        List<Point> wallList = new List<Point>();
        List<Point> boxDoorList = new List<Point>();
        List<Point> boxList = new List<Point>();

        private Direction[] directions = new Direction[4];

        private frmPacmanGame parentForm;
        private PacmanBoard board;
        private GhostColor color;

        public GhostRun(frmPacmanGame frm, PacmanBoard b, GhostColor color)
        {
            this.color = color;
            parentForm = frm;
            board = b;
            this.Init();
        }

        public int Delay
        {
            get { return _delay; }
            set { _delay = (value < 10) ? 10 : value; }
        }


        public Point[] perimeter()
        {
            return ghost.perimeter(ghost.Point);
        }

        public Point[] core()
        {
            if (gState == GhostState.EATEN) return ghost.core(new Point(0,0));
            else return ghost.core(ghost.Point);
        }


        public void Run()
        {
            State = GameState.GAMERUN;
            ghostRunner = new Task(runghost);
            ghostRunner.Start();
        }

        private void Init()
        {
            boxDoorList = PointLists.boxDoorPointList();
            wallList = PointLists.banPointList();
            boxList = PointLists.boxPointList();
            directionsInit();
            gState = GhostState.NORMAL;
            switch (color)
            {
                case GhostColor.BLUE:
                    ghost = new Ghost(new Point(31, 29), Direction.UP);
                    break;
                case GhostColor.PINK:
                    ghost = new Ghost(new Point(27, 29), Direction.DOWN);
                    break;
                case GhostColor.RED:
                    ghost = new Ghost(new Point(27, 22), Direction.RIGHT);
                    break;
                case GhostColor.YELLOW:
                    ghost = new Ghost(new Point(23, 29), Direction.UP);
                    break;
            }

            State = GameState.GAMEOVER;
        }

        public void reset()
        {
            gState = GhostState.NORMAL;
            switch (color)
            {
                case GhostColor.BLUE:
                    ghost = new Ghost(new Point(31, 29), Direction.UP);
                    break;
                case GhostColor.PINK:
                    ghost = new Ghost(new Point(27, 29), Direction.DOWN);
                    break;
                case GhostColor.RED:
                    ghost = new Ghost(new Point(27, 22), Direction.RIGHT);
                    break;
                case GhostColor.YELLOW:
                    ghost = new Ghost(new Point(23, 29), Direction.UP);
                    break;
            }
            
        }


        private void runghost()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    this.Point = ghost.Point;
                    ghost = ghostMove(ghost.Point, ghost.Direction);

                    switch (color)
                    {
                        case GhostColor.BLUE:
                            parentForm.blueGhostMove(ghost.Point, ghost.Direction);
                            break;
                        case GhostColor.PINK:
                            parentForm.PinkGhostMove(ghost.Point, ghost.Direction);
                            break;
                        case GhostColor.RED:
                            parentForm.redGhostMove(ghost.Point, ghost.Direction);
                            break;
                        case GhostColor.YELLOW:
                            parentForm.YellowGhostMove(ghost.Point, ghost.Direction);
                            break;
                    }
                    if (gState == GhostState.NORMAL)
                    {
                        ghostRunner.Wait(_delay + 5);
                    }
                    else if(gState == GhostState.BONUS)
                    {
                        ghostRunner.Wait(120);
                    }
                    else
                    {
                        ghostRunner.Wait(25);
                    }

                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private Ghost ghostMove(Point StartPoint, Direction d)
        {
            Ghost Ghost = new Ghost(StartPoint, d);

            if (State != GameState.GAMERUN)
            {
                return Ghost;
            }

            int randomInitValue, i;
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                randomInitValue = BitConverter.ToInt32(rno, 0);
            }
            Random rnd = new Random(randomInitValue);

            List<Direction> nextPossibleDir = possibleDirections(StartPoint, d);

            if (nextPossibleDir.Count != 0)
            {
                i = rnd.Next(0, nextPossibleDir.Count);
                d = nextPossibleDir[i];
            }
            Ghost = new Ghost(nextPoint(StartPoint, d), d);

            return Ghost;

        }

        private List<Direction> possibleDirections(Point P, Direction curDir)
        {
            List<Direction> dList = new List<Direction>();
            foreach (Direction d in directions)
            {
                //if (checkForConflict(nextPoint(P, d), P) && d != curDir &&  Math.Abs(d - curDir) != 2) dList.Add(d);
                if (checkForConflict(nextPoint(P, d), P) && Math.Abs(d - curDir) != 2) dList.Add(d);
            }
            return dList;
        }
        

        private bool outOfBox(Point P)
        {
            Ghost Ghost = new Ghost(P, Direction.STOP);

            List<Point> commonPoints = Ghost.perimeter(P).Intersect(boxList.Select(u => u)).ToList();

            return (commonPoints.Count == 0);
        }

        private bool checkForConflict(Point P, Point PrevP)
        {
            Ghost Ghost = new Ghost(P, Direction.STOP);
            List<Point> mergedList = new List<Point>();
            if (outOfBox(PrevP))
            {
                mergedList = boxDoorList.Union(wallList).ToList();
            }
            else
            {
                mergedList = wallList;
            }
            List<Point> commonPoints = Ghost.perimeter(P).Intersect(mergedList.Select(u => u)).ToList();

            return (commonPoints.Count == 0);
        }



        private Point nextPoint(Point P, Direction D)
        {
            Point nextP = new Point();
            nextP = P;
            switch (D)
            {
                case Direction.UP:
                    nextP.Y--;
                    break;
                case Direction.DOWN:
                    nextP.Y++;
                    break;
                case Direction.RIGHT:
                    nextP.X++;
                    break;
                case Direction.LEFT:
                    nextP.X--;
                    break;
                case Direction.STOP:

                    break;
            }
            return nextP;
        }


        private void directionsInit()
        {
            directions[0] = Direction.UP;
            directions[1] = Direction.RIGHT;
            directions[2] = Direction.DOWN;
            directions[3] = Direction.LEFT;
        }

        public void RePaint()
        {
            parentForm.SuspendLayout();
            
            parentForm.ResumeLayout(false);
        }
    }

}
