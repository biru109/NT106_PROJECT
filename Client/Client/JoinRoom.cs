using System;
using System.Windows.Forms;

namespace Client
{
    public partial class JoinRoom : Form
    {
        public JoinRoom()
        {
            InitializeComponent();
        }

        private void join_btn_Click(object sender, EventArgs e)
        {
            string playerName = name.Text;
            string roomIP = room_ip.Text;

            if (string.IsNullOrEmpty(playerName) || string.IsNullOrEmpty(roomIP))
            {
                MessageBox.Show("Please enter both your name and room IP.");
                return;
            }

            // Chuyển sang WaitingRoom và truyền thông tin
            WaitingRoom waitingRoomForm = new WaitingRoom(playerName, roomIP);
            this.Hide();
            waitingRoomForm.Show();
        }
    }
}
