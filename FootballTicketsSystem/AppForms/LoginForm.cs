using FootballTicketsSystem.AppForms;
using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
using FootballTicketsSystem.Helpers;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace FootballTicketsSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ContextManager.loginForm = this;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
            this.Show();
        }

        private void btnLoginSystem_Click(object sender, EventArgs e)
        {
            // Проверка пустых полей
            if (string.IsNullOrWhiteSpace(tBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(tBoxPassword.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = tBoxEmail.Text.Trim();
            string password = tBoxPassword.Text;

            // 1. СНАЧАЛА ищем пользователя
            var user = Program.context.Users
                .Include(u => u.Roles)
                .FirstOrDefault(u => u.Email == email);

            // 2. Проверяем, найден ли пользователь
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка входа",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Только если пользователь найден, проверяем пароль
            bool isValid = PasswordHelper.VerifyPassword(
                password,
                user.PasswordHash,
                user.PasswordSalt);

            if (!isValid)
            {
                MessageBox.Show("Неверный пароль", "Ошибка входа",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Если всё верно — входим в систему
            UserSession.CurrentUser = user;

            // Открываем главную форму
            MainDashboardForm mainForm = new MainDashboardForm();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();

        }

    }
}
