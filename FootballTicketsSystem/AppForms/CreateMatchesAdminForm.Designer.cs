namespace FootballTicketsSystem.AppForms
{
    partial class CreateMatchesAdminForm
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
            System.Windows.Forms.Label teamHomeIdLabel;
            System.Windows.Forms.Label teamAwayIdLabel;
            System.Windows.Forms.Label matchDateLabel;
            System.Windows.Forms.Label stadiumIdLabel;
            System.Windows.Forms.Label ratingMatchLabel;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateMatchesAdminForm));
            this.label1 = new System.Windows.Forms.Label();
            this.panelMatchStatistic = new Guna.UI2.WinForms.Guna2Panel();
            this.labelTicketsBuy = new System.Windows.Forms.Label();
            this.labelActivMatches = new System.Windows.Forms.Label();
            this.labelCountMatches = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.footballTicketSystemDataSet = new FootballTicketsSystem.FootballTicketSystemDataSet();
            this.matchesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.matchesTableAdapter = new FootballTicketsSystem.FootballTicketSystemDataSetTableAdapters.MatchesTableAdapter();
            this.tableAdapterManager = new FootballTicketsSystem.FootballTicketSystemDataSetTableAdapters.TableAdapterManager();
            this.dateTimePickerMatch = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.comboBoxTeamHome = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboBoxTeamAway = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboBoxStadium = new Guna.UI2.WinForms.Guna2ComboBox();
            this.numericUpDownRating = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnTransfers = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnCalendar = new Guna.UI2.WinForms.Guna2Button();
            this.btnProfil = new Guna.UI2.WinForms.Guna2Button();
            this.btnTickets = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveMatch = new Guna.UI2.WinForms.Guna2Button();
            this.btnCloseBack = new Guna.UI2.WinForms.Guna2Button();
            this.pictureProfil = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.labelUserRole = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.numericUpDownScoreAway = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numericUpDownScoreHome = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.comboBoxStage = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelScoreTeamHome = new System.Windows.Forms.Label();
            this.labelScoreTeamAway = new System.Windows.Forms.Label();
            teamHomeIdLabel = new System.Windows.Forms.Label();
            teamAwayIdLabel = new System.Windows.Forms.Label();
            matchDateLabel = new System.Windows.Forms.Label();
            stadiumIdLabel = new System.Windows.Forms.Label();
            ratingMatchLabel = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.panelMatchStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.footballTicketSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScoreAway)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScoreHome)).BeginInit();
            this.SuspendLayout();
            // 
            // teamHomeIdLabel
            // 
            teamHomeIdLabel.AutoSize = true;
            teamHomeIdLabel.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            teamHomeIdLabel.Location = new System.Drawing.Point(507, 236);
            teamHomeIdLabel.Name = "teamHomeIdLabel";
            teamHomeIdLabel.Size = new System.Drawing.Size(96, 24);
            teamHomeIdLabel.TabIndex = 31;
            teamHomeIdLabel.Text = "Команда 1";
            // 
            // teamAwayIdLabel
            // 
            teamAwayIdLabel.AutoSize = true;
            teamAwayIdLabel.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            teamAwayIdLabel.Location = new System.Drawing.Point(507, 285);
            teamAwayIdLabel.Name = "teamAwayIdLabel";
            teamAwayIdLabel.Size = new System.Drawing.Size(99, 24);
            teamAwayIdLabel.TabIndex = 33;
            teamAwayIdLabel.Text = "Команда 2";
            // 
            // matchDateLabel
            // 
            matchDateLabel.AutoSize = true;
            matchDateLabel.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            matchDateLabel.Location = new System.Drawing.Point(507, 335);
            matchDateLabel.Name = "matchDateLabel";
            matchDateLabel.Size = new System.Drawing.Size(124, 24);
            matchDateLabel.TabIndex = 35;
            matchDateLabel.Text = "Дата и время";
            // 
            // stadiumIdLabel
            // 
            stadiumIdLabel.AutoSize = true;
            stadiumIdLabel.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            stadiumIdLabel.Location = new System.Drawing.Point(507, 387);
            stadiumIdLabel.Name = "stadiumIdLabel";
            stadiumIdLabel.Size = new System.Drawing.Size(80, 24);
            stadiumIdLabel.TabIndex = 37;
            stadiumIdLabel.Text = "Стадион";
            // 
            // ratingMatchLabel
            // 
            ratingMatchLabel.AutoSize = true;
            ratingMatchLabel.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ratingMatchLabel.Location = new System.Drawing.Point(507, 436);
            ratingMatchLabel.Name = "ratingMatchLabel";
            ratingMatchLabel.Size = new System.Drawing.Size(128, 24);
            ratingMatchLabel.TabIndex = 39;
            ratingMatchLabel.Text = "Оценка матча";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label5.Location = new System.Drawing.Point(507, 487);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(106, 24);
            label5.TabIndex = 57;
            label5.Text = "Этап матча";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(304, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(499, 39);
            this.label1.TabIndex = 29;
            this.label1.Text = "Добавление/редактирование матча";
            // 
            // panelMatchStatistic
            // 
            this.panelMatchStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMatchStatistic.BackColor = System.Drawing.Color.Transparent;
            this.panelMatchStatistic.BorderColor = System.Drawing.Color.White;
            this.panelMatchStatistic.BorderRadius = 10;
            this.panelMatchStatistic.BorderThickness = 2;
            this.panelMatchStatistic.Controls.Add(this.labelTicketsBuy);
            this.panelMatchStatistic.Controls.Add(this.labelActivMatches);
            this.panelMatchStatistic.Controls.Add(this.labelCountMatches);
            this.panelMatchStatistic.Controls.Add(this.label4);
            this.panelMatchStatistic.Controls.Add(this.label3);
            this.panelMatchStatistic.Controls.Add(this.label2);
            this.panelMatchStatistic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(233)))), ((int)(((byte)(234)))));
            this.panelMatchStatistic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.panelMatchStatistic.Location = new System.Drawing.Point(311, 598);
            this.panelMatchStatistic.Name = "panelMatchStatistic";
            this.panelMatchStatistic.Size = new System.Drawing.Size(860, 178);
            this.panelMatchStatistic.TabIndex = 30;
            // 
            // labelTicketsBuy
            // 
            this.labelTicketsBuy.AutoSize = true;
            this.labelTicketsBuy.Font = new System.Drawing.Font("Inter SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTicketsBuy.Location = new System.Drawing.Point(720, 80);
            this.labelTicketsBuy.Name = "labelTicketsBuy";
            this.labelTicketsBuy.Size = new System.Drawing.Size(68, 28);
            this.labelTicketsBuy.TabIndex = 5;
            this.labelTicketsBuy.Text = "5 680";
            // 
            // labelActivMatches
            // 
            this.labelActivMatches.AutoSize = true;
            this.labelActivMatches.Font = new System.Drawing.Font("Inter SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelActivMatches.Location = new System.Drawing.Point(466, 78);
            this.labelActivMatches.Name = "labelActivMatches";
            this.labelActivMatches.Size = new System.Drawing.Size(32, 28);
            this.labelActivMatches.TabIndex = 4;
            this.labelActivMatches.Text = "12";
            // 
            // labelCountMatches
            // 
            this.labelCountMatches.AutoSize = true;
            this.labelCountMatches.Font = new System.Drawing.Font("Inter SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountMatches.Location = new System.Drawing.Point(176, 80);
            this.labelCountMatches.Name = "labelCountMatches";
            this.labelCountMatches.Size = new System.Drawing.Size(38, 28);
            this.labelCountMatches.TabIndex = 3;
            this.labelCountMatches.Text = "30";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Inter", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(543, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "Продано билетов:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(300, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Активные матчи:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(35, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Всего матчей:";
            // 
            // footballTicketSystemDataSet
            // 
            this.footballTicketSystemDataSet.DataSetName = "FootballTicketSystemDataSet";
            this.footballTicketSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // matchesBindingSource
            // 
            this.matchesBindingSource.DataMember = "Matches";
            this.matchesBindingSource.DataSource = this.footballTicketSystemDataSet;
            // 
            // matchesTableAdapter
            // 
            this.matchesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CoachesTableAdapter = null;
            this.tableAdapterManager.MatchesTableAdapter = this.matchesTableAdapter;
            this.tableAdapterManager.PlayersTableAdapter = null;
            this.tableAdapterManager.RolesTableAdapter = null;
            this.tableAdapterManager.StadiumsTableAdapter = null;
            this.tableAdapterManager.TeamsTableAdapter = null;
            this.tableAdapterManager.TicketsTableAdapter = null;
            this.tableAdapterManager.TransfersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = FootballTicketsSystem.FootballTicketSystemDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            this.tableAdapterManager.UserTicketsTableAdapter = null;
            // 
            // dateTimePickerMatch
            // 
            this.dateTimePickerMatch.BackColor = System.Drawing.Color.White;
            this.dateTimePickerMatch.Checked = true;
            this.dateTimePickerMatch.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePickerMatch.FillColor = System.Drawing.Color.White;
            this.dateTimePickerMatch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerMatch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMatch.Location = new System.Drawing.Point(667, 330);
            this.dateTimePickerMatch.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerMatch.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerMatch.Name = "dateTimePickerMatch";
            this.dateTimePickerMatch.ShowUpDown = true;
            this.dateTimePickerMatch.Size = new System.Drawing.Size(265, 36);
            this.dateTimePickerMatch.TabIndex = 41;
            this.dateTimePickerMatch.Value = new System.DateTime(2026, 4, 16, 10, 58, 18, 749);
            this.dateTimePickerMatch.ValueChanged += new System.EventHandler(this.dateTimePickerMatch_ValueChanged);
            // 
            // comboBoxTeamHome
            // 
            this.comboBoxTeamHome.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxTeamHome.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxTeamHome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeamHome.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTeamHome.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTeamHome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxTeamHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxTeamHome.ItemHeight = 30;
            this.comboBoxTeamHome.Location = new System.Drawing.Point(667, 231);
            this.comboBoxTeamHome.Name = "comboBoxTeamHome";
            this.comboBoxTeamHome.Size = new System.Drawing.Size(265, 36);
            this.comboBoxTeamHome.TabIndex = 42;
            this.comboBoxTeamHome.SelectedIndexChanged += new System.EventHandler(this.comboBoxTeamHome_SelectedIndexChanged);
            // 
            // comboBoxTeamAway
            // 
            this.comboBoxTeamAway.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxTeamAway.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxTeamAway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeamAway.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTeamAway.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTeamAway.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxTeamAway.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxTeamAway.ItemHeight = 30;
            this.comboBoxTeamAway.Location = new System.Drawing.Point(667, 279);
            this.comboBoxTeamAway.Name = "comboBoxTeamAway";
            this.comboBoxTeamAway.Size = new System.Drawing.Size(265, 36);
            this.comboBoxTeamAway.TabIndex = 43;
            this.comboBoxTeamAway.SelectedIndexChanged += new System.EventHandler(this.comboBoxTeamAway_SelectedIndexChanged);
            // 
            // comboBoxStadium
            // 
            this.comboBoxStadium.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxStadium.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxStadium.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStadium.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxStadium.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxStadium.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxStadium.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxStadium.ItemHeight = 30;
            this.comboBoxStadium.Location = new System.Drawing.Point(667, 380);
            this.comboBoxStadium.Name = "comboBoxStadium";
            this.comboBoxStadium.Size = new System.Drawing.Size(265, 36);
            this.comboBoxStadium.TabIndex = 44;
            // 
            // numericUpDownRating
            // 
            this.numericUpDownRating.BackColor = System.Drawing.Color.Transparent;
            this.numericUpDownRating.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericUpDownRating.DecimalPlaces = 2;
            this.numericUpDownRating.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numericUpDownRating.Location = new System.Drawing.Point(667, 430);
            this.numericUpDownRating.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownRating.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRating.Name = "numericUpDownRating";
            this.numericUpDownRating.Size = new System.Drawing.Size(265, 37);
            this.numericUpDownRating.TabIndex = 45;
            this.numericUpDownRating.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.numericUpDownRating.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Controls.Add(this.btnExit);
            this.guna2Panel1.Controls.Add(this.btnTransfers);
            this.guna2Panel1.Controls.Add(this.guna2Separator1);
            this.guna2Panel1.Controls.Add(this.btnCalendar);
            this.guna2Panel1.Controls.Add(this.btnProfil);
            this.guna2Panel1.Controls.Add(this.btnTickets);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Controls.Add(this.btnMain);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(284, 810);
            this.guna2Panel1.TabIndex = 46;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.guna2Button1.Image = global::FootballTicketsSystem.Properties.Resources.teams;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.Location = new System.Drawing.Point(29, 309);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Padding = new System.Windows.Forms.Padding(10, 10, 60, 10);
            this.guna2Button1.Size = new System.Drawing.Size(226, 49);
            this.guna2Button1.TabIndex = 14;
            this.guna2Button1.Text = "Команды";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BorderRadius = 5;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.btnExit.Image = global::FootballTicketsSystem.Properties.Resources.exit_black;
            this.btnExit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExit.Location = new System.Drawing.Point(29, 728);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(10, 10, 60, 10);
            this.btnExit.Size = new System.Drawing.Size(226, 48);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Выйти";
            this.btnExit.TextOffset = new System.Drawing.Point(-10, 0);
            // 
            // btnTransfers
            // 
            this.btnTransfers.BackColor = System.Drawing.Color.Transparent;
            this.btnTransfers.BorderRadius = 5;
            this.btnTransfers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTransfers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTransfers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTransfers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTransfers.FillColor = System.Drawing.Color.Transparent;
            this.btnTransfers.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTransfers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.btnTransfers.Image = global::FootballTicketsSystem.Properties.Resources.transfer_black;
            this.btnTransfers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTransfers.Location = new System.Drawing.Point(29, 655);
            this.btnTransfers.Name = "btnTransfers";
            this.btnTransfers.Padding = new System.Windows.Forms.Padding(10, 10, 60, 10);
            this.btnTransfers.Size = new System.Drawing.Size(226, 49);
            this.btnTransfers.TabIndex = 12;
            this.btnTransfers.Text = "Трансферы";
            this.btnTransfers.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(29, 614);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(225, 10);
            this.guna2Separator1.TabIndex = 7;
            // 
            // btnCalendar
            // 
            this.btnCalendar.BackColor = System.Drawing.Color.Transparent;
            this.btnCalendar.BorderRadius = 5;
            this.btnCalendar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCalendar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCalendar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCalendar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCalendar.FillColor = System.Drawing.Color.Transparent;
            this.btnCalendar.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCalendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.btnCalendar.Image = global::FootballTicketsSystem.Properties.Resources.calendar_black;
            this.btnCalendar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCalendar.Location = new System.Drawing.Point(28, 538);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Padding = new System.Windows.Forms.Padding(10, 10, 60, 10);
            this.btnCalendar.Size = new System.Drawing.Size(226, 49);
            this.btnCalendar.TabIndex = 11;
            this.btnCalendar.Text = "Календарь";
            this.btnCalendar.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // btnProfil
            // 
            this.btnProfil.BackColor = System.Drawing.Color.Transparent;
            this.btnProfil.BorderRadius = 5;
            this.btnProfil.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProfil.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProfil.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProfil.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProfil.FillColor = System.Drawing.Color.Transparent;
            this.btnProfil.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnProfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.btnProfil.Image = global::FootballTicketsSystem.Properties.Resources.profil_black;
            this.btnProfil.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProfil.Location = new System.Drawing.Point(28, 462);
            this.btnProfil.Name = "btnProfil";
            this.btnProfil.Padding = new System.Windows.Forms.Padding(10, 10, 60, 10);
            this.btnProfil.Size = new System.Drawing.Size(226, 49);
            this.btnProfil.TabIndex = 10;
            this.btnProfil.Text = "Профиль";
            // 
            // btnTickets
            // 
            this.btnTickets.BackColor = System.Drawing.Color.Transparent;
            this.btnTickets.BorderColor = System.Drawing.Color.White;
            this.btnTickets.BorderRadius = 5;
            this.btnTickets.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTickets.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTickets.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTickets.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTickets.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.btnTickets.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTickets.ForeColor = System.Drawing.Color.White;
            this.btnTickets.Image = global::FootballTicketsSystem.Properties.Resources.tickets_white;
            this.btnTickets.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTickets.Location = new System.Drawing.Point(28, 385);
            this.btnTickets.Name = "btnTickets";
            this.btnTickets.Padding = new System.Windows.Forms.Padding(10, 10, 60, 10);
            this.btnTickets.Size = new System.Drawing.Size(226, 49);
            this.btnTickets.TabIndex = 9;
            this.btnTickets.Text = "Мои билеты";
            this.btnTickets.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::FootballTicketsSystem.Properties.Resources.logo_green;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(54, 28);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(175, 175);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnMain
            // 
            this.btnMain.BorderColor = System.Drawing.Color.Transparent;
            this.btnMain.BorderRadius = 5;
            this.btnMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMain.FillColor = System.Drawing.Color.Transparent;
            this.btnMain.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.btnMain.Image = global::FootballTicketsSystem.Properties.Resources.main_component_black;
            this.btnMain.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMain.Location = new System.Drawing.Point(28, 236);
            this.btnMain.Name = "btnMain";
            this.btnMain.Padding = new System.Windows.Forms.Padding(10, 10, 60, 10);
            this.btnMain.Size = new System.Drawing.Size(226, 49);
            this.btnMain.TabIndex = 7;
            this.btnMain.Text = "Главная";
            // 
            // btnSaveMatch
            // 
            this.btnSaveMatch.BorderColor = System.Drawing.Color.White;
            this.btnSaveMatch.BorderRadius = 5;
            this.btnSaveMatch.BorderThickness = 1;
            this.btnSaveMatch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveMatch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveMatch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveMatch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveMatch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.btnSaveMatch.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveMatch.ForeColor = System.Drawing.Color.White;
            this.btnSaveMatch.Location = new System.Drawing.Point(511, 528);
            this.btnSaveMatch.Name = "btnSaveMatch";
            this.btnSaveMatch.Size = new System.Drawing.Size(421, 47);
            this.btnSaveMatch.TabIndex = 49;
            this.btnSaveMatch.Text = "Сохранить";
            this.btnSaveMatch.Click += new System.EventHandler(this.btnSaveMatch_Click);
            // 
            // btnCloseBack
            // 
            this.btnCloseBack.BorderColor = System.Drawing.Color.White;
            this.btnCloseBack.BorderRadius = 5;
            this.btnCloseBack.BorderThickness = 1;
            this.btnCloseBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCloseBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCloseBack.FillColor = System.Drawing.Color.CadetBlue;
            this.btnCloseBack.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Bold);
            this.btnCloseBack.ForeColor = System.Drawing.Color.White;
            this.btnCloseBack.Location = new System.Drawing.Point(311, 102);
            this.btnCloseBack.Name = "btnCloseBack";
            this.btnCloseBack.Size = new System.Drawing.Size(171, 44);
            this.btnCloseBack.TabIndex = 50;
            this.btnCloseBack.Text = "Назад";
            this.btnCloseBack.Click += new System.EventHandler(this.btnCloseBack_Click);
            // 
            // pictureProfil
            // 
            this.pictureProfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureProfil.BackColor = System.Drawing.Color.Transparent;
            this.pictureProfil.ImageRotate = 0F;
            this.pictureProfil.Location = new System.Drawing.Point(911, 44);
            this.pictureProfil.Name = "pictureProfil";
            this.pictureProfil.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureProfil.Size = new System.Drawing.Size(75, 75);
            this.pictureProfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureProfil.TabIndex = 28;
            this.pictureProfil.TabStop = false;
            // 
            // labelUserRole
            // 
            this.labelUserRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserRole.AutoSize = true;
            this.labelUserRole.BackColor = System.Drawing.Color.Transparent;
            this.labelUserRole.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserRole.ForeColor = System.Drawing.Color.Black;
            this.labelUserRole.Location = new System.Drawing.Point(992, 48);
            this.labelUserRole.Name = "labelUserRole";
            this.labelUserRole.Size = new System.Drawing.Size(83, 24);
            this.labelUserRole.TabIndex = 52;
            this.labelUserRole.Text = "UserRole";
            // 
            // labelUserName
            // 
            this.labelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserName.BackColor = System.Drawing.Color.Transparent;
            this.labelUserName.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserName.ForeColor = System.Drawing.Color.Black;
            this.labelUserName.Location = new System.Drawing.Point(992, 87);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(194, 66);
            this.labelUserName.TabIndex = 51;
            this.labelUserName.Text = "UserName";
            // 
            // numericUpDownScoreAway
            // 
            this.numericUpDownScoreAway.BackColor = System.Drawing.Color.Transparent;
            this.numericUpDownScoreAway.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericUpDownScoreAway.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numericUpDownScoreAway.Location = new System.Drawing.Point(667, 193);
            this.numericUpDownScoreAway.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownScoreAway.Name = "numericUpDownScoreAway";
            this.numericUpDownScoreAway.Size = new System.Drawing.Size(265, 24);
            this.numericUpDownScoreAway.TabIndex = 55;
            this.numericUpDownScoreAway.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.numericUpDownScoreAway.UpDownButtonForeColor = System.Drawing.Color.White;
            this.numericUpDownScoreAway.Visible = false;
            // 
            // numericUpDownScoreHome
            // 
            this.numericUpDownScoreHome.BackColor = System.Drawing.Color.Transparent;
            this.numericUpDownScoreHome.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericUpDownScoreHome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numericUpDownScoreHome.Location = new System.Drawing.Point(667, 161);
            this.numericUpDownScoreHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownScoreHome.Name = "numericUpDownScoreHome";
            this.numericUpDownScoreHome.Size = new System.Drawing.Size(265, 24);
            this.numericUpDownScoreHome.TabIndex = 56;
            this.numericUpDownScoreHome.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.numericUpDownScoreHome.UpDownButtonForeColor = System.Drawing.Color.White;
            this.numericUpDownScoreHome.Visible = false;
            // 
            // comboBoxStage
            // 
            this.comboBoxStage.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxStage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStage.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxStage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxStage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxStage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxStage.ItemHeight = 30;
            this.comboBoxStage.Items.AddRange(new object[] {
            "Чемпионат",
            "Групповой этап",
            "1/8 финала",
            "1/4 финала",
            "1/2 финала",
            "Финал",
            "Матч за 3-е место",
            "Плей-офф",
            "Квалификация",
            "Товарищеский матч"});
            this.comboBoxStage.Location = new System.Drawing.Point(667, 478);
            this.comboBoxStage.Name = "comboBoxStage";
            this.comboBoxStage.Size = new System.Drawing.Size(265, 36);
            this.comboBoxStage.TabIndex = 58;
            // 
            // labelScoreTeamHome
            // 
            this.labelScoreTeamHome.AutoSize = true;
            this.labelScoreTeamHome.Font = new System.Drawing.Font("Inter", 10F);
            this.labelScoreTeamHome.Location = new System.Drawing.Point(507, 161);
            this.labelScoreTeamHome.Name = "labelScoreTeamHome";
            this.labelScoreTeamHome.Size = new System.Drawing.Size(142, 24);
            this.labelScoreTeamHome.TabIndex = 61;
            this.labelScoreTeamHome.Text = "Счет команды 1";
            this.labelScoreTeamHome.Visible = false;
            // 
            // labelScoreTeamAway
            // 
            this.labelScoreTeamAway.AutoSize = true;
            this.labelScoreTeamAway.Font = new System.Drawing.Font("Inter", 10F);
            this.labelScoreTeamAway.Location = new System.Drawing.Point(507, 193);
            this.labelScoreTeamAway.Name = "labelScoreTeamAway";
            this.labelScoreTeamAway.Size = new System.Drawing.Size(145, 24);
            this.labelScoreTeamAway.TabIndex = 62;
            this.labelScoreTeamAway.Text = "Счет команды 2";
            this.labelScoreTeamAway.Visible = false;
            // 
            // CreateMatchesAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 810);
            this.Controls.Add(this.labelScoreTeamAway);
            this.Controls.Add(this.labelScoreTeamHome);
            this.Controls.Add(this.comboBoxStage);
            this.Controls.Add(label5);
            this.Controls.Add(this.numericUpDownScoreHome);
            this.Controls.Add(this.numericUpDownScoreAway);
            this.Controls.Add(this.labelUserRole);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.btnCloseBack);
            this.Controls.Add(this.btnSaveMatch);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.numericUpDownRating);
            this.Controls.Add(this.comboBoxStadium);
            this.Controls.Add(this.comboBoxTeamAway);
            this.Controls.Add(this.comboBoxTeamHome);
            this.Controls.Add(this.dateTimePickerMatch);
            this.Controls.Add(teamHomeIdLabel);
            this.Controls.Add(teamAwayIdLabel);
            this.Controls.Add(matchDateLabel);
            this.Controls.Add(stadiumIdLabel);
            this.Controls.Add(ratingMatchLabel);
            this.Controls.Add(this.panelMatchStatistic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureProfil);
            this.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateMatchesAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление | редактирование матча";
            this.Load += new System.EventHandler(this.CreateMatchesAdminForm_Load);
            this.panelMatchStatistic.ResumeLayout(false);
            this.panelMatchStatistic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.footballTicketSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScoreAway)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScoreHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureProfil;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel panelMatchStatistic;
        private FootballTicketSystemDataSet footballTicketSystemDataSet;
        private System.Windows.Forms.BindingSource matchesBindingSource;
        private FootballTicketSystemDataSetTableAdapters.MatchesTableAdapter matchesTableAdapter;
        private FootballTicketSystemDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerMatch;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxTeamHome;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxTeamAway;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxStadium;
        private Guna.UI2.WinForms.Guna2NumericUpDown numericUpDownRating;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Button btnTransfers;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Button btnCalendar;
        private Guna.UI2.WinForms.Guna2Button btnProfil;
        private Guna.UI2.WinForms.Guna2Button btnTickets;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnMain;
        private Guna.UI2.WinForms.Guna2Button btnSaveMatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCountMatches;
        private System.Windows.Forms.Label labelActivMatches;
        private System.Windows.Forms.Label labelTicketsBuy;
        private Guna.UI2.WinForms.Guna2Button btnCloseBack;
        private System.Windows.Forms.Label labelUserRole;
        private System.Windows.Forms.Label labelUserName;
        private Guna.UI2.WinForms.Guna2NumericUpDown numericUpDownScoreAway;
        private Guna.UI2.WinForms.Guna2NumericUpDown numericUpDownScoreHome;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxStage;
        private System.Windows.Forms.Label labelScoreTeamHome;
        private System.Windows.Forms.Label labelScoreTeamAway;
    }
}