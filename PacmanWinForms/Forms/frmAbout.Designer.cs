namespace PacmanWinForms
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblWebPage = new System.Windows.Forms.LinkLabel();
            this.lblIssues = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Created by : Ioannis Alimpertis";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblIssues);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblWebPage);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblLicense);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(42, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 155);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version : 0.85 Beta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "License :";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(67, 41);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(66, 13);
            this.lblLicense.TabIndex = 3;
            this.lblLicense.TabStop = true;
            this.lblLicense.Text = "MIT License";
            this.lblLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLicense_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Github Link :";
            // 
            // lblWebPage
            // 
            this.lblWebPage.AutoSize = true;
            this.lblWebPage.Location = new System.Drawing.Point(85, 89);
            this.lblWebPage.Name = "lblWebPage";
            this.lblWebPage.Size = new System.Drawing.Size(176, 13);
            this.lblWebPage.TabIndex = 5;
            this.lblWebPage.TabStop = true;
            this.lblWebPage.Text = "https://github.com/Obrelix/Pacman";
            this.lblWebPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblWebPage_LinkClicked);
            // 
            // lblIssues
            // 
            this.lblIssues.AutoSize = true;
            this.lblIssues.Location = new System.Drawing.Point(96, 114);
            this.lblIssues.Name = "lblIssues";
            this.lblIssues.Size = new System.Drawing.Size(210, 13);
            this.lblIssues.TabIndex = 7;
            this.lblIssues.TabStop = true;
            this.lblIssues.Text = "https://github.com/Obrelix/Pacman/issues";
            this.lblIssues.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblIssues_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Report Issues :";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(399, 230);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(415, 268);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(415, 268);
            this.Name = "frmAbout";
            this.Text = "About";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lblIssues;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lblWebPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lblLicense;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}