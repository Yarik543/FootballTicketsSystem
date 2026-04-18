using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.Helpers
{
    public static class ImageLoader
    {
        // Один HttpClient на всё приложение (лучшая практика!)
        private static readonly HttpClient _httpClient = new HttpClient();

        static ImageLoader()
        {
            _httpClient.Timeout = TimeSpan.FromSeconds(5); // Таймаут 5 сек
        }

        public static async Task<Image> LoadImageAsync(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;

            // 1. Проверяем кэш
            Image cached = ImageCache.GetImage(url);
            if (cached != null) return cached;

            try
            {
                // 2. Скачиваем
                byte[] bytes = await _httpClient.GetByteArrayAsync(url);

                using (var ms = new MemoryStream(bytes))
                {
                    Image image = Image.FromStream(ms);

                    // 3. Сохраняем в кэш
                    ImageCache.AddImage(url, image);

                    // 4. Возвращаем копию
                    return new Bitmap(image);
                }
            }
            catch
            {
                return null; // При ошибке — нулл
            }
        }

        // Метод для загрузки с заглушкой (удобно для PictureBox)
        public static async Task LoadToPictureBoxAsync(PictureBox pictureBox, string url, Image picture = null)
        {
            if (pictureBox == null) return;

            // Сразу ставим заглушку
            if (picture != null)
                pictureBox.Image = picture;
            else if (string.IsNullOrEmpty(url))
                pictureBox.Image = null;

            if (string.IsNullOrEmpty(url)) return;

            Image image = await LoadImageAsync(url);

            if (image != null)
            {
                pictureBox.Image = image;
            }
            else if (picture != null)
            {
                pictureBox.Image = picture;
            }
        }
    }
}