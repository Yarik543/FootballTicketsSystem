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
    public partial class CreateTransfersAdminForm : Form
    {
        Transfers _transfer;

        List <Transfers> transfers = Program.context.Transfers.ToList();
        private bool _isEditMode = false;
        public CreateTransfersAdminForm()
        {
            InitializeComponent();
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
            _transfer = new Transfers();
            labelCountTransfers.Text = Program.context.Transfers.Count().ToString();
            _isEditMode = false;
            Program.context.Transfers.Add(_transfer);
        }
        public CreateTransfersAdminForm(Transfers transfers)

        {
            InitializeComponent();
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
            _transfer = transfers;
            transfersBindingSource.DataSource = _transfer;
            _isEditMode = true;
        }

        /// <summary>
        /// Заполняет поля формы данными трансфера
        /// </summary>
        private void LoadTransferData()
        {
            // === КОМАНДА ===
            List<Teams> teams = Program.context.Teams.OrderBy(t => t.TeamName).ToList();

            teamNowComboBox.DataSource = null;
            teamNowComboBox.DataSource = teams;
            teamNowComboBox.DisplayMember = "TeamName";
            teamNowComboBox.ValueMember = "IdTeam";

            // Сначала привязка, ПОТОМ выбор значения
            if (_transfer.ToTeamId.HasValue)
            {
                teamNowComboBox.SelectedValue = _transfer.ToTeamId.Value;
            }

            // Остальные поля
            tBoxTeamFrom.Text = _transfer.FromTeamName ?? "";
            priceTransferNumericUpDown.Value = _transfer.Price ?? 0m;
            dateTimePickerTransfer.Value = _transfer.DateTransfer ?? DateTime.Now;

            // === ИГРОК ===
            if (_transfer.PlayerId.HasValue)
            {
                var player = Program.context.Players.Find(_transfer.PlayerId.Value);
                if (player != null && player.TeamId.HasValue)
                {
                    // Загружаем игроков команды, не фильтруя текущего
                    LoadPlayersByTeam(player.TeamId.Value, excludePlayerId: _transfer.PlayerId.Value);

                    // Выбираем игрока ПОСЛЕ загрузки списка
                    if (comboBoxPlayers.Items.Count > 0)
                    {
                        comboBoxPlayers.SelectedValue = _transfer.PlayerId.Value;
                    }
                }
            }

            labelCountTransfers.Text = Program.context.Transfers.Count().ToString();
        }

        /// <summary>
        /// Фон + границы формы
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiPainter.DrawGradientBackground(this, e);
        }

        private void CreateTransfersAdminForm_Load(object sender, EventArgs e)
        {

            if (_isEditMode)
            {
                // 👇 Режим редактирования — загружаем данные
                LoadTransferData();
            }
            else
            {
                // 👇 Режим создания — базовая настройка
                List<Teams> teams = Program.context.Teams.OrderBy(t => t.TeamName).ToList();

                teamNowComboBox.DataSource = null;
                teamNowComboBox.DataSource = teams;
                teamNowComboBox.DisplayMember = "TeamName";
                teamNowComboBox.ValueMember = "IdTeam";
                teamNowComboBox.SelectedIndex = -1;
                teamNowComboBox.Text = "Выберите команду...";

                comboBoxPlayers.Enabled = false;
                comboBoxPlayers.Text = "Сначала выберите команду...";
            }
        }

        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void teamNowComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTeam = teamNowComboBox.SelectedItem as Teams;

            if (selectedTeam == null)
            {
                comboBoxPlayers.DataSource = null;
                comboBoxPlayers.Text = "Сначала выберите команду...";
                comboBoxPlayers.Enabled = false;
                return;
            }

            int teamId = selectedTeam.IdTeam;
            LoadPlayersByTeam(teamId);
        }

        private void LoadPlayersByTeam(int teamId, int? excludePlayerId = null)
        {
            var playersQuery = Program.context.Players.Where(p => p.TeamId == teamId);

            if (excludePlayerId.HasValue)
            {
                // В режиме редактирования: исключаем всех с трансфером, КРОМЕ текущего игрока
                playersQuery = playersQuery.Where(p =>
                    p.IdPlayer == excludePlayerId.Value ||
                    !Program.context.Transfers.Any(t => t.PlayerId == p.IdPlayer));
            }
            else
            {
                // В режиме создания: исключаем всех, у кого уже есть трансфер
                playersQuery = playersQuery.Where(p =>
                    !Program.context.Transfers.Any(t => t.PlayerId == p.IdPlayer));
            }

            List<Players> players = playersQuery.OrderBy(p => p.FullName).ToList();

            if (players.Count == 0)
            {
                comboBoxPlayers.DataSource = null;
                comboBoxPlayers.Text = "Нет свободных игроков";
                comboBoxPlayers.Enabled = false;
                return;
            }

            // 👇 ВАЖНЫЙ ПОРЯДОК:
            comboBoxPlayers.DataSource = null;           // 1. Сброс
            comboBoxPlayers.DataSource = players;        // 2. Новый источник
            comboBoxPlayers.DisplayMember = "FullName";  // 3. Что показывать
            comboBoxPlayers.ValueMember = "IdPlayer";    // 4. Какое значение брать
            comboBoxPlayers.Enabled = true;              // 5. Включаем
                                                         // 👇 SelectedValue ставится ВНЕ этого метода, после вызова!
        }

        private void FieldModels()
        {
            if (teamNowComboBox.SelectedValue != null)
                _transfer.ToTeamId = (int)teamNowComboBox.SelectedValue;
            _transfer.FromTeamName = tBoxTeamFrom.Text.Trim();
            _transfer.Price = priceTransferNumericUpDown.Value;
            _transfer.DateTransfer = dateTimePickerTransfer.Value;
            if (comboBoxPlayers.SelectedValue != null)
                _transfer.PlayerId = (int)comboBoxPlayers.SelectedValue;
        }

        private void btnSaveTransfer_Click(object sender, EventArgs e)
        {
            DialogResult agree = MessageBox.Show("Уверены, что хотите сохранить?", "Запрос подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (agree == DialogResult.No)
            {
                return;
            }

            try
            {
                FieldModels();
                Program.context.SaveChanges();
                DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
