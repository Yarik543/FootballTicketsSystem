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
        public CreateTransfersAdminForm()
        {
            InitializeComponent();
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
            _transfer = new Transfers();
            Program.context.Transfers.Add(_transfer);
            labelCountTransfers.Text = transfers.Count.ToString();
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

            List <Teams> teams = Program.context.Teams.OrderBy(t=>t.IdTeam).ToList();
            // Настраиваем ComboBox "Текущая команда"
            teamNowComboBox.DataSource = null;
            teamNowComboBox.DataSource = teams;
            teamNowComboBox.DisplayMember = "TeamName";  
            teamNowComboBox.ValueMember = "IdTeam";   

            teamNowComboBox.SelectedIndex = -1;
            teamNowComboBox.Text = "Выберите команду...";
        }

        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void teamNowComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Безопасное получение команды
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

        private void LoadPlayersByTeam(int teamId)
        {
            // Получаем игроков:
            // 1. Из нужной команды (p.TeamId == teamId)
            // 2. У которых НЕТ записи в таблице Transfers
            List<Players> players = Program.context.Players
                .Where(p => p.TeamId == teamId &&
                           !Program.context.Transfers.Any(t => t.PlayerId == p.IdPlayer))
                .OrderBy(p => p.FullName)
                .ToList();

            if (players.Count == 0)
            {
                comboBoxPlayers.DataSource = null;
                comboBoxPlayers.Text = "Нет свободных игроков";
                comboBoxPlayers.Enabled = false;
                return;
            }

            // Настраиваем ComboBox игрока
            comboBoxPlayers.DataSource = null; // Сброс старой привязки
            comboBoxPlayers.DataSource = players;
            comboBoxPlayers.DisplayMember = "FullName"; 
            comboBoxPlayers.ValueMember = "IdPlayer";    
            comboBoxPlayers.SelectedIndex = -1;
            comboBoxPlayers.Text = "Выберите игрока...";
            comboBoxPlayers.Enabled = true;
        }

        private void FieldModels()
        {
            _transfer.ToTeamId = (int)teamNowComboBox.SelectedValue;
            _transfer.FromTeamName = tBoxTeamFrom.Text.Trim();
            _transfer.Price = priceTransferNumericUpDown.Value;
            _transfer.DateTransfer = dateTimePickerTransfer.Value;
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
