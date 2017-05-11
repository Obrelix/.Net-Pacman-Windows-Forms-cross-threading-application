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
        public Pacman(Point point, Direction direction)
        {
            this.Point = point;
            this.Direction = direction;
        }
    }

    public class PacmanGame
    {
        public Direction pacmanDir = Direction.STOP;
        private Direction pacmanPrevDir = Direction.STOP;

        public Direction ghostDir = Direction.STOP;
        private Direction ghostPrevDir = Direction.STOP;

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
        
        private Point pacmanNextPoint = new Point();
        private Point ghostNextPoint = new Point();
        private frmPacmanGame parentForm;
        private PacmanBoard board;
        private Pacman Pacman;
        private Pacman RedGhost;

        private Point[] posArray = new Point[8];
        private Point[] pacmanCoreArray = new Point[4];
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
            pacmanNextPoint = Pacman.Point;

            ghostDir = Direction.RIGHT;
            RedGhost = new Pacman(new Point(27, 30), ghostDir);

            score = 0;
            Delay = 70;

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
            PacmanRunner = new Task(runGame);
            State = GameState.GAMERUN;
            PacmanRunner.Start();
            GhostRunner = new Task(runGhosts);
            GhostRunner.Start();
            RePaint();
        }

        private void runGhosts()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                   // ghostMove();

                    PacmanRunner.Wait(_delay);
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
                    boardPaint();

                    checkDots(Pacman.Point);

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

            ghostNextPoint = Pacman.Point;
            switch (ghostDir)
            {
                case Direction.UP:
                    ghostNextPoint.Y--;
                    break;
                case Direction.DOWN:
                    ghostNextPoint.Y++;
                    break;
                case Direction.RIGHT:
                    ghostNextPoint.X++;
                    break;
                case Direction.LEFT:
                    ghostNextPoint.X--;
                    break;
                case Direction.STOP:
                    // board.DrawPacMan(Pacman.Point, Color.Yellow, Direction);
                    break;
            }
            checkNextPos(ghostNextPoint);
        }

        private void pacmanMove()
        {
            if (State != GameState.GAMERUN)
            {
                return;
            }

            pacmanNextPoint = Pacman.Point;
            switch (pacmanDir)
            {
                case Direction.UP:
                    pacmanNextPoint.Y--;
                    break;
                case Direction.DOWN:
                    pacmanNextPoint.Y++;
                    break;
                case Direction.RIGHT:
                    pacmanNextPoint.X++;
                    break;
                case Direction.LEFT:
                    pacmanNextPoint.X--;
                    break;
                case Direction.STOP:
                   // board.DrawPacMan(Pacman.Point, Color.Yellow, Direction);
                    break;
            }
            checkNextPos(pacmanNextPoint);
        }

        private void boardPaint()
        {
            foreach (Point p in dotList)
            {
                board.DrawDot(p, Color.White);
            }
            foreach (Point p in wallList)
            {
                board.DrawRect(p, Color.DarkBlue);
            }
        }

        private void checkForWin()
        {
            if (dotList.Count == 0)
            {
                State = GameState.GAMEOVER;
            }
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
                Pacman = new Pacman(P, pacmanDir);
                board.DrawPacMan(Pacman.Point, Color.Yellow, pacmanDir);
                pacmanPrevDir = pacmanDir;
            }
            else
            {
                board.ClearPacMan(Pacman.Point);
                pacmanDir = pacmanPrevDir;
                board.DrawPacMan(Pacman.Point, Color.Yellow, pacmanDir);
            }
        }
       
        private bool checkPosition()
        {
            foreach (Point banPoint in wallList)
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
            board.DrawPacMan(Pacman.Point, ColorHead, pacmanDir);
            parentForm.ResumeLayout(false);
        }

        
    }
}
