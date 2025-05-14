using System;
using System.Windows.Forms;

namespace Client
{
    public partial class CreateRoom : Form
    {
        public CreateRoom()
        {
            InitializeComponent();
        }

        private void create_btn_Click_1(object sender, EventArgs e)
        {
            string playerName = name.Text;
            string roomIP = room_ip.Text;

            if (string.IsNullOrEmpty(playerName) || string.IsNullOrEmpty(roomIP))
            {
                MessageBox.Show("Please enter both your name and room IP.");
                return;
            }

            // Sau khi kết nối thành công, chuyển tới WaitingRoom
            WaitingRoom waitingRoomForm = new WaitingRoom(playerName, roomIP);
            this.Hide(); // Ẩn CreateRoom
            waitingRoomForm.Show();
        }
    }
}
