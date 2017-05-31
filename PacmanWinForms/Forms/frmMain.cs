using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanWinForms
{
    public partial class frmMain : Form
    {
        int difficulty = 0, algorith = 1, pacmanDelay = 70, ghostDelay = 75;
        static string savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Pacman";
        static string saveFile = savePath + "\\highScores.json";
        
        public frmMain()
        {
            InitializeComponent();
            GTools.loadHighScores(savePath, saveFile);
           // HighScoreList.add(new HighScores("Obre", 1000));

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (lstvDifficulty.SelectedItems.Count > 0) difficulty = lstvDifficulty.SelectedItems[0].Index;
            if (lstvAlgorithm.SelectedItems.Count > 0) algorith = lstvAlgorithm.SelectedItems[0].Index;
            pacmanDelay =(int)nmrPacmanDelay.Value;
            ghostDelay = (int)nmrGhostDelay.Value;
            this.Hide();
            frmPacmanGame form = new frmPacmanGame(this, difficulty, algorith, pacmanDelay, ghostDelay, HighScoreList.max());
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Height = Screen.PrimaryScreen.Bounds.Height;
            form.Show();
        }

        public void frmShow()
        {
            this.Show();
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

        private void mnuHighScores_Click(object sender, EventArgs e)
        {
            frmScores form = new frmScores();
            form.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            GTools.saveHighScores(saveFile);
        }

        bool flag = true;
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                pnlSettings.Visible = true;
                btnStart.Location = new Point((this.ClientRectangle.Width - btnStart.Width) / 2,
                    this.ClientRectangle.Height - btnStart.Height - 10);
                flag = false;
            }
            else
            {
                pnlSettings.Visible = false;
                btnStart.Location = new Point((this.ClientRectangle.Width - btnStart.Width) / 2,
                    (this.ClientRectangle.Height - btnStart.Height) / 2);
                flag = true;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            pnlSettings.Visible = false;
            btnStart.Location = new Point((this.ClientRectangle.Width - btnStart.Width) / 2, 
                (this.ClientRectangle.Height - btnStart.Height) / 2);
            lstvDifficulty.Items[3].Selected = true;
            lstvAlgorithm.Items[0].Selected = true;
            //PointLists.saveMap(1);
        }
    }
}
