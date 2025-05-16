using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLIENT
{
    public partial class WAITINGROOM : Form
    {
        public WAITINGROOM lobby;
        public List<Label> PlayerName = new List<Label>();
        public List<PictureBox> PlayerIcon = new List<PictureBox>();
        public int connectedPlayer = 0;
        public string RoomIP { get; set; }

        public WAITINGROOM(string roomIP)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            lobby = this;
            btnStart.Visible = false;

            RoomIP = roomIP; // Lưu IP lại

            //// thêm tên người chơi
            PlayerName.Add(labelP1);
            PlayerName.Add(labelP2);
            PlayerName.Add(labelP3);
            PlayerName.Add(labelP4);
            // thêm icon
            PlayerIcon.Add(pictureBoxP1);
            PlayerIcon.Add(pictureBoxP2);
            PlayerIcon.Add(pictureBoxP3);
            PlayerIcon.Add(pictureBoxP4);

            roomip.Text = RoomIP;
        }

        public void ShowStartButton()
        {
            btnStart.Visible = true;
        }

       
      

        public void ShowCurrentUser(string ID)
        {
            connectedPlayer++;
            
            switch(connectedPlayer)
            {
                case 1:
                    labelP1.Text = ID;
                    break;
                case 2:
                    labelP2.Text = ID;
                    break;
                case 3:
                    labelP3.Text = ID;
                    break;
                case 4:
                    labelP4.Text = ID;
                    break;
                default:
                    break;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ProcessSocket.Data = "START";
            ProcessSocket.SENDER("");        
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void labelP1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxP2_Click(object sender, EventArgs e)
        {

        }

        private void labelP2_Click(object sender, EventArgs e)
        {

        }

        private void WAITINGROOM_Load(object sender, EventArgs e)
        {

        }

        private void roomip_Click(object sender, EventArgs e)
        {

        }
    }
}
