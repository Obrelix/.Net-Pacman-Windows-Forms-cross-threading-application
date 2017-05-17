using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanWinForms
{
    public partial class frmPacmanGame : Form
    {
        PacmanGame game = null;
        int cellHeight, cellWidth;
        bool Redflag = true, Blueflag = true, PinkFlag = true, YellowFlag = true;
        bool bonusFlag = false;
        bool redCollision = false, blueCollision = false, yellowCollision = false, pinkCollision = false;
        public frmPacmanGame()
        {
            InitializeComponent();
        }
        
        public void setCollision(GhostColor color)
        {
            switch (color)
            {
                case GhostColor.RED:
                    redCollision = true;
                    break;
                case GhostColor.BLUE:
                    blueCollision = true;
                    break;
                case GhostColor.PINK:
                    pinkCollision = true;
                    break;
                case GhostColor.YELLOW:
                    yellowCollision = true;
                    break;
                default:
                    break;
            }
        }

        private void frmPacmanGame_Load(object sender, EventArgs e)
        {
            game = new PacmanGame(this, pnlBoard);
            playSound(Properties.Resources.Pacman_Opening_Song);
            posSizeInit();
            game.State = GameState.GAMEPAUSE;
            picRedGhost.Location = new Point(27 * cellWidth + 2, 22 * cellHeight + 2);
            picBlueGhost.Location = new Point(31 * cellWidth + 2, 29 * cellHeight + 2);
            picPinkGhost.Location = new Point(27 * cellWidth + 2, 29 * cellHeight + 2);
            picYellowGhost.Location = new Point(23 * cellWidth + 2, 29 * cellHeight + 2);
        }

        private void frmPacmanGame_KeyDown(object sender, KeyEventArgs e)
        {
            //if (game.State == GameState.GAMEPAUSE)
            //{
            //    game.Continue();
            //}
            //game.RePaint();
            //game.KeyDown(e);
            if (game == null) return;
            if (e.KeyCode == Keys.Left) { game.setDirection(Direction.LEFT); }
            else if (e.KeyCode == Keys.Right) { game.setDirection(Direction.RIGHT); }
            else if (e.KeyCode == Keys.Up) { game.setDirection(Direction.UP); }
            else if (e.KeyCode == Keys.Down) { game.setDirection(Direction.DOWN); }
            else if (e.KeyCode == Keys.Subtract)
            {
                game.PacmanDelay += 5;
                game.GhostDelay += 5;
            }
            else if (e.KeyCode == Keys.Add)
            {
                game.PacmanDelay -= 5;
                game.GhostDelay -= 5;
            }
            else if (e.KeyCode == Keys.P || e.KeyCode == Keys.Space)
            {
                if (game.State == GameState.GAMERUN)
                {
                    game.Pause();
                }
                else if (game.State == GameState.GAMEPAUSE)
                {
                    game.Continue();
                }
            }
        }

        private void posSizeInit()
        {
            cellHeight = pnlBoard.Height / 64;
            cellWidth = pnlBoard.Width / 58;


            picRedGhost.Size = new Size(cellWidth * 4 - 4, cellHeight * 4 - 4);
            picBlueGhost.Size = new Size(cellWidth * 4 - 4, cellHeight * 4 - 4);
            picPinkGhost.Size = new Size(cellWidth * 4 - 4, cellHeight * 4 - 4);
            picYellowGhost.Size = new Size(cellWidth * 4 - 4, cellHeight * 4 - 4);

            pnlLvl.Location = new Point((pnlDisplay.Width - pnlLvl.Width) / 2, 0);
            pnlHighScore.Location = new Point(pnlLvl.Location.X + 100, 0);
            pnlSc.Location = new Point(pnlLvl.Location.X - 100, 0);
            lblScore.Location = new Point((pnlSc.Width - lblScore.Width) / 2, lblLVL.Height + 20);
            lblLVLValue.Location = new Point((pnlSc.Width - lblLVLValue.Width) / 2, lblLVL.Height + 20);
            lblHScoreValue.Location = new Point((pnlSc.Width - lblHScoreValue.Width) / 2, lblLVL.Height + 20);
            pnlDisplay.Location = new Point((this.ClientRectangle.Width - pnlDisplay.Width) / 2, 0);
        }

        public void redGhostMove(Point P, Direction D)
        {

            if (InvokeRequired)
            {
                Invoke(new Action<Point, Direction>(redGhostMove), new object[] { P, D });
                //Invoke(new Action<string>(WritePosition), value);
                return;
            }
            picRedGhost.Location = new Point(P.X * cellWidth + 2, P.Y * cellHeight + 2);

            if (!bonusFlag || redCollision)
            {
                switch (D)
                {
                    case Direction.DOWN:
                        if (redCollision)
                        {
                            picRedGhost.BackgroundImage = Properties.Resources.eyesDown;
                        }
                        else
                        {
                            if (Redflag)
                            {

                                picRedGhost.BackgroundImage = Properties.Resources.RedGhostDown1;
                                Redflag = false;
                            }
                            else
                            {
                                picRedGhost.BackgroundImage = Properties.Resources.RedGhostDown2;
                                Redflag = true;
                            }
                        }
                    break;
                    case Direction.UP:
                        if (redCollision)
                        {
                            picRedGhost.BackgroundImage = Properties.Resources.eyesUp;
                        }
                        else
                        {
                            if (Redflag)
                            {
                                picRedGhost.BackgroundImage = Properties.Resources.RedGhostUp1;
                                Redflag = false;
                            }
                            else
                            {
                                picRedGhost.BackgroundImage = Properties.Resources.RedGhostUp2;
                                Redflag = true;
                            }
                        }
                    break;
                    case Direction.RIGHT:
                        if (redCollision)
                        {
                            picRedGhost.BackgroundImage = Properties.Resources.eyesRight;
                        }
                        else
                        {
                            if (Redflag)
                            {
                                picRedGhost.BackgroundImage = Properties.Resources.RedGhostRight1;
                                Redflag = false;
                            }
                            else
                            {
                                picRedGhost.BackgroundImage = Properties.Resources.RedGhostRight2;
                                Redflag = true;
                            }
                        }
                    break;
                    case Direction.LEFT:

                        if (redCollision)
                        {
                            picRedGhost.BackgroundImage = Properties.Resources.eyesLeft;
                        }
                        else
                        {
                            if (Redflag)
                            {
                                picRedGhost.BackgroundImage = Properties.Resources.RedGhostLeft1;
                                Redflag = false;
                            }
                            else
                            {
                                picRedGhost.BackgroundImage = Properties.Resources.RedGhostLeft2;
                                Redflag = true;
                            }
                        }
                    break;
                }
            }
            else
            {
                if (Redflag)
                {
                   
                    picRedGhost.BackgroundImage = Properties.Resources.BonusBGhost1;
                    Redflag = false;
                }
                else
                {
                    picRedGhost.BackgroundImage = Properties.Resources.BonusBGhost2;
                    Redflag = true;
                }
            }
        }

        public void YellowGhostMove(Point P, Direction D)
        {

            if (InvokeRequired)
            {
                Invoke(new Action<Point, Direction>(YellowGhostMove), new object[] { P, D });
                //Invoke(new Action<string>(WritePosition), value);
                return;
            }
            picYellowGhost.Location = new Point(P.X * cellWidth + 2, P.Y * cellHeight + 2);
            if (!bonusFlag || yellowCollision)
            {
                switch (D)
                {
                    case Direction.DOWN:
                        if (yellowCollision)
                        {
                            picYellowGhost.BackgroundImage = Properties.Resources.eyesDown;
                        }
                        else
                        {
                            if (YellowFlag)
                            {
                                picYellowGhost.BackgroundImage = Properties.Resources.YellowGhostDown1;
                                YellowFlag = false;
                            }
                            else
                            {
                                picYellowGhost.BackgroundImage = Properties.Resources.YellowGhostDown2;
                                YellowFlag = true;
                            }
                        }
                        
                        break;
                    case Direction.UP:
                        if (yellowCollision)
                        {
                            picYellowGhost.BackgroundImage = Properties.Resources.eyesUp;
                        }
                        else
                        {
                            if (YellowFlag)
                            {
                                picYellowGhost.BackgroundImage = Properties.Resources.YellowGhostUp1;
                                YellowFlag = false;
                            }
                            else
                            {
                                picYellowGhost.BackgroundImage = Properties.Resources.YellowGhostUp2;
                                YellowFlag = true;
                            }
                        }
                        
                        break;
                    case Direction.RIGHT:
                        if (yellowCollision)
                        {
                            picYellowGhost.BackgroundImage = Properties.Resources.eyesRight;
                        }
                        else
                        {
                            if (YellowFlag)
                            {
                                picYellowGhost.BackgroundImage = Properties.Resources.YellowGhostRight1;
                                YellowFlag = false;
                            }
                            else
                            {
                                picYellowGhost.BackgroundImage = Properties.Resources.YellowGhostRight2;
                                YellowFlag = true;
                            }
                        }
                        
                        break;
                    case Direction.LEFT:
                        if (yellowCollision)
                        {
                            picYellowGhost.BackgroundImage = Properties.Resources.eyesLeft;
                        }
                        else
                        {
                            if (YellowFlag)
                            {
                                picYellowGhost.BackgroundImage = Properties.Resources.YellowGhostLeft1;
                                YellowFlag = false;
                            }
                            else
                            {
                                picYellowGhost.BackgroundImage = Properties.Resources.YellowGhostLeft2;
                                YellowFlag = true;
                            }
                        }
                        
                        break;
                }
            }
            else
            {
                if (YellowFlag)
                {
                    picYellowGhost.BackgroundImage = Properties.Resources.BonusBGhost1;
                    YellowFlag = false;
                }
                else
                {
                    picYellowGhost.BackgroundImage = Properties.Resources.BonusBGhost2;
                    YellowFlag = true;
                }
            }
        }

        public void PinkGhostMove(Point P, Direction D)
        {

            if (InvokeRequired)
            {
                Invoke(new Action<Point, Direction>(PinkGhostMove), new object[] { P, D });
                //Invoke(new Action<string>(WritePosition), value);
                return;
            }
            picPinkGhost.Location = new Point(P.X * cellWidth + 2, P.Y * cellHeight + 2);
            if (!bonusFlag || pinkCollision)
            {
                switch (D)
                {
                    case Direction.DOWN:
                        if (pinkCollision)
                        {
                            picPinkGhost.BackgroundImage = Properties.Resources.eyesDown;
                        }
                        else
                        {
                            if (PinkFlag)
                            {
                                picPinkGhost.BackgroundImage = Properties.Resources.PinkGhostDown1;
                                PinkFlag = false;
                            }
                            else
                            {
                                picPinkGhost.BackgroundImage = Properties.Resources.PinkGhostDown2;
                                PinkFlag = true;
                            }
                        }
                        break;
                    case Direction.UP:
                        if (pinkCollision)
                        {
                            picPinkGhost.BackgroundImage = Properties.Resources.eyesUp;
                        }
                        else
                        {
                            if (PinkFlag)
                            {
                                picPinkGhost.BackgroundImage = Properties.Resources.PinkGhostUp1;
                                PinkFlag = false;
                            }
                            else
                            {
                                picPinkGhost.BackgroundImage = Properties.Resources.PinkGhostUp2;
                                PinkFlag = true;
                            }
                        }
                        break;
                    case Direction.RIGHT:
                        if (pinkCollision)
                        {
                            picPinkGhost.BackgroundImage = Properties.Resources.eyesRight;
                        }
                        else
                        {
                            if (PinkFlag)
                            {
                                picPinkGhost.BackgroundImage = Properties.Resources.PinkGhostRight1;
                                PinkFlag = false;
                            }
                            else
                            {
                                picPinkGhost.BackgroundImage = Properties.Resources.PinkGhostRight2;
                                PinkFlag = true;
                            }
                        }
                        break;
                    case Direction.LEFT:
                        if (pinkCollision)
                        {
                            picPinkGhost.BackgroundImage = Properties.Resources.eyesLeft;
                        }
                        else
                        {
                            if (PinkFlag)
                            {
                                picPinkGhost.BackgroundImage = Properties.Resources.PinkGhostLeft1;
                                PinkFlag = false;
                            }
                            else
                            {
                                picPinkGhost.BackgroundImage = Properties.Resources.PinkGhostLeft2;
                                PinkFlag = true;
                            }
                        }
                        break;
                }
            }
            else
            {
                if (PinkFlag)
                {
                    picPinkGhost.BackgroundImage = Properties.Resources.BonusBGhost1;
                    PinkFlag = false;
                }
                else
                {
                    picPinkGhost.BackgroundImage = Properties.Resources.BonusBGhost2;
                    PinkFlag = true;
                }
            }

        }

        public void blueGhostMove(Point P, Direction D)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Point, Direction>(blueGhostMove), new object[] { P, D });
                //Invoke(new Action<string>(WritePosition), value);
                return;
            }
            picBlueGhost.Location = new Point(P.X * cellWidth + 2, P.Y * cellHeight + 2);
            if (!bonusFlag || blueCollision)
            {
                switch (D)
                {
                    case Direction.DOWN:
                        if (blueCollision)
                        {
                            picBlueGhost.BackgroundImage = Properties.Resources.eyesDown;
                        }
                        else
                        {
                            if (Blueflag)
                            {
                                picBlueGhost.BackgroundImage = Properties.Resources.BlueGhostDown1;
                                Blueflag = false;
                            }
                            else
                            {
                                picBlueGhost.BackgroundImage = Properties.Resources.BlueGhostDown2;
                                Blueflag = true;
                            }
                        }
                        break;
                    case Direction.UP:
                        if (blueCollision)
                        {
                            picBlueGhost.BackgroundImage = Properties.Resources.eyesUp;
                        }
                        else
                        {
                            if (Blueflag)
                            {
                                picBlueGhost.BackgroundImage = Properties.Resources.BlueGhostUp1;
                                Blueflag = false;
                            }
                            else
                            {
                                picBlueGhost.BackgroundImage = Properties.Resources.BlueGhostUp2;
                                Blueflag = true;
                            }
                        }
                        break;
                    case Direction.RIGHT:
                        if (blueCollision)
                        {
                            picBlueGhost.BackgroundImage = Properties.Resources.eyesRight;
                        }
                        else
                        {
                            if (Blueflag)
                            {
                                picBlueGhost.BackgroundImage = Properties.Resources.BlueGhostRight1;
                                Blueflag = false;
                            }
                            else
                            {
                                picBlueGhost.BackgroundImage = Properties.Resources.BlueGhostRight2;
                                Blueflag = true;
                            }
                        }
                        break;
                    case Direction.LEFT:
                        if (blueCollision)
                        {
                            picBlueGhost.BackgroundImage = Properties.Resources.eyesLeft;
                        }
                        else
                        {
                            if (Blueflag)
                            {
                                picBlueGhost.BackgroundImage = Properties.Resources.BlueGhostLeft1;
                                Blueflag = false;
                            }
                            else
                            {
                                picBlueGhost.BackgroundImage = Properties.Resources.BlueGhostLeft2;
                                Blueflag = true;
                            }
                        }
                        break;
                }
            }
            else
            {
                if (Blueflag)
                {
                    picBlueGhost.BackgroundImage = Properties.Resources.BonusBGhost1;
                    Blueflag = false;
                }
                else
                {
                    picBlueGhost.BackgroundImage = Properties.Resources.BonusBGhost2;
                    Blueflag = true;
                }
            }
        }

        private async void frmPacmanGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (game == null) return;
            game.Stop();
            if (!game.Runner.IsCompleted)
            {
#if RELESE
                this.Hide();
#endif
                e.Cancel = true;
                await game.Runner;
                this.Close();
            }
        }

        private void frmPacmanGame_Activated(object sender, EventArgs e)
        {
            if (game == null) return;
            game.RePaint();
            game.Continue();
        }

        private void frmPacmanGame_Deactivate(object sender, EventArgs e)
        {
            if (game == null) return;
            game.Pause();
        }

        private void frmPacmanGame_Paint(object sender, PaintEventArgs e)
        {
            game.RePaint();
        }


        int counter = 0, redCounter = 0, blueCounter = 0, pinkCounter = 0, yellowCounter = 0;

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            //playSound(Properties.Resources.Pacman_Siren);
            if (bonusFlag)
            {
                if (bonusFlag && counter <= 60)
                {
                    game.setGhostState(GhostColor.BLUE, GhostState.BONUS);
                    game.setGhostState(GhostColor.RED, GhostState.BONUS);
                    game.setGhostState(GhostColor.PINK, GhostState.BONUS);
                    game.setGhostState(GhostColor.YELLOW, GhostState.BONUS);
                    counter++;
                }
                else
                {
                    game.setGhostState(GhostColor.BLUE, GhostState.NORMAL);
                    game.setGhostState(GhostColor.RED, GhostState.NORMAL);
                    game.setGhostState(GhostColor.PINK, GhostState.NORMAL);
                    game.setGhostState(GhostColor.YELLOW, GhostState.NORMAL);
                    counter = 0;
                    bonusFlag = false;
                }
               
            }

            if (redCollision && redCounter <= 50)
            {
                game.setGhostState(GhostColor.RED, GhostState.EATEN);
                redCounter++;
            }
            else if (redCounter >= 50)
            {
                game.setGhostState(GhostColor.RED, GhostState.NORMAL);
                redCollision = false;
                redCounter = 0;
            }
            if (blueCollision && blueCounter <= 50)
            {
                game.setGhostState(GhostColor.BLUE, GhostState.EATEN);
                blueCounter++;
            }
            else if (blueCounter >= 50)
            {
                game.setGhostState(GhostColor.BLUE, GhostState.NORMAL);
                blueCollision = false;
                blueCounter = 0;
            }
            if (pinkCollision && pinkCounter <= 50)
            {
                game.setGhostState(GhostColor.PINK, GhostState.EATEN);
                pinkCounter++;
            }
            else if (pinkCounter >= 50)
            {
                game.setGhostState(GhostColor.PINK, GhostState.NORMAL);
                pinkCollision = false;
                pinkCounter = 0;
            }
            if (yellowCollision && yellowCounter <= 50)
            {
                game.setGhostState(GhostColor.YELLOW, GhostState.EATEN);
                yellowCounter++;
            }
            else if( yellowCounter >= 50 )
            {
                game.setGhostState(GhostColor.YELLOW, GhostState.NORMAL);
                yellowCollision = false;
                yellowCounter = 0;
            }

            game.Bonus = bonusFlag;
        }

        private void frmPacmanGame_Resize(object sender, EventArgs e)
        {
            this.Height = (int)(1.25 * this.Width);
            if (game == null) return;
            game.RePaint();
            posSizeInit();
        }

        public void playSound(Stream s)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Stream>(playSound), new object[] { s });
                return;
            }
            SoundPlayer player = new SoundPlayer(s);
            player.Play();
        }

        public void Write(string score, string lvl, string lives, string position, string delay  )
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, string, string, string, string>(Write), new object[] { score, lvl, lives, position, delay });
                return;
            }
            this.lblPosition.Text ="Coors : " + position ;
            this.lblScore.Text = score;
            lblDelay.Text = "Delay : " + delay + " ms";
            lblLVLValue.Text = lvl;
            lblHScoreValue.Text = lives;
            posSizeInit();
        }

        public void Bonus(bool flag)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(Bonus), new object[] { flag });
                return;
            }
            bonusFlag = true;
        }


        private void frmPacmanGame_Shown(object sender, EventArgs e)
        {
            if (game == null) return;
            game.Run();
            game.State = GameState.GAMEPAUSE;
        }
    }
}
