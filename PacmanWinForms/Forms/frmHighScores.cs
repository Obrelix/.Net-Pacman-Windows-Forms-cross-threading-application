using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanWinForms
{
    public partial class frmScores : Form
    {

        DataTable dtDriveFiles;
        private int curScore, coinsAdded;
        Difficulty difficulty;

        public frmScores()
        {
            InitializeComponent();
        }

        private void frmHighScores_Load(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            btnAdd.Enabled = false;
            dgvInit();
        }
        private void dgvInit()
        {
            dtDriveFiles = null;
            dtDriveFiles = GTools.ToDataTable<HighScores>(HighScoreList.hsList);
            dgvHighScores.DataSource = dtDriveFiles;

        }

        public void parseScore(int curScore, Difficulty dif, int coinsAdded)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, Difficulty, int>(parseScore), new object[] { curScore, dif, coinsAdded});
                return;
            }
            txtName.Enabled = true;
            btnAdd.Enabled = true;
            txtName.Focus();
            difficulty = dif;
            this.coinsAdded = coinsAdded;
            this.curScore = curScore;
            lblScore.Text = curScore.ToString();
            lblCoins.Text = coinsAdded.ToString();
            lblDifficulty.Text = difficulty.ToString();
            lblLocationInit();
        }

        private void lblLocationInit()
        {
            lblScore.Location = new Point((pnlScore.Width - lblScore.Width) / 2, 26);
            lblCoins.Location = new Point((pnlCoin.Width - lblCoins.Width) / 2, 26);
            lblDifficulty.Location = new Point((pnlDiff.Width - lblDifficulty.Width) / 2, 26);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HighScoreList.add(new HighScores(txtName.Text, curScore, coinsAdded, difficulty));
            txtName.Enabled = false;
            btnAdd.Enabled = false;
            dgvInit();
            this.Close();
        }

        private void frmScores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(btnAdd.Enabled) HighScoreList.add(new HighScores(txtName.Text, curScore, coinsAdded, difficulty));
            GTools.saveHighScores(GTools.saveFile);
        }
    }
}
