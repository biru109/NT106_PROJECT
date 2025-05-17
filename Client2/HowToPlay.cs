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
    public partial class HowToPlay : Form
    {
        private List<Image> guideImages = new List<Image>();
        private int currentIndex = 0;
        public HowToPlay()
        {
            InitializeComponent();
            guideImages.Add(Properties.Resources.Howtoplay1);
            guideImages.Add(Properties.Resources.Howtoplay2);
            guideImages.Add(Properties.Resources.Howtoplay3);
            guideImages.Add(Properties.Resources.Howtoplay4);
            guideImages.Add(Properties.Resources.Howtoplay5);
            guideImages.Add(Properties.Resources.Howtoplay6);
            guideImages.Add(Properties.Resources.Howtoplay7);


            ShowImage();

        }
        private void ShowImage()
        {
            pictureBoxGuide.Image = guideImages[currentIndex];

            // Hiện/ẩn nút Prev
            btnPrev.Visible = currentIndex > 0;

            // Hiện/ẩn nút Next
            btnNext.Visible = currentIndex < guideImages.Count - 1;
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                ShowImage();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < guideImages.Count - 1)
            {
                currentIndex++;
                ShowImage();
            }
        }

        private void pictureBoxGuide_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
