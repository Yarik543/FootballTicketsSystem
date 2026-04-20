using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppServices
{
    public class PhotoHelper
    {
        /// <summary>
        /// Загружает фото пользователя (твой код, вынесенный в метод)
        /// </summary>
        public static Image LoadUserPhoto(string photoFileName)
        {
            Image newImage;

            if (string.IsNullOrEmpty(photoFileName))
            {
                newImage = Properties.Resources.profil_default;
            }
            else
            {
                string path = Path.Combine(Application.StartupPath, "img", "users", photoFileName);

                using (var temp = Image.FromFile(path))
                {
                    newImage = new Bitmap(temp);
                }
            }

            return newImage;
        }
    }
}
