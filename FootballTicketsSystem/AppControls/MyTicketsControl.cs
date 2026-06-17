using FootballTicketsSystem.DBModels;
using FootballTicketsSystem.Helpers;
using QRCoder;
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
    public partial class MyTicketsControl : UserControl
    {
        Tickets _ticket;
        public MyTicketsControl(Tickets tickets)
        {
            InitializeComponent();
            _ticket = tickets;
            SetTicketData();
        }

        private async void SetTicketData()
        {
            // 1. Дата и время
            if (_ticket.Matches?.MatchDate.HasValue == true)
            {
                DateTime matchDate = _ticket.Matches.MatchDate.Value;
                labelDataMatch.Text = matchDate.ToString("dd.MM.yyyy");
                labelTimeMatch.Text = matchDate.ToString("HH:mm");

                // 👇 Определяем статус билета
                UpdateTicketStatus(matchDate);
            }
            else
            {
                labelDataMatch.Text = "--.--.----";
                labelTimeMatch.Text = "--:--";
                UpdateTicketStatus(null); // Нет даты = неактивен
            }

            // 2. Стадион
            labelStadiumName.Text = $"Стадион: {_ticket.Matches?.Stadiums?.NameStadium ?? "Не указан"}";

            // 3. Сектор, ряд, место
            labelSector.Text = _ticket.Sector ?? "A";
            labelRow.Text = _ticket.Row?.ToString() ?? "-";
            labelPlaceSeat.Text = _ticket.SeatNumber?.ToString() ?? "-";

            // 4. Команды
            labelTeamNameFirst.Text = _ticket.Matches?.Teams?.TeamName ?? "Команда 1";
            labelTeamNameSecond.Text = _ticket.Matches?.Teams1?.TeamName ?? "Команда 2";

            // 5. 👇 СЧЁТ МАТЧА (если сыгран)
            if (_ticket.Matches?.ScoreHome.HasValue == true && _ticket.Matches?.ScoreAway.HasValue == true)
            {
                labelScore.Text = $"{_ticket.Matches.ScoreHome.Value} : {_ticket.Matches.ScoreAway.Value}";
                labelScore.Visible = true;
                if (pictureBoxVs != null) pictureBoxVs.Visible = false;
            }
            else
            {
                labelScore.Visible = false;
                if (pictureBoxVs != null) pictureBoxVs.Visible = true;
            }

            // 6. Загружаем логотипы
            await LoadTeamLogosAsync();
        }

        /// <summary>
        /// Обновляет статус билета (активен/неактивен)
        /// </summary>
        private void UpdateTicketStatus(DateTime? matchDate)
        {
            bool isActive = matchDate.HasValue && matchDate.Value > DateTime.Now;

            if (isActive)
            {
                // ✅ Матч ещё не начался — билет активен
                labelStatus.Text = "Активен";
                labelStatus.ForeColor = Color.FromArgb(0, 200, 150); // Зелёный

                pictureBoxActive.Visible = true;
                pictureBoxDisab.Visible = false;

                // 👇 Делаем кнопку QR активной
                btnShowOr.Enabled = true;
                btnShowOr.Cursor = Cursors.Hand;
            }
            else
            {
                // 
                labelStatus.Text = "Неактивен";
                labelStatus.ForeColor = Color.FromArgb(223, 111, 138); // Красный

                pictureBoxActive.Visible = false;
                pictureBoxDisab.Visible = true;

                // 👇 Отключаем кнопку QR (билет уже недействителен)
                btnShowOr.Enabled = false;
                btnShowOr.Cursor = Cursors.Default;
            }
        }

        private async Task LoadTeamLogosAsync()
        {
            if (_ticket.Matches == null) return;

            var task1 = ImageLoader.LoadToPictureBoxAsync(
                pictureBoxLogoFirstTeam,
                _ticket.Matches.Teams?.Logo,
                Properties.Resources.picture);

            var task2 = ImageLoader.LoadToPictureBoxAsync(
                pictureBoxTeamLogoAway,
                _ticket.Matches.Teams1?.Logo,
                Properties.Resources.picture);

            await Task.WhenAll(task1, task2);
        }


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

        private void btnShowOr_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_ticket.QrCodeData))
            {
                MessageBox.Show("QR-код не найден для этого билета", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowTicketQrCode(_ticket.QrCodeData, _ticket);
        }

        /// <summary>
        /// Показывает QR-код билета во всплывающем окне
        /// </summary>
        private void ShowTicketQrCode(string qrData, Tickets ticket)
        {
            var qrForm = new Form
            {
                Text = "QR-код билета",
                Size = new Size(350, 520),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false
            };

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = Color.White
            };
            qrForm.Controls.Add(panel);

            // Заголовок
            var lblTitle = new Label
            {
                Text = "Ваш билет",
                Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 184, 134),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 40
            };
            panel.Controls.Add(lblTitle);

            // QR-код
            var qrPictureBox = new PictureBox
            {
                Size = new Size(250, 250),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(40, 60),
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                var qrGenerator = new QRCodeGenerator();
                var qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCode(qrCodeData);
                qrPictureBox.Image = qrCode.GetGraphic(20);
            }
            catch (Exception ex)
            {
                qrPictureBox.Image = Properties.Resources.picture;
                MessageBox.Show($"Ошибка генерации QR: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            panel.Controls.Add(qrPictureBox);

            // Информация
            var lblMatch = new Label
            {
                Text = $"{ticket.Matches?.Teams?.TeamName} vs {ticket.Matches?.Teams1?.TeamName}",
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(40, 320),
                Width = 250,
                AutoSize = false
            };
            panel.Controls.Add(lblMatch);

            var lblDetails = new Label
            {
                Text = $"{ticket.Matches?.MatchDate?.ToString("dd.MM.yyyy HH:mm")}\n" +
                       $"{ticket.Matches?.Stadiums?.NameStadium}\n" +
                       $"{ticket.Sector}, {ticket.Row}, {ticket.SeatNumber}",
                Font = new Font("Microsoft Sans Serif", 8),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(40, 360),
                Width = 250,
                Height = 70,
                AutoSize = false
            };
            panel.Controls.Add(lblDetails);

            // Кнопка закрытия
            var btnClose = new Button
            {
                Text = "Закрыть",
                Location = new Point(120, 440),
                Width = 100,
                DialogResult = DialogResult.OK
            };
            qrForm.AcceptButton = btnClose;
            panel.Controls.Add(btnClose);

            qrForm.ShowDialog();
        }
    }
}
