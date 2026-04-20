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
    public partial class TeamDetailsForm : Form
    {
        public TeamDetailsForm()
        {
            InitializeComponent();
        }

        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
