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
        //Graphics g;
        //Pen pen = new Pen(Color.Yellow, 2);
        //Brush brushYellow = new SolidBrush(Color.Yellow);
        //Brush brushBlack = new SolidBrush(Color.Black);
        //Rectangle rect;

        public frmPacmanGame()
        {
            InitializeComponent();
            //g = pnlBoard.CreateGraphics();
            //pnlBoard.BackgroundImage = Properties.Resources.maze2;
        }

        //int startAngle = 40, sweepAngle = 270, posX = 24;

        private void timer1_Tick(object sender, EventArgs e)
        {
        
            //rect = new Rectangle(posX, 24, 40, 40);
            //g.FillPie(brushBlack, rect, startAngle, sweepAngle);
            //posX += 24;
            //rect = new Rectangle(posX, 24, 40, 40);
            //g.FillPie(brushYellow, rect, startAngle, sweepAngle);
        }

        private void frmPacmanGame_Load(object sender, EventArgs e)
        {
            game = new PacmanGame(this, pnlBoard);
        }

        private void frmPacmanGame_KeyDown(object sender, KeyEventArgs e)
        {
            //game.KeyDown(e);
            if (game == null) return;
            if (e.KeyCode == Keys.Left) { game.Direction = Direction.LEFT; }
            else if (e.KeyCode == Keys.Right) { game.Direction = Direction.RIGHT; }
            else if (e.KeyCode == Keys.Up) { game.Direction = Direction.UP; }
            else if (e.KeyCode == Keys.Down) { game.Direction = Direction.DOWN; }
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
            game.RePaint();
        }

        public void WritePosition(string value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(WritePosition), new object[] { value });
                //Invoke(new Action<string>(WritePosition), value);
                return;
            }
            this.lblPosition.Text = value;
        }

        private void frmPacmanGame_Shown(object sender, EventArgs e)
        {
            game.Run();
        }
    }
}
