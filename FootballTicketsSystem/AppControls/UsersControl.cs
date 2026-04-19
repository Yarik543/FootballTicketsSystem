using FootballTicketsSystem.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppControls
{
    public partial class UsersControl : UserControl
    {
        Users _user;
        public UsersControl(Users users)
        {
            InitializeComponent();
            _user = users;
            SetDataUsersLabel();
        }

        private void SetDataUsersLabel()
        {
            labelUserName.Text += _user.FullName ?? "Не указано";
            labelEmail.Text += _user.Email ?? "Не указано";
            labelPhone.Text += _user.Phone ?? "Не указано";
            Image newImage;

            if (string.IsNullOrEmpty(_user.PhotoProfil))
            {
                newImage = Properties.Resources.profil_default;
            }
            else
            {
                string path = Path.Combine(Application.StartupPath, "img", "users", _user.PhotoProfil);

                // Image.FromFile блокирует файл, поэтому делаем независимую копию
                using (var temp = Image.FromFile(path))
                {
                    newImage = new Bitmap(temp);
                }
            }

            pictureBoxProfil.Image?.Dispose();
            pictureBoxProfil.Image = newImage;
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
