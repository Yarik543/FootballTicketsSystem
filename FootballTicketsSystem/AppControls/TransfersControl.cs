using FootballTicketsSystem.DBModels;
using FootballTicketsSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppControls
{
    public partial class TransfersControl : UserControl
    {
        Transfers _transfer;
        public TransfersControl(Transfers transfer)
        {
            InitializeComponent();
            _transfer = transfer;
            SetDataLabels();
        }

        private async Task LoadPlayerPhotoAsync()
        {
            // 1. Если фото нет — сразу ставим заглушку
            if (string.IsNullOrEmpty(_transfer.Players?.Photo))
            {
                pictureBoxPhotoPlayer.Image = Properties.Resources.player_picture;
                return;
            }

            string photoPath = _transfer.Players.Photo;

            // 2. Если это ссылка (начинается с http) — грузим асинхронно через ImageLoader
            if (photoPath.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                await ImageLoader.LoadToPictureBoxAsync(
                    pictureBoxPhotoPlayer,
                    photoPath,
                    Properties.Resources.player_picture);
            }
            // 3. Если это имя файла — грузим локально
            else
            {
                // Путь: bin/Debug/img/players/имя_файла
                string localPath = Path.Combine(
                    Application.StartupPath,  
                    "img",                    
                    "players",                
                    photoPath                 
                );

                if (File.Exists(localPath))
                {
                    try
                    {
                        // Загружаем картинку (с кэшированием, чтобы не грузить каждый раз с диска)
                        pictureBoxPhotoPlayer.Image = Image.FromFile(localPath);
                        pictureBoxPhotoPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch
                    {
                        pictureBoxPhotoPlayer.Image = Properties.Resources.player_picture;
                    }
                }
                else
                {
                    // Файл не найден — заглушка
                    pictureBoxPhotoPlayer.Image = Properties.Resources.player_picture;
                }
            }
        }

        private void SetDataLabels()
        {
            if (_transfer == null || _transfer.Players == null) return;

            labelDataTransfer.Text = _transfer.DateTransfer?.ToString("yyyy.MM.dd") ?? "Не указана";
            labelPlayerName.Text = _transfer.Players.FullName;

            // Цена
            if (!_transfer.Price.HasValue || _transfer.Price.Value == 0)
            {
                labelPriceTransfer.Text = "Бесплатно";
            }
            else
            {
                labelPriceTransfer.Text = _transfer.Price.Value.ToString("#,##0").Replace(",", " ") + " €";
            }

            // Команды — всегда
            labelTeamsTransfer.Text = $"{_transfer.FromTeamName} → {_transfer.Teams?.TeamName ?? "Неизвестно"}";

            // Фото — всегда (асинхронно)
            _ = LoadPlayerPhotoAsync();
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
    }
}
