using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public static WaitingRoom WaitingRoom;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateRoom createRoomForm = new CreateRoom();
            createRoomForm.Show();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            JoinRoom joinRoomForm = new JoinRoom();
            joinRoomForm.Show();
        }
    }
}
