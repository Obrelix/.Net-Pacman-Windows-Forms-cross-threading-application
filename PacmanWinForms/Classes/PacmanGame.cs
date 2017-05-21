using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Security.Cryptography;

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
        BONUSEND = 3
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
                fruit.State = value;
            }
        }

        public Task Runner;
        public Task wallRunner;
        public Task Clock;

        private GameState _state = GameState.GAMEOVER;
        private int _ghostDelay = 90;
        private int _delay = 90;
        private int score = 0;
        private bool _bonus = false;
        private int Level = 1;
        private int lives = 3;
        private int bonusStateCounter = 1, bonusCounter = 0;
        private bool BonusEndSprite = true;
        private int fruitCounter = 0 , AIClockCounter = 0;
        private int redCounter = 0, blueCounter = 0, pinkCounter = 0, yellowCounter = 0;

        private bool addLive = true, addLive2 = true, addLive3 = true;
        private int eatenScore = 200;

        private  frmPacmanGame parentForm;
        private  PacmanBoard board;

        private PacmanRun Pacman;
        private GhostRun RedGhost;
        private GhostRun BlueGhost;
        private GhostRun PinkGhost;
        private GhostRun YellowGhost;
        private FruitRun fruit;

        private bool[] AIFlagArray = new bool[4];

        private List<Point> wallList = new List<Point>();
        private List<Point> dotList = new List<Point>();
        private List<Point> boxList = new List<Point>();
        private List<Point> boxDoorList = new List<Point>();
        private List<Point> bonusList = new List<Point>();
        private List<Point> roadList = new List<Point>();

        public PacmanGame(frmPacmanGame frm, Panel p)
        {
            parentForm = frm;
            board = new PacmanBoard(p);
            Pacman = new PacmanRun(parentForm, board);
            RedGhost = new GhostRun(parentForm, board, GhostColor.RED);
            BlueGhost = new GhostRun(parentForm, board, GhostColor.BLUE);
            PinkGhost = new GhostRun(parentForm, board, GhostColor.PINK);
            YellowGhost = new GhostRun(parentForm, board, GhostColor.YELLOW);
            fruit = new FruitRun(parentForm, board);
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
            roadList = PointLists.roadPointList();
            fruit.fruitState = FruitState.EATEN;
            State = GameState.GAMEOVER;
            AIFlagInit();
            score = 0;
            PacmanDelay = 70;
            GhostDelay = 75;
        }

        private void AIFlagInit()
        {
            int randomInitValue, random;
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                randomInitValue = BitConverter.ToInt32(rno, 0);
            }
            Random rnd = new Random(randomInitValue);
            random = rnd.Next(0, 4);

            for (int i = 0; i < 4; i++)
            {
                if (i != random) AIFlagArray[i] = false;
                else AIFlagArray[i] = true;
            }

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

            RedGhost.Run();
            BlueGhost.Run();
            YellowGhost.Run();
            PinkGhost.Run();
            Pacman.Run();
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
                    checkReset();
                    ghostSetTargets();
                    eatDots(Pacman.core());
                    eatBonus(Pacman.core());
                    addLives();
                    bonusClear();
                    bonusPaint(bonusStateCounter);
                    dotPaint();
                    checkForWin();
                    checkForLose();
                    eatGhost();
                    eatFruit();
                    parentForm.Write(score.ToString(), Level.ToString(), convertLives(lives), Pacman.Point.ToString(), PacmanDelay.ToString(), GhostDelay.ToString());
                    Runner.Wait(10);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }


        private void ghostSetTargets()
        {
            if(AIClockCounter < 500)
            {
                if (RedGhost.gState == GhostState.EATEN) RedGhost.setTarget(new Point(27, 29), true);
                else RedGhost.setTarget(Pacman.Point, false);
                if (BlueGhost.gState == GhostState.EATEN) BlueGhost.setTarget(new Point(27, 29), true);
                else BlueGhost.setTarget(Pacman.Point, false);
                if (PinkGhost.gState == GhostState.EATEN) PinkGhost.setTarget(new Point(27, 29), true);
                else PinkGhost.setTarget(Pacman.Point, false);
                if (YellowGhost.gState == GhostState.EATEN) YellowGhost.setTarget(new Point(27, 29), true);
                else YellowGhost.setTarget(Pacman.Point, false);
            }
            else if(AIClockCounter >= 500)
            {
                if (RedGhost.gState == GhostState.EATEN) RedGhost.setTarget(new Point(27, 29), true);
                else RedGhost.setTarget(Pacman.Point, AIFlagArray[0]);
                if (BlueGhost.gState == GhostState.EATEN) BlueGhost.setTarget(new Point(27, 29), true);
                else BlueGhost.setTarget(Pacman.Point, AIFlagArray[1]);
                if (PinkGhost.gState == GhostState.EATEN) PinkGhost.setTarget(new Point(27, 29), true);
                else PinkGhost.setTarget(Pacman.Point, AIFlagArray[2]);
                if (YellowGhost.gState == GhostState.EATEN) YellowGhost.setTarget(new Point(27, 29), true);
                else YellowGhost.setTarget(Pacman.Point, AIFlagArray[3]);
            }
            if (AIClockCounter % 1500 == 0) AIFlagInit();
            if(State == GameState.GAMERUN)AIClockCounter++;
           
        }

        private string convertLives(int l)
        {
            string lives = string.Empty;
            for (int i = 0; i < l; i++) lives += "❤";
            return lives;

        }

        private void sendMsg()
        {
            switch (State)
            {
                case GameState.GAMEPAUSE:
                    board.PrintMessage(true, "Game Paused", "Press ( p / SpaceBar ) to continue!");
                    break;
                case GameState.GAMEOVER:
                    board.PrintMessage(true, "Game Over", "Press ( Enter ) to play again!");
                    break;
                case GameState.GAMERUN:
                    board.PrintMessage(false, "", "");
                    break;
            }
        }

        private void addLives()
        {
           
            if(score > 14999 && addLive)
            {
                coinInserted();
                addLive = false;
            }
            if(score > 29999 && addLive2)
            {
                coinInserted();
                addLive2 = false;
            }
            if (score > 59999 && addLive3)
            {
                coinInserted();
                addLive3 = false;
            }


        }

        public void coinInserted()
        {
            parentForm.playSound(Properties.Resources.Pacman_Extra_Live);
            lives++;
        }

        private void runWalls()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    //RoadPaint();
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
                    resetPrintables();
                    sendMsg();
                    fruitApear();
                    changeGhostState();
                    bonusStateChange();
                    Clock.Wait(100);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private void changeGhostState()
        {
            if (RedGhost.gState == GhostState.EATEN && redCounter <= 45 && this.State == GameState.GAMERUN)
            {
                redCounter++;
            }
            else if (redCounter >= 45)
            {
                setGhostState(GhostColor.RED, GhostState.NORMAL );
                redCounter = 0;
            }
            if (BlueGhost.gState == GhostState.EATEN && blueCounter <= 45 && this.State == GameState.GAMERUN)
            {
                blueCounter++;
            }
            else if (blueCounter >= 45)
            {
                setGhostState(GhostColor.BLUE, GhostState.NORMAL);
                blueCounter = 0;
            }
            if (PinkGhost.gState == GhostState.EATEN && pinkCounter <= 45 && this.State == GameState.GAMERUN)
            {
                pinkCounter++;
            }
            else if (pinkCounter >= 45)
            {
                setGhostState(GhostColor.PINK, GhostState.NORMAL);
                pinkCounter = 0;
            }
            if (YellowGhost.gState == GhostState.EATEN && yellowCounter <= 45 && this.State == GameState.GAMERUN)
            {
                yellowCounter++;
            }
            else if (yellowCounter >= 45)
            {
                setGhostState(GhostColor.YELLOW, GhostState.NORMAL);
                yellowCounter = 0;
            }
        }
        
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
                    if (BlueGhost.gState != GhostState.EATEN && !BlueGhost.eatenFlag) setGhostState(GhostColor.BLUE, GhostState.BONUSEND);
                    if (RedGhost.gState != GhostState.EATEN && !RedGhost.eatenFlag) setGhostState(GhostColor.RED, GhostState.BONUSEND);
                    if (PinkGhost.gState != GhostState.EATEN && !PinkGhost.eatenFlag) setGhostState(GhostColor.PINK, GhostState.BONUSEND);
                    if (YellowGhost.gState != GhostState.EATEN && ! YellowGhost.eatenFlag) setGhostState(GhostColor.YELLOW, GhostState.BONUSEND);
                    BonusEndSprite = false;
                }
                else
                {
                    if (BlueGhost.gState != GhostState.EATEN && !BlueGhost.eatenFlag) setGhostState(GhostColor.BLUE, GhostState.BONUS);
                    if (RedGhost.gState != GhostState.EATEN && !RedGhost.eatenFlag) setGhostState(GhostColor.RED, GhostState.BONUS);
                    if (PinkGhost.gState != GhostState.EATEN && !PinkGhost.eatenFlag) setGhostState(GhostColor.PINK, GhostState.BONUS);
                    if (YellowGhost.gState != GhostState.EATEN && !YellowGhost.eatenFlag) setGhostState(GhostColor.YELLOW, GhostState.BONUS);
                    BonusEndSprite = true;
                }
                bonusCounter++;
            }
            else if(Bonus && bonusCounter >= 100)
            {
                bonusCounter = 0;
                Bonus = false;
                if (BlueGhost.gState != GhostState.EATEN) { setGhostState(GhostColor.BLUE, GhostState.NORMAL); BlueGhost.eatenFlag = false; }
                if (RedGhost.gState != GhostState.EATEN) { setGhostState(GhostColor.RED, GhostState.NORMAL); RedGhost.eatenFlag = false; }
                if (PinkGhost.gState != GhostState.EATEN) { setGhostState(GhostColor.PINK, GhostState.NORMAL); PinkGhost.eatenFlag = false; }
                if (YellowGhost.gState != GhostState.EATEN) { setGhostState(GhostColor.YELLOW, GhostState.NORMAL); YellowGhost.eatenFlag = false; }
                
            }
        }

        private int fruitPicIndex = 1;
        private void fruitApear()
        {
            if(fruitCounter < 600 && State == GameState.GAMERUN)
            {
                fruitCounter++;
            }
            else if(fruitCounter >= 600 && fruitCounter < 601 && State == GameState.GAMERUN)
            {
                fruit.Run(fruitPicIndex);
                fruitCounter++;
                fruit.fruitState = FruitState.NORMAL;
                fruitPicIndex++;
            }
            else if (fruitCounter >= 601 && fruitCounter < 800 && State == GameState.GAMERUN)
            {
                fruitCounter++;
            }
            else if (fruitCounter >= 800 && State == GameState.GAMERUN)
            {
                fruitCounter = 0;
                fruit.fruitState = FruitState.EATEN;
                board.CleanFruit(fruit.Point, 1);
                fruit.State = GameState.GAMEOVER;
            }
            fruitPicIndex = (fruitPicIndex < 5) ? fruitPicIndex : 1;
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
                       // board.PrintBonus(Pacman.Point, 20 * Level / 2, 1);

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
                        AIFlagInit();
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


        private void checkForLose()
        {
            List<Point> mergedList = new List<Point>();
            mergedList = RedGhost.core().Union(BlueGhost.core()).Union(PinkGhost.core()).Union(YellowGhost.core()).ToList();

            List<Point> commonPoints = Pacman.core().Intersect(mergedList.Select(u => u)).ToList();

            if ((commonPoints.Count != 0 && !Bonus ) || lives == 0)
            {
                State = GameState.GAMEPAUSE;
                parentForm.playSound(Properties.Resources.Pacman_Dies);
                AIFlagInit();
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
                AIClockCounter = 0;
                if (lives == 0)
                {
                    State = GameState.GAMEOVER;
                    sendMsg();
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
                AIClockCounter = 0;
            }
        }

        private void eatFruit()
        {
            List<Point> commonPoints = Pacman.core().Intersect(fruit.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0)
            {
                score += 500 * Level;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Cherry);
                board.PrintBonus(fruit.Point, 500 * Level, 5); printCounter = 0;
                fruit.fruitState = FruitState.EATEN;
                board.CleanFruit(fruit.Point, 1);
            }
        }

        private int ghostEatenCounter = 1;
        private GhostColor eatGhost()
        {
            ghostEatenCounter = (Bonus) ? ghostEatenCounter : 1;
            eatenScore = (!Bonus || eatenScore > 1600) ? 200 : eatenScore;
            List<Point> commonPoints = Pacman.core().Intersect(RedGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus && RedGhost.gState != GhostState.EATEN)
            {
                score += eatenScore;
                ghostEatenCounter++;
                board.PrintBonus(Pacman.Point, eatenScore, ghostEatenCounter); printCounter = 0;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                State = GameState.GAMEPAUSE;
                RedGhost.eatenFlag = true;
                setGhostState(GhostColor.RED, GhostState.EATEN);
                State = GameState.GAMERUN;
                return GhostColor.RED;
            }

            commonPoints.Clear();
            commonPoints = Pacman.core().Intersect(BlueGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus && BlueGhost.gState != GhostState.EATEN)
            {
                score += eatenScore;
                ghostEatenCounter++;
                board.PrintBonus(Pacman.Point, eatenScore, ghostEatenCounter); printCounter = 0;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                State = GameState.GAMEPAUSE;
                BlueGhost.eatenFlag = true;
                setGhostState(GhostColor.BLUE, GhostState.EATEN);
                State = GameState.GAMERUN;
                return GhostColor.BLUE;
            }

            commonPoints.Clear();
            commonPoints = Pacman.core().Intersect(YellowGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus && YellowGhost.gState != GhostState.EATEN)
            {
                score += eatenScore;
                ghostEatenCounter++;
                board.PrintBonus(Pacman.Point, eatenScore, ghostEatenCounter); printCounter = 0;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                State = GameState.GAMEPAUSE;
                YellowGhost.eatenFlag = true;
                setGhostState(GhostColor.YELLOW, GhostState.EATEN);
                State = GameState.GAMERUN;
                return GhostColor.YELLOW;
            }

            commonPoints.Clear();
            commonPoints = Pacman.core().Intersect(PinkGhost.core().Select(u => u)).ToList();
            if (commonPoints.Count != 0 && Bonus && PinkGhost.gState != GhostState.EATEN)
            {
                score += eatenScore;
                ghostEatenCounter++;
                board.PrintBonus(Pacman.Point, eatenScore, ghostEatenCounter); printCounter = 0;
                eatenScore += eatenScore;
                parentForm.playSound(Properties.Resources.Pacman_Eating_Ghost);
                State = GameState.GAMEPAUSE;
                PinkGhost.eatenFlag = true;
                setGhostState(GhostColor.PINK, GhostState.EATEN);
                State = GameState.GAMERUN;
                return GhostColor.PINK;
            }

            return GhostColor.NULL;
        }

        private int printCounter = 0;

        private void resetPrintables()
        {
            printCounter = (printCounter> 100) ? 100 :printCounter;
            if(printCounter > 40)
            {
                board.CleanBonus(new Point(), 0, 10);
            }
            printCounter++;

        }

        bool wait = true, reset = false;
        public void cheat()
        {
            reset = true;
            ChangeLevel();
        }

        private void checkReset()
        {
            if (reset)
            {
                dotList = PointLists.dotPointList();
                bonusList = PointLists.bonusPointList();
                reset = false;
            }
        }

        public void Reset()
        {

            RePaint();
            Run();
            reset = true;
            State = GameState.GAMEPAUSE;
            bonusStateCounter = 1; bonusCounter = 0;
            fruitCounter = 0; AIClockCounter = 0;
            redCounter = 0; blueCounter = 0; pinkCounter = 0; yellowCounter = 0;
            AIClockCounter = 0;
            BonusEndSprite = true; addLive = true; addLive2 = true; addLive3 = true;
            eatenScore = 200; Level = 1; score = 0; lives = 3;
            GhostDelay = 75; PacmanDelay = 70;
            AIFlagInit();
            fruit.fruitState = FruitState.EATEN;
            board.CleanFruit(fruit.Point, 1);
            Bonus = false;
        }

        private void ChangeLevel()
        {
            //PacmanDelay -= 3;
            GhostDelay -= 2;
            AIFlagInit();
            State = GameState.GAMEPAUSE;
            RedGhost.reset();
            BlueGhost.reset();
            PinkGhost.reset();
            YellowGhost.reset();
            Pacman.reset();
            AIClockCounter = 0;
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

        private void RoadPaint()
        {
            foreach(Point p in roadList)
            {
                board.DrawRect(p, Color.Red);
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
