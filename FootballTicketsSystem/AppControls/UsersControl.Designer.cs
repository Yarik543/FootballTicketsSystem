namespace FootballTicketsSystem.AppControls
{
    partial class UsersControl
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
            this.gunaPanelMatch = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTopBalance = new Guna.UI2.WinForms.Guna2Button();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.pictureBoxProfil = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnDeleteUser = new Guna.UI2.WinForms.Guna2Button();
            this.labelUserName = new System.Windows.Forms.Label();
            this.gunaPanelMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfil)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaPanelMatch
            // 
            this.gunaPanelMatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(233)))), ((int)(((byte)(234)))));
            this.gunaPanelMatch.BorderColor = System.Drawing.Color.White;
            this.gunaPanelMatch.BorderRadius = 10;
            this.gunaPanelMatch.BorderThickness = 2;
            this.gunaPanelMatch.Controls.Add(this.btnTopBalance);
            this.gunaPanelMatch.Controls.Add(this.labelPhone);
            this.gunaPanelMatch.Controls.Add(this.labelEmail);
            this.gunaPanelMatch.Controls.Add(this.pictureBoxProfil);
            this.gunaPanelMatch.Controls.Add(this.btnDeleteUser);
            this.gunaPanelMatch.Controls.Add(this.labelUserName);
            this.gunaPanelMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaPanelMatch.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaPanelMatch.Location = new System.Drawing.Point(0, 0);
            this.gunaPanelMatch.Margin = new System.Windows.Forms.Padding(25, 0, 0, 25);
            this.gunaPanelMatch.Name = "gunaPanelMatch";
            this.gunaPanelMatch.Size = new System.Drawing.Size(1220, 195);
            this.gunaPanelMatch.TabIndex = 2;
            // 
            // btnTopBalance
            // 
            this.btnTopBalance.BorderColor = System.Drawing.Color.White;
            this.btnTopBalance.BorderRadius = 5;
            this.btnTopBalance.BorderThickness = 2;
            this.btnTopBalance.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTopBalance.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTopBalance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTopBalance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTopBalance.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.btnTopBalance.Font = new System.Drawing.Font("Inter Medium", 11F, System.Drawing.FontStyle.Bold);
            this.btnTopBalance.ForeColor = System.Drawing.Color.White;
            this.btnTopBalance.Location = new System.Drawing.Point(929, 63);
            this.btnTopBalance.Name = "btnTopBalance";
            this.btnTopBalance.Size = new System.Drawing.Size(262, 55);
            this.btnTopBalance.TabIndex = 38;
            this.btnTopBalance.Text = "Пополнить балланс";
            this.btnTopBalance.Click += new System.EventHandler(this.btnTopBalance_Click);
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPhone.Location = new System.Drawing.Point(269, 150);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(111, 28);
            this.labelPhone.TabIndex = 37;
            this.labelPhone.Text = "Телефон: ";
            this.labelPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEmail.Location = new System.Drawing.Point(269, 83);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(75, 28);
            this.labelEmail.TabIndex = 36;
            this.labelEmail.Text = "Email: ";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxProfil
            // 
            this.pictureBoxProfil.ImageRotate = 0F;
            this.pictureBoxProfil.Location = new System.Drawing.Point(43, 18);
            this.pictureBoxProfil.Name = "pictureBoxProfil";
            this.pictureBoxProfil.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureBoxProfil.Size = new System.Drawing.Size(190, 160);
            this.pictureBoxProfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfil.TabIndex = 35;
            this.pictureBoxProfil.TabStop = false;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BorderColor = System.Drawing.Color.White;
            this.btnDeleteUser.BorderRadius = 5;
            this.btnDeleteUser.BorderThickness = 2;
            this.btnDeleteUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(111)))), ((int)(((byte)(128)))));
            this.btnDeleteUser.Font = new System.Drawing.Font("Inter Medium", 11F, System.Drawing.FontStyle.Bold);
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Location = new System.Drawing.Point(929, 124);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(262, 54);
            this.btnDeleteUser.TabIndex = 34;
            this.btnDeleteUser.Text = "Удалить";
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserName.Location = new System.Drawing.Point(269, 18);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(71, 28);
            this.labelUserName.TabIndex = 23;
            this.labelUserName.Text = "ФИО: ";
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gunaPanelMatch);
            this.Margin = new System.Windows.Forms.Padding(25, 0, 0, 25);
            this.Name = "UsersControl";
            this.Size = new System.Drawing.Size(1220, 195);
            this.gunaPanelMatch.ResumeLayout(false);
            this.gunaPanelMatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel gunaPanelMatch;
        private Guna.UI2.WinForms.Guna2Button btnDeleteUser;
        private System.Windows.Forms.Label labelUserName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureBoxProfil;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelEmail;
        private Guna.UI2.WinForms.Guna2Button btnTopBalance;
    }
}
