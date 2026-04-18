using FootballTicketsSystem.DBModels;
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

namespace FootballTicketsSystem.AppForms
{
    public partial class TicketBuyForm : Form
    {
        public TicketBuyForm()
        {
            InitializeComponent();
        }

        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TicketBuyForm_Load(object sender, EventArgs e)
        {
            GenerateTestSeats();
            LoadDataTickets();
        }

        public void LoadDataTickets()
        {

        }

        private void GenerateTestSeats()
        {
            // Очищаем панель
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(0, 15, 20, 50); // Слева, Сверху, Справа, Снизу

            // Тестовые данные: 15 рядов по 10 мест
            int totalRows = 15;
            int seatsPerRow = 10;

            for (int row = 1; row <= totalRows; row++)
            {
                // Создаем панель для одного ряда
                var rowPanel = new FlowLayoutPanel
                {
                    Width = flowLayoutPanel1.Width - 20,
                    Height = 40,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false,
                    Margin = new Padding(0, 2, 0, 2),
                    Padding = new Padding(5, 0, 5, 0)
                };

                // Добавляем номер ряда (Label слева)
                var lblRowNumber = new Label
                {
                    Text = row.ToString(),
                    Width = 40,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30,30,47),
                    Margin = new Padding(0, 5, 8, 5)
                };
                rowPanel.Controls.Add(lblRowNumber);

                // Добавляем кнопки мест
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
                        Tag = new { Row = row, Seat = seat }
                    };

                    // Случайный статус для теста
                    // Каждое 3-е место занято для наглядности
                    if (seat % 3 == 0)
                    {
                        // Занято - красный/розовый
                        btnSeat.FillColor = Color.FromArgb(223, 111, 138);
                        btnSeat.ForeColor = Color.White;
                        btnSeat.DisabledState.FillColor = Color.FromArgb(223, 111, 138);
                        btnSeat.DisabledState.ForeColor = Color.White;
                        btnSeat.Enabled = false;
                    }
                    else
                    {
                        // Свободно - зеленый
                        btnSeat.FillColor = Color.FromArgb(20, 184, 134);
                        btnSeat.ForeColor = Color.White;
                        btnSeat.Click += BtnSeat_Click;
                        btnSeat.Cursor = Cursors.Hand;
                    }

                    rowPanel.Controls.Add(btnSeat);
                }

                flowLayoutPanel1.Controls.Add(rowPanel);
            }

            //Панель отступ снизу
            var bottomSpacer = new Panel
            {
                Height = 20,  // Отступ снизу 20 пикселей
                Width = flowLayoutPanel1.Width - 20
            };
            flowLayoutPanel1.Controls.Add(bottomSpacer);
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            // Сбрасываем выделение со всех кнопок
            ResetSelection();

            // Выделяем нажатую кнопку
            var btn = sender as Guna2Button;
            btn.FillColor = Color.FromArgb(255, 193, 7); // Оранжевый

            // Получаем данные из Tag
            var data = btn.Tag as dynamic;

            // Обновляем информацию в Labels
            labelSectorName.Text = "Сектор " + (teamAwayIdComboBox.SelectedItem?.ToString() ?? "A");
            labelRowPlace.Text = $"Ряд {data.Row}";
            labelNumberPlace.Text = $"Место {data.Seat}";
            labelPrice.Text = "1200 ₽";
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
                            // Возвращаем зеленый цвет
                            btn.FillColor = Color.FromArgb(20, 184, 134);
                        }
                    }
                }
            }
        }
    }
}
