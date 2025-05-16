using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace CLIENT
{
    public partial class ConnectMenu : Form
    {
      
        public static WAITINGROOM WaitingRoom;
        public ConnectMenu()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
           
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 11000);
            ProcessSocket.Data = "CONNECT";
            ProcessSocket.LINK(serverEP);

            WaitingRoom = new WAITINGROOM(textBoxIP.Text);
            ProcessSocket.SENDER(textBoxName.Text);

            User.ID = textBoxName.Text;

            WaitingRoom.FormClosed += new FormClosedEventHandler(lobby_FormClosed);
            WaitingRoom.ShowStartButton();
            WaitingRoom.Show();
        }

        void lobby_FormClosed(object sender, EventArgs e)
        {
            ProcessSocket.Data = "DISCONNECT";
            ProcessSocket.SENDER(User.ID);
            ProcessSocket.SKCL.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            ProcessSocket.SKCL.Close();
            this.Show();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            
          
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 11000);
            ProcessSocket.Data = "CONNECT";
            ProcessSocket.LINK(serverEP);
            WaitingRoom = new WAITINGROOM(textBoxIP.Text);
            ProcessSocket.SENDER(textBoxName.Text);

            User.ID = textBoxName.Text;

            WaitingRoom.FormClosed += new FormClosedEventHandler(lobby_FormClosed);
            WaitingRoom.Show();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {           
            System.Diagnostics.Process.Start("https://www.unorules.com/");
        }

        private void textBoxName_MouseClick(object sender, MouseEventArgs e)
        {
           textBoxName.Text = "";
        }
    }
}
