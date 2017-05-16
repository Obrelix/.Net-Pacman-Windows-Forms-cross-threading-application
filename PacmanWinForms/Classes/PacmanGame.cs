using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;

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
        PINK = 3,
        NULL = 5
    }

    public enum GhostState : byte
    {
        NORMAL = 0,
        BONUS = 1,
        EATEN = 2
    }

    public class PacmanGame
    {

        public int PacmanDelay
        {
            get { return _delay; }
            set
            {
                
                _delay = (value < 10) ? 10 : value;
                Pacman.Delay = _delay;
            }
        }

        public int RedGhostDelay
        {
            get { return RedGhost.Delay; }
            set { RedGhost.Delay = value; }
        }

        public int BlueGhostDelay
        {
            get { return BlueGhost.Delay; }
            set { BlueGhost.Delay = value; }
        }

        public int PinkGhostDelay
        {
            get { return PinkGhost.Delay; }
            set { PinkGhost.Delay = value; }
        }

        public int YellowGhostDelay
        {
            get { return YellowGhost.Delay; }
            set { YellowGhost.Delay = value; }
        }

        public int GhostDelay
        {
            get { return _ghostDelay; }
            set
            {
                _ghostDelay = (value < 10) ? 10 : value;
                RedGhost.Delay = _ghostDelay;
                BlueGhost.Delay = _ghostDelay;
                PinkGhost.Delay = _ghostDelay;
                YellowGhost.Delay = _ghostDelay;
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
        public Task wallRunner;
        private int _ghostDelay = 70;
        private int _delay = 70;
        private int score = 0;
        private bool _bonus = false;
        private int Level = 1;
        private int lives = 3;
        private bool changeLvl = false;
        public bool Bonus
        {
            get
            {
                return _bonus;
            }
            set
            {
                _bonus = value;
            }
        }

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


        private void Init()
        {
            wallList = PointLists.banPointList();
            dotList = PointLists.dotPointList();
            boxList = PointLists.boxPointList();
            boxDoorList = PointLists.boxDoorPointList();
            bonusList = PointLists.bonusPointList();

            State = GameState.GAMEOVER;

            score = 0;
            PacmanDelay = 70;
        }


        public void Run()
        {
            RePaint();
            State = GameState.GAMERUN;
            Runner = new Task(runGame);
            Runner.Start();
            wallRunner = new Task(runWalls);
            wallRunner.Start();
            Pacman.Run();
            RedGhost.Run();
            BlueGhost.Run();
            YellowGhost.Run();
            PinkGhost.Run();
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
                    eatDots(Pacman.core());
                    eatBonus(Pacman.core());
                    bonusClear();
                    counter = (counter > 4) ? 1 : counter;
                    bonusPaint(counter);
                    dotPaint();
                    checkForWin();
                    parentForm.setCollision(checkForCollision());
                    checkForLose();
                    string data = Pacman.Point.ToString() + "@" + score + "%" + PacmanDelay;
                    parentForm.Write(score.ToString(), Level.ToString(), Pacman.Point.ToString(), _delay.ToString());
                    Runner.Wait(10);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        int counter = 1;
        private void runWalls()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    counter = (counter > 4) ? 1 : counter;
                    counter++;
                    doorPaint();
                    wallPaint();
                    Runner.Wait(70);
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
                        //Stream s = Properties.Resources.Pacman_Waka_Waka_Cut;
                        //SoundPlayer player = new SoundPlayer(s);
                        //player.Play();
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
                        score += 50;
                        Bonus = true;
                        parentForm.Bonus(Bonus);
                        break;
                    }
                }
            }
        }

        int eatenScore = 200;

        private void checkForLose()
        {
            List<Point> mergedList = new List<Point>();
            mergedList = RedGhost.core().Union(BlueGhost.core()).Union(PinkGhost.core()).Union(YellowGhost.core()).ToList();

            List<Point> commonPoints = Pacman.core().Intersect(mergedList.Select(u => u)).ToList();

            if ((commonPoints.Count != 0 && !Bonus) || lives == 0)
            {
               // WaitSomeTime();
                State = GameState.GAMEPAUSE;
                parentForm.playSound(Properties.Resources.Pacman_Dies);

                RedGhost.reset();
                BlueGhost.reset();
                PinkGhost.reset();
                YellowGhost.reset();
                Pacman.reset();
                lives--;
                if (lives == 0)
                {
                    State = GameState.GAMEOVER;
                }
            }
        }

        private void checkForWin()
        {
            if (dotList.Count == 0 && bonusList.Count == 0)
            {
                parentForm.playSound(Properties.Resources.Pacman_Intermission);
                State = GameState.GAMEPAUSE;
                ChangeLevel();
            }
        }

        private GhostColor checkForCollision()
        {
            eatenScore = (Bonus) ? eatenScore : 200;
            List<Point> commonPoints = Pacman.core().Intersect(RedGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus)
            {
                score += eatenScore;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                return GhostColor.RED;
            }

            commonPoints.Clear();
            commonPoints = Pacman.core().Intersect(BlueGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus)
            {
                score += eatenScore;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                return GhostColor.BLUE;
            }

            commonPoints.Clear();
            commonPoints = Pacman.core().Intersect(YellowGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus)
            {
                score += eatenScore;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                return GhostColor.YELLOW;
            }

            commonPoints.Clear();
            commonPoints = Pacman.core().Intersect(PinkGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus)
            {
                score += eatenScore;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                return GhostColor.PINK;
            }

            return GhostColor.NULL;
        }


        private void ChangeLevel()
        {
            dotList = PointLists.dotPointList();
            bonusList = PointLists.bonusPointList();
            State = GameState.GAMEPAUSE;
            RedGhost.reset();
            BlueGhost.reset();
            PinkGhost.reset();
            YellowGhost.reset();
            Pacman.reset();
            GhostDelay -= 10;
            GhostDelay = (_ghostDelay < 10) ? 10 : _ghostDelay;
            Level++;
        }
        public async void WaitSomeTime()
        {
            await Task.Delay(1000);

        }

        public void setGhostState(GhostColor color, GhostState state)
        {
            switch (color)
            {
                case GhostColor.RED:
                    RedGhost.gState = state;
                    break;
                case GhostColor.BLUE:
                    BlueGhost.gState = state;
                    break;
                case GhostColor.PINK:
                    PinkGhost.gState = state;
                    break;
                case GhostColor.YELLOW:
                    YellowGhost.gState = state;
                    break;
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
            Color color = new Color();
            color = (Level == 1) ? Color.DarkBlue : Color.Blue;
            foreach (Point p in wallList)
            {
                board.DrawRect(p, color);
            }
        }

        private void dotPaint()
        {
            foreach (Point p in dotList)
            {
                board.DrawDot(p, Color.White);
            }
        }

        private void bonusPaint(int state)
        {
            foreach (Point p in bonusList)
            {
                board.DrawBonus(p, Color.White, state);
            }
        }

        private void bonusClear()
        {
            if(bonusList.Count != 0)
            {
                foreach (Point p in bonusList)
                {
                    board.ClearBonus(p);
                }
            }
        }

        public void Stop()
        {
            State = GameState.GAMEOVER;
        }

        public void Pause()
        {
            if (State == GameState.GAMERUN)
            {
                State = GameState.GAMEPAUSE;
            }
        }

        public void Continue()
        {
            if (State == GameState.GAMEPAUSE)
            {
                State = GameState.GAMERUN;
            }
        }
    }
}
