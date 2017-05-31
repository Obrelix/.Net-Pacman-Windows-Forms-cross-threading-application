using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

public enum FruitState : byte
{
    EATEN = 1,
    NORMAL = 0
}

namespace PacmanWinForms
{
    public class Fruit
    {
        public Point Point;
        public Direction Direction;
        private Point[] Perimeter = new Point[12];
        private Point[] Core = new Point[4];

        public Fruit(Point point, Direction direction)
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

    public class FruitRun
    {


        public Point Point = new Point();
        public Direction fruitDirection { get; set; }
        Task fruitRunner;
        private int _delay = 70;
        Fruit fruit;
        public GameState State = GameState.GAMEOVER;

        List<Point> wallList = new List<Point>();
        List<Point> boxDoorList = new List<Point>();

        private Direction[] directions = new Direction[4];
        private int fruitIndex = 1;
        private int stage = 1;
        private frmPacmanGame parentForm;
        private PacmanBoard board;
        public FruitState fruitState;

        public FruitRun(frmPacmanGame frm, PacmanBoard b, int stage)
        {
            this.stage = stage;
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
            return fruit.perimeter(fruit.Point);
        }

        public Point[] core()
        {
            if(fruitState == FruitState.EATEN) return fruit.core(new Point(-100, -100));
            return fruit.core(fruit.Point);
        }


        public void Run(int fruitIndex, int stage)
        {
            this.stage = stage;
            State = GameState.GAMERUN;
            wallList = PointLists.mapList(stage, '0');
            fruitState = FruitState.NORMAL;
            fruit = (stage == 1) ? new Fruit(new Point(26, 33), Direction.RIGHT) : new Fruit(new Point(26, 33), Direction.LEFT);
            fruitRunner = new Task(runfruit);
            this.fruitIndex = fruitIndex;
            fruitRunner.Start();
        }

        private void Init()
        {
            boxDoorList = PointLists.boxDoorPointList();
            wallList = PointLists.mapList(stage, '0');
            directionsInit();
            fruitState = FruitState.NORMAL;
            fruit = (stage == 1) ? new Fruit(new Point(26, 33), Direction.RIGHT) : new Fruit(new Point(26, 33 ), Direction.LEFT);
            State = GameState.GAMEOVER;
        }

        public void reset(int stage)
        {

            boxDoorList = PointLists.boxDoorPointList();
            wallList = PointLists.mapList(stage, '0');
            fruitState = FruitState.NORMAL;
            fruit = (stage == 1) ? new Fruit(new Point(26, 33), Direction.RIGHT) : new Fruit(new Point(26, 33), Direction.LEFT);
        }

        public void setTarget()
        {

        }
        private void runfruit()
        {
            while (State != GameState.GAMEOVER && fruitState != FruitState.EATEN)
            {
                try
                {

                    this.Point = fruit.Point;
                    fruit = fruitMove(fruit.Point, fruit.Direction);
                    board.DrawFruit(fruit.Point, fruitIndex);
                    fruitRunner.Wait(250);
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

      

        private Fruit fruitMove(Point StartPoint, Direction d)
        {
            Fruit fruit = new Fruit(StartPoint, d);

            if (State != GameState.GAMERUN)
            {
                return fruit;
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
            fruit = new Fruit(nextPoint(StartPoint, d), d);

            return fruit;

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
        

        private bool checkForConflict(Point P, Point PrevP)
        {
            Fruit fruit = new Fruit(P, Direction.STOP);
            List<Point> mergedList = new List<Point>();
                mergedList = boxDoorList.Union(wallList).ToList();
            List<Point> commonPoints = fruit.perimeter(P).Intersect(mergedList.Select(u => u)).ToList();
            return (commonPoints.Count == 0);
        }



        private Point nextPoint(Point P, Direction D)
        {
            Point nextP = new Point();
            if (stage == 2)
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
