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
        private int difficulty, algorithm, pacmanDelay, ghostDelay, highScore;
        private frmMain parentForm;
        PacmanBoard board;
        private Sounds samplePlayer;
        private bool cheatEnabled = false;

        public frmPacmanGame(frmMain pForm, int diff, int alg, int pacmanDelay, int ghostDelay, int highScore)
        {
            InitializeComponent();
            parentForm = pForm;
            difficulty = diff;
            algorithm = alg;
            this.pacmanDelay = pacmanDelay;
            this.ghostDelay = ghostDelay;
            this.highScore = highScore;
            samplePlayer = new Sounds();

        }
        


        private void frmPacmanGame_Load(object sender, EventArgs e)
        {
            game = new PacmanGame(this, pnlBoard, pnlBoardInfo, difficulty, algorithm, pacmanDelay, ghostDelay, highScore);
            board = new PacmanBoard(pnlBoard);
            //this.Width = Screen.PrimaryScreen.Bounds.Width / 2;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 40;
            posSizeInit();
            //samplePlayer.playBackground(1, false);
        }

        private void frmPacmanGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (game == null) return;
            if (e.KeyCode == Keys.Left) { game.setDirection(Direction.LEFT); }
            else if (e.KeyCode == Keys.Right) { game.setDirection(Direction.RIGHT); }
            else if (e.KeyCode == Keys.Up) { game.setDirection(Direction.UP); }
            else if (e.KeyCode == Keys.Down) { game.setDirection(Direction.DOWN); }
            else if (e.KeyCode == Keys.F12) { cheatEnabled = true; }
            else if (e.KeyCode == Keys.F1) {if(cheatEnabled) game.cheat(); }
            else if (e.KeyCode == Keys.D1) { game.coinInserted(true); }
            else if (e.KeyCode == Keys.D2) {if (cheatEnabled) game.cheatFruit(true); }
            else if (e.KeyCode == Keys.Enter)
            {
                if(game.State == GameState.GAMERUN)
                {
                    game.State = GameState.GAMEPAUSE;
                   bool result = (MessageBox.Show("Do You want to reset the game?",
                       "Reset?",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                    if(result) game.Reset();
                }
                else game.Reset();
            }
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
            //pnlLvl.Location = new Point((pnlDisplay.Width - pnlLvl.Width) / 2, 0);
            lblLScore.Location = new Point((pnlSc.Width - lblLScore.Width)/2, 1);
            lblLVL.Location = new Point((pnlLvl.Width - lblLVL.Width) / 2, 1);
            lblLives.Location = new Point((pnlHighScore.Width - lblLives.Width) / 2, 1);
            lblScore.Location = new Point((pnlSc.Width - lblScore.Width) / 2, lblLVL.Height + 5);
            lblLVLValue.Location = new Point((pnlSc.Width - lblLVLValue.Width) / 2, lblLVL.Height+ 5);
            lblLivesValue.Location = new Point((pnlSc.Width - lblLivesValue.Width) / 2, lblLVL.Height+ 5);
            pnlDisplay.Location = new Point((panel1.Width - pnlDisplay.Width) / 2, panel1.Height -1);
        }

        public void frmClose()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(frmClose), new object[] {  });
                return;
            }
            this.Close();
            parentForm.Show();
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
                samplePlayer.playBackground(1, true);
                parentForm.Show();
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

        }

        private void frmPacmanGame_Resize(object sender, EventArgs e)
        {
            this.Width = (int)(0.75 * this.Height);
           // this.Height = (int)(1.25 * this.Width);
            if (game == null) return;
            game.RePaint();
            posSizeInit();
        }

        public void playSound( Stream s = null, SoundNames soundName = 0)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Stream, SoundNames >(playSound), new object[] { s, soundName });
                return;
            }
            switch (soundName)
            {
                case SoundNames.Waka:
                    samplePlayer.playWaka(false);
                    break;
                default:

                    SoundPlayer player = new SoundPlayer(s);
                    player.Play();
                    break;
            }
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
            lblGhostDelay.Text = "Ghost Delay : " + ghostDelay + " ms";
            lblLivesValue.Text = lives;
            posSizeInit();

            //addPacman(lives.Length);
        }

        public void AddHighScore(int score, int coins, Difficulty dif)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, int, Difficulty>(AddHighScore), new object[] { score, coins, dif });
                return;
            }
            frmScores form = new frmScores();
            form.Show();
            form.parseScore(score, dif, coins);
        }

        private void mnuHighScores_Click(object sender, EventArgs e)
        {

            frmScores form = new frmScores();
            form.Show();
            //form.parseScore((Convert.ToInt32(lblScore.Text)));
        }

        private void frmPacmanGame_Shown(object sender, EventArgs e)
        {
            samplePlayer.playBackground(1, false);
            if (game == null) return;
            game.Run();
        }

        private void mnuAbout_Click_1(object sender, EventArgs e)
        {
            frmAbout form = new frmAbout();
            form.Show();

        }

        private void mnuHelp_Click_1(object sender, EventArgs e)
        {
            frmHelp form = new frmHelp();
            form.Show();
        }
        
        
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (game == null) return;
            game.Reset();
        }

        private void mnuGame_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
