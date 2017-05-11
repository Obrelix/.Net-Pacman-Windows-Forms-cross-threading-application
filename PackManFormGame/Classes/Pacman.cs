using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PackManFormGame
{
    public enum GameState : byte
    {
        GAMEOVER = 0,
        GAMEPAUSE = 1,
        GAMERUN = 2
    }

    public enum Direction : byte
    {
        UP = 0,
        LEFT = 1,
        DOWN = 2,
        RIGHT = 3,
        STOP = 4
    }

    internal class PacmanSegnement
    {
        public Point Point;
        public Direction Direction;
        public PacmanSegnement(Point point, Direction direction)
        {
            this.Point = point;
            this.Direction = direction;
        }
    }

    public class PacmanGame
    {
        public Direction Direction = Direction.STOP;

        public int Delay
        {
            get { return _delay; }
            set { _delay = (value < 10) ? 0 : value; }
        }
        public GameState State = GameState.GAMEOVER;
        public Color ColorBody = Color.Black;
        public Color ColorHead = Color.Yellow;
        public Task Runner;

        private Direction PreviusDir = Direction.STOP;

        private int _delay = 60;
        private int score = 0;
        private Point bonus;
        
        private Point nextPoint = new Point();
        private frmPacmanGame parentForm;
        private PacmanBoard board;
        private PacmanSegnement Pacman;

        private Point[] posArray = new Point[8];
        private Point[] pacmanCoreArray = new Point[4];
        List<Point> banList = new List<Point>();
        List<Point> dotList = new List<Point>();


        public PacmanGame(frmPacmanGame frm, Panel p)
        {
            parentForm = frm;
            board = new PacmanBoard(p);
            this.Init();
        }

        private void Init()
        {
            banList = PointLists.banPointList();
            dotList = PointLists.dotPointList();
            State = GameState.GAMEOVER;

            Direction = Direction.STOP;
            Pacman = new PacmanSegnement(new Point(27, 40), Direction);

            nextPoint = Pacman.Point;
            //
            score = 0;
            Delay = 80;
        }

        private void posArrayInit(Point p)
        {
            posArray[0] = p;
            posArray[1] = new Point(p.X + 1, p.Y);
            posArray[2] = new Point(p.X + 3, p.Y);
            posArray[3] = new Point(p.X + 3, p.Y + 1);
            posArray[4] = new Point(p.X + 3, p.Y + 3);
            posArray[5] = new Point(p.X + 2, p.Y + 3);
            posArray[6] = new Point(p.X, p.Y + 3);
            posArray[7] = new Point(p.X, p.Y + 2);
        }
        private void coreArrayInit(Point p)
        {
            pacmanCoreArray[0] = new Point(p.X + 2, p.Y + 2);
            pacmanCoreArray[1] = new Point(p.X + 2, p.Y + 3);
            pacmanCoreArray[2] = new Point(p.X + 3, p.Y + 3);
            pacmanCoreArray[3] = new Point(p.X + 3, p.Y + 2);
        }

        public void Stop()
        {
            State = GameState.GAMEOVER;
        }

        public void Pause()
        {
            if (State == GameState.GAMERUN) State = GameState.GAMEPAUSE;
        }

        public void Continue()
        {
            if (State == GameState.GAMEPAUSE) State = GameState.GAMERUN;
        }

        public void Run()
        {
            Runner = new Task(runGame);
            State = GameState.GAMERUN;
            RePaint();
            Runner.Start();
        }

        private void runGame()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    move();
                    string data = Pacman.Point.ToString() + "@" + score + "%"+ Delay;
                    parentForm.Write(data);
                    Runner.Wait(_delay);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void move()
        {
            if (State != GameState.GAMERUN)
            {
                return;
            }

            nextPoint = Pacman.Point;
            switch (Direction)
            {
                case Direction.UP:
                    nextPoint.Y--;
                    break;
                case Direction.DOWN:
                    nextPoint.Y++;
                    break;
                case Direction.RIGHT:
                    nextPoint.X++;
                    break;
                case Direction.LEFT:
                    nextPoint.X--;
                    break;
                case Direction.STOP:
                   // board.DrawPacMan(Pacman.Point, Color.Yellow, Direction);
                    break;
            }
            checkNextPos(nextPoint);
            checkDots(Pacman.Point);
            foreach (Point p in dotList)
            {
                board.DrawDot(p, Color.White);
            }
            foreach (Point p in banList)
            {
                board.DrawRect(p, Color.DarkBlue);
            }

            if(dotList.Count == 0)
            {
                State = GameState.GAMEOVER; 
            }

            //foreach (Point p in posArray)
            //{
            //    board.DrawDot(p, Color.Aqua);
            //}


        }

        private void checkDots(Point P)
        {
            coreArrayInit(P);
            for(int i = 0; i <= dotList.Count - 1; i++)
            {
                foreach (Point corePoint in pacmanCoreArray)
                {
                    if (corePoint.X == dotList[i].X && corePoint.Y == dotList[i].Y)
                    {
                        dotList.RemoveAt(i);
                        score += 10;
                        break;
                    }
                }
            }

        }
        private void checkNextPos(Point P)
        {

            posArrayInit(P);
            if (checkPosition())
            {
                Point tempPoint = Pacman.Point;
                board.ClearPacMan(tempPoint);
                Pacman = new PacmanSegnement(P, Direction);
                board.DrawPacMan(Pacman.Point, Color.Yellow, Direction);
                PreviusDir = Direction;
            }
            else
            {
                Direction = PreviusDir;
            }
        }
       
        private bool checkPosition()
        {
            foreach (Point banPoint in banList)
            {
                foreach(Point pacmanPoint in posArray)
                {
                    if(pacmanPoint == banPoint)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        

        public void RePaint()
        {
            parentForm.SuspendLayout();
            board.Resize();
            board.DrawPacMan(Pacman.Point, ColorHead, Direction);
            parentForm.ResumeLayout(false);
        }

        
    }
}
