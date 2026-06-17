using FootballTicketsSystem.AppControls;
using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
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
    public partial class AdminUsersForm : Form
    {
        public AdminUsersForm()
        {
            InitializeComponent();
            ContextManager.adminUsersForm = this;
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);
        }

        /// <summary>
        /// Фон + границы формы
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiPainter.DrawGradientBackground(this, e);
        }
        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminUsersForm_Load(object sender, EventArgs e)
        {
            LoadDataUsers();
        }

        public void LoadDataUsers()
        {
            flowLayoutPanel1.Controls.Clear();

            List <Users> users = Program.context.Users.OrderBy(u=>u.FullName).ToList();

            foreach (Users user in users)
            {
                flowLayoutPanel1.Controls.Add(new UsersControl(user));
            }
        }
    }
}
