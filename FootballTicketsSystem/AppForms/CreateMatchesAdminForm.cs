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
            _isEditMode = false;

            UpdateStatistics();
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

            UpdateStatistics();
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
            dateTimePickerMatch.Format = DateTimePickerFormat.Custom;
            dateTimePickerMatch.CustomFormat = "dd MMMM yyyy г., HH:mm";
            dateTimePickerMatch.ShowUpDown = true;

            DateTime tomorrow = DateTime.Now.Date.AddDays(1).AddHours(21);
            DateTime safeMaxDate = new DateTime(2100, 12, 31);

            if (_isEditMode)
            {
                if (_match.MatchDate.HasValue)
                {
                    DateTime matchDate = _match.MatchDate.Value;

                    DateTime minDate = matchDate < DateTime.Now ? matchDate : tomorrow;

                    dateTimePickerMatch.MinDate = minDate;
                    dateTimePickerMatch.MaxDate = safeMaxDate;
                    dateTimePickerMatch.Value = matchDate;
                }
                else
                {
                    dateTimePickerMatch.MinDate = tomorrow;
                    dateTimePickerMatch.MaxDate = safeMaxDate;
                    dateTimePickerMatch.Value = tomorrow;
                }
            }
            else
            {
                dateTimePickerMatch.MinDate = tomorrow;
                dateTimePickerMatch.MaxDate = safeMaxDate;
                dateTimePickerMatch.Value = tomorrow;
            }

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

            comboBoxTeamHome.DataSource = teams.ToList();
            comboBoxTeamHome.DisplayMember = "TeamName";
            comboBoxTeamHome.ValueMember = "IdTeam";
            comboBoxTeamHome.SelectedIndex = -1;
            comboBoxTeamHome.Text = "Выберите команду...";

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
            comboBoxStage.SelectedIndex = 0;
        }

        /// <summary>
        /// Загружает данные матча при редактировании
        /// </summary>
        private void LoadMatchData()
        {
            if (_match.TeamHomeId.HasValue)
                comboBoxTeamHome.SelectedValue = _match.TeamHomeId.Value;

            if (_match.TeamAwayId.HasValue)
                comboBoxTeamAway.SelectedValue = _match.TeamAwayId.Value;

            if (_match.StadiumId.HasValue)
                comboBoxStadium.SelectedValue = _match.StadiumId.Value;

            bool isMatchPlayed = _match.MatchDate.HasValue && _match.MatchDate.Value < DateTime.Now;

            if (isMatchPlayed || _match.ScoreHome.HasValue || _match.ScoreAway.HasValue)
            {
                labelScoreTeamHome.Visible = true;
                labelScoreTeamAway.Visible = true;
                numericUpDownScoreHome.Visible = true;
                numericUpDownScoreAway.Visible = true;

                if (_match.ScoreHome.HasValue)
                    numericUpDownScoreHome.Value = _match.ScoreHome.Value;

                if (_match.ScoreAway.HasValue)
                    numericUpDownScoreAway.Value = _match.ScoreAway.Value;
            }
            else
            {
                labelScoreTeamHome.Visible = false;
                labelScoreTeamAway.Visible = false;
                numericUpDownScoreHome.Visible = false;
                numericUpDownScoreAway.Visible = false;
            }


            if (_match.RatingMatch.HasValue)
                numericUpDownRating.Value = (decimal)_match.RatingMatch.Value;

            if (!string.IsNullOrEmpty(_match.Stage))
                comboBoxStage.Text = _match.Stage;

            dateTimePickerMatch_ValueChanged(null, EventArgs.Empty);
        }

        /// <summary>
        /// Проверяет, можно ли сохранить матч с выбранной датой
        /// </summary>
        private bool ValidateMatchDate()
        {
            DateTime selectedDate = dateTimePickerMatch.Value;
            DateTime minAllowedDate = DateTime.Now.Date.AddDays(1).AddHours(21); 

            if (_isEditMode && _match.MatchDate.HasValue && _match.MatchDate.Value < DateTime.Now)
            {
                return true;
            }

            if (selectedDate < minAllowedDate)
            {
                MessageBox.Show(
                     $"❌ Нельзя создать матч ранее чем через 24 часа\n\n" +
                     $"Минимальная дата: {minAllowedDate:dd.MM.yyyy HH:mm}\n" +
                     $"Выбранная дата: {selectedDate:dd.MM.yyyy HH:mm}\n\n" +
                     "Пожалуйста, выберите более позднюю дату.",
                     "Ошибка валидации",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        /// <summary>
        /// Сохраняет данные из формы в объект матча
        /// </summary>
        private void SaveMatchData()
        {
            if (comboBoxTeamHome.SelectedValue != null)
                _match.TeamHomeId = (int)comboBoxTeamHome.SelectedValue;

            if (comboBoxTeamAway.SelectedValue != null)
                _match.TeamAwayId = (int)comboBoxTeamAway.SelectedValue;

            if (comboBoxStadium.SelectedValue != null)
                _match.StadiumId = (int)comboBoxStadium.SelectedValue;

            DateTime matchDate = dateTimePickerMatch.Value;
            bool isMatchPlayed = matchDate < DateTime.Now;

            if (isMatchPlayed)
            {
                _match.ScoreHome = (int)numericUpDownScoreHome.Value;
                _match.ScoreAway = (int)numericUpDownScoreAway.Value;
            }
            else
            {
                if (numericUpDownScoreHome.Visible)
                    _match.ScoreHome = (int)numericUpDownScoreHome.Value;

                if (numericUpDownScoreAway.Visible)
                    _match.ScoreAway = (int)numericUpDownScoreAway.Value;
            }

            _match.MatchDate = dateTimePickerMatch.Value;

            _match.RatingMatch = numericUpDownRating.Value;

            _match.Stage = comboBoxStage.Text;
        }

        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveMatch_Click(object sender, EventArgs e)
        {
            if (comboBoxTeamHome.SelectedValue == null)
            {
                MessageBox.Show("Выберите домашнюю команду!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxTeamHome.Focus();
                return;
            }

            if (comboBoxTeamAway.SelectedValue == null)
            {
                MessageBox.Show("Выберите гостевую команду!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxTeamAway.Focus();
                return;
            }

            if (comboBoxTeamHome.SelectedValue?.Equals(comboBoxTeamAway.SelectedValue) == true)
            {
                MessageBox.Show("Команды не могут быть одинаковыми!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxStadium.SelectedValue == null)
            {
                MessageBox.Show("Выберите стадион!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxStadium.Focus();
                return;
            }

            if (!ValidateMatchDate())
            {
                return;
            }

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

                if (!_isEditMode)
                {
                    Program.context.Matches.Add(_match);
                }
                Program.context.SaveChanges();

                MessageBox.Show(
                    "Матч успешно сохранен!",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                UpdateStatistics();

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
            if (dateTimePickerMatch.Value < DateTime.Now)
            {
                labelScoreTeamHome.Visible = true;
                labelScoreTeamAway.Visible = true;
                numericUpDownScoreHome.Visible = true;
                numericUpDownScoreAway.Visible = true;
            }
            else
            {
                labelScoreTeamHome.Visible = false;
                labelScoreTeamAway.Visible = false;
                numericUpDownScoreHome.Visible = false;
                numericUpDownScoreAway.Visible = false;
            }
        }

        private void comboBoxTeamHome_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        /// <summary>
        /// Обновляет статистику на форме
        /// </summary>
        private void UpdateStatistics()
        {
            int totalMatches = Program.context.Matches.Count();
            labelCountMatches.Text = totalMatches.ToString();

            int activeMatches = Program.context.Matches
                .Count(m => m.MatchDate >= DateTime.Now ||
                            (m.ScoreHome == null && m.ScoreAway == null));
            labelActivMatches.Text = activeMatches.ToString();

            int soldTickets = Program.context.Tickets
                .Count(t => t.IsSold == true);
            labelTicketsBuy.Text = soldTickets.ToString("### ###");
        }
    }
}
