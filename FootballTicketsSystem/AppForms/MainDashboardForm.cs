using FootballTicketsSystem.AppServices;
using Guna.UI2.WinForms;
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
    public partial class MainDashboardForm : Form
    {
        public MainDashboardForm()
        {
            InitializeComponent();
            ContextManager.mainDashboardForm = this;
            this.DoubleBuffered = true;
        }

        private void MainDashboardForm_Load(object sender, EventArgs e)
        {
            labelUserBack.Text += UserSession.CurrentUser.FullName;
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
        }

        /// <summary>
        /// Фон + границы формы
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiPainter.DrawGradientBackground(this, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            TeamsForm teamsForm = new TeamsForm();
            DialogResult teamsF = teamsForm.ShowDialog();
            this.Hide();
            if (teamsF == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            MyTicketsForm ticketsForm = new MyTicketsForm();
            DialogResult ticketsDialog = ticketsForm.ShowDialog();
            this.Hide();
            if (ticketsDialog == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            ProfilForm profilForm = new ProfilForm();
            DialogResult profilDialog = profilForm.ShowDialog();
            this.Hide();
            if(profilDialog == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            CalendarForm calendarForm = new CalendarForm();
            DialogResult calendarDialog = calendarForm.ShowDialog();
            this.Hide();
            if (calendarDialog == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnTransfers_Click(object sender, EventArgs e)
        {
            TransfersForm transfers = new TransfersForm();
            DialogResult transferDialog = transfers.ShowDialog();
            this.Hide();
            if (transferDialog == DialogResult.OK)
            {
                this.Show();
            }
        }
    }
}
