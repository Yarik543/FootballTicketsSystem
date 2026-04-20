using FootballTicketsSystem.AppControls;
using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace FootballTicketsSystem.AppForms
{
    public partial class TransfersForm : Form
    {
        public TransfersForm()
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
        private void btnMain_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void TransfersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
           flowLayoutPanelTrnasfers.Controls.Clear();

            List<Transfers> transfers = Program.context.Transfers.OrderBy(t => t.DateTransfer).ToList();

            foreach (Transfers transfer in transfers)
            {
                flowLayoutPanelTrnasfers.Controls.Add(new TransfersControl(transfer));
            }
        }

        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            CreateTransfersAdminForm createTransfersAdminForm = new CreateTransfersAdminForm();
            DialogResult result = createTransfersAdminForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }
    }
}
