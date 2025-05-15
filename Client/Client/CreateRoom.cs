using System;
using System.Windows.Forms;

namespace Client
{
    public partial class CreateRoom : Form
    {
        private ProcessSocket processSocket;

        public CreateRoom()
        {
            InitializeComponent();
            processSocket = new ProcessSocket();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            string playerName = name.Text;
            string roomIP = room_ip.Text;

            if (string.IsNullOrEmpty(playerName) || string.IsNullOrEmpty(roomIP))
            {
                MessageBox.Show("Please enter both your name and room IP.");
                return;
            }

            // Bắt đầu server với IP và port
            await processSocket.StartServerAsync(roomIP, 12345); // 12345 là port mẫu
            MessageBox.Show("Room created successfully!");

            // Sau khi tạo phòng xong, chuyển đến WaitingRoom
            WaitingRoom waitingRoomForm = new WaitingRoom(playerName, roomIP, processSocket);
            this.Hide(); // Ẩn CreateRoom
            waitingRoomForm.Show();
        }
    }
}
