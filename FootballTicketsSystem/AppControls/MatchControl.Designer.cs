namespace FootballTicketsSystem.AppControls
{
    partial class MatchControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchControl));
            this.labelTeamNameFirst = new System.Windows.Forms.Label();
            this.pictureBoxVs = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pictureBoxLogoFirstTeam = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pictureBoxTeamLogoAway = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.labelDataMatch = new System.Windows.Forms.Label();
            this.labelTeamNameSecond = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.labelTimeMatch = new System.Windows.Forms.Label();
            this.labelStadiumName = new System.Windows.Forms.Label();
            this.btnBuyTicket = new Guna.UI2.WinForms.Guna2Button();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.gunaPanelMatch = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDeleteMatch = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoFirstTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeamLogoAway)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).BeginInit();
            this.gunaPanelMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteMatch)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTeamNameFirst
            // 
            this.labelTeamNameFirst.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold);
            this.labelTeamNameFirst.Location = new System.Drawing.Point(239, 50);
            this.labelTeamNameFirst.Name = "labelTeamNameFirst";
            this.labelTeamNameFirst.Size = new System.Drawing.Size(229, 33);
            this.labelTeamNameFirst.TabIndex = 23;
            this.labelTeamNameFirst.Text = "Real";
            this.labelTeamNameFirst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTeamNameFirst.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // pictureBoxVs
            // 
            this.pictureBoxVs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxVs.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxVs.FillColor = System.Drawing.Color.Transparent;
            this.pictureBoxVs.Image = global::FootballTicketsSystem.Properties.Resources.vs;
            this.pictureBoxVs.ImageRotate = 0F;
            this.pictureBoxVs.Location = new System.Drawing.Point(578, 45);
            this.pictureBoxVs.Name = "pictureBoxVs";
            this.pictureBoxVs.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureBoxVs.Size = new System.Drawing.Size(42, 35);
            this.pictureBoxVs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxVs.TabIndex = 25;
            this.pictureBoxVs.TabStop = false;
            this.pictureBoxVs.UseTransparentBackground = true;
            this.pictureBoxVs.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // pictureBoxLogoFirstTeam
            // 
            this.pictureBoxLogoFirstTeam.BorderRadius = 5;
            this.pictureBoxLogoFirstTeam.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogoFirstTeam.Image")));
            this.pictureBoxLogoFirstTeam.ImageRotate = 0F;
            this.pictureBoxLogoFirstTeam.Location = new System.Drawing.Point(474, 20);
            this.pictureBoxLogoFirstTeam.Name = "pictureBoxLogoFirstTeam";
            this.pictureBoxLogoFirstTeam.Size = new System.Drawing.Size(95, 80);
            this.pictureBoxLogoFirstTeam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogoFirstTeam.TabIndex = 26;
            this.pictureBoxLogoFirstTeam.TabStop = false;
            this.pictureBoxLogoFirstTeam.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // pictureBoxTeamLogoAway
            // 
            this.pictureBoxTeamLogoAway.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(233)))), ((int)(((byte)(234)))));
            this.pictureBoxTeamLogoAway.BorderRadius = 5;
            this.pictureBoxTeamLogoAway.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTeamLogoAway.Image")));
            this.pictureBoxTeamLogoAway.ImageRotate = 0F;
            this.pictureBoxTeamLogoAway.Location = new System.Drawing.Point(653, 20);
            this.pictureBoxTeamLogoAway.Name = "pictureBoxTeamLogoAway";
            this.pictureBoxTeamLogoAway.Size = new System.Drawing.Size(95, 80);
            this.pictureBoxTeamLogoAway.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTeamLogoAway.TabIndex = 27;
            this.pictureBoxTeamLogoAway.TabStop = false;
            this.pictureBoxTeamLogoAway.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // guna2CirclePictureBox2
            // 
            this.guna2CirclePictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CirclePictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox2.Image = global::FootballTicketsSystem.Properties.Resources.mdi_calendar;
            this.guna2CirclePictureBox2.ImageRotate = 0F;
            this.guna2CirclePictureBox2.Location = new System.Drawing.Point(483, 112);
            this.guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
            this.guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox2.Size = new System.Drawing.Size(31, 28);
            this.guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox2.TabIndex = 28;
            this.guna2CirclePictureBox2.TabStop = false;
            this.guna2CirclePictureBox2.UseTransparentBackground = true;
            this.guna2CirclePictureBox2.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // labelDataMatch
            // 
            this.labelDataMatch.AutoSize = true;
            this.labelDataMatch.Font = new System.Drawing.Font("Inter", 11F);
            this.labelDataMatch.Location = new System.Drawing.Point(517, 113);
            this.labelDataMatch.Name = "labelDataMatch";
            this.labelDataMatch.Size = new System.Drawing.Size(108, 27);
            this.labelDataMatch.TabIndex = 29;
            this.labelDataMatch.Text = "12.10.2026";
            this.labelDataMatch.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // labelTeamNameSecond
            // 
            this.labelTeamNameSecond.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold);
            this.labelTeamNameSecond.Location = new System.Drawing.Point(760, 50);
            this.labelTeamNameSecond.Name = "labelTeamNameSecond";
            this.labelTeamNameSecond.Size = new System.Drawing.Size(229, 30);
            this.labelTeamNameSecond.TabIndex = 30;
            this.labelTeamNameSecond.Text = "FC Barcelona";
            this.labelTeamNameSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTeamNameSecond.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // guna2CirclePictureBox3
            // 
            this.guna2CirclePictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CirclePictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox3.Image = global::FootballTicketsSystem.Properties.Resources.mingcute_time_fill;
            this.guna2CirclePictureBox3.ImageRotate = 0F;
            this.guna2CirclePictureBox3.Location = new System.Drawing.Point(643, 113);
            this.guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
            this.guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox3.Size = new System.Drawing.Size(30, 25);
            this.guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox3.TabIndex = 31;
            this.guna2CirclePictureBox3.TabStop = false;
            this.guna2CirclePictureBox3.UseTransparentBackground = true;
            this.guna2CirclePictureBox3.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // labelTimeMatch
            // 
            this.labelTimeMatch.AutoSize = true;
            this.labelTimeMatch.Font = new System.Drawing.Font("Inter", 11F);
            this.labelTimeMatch.Location = new System.Drawing.Point(678, 113);
            this.labelTimeMatch.Name = "labelTimeMatch";
            this.labelTimeMatch.Size = new System.Drawing.Size(61, 27);
            this.labelTimeMatch.TabIndex = 32;
            this.labelTimeMatch.Text = "21:00";
            this.labelTimeMatch.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // labelStadiumName
            // 
            this.labelStadiumName.Font = new System.Drawing.Font("Inter", 11F);
            this.labelStadiumName.Location = new System.Drawing.Point(384, 142);
            this.labelStadiumName.Name = "labelStadiumName";
            this.labelStadiumName.Size = new System.Drawing.Size(460, 33);
            this.labelStadiumName.TabIndex = 33;
            this.labelStadiumName.Text = "Стадион: Santiago Bernabeu";
            this.labelStadiumName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelStadiumName.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // btnBuyTicket
            // 
            this.btnBuyTicket.BorderColor = System.Drawing.Color.White;
            this.btnBuyTicket.BorderRadius = 5;
            this.btnBuyTicket.BorderThickness = 2;
            this.btnBuyTicket.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBuyTicket.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBuyTicket.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBuyTicket.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBuyTicket.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.btnBuyTicket.Font = new System.Drawing.Font("Inter Medium", 11F, System.Drawing.FontStyle.Bold);
            this.btnBuyTicket.ForeColor = System.Drawing.Color.White;
            this.btnBuyTicket.Location = new System.Drawing.Point(920, 168);
            this.btnBuyTicket.Name = "btnBuyTicket";
            this.btnBuyTicket.Size = new System.Drawing.Size(262, 49);
            this.btnBuyTicket.TabIndex = 34;
            this.btnBuyTicket.Text = "Купить билет";
            this.btnBuyTicket.Click += new System.EventHandler(this.btnBuyTicket_Click);
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Font = new System.Drawing.Font("Inter", 11F);
            this.labelCapacity.Location = new System.Drawing.Point(36, 193);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(206, 27);
            this.labelCapacity.TabIndex = 36;
            this.labelCapacity.Text = "Заполненность: 72%";
            this.labelCapacity.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold);
            this.labelScore.Location = new System.Drawing.Point(583, 49);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(32, 28);
            this.labelScore.TabIndex = 40;
            this.labelScore.Text = "12";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelScore.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // gunaPanelMatch
            // 
            this.gunaPanelMatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(233)))), ((int)(((byte)(234)))));
            this.gunaPanelMatch.BorderColor = System.Drawing.Color.White;
            this.gunaPanelMatch.BorderRadius = 10;
            this.gunaPanelMatch.BorderThickness = 2;
            this.gunaPanelMatch.Controls.Add(this.btnDeleteMatch);
            this.gunaPanelMatch.Controls.Add(this.labelScore);
            this.gunaPanelMatch.Controls.Add(this.labelCapacity);
            this.gunaPanelMatch.Controls.Add(this.btnBuyTicket);
            this.gunaPanelMatch.Controls.Add(this.labelStadiumName);
            this.gunaPanelMatch.Controls.Add(this.labelTimeMatch);
            this.gunaPanelMatch.Controls.Add(this.guna2CirclePictureBox3);
            this.gunaPanelMatch.Controls.Add(this.labelTeamNameSecond);
            this.gunaPanelMatch.Controls.Add(this.labelDataMatch);
            this.gunaPanelMatch.Controls.Add(this.guna2CirclePictureBox2);
            this.gunaPanelMatch.Controls.Add(this.pictureBoxTeamLogoAway);
            this.gunaPanelMatch.Controls.Add(this.pictureBoxLogoFirstTeam);
            this.gunaPanelMatch.Controls.Add(this.pictureBoxVs);
            this.gunaPanelMatch.Controls.Add(this.labelTeamNameFirst);
            this.gunaPanelMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaPanelMatch.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaPanelMatch.Location = new System.Drawing.Point(0, 0);
            this.gunaPanelMatch.Margin = new System.Windows.Forms.Padding(25, 0, 0, 25);
            this.gunaPanelMatch.Name = "gunaPanelMatch";
            this.gunaPanelMatch.Size = new System.Drawing.Size(1220, 238);
            this.gunaPanelMatch.TabIndex = 1;
            this.gunaPanelMatch.Click += new System.EventHandler(this.pictureBoxVs_Click);
            // 
            // btnDeleteMatch
            // 
            this.btnDeleteMatch.Image = global::FootballTicketsSystem.Properties.Resources.trash;
            this.btnDeleteMatch.ImageRotate = 0F;
            this.btnDeleteMatch.Location = new System.Drawing.Point(1144, 20);
            this.btnDeleteMatch.Name = "btnDeleteMatch";
            this.btnDeleteMatch.Size = new System.Drawing.Size(38, 27);
            this.btnDeleteMatch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDeleteMatch.TabIndex = 36;
            this.btnDeleteMatch.TabStop = false;
            this.btnDeleteMatch.Visible = false;
            this.btnDeleteMatch.Click += new System.EventHandler(this.btnDeleteMatch_Click);
            // 
            // MatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gunaPanelMatch);
            this.Margin = new System.Windows.Forms.Padding(25, 3, 3, 25);
            this.Name = "MatchControl";
            this.Size = new System.Drawing.Size(1220, 238);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoFirstTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeamLogoAway)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).EndInit();
            this.gunaPanelMatch.ResumeLayout(false);
            this.gunaPanelMatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteMatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTeamNameFirst;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureBoxVs;
        private Guna.UI2.WinForms.Guna2PictureBox pictureBoxLogoFirstTeam;
        private Guna.UI2.WinForms.Guna2PictureBox pictureBoxTeamLogoAway;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox2;
        private System.Windows.Forms.Label labelDataMatch;
        private System.Windows.Forms.Label labelTeamNameSecond;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox3;
        private System.Windows.Forms.Label labelTimeMatch;
        private System.Windows.Forms.Label labelStadiumName;
        private Guna.UI2.WinForms.Guna2Button btnBuyTicket;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.Label labelScore;
        private Guna.UI2.WinForms.Guna2Panel gunaPanelMatch;
        private Guna.UI2.WinForms.Guna2PictureBox btnDeleteMatch;
    }
}
