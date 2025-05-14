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
    public partial class CreateRoom : Form
    {
        public CreateRoom()
        {
            InitializeComponent();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void room_ip_TextChanged(object sender, EventArgs e)
        {

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

            // Giả sử bạn có phương thức để kết nối đến server và tạo phòng
            // Ví dụ: ClientSocket.Connect(roomIP, playerName);

            // Sau khi kết nối thành công, chuyển tới WaitingRoom
            WaitingRoom waitingRoomForm = new WaitingRoom(playerName, roomIP);
            this.Hide(); // Ẩn CreateRoom
            waitingRoomForm.Show();
        }
    }
}
