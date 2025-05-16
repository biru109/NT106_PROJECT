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
            guideImages.Add(Image.FromFile("How to play 1.png"));
            guideImages.Add(Image.FromFile("How to play 2.png"));
            guideImages.Add(Image.FromFile("How to play 3.png"));
            guideImages.Add(Image.FromFile("How to play 4.png"));
            guideImages.Add(Image.FromFile("How to play 5.png"));
            guideImages.Add(Image.FromFile("How to play 6.png"));
            guideImages.Add(Image.FromFile("How to play 7.png"));

            ShowImage();

        }
        private void ShowImage()
        {
            pictureBoxGuide.Image = guideImages[currentIndex];
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
    }
}
