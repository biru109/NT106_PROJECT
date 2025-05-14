using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    public partial class WaitingRoom : Form
    {
        private string playerName;
        private string roomIP;
        private ProcessSocket processSocket;

        public WaitingRoom(string playerName, string roomIP, ProcessSocket processSocket)
        {
            InitializeComponent();
            this.playerName = playerName;
            this.roomIP = roomIP;
            this.processSocket = processSocket;

            this.processSocket.OnPlayerListUpdated += UpdatePlayersList;
        }

        private void UpdatePlayersList(List<string> playerNames)
        {
            // Cập nhật tên người chơi trong waiting room
            if (playerNames.Count > 0) name_1.Text = playerNames[0];
            if (playerNames.Count > 1) name_2.Text = playerNames[1];
            if (playerNames.Count > 2) name_3.Text = playerNames[2];
            if (playerNames.Count > 3) name_4.Text = playerNames[3];
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game is starting...");
        }
    }
}
