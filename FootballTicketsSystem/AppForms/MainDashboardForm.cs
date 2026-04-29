using FootballTicketsSystem.AppControls;
using FootballTicketsSystem.AppServices;
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
        private int? _currentMatchId = null; // Запоминаем ID текущего матча
        private int? _currentTeamsStatsMatchId = null; //  Для статистики
        private DateTime _lastTeamsStatsUpdate = DateTime.MinValue; //  Новое поле
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

        private void MainDashboardForm_Load(object sender, EventArgs e)
        {
            labelUserBack.Text += UserSession.CurrentUser.FullName;
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;

            // Загружаем всё сразу
            LoadNextMatch();
            LoadTeamsStatistics(); // Установит _currentTeamsStatsMatchId
            LoadMatchStatistics();
            LoadLastThreeMatchesAll();
            LoadTeamsTable();

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
            if (profilDialog == DialogResult.OK)
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

        /// <summary>
        /// Загрузка следующего матча (через Program.context)
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

            // Если матч не изменился — не перезагружаем команды
            if (nextMatch?.IdMatch == _currentMatchId)
            {
                return false; // Матч тот же
            }

            // Матч изменился (или первый запуск) — обновляем всё
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

                // Логотипы
                if (nextMatch.Teams != null && !string.IsNullOrEmpty(nextMatch.Teams.Logo))
                    _ = ImageLoader.LoadToPictureBoxAsync(pictureBoxLogoFirstTeam, nextMatch.Teams.Logo, Properties.Resources.picture);
                else
                    pictureBoxLogoFirstTeam.Image = Properties.Resources.picture;

                if (nextMatch.Teams1 != null && !string.IsNullOrEmpty(nextMatch.Teams1.Logo))
                    _ = ImageLoader.LoadToPictureBoxAsync(pictureBoxLogoSecondTeam, nextMatch.Teams1.Logo, Properties.Resources.picture);
                else
                    pictureBoxLogoSecondTeam.Image = Properties.Resources.picture;

                return true; // Матч обновился
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
            // Ищем ТЕКУЩИЙ активный матч (с учетом 2-часового буфера)
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

            // Если матч для статистики не изменился — не обновляем
            if (currentMatch.IdMatch == _currentTeamsStatsMatchId)
            {
                return;
            }

            _currentTeamsStatsMatchId = currentMatch.IdMatch;

            int team1Id = currentMatch.Teams.IdTeam;
            int team2Id = currentMatch.Teams1.IdTeam;

            // Названия команд
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

            // Считаем статистику
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

            // Обновляем цифры
            labelCountTeamFirstWin.Text = team1Wins.ToString();
            labelCountTeamSecondWin.Text = team2Wins.ToString();
            labelDrawsCount.Text = draws.ToString();
            labelLastGame.Text = "Последние игры: " + lastMatches.Count.ToString();

            // Обновляем прогресс-бар
            UpdateStatsBars(team1Wins, team2Wins, draws, lastMatches.Count);
        }


        /// <summary>
        /// Обновляет ширину цветных панелей статистики
        /// </summary>
        private void UpdateStatsBars(int team1Wins, int team2Wins, int draws, int totalGames)
        {
            // Если нет игр, очищаем всё
            if (totalGames == 0)
            {
                panelTeam1Win.Width = 0;
                panelDraw.Width = 0;
                panelTeam2Win.Width = 0;
                return;
            }

            // Общая ширина контейнера (берем текущую ширину родительской панели)
            int totalWidth = panelStatsContainer.Width;

            // Считаем ширину каждой части пропорционально количеству
            // Формула: (Победы * Общая Ширина) / Всего Игр
            panelTeam1Win.Width = (team1Wins * totalWidth) / totalGames;
            panelDraw.Width = (draws * totalWidth) / totalGames;
            panelTeam2Win.Width = (team2Wins * totalWidth) / totalGames;
        }

        private void timerMatchStats_Tick(object sender, EventArgs e)
        {
            // 1. Всегда обновляем билеты/таймер
            LoadMatchStatistics();

            // 2. Проверяем, не сменился ли матч
            bool matchChanged = LoadNextMatch();

            // 3. Если матч сменился — обновляем статистику команд
            if (matchChanged)
            {
                LoadTeamsStatistics();
                LoadLastThreeMatchesAll(); // Обновляем последние результаты при смене матча
                LoadTeamsTable();
            }
        }

        private void LoadMatchStatistics()
        {
            //  1. Вычисляем пороговое время ДО запроса
            var thresholdTime = DateTime.Now.AddHours(-2);

            //  2. Используем переменную в Where
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

            // ==========================================
            // УМНОЕ ОТОБРАЖЕНИЕ ВРЕМЕНИ
            // ==========================================
            if (timeLeft.TotalSeconds <= 0)
            {
                // ⚽ МАТЧ НАЧАЛСЯ
                labelTimerMatch.Text = "⚽ Матч идет";
                labelTimerMatch.ForeColor = Color.FromArgb(0, 200, 150); // Зелёный
            }
            else if (timeLeft.TotalMinutes < 1)
            {
                // ⏱ ПОСЛЕДНЯЯ МИНУТА — показываем секунды
                int seconds = (int)timeLeft.TotalSeconds;
                labelTimerMatch.Text = $"{seconds} сек";
                labelTimerMatch.ForeColor = Color.FromArgb(255, 62, 62); // Красный (срочно!)
            }
            else if (timeLeft.TotalHours < 1)
            {
                // ⏰ МЕНЬШЕ ЧАСА — показываем минуты
                int minutes = (int)timeLeft.TotalMinutes;
                labelTimerMatch.Text = $"{minutes} мин";
                labelTimerMatch.ForeColor = Color.FromArgb(255, 193, 7); // Жёлтый
            }
            else if (timeLeft.TotalDays < 1)
            {
                // 📅 МЕНЬШЕ СУТОК — показываем часы
                int hours = (int)timeLeft.TotalHours;
                labelTimerMatch.Text = $"{hours} ч";
                labelTimerMatch.ForeColor = Color.Black;
            }
            else
            {
                // 📆 БОЛЬШЕ ДНЯ — показываем дни
                int days = (int)timeLeft.TotalDays;
                labelTimerMatch.Text = $"{days} дн";
                labelTimerMatch.ForeColor = Color.Gray;
            }

            // ==========================================
            // ОСТАЛЬНАЯ СТАТИСТИКА (без изменений)
            // ==========================================
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
            // Обновляем следующий матч и статистику команд
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
            // Получаем 3 самых свежих завершенных матча
            var lastMatches = Program.context.Matches
                .AsNoTracking()
                .Include(m => m.Teams)        // Домашняя команда
                .Include(m => m.Teams1)       // Гостевая команда
                .Where(m => m.MatchDate < DateTime.Now && m.ScoreHome != null && m.ScoreAway != null)
                .OrderByDescending(m => m.MatchDate)
                .Take(3)
                .ToList();

            // Заполняем label'ы
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
                    // Если матчей меньше 3 — ставим прочерки
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
        /// Загружает турнирную таблицу команд
        /// </summary>
        private void LoadTeamsTable()
        {
            flowLayoutPanelTableTeams.Controls.Clear();

            // 1. Получаем все завершенные матчи с известным счетом
            var matches = Program.context.Matches.AsNoTracking()
                .Where(m => m.MatchDate < DateTime.Now && m.ScoreHome != null && m.ScoreAway != null)
                .ToList();

            // 2. Словарь для накопления статистики по каждой команде
            var stats = new Dictionary<int, TeamStats>();

            // Инициализируем ВСЕ команды из БД (даже те, у кого пока 0 матчей)
            foreach (var team in Program.context.Teams.AsNoTracking().ToList())
            {
                stats[team.IdTeam] = new TeamStats
                {
                    TeamId = team.IdTeam,
                    TeamName = team.TeamName,
                    LogoPath = team.Logo
                };
            }

            // 3. Проходим по матчам и считаем показатели
            foreach (var m in matches)
            {
                // --- Домашняя команда ---
                var home = stats[m.TeamHomeId.Value];
                home.Games++;
                home.Goals += m.ScoreHome.Value;
                if (m.ScoreHome > m.ScoreAway) home.Wins++;
                else if (m.ScoreHome == m.ScoreAway) home.Draws++;
                else home.Losses++;

                // --- Гостевая команда ---
                var away = stats[m.TeamAwayId.Value];
                away.Games++;
                away.Goals += m.ScoreAway.Value;
                if (m.ScoreAway > m.ScoreHome) away.Wins++;
                else if (m.ScoreAway == m.ScoreHome) away.Draws++;
                else away.Losses++;
            }

            // 4. Вычисляем очки и сортируем таблицу
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
                    Points = (t.Wins * 3) + t.Draws // 👈 ФОРМУЛА ОЧКОВ
                })
                .OrderByDescending(x => x.Points)      // 1. По очкам
                .ThenByDescending(x => x.Goals)        // 2. При равенстве очков → по забитым голам
                .ToList();

            flowLayoutPanelTableTeams.FlowDirection = FlowDirection.LeftToRight;

            // 5. Создаем и добавляем UserControl для каждой команды
            for (int i = 0; i < sortedTable.Count; i++)
            {
                var row = sortedTable[i];
                var control = new TableTeamsControl();

                // Установи фиксированную ширину контрола
                control.Width = flowLayoutPanelTableTeams.Width - 20; // -20 для отступа
                control.MinimumSize = new Size(control.Width, 50);

                // Заполняем данные (убедись, что label'ы в контроле имеют модификатор Public или Internal)
                control.labelNumberTable.Text = (i + 1).ToString();
                control.labelTeamName.Text = row.TeamName;
                control.labelGamesCount.Text = row.Games.ToString();
                control.labelWinCount.Text = row.Wins.ToString();
                control.labelDrawCount.Text = row.Draws.ToString();
                control.labelLostCount.Text = row.Losses.ToString();
                control.labelGoalsCount.Text = row.Goals.ToString();
                control.labelPointsCoint.Text = row.Points.ToString();

                // Загружаем логотип
                if (!string.IsNullOrEmpty(row.LogoPath))
                    ImageLoader.LoadToPictureBoxAsync(control.pictureBoxLogoTeam, row.LogoPath, Properties.Resources.picture);
                else
                    control.pictureBoxLogoTeam.Image = Properties.Resources.picture;

                flowLayoutPanelTableTeams.Controls.Add(control);
            }
        }

        // Вспомогательный класс для накопления данных (можно разместить внутри формы)
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
    }
}
