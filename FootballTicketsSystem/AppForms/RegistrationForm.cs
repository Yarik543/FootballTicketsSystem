using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppForms
{
    public partial class RegistrationForm : Form
    {
        Users _users;
        public RegistrationForm()
        {
            InitializeComponent();
            ContextManager.registrationForm = this;
            _users = new Users();
            Program.context.Users.Add(_users);
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // ставим форму ЗА экран слева
            this.Left = -this.Width;

            // по центру по вертикали
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;

            timerForm.Interval = 10;
            timerForm.Tick += timerForm_Tick;
            timerForm.Start();
            toolTipPhone.SetToolTip(tBoxPhone, "Введите номер телефона в формате +7 (000) 000-00-00");
            toolTipFullName.SetToolTip(tBoxName, "Введите ваше ФИО полностью");
            toolTipEmail.SetToolTip(tBoxEmail, "Введите почту в формате mail@gmail.com/@.ru");
            toolTipPassword.SetToolTip(tBoxPassword, "Введите пароль не менее 8 символов");
        }

        private void timerForm_Tick(object sender, EventArgs e)
        {
            int targetX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;

            if (this.Left < targetX)
            {
                this.Left += 20; // скорость
            }
            else
            {
                this.Left = targetX;
                timerForm.Stop();
            }
        }

        private void RegistrationModels()
        {
            _users.Phone = tBoxPhone.Text.Trim();
            _users.FullName = tBoxName.Text.Trim();
            _users.Email = tBoxEmail.Text.Trim();
            _users.Password = tBoxPassword.Text.Trim();
            _users.RoleId = 2;
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {

            DialogResult AgreeRegistration = MessageBox.Show("Уверены, что введённые данные верны?", "Запрос подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (AgreeRegistration == DialogResult.No)
            {
                return;
            }

            try
            {
                RegistrationModels();
                Program.context.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
