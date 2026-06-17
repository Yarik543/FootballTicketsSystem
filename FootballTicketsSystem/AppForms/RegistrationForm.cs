using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppForms
{
    public partial class RegistrationForm : Form
    {
        Users _user;
        public RegistrationForm()
        {
            InitializeComponent();
            ContextManager.registrationForm = this;
            _user = new Users();
            Program.context.Users.Add(_user);
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

            toolTipPhone.SetToolTip(tBoxPhone, "Введите номер телефона в формате +7 (000) 000-00-00");
            toolTipFullName.SetToolTip(tBoxName, "Введите ваше ФИО полностью");
            toolTipEmail.SetToolTip(tBoxEmail, "Введите почту в формате mail@gmail.com/@.ru");
            toolTipPassword.SetToolTip(tBoxPassword, "Введите пароль не менее 8 символов");
        }

       private void RegistrationModels()
        {
            var (hash, salt) = PasswordHelper.CreatePassword(tBoxPassword.Text);

            // Заполняем поля СУЩЕСТВУЮЩЕГО объекта
            _user.FullName = tBoxName.Text.Trim();
            _user.Phone = tBoxPhone.Text.Trim();
            _user.Email = tBoxEmail.Text.Trim();
            _user.PasswordHash = hash;
            _user.PasswordSalt = salt;
            _user.RoleId = 2;
            _user.Ballance = 0;
            _user.PhotoProfil = null;
        }

        /// <summary>
        /// Проверяет корректность формата email
        /// </summary>
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email.Trim();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Проверяет корректность формата телефона
        /// </summary>
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return true; // Телефон необязателен

            string pattern = @"^[\+]?[0-9\s\-\(\)\.]{10,20}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, pattern))
                return false;

            int digitsCount = phone.Count(char.IsDigit);
            return digitsCount >= 11 && digitsCount <= 15;
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {

            // Валидация полей
            if (string.IsNullOrWhiteSpace(tBoxName.Text))
            {
                MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tBoxName.Focus();
                return;
            }

            // Проверка телефона (если введён)
            if (!string.IsNullOrWhiteSpace(tBoxPhone.Text) && !IsValidPhone(tBoxPhone.Text))
            {
                MessageBox.Show(
                    "Некорректный формат телефона!\n\nПример правильного формата:\n+7 (999) 123-45-67",
                    "Ошибка валидации телефона",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tBoxPhone.Focus();
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

            if (string.IsNullOrWhiteSpace(tBoxPassword.Text) || tBoxPassword.Text.Length < 8)
            {
                MessageBox.Show("Пароль должен содержать не менее 8 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tBoxPassword.Focus();
                return;
            }

            // Проверка уникальности email
            if (Program.context.Users.Any(u => u.Email == tBoxEmail.Text.Trim()))
            {
                MessageBox.Show("Пользователь с таким email уже существует", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult agreeRegistration = MessageBox.Show(
                "Уверены, что введённые данные верны?",
                "Запрос подтверждения",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (agreeRegistration == DialogResult.No)
                return;

            try
            {
                RegistrationModels();
                Program.context.SaveChanges();

                MessageBox.Show("Регистрация прошла успешно!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                string errors = "";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errors += $"Поле: {validationError.PropertyName}\nОшибка: {validationError.ErrorMessage}\n\n";
                    }
                }

                MessageBox.Show($"Ошибка валидации:\n\n{errors}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}\n\n{ex.InnerException?.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
