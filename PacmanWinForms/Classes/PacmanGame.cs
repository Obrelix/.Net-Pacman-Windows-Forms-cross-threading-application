using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;

public delegate void Communicate(Task t, Point P);
public delegate void CheatCode();
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
        EATEN = 2,
        BONUSEND = 4
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
        public Task Clock;
        private int _ghostDelay = 90;
        private int _delay = 90;
        private int score = 0;
        private bool _bonus = false;
        private int Level = 1;
        private int lives = 3;

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
            PacmanDelay = 80;
            GhostDelay = 80;
        }


        public void Run()
        {
            RePaint();
            State = GameState.GAMERUN;
            Runner = new Task(runGame);
            Runner.Start();
            wallRunner = new Task(runWalls);
            wallRunner.Start();
            Clock = new Task(runClock);
            Clock.Start();
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
                    addLives();
                    bonusClear();
                    bonusPaint(bonusStateCounter);
                    dotPaint();
                    checkForWin();
                    checkForLose();
                    checkForCollision();
                    parentForm.Write(score.ToString(), Level.ToString(), convertLives(lives), Pacman.Point.ToString(), PacmanDelay.ToString(), GhostDelay.ToString());
                    Runner.Wait(10);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private string convertLives(int l)
        {
            string lives = string.Empty;
            for (int i = 0; i < l; i++) lives += "❤";
            return lives;

        }

        private void addLives()
        {
            if (score % 10000 == 0)
            {
                parentForm.playSound(Properties.Resources.Pacman_Extra_Live);
                score += 10;
                lives++;
            }
        }

        private void runWalls()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    doorPaint();
                    wallPaint();
                    wallRunner.Wait(100);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private void runClock()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    changeGhostState();
                    bonusStateChange();
                    Clock.Wait(100);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        int  redCounter = 0, blueCounter = 0, pinkCounter = 0, yellowCounter = 0;

        private void changeGhostState()
        {
            if (RedGhost.gState == GhostState.EATEN && redCounter <= 50 && this.State == GameState.GAMERUN)
            {
                redCounter++;
            }
            else if (redCounter >= 50)
            {
                setGhostState(GhostColor.RED, GhostState.NORMAL );
                redCounter = 0;
            }
            if (BlueGhost.gState == GhostState.EATEN && blueCounter <= 50 && this.State == GameState.GAMERUN)
            {
                blueCounter++;
            }
            else if (blueCounter >= 50)
            {
                setGhostState(GhostColor.BLUE, GhostState.NORMAL);
                blueCounter = 0;
            }
            if (PinkGhost.gState == GhostState.EATEN && pinkCounter <= 50 && this.State == GameState.GAMERUN)
            {
                pinkCounter++;
            }
            else if (pinkCounter >= 50)
            {
                setGhostState(GhostColor.PINK, GhostState.NORMAL);
                pinkCounter = 0;
            }
            if (YellowGhost.gState == GhostState.EATEN && yellowCounter <= 50 && this.State == GameState.GAMERUN)
            {
                yellowCounter++;
            }
            else if (yellowCounter >= 50)
            {
                setGhostState(GhostColor.YELLOW, GhostState.NORMAL);
                yellowCounter = 0;
            }
        }

        int bonusStateCounter = 1, bonusCounter = 0;
        bool BonusEndSprite = true;
        
        private void bonusStateChange()
        {
            bonusStateCounter = (bonusStateCounter > 4) ? 1 : bonusStateCounter;
            bonusStateCounter++;
            if (Bonus && bonusCounter < 70 && this.State == GameState.GAMERUN)
            {
                bonusCounter++;
                
            }
            else if (Bonus && bonusCounter >= 70 && bonusCounter < 100)
            {
                if (BonusEndSprite)
                {
                    if (BlueGhost.gState != GhostState.EATEN) setGhostState(GhostColor.BLUE, GhostState.BONUSEND);
                    if (RedGhost.gState != GhostState.EATEN) setGhostState(GhostColor.RED, GhostState.BONUSEND);
                    if (PinkGhost.gState != GhostState.EATEN) setGhostState(GhostColor.PINK, GhostState.BONUSEND);
                    if (YellowGhost.gState != GhostState.EATEN) setGhostState(GhostColor.YELLOW, GhostState.BONUSEND);
                    BonusEndSprite = false;
                }
                else
                {
                    if (BlueGhost.gState != GhostState.EATEN) setGhostState(GhostColor.BLUE, GhostState.BONUS);
                    if (RedGhost.gState != GhostState.EATEN) setGhostState(GhostColor.RED, GhostState.BONUS);
                    if (PinkGhost.gState != GhostState.EATEN) setGhostState(GhostColor.PINK, GhostState.BONUS);
                    if (YellowGhost.gState != GhostState.EATEN) setGhostState(GhostColor.YELLOW, GhostState.BONUS);
                    BonusEndSprite = true;
                }
                bonusCounter++;
            }
            else if(Bonus && bonusCounter >= 100)
            {
                bonusCounter = 0;
                Bonus = false;
                if (BlueGhost.gState != GhostState.EATEN) setGhostState(GhostColor.BLUE, GhostState.NORMAL);
                if (RedGhost.gState != GhostState.EATEN) setGhostState(GhostColor.RED, GhostState.NORMAL);
                if (PinkGhost.gState != GhostState.EATEN) setGhostState(GhostColor.PINK, GhostState.NORMAL);
                if (YellowGhost.gState != GhostState.EATEN) setGhostState(GhostColor.YELLOW, GhostState.NORMAL);
                
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
                        score += 20 * Level/2;
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
                        score += 100 * Level/2;
                        setGhostState(GhostColor.BLUE, GhostState.BONUS);
                        setGhostState(GhostColor.RED, GhostState.BONUS);
                        setGhostState(GhostColor.PINK, GhostState.BONUS);
                        setGhostState(GhostColor.YELLOW, GhostState.BONUS);
                        Bonus = true; bonusCounter = 0;
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

            if ((commonPoints.Count != 0 && !Bonus ) || lives == 0)
            {
                State = GameState.GAMEPAUSE;
                parentForm.playSound(Properties.Resources.Pacman_Dies);

                WaitSomeTime(1000);
                while (wait) { }
                wait = true;
                RedGhost.reset();
                BlueGhost.reset();
                PinkGhost.reset();
                YellowGhost.reset();
                Pacman.reset();
                Bonus = false;
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
                WaitSomeTime(5000);
                while (wait) { }
                wait = true;
                dotList = PointLists.dotPointList();
                bonusList = PointLists.bonusPointList();
                ChangeLevel();
            }
        }

        private GhostColor checkForCollision()
        {
            eatenScore = (!Bonus || eatenScore > 1600) ? 200 : eatenScore;
            List<Point> commonPoints = Pacman.core().Intersect(RedGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus && RedGhost.gState != GhostState.EATEN)
            {
                score += eatenScore;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                State = GameState.GAMEPAUSE;
                setGhostState(GhostColor.RED, GhostState.EATEN);
                State = GameState.GAMERUN;
                return GhostColor.RED;
            }

            commonPoints.Clear();
            commonPoints = Pacman.core().Intersect(BlueGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus && BlueGhost.gState != GhostState.EATEN)
            {
                score += eatenScore;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                State = GameState.GAMEPAUSE;
                setGhostState(GhostColor.BLUE, GhostState.EATEN);
                State = GameState.GAMERUN;
                return GhostColor.BLUE;
            }

            commonPoints.Clear();
            commonPoints = Pacman.core().Intersect(YellowGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus && YellowGhost.gState != GhostState.EATEN)
            {
                score += eatenScore;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                State = GameState.GAMEPAUSE;
                setGhostState(GhostColor.YELLOW, GhostState.EATEN);
                State = GameState.GAMERUN;
                return GhostColor.YELLOW;
            }

            commonPoints.Clear();
            commonPoints = Pacman.core().Intersect(PinkGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus && PinkGhost.gState != GhostState.EATEN)
            {
                score += eatenScore;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                State = GameState.GAMEPAUSE;
                setGhostState(GhostColor.PINK, GhostState.EATEN);
                State = GameState.GAMERUN;
                return GhostColor.PINK;
            }

            return GhostColor.NULL;
        }

        bool wait = true;
        public void cheat()
        {
            lock (this)
            {
                ChangeLevel();
            }
        }
        private void ChangeLevel()
        {
            //PacmanDelay -= 3;
            GhostDelay -= 3;
            State = GameState.GAMEPAUSE;
            RedGhost.reset();
            BlueGhost.reset();
            PinkGhost.reset();
            YellowGhost.reset();
            Pacman.reset();
            Bonus = false;
            Level++;
        }
        public async void WaitSomeTime(int time)
        {
            await Task.Delay(time);
            wait = false;
        }

        public void setGhostState(GhostColor color, GhostState state)
        {
            switch (color)
            {
                case GhostColor.RED: RedGhost.gState = state; break;
                case GhostColor.BLUE: BlueGhost.gState = state; break;
                case GhostColor.PINK: PinkGhost.gState = state; break;
                case GhostColor.YELLOW: YellowGhost.gState = state; break;
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
            switch (Level)
            {
                case 1: color = Color.DarkBlue; break;
                case 2: color = Color.MediumBlue; break;
                case 3: color = Color.Blue; break;
                case 4: color = Color.DodgerBlue; break;
                case 5: color = Color.RoyalBlue; break;
                case 6: color = Color.LightBlue; break;
                case 7: color = Color.LightSkyBlue; break;
                case 8: color = Color.LightSteelBlue; break;
                case 9: color = Color.SteelBlue; break;
                case 10: color = Color.DarkSlateBlue; break;
                case 11: color = Color.SlateBlue; break;
                case 12: color = Color.DarkSlateGray; break;
                case 13: color = Color.SlateGray; break;
                default: color = Color.Blue; break;
            }
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
