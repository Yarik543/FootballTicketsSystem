namespace FootballTicketsSystem.AppControls
{
    partial class TransfersControl
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
            this.btnDeleteTransfer = new Guna.UI2.WinForms.Guna2PictureBox();
            this.labelPriceTransfer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTeamsTransfer = new System.Windows.Forms.Label();
            this.labelDataTransfer = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.pictureBoxPhotoPlayer = new Guna.UI2.WinForms.Guna2PictureBox();
            this.gunaPanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteTransfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhotoPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaPanelControl
            // 
            this.gunaPanelControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(233)))), ((int)(((byte)(234)))));
            this.gunaPanelControl.BorderColor = System.Drawing.Color.White;
            this.gunaPanelControl.BorderRadius = 10;
            this.gunaPanelControl.BorderThickness = 2;
            this.gunaPanelControl.Controls.Add(this.btnDeleteTransfer);
            this.gunaPanelControl.Controls.Add(this.labelPriceTransfer);
            this.gunaPanelControl.Controls.Add(this.label1);
            this.gunaPanelControl.Controls.Add(this.labelTeamsTransfer);
            this.gunaPanelControl.Controls.Add(this.labelDataTransfer);
            this.gunaPanelControl.Controls.Add(this.guna2CirclePictureBox2);
            this.gunaPanelControl.Controls.Add(this.labelPlayerName);
            this.gunaPanelControl.Controls.Add(this.pictureBoxPhotoPlayer);
            this.gunaPanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaPanelControl.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaPanelControl.Location = new System.Drawing.Point(0, 0);
            this.gunaPanelControl.Name = "gunaPanelControl";
            this.gunaPanelControl.Size = new System.Drawing.Size(595, 204);
            this.gunaPanelControl.TabIndex = 1;
            this.gunaPanelControl.Click += new System.EventHandler(this.gunaPanelControl_Click);
            // 
            // btnDeleteTransfer
            // 
            this.btnDeleteTransfer.Image = global::FootballTicketsSystem.Properties.Resources.trash;
            this.btnDeleteTransfer.ImageRotate = 0F;
            this.btnDeleteTransfer.Location = new System.Drawing.Point(535, 155);
            this.btnDeleteTransfer.Name = "btnDeleteTransfer";
            this.btnDeleteTransfer.Size = new System.Drawing.Size(38, 27);
            this.btnDeleteTransfer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDeleteTransfer.TabIndex = 35;
            this.btnDeleteTransfer.TabStop = false;
            this.btnDeleteTransfer.Click += new System.EventHandler(this.btnDeleteTransfer_Click);
            // 
            // labelPriceTransfer
            // 
            this.labelPriceTransfer.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPriceTransfer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.labelPriceTransfer.Location = new System.Drawing.Point(326, 158);
            this.labelPriceTransfer.Name = "labelPriceTransfer";
            this.labelPriceTransfer.Size = new System.Drawing.Size(190, 24);
            this.labelPriceTransfer.TabIndex = 34;
            this.labelPriceTransfer.Text = "$120M";
            this.labelPriceTransfer.Click += new System.EventHandler(this.gunaPanelControl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "Сумма: ";
            this.label1.Click += new System.EventHandler(this.gunaPanelControl_Click);
            // 
            // labelTeamsTransfer
            // 
            this.labelTeamsTransfer.AutoSize = true;
            this.labelTeamsTransfer.Location = new System.Drawing.Point(245, 112);
            this.labelTeamsTransfer.Name = "labelTeamsTransfer";
            this.labelTeamsTransfer.Size = new System.Drawing.Size(55, 24);
            this.labelTeamsTransfer.TabIndex = 32;
            this.labelTeamsTransfer.Text = "Team";
            this.labelTeamsTransfer.Click += new System.EventHandler(this.gunaPanelControl_Click);
            // 
            // labelDataTransfer
            // 
            this.labelDataTransfer.AutoSize = true;
            this.labelDataTransfer.Font = new System.Drawing.Font("Inter", 10F);
            this.labelDataTransfer.Location = new System.Drawing.Point(292, 75);
            this.labelDataTransfer.Name = "labelDataTransfer";
            this.labelDataTransfer.Size = new System.Drawing.Size(96, 24);
            this.labelDataTransfer.TabIndex = 31;
            this.labelDataTransfer.Text = "12.10.2026";
            this.labelDataTransfer.Click += new System.EventHandler(this.gunaPanelControl_Click);
            // 
            // guna2CirclePictureBox2
            // 
            this.guna2CirclePictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CirclePictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox2.Image = global::FootballTicketsSystem.Properties.Resources.mdi_calendar;
            this.guna2CirclePictureBox2.ImageRotate = 0F;
            this.guna2CirclePictureBox2.Location = new System.Drawing.Point(248, 72);
            this.guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
            this.guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox2.Size = new System.Drawing.Size(35, 28);
            this.guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox2.TabIndex = 30;
            this.guna2CirclePictureBox2.TabStop = false;
            this.guna2CirclePictureBox2.UseTransparentBackground = true;
            this.guna2CirclePictureBox2.Click += new System.EventHandler(this.gunaPanelControl_Click);
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Font = new System.Drawing.Font("Inter", 12F);
            this.labelPlayerName.Location = new System.Drawing.Point(244, 20);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(65, 28);
            this.labelPlayerName.TabIndex = 1;
            this.labelPlayerName.Text = "label1";
            this.labelPlayerName.Click += new System.EventHandler(this.gunaPanelControl_Click);
            // 
            // pictureBoxPhotoPlayer
            // 
            this.pictureBoxPhotoPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPhotoPlayer.BorderRadius = 8;
            this.pictureBoxPhotoPlayer.ImageRotate = 0F;
            this.pictureBoxPhotoPlayer.Location = new System.Drawing.Point(26, 20);
            this.pictureBoxPhotoPlayer.Name = "pictureBoxPhotoPlayer";
            this.pictureBoxPhotoPlayer.Size = new System.Drawing.Size(191, 162);
            this.pictureBoxPhotoPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPhotoPlayer.TabIndex = 0;
            this.pictureBoxPhotoPlayer.TabStop = false;
            this.pictureBoxPhotoPlayer.Click += new System.EventHandler(this.gunaPanelControl_Click);
            // 
            // TransfersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gunaPanelControl);
            this.Margin = new System.Windows.Forms.Padding(25, 3, 3, 25);
            this.Name = "TransfersControl";
            this.Size = new System.Drawing.Size(595, 204);
            this.gunaPanelControl.ResumeLayout(false);
            this.gunaPanelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteTransfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhotoPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel gunaPanelControl;
        private System.Windows.Forms.Label labelPlayerName;
        private Guna.UI2.WinForms.Guna2PictureBox pictureBoxPhotoPlayer;
        private System.Windows.Forms.Label labelDataTransfer;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox2;
        private System.Windows.Forms.Label labelTeamsTransfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPriceTransfer;
        private Guna.UI2.WinForms.Guna2PictureBox btnDeleteTransfer;
    }
}
