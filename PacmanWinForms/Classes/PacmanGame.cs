using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Media;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

public delegate void Communicate(Task t, Point P);

namespace PacmanWinForms
{
    public enum GameState : byte
    {
        GAMEOVER = 0,
        GAMEPAUSE = 1,
        GAMERUN = 2
    }

    public enum Direction : Int16
    {
        UP = 0,
        LEFT = 1,
        DOWN = 2,
        RIGHT = 3,
        STOP = 14
    }

    public enum GhostColor : byte
    {
        RED = 0,
        BLUE = 1,
        YELLOW = 2,
        PINK = 3
    }

    public class PacmanGame
    {

        public int Delay
        {
            get { return _delay; }
            set
            {
                _delay = (value < 10) ? 10 : value;
                RedGhost.Delay = _delay;
                BlueGhost.Delay = _delay;
                PinkGhost.Delay = _delay;
                YellowGhost.Delay = _delay;
                Pacman.Delay = _delay;
            }
        }

        private GameState _state = GameState.GAMEOVER;

        public  GameState State
        {
            get { return _state; }
            set
            {
                _state = value;
                Pacman.State = value;
                RedGhost.State = value;
                BlueGhost.State = value;
                YellowGhost.State = value;
                PinkGhost.State = value;
            }
        }
        public Task Runner;
        
        private int _delay = 70;
        private int score = 0;       
        private  frmPacmanGame parentForm;
        private  PacmanBoard board;
        private PacmanRun Pacman;
        private GhostRun RedGhost;
        private GhostRun BlueGhost;
        private GhostRun PinkGhost;
        private GhostRun YellowGhost;
        List<Point> wallList = new List<Point>();
        List<Point> dotList = new List<Point>();
        List<Point> boxList = new List<Point>();
        List<Point> boxDoorList = new List<Point>();
        List<Point> bonusList = new List<Point>();


        public PacmanGame(frmPacmanGame frm, Panel p)
        {
            parentForm = frm;
            board = new PacmanBoard(p);
            Pacman = new PacmanRun(parentForm, board);
            RedGhost = new GhostRun(parentForm, board, GhostColor.RED);
            BlueGhost = new GhostRun(parentForm, board, GhostColor.BLUE);
            PinkGhost = new GhostRun(parentForm, board, GhostColor.PINK);
            YellowGhost = new GhostRun(parentForm, board, GhostColor.YELLOW);
            this.Init();
            RePaint();
        }

        public void setState(GameState state)
        {
            this.State = state;
            Pacman.State = GameState.GAMEOVER;
            RedGhost.State = GameState.GAMEOVER;
            BlueGhost.State = GameState.GAMEOVER;
            YellowGhost.State = GameState.GAMEOVER;
            PinkGhost.State = GameState.GAMEOVER;
        }

        private void Init()
        {
            wallList = PointLists.banPointList();
            dotList = PointLists.dotPointList();
            boxList = PointLists.boxPointList();
            boxDoorList = PointLists.boxDoorPointList();
            bonusList = PointLists.bonusPointList();

            State = GameState.GAMEOVER;
            Pacman.State = GameState.GAMEOVER;
            RedGhost.State = GameState.GAMEOVER;
            BlueGhost.State = GameState.GAMEOVER;
            YellowGhost.State = GameState.GAMEOVER;
            PinkGhost.State = GameState.GAMEOVER;

            score = 0;
            Delay = 70;
        }

        public void Run()
        {
            State = GameState.GAMERUN;
            Pacman.State = GameState.GAMERUN;
            RedGhost.State = GameState.GAMERUN;
            BlueGhost.State = GameState.GAMERUN;
            YellowGhost.State = GameState.GAMERUN;
            PinkGhost.State = GameState.GAMERUN;
            Runner = new Task(runGame);
            Runner.Start();
            Pacman.Run();
            RedGhost.Run();
            BlueGhost.Run();
            YellowGhost.Run();
            PinkGhost.Run();
            RePaint();
        }

        public void RePaint()
        {
            parentForm.SuspendLayout();
            board.Resize();
            parentForm.ResumeLayout(false);
        }

        private void runGame()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    checkForWin();
                    doorPaint();
                    wallPaint();
                    dotPaint();
                    bonusPaint();
                    string data = Pacman.Point.ToString() + "@" + score + "%" + Delay;
                    parentForm.Write(data);
                    Runner.Wait(_delay);

                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private void eatDots(Point[] core)
        {
            
            for (int i = 0; i <= dotList.Count - 1; i++)
            {
                foreach (Point corePoint in core)
                {
                    if (corePoint.X == dotList[i].X && corePoint.Y == dotList[i].Y)
                    {
                        dotList.RemoveAt(i);
                        score += 10;
                        Stream s = Properties.Resources.Pacman_Waka_Waka_Cut;
                        SoundPlayer player = new SoundPlayer(s);
                        player.Play();
                        // parentForm.playSound(Properties.Resources.Pacman_Waka_Waka_Cut);
                        break;
                    }
                }
            }
        }

        private void eatBonus(Point[] core)
        {
            for (int i = 0; i <= bonusList.Count - 1; i++)
            {
                foreach (Point corePoint in core)
                {
                    if (corePoint.X == bonusList[i].X && corePoint.Y == bonusList[i].Y)
                    {
                        bonusList.RemoveAt(i);
                        score += 25;
                        parentForm.playSound(Properties.Resources.Pacman_Waka_Waka_Cut);
                        break;
                    }
                }
            }
        }


        private void checkForWin()
        {
            if (dotList.Count == 0)
            {
                parentForm.playSound(Properties.Resources.Pacman_Intermission);
                State = GameState.GAMEOVER;
                Pacman.State = GameState.GAMEOVER;
                RedGhost.State = GameState.GAMEOVER;
                BlueGhost.State = GameState.GAMEOVER;
                YellowGhost.State = GameState.GAMEOVER;
                PinkGhost.State = GameState.GAMEOVER;
            }
        }
        
        public void setDirection(Direction d)
        {
            Pacman.setDirection(d);
        }

        private void doorPaint()
        {
            foreach (Point p in boxDoorList)
            {
                board.DrawDoor(p, Color.SlateBlue);
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

        private void bonusPaint()
        {
            foreach (Point p in bonusList)
            {
                board.DrawBonus(p, Color.White);
            }
        }

        public void Stop()
        {
            State = GameState.GAMEOVER;
            Pacman.State = GameState.GAMEOVER;
            RedGhost.State = GameState.GAMEOVER;
            BlueGhost.State = GameState.GAMEOVER;
            YellowGhost.State = GameState.GAMEOVER;
            PinkGhost.State = GameState.GAMEOVER;
        }

        public void Pause()
        {
            if (State == GameState.GAMERUN)
            {
                Pacman.State = GameState.GAMEPAUSE;
                RedGhost.State = GameState.GAMEPAUSE;
                BlueGhost.State = GameState.GAMEPAUSE;
                YellowGhost.State = GameState.GAMEPAUSE;
                PinkGhost.State = GameState.GAMEPAUSE;
                State = GameState.GAMEPAUSE;
            }
        }

        public void Continue()
        {
            if (State == GameState.GAMEPAUSE)
            {
                Pacman.State = GameState.GAMERUN;
                RedGhost.State = GameState.GAMERUN;
                BlueGhost.State = GameState.GAMERUN;
                YellowGhost.State = GameState.GAMERUN;
                PinkGhost.State = GameState.GAMERUN;
                State = GameState.GAMERUN;
            }
        }
    }
}
