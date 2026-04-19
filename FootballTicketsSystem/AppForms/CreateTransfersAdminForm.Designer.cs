namespace FootballTicketsSystem.AppForms
{
    partial class CreateTransfersAdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTransfersAdminForm));
            this.btnSaveTransfer = new Guna.UI2.WinForms.Guna2Button();
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
            this.priceTransferNumericUpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.teamNowComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.teamFromComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCloseBack = new Guna.UI2.WinForms.Guna2Button();
            this.labelUserRole = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.dateTimePickerTransfer = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.panelMatchStatistic = new Guna.UI2.WinForms.Guna2Panel();
            this.labelTeamNameMore = new System.Windows.Forms.Label();
            this.labelCountTransfers = new System.Windows.Forms.Label();
            this.labelTopPlayers = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureProfil = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.footballTicketSystemDataSet = new FootballTicketsSystem.FootballTicketSystemDataSet();
            this.matchesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager = new FootballTicketsSystem.FootballTicketSystemDataSetTableAdapters.TableAdapterManager();
            this.matchesTableAdapter = new FootballTicketsSystem.FootballTicketSystemDataSetTableAdapters.MatchesTableAdapter();
            this.transfersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transfersTableAdapter = new FootballTicketsSystem.FootballTicketSystemDataSetTableAdapters.TransfersTableAdapter();
            this.tBoxPlayerName = new Guna.UI2.WinForms.Guna2TextBox();
            teamHomeIdLabel = new System.Windows.Forms.Label();
            teamAwayIdLabel = new System.Windows.Forms.Label();
            matchDateLabel = new System.Windows.Forms.Label();
            stadiumIdLabel = new System.Windows.Forms.Label();
            ratingMatchLabel = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTransferNumericUpDown)).BeginInit();
            this.panelMatchStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.footballTicketSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transfersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // teamHomeIdLabel
            // 
            teamHomeIdLabel.AutoSize = true;
            teamHomeIdLabel.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            teamHomeIdLabel.Location = new System.Drawing.Point(564, 212);
            teamHomeIdLabel.Name = "teamHomeIdLabel";
            teamHomeIdLabel.Size = new System.Drawing.Size(59, 24);
            teamHomeIdLabel.TabIndex = 54;
            teamHomeIdLabel.Text = "Игрок";
            // 
            // teamAwayIdLabel
            // 
            teamAwayIdLabel.AutoSize = true;
            teamAwayIdLabel.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            teamAwayIdLabel.Location = new System.Drawing.Point(564, 261);
            teamAwayIdLabel.Name = "teamAwayIdLabel";
            teamAwayIdLabel.Size = new System.Drawing.Size(163, 24);
            teamAwayIdLabel.TabIndex = 55;
            teamAwayIdLabel.Text = "Прошлая команда";
            // 
            // matchDateLabel
            // 
            matchDateLabel.AutoSize = true;
            matchDateLabel.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            matchDateLabel.Location = new System.Drawing.Point(564, 361);
            matchDateLabel.Name = "matchDateLabel";
            matchDateLabel.Size = new System.Drawing.Size(124, 24);
            matchDateLabel.TabIndex = 56;
            matchDateLabel.Text = "Дата и время";
            // 
            // stadiumIdLabel
            // 
            stadiumIdLabel.AutoSize = true;
            stadiumIdLabel.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            stadiumIdLabel.Location = new System.Drawing.Point(564, 309);
            stadiumIdLabel.Name = "stadiumIdLabel";
            stadiumIdLabel.Size = new System.Drawing.Size(160, 24);
            stadiumIdLabel.TabIndex = 57;
            stadiumIdLabel.Text = "Текущая команда";
            // 
            // ratingMatchLabel
            // 
            ratingMatchLabel.AutoSize = true;
            ratingMatchLabel.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ratingMatchLabel.Location = new System.Drawing.Point(564, 412);
            ratingMatchLabel.Name = "ratingMatchLabel";
            ratingMatchLabel.Size = new System.Drawing.Size(147, 24);
            ratingMatchLabel.TabIndex = 58;
            ratingMatchLabel.Text = "Цена трансфера\r\n";
            // 
            // btnSaveTransfer
            // 
            this.btnSaveTransfer.BorderColor = System.Drawing.Color.White;
            this.btnSaveTransfer.BorderRadius = 5;
            this.btnSaveTransfer.BorderThickness = 1;
            this.btnSaveTransfer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveTransfer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveTransfer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveTransfer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveTransfer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.btnSaveTransfer.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveTransfer.ForeColor = System.Drawing.Color.White;
            this.btnSaveTransfer.Location = new System.Drawing.Point(568, 466);
            this.btnSaveTransfer.Name = "btnSaveTransfer";
            this.btnSaveTransfer.Size = new System.Drawing.Size(448, 47);
            this.btnSaveTransfer.TabIndex = 67;
            this.btnSaveTransfer.Text = "Сохранить";
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
            this.guna2Panel1.TabIndex = 64;
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
            this.btnTransfers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.btnTransfers.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTransfers.ForeColor = System.Drawing.Color.White;
            this.btnTransfers.Image = global::FootballTicketsSystem.Properties.Resources.transfers_white;
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
            this.btnTickets.FillColor = System.Drawing.Color.Transparent;
            this.btnTickets.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTickets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.btnTickets.Image = global::FootballTicketsSystem.Properties.Resources.tickets_black;
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
            // priceTransferNumericUpDown
            // 
            this.priceTransferNumericUpDown.BackColor = System.Drawing.Color.Transparent;
            this.priceTransferNumericUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.priceTransferNumericUpDown.DecimalPlaces = 2;
            this.priceTransferNumericUpDown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.priceTransferNumericUpDown.Location = new System.Drawing.Point(751, 405);
            this.priceTransferNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.priceTransferNumericUpDown.Name = "priceTransferNumericUpDown";
            this.priceTransferNumericUpDown.Size = new System.Drawing.Size(265, 37);
            this.priceTransferNumericUpDown.TabIndex = 63;
            this.priceTransferNumericUpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.priceTransferNumericUpDown.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // teamNowComboBox
            // 
            this.teamNowComboBox.BackColor = System.Drawing.Color.Transparent;
            this.teamNowComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.teamNowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamNowComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.teamNowComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.teamNowComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.teamNowComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.teamNowComboBox.ItemHeight = 30;
            this.teamNowComboBox.Location = new System.Drawing.Point(751, 303);
            this.teamNowComboBox.Name = "teamNowComboBox";
            this.teamNowComboBox.Size = new System.Drawing.Size(265, 36);
            this.teamNowComboBox.TabIndex = 62;
            // 
            // teamFromComboBox
            // 
            this.teamFromComboBox.BackColor = System.Drawing.Color.Transparent;
            this.teamFromComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.teamFromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamFromComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.teamFromComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.teamFromComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.teamFromComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.teamFromComboBox.ItemHeight = 30;
            this.teamFromComboBox.Location = new System.Drawing.Point(751, 254);
            this.teamFromComboBox.Name = "teamFromComboBox";
            this.teamFromComboBox.Size = new System.Drawing.Size(265, 36);
            this.teamFromComboBox.TabIndex = 61;
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
            this.btnCloseBack.Location = new System.Drawing.Point(325, 102);
            this.btnCloseBack.Name = "btnCloseBack";
            this.btnCloseBack.Size = new System.Drawing.Size(171, 44);
            this.btnCloseBack.TabIndex = 68;
            this.btnCloseBack.Text = "Назад";
            this.btnCloseBack.Click += new System.EventHandler(this.btnCloseBack_Click);
            // 
            // labelUserRole
            // 
            this.labelUserRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserRole.AutoSize = true;
            this.labelUserRole.BackColor = System.Drawing.Color.Transparent;
            this.labelUserRole.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserRole.ForeColor = System.Drawing.Color.Black;
            this.labelUserRole.Location = new System.Drawing.Point(1065, 85);
            this.labelUserRole.Name = "labelUserRole";
            this.labelUserRole.Size = new System.Drawing.Size(83, 24);
            this.labelUserRole.TabIndex = 66;
            this.labelUserRole.Text = "UserRole";
            // 
            // labelUserName
            // 
            this.labelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserName.AutoSize = true;
            this.labelUserName.BackColor = System.Drawing.Color.Transparent;
            this.labelUserName.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserName.ForeColor = System.Drawing.Color.Black;
            this.labelUserName.Location = new System.Drawing.Point(1065, 48);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(96, 24);
            this.labelUserName.TabIndex = 65;
            this.labelUserName.Text = "UserName";
            // 
            // dateTimePickerTransfer
            // 
            this.dateTimePickerTransfer.BackColor = System.Drawing.Color.White;
            this.dateTimePickerTransfer.Checked = true;
            this.dateTimePickerTransfer.FillColor = System.Drawing.Color.White;
            this.dateTimePickerTransfer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerTransfer.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateTimePickerTransfer.Location = new System.Drawing.Point(751, 354);
            this.dateTimePickerTransfer.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerTransfer.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerTransfer.Name = "dateTimePickerTransfer";
            this.dateTimePickerTransfer.Size = new System.Drawing.Size(265, 36);
            this.dateTimePickerTransfer.TabIndex = 59;
            this.dateTimePickerTransfer.Value = new System.DateTime(2026, 4, 16, 10, 58, 18, 749);
            // 
            // panelMatchStatistic
            // 
            this.panelMatchStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMatchStatistic.BackColor = System.Drawing.Color.Transparent;
            this.panelMatchStatistic.BorderColor = System.Drawing.Color.White;
            this.panelMatchStatistic.BorderRadius = 10;
            this.panelMatchStatistic.BorderThickness = 2;
            this.panelMatchStatistic.Controls.Add(this.labelTeamNameMore);
            this.panelMatchStatistic.Controls.Add(this.labelCountTransfers);
            this.panelMatchStatistic.Controls.Add(this.labelTopPlayers);
            this.panelMatchStatistic.Controls.Add(this.label4);
            this.panelMatchStatistic.Controls.Add(this.label3);
            this.panelMatchStatistic.Controls.Add(this.label2);
            this.panelMatchStatistic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(233)))), ((int)(((byte)(234)))));
            this.panelMatchStatistic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.panelMatchStatistic.Location = new System.Drawing.Point(325, 576);
            this.panelMatchStatistic.Name = "panelMatchStatistic";
            this.panelMatchStatistic.Size = new System.Drawing.Size(878, 200);
            this.panelMatchStatistic.TabIndex = 53;
            // 
            // labelTeamNameMore
            // 
            this.labelTeamNameMore.AutoSize = true;
            this.labelTeamNameMore.Font = new System.Drawing.Font("Inter SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTeamNameMore.Location = new System.Drawing.Point(475, 152);
            this.labelTeamNameMore.Name = "labelTeamNameMore";
            this.labelTeamNameMore.Size = new System.Drawing.Size(68, 28);
            this.labelTeamNameMore.TabIndex = 5;
            this.labelTeamNameMore.Text = "5 680";
            // 
            // labelCountTransfers
            // 
            this.labelCountTransfers.AutoSize = true;
            this.labelCountTransfers.Font = new System.Drawing.Font("Inter SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountTransfers.Location = new System.Drawing.Point(213, 100);
            this.labelCountTransfers.Name = "labelCountTransfers";
            this.labelCountTransfers.Size = new System.Drawing.Size(32, 28);
            this.labelCountTransfers.TabIndex = 4;
            this.labelCountTransfers.Text = "12";
            // 
            // labelTopPlayers
            // 
            this.labelTopPlayers.Font = new System.Drawing.Font("Inter SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTopPlayers.Location = new System.Drawing.Point(291, 38);
            this.labelTopPlayers.Name = "labelTopPlayers";
            this.labelTopPlayers.Size = new System.Drawing.Size(559, 57);
            this.labelTopPlayers.TabIndex = 3;
            this.labelTopPlayers.Text = "Игроки\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Inter", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(27, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(441, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "Какая команда больше всего покупает/продаёт:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Всего трансферов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(27, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Топ игроков по стоимости: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(318, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(563, 39);
            this.label1.TabIndex = 52;
            this.label1.Text = "Добавление/редактирование трансфера";
            // 
            // pictureProfil
            // 
            this.pictureProfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureProfil.BackColor = System.Drawing.Color.Transparent;
            this.pictureProfil.ImageRotate = 0F;
            this.pictureProfil.Location = new System.Drawing.Point(969, 44);
            this.pictureProfil.Name = "pictureProfil";
            this.pictureProfil.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureProfil.Size = new System.Drawing.Size(75, 75);
            this.pictureProfil.TabIndex = 51;
            this.pictureProfil.TabStop = false;
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
            // matchesTableAdapter
            // 
            this.matchesTableAdapter.ClearBeforeFill = true;
            // 
            // transfersBindingSource
            // 
            this.transfersBindingSource.DataMember = "Transfers";
            this.transfersBindingSource.DataSource = this.footballTicketSystemDataSet;
            // 
            // transfersTableAdapter
            // 
            this.transfersTableAdapter.ClearBeforeFill = true;
            // 
            // tBoxPlayerName
            // 
            this.tBoxPlayerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBoxPlayerName.DefaultText = "";
            this.tBoxPlayerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tBoxPlayerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tBoxPlayerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tBoxPlayerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tBoxPlayerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tBoxPlayerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tBoxPlayerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tBoxPlayerName.Location = new System.Drawing.Point(751, 206);
            this.tBoxPlayerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxPlayerName.Name = "tBoxPlayerName";
            this.tBoxPlayerName.PlaceholderText = "";
            this.tBoxPlayerName.SelectedText = "";
            this.tBoxPlayerName.Size = new System.Drawing.Size(265, 36);
            this.tBoxPlayerName.TabIndex = 77;
            // 
            // CreateTransfersAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 810);
            this.Controls.Add(this.tBoxPlayerName);
            this.Controls.Add(this.btnSaveTransfer);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.priceTransferNumericUpDown);
            this.Controls.Add(this.teamNowComboBox);
            this.Controls.Add(this.teamFromComboBox);
            this.Controls.Add(this.btnCloseBack);
            this.Controls.Add(this.labelUserRole);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.dateTimePickerTransfer);
            this.Controls.Add(teamHomeIdLabel);
            this.Controls.Add(teamAwayIdLabel);
            this.Controls.Add(matchDateLabel);
            this.Controls.Add(stadiumIdLabel);
            this.Controls.Add(ratingMatchLabel);
            this.Controls.Add(this.panelMatchStatistic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureProfil);
            this.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateTransfersAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление | редактирование трансфера";
            this.Load += new System.EventHandler(this.CreateTransfersAdminForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTransferNumericUpDown)).EndInit();
            this.panelMatchStatistic.ResumeLayout(false);
            this.panelMatchStatistic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.footballTicketSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transfersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSaveTransfer;
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
        private Guna.UI2.WinForms.Guna2NumericUpDown priceTransferNumericUpDown;
        private Guna.UI2.WinForms.Guna2ComboBox teamNowComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox teamFromComboBox;
        private Guna.UI2.WinForms.Guna2Button btnCloseBack;
        private System.Windows.Forms.Label labelUserRole;
        private System.Windows.Forms.Label labelUserName;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerTransfer;
        private Guna.UI2.WinForms.Guna2Panel panelMatchStatistic;
        private System.Windows.Forms.Label labelTeamNameMore;
        private System.Windows.Forms.Label labelCountTransfers;
        private System.Windows.Forms.Label labelTopPlayers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureProfil;
        private FootballTicketSystemDataSet footballTicketSystemDataSet;
        private System.Windows.Forms.BindingSource matchesBindingSource;
        private FootballTicketSystemDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private FootballTicketSystemDataSetTableAdapters.MatchesTableAdapter matchesTableAdapter;
        private System.Windows.Forms.BindingSource transfersBindingSource;
        private FootballTicketSystemDataSetTableAdapters.TransfersTableAdapter transfersTableAdapter;
        private Guna.UI2.WinForms.Guna2TextBox tBoxPlayerName;
    }
}