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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPacmanGame));
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblLScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLVL = new System.Windows.Forms.Label();
            this.lblLVLValue = new System.Windows.Forms.Label();
            this.lblLives = new System.Windows.Forms.Label();
            this.lblLivesValue = new System.Windows.Forms.Label();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.lblInfoDetails = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblGhostDelay = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.pnlHighScore = new System.Windows.Forms.Panel();
            this.pnlLvl = new System.Windows.Forms.Panel();
            this.pnlSc = new System.Windows.Forms.Panel();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.mnuGame = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBoard.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            this.pnlHighScore.SuspendLayout();
            this.pnlLvl.SuspendLayout();
            this.pnlSc.SuspendLayout();
            this.mnuGame.SuspendLayout();
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
            this.lblLScore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLScore.AutoSize = true;
            this.lblLScore.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLScore.ForeColor = System.Drawing.Color.White;
            this.lblLScore.Location = new System.Drawing.Point(44, 0);
            this.lblLScore.Name = "lblLScore";
            this.lblLScore.Size = new System.Drawing.Size(58, 18);
            this.lblLScore.TabIndex = 2;
            this.lblLScore.Text = "Score";
            // 
            // lblScore
            // 
            this.lblScore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(65, 20);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(18, 18);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLVL
            // 
            this.lblLVL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLVL.AutoSize = true;
            this.lblLVL.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLVL.ForeColor = System.Drawing.Color.White;
            this.lblLVL.Location = new System.Drawing.Point(44, 0);
            this.lblLVL.Name = "lblLVL";
            this.lblLVL.Size = new System.Drawing.Size(58, 18);
            this.lblLVL.TabIndex = 4;
            this.lblLVL.Text = "Level";
            // 
            // lblLVLValue
            // 
            this.lblLVLValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLVLValue.AutoSize = true;
            this.lblLVLValue.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLVLValue.ForeColor = System.Drawing.Color.White;
            this.lblLVLValue.Location = new System.Drawing.Point(64, 17);
            this.lblLVLValue.Name = "lblLVLValue";
            this.lblLVLValue.Size = new System.Drawing.Size(18, 18);
            this.lblLVLValue.TabIndex = 5;
            this.lblLVLValue.Text = "1";
            // 
            // lblLives
            // 
            this.lblLives.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLives.AutoSize = true;
            this.lblLives.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLives.ForeColor = System.Drawing.Color.White;
            this.lblLives.Location = new System.Drawing.Point(44, 0);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(58, 18);
            this.lblLives.TabIndex = 6;
            this.lblLives.Text = "Lives";
            // 
            // lblLivesValue
            // 
            this.lblLivesValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLivesValue.AutoSize = true;
            this.lblLivesValue.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLivesValue.ForeColor = System.Drawing.Color.Red;
            this.lblLivesValue.Location = new System.Drawing.Point(64, 20);
            this.lblLivesValue.Name = "lblLivesValue";
            this.lblLivesValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLivesValue.Size = new System.Drawing.Size(18, 18);
            this.lblLivesValue.TabIndex = 7;
            this.lblLivesValue.Text = "3";
            // 
            // pnlBoard
            // 
            this.pnlBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBoard.Controls.Add(this.lblInfoDetails);
            this.pnlBoard.Controls.Add(this.lblInfo);
            this.pnlBoard.Controls.Add(this.lblPosition);
            this.pnlBoard.Controls.Add(this.lblGhostDelay);
            this.pnlBoard.Controls.Add(this.lblDelay);
            this.pnlBoard.Location = new System.Drawing.Point(9, 77);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(522, 576);
            this.pnlBoard.TabIndex = 0;
            // 
            // lblInfoDetails
            // 
            this.lblInfoDetails.AutoSize = true;
            this.lblInfoDetails.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInfoDetails.ForeColor = System.Drawing.Color.Red;
            this.lblInfoDetails.Location = new System.Drawing.Point(238, 297);
            this.lblInfoDetails.Name = "lblInfoDetails";
            this.lblInfoDetails.Size = new System.Drawing.Size(58, 18);
            this.lblInfoDetails.TabIndex = 4;
            this.lblInfoDetails.Text = "Score";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Courier New", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(163, 257);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(206, 40);
            this.lblInfo.TabIndex = 16;
            this.lblInfo.Text = "Game Over";
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
            this.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDisplay.Controls.Add(this.pnlHighScore);
            this.pnlDisplay.Controls.Add(this.pnlLvl);
            this.pnlDisplay.Controls.Add(this.pnlSc);
            this.pnlDisplay.Location = new System.Drawing.Point(39, 26);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(450, 45);
            this.pnlDisplay.TabIndex = 0;
            // 
            // pnlHighScore
            // 
            this.pnlHighScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHighScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHighScore.Controls.Add(this.lblLives);
            this.pnlHighScore.Controls.Add(this.lblLivesValue);
            this.pnlHighScore.Location = new System.Drawing.Point(296, 0);
            this.pnlHighScore.Name = "pnlHighScore";
            this.pnlHighScore.Size = new System.Drawing.Size(150, 45);
            this.pnlHighScore.TabIndex = 17;
            // 
            // pnlLvl
            // 
            this.pnlLvl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlLvl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLvl.Controls.Add(this.lblLVL);
            this.pnlLvl.Controls.Add(this.lblLVLValue);
            this.pnlLvl.Location = new System.Drawing.Point(148, 0);
            this.pnlLvl.Name = "pnlLvl";
            this.pnlLvl.Size = new System.Drawing.Size(150, 45);
            this.pnlLvl.TabIndex = 16;
            // 
            // pnlSc
            // 
            this.pnlSc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSc.Controls.Add(this.lblLScore);
            this.pnlSc.Controls.Add(this.lblScore);
            this.pnlSc.Location = new System.Drawing.Point(0, 0);
            this.pnlSc.Name = "pnlSc";
            this.pnlSc.Size = new System.Drawing.Size(150, 45);
            this.pnlSc.TabIndex = 15;
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // mnuGame
            // 
            this.mnuGame.BackColor = System.Drawing.Color.Black;
            this.mnuGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.mnuGame.Location = new System.Drawing.Point(0, 0);
            this.mnuGame.Name = "mnuGame";
            this.mnuGame.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuGame.Size = new System.Drawing.Size(539, 24);
            this.mnuGame.TabIndex = 1;
            this.mnuGame.Text = "menuStrip1";
            this.mnuGame.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuGame_ItemClicked);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelp,
            this.mnuAbout});
            this.menuToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "&Menu";
            // 
            // mnuHelp
            // 
            this.mnuHelp.BackColor = System.Drawing.Color.White;
            this.mnuHelp.ForeColor = System.Drawing.Color.Black;
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(107, 22);
            this.mnuHelp.Text = "&Help";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.BackColor = System.Drawing.Color.White;
            this.mnuAbout.ForeColor = System.Drawing.Color.Black;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
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
            this.Controls.Add(this.mnuGame);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnuGame;
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
            this.mnuGame.ResumeLayout(false);
            this.mnuGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblLScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblLVL;
        private System.Windows.Forms.Label lblLVLValue;
        private System.Windows.Forms.Label lblLives;
        private System.Windows.Forms.Label lblLivesValue;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.Panel pnlLvl;
        private System.Windows.Forms.Panel pnlSc;
        private System.Windows.Forms.Panel pnlHighScore;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.Label lblGhostDelay;
        private System.Windows.Forms.MenuStrip mnuGame;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblInfoDetails;
    }
}

