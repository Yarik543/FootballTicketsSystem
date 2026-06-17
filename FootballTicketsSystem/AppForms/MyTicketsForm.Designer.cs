namespace FootballTicketsSystem.AppForms
{
    partial class MyTicketsForm
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTeams = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnTransfers = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnCalendar = new Guna.UI2.WinForms.Guna2Button();
            this.btnProfil = new Guna.UI2.WinForms.Guna2Button();
            this.btnTickets = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnMain = new Guna.UI2.WinForms.Guna2Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.guna2PanelHeaderForm = new Guna.UI2.WinForms.Guna2Panel();
            this.labelUserRole = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pictureProfil = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxSearchTeam = new Guna.UI2.WinForms.Guna2TextBox();
            this.flowLayoutPanelTickets = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.guna2PanelHeaderForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnTeams);
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
            this.guna2Panel1.Size = new System.Drawing.Size(284, 857);
            this.guna2Panel1.TabIndex = 18;
            // 
            // btnTeams
            // 
            this.btnTeams.BorderColor = System.Drawing.Color.Transparent;
            this.btnTeams.BorderRadius = 5;
            this.btnTeams.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTeams.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTeams.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTeams.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTeams.FillColor = System.Drawing.Color.Transparent;
            this.btnTeams.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTeams.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.btnTeams.Image = global::FootballTicketsSystem.Properties.Resources.teams;
            this.btnTeams.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTeams.Location = new System.Drawing.Point(29, 309);
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.Padding = new System.Windows.Forms.Padding(10, 10, 60, 10);
            this.btnTeams.Size = new System.Drawing.Size(226, 49);
            this.btnTeams.TabIndex = 14;
            this.btnTeams.Text = "Команды";
            this.btnTeams.Click += new System.EventHandler(this.btnTeams_Click);
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
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.btnTransfers.Click += new System.EventHandler(this.btnTransfers_Click);
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
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
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
            this.btnProfil.Click += new System.EventHandler(this.btnProfil_Click);
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
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(284, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.guna2PanelHeaderForm);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanelTickets);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 55);
            this.splitContainer1.Size = new System.Drawing.Size(986, 857);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 19;
            // 
            // guna2PanelHeaderForm
            // 
            this.guna2PanelHeaderForm.BackColor = System.Drawing.Color.Transparent;
            this.guna2PanelHeaderForm.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2PanelHeaderForm.Controls.Add(this.labelUserRole);
            this.guna2PanelHeaderForm.Controls.Add(this.labelUserName);
            this.guna2PanelHeaderForm.Controls.Add(this.label2);
            this.guna2PanelHeaderForm.Controls.Add(this.comboBoxStatus);
            this.guna2PanelHeaderForm.Controls.Add(this.pictureProfil);
            this.guna2PanelHeaderForm.Controls.Add(this.guna2PictureBox2);
            this.guna2PanelHeaderForm.Controls.Add(this.label1);
            this.guna2PanelHeaderForm.Controls.Add(this.tBoxSearchTeam);
            this.guna2PanelHeaderForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PanelHeaderForm.Location = new System.Drawing.Point(0, 0);
            this.guna2PanelHeaderForm.Name = "guna2PanelHeaderForm";
            this.guna2PanelHeaderForm.Size = new System.Drawing.Size(986, 151);
            this.guna2PanelHeaderForm.TabIndex = 19;
            // 
            // labelUserRole
            // 
            this.labelUserRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserRole.AutoSize = true;
            this.labelUserRole.BackColor = System.Drawing.Color.Transparent;
            this.labelUserRole.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserRole.ForeColor = System.Drawing.Color.Black;
            this.labelUserRole.Location = new System.Drawing.Point(780, 37);
            this.labelUserRole.Name = "labelUserRole";
            this.labelUserRole.Size = new System.Drawing.Size(83, 24);
            this.labelUserRole.TabIndex = 20;
            this.labelUserRole.Text = "UserRole";
            // 
            // labelUserName
            // 
            this.labelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserName.BackColor = System.Drawing.Color.Transparent;
            this.labelUserName.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserName.ForeColor = System.Drawing.Color.Black;
            this.labelUserName.Location = new System.Drawing.Point(780, 76);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(194, 66);
            this.labelUserName.TabIndex = 19;
            this.labelUserName.Text = "UserName";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(403, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Статус";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBoxStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FillColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxStatus.ItemHeight = 30;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Все",
            "Активные",
            "Прошедшие"});
            this.comboBoxStatus.Location = new System.Drawing.Point(477, 94);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(173, 36);
            this.comboBoxStatus.StartIndex = 0;
            this.comboBoxStatus.TabIndex = 17;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
            // 
            // pictureProfil
            // 
            this.pictureProfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureProfil.BackColor = System.Drawing.Color.Transparent;
            this.pictureProfil.ImageRotate = 0F;
            this.pictureProfil.Location = new System.Drawing.Point(699, 37);
            this.pictureProfil.Name = "pictureProfil";
            this.pictureProfil.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureProfil.Size = new System.Drawing.Size(75, 75);
            this.pictureProfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureProfil.TabIndex = 16;
            this.pictureProfil.TabStop = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = global::FootballTicketsSystem.Properties.Resources.search;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(407, 46);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(25, 25);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 2;
            this.guna2PictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(19, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Мои купленные билеты";
            // 
            // tBoxSearchTeam
            // 
            this.tBoxSearchTeam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tBoxSearchTeam.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBoxSearchTeam.DefaultText = "";
            this.tBoxSearchTeam.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tBoxSearchTeam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tBoxSearchTeam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tBoxSearchTeam.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tBoxSearchTeam.FillColor = System.Drawing.Color.WhiteSmoke;
            this.tBoxSearchTeam.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tBoxSearchTeam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tBoxSearchTeam.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tBoxSearchTeam.Location = new System.Drawing.Point(438, 43);
            this.tBoxSearchTeam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxSearchTeam.Name = "tBoxSearchTeam";
            this.tBoxSearchTeam.PlaceholderText = "";
            this.tBoxSearchTeam.SelectedText = "";
            this.tBoxSearchTeam.Size = new System.Drawing.Size(212, 31);
            this.tBoxSearchTeam.TabIndex = 1;
            this.tBoxSearchTeam.TextChanged += new System.EventHandler(this.tBoxSearchTeam_TextChanged);
            // 
            // flowLayoutPanelTickets
            // 
            this.flowLayoutPanelTickets.AutoScroll = true;
            this.flowLayoutPanelTickets.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTickets.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelTickets.Name = "flowLayoutPanelTickets";
            this.flowLayoutPanelTickets.Size = new System.Drawing.Size(986, 647);
            this.flowLayoutPanelTickets.TabIndex = 0;
            // 
            // MyTicketsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1270, 857);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyTicketsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мои билеты";
            this.Load += new System.EventHandler(this.MyTicketsForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.guna2PanelHeaderForm.ResumeLayout(false);
            this.guna2PanelHeaderForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnTeams;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Button btnTransfers;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Button btnCalendar;
        private Guna.UI2.WinForms.Guna2Button btnProfil;
        private Guna.UI2.WinForms.Guna2Button btnTickets;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelHeaderForm;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureProfil;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tBoxSearchTeam;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTickets;
        private System.Windows.Forms.Label labelUserRole;
        private System.Windows.Forms.Label labelUserName;
    }
}