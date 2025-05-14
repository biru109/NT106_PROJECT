using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class WaitingRoom: Form
    {

        private string playerName;
        private string roomIP;
        private List<string> playersInRoom;
        public WaitingRoom()
        {
            InitializeComponent();
            this.playerName = playerName;
            this.roomIP = roomIP;
            playersInRoom = new List<string>();
        }

        private void WaitingRoom_Load(object sender, EventArgs e)
        {
            // Khi form được load, bạn có thể gọi một phương thức để lấy danh sách người chơi trong phòng
            // UpdatePlayersList();

            // Cập nhật UI với danh sách người chơi
            UpdatePlayersUI();
        }

        private void UpdatePlayersUI()
        {
            // Cập nhật các TextBox với tên người chơi trong phòng
            if (playersInRoom.Count > 0) name_1.Text = playersInRoom[0];
            if (playersInRoom.Count > 1) name_2.Text = playersInRoom[1];
            if (playersInRoom.Count > 2) name_3.Text = playersInRoom[2];
            if (playersInRoom.Count > 3) name_4.Text = playersInRoom[3];

            // Kiểm tra nếu có >= 2 người chơi và chỉ người tạo phòng mới có thể nhấn nút Play
            if (playersInRoom.Count >= 2 && playersInRoom[0] == playerName)
            {
                play_btn.Enabled = true; // Kích hoạt nút Play cho người tạo phòng
            }
            else
            {
                play_btn.Enabled = false; // Vô hiệu hóa nút Play cho người không phải là người tạo phòng
            }
        }
        private void name_3TextChanged(object sender, EventArgs e)
        {

        }

        private void room_ip_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            CreateRoom createRoomForm = new CreateRoom();
            this.Hide();
            createRoomForm.Show();
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game is starting...");

        }

        private void name_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_4_TextChanged(object sender, EventArgs e)
        {

        }
        public void UpdatePlayersList(string player)
        {
            if (!playersInRoom.Contains(player))
            {
                playersInRoom.Add(player);
                UpdatePlayersUI();
            }
        }
    }
}
