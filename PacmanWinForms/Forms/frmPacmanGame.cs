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

        public frmPacmanGame()
        {
            InitializeComponent();
        }
        

        private void frmPacmanGame_Load(object sender, EventArgs e)
        {
            game = new PacmanGame(this, pnlBoard);
            playSound(Properties.Resources.Pacman_Opening_Song);
            posSizeInit();
            game.State = GameState.GAMEPAUSE;
        }

        private void frmPacmanGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (game.State == GameState.GAMEPAUSE)
            {
                game.Continue();
            }
            //game.RePaint();
            //game.KeyDown(e);
            if (game == null) return;
            if (e.KeyCode == Keys.Left) { game.setDirection(Direction.LEFT); }
            else if (e.KeyCode == Keys.Right) { game.setDirection(Direction.RIGHT); }
            else if (e.KeyCode == Keys.Up) { game.setDirection(Direction.UP); }
            else if (e.KeyCode == Keys.Down) { game.setDirection(Direction.DOWN); }
            else if (e.KeyCode == Keys.Subtract) { game.Delay += 5; }
            else if (e.KeyCode == Keys.Add) { game.Delay -= 5; }
            else if (e.KeyCode == Keys.P)
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
            pnlHighScore.Location = new Point(pnlLvl.Location.X + 78 +50, 0);
            pnlSc.Location = new Point(pnlLvl.Location.X - 78 - 50, 0);
            lblScore.Location = new Point((pnlSc.Width - lblScore.Width) / 2, lblLVL.Height + 10);
            pnlDisplay.Location = new Point((this.ClientRectangle.Width - pnlDisplay.Width) / 2, 0);
        }

        public void redGhostMove(Point P, Direction D)
        {
            
            if (InvokeRequired)
            {
                Invoke(new Action<Point, Direction>(redGhostMove), new object[] { P , D });
                //Invoke(new Action<string>(WritePosition), value);
                return;
            }
            picRedGhost.Location = new Point(P.X * cellWidth + 2, P.Y *cellHeight +2);
            switch (D)
            {
                case Direction.DOWN:
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
                        break;
                case Direction.UP:
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
                    break;
                case Direction.RIGHT:
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
                    break;
                case Direction.LEFT:
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
                    break;
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
            switch (D)
            {
                case Direction.DOWN:
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
                    break;
                case Direction.UP:
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
                    break;
                case Direction.RIGHT:
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
                    break;
                case Direction.LEFT:
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
                    break;
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
            switch (D)
            {
                case Direction.DOWN:
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
                    break;
                case Direction.UP:
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
                    break;
                case Direction.RIGHT:
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
                    break;
                case Direction.LEFT:
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
                    break;
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
            switch (D)
            {
                case Direction.DOWN:
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
                    break;
                case Direction.UP:
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
                    break;
                case Direction.RIGHT:
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
                    break;
                case Direction.LEFT:
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
                    break;
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

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            //playSound(Properties.Resources.Pacman_Siren);
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

        public void Write(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Write), new object[] { data });
                return;
            }
            this.lblPosition.Text ="Coors : " + data.Split('@').First() ;
            this.lblScore.Text = data.Split('@').Last().Split('%').First();
            lblDelay.Text = "Delay : " + data.Split('%').Last() + " ms";
            posSizeInit();
        }


        private void frmPacmanGame_Shown(object sender, EventArgs e)
        {
            if (game == null) return;
            game.Run();
            game.State = GameState.GAMEPAUSE;
        }
    }
}
