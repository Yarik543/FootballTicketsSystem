using FootballTicketsSystem.AppControls;
using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace FootballTicketsSystem.AppForms
{
    public partial class CalendarForm : Form
    {
        public CalendarForm()
        {
            InitializeComponent();
            ContextManager.calendarForm = this;
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            int balance = UserSession.CurrentUser.Ballance ?? 0;
            // Форматируем с пробелами
            labelBallanceUser.Text = $"Ваш баланс: {balance:N0} ₽";
            if (string.IsNullOrEmpty(UserSession.CurrentUser.Ballance.ToString()))
            {
                labelBallanceUser.Text = "Ваш балланс: 0 ₽";
            }

            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
            if(UserSession.CurrentUser.IsAdmin())
            {
                btnAddMatch.Visible = true;
                comboBoxSortGoalsMatch.Visible = true;
            }
        }

        /// <summary>
        /// Фон + границы формы
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiPainter.DrawGradientBackground(this, e);
        }
        private void btnMain_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CalendarForm_Load(object sender, EventArgs e)
        {
            comboBoxSortGoalsMatch.Items.Clear();
            comboBoxSortGoalsMatch.Items.Add("Все");
            comboBoxSortGoalsMatch.Items.Add("Без счёта (прошедшие)"); //
            comboBoxSortGoalsMatch.SelectedIndex = 0;

            LoadDataMatch();
        }

        /// <summary>
        /// Загружаем матчи С СВЯЗАННЫМИ ДАННЫМИ (Teams, Teams1, Stadiums)
        /// </summary>
        public void LoadDataMatch()
        {
            flowLayoutPanelMatches.Controls.Clear();

            List<Matches> matches = Program.context.Matches
                .Include(m => m.Teams)
                .Include(m => m.Teams1)
                .Include(m => m.Stadiums)
                .OrderBy(m => m.MatchDate)
                .ToList();

            string search = tBoxSearchMatch.Text.Trim().ToLower();

            // Безопасная фильтрация с защитой от null
            if (!string.IsNullOrEmpty(search))
            {
                matches = matches.Where(m =>
                    (m.Teams?.TeamName?.ToLower() ?? "").Contains(search) ||
                    (m.Teams1?.TeamName?.ToLower() ?? "").Contains(search) ||
                    (m.Stadiums?.NameStadium?.ToLower() ?? "").Contains(search) ||
                    (m.MatchDate?.ToString("dd.MM.yyyy HH:mm")?.ToLower() ?? "").Contains(search)
                ).ToList();
            }

            if (radioBtnLater.Checked)
            {
                matches = matches.OrderByDescending(m => m.MatchDate).ToList();
            }

            switch (comboBoxSortGoalsMatch.SelectedIndex)
            {
                case 0:
                    break;

                case 1: // Без счёта И матч уже прошёл
                    matches = matches.Where(m =>
                        (!m.ScoreHome.HasValue || !m.ScoreAway.HasValue) &&
                        m.MatchDate.HasValue && m.MatchDate.Value < DateTime.Now
                    ).ToList();
                    break;
            }

            foreach (Matches match in matches)
            {
                flowLayoutPanelMatches.Controls.Add(new MatchControl(match));
            }
        }

        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            CreateMatchesAdminForm createMatchesAdminForm = new CreateMatchesAdminForm();
            DialogResult result = createMatchesAdminForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadDataMatch();
            }
        }

        private void radioBtnEarly_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataMatch();
        }

        private void radioBtnLater_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataMatch();
        }

        private void tBoxSearchMatch_TextChanged(object sender, EventArgs e)
        {
            LoadDataMatch();
        }

        private void comboBoxSortGoalsMatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataMatch();
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
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

        private void btnTickets_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LogoutService.RequestLogout(this);
        }
    }
}
