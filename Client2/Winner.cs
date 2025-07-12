using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLIENT
{
    public partial class EndForm : Form
    {
        public EndForm(string winnerName)
        {
            InitializeComponent();
            lblWinner.Text = "Người chiến thắng: " + winnerName;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            ConnectMenu menu = new ConnectMenu();
            menu.Show();
            this.Close();
        }
    }


}
