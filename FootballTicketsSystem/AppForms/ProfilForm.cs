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
    public partial class ProfilForm : Form
    {
        public ProfilForm()
        {
            InitializeComponent();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            AdminUsersForm adminUsersForm = new AdminUsersForm();
            DialogResult adminResult = adminUsersForm.ShowDialog();
        }
    }
}
