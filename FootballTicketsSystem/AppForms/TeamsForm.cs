using FootballTicketsSystem.AppControls;
using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppForms
{
    public partial class TeamsForm : Form
    {
        public TeamsForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
        }

        /// <summary>
        /// Фон + границы формы
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiPainter.DrawGradientBackground(this, e);
        }

        private void TeamsForm_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            flowLayoutPanelTeamsShow.Controls.Clear();
           List<Teams> teams = Program.context.Teams.ToList();

            string search = tBoxSearchTeam.Text.ToLower().Trim();
            teams = teams.Where(t=>
            (t.TeamName?.ToLower() ?? "").Contains(search) || 
            (t.Stadiums.NameStadium?.ToLower() ?? "").Contains(search) ||
            (t.City?.ToLower() ?? "").Contains(search)
            ).ToList();

            foreach (Teams team in teams)
            {
                flowLayoutPanelTeamsShow.Controls.Add(new TeamsTournamentControl(team));
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tBoxSearchTeam_TextChanged(object sender, EventArgs e)
        {
           LoadData();
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void btnTransfers_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LogoutService.RequestLogout(this);
        }
    }
}
