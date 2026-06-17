using FootballTicketsSystem.AppServices;
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

namespace FootballTicketsSystem.AppForms
{
    public partial class ProfilForm : Form
    {
        Users _user;
        private string _selectedPhotoPath = null;
        public ProfilForm(Users users)
        {
            InitializeComponent();
            if(UserSession.CurrentUser.Roles.RoleName == "Администратор")
            {
                btnClients.Visible = true;
            }

            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
            pictureBoxProfilEdit.Image?.Dispose();
            pictureBoxProfilEdit.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
            _user = users;
            LoadUserData();
            CalculateProfileCompletion();
        }

        /// <summary>
        /// Загружает данные пользователя в форму
        /// </summary>
        private void LoadUserData()
        {
            if (_user == null) return;

            LoadUserPhoto();

            tBoxFullName.Text = _user.FullName ?? "";
            tBoxPhone.Text = _user.Phone ?? "";
            tBoxEmail.Text = _user.Email ?? "";
            tBoxPassword.Text = "";

            UpdateCompletionCheckboxes();
        }

        /// <summary>
        /// Загружает фото пользователя
        /// </summary>
        private void LoadUserPhoto()
        {
            if (!string.IsNullOrEmpty(_user.PhotoProfil))
            {
                pictureBoxProfilEdit.Image?.Dispose();
                pictureBoxProfilEdit.Image = PhotoHelper.LoadUserPhoto(_user.PhotoProfil);

                pictureProfil.Image?.Dispose();
                pictureProfil.Image = PhotoHelper.LoadUserPhoto(_user.PhotoProfil);
            }
            else
            {
                pictureBoxProfilEdit.Image = Properties.Resources.picture;
            }
        }

        /// <summary>
        /// Обновляет заполненности полей (галочки/крестики)
        /// </summary>
        private void UpdateCompletionCheckboxes()
        {
            if (_user == null) return;

            if (!string.IsNullOrWhiteSpace(_user.FullName))
            {
                pictureBoxNameCheck.Image = Properties.Resources.agree_galochka;
            }
            else
            {
                pictureBoxNameCheck.Image = Properties.Resources.cross;
            }

            if (!string.IsNullOrWhiteSpace(_user.PhotoProfil))
            {
                pictureBoxPhotoCheck.Image = Properties.Resources.agree_galochka;
            }
            else
            {
                pictureBoxPhotoCheck.Image = Properties.Resources.cross;
            }

            if (!string.IsNullOrWhiteSpace(_user.Phone))
            {
                pictureBoxPhoneCheck.Image = Properties.Resources.agree_galochka;
            }
            else
            {
                pictureBoxPhoneCheck.Image = Properties.Resources.cross;
            }

            pictureBoxPasswordCheck.Image = Properties.Resources.agree_galochka;

            if (!string.IsNullOrWhiteSpace(_user.Email))
            {
                pictureBoxEmailCheck.Image = Properties.Resources.agree_galochka;
            }
            else
            {
                pictureBoxEmailCheck.Image = Properties.Resources.cross;
            }
        }

        /// <summary>
        /// Рассчитывает процент заполненности профиля
        /// </summary>
        private void CalculateProfileCompletion()
        {
            int totalFields = 5; // Имя, Фото, Телефон, Пароль, Почта
            int filledFields = 0;

            if (!string.IsNullOrWhiteSpace(_user.FullName))
                filledFields++;

            if (!string.IsNullOrWhiteSpace(_user.PhotoProfil))
                filledFields++;

            if (!string.IsNullOrWhiteSpace(_user.Phone))
                filledFields++;

            filledFields++;

            if (!string.IsNullOrWhiteSpace(_user.Email))
                filledFields++;

            int percentage = (filledFields * 100) / totalFields;

            UpdateProgressChart(percentage);
        }

        /// <summary>
        /// Обновляет круговую диаграмму прогресса
        /// </summary>
        private void UpdateProgressChart(int percentage)
        {

            if (labelProgressPercent != null)
            {
                labelProgressPercent.Text = $"{percentage}%";
            }

            if (progressBarProfile != null)
            {
                progressBarProfile.Value = percentage;
            }

            // Меняем цвет в зависимости от процента
            if (percentage < 40)
            {
                // Красный
                if (labelProgressPercent != null)
                    labelProgressPercent.ForeColor = Color.FromArgb(223, 111, 138);
            }
            else if (percentage < 80)
            {
                // Жёлтый
                if (labelProgressPercent != null)
                    labelProgressPercent.ForeColor = Color.FromArgb(255, 193, 7);
            }
            else
            {
                // Зелёный
                if (labelProgressPercent != null)
                    labelProgressPercent.ForeColor = Color.FromArgb(20, 184, 134);
            }
        }

        /// <summary>
        /// Фон + границы формы
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiPainter.DrawGradientBackground(this, e);
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            AdminUsersForm adminUsersForm = new AdminUsersForm();
            DialogResult adminResult = adminUsersForm.ShowDialog();
        }

        private void ProfilForm_Load(object sender, EventArgs e)
        {
            tBoxFullName.Text = _user.FullName;
        }

        private void btnEditImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|All Files|*.*",
                Title = "Выберите изображение профиля"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedPhotoPath = openFileDialog.FileName;

                try
                {
                    pictureBoxProfilEdit.Image?.Dispose();
                    pictureBoxProfilEdit.Image = Image.FromFile(_selectedPhotoPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки фото: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Проверяет корректность формата телефона
        /// </summary>
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return true;

            string pattern = @"^[\+]?[0-9\s\-\(\)\.]{10,20}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, pattern))
                return false;

            int digitsCount = phone.Count(char.IsDigit);
            return digitsCount >= 11 && digitsCount <= 15;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tBoxFullName.Text))
            {
                MessageBox.Show("Введите ФИО", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tBoxFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tBoxEmail.Text))
            {
                MessageBox.Show("Введите email", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tBoxEmail.Focus();
                return;
            }

            if (!IsValidEmail(tBoxEmail.Text))
            {
                MessageBox.Show(
                    "Некорректный формат email!\n\nПример правильного формата:\nuser@gmail.com\nivan.ivanov@yandex.ru\nivan.ivanov@i",
                    "Ошибка валидации email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tBoxEmail.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(tBoxPhone.Text) && !IsValidPhone(tBoxPhone.Text))
            {
                MessageBox.Show(
                    "Некорректный формат телефона!\n\nПример правильного формата:\n+7 (999) 123-45-67\n89991234567",
                    "Ошибка валидации телефона",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tBoxPhone.Focus();
                return;
            }

            string newEmail = tBoxEmail.Text.Trim();
            if (newEmail != _user.Email &&
                Program.context.Users.Any(u => u.Email == newEmail))
            {
                MessageBox.Show(
                    "Пользователь с таким email уже существует.\nПожалуйста, используйте другой email.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tBoxEmail.Focus();
                return;
            }


            DialogResult confirm = MessageBox.Show(
                "Сохранить изменения в профиле?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _user.FullName = tBoxFullName.Text.Trim();
                _user.Email = tBoxEmail.Text.Trim();
                _user.Phone = tBoxPhone.Text.Trim();

                if (!string.IsNullOrWhiteSpace(tBoxPassword.Text))
                {
                    var (hash, salt) = PasswordHelper.CreatePassword(tBoxPassword.Text);
                    _user.PasswordHash = hash;
                    _user.PasswordSalt = salt;
                }

                // Если загружено новое фото
                if (!string.IsNullOrEmpty(_selectedPhotoPath))
                {
                    // Сохраняем фото в папку
                    string photoFileName = SavePhotoToServer(_selectedPhotoPath);
                    _user.PhotoProfil = photoFileName;
                }

                Program.context.SaveChanges();
                UserSession.CurrentUser = _user;

                MessageBox.Show("Профиль успешно обновлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadUserData();
                CalculateProfileCompletion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверяет корректность email
        /// </summary>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Сохраняет фото в бд
        /// </summary>
        private string SavePhotoToServer(string sourcePath)
        {
            string uploadsFolder = Path.Combine(Application.StartupPath, "Uploads", "Profiles");
            Directory.CreateDirectory(uploadsFolder);

            string extension = Path.GetExtension(sourcePath);
            string fileName = $"user_{_user.IdUser}_{DateTime.Now:yyyyMMdd_HHmmss}{extension}";
            string destPath = Path.Combine(uploadsFolder, fileName);

            File.Copy(sourcePath, destPath, true);

            // Возвращаем относительный путь для БД
            return Path.Combine("Uploads", "Profiles", fileName);
        }

        private void pictureBoxVisible_Click(object sender, EventArgs e)
        {
            tBoxPassword.PasswordChar = '\0'; 

            pictureBoxVisible.Visible = false;
            pictureBoxInvisible.Visible = true;
        }

        private void pictureBoxInvisible_Click(object sender, EventArgs e)
        {
            tBoxPassword.PasswordChar = '*';

            pictureBoxVisible.Visible = true;
            pictureBoxInvisible.Visible = false;
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnTransfers_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LogoutService.RequestLogout(this);
        }
    }
}
