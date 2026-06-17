using FootballTicketsSystem.AppServices;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace FootballTicketsSystem.AppForms
{
    public partial class TicketBuyForm : Form
    {
        private Matches _currentMatch;
        private dynamic _selectedSeat;
        private decimal _currentPrice;
        public TicketBuyForm(Matches match)
        {
            InitializeComponent();
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);

            _currentMatch = match;
            LoadMatchInfo();

            this.FormClosed += TicketBuyForm_FormClosed;
        }

        /// <summary>
        /// Фон + границы формы
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiPainter.DrawGradientBackground(this, e);
        }

        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TicketBuyForm_Load(object sender, EventArgs e)
        {
            if (_currentMatch == null)
            {
                MessageBox.Show("Ошибка: матч не указан!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            labelBalance.Text = $"Ваш баланс: {UserSession.CurrentUser.Ballance:N0} ₽";
            GenerateTestSeats();

            CheckStadiumAvailability();
        }

        /// <summary>
        /// Загружает информацию о матче
        /// </summary>
        private async void LoadMatchInfo()
        {
            if (_currentMatch == null) return;

            var homeTeam = Program.context.Teams.Find(_currentMatch.TeamHomeId);
            var awayTeam = Program.context.Teams.Find(_currentMatch.TeamAwayId);

            labelTeamHome.Text = homeTeam?.TeamName ?? "Команда 1";
            labelTeamAway.Text = awayTeam?.TeamName ?? "Команда 2";

            if (homeTeam != null)
            {
                await ImageLoader.LoadToPictureBoxAsync(
                    pictureBoxLogoFirstTeam,
                    homeTeam.Logo,
                    Properties.Resources.picture);
            }

            if (awayTeam != null)
            {
                await ImageLoader.LoadToPictureBoxAsync(
                    pictureBoxTeamLogoAway,
                    awayTeam.Logo,
                    Properties.Resources.picture);
            }

            var stadium = Program.context.Stadiums.Find(_currentMatch.StadiumId);
            labelStadiumName.Text = $"Стадион: {stadium?.NameStadium ?? "Не указан"}";

            if (_currentMatch.MatchDate.HasValue)
            {
                labelMatchDate.Text = _currentMatch.MatchDate.Value.ToString("dd.MM.yyyy");
                labelMatchTime.Text = _currentMatch.MatchDate.Value.ToString("HH:mm");
            }

            labelStage.Text = _currentMatch.Stage ?? "Чемпионат";
        }

        private decimal CalculateTicketPrice(int row, string stage)
        {
            decimal basePrice = 1000;
            if (stage == "Финал") basePrice = 5000;
            else if (stage == "1/2 финала") basePrice = 3500;
            else if (stage == "1/4 финала") basePrice = 2500;
            else if (stage == "1/8 финала") basePrice = 2000;
            else if (stage == "Групповой этап") basePrice = 1500;
            else if (stage == "Плей-офф") basePrice = 2000;

            decimal rowBonus = 100;
            if (row <= 5) rowBonus = (6 - row) * 500m;
            else if (row <= 10) rowBonus = (11 - row) * 300m;
            else if (row <= 15) rowBonus = (16 - row) * 200m;

            return basePrice + rowBonus;
        }

        private void GenerateTestSeats()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(20, 15, 20, 50);

            int totalRows = 15;
            int seatsPerRow = 10;
            var purchasedSeats = GetPurchasedSeats();

            string currentSector = sectorComboBox.SelectedItem?.ToString() ?? "A";

            for (int row = 1; row <= totalRows; row++)
            {
                var rowPanel = new FlowLayoutPanel
                {
                    Width = flowLayoutPanel1.Width - 20,
                    Height = 40,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false,
                    Margin = new Padding(0, 2, 0, 2),
                    Padding = new Padding(5, 0, 5, 0)
                };

                var lblRowNumber = new Label
                {
                    Text = row.ToString(),
                    Width = 40,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 30, 47),
                    Margin = new Padding(0, 5, 8, 5)
                };
                rowPanel.Controls.Add(lblRowNumber);

                int middleSeat = seatsPerRow / 2;

                for (int seat = 1; seat <= seatsPerRow; seat++)
                {
                    var btnSeat = new Guna2Button
                    {
                        Width = 40,
                        Height = 40,
                        Margin = new Padding(1),
                        BorderRadius = 5,
                        Font = new Font("Microsoft Sans Serif", 7),
                        Text = seat.ToString(),
                        Tag = new { Sector = currentSector, Row = row, Seat = seat } // Добавляем сектор в Tag
                    };

                    bool isOccupied = purchasedSeats.Any(s =>
                        s.Sector == currentSector && s.Row == row && s.Seat == seat);

                    if (isOccupied)
                    {
                        btnSeat.FillColor = Color.FromArgb(223, 111, 138);
                        btnSeat.ForeColor = Color.White;
                        btnSeat.Enabled = false;
                    }
                    else
                    {
                        btnSeat.FillColor = Color.FromArgb(20, 184, 134);
                        btnSeat.ForeColor = Color.White;
                        btnSeat.Click += BtnSeat_Click;
                        btnSeat.Cursor = Cursors.Hand;
                    }

                    rowPanel.Controls.Add(btnSeat);

                    if (seat == middleSeat)
                    {
                        var aisleSpacer = new Panel { Width = 40, Height = 40, BackColor = Color.Transparent };
                        rowPanel.Controls.Add(aisleSpacer);
                    }
                }

                flowLayoutPanel1.Controls.Add(rowPanel);
            }

            var bottomSpacer = new Panel { Height = 20, Width = flowLayoutPanel1.Width - 20 };
            flowLayoutPanel1.Controls.Add(bottomSpacer);
        }

        /// <summary>
        /// Получает список уже купленных мест на этот матч
        /// </summary>
        private List<(string Sector, int Row, int Seat)> GetPurchasedSeats()
        {
            var purchasedSeats = new List<(string, int, int)>();
            if (_currentMatch == null) return purchasedSeats;

            var tickets = Program.context.Tickets
                .Where(t => t.MatchId == _currentMatch.IdMatch && t.IsSold == true)
                .ToList();

            foreach (var ticket in tickets)
            {
                if (ticket.Row.HasValue && ticket.SeatNumber.HasValue)
                {
                    string sector = ticket.Sector ?? "A";
                    purchasedSeats.Add((sector, ticket.Row.Value, ticket.SeatNumber.Value));
                }
            }

            return purchasedSeats;
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            ResetSelection();
            var btn = sender as Guna2Button;
            btn.FillColor = Color.FromArgb(255, 193, 7);
            _selectedSeat = btn.Tag as dynamic;

            // Используем сектор из Tag кнопки
            string sector = _selectedSeat.Sector ?? "A";
            labelSectorName.Text = "Сектор " + sector;
            labelRowPlace.Text = $"Ряд {_selectedSeat.Row}";
            labelNumberPlace.Text = $"Место {_selectedSeat.Seat}";

            string stage = _currentMatch?.Stage ?? "Чемпионат";
            _currentPrice = CalculateTicketPrice(_selectedSeat.Row, stage);
            labelPrice.Text = $"{_currentPrice:N0} ₽";
        }

        private void ResetSelection()
        {
            foreach (Control rowControl in flowLayoutPanel1.Controls)
            {
                if (rowControl is FlowLayoutPanel rowPanel)
                {
                    foreach (Control ctrl in rowPanel.Controls)
                    {
                        if (ctrl is Guna2Button btn && btn.Enabled)
                        {
                            btn.FillColor = Color.FromArgb(20, 184, 134);
                        }
                    }
                }
            }
        }

        private void sectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedSeat != null)
            {
                string stage = _currentMatch?.Stage ?? "Чемпионат";
                _currentPrice = CalculateTicketPrice(_selectedSeat.Row, stage);
                labelPrice.Text = $"{_currentPrice:N0} ₽";

            }
            // Перерисовываем места при смене сектора
            GenerateTestSeats();

            ResetSelection();
            _selectedSeat = null;
            labelSectorName.Text = "-";
            labelRowPlace.Text = "-";
            labelNumberPlace.Text = "-";
            labelPrice.Text = "-";

            CheckStadiumAvailability();
        }

        private void btnBuyTickets_Click(object sender, EventArgs e)
        {
            if (_selectedSeat == null)
            {
                MessageBox.Show("Выберите место!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!UserSession.CurrentUser.Ballance.HasValue || UserSession.CurrentUser.Ballance.Value < _currentPrice)
            {
                MessageBox.Show(
                    $"Недостаточно средств! Необходимо {_currentPrice:N0} ₽, а у вас {UserSession.CurrentUser.Ballance:N0} ₽",
                    "Недостаточно средств",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Купить билет за {_currentPrice:N0} ₽?\n\n" +
                $"Сектор: {labelSectorName.Text}\n" +
                $"Ряд: {_selectedSeat.Row}\n" +
                $"Место: {_selectedSeat.Seat}",
                "Подтверждение покупки",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                string sector = labelSectorName.Text.Replace("Сектор ", "").Trim();

                string qrData = Guid.NewGuid().ToString();

                var ticket = new Tickets
                {
                    MatchId = _currentMatch.IdMatch,
                    Sector = sector,
                    Row = _selectedSeat.Row,
                    SeatNumber = _selectedSeat.Seat,
                    Price = _currentPrice,
                    IsSold = true,
                    QrCodeData = qrData
                };

                Program.context.Tickets.Add(ticket);
                Program.context.SaveChanges();

                ShowQrCodeDialog(qrData, ticket);

                var userTicket = new UserTickets
                {
                    UserId = UserSession.CurrentUser.IdUser,
                    TicketId = ticket.IdTicket
                };
                Program.context.UserTickets.Add(userTicket);

                UserSession.CurrentUser.Ballance -= (int)_currentPrice;

                Program.context.SaveChanges();

                MessageBox.Show(
                    $"Билет успешно куплен!\n\n" +
                    $"Сектор: {labelSectorName.Text}\n" +
                    $"Ряд: {_selectedSeat.Row}, Место: {_selectedSeat.Seat}\n" +
                    $"Цена: {_currentPrice:N0} ₽",
                    "Успешная покупка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                labelBalance.Text = $"Ваш баланс: {UserSession.CurrentUser.Ballance:N0} ₽";
                GenerateTestSeats();
                CheckStadiumAvailability();

                ResetSelection();
                _selectedSeat = null;
                labelSectorName.Text = "-";
                labelRowPlace.Text = "-";
                labelNumberPlace.Text = "-";
                labelPrice.Text = "-";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при покупке: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Показывает форму с QR-кодом билета
        /// </summary>
        private void ShowQrCodeDialog(string qrData, Tickets ticket)
        {
            var qrForm = new Form
            {
                Text = "Ваш билет",
                Size = new Size(350, 500),
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

            var lblTitle = new Label
            {
                Text = "Билет куплен!",
                Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 184, 134),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 40
            };
            panel.Controls.Add(lblTitle);

            var qrPictureBox = new PictureBox
            {
                Size = new Size(250, 250),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(40, 60)
            };

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            qrPictureBox.Image = qrCode.GetGraphic(20);

            panel.Controls.Add(qrPictureBox);

            var lblInfo = new Label
            {
                Text = $"Сектор: {ticket.Sector}\nРяд: {ticket.Row}\nМесто: {ticket.SeatNumber}\nЦена: {ticket.Price:N0} ₽",
                Font = new Font("Microsoft Sans Serif", 10),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(40, 320),
                Width = 250,
                Height = 80,
                AutoSize = false
            };
            panel.Controls.Add(lblInfo);

            var btnClose = new Button
            {
                Text = "Закрыть",
                Location = new Point(120, 420),
                Width = 100,
                DialogResult = DialogResult.OK
            };
            qrForm.AcceptButton = btnClose;
            panel.Controls.Add(btnClose);

            qrForm.ShowDialog();
        }

        /// <summary>
        /// Проверяет, есть ли свободные места на стадионе
        /// </summary>
        private bool CheckStadiumAvailability()
        {
            if (_currentMatch?.StadiumId == null) return false;

            var stadium = Program.context.Stadiums.Find(_currentMatch.StadiumId);
            if (stadium == null || stadium.Capacity <= 0) return false;

            int capacity = stadium.Capacity.Value;

            int soldCount = Program.context.Tickets
                .Count(t => t.MatchId == _currentMatch.IdMatch && t.IsSold == true);

            if (soldCount >= capacity)
            {
                DisableBuyButton("Аншлаг! Все места распроданы");
                return false;
            }

            EnableBuyButton();
            return true;
        }

        /// <summary>
        /// Отключает кнопку покупки с сообщением
        /// </summary>
        private void DisableBuyButton(string reason)
        {
            btnBuyTickets.Enabled = false;
            btnBuyTickets.FillColor = Color.FromArgb(180, 180, 180);
            btnBuyTickets.ForeColor = Color.Gray;
            btnBuyTickets.Text = "Нет мест";
            btnBuyTickets.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Включает кнопку покупки
        /// </summary>
        private void EnableBuyButton()
        {
            btnBuyTickets.Enabled = true;
            btnBuyTickets.FillColor = Color.FromArgb(20, 184, 134);
            btnBuyTickets.ForeColor = Color.White;
            btnBuyTickets.Text = "Купить билет";
            btnBuyTickets.Cursor = Cursors.Hand;
        }

        private void TicketBuyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContextManager.calendarForm?.LoadDataMatch();
            ContextManager.mainDashboardForm?.LoadMatchStatistics();
        }
    }
}
