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
            //game.RePaint();
            //game.KeyDown(e);
            if (game == null) return;
            if (e.KeyCode == Keys.Left) { game.setDirection(Direction.LEFT); }
            else if (e.KeyCode == Keys.Right) { game.setDirection(Direction.RIGHT); }
            else if (e.KeyCode == Keys.Up) { game.setDirection(Direction.UP); }
            else if (e.KeyCode == Keys.Down) { game.setDirection(Direction.DOWN); }
            else if (e.KeyCode == Keys.F1) { game.cheat(); }
            else if (e.KeyCode == Keys.D1) { game.coinInserted(); }
            else if (e.KeyCode == Keys.Enter) {if(game.State == GameState.GAMEOVER) game.Reset(); }
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
            lblInfo.Location = new Point((pnlBoard.Width - lblInfo.Width) / 2, (pnlBoard.Height - lblInfo.Height) / 2);
            pnlLvl.Location = new Point((pnlDisplay.Width - pnlLvl.Width) / 2, 0);
            //pnlHighScore.Location = new Point(pnlLvl.Location.X + 78 +50, 0);
            //pnlSc.Location = new Point(pnlLvl.Location.X -78 - 50, 0); 
            lblScore.Location = new Point((pnlSc.Width - lblScore.Width) / 2, lblLVL.Height+2);
            lblLVLValue.Location = new Point((pnlSc.Width - lblLVLValue.Width) / 2, lblLVL.Height+ 2);
            lblLivesValue.Location = new Point((pnlSc.Width - lblLivesValue.Width) / 2, lblLVL.Height+ 2);
            pnlDisplay.Location = new Point((this.ClientRectangle.Width - pnlDisplay.Width) / 2, 30);
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

            lblInfo.Location = new Point((pnlBoard.Width - lblInfo.Width) / 2, (pnlBoard.Height - lblInfo.Height) / 2);
            lblInfoDetails.Location = new Point((pnlBoard.Width - lblInfoDetails.Width) / 2, (pnlBoard.Height - lblInfoDetails.Height) / 2 + lblInfo.Height);
            switch (game.State)
            {
                case GameState.GAMEOVER:
                    lblInfoDetails.Text = "Press ( Enter ) to play again!"; lblInfoDetails.Visible = true;
                    lblInfo.Text = "Game Over"; lblInfo.Visible = true; break;
                case GameState.GAMEPAUSE:
                    lblInfoDetails.Text = "Press ( p / SpaceBar ) to continue!"; lblInfoDetails.Visible = true;
                    lblInfo.Text = "Game Paused"; lblInfo.Visible = true; break;
                case GameState.GAMERUN:
                    lblInfoDetails.Visible = false; lblInfo.Visible = false; break;

            }
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

        public void Write(string score, string lvl, string lives, string position, string delay, string ghostDelay  )
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, string, string, string, string, string>(Write), new object[] { score, lvl, lives, position, delay, ghostDelay });
                return;
            }

            this.lblPosition.Text ="Coors : " + position ;
            this.lblScore.Text = score;
            lblDelay.Text = "Pacman Delay : " + delay + " ms";
            lblLVLValue.Text = lvl;
            lblLivesValue.Text = lives;
            lblGhostDelay.Text = "Ghost Delay : " + ghostDelay + " ms";
            posSizeInit();
        }
        


        private void frmPacmanGame_Shown(object sender, EventArgs e)
        {
            if (game == null) return;
            game.Run();
            game.State = GameState.GAMEPAUSE;
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            frmHelp form = new frmHelp();
            form.Show();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAbout form = new frmAbout();
            form.Show();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (game == null) return;
            game.State = GameState.GAMEPAUSE;
            game.Reset();
        }

        private void mnuGame_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
