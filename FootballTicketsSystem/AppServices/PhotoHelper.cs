using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppServices
{
    public class PhotoHelper
    {
        /// <summary>
        /// Загружает фото пользователя
        /// </summary>
        public static Image LoadUserPhoto(string photoFileName)
        {
            if (string.IsNullOrEmpty(photoFileName))
            {
                return Properties.Resources.profil_default;
            }

            // 👇 ПРАВИЛЬНЫЙ ПУТЬ
            string path;

            // Проверяем, начинается ли путь уже с "Uploads" или "img"
            if (photoFileName.StartsWith("Uploads") || photoFileName.StartsWith("img"))
            {
                // Путь уже полный относительно StartupPath
                path = Path.Combine(Application.StartupPath, photoFileName);
            }
            else
            {
                // Старый формат - добавляем префикс
                path = Path.Combine(Application.StartupPath, "img", "users", photoFileName);
            }

            // Проверяем существование файла
            if (!File.Exists(path))
            {
                // Если файл не найден - возвращаем заглушку
                return Properties.Resources.profil_default;
            }

            try
            {
                using (var temp = Image.FromFile(path))
                {
                    return new Bitmap(temp);
                }
            }
            catch
            {
                return Properties.Resources.profil_default;
            }
        }
    }
}