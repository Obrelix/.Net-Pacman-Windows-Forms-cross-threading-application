namespace PackManFormGame
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
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblLScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLVL = new System.Windows.Forms.Label();
            this.lblLVLValue = new System.Windows.Forms.Label();
            this.lblHightScore = new System.Windows.Forms.Label();
            this.lblHScoreValue = new System.Windows.Forms.Label();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.lblDelay = new System.Windows.Forms.Label();
            this.pnlScores = new System.Windows.Forms.Panel();
            this.pnlScores.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.Location = new System.Drawing.Point(12, 41);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(14, 13);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "0";
            // 
            // lblLScore
            // 
            this.lblLScore.AutoSize = true;
            this.lblLScore.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLScore.ForeColor = System.Drawing.Color.White;
            this.lblLScore.Location = new System.Drawing.Point(3, 8);
            this.lblLScore.Name = "lblLScore";
            this.lblLScore.Size = new System.Drawing.Size(70, 23);
            this.lblLScore.TabIndex = 2;
            this.lblLScore.Text = "Score";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(32, 31);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(22, 23);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLVL
            // 
            this.lblLVL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLVL.AutoSize = true;
            this.lblLVL.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLVL.ForeColor = System.Drawing.Color.White;
            this.lblLVL.Location = new System.Drawing.Point(169, 8);
            this.lblLVL.Name = "lblLVL";
            this.lblLVL.Size = new System.Drawing.Size(70, 23);
            this.lblLVL.TabIndex = 4;
            this.lblLVL.Text = "Level";
            // 
            // lblLVLValue
            // 
            this.lblLVLValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLVLValue.AutoSize = true;
            this.lblLVLValue.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLVLValue.ForeColor = System.Drawing.Color.White;
            this.lblLVLValue.Location = new System.Drawing.Point(192, 34);
            this.lblLVLValue.Name = "lblLVLValue";
            this.lblLVLValue.Size = new System.Drawing.Size(22, 23);
            this.lblLVLValue.TabIndex = 5;
            this.lblLVLValue.Text = "1";
            // 
            // lblHightScore
            // 
            this.lblHightScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHightScore.AutoSize = true;
            this.lblHightScore.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHightScore.ForeColor = System.Drawing.Color.White;
            this.lblHightScore.Location = new System.Drawing.Point(306, 8);
            this.lblHightScore.Name = "lblHightScore";
            this.lblHightScore.Size = new System.Drawing.Size(130, 23);
            this.lblHightScore.TabIndex = 6;
            this.lblHightScore.Text = "High Score";
            // 
            // lblHScoreValue
            // 
            this.lblHScoreValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHScoreValue.AutoSize = true;
            this.lblHScoreValue.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHScoreValue.ForeColor = System.Drawing.Color.White;
            this.lblHScoreValue.Location = new System.Drawing.Point(337, 34);
            this.lblHScoreValue.Name = "lblHScoreValue";
            this.lblHScoreValue.Size = new System.Drawing.Size(70, 23);
            this.lblHScoreValue.TabIndex = 7;
            this.lblHScoreValue.Text = "99999";
            // 
            // pnlBoard
            // 
            this.pnlBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBoard.Location = new System.Drawing.Point(0, 61);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(697, 771);
            this.pnlBoard.TabIndex = 0;
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDelay.ForeColor = System.Drawing.Color.White;
            this.lblDelay.Location = new System.Drawing.Point(12, 16);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(14, 13);
            this.lblDelay.TabIndex = 14;
            this.lblDelay.Text = "0";
            // 
            // pnlScores
            // 
            this.pnlScores.Controls.Add(this.lblHScoreValue);
            this.pnlScores.Controls.Add(this.lblLScore);
            this.pnlScores.Controls.Add(this.lblHightScore);
            this.pnlScores.Controls.Add(this.lblScore);
            this.pnlScores.Controls.Add(this.lblLVLValue);
            this.pnlScores.Controls.Add(this.lblLVL);
            this.pnlScores.Location = new System.Drawing.Point(135, 1);
            this.pnlScores.Name = "pnlScores";
            this.pnlScores.Size = new System.Drawing.Size(439, 63);
            this.pnlScores.TabIndex = 0;
            // 
            // frmPacmanGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(698, 831);
            this.Controls.Add(this.pnlScores);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.pnlBoard);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
            this.pnlScores.ResumeLayout(false);
            this.pnlScores.PerformLayout();
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
        private System.Windows.Forms.Label lblHightScore;
        private System.Windows.Forms.Label lblHScoreValue;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Panel pnlScores;
    }
}

