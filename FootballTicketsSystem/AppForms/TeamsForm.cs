using FootballTicketsSystem.AppControls;
using FootballTicketsSystem.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppForms
{
    public partial class TeamsForm : Form
    {
        public TeamsForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        /// <summary>
        /// Фон + границы формы
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiPainter.DrawGradientBackground(this, e);
        }

        private void TeamsForm_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
           List<Teams> teams = Program.context.Teams.ToList();

            foreach (Teams team in teams)
            {
                flowLayoutPanelTeamsShow.Controls.Add(new TeamsTournamentControl(team));
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

    }
}
