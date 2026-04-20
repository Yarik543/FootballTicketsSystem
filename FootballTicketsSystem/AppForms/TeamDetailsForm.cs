using FootballTicketsSystem.AppServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppForms
{
    public partial class TeamDetailsForm : Form
    {
        public TeamDetailsForm()
        {
            InitializeComponent();
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);

            // По умолчанию показываем команду
            panelPlayers.BringToFront();

            // Подсветка активного таба
            labelTeam.ForeColor = Color.FromArgb(0, 200, 150); // Зелёный
            labelCoach.ForeColor = Color.Gray; // Серый
        }

        /// <summary>
        /// Фон + границы формы
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiPainter.DrawGradientBackground(this, e);
        }

        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelTeam_Click(object sender, EventArgs e)
        {
            panelPlayers.BringToFront();

            // Подсветка текста
            labelTeam.ForeColor = Color.FromArgb(0, 200, 150);
            labelCoach.ForeColor = Color.Gray;

            lineCoach.Visible = false;
            linePlayers.Visible = true;
        }

        private void labelCoach_Click(object sender, EventArgs e)
        {
            panelCoach.BringToFront();

            // Подсветка текста
            labelTeam.ForeColor = Color.Gray;
            labelCoach.ForeColor = Color.FromArgb(0, 200, 150);

            lineCoach.Visible = true;
            linePlayers.Visible = false;
        }
    }
}
