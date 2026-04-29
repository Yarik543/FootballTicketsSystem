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
            if(UserSession.CurrentUser.IsAdmin())
            {
                btnAddMatch.Visible = true;
                comboBoxSortGoalsMatch.Visible = true;
            }
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
            LoadDataMatch();
        }

        private void LoadDataMatch()
        {
            flowLayoutPanelMatches.Controls.Clear();

            List <Matches> matches = Program.context.Matches.OrderBy(m=>m.MatchDate).ToList();

            string search = tBoxSearchMatch.Text.Trim().ToLower();
            matches = matches.Where(m=>m.Teams.TeamName.ToLower().Contains(search) || 
            m.Teams1.TeamName.ToLower().Contains(search) ||
            m.Stadiums.NameStadium.ToLower().Contains(search) ||
            m.MatchDate.ToString().ToLower().Contains(search)).ToList();

            if (radioBtnLater.Checked)
            {
                matches = matches.OrderByDescending(m=>m.MatchDate).ToList();
            }

            foreach (Matches match in matches)
            {
                flowLayoutPanelMatches.Controls.Add(new MatchControl(match));
            }
        }

        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            CreateMatchesAdminForm createMatchesAdminForm = new CreateMatchesAdminForm();
            DialogResult result = createMatchesAdminForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadDataMatch();
            }
        }

        private void radioBtnEarly_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataMatch();
        }

        private void radioBtnLater_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataMatch();
        }

        private void tBoxSearchMatch_TextChanged(object sender, EventArgs e)
        {
            LoadDataMatch();
        }
    }
}
