using PacmanWinForms;
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
        public Direction ghostDirection { get; set; }
        Task ghostRunner;
        public GhostState gState { get; set; }
        public bool eatenFlag { get; set; }

        public GameState State = GameState.GAMEOVER;
        public int algorithm = 0;

        private List<Point> scaleList = new List<Point>();
        private List<Point> wallList = new List<Point>();
        private List<Point> boxDoorList = new List<Point>();
        private List<Point> boxList = new List<Point>();
        private List<Point> bonusList = new List<Point>();

        private int stage = 1;
        private int _delay = 70;
        private Ghost ghost;
        private Point target;
        private Direction[] directions = new Direction[4];
        private bool AIFlag = false;
        private frmPacmanGame parentForm;
        private PacmanBoard board;
        private GhostColor color;
        private bool fear = false;
        private bool sprite1 = true;

        private Map map;
        private AStar aStar;
        private BestFirst bestFirst;
        private BreadthFirst breadthFirst;



        public GhostRun(frmPacmanGame frm, PacmanBoard b, GhostColor color, int algorithm, int stage)
        {
            this.color = color;
            parentForm = frm;
            board = b;
            this.algorithm = algorithm;
            this.stage = stage;
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
            Ghost g = new Ghost(new Point(-10, -10), Direction.STOP);
            if (gState == GhostState.EATEN) return g.core(g.Point);
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
            boxList = PointLists.boxPointList();
            wallList = PointLists.mapList(stage, '0');
            scaleList = MazeList.WallList(stage);
            directionsInit();
            gState = GhostState.NORMAL;
            target = new Point();
            switch (color)
            {
                case GhostColor.BLUE:
                    ghost = new Ghost(new Point(30, 28), Direction.UP);
                    break;
                case GhostColor.PINK:
                    ghost = new Ghost(new Point(26, 28), Direction.DOWN);
                    break;
                case GhostColor.RED:
                    ghost = new Ghost(new Point(26, 21), Direction.RIGHT);
                    break;
                case GhostColor.YELLOW:
                    ghost = new Ghost(new Point(22, 28), Direction.UP);
                    break;
            }
            map = new Map(scaleList);
            aStar = new AStar(map);
            bestFirst = new BestFirst(map);
            breadthFirst = new BreadthFirst(map);
            State = GameState.GAMEOVER;
        }

        public void reset(int stage)
        {
            wallList = PointLists.mapList(stage, '0');
            scaleList = MazeList.WallList(stage);
            gState = GhostState.NORMAL;
            map = new Map(scaleList);
            aStar = new AStar(map);
            bestFirst = new BestFirst(map);
            breadthFirst = new BreadthFirst(map);
            switch (color)
            {
                case GhostColor.BLUE:
                    ghost = new Ghost(new Point(30, 28), Direction.UP);
                    break;
                case GhostColor.PINK:
                    ghost = new Ghost(new Point(26, 28), Direction.DOWN);
                    break;
                case GhostColor.RED:
                    ghost = new Ghost(new Point(26, 21), Direction.RIGHT);
                    break;
                case GhostColor.YELLOW:
                    ghost = new Ghost(new Point(22, 28), Direction.UP);
                    break;
            }
            
        }


        public Point scalePoint(Point P)
        {
            return new Point((int)(P.X * PacmanBoard.cellWidth / PacmanBoard.modelCellWidth) + 1,
                (int)(P.Y * PacmanBoard.cellHeight / PacmanBoard.modelCellHeight) + 1);
        }


        private void runghost()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    this.Point = ghost.Point;
                    ghost = ghostMove(ghost.Point, ghost.Direction);
                    board.GhostMove(ghost.Point, ghost.Direction, color, sprite1, gState);
                   // Debug.WriteLine(scalePoint(ghost.Point));
                    sprite1 = !sprite1;

                    changeWait();
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void changeWait()
        {
            if (gState == GhostState.NORMAL && !AIFlag)
            {
                ghostRunner.Wait(_delay);
            }
            else if (gState == GhostState.BONUS || gState == GhostState.BONUSEND)
            {
                ghostRunner.Wait(_delay + 40);
            }
            else if (AIFlag && gState != GhostState.EATEN)
            {
                ghostRunner.Wait(_delay + 10);
            }
            else
            {
                ghostRunner.Wait(40);
            }
        }

        private Ghost ghostMove(Point StartPoint, Direction d)
        {
            Ghost Ghost = new Ghost(StartPoint, d);

            if (State != GameState.GAMERUN)
            {
                return Ghost;
            }
            
            List<Direction> nextPossibleDir = possibleDirections(StartPoint, d);

            if (nextPossibleDir.Count != 0)
            {
                d = nextPossibleDir[getRandomNumber(0, nextPossibleDir.Count)];
            }
            Ghost = new Ghost(nextPoint(StartPoint, d), d);

            return Ghost;

        }


        private List<Direction> possibleDirections(Point P, Direction curDir)
        {
            List<Direction> dList = new List<Direction>();

            if (AIFlag)
            {
                Point scaleP, scaleTargetPoint, tempPoint;
                    tempPoint = ghost.Point;
                    if (tempPoint.X < 1 && tempPoint.Y == 27) tempPoint = new Point(1, 27);
                    if (tempPoint.X > 52 && tempPoint.Y == 27) tempPoint = new Point(52, 27);
                    scaleP = scalePoint(tempPoint);
                    tempPoint = target;
                    if (target.X < 1 && target.Y == 27) tempPoint = new Point(1, 27);
                    if (target.X > 52 && target.Y == 27) tempPoint = new Point(52, 27);
                    scaleTargetPoint = scalePoint(tempPoint);

                if (scaleP != scaleTargetPoint)
                {
                    Direction aiDirection;
                    switch (algorithm)
                    {
                        case 0:
                            aiDirection = aStar.Run(map.map[scaleP.X, scaleP.Y],
                                                        map.map[scaleTargetPoint.X, scaleTargetPoint.Y], 
                                                        curDir);
                            map.Reset();
                            break;
                        case 1:
                            aiDirection = bestFirst.Run(map.map[scaleP.X, scaleP.Y],
                                                     map.map[scaleTargetPoint.X, scaleTargetPoint.Y],
                                                     curDir);
                            map.Reset();
                            break;
                        case 2:
                            aiDirection = breadthFirst.Run(map.map[scaleP.X, scaleP.Y],
                                                     map.map[scaleTargetPoint.X, scaleTargetPoint.Y],
                                                     curDir);
                            map.Reset();
                            break;
                        default:
                            aiDirection = aStar.Run(map.map[scaleP.X, scaleP.Y],
                                                     map.map[scaleTargetPoint.X, scaleTargetPoint.Y],
                                                     curDir);
                            map.Reset();
                            break;
                    }
                    
                    if (checkForConflict(nextPoint(P, aiDirection), P))
                    {
                        dList.Add(aiDirection);
                        return dList;
                    }
                }
                
            }
            dList.Clear();
            foreach (Direction d in directions)
            {
                //if (checkForConflict(nextPoint(P, d), P) && d != curDir &&  Math.Abs(d - curDir) != 2) dList.Add(d);
                bool conflictCheck = checkForConflict(nextPoint(P, d), P);
                if (conflictCheck && Math.Abs(d - curDir) != 2 && !fear) dList.Add(d);
                else if (conflictCheck && fear) //&& !tempList.Any(dirs => dirs == d))
                {
                    if(!avoidDirections(P, target).Any(dirs => dirs == d)) dList.Add(d);

                }

            }
            if(dList.Count == 0)
            {
                foreach(Direction d in directions)
                {
                    bool conflictCheck = checkForConflict(nextPoint(P, d), P);
                    if (conflictCheck) dList.Add(d);
                }
            }
            return dList;
        }

        private List<Direction> avoidDirections(Point root, Point target)
        {
            List<Direction> d = new List<Direction>();
            if (root.X - target.X > 0) d.Add(Direction.LEFT);
            else if (root.X - target.X < 0) d.Add(Direction.RIGHT);
            if (root.Y - target.Y > 0) d.Add(Direction.UP);
            else if (root.Y - target.Y < 0) d.Add(Direction.DOWN);
            return d;
        }

        public void setTarget(PacmanRun pacman, Point blinkyPoint, bool ready, bool originalAI)
        {
            bool outOfB = outOfBox(ghost.Point);

            switch (gState)
            {
                case GhostState.NORMAL:
                    if (originalAI && ready)
                        switch (color)
                        {
                            case GhostColor.PINK:
                                algorithm = (stage == 1) ? 2 : 0;
                                pinkAI(pacman.Point, blinkyPoint, ready, outOfB);
                                break;
                            case GhostColor.RED:
                                algorithm =(stage == 1)? 0: 2;
                                redAI(pacman.Point, ready, outOfB);
                                break;
                            case GhostColor.YELLOW:
                                algorithm = (stage == 1) ? 2 : 0;
                                yellowAI(pacman.Point, ready, outOfB);
                                break;
                            case GhostColor.BLUE:
                                algorithm = (stage == 1) ? 0: 2;
                                blueAI(pacman.Point, blinkyPoint, ready, outOfB);
                                break;
                        }
                    else redAI(pacman.Point, ready, outOfB);
                    break;
                case GhostState.EATEN: enableEaten(); break;
                case GhostState.BONUS:
                case GhostState.BONUSEND: enableFear(pacman.Point); break;

            }
        }

        private void redAI(Point pacmanPoint, bool ready, bool outOfBox)
        {
            if (!isNear(ghost.Point, pacmanPoint, 6))
            {
                target = pacmanPoint;
                fear = false;
                AIFlag = (ready && outOfBox);
            }
                
        }

        private void pinkAI(Point pacmanPoint, Point blinkyPoint, bool ready, bool outOfBox)
        {

            if ( !isNear(ghost.Point, pacmanPoint, 12) || (!isNear(blinkyPoint, pacmanPoint, 12) && !isNear(ghost.Point, pacmanPoint, 6)))
            {
                target = pacmanPoint;
                fear = false;
                AIFlag = (ready && outOfBox);
            }
            else
            {
                AIFlag = false;
                fear = false;
            }
        }

        private void yellowAI(Point pacmanPoint, bool ready, bool outOfBox)
        {
            if (!isNear(ghost.Point,pacmanPoint, 20))
            {
                target = pacmanPoint;
                fear = false;
                AIFlag = (ready && outOfBox);
            }
            else
            {
                //fear = true;
                AIFlag = false;
                target = pacmanPoint;
            }
                    
        }

        private void blueAI(Point pacmanPoint, Point blinkyPoint, bool ready, bool outOfBox)
        {
            if ( isNear(ghost.Point, blinkyPoint, 15) && !isNear(ghost.Point, pacmanPoint, 6) )
            {
                target = pacmanPoint;
                fear = false;
                AIFlag = (ready && outOfBox);
            }
            else
            {
                AIFlag = false;
                fear = false;
            }
        }

        private void enableFear(Point pacmanPoint)
        {
            fear = isNear(ghost.Point, pacmanPoint, 8);
            target = pacmanPoint;
            AIFlag = false;
        }

        private void enableEaten()
        {
            target = new Point(26, 27);
            AIFlag = true;
            fear = false;
        }

        private bool isNear(Point root, Point target, int distance)
        {
            return (Math.Abs(root.X - target.X) < distance) && (Math.Abs(root.Y - target.Y) < distance);
        }

        private int getRandomNumber(int start, int end)
        {
            int randomInitValue;
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                randomInitValue = BitConverter.ToInt32(rno, 0);
            }
            Random rnd = new Random(randomInitValue);
            return rnd.Next(start, end);
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
            if (outOfBox(PrevP) && gState != GhostState.EATEN)
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
            if(stage == 2)
            {
                Point leftTunel = new Point(-1, 27);
                Point rightTunel = new Point(56, 27);

                if (P == leftTunel && D != Direction.RIGHT) return rightTunel;
                if (P == rightTunel && D != Direction.LEFT) return leftTunel;
            }
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
