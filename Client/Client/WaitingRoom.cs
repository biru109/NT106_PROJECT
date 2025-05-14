using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace Client
{
    public partial class WaitingRoom : Form
    {
        private string playerName;
        private string roomIP;
        private List<string> playersInRoom;

        // Constructor nhận tham số playerName và roomIP

        public WaitingRoom(string playerName, string roomIP)
        {
            InitializeComponent();
            this.playerName = playerName;
            this.roomIP = roomIP;
            playersInRoom = new List<string>();

            // Cập nhật ngay giao diện
            room_ip.Text = roomIP;
            UpdatePlayersList(playerName);
        }



        private void WaitingRoom_Load(object sender, EventArgs e)
        {
            // Cập nhật UI với danh sách người chơi
            UpdatePlayersUI();
        }

        private void UpdatePlayersUI()
        {
            // Cập nhật các TextBox với danh sách người chơi, nếu chưa có người chơi thì để "--"
            name_1.Text = playersInRoom.Count > 0 ? playersInRoom[0] : "--";
            name_2.Text = playersInRoom.Count > 1 ? playersInRoom[1] : "--";
            name_3.Text = playersInRoom.Count > 2 ? playersInRoom[2] : "--";
            name_4.Text = playersInRoom.Count > 3 ? playersInRoom[3] : "--";

            // Nếu có >= 2 người chơi và người tạo phòng là người đầu tiên
            if (playersInRoom.Count >= 2 && playersInRoom[0] == playerName)
            {
                play_btn.Enabled = true; // Kích hoạt nút Play cho người tạo phòng
            }
            else
            {
                play_btn.Enabled = false; // Vô hiệu hóa nút Play cho người không phải là người tạo phòng
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            // Quay lại form CreateRoom
            CreateRoom createRoomForm = new CreateRoom();
            this.Hide();
            createRoomForm.Show();
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            // Bắt đầu trò chơi khi nút Play được nhấn
            MessageBox.Show("Game is starting...");
            // Ví dụ: StartGame();
        }

        // Phương thức cập nhật danh sách người chơi
        public void UpdatePlayersList(string player)
        {
            if (!playersInRoom.Contains(player))
            {
                playersInRoom.Add(player);
                UpdatePlayersUI();
            }
        }

        private void room_ip_TextChanged(object sender, EventArgs e)
        {
            // Cập nhật thông tin IP nếu cần
            room_ip.Text = roomIP;
        }

        private void name_1_TextChanged(object sender, EventArgs e)
        {
            // Không làm gì ở đây, vì thông tin người chơi được cập nhật trong UpdatePlayersUI
        }
    }
}
