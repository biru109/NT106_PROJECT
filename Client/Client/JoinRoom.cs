using System;
using System.Windows.Forms;

namespace Client
{
    public partial class JoinRoom : Form
    {
        private ProcessSocket processSocket;

        public JoinRoom()
        {
            InitializeComponent();
            processSocket = new ProcessSocket();
        }

        private async void btnJoin_Click(object sender, EventArgs e)
        {
            string playerName = name.Text;
            string roomIP = room_ip.Text;

            if (string.IsNullOrEmpty(playerName) || string.IsNullOrEmpty(roomIP))
            {
                MessageBox.Show("Please enter both your name and room IP.");
                return;
            }

            // Tham gia phòng với IP và port đã nhập
            await processSocket.StartClientAsync(roomIP, 12345, playerName); // 12345 là port mẫu
            MessageBox.Show("Joined room successfully!");

            // Sau khi tham gia phòng xong, chuyển đến WaitingRoom
            WaitingRoom waitingRoomForm = new WaitingRoom(playerName, roomIP, processSocket);
            this.Hide(); // Ẩn JoinRoom
            waitingRoomForm.Show();
        }
    }
}
