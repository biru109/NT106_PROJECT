﻿using System;
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
            string ipAddress = textBoxIP.Text;

            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 11000);
            ProcessSocket.Data = "CONNECT";
            ProcessSocket.LINK(serverEP);
            WaitingRoom = new WAITINGROOM();
            WaitingRoom.ServerIP = ipAddress;
            ProcessSocket.SENDER(textBoxName.Text);

            UserInfo.ID = textBoxName.Text;

            WaitingRoom.FormClosed += new FormClosedEventHandler(lobby_FormClosed);
            WaitingRoom.ShowStartButton();
            this.Hide();
            WaitingRoom.Show();
          
        }

        void lobby_FormClosed(object sender, EventArgs e)
        {
            ProcessSocket.Data = "DISCONNECT";
            ProcessSocket.SENDER(UserInfo.ID);
            ProcessSocket.SKCL.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            ProcessSocket.SKCL.Close();
            this.Show();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {

            string ipAddress = textBoxIP.Text;
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 11000);
            ProcessSocket.Data = "CONNECT";
            ProcessSocket.LINK(serverEP);
            WaitingRoom = new WAITINGROOM();
            this.Hide();

            ProcessSocket.SENDER(textBoxName.Text);

            UserInfo.ID = textBoxName.Text;

            WaitingRoom.FormClosed += new FormClosedEventHandler(lobby_FormClosed);
            WaitingRoom.ServerIP = ipAddress;
            WaitingRoom.Show();
            
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            var howToPlayForm = new HowToPlay();
            howToPlayForm.ShowDialog();
        }

        private void textBoxName_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxName.Text = "";
        }
    }
}
