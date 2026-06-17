namespace FootballTicketsSystem.AppControls
{
    partial class TableTeamsControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelNumberTable = new System.Windows.Forms.Label();
            this.pictureBoxLogoTeam = new System.Windows.Forms.PictureBox();
            this.labelTeamName = new System.Windows.Forms.Label();
            this.labelGamesCount = new System.Windows.Forms.Label();
            this.labelWinCount = new System.Windows.Forms.Label();
            this.labelDrawCount = new System.Windows.Forms.Label();
            this.labelLostCount = new System.Windows.Forms.Label();
            this.labelGoalsCount = new System.Windows.Forms.Label();
            this.labelPointsCoint = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 9;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(437, 55);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelNumberTable
            // 
            this.labelNumberTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNumberTable.Font = new System.Drawing.Font("Inter", 8F);
            this.labelNumberTable.Location = new System.Drawing.Point(13, 11);
            this.labelNumberTable.Name = "labelNumberTable";
            this.labelNumberTable.Size = new System.Drawing.Size(29, 36);
            this.labelNumberTable.TabIndex = 0;
            this.labelNumberTable.Text = "1";
            this.labelNumberTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxLogoTeam
            // 
            this.pictureBoxLogoTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLogoTeam.Location = new System.Drawing.Point(48, 11);
            this.pictureBoxLogoTeam.Name = "pictureBoxLogoTeam";
            this.pictureBoxLogoTeam.Size = new System.Drawing.Size(39, 36);
            this.pictureBoxLogoTeam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogoTeam.TabIndex = 1;
            this.pictureBoxLogoTeam.TabStop = false;
            // 
            // labelTeamName
            // 
            this.labelTeamName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTeamName.Font = new System.Drawing.Font("Inter", 8F);
            this.labelTeamName.Location = new System.Drawing.Point(93, 11);
            this.labelTeamName.Name = "labelTeamName";
            this.labelTeamName.Size = new System.Drawing.Size(100, 36);
            this.labelTeamName.TabIndex = 2;
            this.labelTeamName.Text = "FC Barcelona";
            this.labelTeamName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGamesCount
            // 
            this.labelGamesCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGamesCount.Font = new System.Drawing.Font("Inter", 8F);
            this.labelGamesCount.Location = new System.Drawing.Point(199, 11);
            this.labelGamesCount.Name = "labelGamesCount";
            this.labelGamesCount.Size = new System.Drawing.Size(29, 36);
            this.labelGamesCount.TabIndex = 3;
            this.labelGamesCount.Text = "И";
            this.labelGamesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWinCount
            // 
            this.labelWinCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWinCount.Font = new System.Drawing.Font("Inter", 8F);
            this.labelWinCount.Location = new System.Drawing.Point(234, 11);
            this.labelWinCount.Name = "labelWinCount";
            this.labelWinCount.Size = new System.Drawing.Size(24, 36);
            this.labelWinCount.TabIndex = 4;
            this.labelWinCount.Text = "В";
            this.labelWinCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDrawCount
            // 
            this.labelDrawCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDrawCount.Font = new System.Drawing.Font("Inter", 8F);
            this.labelDrawCount.Location = new System.Drawing.Point(264, 11);
            this.labelDrawCount.Name = "labelDrawCount";
            this.labelDrawCount.Size = new System.Drawing.Size(24, 36);
            this.labelDrawCount.TabIndex = 5;
            this.labelDrawCount.Text = "Н";
            this.labelDrawCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLostCount
            // 
            this.labelLostCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLostCount.Font = new System.Drawing.Font("Inter", 8F);
            this.labelLostCount.Location = new System.Drawing.Point(294, 11);
            this.labelLostCount.Name = "labelLostCount";
            this.labelLostCount.Size = new System.Drawing.Size(24, 36);
            this.labelLostCount.TabIndex = 6;
            this.labelLostCount.Text = "П";
            this.labelLostCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGoalsCount
            // 
            this.labelGoalsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGoalsCount.Font = new System.Drawing.Font("Inter", 8F);
            this.labelGoalsCount.Location = new System.Drawing.Point(324, 11);
            this.labelGoalsCount.Name = "labelGoalsCount";
            this.labelGoalsCount.Size = new System.Drawing.Size(29, 36);
            this.labelGoalsCount.TabIndex = 7;
            this.labelGoalsCount.Text = "Г";
            this.labelGoalsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPointsCoint
            // 
            this.labelPointsCoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPointsCoint.Font = new System.Drawing.Font("Inter", 8F, System.Drawing.FontStyle.Bold);
            this.labelPointsCoint.Location = new System.Drawing.Point(359, 11);
            this.labelPointsCoint.Name = "labelPointsCoint";
            this.labelPointsCoint.Size = new System.Drawing.Size(44, 36);
            this.labelPointsCoint.TabIndex = 8;
            this.labelPointsCoint.Text = "ОЧКИ";
            this.labelPointsCoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.White;
            this.guna2Separator1.Location = new System.Drawing.Point(10, 50);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(417, 5);
            this.guna2Separator1.TabIndex = 9;
            // 
            // TableTeamsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(233)))), ((int)(((byte)(234)))));
            this.Controls.Add(this.tableLayoutPanelMain);
            this.MinimumSize = new System.Drawing.Size(0, 55);
            this.Name = "TableTeamsControl";
            this.Size = new System.Drawing.Size(437, 55);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoTeam)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label labelNumberTable;
        private System.Windows.Forms.PictureBox pictureBoxLogoTeam;
        private System.Windows.Forms.Label labelTeamName;
        private System.Windows.Forms.Label labelGamesCount;
        private System.Windows.Forms.Label labelWinCount;
        private System.Windows.Forms.Label labelDrawCount;
        private System.Windows.Forms.Label labelLostCount;
        private System.Windows.Forms.Label labelGoalsCount;
        private System.Windows.Forms.Label labelPointsCoint;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
    }
}