using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private CreateRoom createRoomForm;   // 👈 Thêm dòng này
        private JoinRoom joinRoomForm;       // 👈 Và dòng này

        public static WaitingRoom WaitingRoom;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (createRoomForm == null || createRoomForm.IsDisposed)
            {
                createRoomForm = new CreateRoom();
                createRoomForm.Show();
            }
            else
            {
                createRoomForm.BringToFront();
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (joinRoomForm == null || joinRoomForm.IsDisposed)
            {
                joinRoomForm = new JoinRoom();
                joinRoomForm.Show();
            }
            else
            {
                joinRoomForm.BringToFront();
            }
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            // Show rules...
        }
    }
}
