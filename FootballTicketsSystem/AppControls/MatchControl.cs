using FootballTicketsSystem.AppForms;
using FootballTicketsSystem.DBModels;
using FootballTicketsSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            TicketBuyForm ticketBuyForm = new TicketBuyForm();
            DialogResult dialogResult = ticketBuyForm.ShowDialog();
        }
    }
}
