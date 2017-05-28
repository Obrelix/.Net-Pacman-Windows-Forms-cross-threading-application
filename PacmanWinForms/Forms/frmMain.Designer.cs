namespace PacmanWinForms
{
    partial class frmMain
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "A Star"}, -1, System.Drawing.Color.Gold, System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161))));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Best First"}, -1, System.Drawing.Color.PaleGreen, System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161))));
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Breadth First"}, -1, System.Drawing.Color.Aqua, System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161))));
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Easy"}, -1, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161))));
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Normal"}, -1, System.Drawing.Color.Green, System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161))));
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "Hard"}, -1, System.Drawing.Color.Red, System.Drawing.Color.Black, new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161))));
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Original AI"}, -1, System.Drawing.Color.Gold, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161))));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.nmrPacmanDelay = new System.Windows.Forms.NumericUpDown();
            this.nmrGhostDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstvAlgorithm = new System.Windows.Forms.ListView();
            this.lstvDifficulty = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.mnuGame = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHighScores = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPacmanDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrGhostDelay)).BeginInit();
            this.mnuGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSettings.Controls.Add(this.nmrPacmanDelay);
            this.pnlSettings.Controls.Add(this.nmrGhostDelay);
            this.pnlSettings.Controls.Add(this.label4);
            this.pnlSettings.Controls.Add(this.label3);
            this.pnlSettings.Controls.Add(this.lstvAlgorithm);
            this.pnlSettings.Controls.Add(this.lstvDifficulty);
            this.pnlSettings.Controls.Add(this.label2);
            this.pnlSettings.Controls.Add(this.label1);
            this.pnlSettings.Location = new System.Drawing.Point(99, 37);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(256, 228);
            this.pnlSettings.TabIndex = 0;
            // 
            // nmrPacmanDelay
            // 
            this.nmrPacmanDelay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nmrPacmanDelay.Location = new System.Drawing.Point(146, 186);
            this.nmrPacmanDelay.Name = "nmrPacmanDelay";
            this.nmrPacmanDelay.Size = new System.Drawing.Size(54, 20);
            this.nmrPacmanDelay.TabIndex = 9;
            this.nmrPacmanDelay.Value = new decimal(new int[] {
            68,
            0,
            0,
            0});
            // 
            // nmrGhostDelay
            // 
            this.nmrGhostDelay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nmrGhostDelay.Location = new System.Drawing.Point(146, 147);
            this.nmrGhostDelay.Name = "nmrGhostDelay";
            this.nmrGhostDelay.Size = new System.Drawing.Size(54, 20);
            this.nmrGhostDelay.TabIndex = 8;
            this.nmrGhostDelay.Value = new decimal(new int[] {
            78,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(18, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ghost\'s Delay:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(18, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pacman\'s Delay:";
            // 
            // lstvAlgorithm
            // 
            this.lstvAlgorithm.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstvAlgorithm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstvAlgorithm.BackColor = System.Drawing.Color.Black;
            this.lstvAlgorithm.HideSelection = false;
            this.lstvAlgorithm.HoverSelection = true;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            this.lstvAlgorithm.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.lstvAlgorithm.Location = new System.Drawing.Point(144, 72);
            this.lstvAlgorithm.MultiSelect = false;
            this.lstvAlgorithm.Name = "lstvAlgorithm";
            this.lstvAlgorithm.Size = new System.Drawing.Size(94, 63);
            this.lstvAlgorithm.TabIndex = 5;
            this.lstvAlgorithm.UseCompatibleStateImageBehavior = false;
            this.lstvAlgorithm.View = System.Windows.Forms.View.SmallIcon;
            // 
            // lstvDifficulty
            // 
            this.lstvDifficulty.AllowDrop = true;
            this.lstvDifficulty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstvDifficulty.BackColor = System.Drawing.Color.Black;
            this.lstvDifficulty.HideSelection = false;
            this.lstvDifficulty.HoverSelection = true;
            listViewItem4.StateImageIndex = 0;
            listViewItem4.Tag = "tag1";
            listViewItem5.StateImageIndex = 0;
            listViewItem5.Tag = "tag1";
            listViewItem6.StateImageIndex = 0;
            listViewItem6.Tag = "tag1";
            this.lstvDifficulty.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.lstvDifficulty.Location = new System.Drawing.Point(144, 13);
            this.lstvDifficulty.MultiSelect = false;
            this.lstvDifficulty.Name = "lstvDifficulty";
            this.lstvDifficulty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstvDifficulty.ShowGroups = false;
            this.lstvDifficulty.Size = new System.Drawing.Size(94, 53);
            this.lstvDifficulty.TabIndex = 4;
            this.lstvDifficulty.UseCompatibleStateImageBehavior = false;
            this.lstvDifficulty.View = System.Windows.Forms.View.SmallIcon;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(18, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ghost\'s Tracking \r\nAlgorithm\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Difficulty";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(157, 280);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(142, 45);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // mnuGame
            // 
            this.mnuGame.BackColor = System.Drawing.Color.Transparent;
            this.mnuGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.mnuGame.Location = new System.Drawing.Point(0, 0);
            this.mnuGame.Name = "mnuGame";
            this.mnuGame.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuGame.Size = new System.Drawing.Size(454, 24);
            this.mnuGame.TabIndex = 4;
            this.mnuGame.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelp,
            this.mnuAbout,
            this.mnuHighScores});
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
            this.mnuHelp.Size = new System.Drawing.Size(139, 22);
            this.mnuHelp.Text = "&Help";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.BackColor = System.Drawing.Color.White;
            this.mnuAbout.ForeColor = System.Drawing.Color.Black;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(139, 22);
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnuHighScores
            // 
            this.mnuHighScores.Name = "mnuHighScores";
            this.mnuHighScores.Size = new System.Drawing.Size(139, 22);
            this.mnuHighScores.Text = "&High-Scores";
            this.mnuHighScores.Click += new System.EventHandler(this.mnuHighScores_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::PacmanWinForms.Properties.Resources.Wiki_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(454, 337);
            this.Controls.Add(this.mnuGame);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.btnStart);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(470, 375);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 375);
            this.Name = "frmMain";
            this.Text = "Pacman";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPacmanDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrGhostDelay)).EndInit();
            this.mnuGame.ResumeLayout(false);
            this.mnuGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListView lstvDifficulty;
        private System.Windows.Forms.ListView lstvAlgorithm;
        private System.Windows.Forms.MenuStrip mnuGame;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmrPacmanDelay;
        private System.Windows.Forms.NumericUpDown nmrGhostDelay;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHighScores;
    }
}