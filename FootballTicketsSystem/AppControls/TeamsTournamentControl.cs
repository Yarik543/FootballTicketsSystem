using FootballTicketsSystem.AppForms;
using FootballTicketsSystem.DBModels;
using FootballTicketsSystem.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppControls
{
    public partial class TeamsTournamentControl : UserControl
    {
        Teams _teams;
        public TeamsTournamentControl(Teams teams)
        {
            InitializeComponent();
            _teams = teams;
            // Загружаем данные асинхронно
            _ = LoadTeamDataAsync();
        }

        private async Task LoadTeamDataAsync()
        {
            SetDataLabels();
            await LoadLogoAsync();
        }

        private void SetDataLabels()
        {
            if (_teams == null) return;

            labelTeamName.Text = _teams.TeamName;
            labelCityName.Text = "Город: " + _teams.City;
            labelStadiumTeam.Text = "Стадион: " + (_teams.Stadiums?.NameStadium ?? "Не указан");
        }

        private async Task LoadLogoAsync()
        {
            // Показываем заглушку, пока грузится
            gunaPictureBoxLogoTeam.Image = Properties.Resources.picture;

            if (!string.IsNullOrEmpty(_teams.Logo))
            {
                // Используем наш ImageLoader (асинхронно + кэш)
                await ImageLoader.LoadToPictureBoxAsync(
                    gunaPictureBoxLogoTeam,
                    _teams.Logo,
                    Properties.Resources.picture);
            }
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            TeamDetailsForm teamDetailsForm = new TeamDetailsForm();
            DialogResult dialogResult = teamDetailsForm.ShowDialog();
        }
    }
}
