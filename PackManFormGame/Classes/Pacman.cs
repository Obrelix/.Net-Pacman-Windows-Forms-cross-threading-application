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

    internal class Pacman
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

    public class PacmanGame
    {
        public Direction pacmanDir = Direction.STOP;
        public Direction ghostDir = Direction.STOP;

        public int Delay
        {
            get { return _delay; }
            set { _delay = (value < 10) ? 0 : value; }
        }
        public GameState State = GameState.GAMEOVER;
        public Color ColorBody = Color.Black;
        public Color ColorHead = Color.Yellow;
        public Task PacmanRunner;
        public Task GhostRunner;


        private int _delay = 70;
        private int score = 0;
        private Point bonus;
        
        private frmPacmanGame parentForm;
        private PacmanBoard board;
        private Pacman Pacman;
        private Pacman RedGhost;

        List<Point> wallList = new List<Point>();
        List<Point> dotList = new List<Point>();


        public PacmanGame(frmPacmanGame frm, Panel p)
        {
            parentForm = frm;
            board = new PacmanBoard(p);
            this.Init();
        }

        private void Init()
        {
            wallList = PointLists.banPointList();
            dotList = PointLists.dotPointList();

            State = GameState.GAMEOVER;
            pacmanDir = Direction.STOP;
            Pacman = new Pacman(new Point(27, 40), pacmanDir);

            ghostDir = Direction.RIGHT;
            RedGhost = new Pacman(new Point(27, 30), ghostDir);

            score = 0;
            Delay = 70;

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
            PacmanRunner = new Task(runGame);
            State = GameState.GAMERUN;
            PacmanRunner.Start();
            GhostRunner = new Task(runGhosts);
            GhostRunner.Start();
           // RePaint();
        }

        public void setDirection(Direction d)
        {
            
            if (checkPosition(nextPoint(Pacman.Point, d)))
            {
                pacmanDir = d;
            }
        }

        public void RePaint()
        {
            parentForm.SuspendLayout();
            board.Resize();
            wallPaint();
            board.DrawPacMan(Pacman.Point, ColorHead, pacmanDir);
            parentForm.ResumeLayout(false);
        }

        private void runGhosts()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    GhostRunner.Wait(_delay);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void runGame()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    pacmanMove();
                    dotPaint();
                    eatDots(Pacman.Point);

                    string data = Pacman.Point.ToString() + "@" + score + "%"+ Delay;
                    parentForm.Write(data);
                    PacmanRunner.Wait(_delay);
                    checkForWin();

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void ghostMove()
        {
            if (State != GameState.GAMERUN)
            {
                return;
            }
            
        }

        private void pacmanMove()
        {
            if (State != GameState.GAMERUN)
            {
                return;
            }
            Point P = nextPoint(Pacman.Point, pacmanDir);
            board.ClearPacMan(Pacman.Point);
            if (checkPosition(P))
            {
                Pacman = new Pacman(P, pacmanDir);
            }

            board.DrawPacMan(Pacman.Point, Color.Yellow, pacmanDir);
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

        

        private void eatDots(Point P)
        {
            Pacman.coreInit(P);
            for(int i = 0; i <= dotList.Count - 1; i++)
            {
                foreach (Point corePoint in Pacman.core)
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
       
        private bool checkPosition(Point P)
        {
            Pacman.posInit(P);
            foreach (Point banPoint in wallList)
            {
                foreach(Point pacmanPoint in Pacman.perimeter)
                {
                    if(pacmanPoint == banPoint)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private void checkForWin()
        {
            if (dotList.Count == 0)
            {
                State = GameState.GAMEOVER;
            }
        }


        private void wallPaint()
        {

            foreach (Point p in wallList)
            {
                board.DrawRect(p, Color.DarkBlue);
            }
        }

        private void dotPaint()
        {
            foreach (Point p in dotList)
            {
                board.DrawDot(p, Color.White);
            }
        }


        


    }
}
