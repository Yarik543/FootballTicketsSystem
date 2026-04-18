using FootballTicketsSystem.AppForms;
using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
using FootballTicketsSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string email = tBoxEmail.Text.Trim();
            string password = tBoxPassword.Text.Trim();
            var user = Program.context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                UserSession.CurrentUser = user; // user из БД
                MainDashboardForm mainDashboardForm = new MainDashboardForm();
                DialogResult MainForm = mainDashboardForm.ShowDialog();
                this.Hide();
                if (MainForm == DialogResult.OK)
                {
                    this.Show();
                }
            }

            else MessageBox.Show("Пользователь с такими данными не найден");


        }

    }
}
