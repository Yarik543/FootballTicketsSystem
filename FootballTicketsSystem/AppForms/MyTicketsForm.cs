using FootballTicketsSystem.AppControls;
using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppForms
{
    public partial class MyTicketsForm : Form
    {
        public MyTicketsForm()
        {   
            InitializeComponent();
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

        private void MyTicketsForm_Load(object sender, EventArgs e)
        {
            LoadMyTickets();
        }

        public void LoadMyTickets()
        {
            flowLayoutPanelTickets.Controls.Clear();

            // 1. Базовый запрос: билеты текущего пользователя через UserTickets
            var tickets = Program.context.Tickets
                .Include(t => t.UserTickets)        // 👈 Связь с пользователями
                .Include(t => t.Matches)
                .Include(t => t.Matches.Teams)
                .Include(t => t.Matches.Teams1)
                .Include(t => t.Matches.Stadiums)
                .Where(t => t.UserTickets.Any(ut => ut.UserId == UserSession.CurrentUser.IdUser))
                .ToList(); // 👇 Выполняем запрос

            // 2. Фильтр по поиску (командам)
            string search = tBoxSearchTeam.Text.ToLower().Trim();
            if (!string.IsNullOrEmpty(search))
            {
                tickets = tickets.Where(t =>
                    (t.Matches?.Teams?.TeamName?.ToLower() ?? "").Contains(search) ||
                    (t.Matches?.Teams1?.TeamName?.ToLower() ?? "").Contains(search)
                ).ToList();
            }

            // 3. Фильтр по статусу (ComboBox)
            switch (comboBoxStatus.SelectedIndex)
            {
                case 0: // Все билеты
                    break;

                case 1: // Только активные (матч ещё не начался)
                    tickets = tickets.Where(t =>
                        t.Matches?.MatchDate.HasValue == true &&
                        t.Matches.MatchDate.Value > DateTime.Now
                    ).ToList();
                    break;

                case 2: // Только неактивные (матч прошёл или идёт)
                    tickets = tickets.Where(t =>
                        t.Matches?.MatchDate.HasValue != true ||
                        t.Matches.MatchDate.Value <= DateTime.Now
                    ).ToList();
                    break;
            }

            // 4. Отображаем результаты
            if (tickets.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "Билетов не найдено",
                    Font = new Font("Microsoft Sans Serif", 10F),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(20)
                };
                flowLayoutPanelTickets.Controls.Add(lbl);
            }
            else
            {
                foreach (Tickets ticket in tickets)
                {
                    flowLayoutPanelTickets.Controls.Add(new MyTicketsControl(ticket));
                }
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tBoxSearchTeam_TextChanged(object sender, EventArgs e)
        {
            LoadMyTickets();
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMyTickets();
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
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
