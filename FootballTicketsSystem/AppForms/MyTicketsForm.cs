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
    public partial class MyTicketsForm : Form
    {
        public MyTicketsForm()
        {   
            InitializeComponent();
        }

        private void MyTicketsForm_Load(object sender, EventArgs e)
        {
            List<Tickets> tickets = Program.context.Tickets.ToList();

            foreach (Tickets ticket in tickets)
            {
                flowLayoutPanelTickets.Controls.Add(new MyTicketsControl(ticket));
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
