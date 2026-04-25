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
            ContextManager.transfersForm = this;
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

        public void LoadData()
        {
            flowLayoutPanelTrnasfers.Controls.Clear();

            List<Transfers> transfers = Program.context.Transfers.OrderBy(t => t.DateTransfer).ToList();

            string search = tBoxSearchTransfer.Text.Trim().ToLower();
            transfers = transfers.Where(t =>
                (t.FromTeamName?.ToLower() ?? "").Contains(search) ||
                (t.Players?.FullName?.ToLower() ?? "").Contains(search) ||
                (t.Teams?.TeamName?.ToLower() ?? "").Contains(search)
            ).ToList();

            if (radioBtnNew.Checked)
            {
                transfers = transfers.OrderByDescending(t => t.DateTransfer).ToList();
            }
            else if (radioBtnLater.Checked)
            {
                transfers = transfers.OrderBy(t => t.DateTransfer).ToList();
            }

            foreach (Transfers transfer in transfers)
            {
                flowLayoutPanelTrnasfers.Controls.Add(new TransfersControl(transfer));
            }
        }

        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            CreateTransfersAdminForm createTransfersAdminForm = new CreateTransfersAdminForm();
            DialogResult result = createTransfersAdminForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void radioBtnNew_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void radioBtnLater_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tBoxSearchTransfer_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
