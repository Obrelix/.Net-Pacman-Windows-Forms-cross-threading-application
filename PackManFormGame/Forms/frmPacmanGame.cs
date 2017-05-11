using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackManFormGame
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
            lblPosInit();
        }

        private void frmPacmanGame_KeyDown(object sender, KeyEventArgs e)
        {
            //game.KeyDown(e);
            if (game == null) return;
            if (e.KeyCode == Keys.Left) { game.pacmanDir = Direction.LEFT; }
            else if (e.KeyCode == Keys.Right) { game.pacmanDir = Direction.RIGHT; }
            else if (e.KeyCode == Keys.Up) { game.pacmanDir = Direction.UP; }
            else if (e.KeyCode == Keys.Down) { game.pacmanDir = Direction.DOWN; }
            else if (e.KeyCode == Keys.Subtract) { game.Delay += 10; }
            else if (e.KeyCode == Keys.Add) { game.Delay -= 10; }
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

        private void lblPosInit()
        {
            
            lblLVL.Location = new Point((pnlScores.Width - lblLVL.Width) / 2, 10);
            lblLVLValue.Location = new Point((pnlScores.ClientRectangle.Width - lblLVLValue.Width) / 2, lblLVL.Height + 10);
            lblLScore.Location = new Point(lblLVL.Location.X - lblScore.Width - 100, 10);
            lblScore.Location = new Point(((lblLScore.Width - lblScore.Width) / 2) + 62, lblLVL.Height + 10);
            lblHightScore.Location = new Point(184 + lblScore.Width  + 100, 10);
            pnlScores.Location = new Point((this.ClientRectangle.Width - pnlScores.Width) / 2, 0);
        }

        private async void frmPacmanGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (game == null) return;
            game.Stop();
            if (!game.PacmanRunner.IsCompleted)
            {
#if RELESE
                this.Hide();
#endif
                e.Cancel = true;
                await game.PacmanRunner;
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

        private void frmPacmanGame_Resize(object sender, EventArgs e)
        {
            if (game == null) return;
            game.RePaint();
            lblPosInit();
        }

        public void Write(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Write), new object[] { data });
                //Invoke(new Action<string>(WritePosition), value);
                return;
            }
            this.lblPosition.Text ="Coors : " + data.Split('@').First() ;
            this.lblScore.Text = data.Split('@').Last().Split('%').First();
            lblDelay.Text = "Delay : " + data.Split('%').Last() + " ms";
            //lblPosInit();
        }


        private void frmPacmanGame_Shown(object sender, EventArgs e)
        {
            if (game == null) return;
            game.Run();
        }
    }
}
