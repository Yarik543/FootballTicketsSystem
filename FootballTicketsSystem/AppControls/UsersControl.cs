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
            btnDeleteUser.Cursor = Cursors.Hand;
        }

        private void SetDataUsersLabel()
        {
            labelUserName.Text += _user.FullName ?? "Не указано";
            labelEmail.Text += _user.Email ?? "Не указано";
            labelPhone.Text += _user.Phone ?? "Не указано";

            pictureBoxProfil.Image?.Dispose();
            pictureBoxProfil.Image = PhotoHelper.LoadUserPhoto(_user.PhotoProfil);
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

        private void DeleteOldImg(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            // 👇 Аналогичная проверка пути
            string path;
            if (fileName.StartsWith("Uploads") || fileName.StartsWith("img"))
            {
                path = Path.Combine(Application.StartupPath, fileName);
            }
            else
            {
                path = Path.Combine(Application.StartupPath, "img", "users", fileName);
            }

            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                    // Файл заблокирован или не удалось удалить
                }
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult deleteResult = MessageBox.Show("Уверены, что хотите удалить?", "Запрос подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteResult == DialogResult.Yes)
            {
                if (pictureBoxProfil.Image != null)
                {
                    pictureBoxProfil.Image.Dispose();
                    pictureBoxProfil.Image = null;
                }
                DeleteOldImg(_user.PhotoProfil);
                Program.context.Users.Remove(_user);
                Program.context.SaveChanges();
                ContextManager.adminUsersForm.LoadDataUsers();
            }
        }

        private void btnTopBalance_Click(object sender, EventArgs e)
        {
            // Простой ввод суммы
            string amountStr = Microsoft.VisualBasic.Interaction.InputBox(
                $"Пополнение баланса для {_user.FullName}",
                "Пополнение баланса",
                "1000"); // Значение по умолчанию

            if (string.IsNullOrWhiteSpace(amountStr))
                return;

            if (int.TryParse(amountStr, out int amount) && amount > 0)
            {
                DialogResult confirm = MessageBox.Show(
                    $"Пополнить баланс {_user.FullName} на {amount:N0} ₽?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes && _user.Ballance != null)
                {
                    try
                    {
                        _user.Ballance += amount;
                        Program.context.SaveChanges();

                        MessageBox.Show(
                            $"Баланс пополнен на {amount:N0} ₽\nНовый баланс: {_user.Ballance:N0} ₽",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Обновляем отображение
                        ContextManager.adminUsersForm.LoadDataUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (confirm == DialogResult.Yes && _user.Ballance == null)
                {
                    try
                    {
                        _user.Ballance = amount;
                        Program.context.SaveChanges();

                        MessageBox.Show(
                            $"Баланс пополнен на {amount:N0} ₽\nНовый баланс: {_user.Ballance:N0} ₽",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Обновляем отображение
                        ContextManager.adminUsersForm.LoadDataUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("Введите корректную сумму", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
