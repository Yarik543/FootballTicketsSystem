using FootballTicketsSystem.AppServices;
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
    public partial class CreateTransfersAdminForm : Form
    {
        public CreateTransfersAdminForm()
        {
            InitializeComponent();
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
        private void CreateTransfersAdminForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'footballTicketSystemDataSet.Transfers' table. You can move, or remove it, as needed.
            this.transfersTableAdapter.Fill(this.footballTicketSystemDataSet.Transfers);
        }

        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
