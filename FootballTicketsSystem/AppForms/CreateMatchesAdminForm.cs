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

namespace FootballTicketsSystem.AppForms
{
    public partial class CreateMatchesAdminForm : Form
    {
        Matches _match;
        private bool _isEditMode = false;
        public CreateMatchesAdminForm()
        {
            InitializeComponent();
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
            _match = new Matches();
            Program.context.Matches.Add(_match);
            _isEditMode = false;
        }

        public CreateMatchesAdminForm(Matches matches)
        {
            InitializeComponent();
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
            _match = matches;
            matchesBindingSource.DataSource = _match;
            _isEditMode = true;
        }

        /// <summary>
        /// Фон + границы формы
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiPainter.DrawGradientBackground(this, e);
        }

        private void matchesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.matchesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.footballTicketSystemDataSet);
        }

        private void CreateMatchesAdminForm_Load(object sender, EventArgs e)
        {
            LoadTeams();
            LoadStadiums();
            LoadStages();
            
            if (_isEditMode)
            {
                LoadMatchData();
            }
        }

        /// <summary>
        /// Загружает команды в ComboBox
        /// </summary>
        private void LoadTeams()
        {
            var teams = Program.context.Teams
                .OrderBy(t => t.TeamName)
                .ToList();

            // Домашняя команда
            comboBoxTeamHome.DataSource = teams.ToList();
            comboBoxTeamHome.DisplayMember = "TeamName";
            comboBoxTeamHome.ValueMember = "IdTeam";
            comboBoxTeamHome.SelectedIndex = -1;
            comboBoxTeamHome.Text = "Выберите команду...";

            // Гостевая команда
            comboBoxTeamAway.DataSource = teams.ToList();
            comboBoxTeamAway.DisplayMember = "TeamName";
            comboBoxTeamAway.ValueMember = "IdTeam";
            comboBoxTeamAway.SelectedIndex = -1;
            comboBoxTeamAway.Text = "Выберите команду...";
        }

        /// <summary>
        /// Загружает стадионы в ComboBox
        /// </summary>
        private void LoadStadiums()
        {
            var stadiums = Program.context.Stadiums
                .OrderBy(s => s.NameStadium)
                .ToList();

            comboBoxStadium.DataSource = stadiums;
            comboBoxStadium.DisplayMember = "NameStadium";
            comboBoxStadium.ValueMember = "IdStadium";
            comboBoxStadium.SelectedIndex = -1;
            comboBoxStadium.Text = "Выберите стадион...";
        }

        /// <summary>
        /// Загружает этапы матча в ComboBox
        /// </summary>
        private void LoadStages()
        {
            comboBoxStage.SelectedIndex = 0; // По умолчанию "Чемпионат"
        }

        /// <summary>
        /// Загружает данные матча при редактировании
        /// </summary>
        private void LoadMatchData()
        {
            // Команды
            if (_match.TeamHomeId.HasValue)
                comboBoxTeamHome.SelectedValue = _match.TeamHomeId.Value;

            if (_match.TeamAwayId.HasValue)
                comboBoxTeamAway.SelectedValue = _match.TeamAwayId.Value;

            // Стадион
            if (_match.StadiumId.HasValue)
                comboBoxStadium.SelectedValue = _match.StadiumId.Value;

            // Счета (показываем только если есть)
            if (_match.ScoreHome.HasValue)
            {
                numericUpDownScoreHome.Value = _match.ScoreHome.Value;
                numericUpDownScoreHome.Visible = true; // Показываем поля счета
            }

            if (_match.ScoreAway.HasValue)
            {
                numericUpDownScoreAway.Value = _match.ScoreAway.Value;
                numericUpDownScoreAway.Visible = true;
            }

            // Дата
            if (_match.MatchDate.HasValue)
                dateTimePickerMatch.Value = _match.MatchDate.Value;

            // Рейтинг
            if (_match.RatingMatch.HasValue)
                numericUpDownRating.Value = (decimal)_match.RatingMatch.Value;

            // Этап
            if (!string.IsNullOrEmpty(_match.Stage))
                comboBoxStage.Text = _match.Stage;
        }

        /// <summary>
        /// Сохраняет данные из формы в объект матча
        /// </summary>
        private void SaveMatchData()
        {
            // Команды
                _match.TeamHomeId = (int)comboBoxTeamHome.SelectedValue;
                _match.TeamAwayId = (int)comboBoxTeamAway.SelectedValue;

            // Стадион
                _match.StadiumId = (int)comboBoxStadium.SelectedValue;

            // Счета (только если поля видимы - значит матч завершен)
            if (numericUpDownScoreHome.Visible)
                _match.ScoreHome = (int)numericUpDownScoreHome.Value;

            if (numericUpDownScoreAway.Visible)
                _match.ScoreAway = (int)numericUpDownScoreAway.Value;

            // Дата
            _match.MatchDate = dateTimePickerMatch.Value;

            // Рейтинг
            _match.RatingMatch = numericUpDownRating.Value;

            // Этап
            _match.Stage = comboBoxStage.Text;
        }

        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveMatch_Click(object sender, EventArgs e)
        {
            // Подтверждение сохранения
            DialogResult agree = MessageBox.Show(
                "Уверены, что хотите сохранить матч?",
                "Запрос подтверждения",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (agree == DialogResult.No)
                return;

            try
            {
                SaveMatchData();
                Program.context.SaveChanges();

                MessageBox.Show(
                    "Матч успешно сохранен!",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при сохранении: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dateTimePickerMatch_ValueChanged(object sender, EventArgs e)
        {
            // Если дата матча уже прошла — показываем поля для ввода счёта
            if (dateTimePickerMatch.Value < DateTime.Now)
            {
                labelScoreTeamHome.Visible = true;
                labelScoreTeamAway.Visible = true;  // 👈 Не забудь про второй label!
                numericUpDownScoreHome.Visible = true;
                numericUpDownScoreAway.Visible = true;
            }
            else
            {
                // Если матч в будущем — скрываем поля счёта
                labelScoreTeamHome.Visible = false;
                labelScoreTeamAway.Visible = false;
                numericUpDownScoreHome.Visible = false;
                numericUpDownScoreAway.Visible = false;
            }
        }

        private void comboBoxTeamHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, не выбрана ли та же команда
            if (comboBoxTeamHome.SelectedValue != null && comboBoxTeamAway.SelectedValue != null)
            {
                if (comboBoxTeamHome.SelectedValue.Equals(comboBoxTeamAway.SelectedValue))
                {
                    MessageBox.Show("Нельзя выбрать ту же команду! Выберите другую.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxTeamAway.SelectedIndex = -1;
                    return;
                }
            }
        }

        private void comboBoxTeamAway_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, не выбрана ли та же команда
            if (comboBoxTeamHome.SelectedValue != null && comboBoxTeamAway.SelectedValue != null)
            {
                if (comboBoxTeamHome.SelectedValue.Equals(comboBoxTeamAway.SelectedValue))
                {
                    MessageBox.Show("Нельзя выбрать ту же команду! Выберите другую.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxTeamAway.SelectedIndex = -1;
                    return;
                }
            }
        }
    }
}
