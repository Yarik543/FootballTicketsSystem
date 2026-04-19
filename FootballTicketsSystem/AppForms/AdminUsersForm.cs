using FootballTicketsSystem.AppControls;
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
        }

        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminUsersForm_Load(object sender, EventArgs e)
        {
            LoadDataUsers();
        }

        private void LoadDataUsers()
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
