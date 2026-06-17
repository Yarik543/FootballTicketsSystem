using FootballTicketsSystem.AppControls;
using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
using FootballTicketsSystem.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        private int? _currentMatchId = null; 
        private int? _currentTeamsStatsMatchId = null;
        private DateTime _lastTeamsStatsUpdate = DateTime.MinValue;
        public MainDashboardForm()
        {
            InitializeComponent();
            ContextManager.mainDashboardForm = this;
            this.DoubleBuffered = true;
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
        }

        private async void MainDashboardForm_Load(object sender, EventArgs e)
        {
            labelUserBack.Text += UserSession.CurrentUser.FullName;
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;

            LoadNextMatch();
            LoadTeamsStatistics();
            LoadMatchStatistics();
            LoadLastThreeMatchesAll();

            await LoadTeamsTableAsync();

            CheckTomorrowMatchWithTicket();


            timerMatchStats.Interval = 1000;
            timerMatchStats.Tick += timerMatchStats_Tick;
            timerMatchStats.Start();
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
            LogoutService.RequestLogout(this);
        }

        /// <summary>
        /// Обрабатывает переходы из дочерних форм (циклически, пока не вернёмся на главную)
        /// </summary>
        private void HandleNavigationResult(DialogResult initialResult)
        {
            DialogResult result = initialResult;

            while (result != DialogResult.OK)
            {
                switch (result)
                {
                    case DialogResult.Abort: // Билеты
                        using (var f = new MyTicketsForm())
                        {
                            result = f.ShowDialog();
                            if (result == DialogResult.OK)
                                RefreshDashboardAfterTickets();
                        }
                        break;

                    case DialogResult.Retry: // Команды
                        using (var f = new TeamsForm())
                        {
                            result = f.ShowDialog();
                            if (result == DialogResult.OK)
                                _ = LoadTeamsTableAsync();
                        }
                        break;

                    case DialogResult.Ignore: //Профиль
                        using (var f = new ProfilForm(UserSession.CurrentUser))
                        {
                            result = f.ShowDialog();
                            if (result == DialogResult.OK)
                                RefreshUserProfile();
                        }
                        break;

                    case DialogResult.Yes: // Календарь
                        using (var f = new CalendarForm())
                        {
                            result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                LoadNextMatch();
                                _ = LoadTeamsTableAsync();
                            }
                        }
                        break;

                    case DialogResult.Cancel: //Трансферы
                        using (var f = new TransfersForm())
                        {
                            result = f.ShowDialog();
                        }
                        break;

                    default:
                        // Неизвестный результат — выходим
                        return;
                }
            }

            RefreshDashboardAfterTickets();
        }

        /// <summary>
        /// Обновляет данные профиля в шапке
        /// </summary>
        private void RefreshUserProfile()
        {
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            using (var form = new TeamsForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) _ = LoadTeamsTableAsync();
                else HandleNavigationResult(result);
            }
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            using (var form = new MyTicketsForm())
            {
                var result = form.ShowDialog();
                RefreshDashboardAfterTickets();
                if (result != DialogResult.OK) HandleNavigationResult(result);
            }
        }

        /// <summary>
        /// Обновляет данные на главной после возврата из формы билетов
        /// </summary>
        private void RefreshDashboardAfterTickets()
        {
            LoadMatchStatistics();
            CheckTomorrowMatchWithTicket();
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            using (var form = new ProfilForm(UserSession.CurrentUser))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) RefreshUserProfile();
                else HandleNavigationResult(result);
            }
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            using (var form = new CalendarForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadNextMatch();
                    _ = LoadTeamsTableAsync();
                }
                else HandleNavigationResult(result);
            }
        }

        private void btnTransfers_Click(object sender, EventArgs e)
        {
            using (var form = new TransfersForm())
            {
                var result = form.ShowDialog();
                if (result != DialogResult.OK) HandleNavigationResult(result);
            }
        }

        /// <summary>
        /// Загрузка следующего матча
        /// </summary>
        private bool LoadNextMatch()
        {
            var activeWindowStart = DateTime.Now.AddHours(-2);

            var nextMatch = Program.context.Matches
                .AsNoTracking()
                .Include(m => m.Teams)
                .Include(m => m.Teams1)
                .Include(m => m.Stadiums)
                .Where(m => m.MatchDate > activeWindowStart)
                .OrderBy(m => m.MatchDate)
                .FirstOrDefault();

            if (nextMatch?.IdMatch == _currentMatchId)
            {
                return false;
            }

            _currentMatchId = nextMatch?.IdMatch;

            if (nextMatch != null)
            {
                labelTeamNameFirst.Text = nextMatch.Teams?.TeamName;
                labelTeamNameSecond.Text = nextMatch.Teams1?.TeamName;

                if (nextMatch.MatchDate.HasValue)
                {
                    labelDateMatch.Text = nextMatch.MatchDate.Value.ToString("HH:mm, dd MMMM, yyyy");
                }

                labelStadiumName.Text = nextMatch.Stadiums?.NameStadium ?? "Стадион не указан";

                if (nextMatch.Teams != null && !string.IsNullOrEmpty(nextMatch.Teams.Logo))
                    _ = ImageLoader.LoadToPictureBoxAsync(pictureBoxLogoFirstTeam, nextMatch.Teams.Logo, Properties.Resources.picture);
                else
                    pictureBoxLogoFirstTeam.Image = Properties.Resources.picture;

                if (nextMatch.Teams1 != null && !string.IsNullOrEmpty(nextMatch.Teams1.Logo))
                    _ = ImageLoader.LoadToPictureBoxAsync(pictureBoxLogoSecondTeam, nextMatch.Teams1.Logo, Properties.Resources.picture);
                else
                    pictureBoxLogoSecondTeam.Image = Properties.Resources.picture;

                return true;
            }
            else
            {
                labelNextMatch.Text = "Матчей нет";
                labelDateMatch.Text = "";
                labelStadiumName.Text = "";
                pictureBoxLogoFirstTeam.Image = Properties.Resources.picture;
                pictureBoxLogoSecondTeam.Image = Properties.Resources.picture;
                return true;
            }
        }

        /// <summary>
        /// Загрузка статистики последних игр между командами
        /// </summary>
        private void LoadTeamsStatistics()
        {
            var activeWindowStart = DateTime.Now.AddHours(-2);

            var currentMatch = Program.context.Matches
                .AsNoTracking()
                .Include(m => m.Teams)
                .Include(m => m.Teams1)
                .Where(m => m.MatchDate > activeWindowStart)
                .OrderBy(m => m.MatchDate)
                .FirstOrDefault();

            if (currentMatch == null || currentMatch.Teams == null || currentMatch.Teams1 == null)
            {
                labelLastGame.Text = "Нет матча";
                return;
            }

            if (currentMatch.IdMatch == _currentTeamsStatsMatchId)
            {
                return;
            }

            _currentTeamsStatsMatchId = currentMatch.IdMatch;

            int team1Id = currentMatch.Teams.IdTeam;
            int team2Id = currentMatch.Teams1.IdTeam;

            labelTeamFirst.Text = currentMatch.Teams.TeamName;
            labelTeamSecond.Text = currentMatch.Teams1.TeamName;

            // Получаем последние 10 завершенных матчей между командами
            var lastMatches = Program.context.Matches
                .AsNoTracking()
                .Where(m => (m.TeamHomeId == team1Id && m.TeamAwayId == team2Id) ||
                           (m.TeamHomeId == team2Id && m.TeamAwayId == team1Id))
                .Where(m => m.MatchDate < DateTime.Now && m.ScoreHome != null && m.ScoreAway != null)
                .OrderByDescending(m => m.MatchDate)
                .Take(10)
                .ToList();

            int team1Wins = 0;
            int team2Wins = 0;
            int draws = 0;

            foreach (var match in lastMatches)
            {
                bool isTeam1Home = match.TeamHomeId == team1Id;
                int homeScore = match.ScoreHome.Value;
                int awayScore = match.ScoreAway.Value;

                if (homeScore > awayScore)
                {
                    if (isTeam1Home) team1Wins++; else team2Wins++;
                }
                else if (awayScore > homeScore)
                {
                    if (isTeam1Home) team2Wins++; else team1Wins++;
                }
                else
                {
                    draws++;
                }
            }

            labelCountTeamFirstWin.Text = team1Wins.ToString();
            labelCountTeamSecondWin.Text = team2Wins.ToString();
            labelDrawsCount.Text = draws.ToString();
            labelLastGame.Text = "Последние игры: " + lastMatches.Count.ToString();

            UpdateStatsBars(team1Wins, team2Wins, draws, lastMatches.Count);
        }


        /// <summary>
        /// Обновляет ширину цветных панелей статистики
        /// </summary>
        private void UpdateStatsBars(int team1Wins, int team2Wins, int draws, int totalGames)
        {
            if (totalGames == 0)
            {
                panelTeam1Win.Width = 0;
                panelDraw.Width = 0;
                panelTeam2Win.Width = 0;
                return;
            }

            int totalWidth = panelStatsContainer.Width;

            panelTeam1Win.Width = (team1Wins * totalWidth) / totalGames;
            panelDraw.Width = (draws * totalWidth) / totalGames;
            panelTeam2Win.Width = (team2Wins * totalWidth) / totalGames;
        }

        private async void timerMatchStats_Tick(object sender, EventArgs e)
        {
            LoadMatchStatistics();

            bool matchChanged = LoadNextMatch();

            if (matchChanged)
            {
                LoadTeamsStatistics();
                LoadLastThreeMatchesAll();
                await LoadTeamsTableAsync();

                CheckTomorrowMatchWithTicket();
            }
        }

        public void LoadMatchStatistics()
        {
            var thresholdTime = DateTime.Now.AddHours(-2);

            var match = Program.context.Matches
                .AsNoTracking()
                .Include(m => m.Stadiums)
                .Where(m => m.MatchDate > thresholdTime)
                .OrderBy(m => m.MatchDate)
                .FirstOrDefault();

            if (match == null)
            {
                labelTimerMatch.Text = "Нет матча";
                return;
            }

            TimeSpan timeLeft = match.MatchDate.Value - DateTime.Now;

            if (timeLeft.TotalSeconds <= 0)
            {
                labelTimerMatch.Text = "⚽ Матч идет";
                labelTimerMatch.ForeColor = Color.FromArgb(0, 200, 150);
            }
            else if (timeLeft.TotalMinutes < 1)
            {
                int seconds = (int)timeLeft.TotalSeconds;
                labelTimerMatch.Text = $"{seconds} сек";
                labelTimerMatch.ForeColor = Color.FromArgb(255, 62, 62);
            }
            else if (timeLeft.TotalHours < 1)
            {
                int minutes = (int)timeLeft.TotalMinutes;
                labelTimerMatch.Text = $"{minutes} мин";
                labelTimerMatch.ForeColor = Color.FromArgb(255, 193, 7);
            }
            else if (timeLeft.TotalDays < 1)
            {
                int hours = (int)timeLeft.TotalHours;
                labelTimerMatch.Text = $"{hours} ч";
                labelTimerMatch.ForeColor = Color.Black;
            }
            else
            {
                int days = (int)timeLeft.TotalDays;
                labelTimerMatch.Text = $"{days} дн";
                labelTimerMatch.ForeColor = Color.Gray;
            }

            int soldCount = Program.context.Tickets.Count(t => t.MatchId == match.IdMatch);
            labelTicketsCount.Text = soldCount.ToString("N0");

            int capacity = match.Stadiums?.Capacity ?? 0;
            int percentage = 0;
            if (capacity > 0)
            {
                percentage = (soldCount * 100) / capacity;
                if (percentage > 100) percentage = 100;
            }
            labelCapacityPircent.Text = $"{percentage}%";

            labelRatingMatch.Text = match.RatingMatch?.ToString("F2") ?? "0.00";
        }

        private void timerNextMatchRefresh_Tick(object sender, EventArgs e)
        {
            LoadNextMatch();
            LoadTeamsStatistics();
            LoadMatchStatistics();

            Console.WriteLine($"[{DateTime.Now}] Следующий матч обновлён автоматически");
        }

        /// <summary>
        /// Загружает 3 самых последних завершенных матча из всей базы
        /// </summary>
        private void LoadLastThreeMatchesAll()
        {
            var lastMatches = Program.context.Matches
                .AsNoTracking()
                .Include(m => m.Teams)
                .Include(m => m.Teams1)
                .Where(m => m.MatchDate < DateTime.Now && m.ScoreHome != null && m.ScoreAway != null)
                .OrderByDescending(m => m.MatchDate)
                .Take(3)
                .ToList();

            for (int i = 0; i < 3; i++)
            {
                if (i < lastMatches.Count)
                {
                    var match = lastMatches[i];
                    string homeTeam = match.Teams?.TeamName ?? "???";
                    string awayTeam = match.Teams1?.TeamName ?? "???";
                    string score = $"{match.ScoreHome}   :   {match.ScoreAway}";

                    SetLastMatchLabels(i, homeTeam, awayTeam, score);
                }
                else
                {
                    SetLastMatchLabels(i, "-", "-", "-");
                }
            }
        }

        /// <summary>
        /// Вспомогательный метод для установки текста в label'ы матчей
        /// </summary>
        private void SetLastMatchLabels(int matchIndex, string homeTeam, string awayTeam, string score)
        {
            switch (matchIndex)
            {
                case 0: // Самый свежий матч
                    labelTeamHomeNameLastResult.Text = homeTeam;
                    labelTeamAwayNameLastResult.Text = awayTeam;
                    labelScoreFirstMatchLast.Text = score;
                    break;
                case 1: // Второй по свежести
                    labelTeamHomeNameLastResult2.Text = homeTeam;
                    labelTeamAwayNameLastResult2.Text = awayTeam;
                    labelScoreSecondMatchLast.Text = score;
                    break;
                case 2: // Третий по свежести
                    labelTeamHomeNameLastResult3.Text = homeTeam;
                    labelTeamAwayNameLastResult3.Text = awayTeam;
                    labelScoreThirdMatchLast.Text = score;
                    break;
            }
        }

        /// <summary>
        /// Проверяет, есть ли у пользователя билет на матч ЗАВТРА
        /// </summary>
        private void CheckTomorrowMatchWithTicket()
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);
            DateTime dayAfterTomorrow = today.AddDays(2);

            var tomorrowMatch = Program.context.Matches
                .AsNoTracking()
                .Include(m => m.Teams)
                .Include(m => m.Teams1)
                .FirstOrDefault(m =>
                    m.MatchDate >= tomorrow &&
                    m.MatchDate < dayAfterTomorrow);

            if (tomorrowMatch == null)
            {
                pictureBoxIndexMessage.Visible = false;
                return;
            }

            var userTicketIds = Program.context.UserTickets
                .Where(ut => ut.UserId == UserSession.CurrentUser.IdUser)
                .Select(ut => ut.TicketId)
                .ToList();

            bool hasTicket = Program.context.Tickets
                .Any(t => userTicketIds.Contains(t.IdTicket) &&
                          t.MatchId == tomorrowMatch.IdMatch &&
                          t.IsSold == true);

            if (hasTicket)
            {
                pictureBoxIndexMessage.Visible = true;
                ShowTomorrowMatchNotification(tomorrowMatch);
            }
            else
            {
                pictureBoxIndexMessage.Visible = false;
            }
        }

        /// <summary>
        /// Показывает красивое уведомление о завтрашнем матче
        /// </summary>
        private void ShowTomorrowMatchNotification(Matches match)
        {
            if (UserSession.HasSeenTomorrowNotification) return;

            var notificationForm = new Form
            {
                Text = "Напоминание",
                Size = new Size(400, 250),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            var headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(20, 184, 134)
            };
            notificationForm.Controls.Add(headerPanel);

            var iconLabel = new Label
            {
                Text = "🎫",
                Font = new Font("Segoe UI Emoji", 24F),
                Location = new Point(15, 10),
                AutoSize = true
            };
            headerPanel.Controls.Add(iconLabel);

            var titleLabel = new Label
            {
                Text = "     Завтра матч!",
                Font = new Font("Inter", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(60, 15),
                AutoSize = true
            };
            headerPanel.Controls.Add(titleLabel);

            var matchInfo = new Label
            {
                Text = $"{match.Teams?.TeamName}  vs  {match.Teams1?.TeamName}\n" +
                       $"📅 {match.MatchDate?.ToString("dd.MM.yyyy HH:mm")}\n" +
                       $"🏟️ {match.Stadiums?.NameStadium}",
                Font = new Font("Microsoft Sans Serif", 10F),
                Location = new Point(20, 80),
                Width = 340,
                Height = 70,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter
            };
            notificationForm.Controls.Add(matchInfo);

            var btnViewTicket = new Guna2Button
            {
                Text = "🎫 Мои билеты",
                Location = new Point(120, 160),
                Width = 160,
                Height = 40,
                BorderRadius = 20,
                FillColor = Color.FromArgb(20, 184, 134),
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold)
            };

            btnViewTicket.HoverState.FillColor = Color.FromArgb(0, 150, 100);
            btnViewTicket.Click += (s, e) =>
            {
                notificationForm.Close();
                var ticketsForm = new MyTicketsForm();
                ticketsForm.ShowDialog();
            };
            notificationForm.Controls.Add(btnViewTicket);

            var btnClose = new Guna2Button
            {
                Text = "Понятно",
                Location = new Point(140, 205),
                Width = 120,
                Height = 30,
                BorderRadius = 15,
                FillColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.FromArgb(30, 30, 47)
            };

            btnClose.HoverState.FillColor = Color.FromArgb(220, 220, 220);
            btnClose.Click += (s, e) => notificationForm.Close();
            notificationForm.Controls.Add(btnClose);


            notificationForm.ShowDialog();
            UserSession.HasSeenTomorrowNotification = true;
        }

        /// <summary>
        /// Загружает турнирную таблицу команд
        /// </summary>
        private async Task LoadTeamsTableAsync()
        {
            flowLayoutPanelTableTeams.Controls.Clear();

            var matches = Program.context.Matches.AsNoTracking()
                .Where(m => m.MatchDate < DateTime.Now && m.ScoreHome != null && m.ScoreAway != null)
                .ToList();

            var stats = new Dictionary<int, TeamStats>();

            foreach (var team in Program.context.Teams.AsNoTracking().ToList())
            {
                stats[team.IdTeam] = new TeamStats
                {
                    TeamId = team.IdTeam,
                    TeamName = team.TeamName,
                    LogoPath = team.Logo
                };
            }

            foreach (var m in matches)
            {
                var home = stats[m.TeamHomeId.Value];
                home.Games++;
                home.Goals += m.ScoreHome.Value;
                if (m.ScoreHome > m.ScoreAway) home.Wins++;
                else if (m.ScoreHome == m.ScoreAway) home.Draws++;
                else home.Losses++;

                var away = stats[m.TeamAwayId.Value];
                away.Games++;
                away.Goals += m.ScoreAway.Value;
                if (m.ScoreAway > m.ScoreHome) away.Wins++;
                else if (m.ScoreAway == m.ScoreHome) away.Draws++;
                else away.Losses++;
            }

            var sortedTable = stats.Values
                .Select(t => new
                {
                    t.TeamId,
                    t.TeamName,
                    t.LogoPath,
                    t.Games,
                    t.Wins,
                    t.Draws,
                    t.Losses,
                    t.Goals,
                    Points = (t.Wins * 3) + t.Draws
                })
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.Goals)
                .ToList();

            flowLayoutPanelTableTeams.FlowDirection = FlowDirection.LeftToRight;

            var loadTasks = new List<Task>();

            for (int i = 0; i < sortedTable.Count; i++)
            {
                var row = sortedTable[i];
                var control = new TableTeamsControl();

                control.Width = flowLayoutPanelTableTeams.Width - 20;
                control.MinimumSize = new Size(control.Width, 55);

                // Запускаем загрузку данных в фоне
                loadTasks.Add(control.LoadTeamDataAsync(
                    position: i + 1,
                    teamName: row.TeamName,
                    logoPath: row.LogoPath,
                    games: row.Games,
                    wins: row.Wins,
                    draws: row.Draws,
                    losses: row.Losses,
                    points: row.Points
                ));

                flowLayoutPanelTableTeams.Controls.Add(control);
            }

            await Task.WhenAll(loadTasks);
        }

        // Вспомогательный класс для накопления данных
        private class TeamStats
        {
            public int TeamId { get; set; }
            public string TeamName { get; set; }
            public string LogoPath { get; set; }
            public int Games { get; set; }
            public int Wins { get; set; }
            public int Draws { get; set; }
            public int Losses { get; set; }
            public int Goals { get; set; }
        }

        private void MainDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult confirm = MessageBox.Show(
                    "Вы действительно хотите выйти из системы?",
                    "Подтверждение выхода",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    UserSession.CurrentUser = null;
                    UserSession.HasSeenTomorrowNotification = false;
                    timerMatchStats.Stop();
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
