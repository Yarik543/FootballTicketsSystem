namespace FootballTicketsSystem.AppControls
{
    partial class TeamsTournamentControl
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
            this.gunaPanelControl = new Guna.UI2.WinForms.Guna2Panel();
            this.labelCityName = new System.Windows.Forms.Label();
            this.btnDetails = new Guna.UI2.WinForms.Guna2Button();
            this.labelStadiumTeam = new System.Windows.Forms.Label();
            this.labelTeamName = new System.Windows.Forms.Label();
            this.gunaPictureBoxLogoTeam = new Guna.UI2.WinForms.Guna2PictureBox();
            this.gunaPanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBoxLogoTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaPanelControl
            // 
            this.gunaPanelControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(233)))), ((int)(((byte)(234)))));
            this.gunaPanelControl.BorderColor = System.Drawing.Color.White;
            this.gunaPanelControl.BorderRadius = 10;
            this.gunaPanelControl.BorderThickness = 2;
            this.gunaPanelControl.Controls.Add(this.labelCityName);
            this.gunaPanelControl.Controls.Add(this.btnDetails);
            this.gunaPanelControl.Controls.Add(this.labelStadiumTeam);
            this.gunaPanelControl.Controls.Add(this.labelTeamName);
            this.gunaPanelControl.Controls.Add(this.gunaPictureBoxLogoTeam);
            this.gunaPanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaPanelControl.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaPanelControl.Location = new System.Drawing.Point(0, 0);
            this.gunaPanelControl.Name = "gunaPanelControl";
            this.gunaPanelControl.Size = new System.Drawing.Size(610, 204);
            this.gunaPanelControl.TabIndex = 0;
            // 
            // labelCityName
            // 
            this.labelCityName.AutoSize = true;
            this.labelCityName.Location = new System.Drawing.Point(246, 56);
            this.labelCityName.Name = "labelCityName";
            this.labelCityName.Size = new System.Drawing.Size(55, 24);
            this.labelCityName.TabIndex = 4;
            this.labelCityName.Text = "label1";
            // 
            // btnDetails
            // 
            this.btnDetails.BorderColor = System.Drawing.Color.White;
            this.btnDetails.BorderRadius = 5;
            this.btnDetails.BorderThickness = 2;
            this.btnDetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDetails.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.btnDetails.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Location = new System.Drawing.Point(239, 137);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(254, 45);
            this.btnDetails.TabIndex = 3;
            this.btnDetails.Text = "Подробнее";
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // labelStadiumTeam
            // 
            this.labelStadiumTeam.AutoSize = true;
            this.labelStadiumTeam.Location = new System.Drawing.Point(246, 93);
            this.labelStadiumTeam.Name = "labelStadiumTeam";
            this.labelStadiumTeam.Size = new System.Drawing.Size(55, 24);
            this.labelStadiumTeam.TabIndex = 2;
            this.labelStadiumTeam.Text = "label1";
            // 
            // labelTeamName
            // 
            this.labelTeamName.AutoSize = true;
            this.labelTeamName.Location = new System.Drawing.Point(246, 20);
            this.labelTeamName.Name = "labelTeamName";
            this.labelTeamName.Size = new System.Drawing.Size(55, 24);
            this.labelTeamName.TabIndex = 1;
            this.labelTeamName.Text = "label1";
            // 
            // gunaPictureBoxLogoTeam
            // 
            this.gunaPictureBoxLogoTeam.BackColor = System.Drawing.Color.Transparent;
            this.gunaPictureBoxLogoTeam.BorderRadius = 8;
            this.gunaPictureBoxLogoTeam.ImageRotate = 0F;
            this.gunaPictureBoxLogoTeam.Location = new System.Drawing.Point(24, 20);
            this.gunaPictureBoxLogoTeam.Name = "gunaPictureBoxLogoTeam";
            this.gunaPictureBoxLogoTeam.Size = new System.Drawing.Size(191, 162);
            this.gunaPictureBoxLogoTeam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBoxLogoTeam.TabIndex = 0;
            this.gunaPictureBoxLogoTeam.TabStop = false;
            // 
            // TeamsTournamentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gunaPanelControl);
            this.Margin = new System.Windows.Forms.Padding(25, 3, 3, 25);
            this.Name = "TeamsTournamentControl";
            this.Size = new System.Drawing.Size(610, 204);
            this.gunaPanelControl.ResumeLayout(false);
            this.gunaPanelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBoxLogoTeam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel gunaPanelControl;
        private Guna.UI2.WinForms.Guna2PictureBox gunaPictureBoxLogoTeam;
        private System.Windows.Forms.Label labelTeamName;
        private System.Windows.Forms.Label labelStadiumTeam;
        private Guna.UI2.WinForms.Guna2Button btnDetails;
        private System.Windows.Forms.Label labelCityName;
    }
}
