using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoanManagement.Screens;

namespace LoanManagement
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void simulaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Simulator().ShowDialog();
        }
    }
}
