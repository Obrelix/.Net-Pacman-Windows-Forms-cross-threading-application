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
        private int curScore;

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

        public void parseScore(int curScore)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(parseScore), new object[] { curScore });
                return;
            }
            txtName.Enabled = true;
            btnAdd.Enabled = true;
            txtName.Focus();
            this.curScore = curScore;
            lblScore.Text = curScore.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HighScoreList.add(new HighScores(txtName.Text, curScore));
            txtName.Enabled = false;
            btnAdd.Enabled = false;
            dgvInit();
            this.Close();
        }

        private void frmScores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(btnAdd.Enabled) HighScoreList.add(new HighScores(txtName.Text, curScore));
            GTools.saveHighScores(GTools.saveFile);
        }
    }
}
