using FootballTicketsSystem.AppForms;
using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
using FootballTicketsSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppControls
{
    public partial class MatchControl : UserControl
    {
        Matches _match;
        public MatchControl(Matches match)
        {
            InitializeComponent();
            _match = match;
            SetDataLabel();
            if(UserSession.CurrentUser.IsAdmin())
            {
                btnDeleteMatch.Visible = true;
            }
            btnDeleteMatch.Cursor = Cursors.Hand;
            
        }

        private async Task SetDataLabel()
        {
            // Проверка на null важна, если связи не загрузились (Include)
            string homeTeamName = _match.Teams?.TeamName ?? "Команда 1";
            string awayTeamName = _match.Teams1?.TeamName ?? "Команда 2";

            labelTeamNameFirst.Text = homeTeamName;  // Хозяева (слева)
            labelTeamNameSecond.Text = awayTeamName; // Гости (справа)

            // 2. Дата и время
            if (_match.MatchDate.HasValue)
            {
                DateTime date = _match.MatchDate.Value;
                // Формат: 12.10.2026
                labelDataMatch.Text = date.ToString("dd.MM.yyyy");
                // Формат: 21:00
                labelTimeMatch.Text = date.ToString("HH:mm");

                // 👇 Проверяем, можно ли купить билет
                UpdateBuyButtonState(date);
            }
            else
            {
                labelDataMatch.Text = "--.--.----";
                labelTimeMatch.Text = "--:--";
            }

            // 3. Стадион
            if (_match.Stadiums != null)
            {
                labelStadiumName.Text = $"Стадион: {_match.Stadiums.NameStadium}";
            }
            else
            {
                labelStadiumName.Text = "Стадион: Не указан";
            }

            // 4. Счет (если матч сыгран)
            if (_match.ScoreHome.HasValue && _match.ScoreAway.HasValue)
            {
                labelScore.Text = $"{_match.ScoreHome.Value} : {_match.ScoreAway.Value}";
                labelScore.Visible = true;
                pictureBoxVs.Visible = false; // Скрываем VS, показываем счет
            }
            else
            {
                labelScore.Visible = false;
                pictureBoxVs.Visible = true; // Показываем VS, если счет еще нет
            }

            await LoadLogosAsync();

            // 👇 Сначала обновляем информацию о заполненности
            UpdateCapacityInfo();

            // 👇 Потом обновляем состояние кнопки (она использует данные о заполненности)
            if (_match.MatchDate.HasValue)
            {
                UpdateBuyButtonState(_match.MatchDate.Value);
            }
        }

        /// <summary>
        /// Обновляет состояние кнопки покупки билета
        /// </summary>
        private void UpdateBuyButtonState(DateTime matchDate)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeUntilMatch = matchDate - now;

            //  Матч уже прошёл
            if (matchDate < now)
            {
                DisableBuyButton("Матч завершён");
                return;
            }

            //  Матч начинается менее чем через 1 час
            if (timeUntilMatch.TotalHours < 1)
            {
                if (timeUntilMatch.TotalMinutes < 1)
                {
                    DisableBuyButton("Матч начинается!");
                }
                else
                {
                    DisableBuyButton($"Осталось {Math.Ceiling(timeUntilMatch.TotalMinutes)} мин");
                }
                return;
            }

            if (IsStadiumFull())
            {
                DisableBuyButton("Аншлаг! Все места распроданы");
                return;
            }

            //  Можно покупать
            EnableBuyButton();
        }

        /// <summary>
        /// Проверяет, заполнен ли стадион на 100%
        /// </summary>
        private bool IsStadiumFull()
        {
            if (_match?.Stadiums == null) return false;

            int capacity = _match.Stadiums.Capacity ?? 0;
            if (capacity <= 0) return false;

            int soldCount = Program.context.Tickets
                .Count(t => t.MatchId == _match.IdMatch && t.IsSold == true);

            return soldCount >= capacity;
        }

        /// <summary>
        /// Отключает кнопку покупки
        /// </summary>
        private void DisableBuyButton(string reason)
        {
            btnBuyTicket.Enabled = false;
            btnBuyTicket.FillColor = Color.FromArgb(180, 180, 180); // Серый
            btnBuyTicket.ForeColor = Color.Gray;
            btnBuyTicket.Text = "Недоступно";
            btnBuyTicket.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Включает кнопку покупки
        /// </summary>
        private void EnableBuyButton()
        {
            btnBuyTicket.Enabled = true;
            btnBuyTicket.FillColor = Color.FromArgb(20, 184, 134); // Зелёный
            btnBuyTicket.ForeColor = Color.White;
            btnBuyTicket.Text = "Купить билет";
            btnBuyTicket.Cursor = Cursors.Hand;
        }

        private async Task LoadLogosAsync()
        {
            // Загружаем параллельно
            var task1 = ImageLoader.LoadToPictureBoxAsync(
                pictureBoxLogoFirstTeam,
                _match.Teams?.Logo,
                Properties.Resources.picture);

            var task2 = ImageLoader.LoadToPictureBoxAsync(
                pictureBoxTeamLogoAway,
                _match.Teams1?.Logo,
                Properties.Resources.picture);

            await Task.WhenAll(task1, task2);
        }

        /// <summary>
        /// скругление углов у userControl
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int radius = 20;

            var path = new System.Drawing.Drawing2D.GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
            path.AddArc(0, Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }

        private void btnBuyTicket_Click(object sender, EventArgs e)
        {
            // 👇 Дополнительная проверка на всякий случай
            if (!btnBuyTicket.Enabled) return;
            TicketBuyForm ticketBuyForm = new TicketBuyForm(_match);
            DialogResult dialogResult = ticketBuyForm.ShowDialog();
        }

        /// <summary>
        /// Обновляет информацию о заполненности стадиона
        /// </summary>
        /// <summary>
        /// Обновляет информацию о заполненности стадиона
        /// </summary>
        /// <summary>
        /// Обновляет информацию о заполненности стадиона
        /// </summary>
        private void UpdateCapacityInfo()
        {
            if (_match == null) return;

            int soldCount = Program.context.Tickets
                .Count(t => t.MatchId == _match.IdMatch && t.IsSold == true);

            int capacity = _match.Stadiums?.Capacity ?? 0;
            int percentage = capacity > 0 ? Math.Min((soldCount * 100) / capacity, 100) : 0;

            if (labelCapacity != null)
            {
                labelCapacity.Text = $"{percentage}%";

                if (percentage < 30)
                {
                    labelCapacity.ForeColor = Color.FromArgb(20, 184, 134);
                }
                else if (percentage < 70)
                {
                    labelCapacity.ForeColor = Color.FromArgb(255, 193, 7);
                }
                else if (percentage < 100)
                {
                    labelCapacity.ForeColor = Color.FromArgb(255, 140, 0);
                }
                else
                {
                    labelCapacity.ForeColor = Color.FromArgb(223, 111, 138);
                }
            }
        }


        private void btnDeleteMatch_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Уверены что хотите удалить?", "Запрос подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delete == DialogResult.No) return;

            try
            {
                var matchToDelete = Program.context.Matches
                    .Include(m => m.Tickets) 
                    .FirstOrDefault(m => m.IdMatch == _match.IdMatch);

                if (matchToDelete != null)
                {
                    // Сначала удаляем связанные билеты (если есть)
                    if (matchToDelete.Tickets?.Any() == true)
                    {
                        Program.context.Tickets.RemoveRange(matchToDelete.Tickets);
                    }

                    // Потом удаляем сам матч
                    Program.context.Matches.Remove(matchToDelete);
                    Program.context.SaveChanges();

                    ContextManager.calendarForm?.LoadDataMatch();
                    MessageBox.Show("✅ Матч успешно удалён", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n\n{ex.InnerException?.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxVs_Click(object sender, EventArgs e)
        {
            if(UserSession.CurrentUser.Roles.RoleName == "Администратор")
            {
                CreateMatchesAdminForm createMatchesAdminForm = new CreateMatchesAdminForm(_match);
                DialogResult createMatch = createMatchesAdminForm.ShowDialog();
                if (createMatch == DialogResult.OK)
                {
                    ContextManager.calendarForm.LoadDataMatch();
                }
            }
            
        }
    }
}
