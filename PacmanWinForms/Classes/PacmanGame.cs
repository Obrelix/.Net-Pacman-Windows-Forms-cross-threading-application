using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PacmanWinForms
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

    public enum GhostColor : byte
    {
        RED = 0,
        BLUE = 1,
        YELLOW = 2,
        PINK = 3,

    }

    public class PacmanGame
    {
        public Direction pacmanDirection = Direction.STOP;
        public Direction redGhostDirection = Direction.UP;
        public Direction blueGhostDirection = Direction.UP;

        public int Delay
        {
            get { return _delay; }
            set { _delay = (value < 10) ? 0 : value; }
        }
        public GameState State = GameState.GAMEOVER;
        public Color ColorBody = Color.Black;
        public Color ColorHead = Color.Yellow;
        public Task PacmanRunner;
        public Task RedGhostRunner;
        public Task BlueGhostRunner;


        private int _delay = 70;
        private int score = 0;
        private Point bonus;
        
        private frmPacmanGame parentForm;
        private PacmanBoard board;
        private Pacman Pacman;
        private Pacman RedGhost;
        private Pacman BlueGhost;

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
            pacmanDirection = Direction.STOP;

            Pacman = new Pacman(new Point(27, 40), pacmanDirection);
            
            RedGhost = new Pacman(new Point(27, 22), Direction.RIGHT);
            BlueGhost = new Pacman(new Point(27, 23), Direction.LEFT);

            score = 0;
            Delay = 70;
            RePaint();
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

            State = GameState.GAMERUN;
            PacmanRunner = new Task(runGame);
            PacmanRunner.Start();
            RedGhostRunner = new Task(runRedGhost);
            RedGhostRunner.Start();
            BlueGhostRunner = new Task(runBlueGhost);
            BlueGhostRunner.Start();

            RePaint();
        }

        public void setDirection(Direction d)
        {
            
            if (checkPosition(nextPoint(Pacman.Point, d)))
            {
                pacmanDirection = d;
            }
        }

        public void RePaint()
        {
            parentForm.SuspendLayout();
            board.Resize();
            wallPaint();
            board.DrawPacMan(Pacman.Point, ColorHead, pacmanDirection);
            parentForm.redGhostMove(RedGhost.Point, RedGhost.Direction);
            parentForm.blueGhostMove(BlueGhost.Point, BlueGhost.Direction);

            //board.DrawGhost(RedGhost.Point, ghostDir);
            parentForm.ResumeLayout(false);
        }
        private void runBlueGhost()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    BlueGhost = ghostMove(BlueGhost.Point, BlueGhost.Direction);
                    parentForm.blueGhostMove(BlueGhost.Point, BlueGhost.Direction);
                    BlueGhostRunner.Wait(80);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void runRedGhost()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    RedGhost = ghostMove(RedGhost.Point, RedGhost.Direction);
                    parentForm.redGhostMove(RedGhost.Point, RedGhost.Direction);
                    RedGhostRunner.Wait(80);
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
                    checkForWin();
                    pacmanMove();
                    dotPaint();
                    eatDots(Pacman.Point);
                    string data = Pacman.Point.ToString() + "@" + score + "%"+ Delay;
                    parentForm.Write(data);
                    PacmanRunner.Wait(_delay);

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private Pacman ghostMove(Point StartPoint, Direction d)
        {
            Pacman Ghost = new Pacman(StartPoint, d);
            if (State != GameState.GAMERUN)
            {
                return Ghost;
            }
            Point P = nextPoint(StartPoint, d);
            if (checkForConflict(P))
            {
                Ghost = new Pacman(P, d);
            }
            else
            {
                Ghost = new Pacman(StartPoint, changeDirection());
            }
            return Ghost;
            
        }

        
        private Direction changeDirection()
        {
            int randomvalue;
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                randomvalue = BitConverter.ToInt32(rno, 0);
            }
            Random rnd = new Random(randomvalue);
            int i = rnd.Next(0, 6);
            switch (i)
            {
                case 0:
                    return Direction.LEFT;
                case 1:
                    return Direction.UP;
                case 2:
                    return Direction.RIGHT;
                case 3:
                    return Direction.LEFT;
                case 4:
                    return Direction.DOWN;
                case 5:
                    return Direction.UP;

                default:
                    return Direction.RIGHT;
            }

             
        }

        private bool checkForConflict(Point P)
        {
            Pacman Ghost = new Pacman(P, Direction.STOP);
            Ghost.posInit(P);

            List<Point> commonPoints = Ghost.perimeter.Intersect(wallList.Select(u => u)).ToList();

            return (commonPoints.Count == 0);
        }

        private void pacmanMove()
        {
            if (State != GameState.GAMERUN)
            {
                return;
            }

            board.ClearPacMan(Pacman.Point);

            Point P = nextPoint(Pacman.Point, pacmanDirection);

            Pacman.posInit(P);
            Pacman.edgesInit(P);
            List<Point> commonPoints = Pacman.perimeter.Intersect(wallList.Select(u => u)).ToList();

            if (commonPoints.Count == 0)
            {
                Pacman = new Pacman(P, pacmanDirection);
            }
            else if(commonPoints.Count == 1)
            {
                Pacman = new Pacman(normalizeTurning(commonPoints[0], Pacman.Point, pacmanDirection), pacmanDirection);
            }

            board.DrawPacMan(Pacman.Point, Color.Yellow, pacmanDirection);
        }
        
        private Point normalizeTurning(Point CommonPoint, Point PacmanPoint, Direction D)
        {
            Point norP = new Point();
            norP = PacmanPoint;
            int i;
            for(i = 0; i < 4; i++)
            {
                if(CommonPoint == Pacman.edges[i])
                {
                    break;
                }
                //else if(i == 3 && CommonPoint != Pacman.edges[i])
                //{
                //    return PacmanPoint;
                //}
            }
            switch (D)
            {
                case Direction.UP:
                    if (i == 1) norP.X--;
                    else norP.X++;
                    break;
                case Direction.DOWN:
                    if (i == 3) norP.X++;
                    else norP.X--;
                    break;
                case Direction.RIGHT:
                    if (i == 2) norP.Y--;
                    else norP.Y++;
                    break;
                case Direction.LEFT:
                    if (i == 3) norP.Y--;
                    else norP.Y++;
                    break;
            }
            return norP;
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

            List<Point> commonPoints = Pacman.perimeter.Intersect(wallList.Select(u => u)).ToList();

            return (commonPoints.Count == 0 || commonPoints.Count == 1);
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
