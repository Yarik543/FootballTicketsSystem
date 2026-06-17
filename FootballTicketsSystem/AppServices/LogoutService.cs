using FootballTicketsSystem.AppForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppServices
{
    /// <summary>
    /// Сервис для выхода из системы из любой формы
    /// </summary>
    public static class LogoutService
    {
        public static void RequestLogout(Form currentForm)
        {
            DialogResult confirm = MessageBox.Show(
                "Вы действительно хотите выйти из системы?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            PerformLogout(currentForm);
        }

        /// <summary>
        /// Выполняет выход без подтверждения
        /// </summary>
        public static void PerformLogout(Form currentForm)
        {
            UserSession.CurrentUser = null;
            UserSession.HasSeenTomorrowNotification = false;

            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form != currentForm)
                {
                    form.Hide();
                }
            }

            currentForm?.Hide();

            using (var loginForm = new LoginForm())
            {
                var result = loginForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var mainForm = new MainDashboardForm();
                    mainForm.Show();
                }
                else
                {
                    Application.Exit();
                }
            }

            currentForm?.Close();
        }
    }
}