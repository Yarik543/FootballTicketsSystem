using FootballTicketsSystem.Helpers;
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
    public partial class TableTeamsControl : UserControl
    {
        public TableTeamsControl()
        {
            InitializeComponent();
            SetupTableLayout();
        }

        /// <summary>
        /// Настраивает TableLayoutPanel с колонками
        /// </summary>
        private void SetupTableLayout()
        {
            tableLayoutPanelMain.SuspendLayout();
            tableLayoutPanelMain.Controls.Clear();
            tableLayoutPanelMain.ColumnStyles.Clear();

            tableLayoutPanelMain.Dock = DockStyle.Top;
            tableLayoutPanelMain.ColumnCount = 8; // 👇 Убрали колонку "Г" (было 9, стало 8)
            tableLayoutPanelMain.RowCount = 1;
            tableLayoutPanelMain.Padding = new Padding(15, 10, 15, 10); // 👇 Увеличили отступы
            tableLayoutPanelMain.Margin = Padding.Empty;
            tableLayoutPanelMain.BackColor = Color.Transparent;
            tableLayoutPanelMain.Height = 60; // 👇 Чуть выше сделали

            // 🔥 НОВАЯ НАСТРОЙКА ШИРИНЫ КОЛОНОК (без "Г")
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));   // № (чуть шире)
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));   // 👇 Лого (было 45, стало 60)
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));   // Команда
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));   // И (шире)
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35));   // В (шире)
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35));   // Н (шире)
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35));   // П (шире)
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55));   // ОЧКИ (шире)

            SetupLabel(labelNumberTable, 0, 0, ContentAlignment.MiddleRight);
            SetupPictureBox(pictureBoxLogoTeam, 1, 0);
            SetupLabel(labelTeamName, 2, 0, ContentAlignment.MiddleLeft);
            SetupLabel(labelGamesCount, 3, 0, ContentAlignment.MiddleCenter);
            SetupLabel(labelWinCount, 4, 0, ContentAlignment.MiddleCenter);
            SetupLabel(labelDrawCount, 5, 0, ContentAlignment.MiddleCenter);
            SetupLabel(labelLostCount, 6, 0, ContentAlignment.MiddleCenter);
            SetupLabel(labelPointsCoint, 7, 0, ContentAlignment.MiddleCenter); // 

            // Сделай так:
            if (guna2Separator1 != null)
            {
                guna2Separator1.Dock = DockStyle.Bottom;
                guna2Separator1.Width = tableLayoutPanelMain.Width; // 👇 Принудительно на всю ширину
                guna2Separator1.Location = new Point(0, tableLayoutPanelMain.Height - 5);

                tableLayoutPanelMain.Controls.Add(guna2Separator1);
            }

            tableLayoutPanelMain.ResumeLayout(false);
        }

        private void SetupLabel(Label label, int column, int row, ContentAlignment alignment)
        {
            label.AutoSize = false;
            label.TextAlign = alignment;
            label.Dock = DockStyle.Fill;
            label.Margin = new Padding(3, 0, 3, 0);
            label.Padding = new Padding(2, 0, 2, 0);
            label.Font = new Font("Inter", 8F, FontStyle.Regular);
            label.ForeColor = Color.FromArgb(30, 30, 47);

            tableLayoutPanelMain.Controls.Add(label, column, row);
        }

        private void SetupPictureBox(PictureBox pictureBox, int column, int row)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Dock = DockStyle.None; 
            pictureBox.Size = new Size(50, 50);
            pictureBox.Margin = new Padding(5, 0, 5, 0);

            // Центрируем в ячейке
            tableLayoutPanelMain.SetCellPosition(pictureBox, new TableLayoutPanelCellPosition(column, row));
            tableLayoutPanelMain.Controls.Add(pictureBox);
        }

        /// <summary>
        /// Асинхронная загрузка данных команды
        /// </summary>
        public async Task LoadTeamDataAsync(int position, string teamName, string logoPath,
            int games, int wins, int draws, int losses, int points)
        {
            labelNumberTable.Text = position.ToString();
            labelTeamName.Text = teamName;
            labelGamesCount.Text = games.ToString();
            labelWinCount.Text = wins.ToString();
            labelDrawCount.Text = draws.ToString();
            labelLostCount.Text = losses.ToString();
            labelPointsCoint.Text = points.ToString();

            // Асинхронная загрузка логотипа
            if (!string.IsNullOrEmpty(logoPath))
            {
                try
                {
                    await ImageLoader.LoadToPictureBoxAsync(
                        pictureBoxLogoTeam,
                        logoPath,
                        Properties.Resources.picture);
                }
                catch
                {
                    pictureBoxLogoTeam.Image = Properties.Resources.picture;
                }
            }
            else
            {
                pictureBoxLogoTeam.Image = Properties.Resources.picture;
            }
        }
    }
}
