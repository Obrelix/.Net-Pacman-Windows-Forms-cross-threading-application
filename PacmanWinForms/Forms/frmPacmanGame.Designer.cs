namespace PacmanWinForms
{
    partial class frmPacmanGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblLScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLVL = new System.Windows.Forms.Label();
            this.lblLVLValue = new System.Windows.Forms.Label();
            this.lblHightScore = new System.Windows.Forms.Label();
            this.lblHScoreValue = new System.Windows.Forms.Label();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.lblGhostDelay = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.pnlHighScore = new System.Windows.Forms.Panel();
            this.pnlLvl = new System.Windows.Forms.Panel();
            this.pnlSc = new System.Windows.Forms.Panel();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.pnlBoard.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            this.pnlHighScore.SuspendLayout();
            this.pnlLvl.SuspendLayout();
            this.pnlSc.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.Location = new System.Drawing.Point(208, 565);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(11, 12);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "0";
            // 
            // lblLScore
            // 
            this.lblLScore.AutoSize = true;
            this.lblLScore.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLScore.ForeColor = System.Drawing.Color.White;
            this.lblLScore.Location = new System.Drawing.Point(12, 20);
            this.lblLScore.Name = "lblLScore";
            this.lblLScore.Size = new System.Drawing.Size(58, 18);
            this.lblLScore.TabIndex = 2;
            this.lblLScore.Text = "Score";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(33, 33);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(18, 18);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLVL
            // 
            this.lblLVL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLVL.AutoSize = true;
            this.lblLVL.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLVL.ForeColor = System.Drawing.Color.White;
            this.lblLVL.Location = new System.Drawing.Point(12, 20);
            this.lblLVL.Name = "lblLVL";
            this.lblLVL.Size = new System.Drawing.Size(58, 18);
            this.lblLVL.TabIndex = 4;
            this.lblLVL.Text = "Level";
            // 
            // lblLVLValue
            // 
            this.lblLVLValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLVLValue.AutoSize = true;
            this.lblLVLValue.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLVLValue.ForeColor = System.Drawing.Color.White;
            this.lblLVLValue.Location = new System.Drawing.Point(29, 33);
            this.lblLVLValue.Name = "lblLVLValue";
            this.lblLVLValue.Size = new System.Drawing.Size(18, 18);
            this.lblLVLValue.TabIndex = 5;
            this.lblLVLValue.Text = "1";
            // 
            // lblHightScore
            // 
            this.lblHightScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHightScore.AutoSize = true;
            this.lblHightScore.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHightScore.ForeColor = System.Drawing.Color.White;
            this.lblHightScore.Location = new System.Drawing.Point(12, 20);
            this.lblHightScore.Name = "lblHightScore";
            this.lblHightScore.Size = new System.Drawing.Size(58, 18);
            this.lblHightScore.TabIndex = 6;
            this.lblHightScore.Text = "Lives";
            // 
            // lblHScoreValue
            // 
            this.lblHScoreValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHScoreValue.AutoSize = true;
            this.lblHScoreValue.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHScoreValue.ForeColor = System.Drawing.Color.Red;
            this.lblHScoreValue.Location = new System.Drawing.Point(37, 31);
            this.lblHScoreValue.Name = "lblHScoreValue";
            this.lblHScoreValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHScoreValue.Size = new System.Drawing.Size(18, 18);
            this.lblHScoreValue.TabIndex = 7;
            this.lblHScoreValue.Text = "3";
            // 
            // pnlBoard
            // 
            this.pnlBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBoard.Controls.Add(this.lblPosition);
            this.pnlBoard.Controls.Add(this.lblGhostDelay);
            this.pnlBoard.Controls.Add(this.lblDelay);
            this.pnlBoard.Location = new System.Drawing.Point(9, 77);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(522, 576);
            this.pnlBoard.TabIndex = 0;
            // 
            // lblGhostDelay
            // 
            this.lblGhostDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGhostDelay.AutoSize = true;
            this.lblGhostDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblGhostDelay.ForeColor = System.Drawing.Color.White;
            this.lblGhostDelay.Location = new System.Drawing.Point(408, 565);
            this.lblGhostDelay.Name = "lblGhostDelay";
            this.lblGhostDelay.Size = new System.Drawing.Size(11, 12);
            this.lblGhostDelay.TabIndex = 15;
            this.lblGhostDelay.Text = "0";
            // 
            // lblDelay
            // 
            this.lblDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDelay.AutoSize = true;
            this.lblDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDelay.ForeColor = System.Drawing.Color.White;
            this.lblDelay.Location = new System.Drawing.Point(10, 565);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(11, 12);
            this.lblDelay.TabIndex = 14;
            this.lblDelay.Text = "0";
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.pnlHighScore);
            this.pnlDisplay.Controls.Add(this.pnlLvl);
            this.pnlDisplay.Controls.Add(this.pnlSc);
            this.pnlDisplay.Location = new System.Drawing.Point(103, 4);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(341, 60);
            this.pnlDisplay.TabIndex = 0;
            // 
            // pnlHighScore
            // 
            this.pnlHighScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHighScore.Controls.Add(this.lblHightScore);
            this.pnlHighScore.Controls.Add(this.lblHScoreValue);
            this.pnlHighScore.Location = new System.Drawing.Point(259, 0);
            this.pnlHighScore.Name = "pnlHighScore";
            this.pnlHighScore.Size = new System.Drawing.Size(82, 58);
            this.pnlHighScore.TabIndex = 17;
            // 
            // pnlLvl
            // 
            this.pnlLvl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlLvl.Controls.Add(this.lblLVL);
            this.pnlLvl.Controls.Add(this.lblLVLValue);
            this.pnlLvl.Location = new System.Drawing.Point(132, 0);
            this.pnlLvl.Name = "pnlLvl";
            this.pnlLvl.Size = new System.Drawing.Size(82, 58);
            this.pnlLvl.TabIndex = 16;
            // 
            // pnlSc
            // 
            this.pnlSc.Controls.Add(this.lblLScore);
            this.pnlSc.Controls.Add(this.lblScore);
            this.pnlSc.Location = new System.Drawing.Point(0, 0);
            this.pnlSc.Name = "pnlSc";
            this.pnlSc.Size = new System.Drawing.Size(82, 58);
            this.pnlSc.TabIndex = 15;
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // frmPacmanGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(539, 662);
            this.Controls.Add(this.pnlDisplay);
            this.Controls.Add(this.pnlBoard);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 375);
            this.Name = "frmPacmanGame";
            this.Text = "Pacman";
            this.Activated += new System.EventHandler(this.frmPacmanGame_Activated);
            this.Deactivate += new System.EventHandler(this.frmPacmanGame_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPacmanGame_FormClosing);
            this.Load += new System.EventHandler(this.frmPacmanGame_Load);
            this.Shown += new System.EventHandler(this.frmPacmanGame_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPacmanGame_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPacmanGame_KeyDown);
            this.Resize += new System.EventHandler(this.frmPacmanGame_Resize);
            this.pnlBoard.ResumeLayout(false);
            this.pnlBoard.PerformLayout();
            this.pnlDisplay.ResumeLayout(false);
            this.pnlHighScore.ResumeLayout(false);
            this.pnlHighScore.PerformLayout();
            this.pnlLvl.ResumeLayout(false);
            this.pnlLvl.PerformLayout();
            this.pnlSc.ResumeLayout(false);
            this.pnlSc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblLScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblLVL;
        private System.Windows.Forms.Label lblLVLValue;
        private System.Windows.Forms.Label lblHightScore;
        private System.Windows.Forms.Label lblHScoreValue;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.Panel pnlLvl;
        private System.Windows.Forms.Panel pnlSc;
        private System.Windows.Forms.Panel pnlHighScore;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.Label lblGhostDelay;
    }
}

