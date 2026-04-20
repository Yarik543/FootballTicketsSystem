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
    public partial class CalendarForm : Form
    {
        public CalendarForm()
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

        private void CalendarForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            flowLayoutPanelMatches.Controls.Clear();

            List <Matches> matches = Program.context.Matches.OrderBy(m=>m.MatchDate).ToList();

            foreach (Matches match in matches)
            {
                flowLayoutPanelMatches.Controls.Add(new MatchControl(match));
            }
        }

        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            CreateMatchesAdminForm createMatchesAdminForm = new CreateMatchesAdminForm();
            DialogResult result = createMatchesAdminForm.ShowDialog();
        }
    }
}
