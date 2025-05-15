using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private CreateRoom createRoomForm;   // 👈 Thêm dòng này
        private JoinRoom joinRoomForm;       // 👈 Và dòng này
        private List<JoinRoom> joinRoomForms = new List<JoinRoom>();
        private const int MaxJoinWindows = 3;


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
            joinRoomForms.RemoveAll(f => f == null || f.IsDisposed);

            if (joinRoomForms.Count < MaxJoinWindows)
            {
                JoinRoom newJoinForm = new JoinRoom();
                joinRoomForms.Add(newJoinForm);
                newJoinForm.Show();
            }
            else
            {
                MessageBox.Show("You can only open up to 3 Join windows.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            // Show rules...
        }
    }
}
