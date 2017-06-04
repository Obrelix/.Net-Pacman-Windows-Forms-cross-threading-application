namespace PacmanWinForms
{
    partial class frmScores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScores));
            this.dgvHighScores = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDifficulty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCoins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlScore = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDiff = new System.Windows.Forms.Panel();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCoin = new System.Windows.Forms.Panel();
            this.lblCoins = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighScores)).BeginInit();
            this.pnlScore.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDiff.SuspendLayout();
            this.pnlCoin.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHighScores
            // 
            this.dgvHighScores.AllowUserToAddRows = false;
            this.dgvHighScores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkOrange;
            this.dgvHighScores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHighScores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHighScores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHighScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHighScores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.Score,
            this.ColDifficulty,
            this.ColCoins});
            this.dgvHighScores.Location = new System.Drawing.Point(0, 0);
            this.dgvHighScores.Name = "dgvHighScores";
            this.dgvHighScores.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHighScores.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvHighScores.Size = new System.Drawing.Size(554, 250);
            this.dgvHighScores.TabIndex = 10;
            this.dgvHighScores.TabStop = false;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.colName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colName.HeaderText = "Nane";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // Score
            // 
            this.Score.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Score.DataPropertyName = "score";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.Score.DefaultCellStyle = dataGridViewCellStyle4;
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            // 
            // ColDifficulty
            // 
            this.ColDifficulty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDifficulty.DataPropertyName = "difficulty";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.ColDifficulty.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColDifficulty.HeaderText = "Difficulty";
            this.ColDifficulty.Name = "ColDifficulty";
            this.ColDifficulty.ReadOnly = true;
            // 
            // ColCoins
            // 
            this.ColCoins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColCoins.DataPropertyName = "coinsAdded";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.ColCoins.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColCoins.HeaderText = "Coins Added";
            this.ColCoins.Name = "ColCoins";
            this.ColCoins.ReadOnly = true;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtName.BackColor = System.Drawing.Color.Black;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtName.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtName.Location = new System.Drawing.Point(11, 24);
            this.txtName.MaxLength = 4;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(55, 23);
            this.txtName.TabIndex = 0;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(41, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Score";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnAdd.Location = new System.Drawing.Point(456, 254);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 47);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblScore
            // 
            this.lblScore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblScore.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblScore.Location = new System.Drawing.Point(38, 26);
            this.lblScore.Margin = new System.Windows.Forms.Padding(0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 17);
            this.lblScore.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(13, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name";
            // 
            // pnlScore
            // 
            this.pnlScore.Controls.Add(this.label1);
            this.pnlScore.Controls.Add(this.lblScore);
            this.pnlScore.Location = new System.Drawing.Point(4, 254);
            this.pnlScore.Name = "pnlScore";
            this.pnlScore.Size = new System.Drawing.Size(133, 47);
            this.pnlScore.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Location = new System.Drawing.Point(366, 254);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(76, 47);
            this.panel1.TabIndex = 12;
            // 
            // pnlDiff
            // 
            this.pnlDiff.Controls.Add(this.lblDifficulty);
            this.pnlDiff.Controls.Add(this.label2);
            this.pnlDiff.Location = new System.Drawing.Point(143, 254);
            this.pnlDiff.Name = "pnlDiff";
            this.pnlDiff.Size = new System.Drawing.Size(101, 47);
            this.pnlDiff.TabIndex = 13;
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDifficulty.ForeColor = System.Drawing.Color.Gold;
            this.lblDifficulty.Location = new System.Drawing.Point(9, 26);
            this.lblDifficulty.Margin = new System.Windows.Forms.Padding(0);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(0, 17);
            this.lblDifficulty.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(15, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Difficulty";
            // 
            // pnlCoin
            // 
            this.pnlCoin.Controls.Add(this.lblCoins);
            this.pnlCoin.Controls.Add(this.label4);
            this.pnlCoin.Location = new System.Drawing.Point(251, 254);
            this.pnlCoin.Name = "pnlCoin";
            this.pnlCoin.Size = new System.Drawing.Size(109, 47);
            this.pnlCoin.TabIndex = 14;
            // 
            // lblCoins
            // 
            this.lblCoins.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCoins.AutoSize = true;
            this.lblCoins.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCoins.ForeColor = System.Drawing.Color.Red;
            this.lblCoins.Location = new System.Drawing.Point(45, 26);
            this.lblCoins.Margin = new System.Windows.Forms.Padding(0);
            this.lblCoins.Name = "lblCoins";
            this.lblCoins.Size = new System.Drawing.Size(0, 17);
            this.lblCoins.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Coins Added";
            // 
            // frmScores
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(554, 308);
            this.Controls.Add(this.pnlCoin);
            this.Controls.Add(this.pnlDiff);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlScore);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvHighScores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(570, 346);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(570, 346);
            this.Name = "frmScores";
            this.Text = "High Score";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScores_FormClosing);
            this.Load += new System.EventHandler(this.frmHighScores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighScores)).EndInit();
            this.pnlScore.ResumeLayout(false);
            this.pnlScore.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDiff.ResumeLayout(false);
            this.pnlDiff.PerformLayout();
            this.pnlCoin.ResumeLayout(false);
            this.pnlCoin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHighScores;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlScore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDiff;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlCoin;
        private System.Windows.Forms.Label lblCoins;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDifficulty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCoins;
    }
}