using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLIENT.Properties;



namespace CLIENT
{
    public partial class GameBoard : Form
    {
        public int soluongbaicanrut=0;
        
        public List<List<CardButton>> Card;
        public List<Label> IDNAME;
        public List<TextBox> IDNUMS;
        public int row = 0;
        public bool IsForcedDraw { get; set; } = false;   // đang bị ép rút?
        public string ForcedDrawType { get; set; } = "";      // "dt" hoặc "df"
        public string currentCard;
        public string overrideColor;

        public void EnableActionButtons()
        {
            btnBocBai.Enabled = true;
            btnDanhBai.Enabled = true;
        }

        public class CardButton
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string id { get; set; }
            public Button btn = new Button();
        }

        private Timer gameTimer;
        private int gameTimerLeft = 60;

        private void GameBoard_Load(object sender, EventArgs e)
        {
            StartGameTimer();      
        }

        public GameBoard()
        {

            InitializeComponent();

            this.Load += GameBoard_Load;
            CheckForIllegalCrossThreadCalls = false;
            btnDanhBai.Enabled = false;
            btnBocBai.Enabled = false;
            panelColors.Visible = false;
            // Hiển thị chức năng nút khi di chuyển chuột vào nút
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(btnBocBai, "Bốc bài");

            // Hiển thị chức năng nút khi di chuyển chuột vào nút
            ToolTip toolTip2 = new ToolTip();
            toolTip2.AutoPopDelay = 5000;
            toolTip2.InitialDelay = 500;
            toolTip2.ReshowDelay = 500;
            toolTip2.ShowAlways = true;
            toolTip2.SetToolTip(btnDanhBai, "Đánh bài");
            btnDiscardPileCard.Enabled = false;
            btnDiscardPileCard.FlatStyle = FlatStyle.Flat;
            btnDiscardPileCard.FlatAppearance.BorderSize = 2;
            btnDiscardPileCard.FlatAppearance.BorderColor = Color.Black;
            btnDiscardPileCard.BackgroundImageLayout = ImageLayout.Stretch;
        
            Card = new List<List<CardButton>>();
            IDNAME = new List<Label>();
            IDNUMS = new List<TextBox>();

            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
        }
        

        public void CANPLAY()
        {
            btnDanhBai.Enabled = true;
        }

        public void CANDRAW()
        {
            btnBocBai.Enabled = true;
        }
        
        
        // Load card image to button(too long)
        public void LoadCard(Button btn, string WhatCard)
        {
            if (WhatCard == "r0")
            {
                btn.BackgroundImage = Properties.Resources.r0;
            }
            else if (WhatCard == "r1" || WhatCard == "r1_")
            {
                btn.BackgroundImage = Properties.Resources.r1;
            }
            else if (WhatCard == "r2" || WhatCard == "r2_")
            {
                btn.BackgroundImage = Properties.Resources.r2;
            }
            else if (WhatCard == "r3" || WhatCard == "r3_")
            {
                btn.BackgroundImage = Properties.Resources.r3;
            }
            else if (WhatCard == "r4" || WhatCard == "r4_")
            {
                btn.BackgroundImage = Properties.Resources.r4;
            }
            else if (WhatCard == "r5" || WhatCard == "r5_")
            {
                btn.BackgroundImage = Properties.Resources.r5;
            }
            else if (WhatCard == "b0")
            {
                btn.BackgroundImage = Properties.Resources.b0;
            }
            else if (WhatCard == "b1" || WhatCard == "b1_")
            {
                btn.BackgroundImage = Properties.Resources.b1;
            }
            else if (WhatCard == "b2" || WhatCard == "b2_")
            {
                btn.BackgroundImage = Properties.Resources.b2;
            }
            else if (WhatCard == "b3" || WhatCard == "b3_")
            {
                btn.BackgroundImage = Properties.Resources.b3;
            }
            else if (WhatCard == "b4" || WhatCard == "b4_")
            {
                btn.BackgroundImage = Properties.Resources.b4;
            }
            else if (WhatCard == "b5" || WhatCard == "b5_")
            {
                btn.BackgroundImage = Properties.Resources.b5;
            }
            else if (WhatCard == "y0")
            {
                btn.BackgroundImage = Properties.Resources.y0;
            }
            else if (WhatCard == "y1" || WhatCard == "y1_")
            {
                btn.BackgroundImage = Properties.Resources.y1;
            }
            else if (WhatCard == "y2" || WhatCard == "y2_")
            {
                btn.BackgroundImage = Properties.Resources.y2;
            }
            else if (WhatCard == "y3" || WhatCard == "y3_")
            {
                btn.BackgroundImage = Properties.Resources.y3;
            }
            else if (WhatCard == "y4" || WhatCard == "y4_")
            {
                btn.BackgroundImage = Properties.Resources.y4;
            }
            else if (WhatCard == "y5" || WhatCard == "y5_")
            {
                btn.BackgroundImage = Properties.Resources.y5;
            }
            else if (WhatCard == "g0")
            {
                btn.BackgroundImage = Properties.Resources.g0;
            }
            else if (WhatCard == "g1" || WhatCard == "g1_")
            {
                btn.BackgroundImage = Properties.Resources.g1;
            }
            else if (WhatCard == "g2" || WhatCard == "g2_")
            {
                btn.BackgroundImage = Properties.Resources.g2;
            }
            else if (WhatCard == "g3" || WhatCard == "g3_")
            {
                btn.BackgroundImage = Properties.Resources.g3;
            }
            else if (WhatCard == "g4" || WhatCard == "g4_")
            {
                btn.BackgroundImage = Properties.Resources.g4;
            }
            else if (WhatCard == "g5" || WhatCard == "g5_")
            {
                btn.BackgroundImage = Properties.Resources.g5;
            }
            else if (WhatCard == "wd" || WhatCard == "wd_X" || WhatCard == "wd_Y" || WhatCard == "wd_Z")
            {
                btn.BackgroundImage = Properties.Resources.wd;
            }
            else if (WhatCard == "df" || WhatCard == "df_X" || WhatCard == "df_Y" || WhatCard == "df_Z")
            {
                btn.BackgroundImage = Properties.Resources.d4;
            }
            else if (WhatCard == "Rv_r" || WhatCard == "Rv_r_X")
            {
                btn.BackgroundImage = Properties.Resources.rrv;
            }
            else if (WhatCard == "Rv_b" || WhatCard == "Rv_b_X")
            {
                btn.BackgroundImage = Properties.Resources.brv;
            }
            else if (WhatCard == "Rv_y" || WhatCard == "Rv_y_X")
            {
                btn.BackgroundImage = Properties.Resources.yrv;
            }
            else if (WhatCard == "Rv_g" || WhatCard == "Rv_g_X")
            {
                btn.BackgroundImage = Properties.Resources.grv;
            }
            else if (WhatCard == "s_r" || WhatCard == "s_r_X")
            {
                btn.BackgroundImage = Properties.Resources.rs;
            }
            else if (WhatCard == "s_b" || WhatCard == "s_b_X")
            {
                btn.BackgroundImage = Properties.Resources.bs;
            }
            else if (WhatCard == "s_y" || WhatCard == "s_y_X")
            {
                btn.BackgroundImage = Properties.Resources.ys;
            }
            else if (WhatCard == "s_g" || WhatCard == "s_g_X")
            {
                btn.BackgroundImage = Properties.Resources.gs;
            }
            else if (WhatCard == "dt_r" || WhatCard == "dt_r_X")
            {
                btn.BackgroundImage = Properties.Resources.rd2;
            }
            else if (WhatCard == "dt_b" || WhatCard == "dt_b_X")
            {
                btn.BackgroundImage = Properties.Resources.bd2;
            }
            else if (WhatCard == "dt_y" || WhatCard == "dt_y_X")
            {
                btn.BackgroundImage = Properties.Resources.yd2;
            }
            else if (WhatCard == "dt_g" || WhatCard == "dt_g_X")
            {
                btn.BackgroundImage = Properties.Resources.gd2;
            }
        }

        public string HAFTDATA = "";
        public void ISTURN(string name)
        {
            HAFTDATA = name;
            foreach (var n in IDNAME)
            {
                if (n.Text == name)
                {
                    n.Font = new Font(n.Font, FontStyle.Bold);
                    n.ForeColor = Color.Red;
                    break;
                }
            }
        }
        public void SHOW()
        {
            // Sắp xếp danh sách người chơi theo lượt chơi.
            ProcessSocket.otheruser.Sort((x, y) => x.LUOT.CompareTo(y.LUOT));

            // Cập nhật thông tin người chơi hiện tại (labelName và textBoxNum).
            labelName.Text = UserInfo.ID;
            textBoxNum.Text = UserInfo.SOLUONGBAI.ToString();
            textBoxNum.Tag = UserInfo.ID;
            IDNAME.Add(labelName);
            IDNUMS.Add(textBoxNum);
            
            // Hiển thị thông tin của người chơi khác, bao gồm tên và số lượng bài của họ.
            switch (ProcessSocket.otheruser.Count)
            {
                case 1:
                    {
                        panelPlayerL.Visible = false;
                        panelPlayerR.Visible = false;
                        labelNameU.Text = ProcessSocket.otheruser[0].ID;
                        textBoxNumU.Tag = ProcessSocket.otheruser[0].ID;
                        textBoxNumU.Text = "7";
                        IDNAME.Add(labelNameU);
                        IDNUMS.Add(textBoxNumU);
                    }
                    break;
                case 2:
                    {
                        panelPlayerU.Visible = false;
                        int indexLeft = (UserInfo.LUOT == 2) ? 1 : 0;
                        int indexRight = (UserInfo.LUOT == 2) ? 0 : 1;
                        labelNameL.Text = ProcessSocket.otheruser[indexLeft].ID;
                        textBoxNumL.Tag = ProcessSocket.otheruser[indexLeft].ID;
                        textBoxNumL.Text = "7";
                        labelNameR.Text = ProcessSocket.otheruser[indexRight].ID;
                        textBoxNumR.Tag = ProcessSocket.otheruser[indexRight].ID;
                        textBoxNumR.Text = "7";
                        IDNAME.Add(labelNameL);
                        IDNAME.Add(labelNameR);
                        IDNUMS.Add(textBoxNumL);
                        IDNUMS.Add(textBoxNumR);
                    }
                    break;
                case 3:
                    {
                        int indexLeft, indexMiddle, indexRight;
                        if (UserInfo.LUOT == 1 || UserInfo.LUOT == 4)
                        {
                            indexLeft = 0;
                            indexMiddle = 1;
                            indexRight = 2;
                        }
                        else if (UserInfo.LUOT == 2)
                        {
                            indexLeft = 1;
                            indexMiddle = 2;
                            indexRight = 0;
                        }
                        else
                        {
                            indexLeft = 2;
                            indexMiddle = 0;
                            indexRight = 1;
                        }

                        labelNameL.Text = ProcessSocket.otheruser[indexLeft].ID;
                        textBoxNumL.Tag = ProcessSocket.otheruser[indexLeft].ID;
                        textBoxNumL.Text = "7";
                        labelNameU.Text = ProcessSocket.otheruser[indexMiddle].ID;
                        textBoxNumU.Tag = ProcessSocket.otheruser[indexMiddle].ID;
                        textBoxNumU.Text = "7";
                        labelNameR.Text = ProcessSocket.otheruser[indexRight].ID;
                        textBoxNumR.Tag = ProcessSocket.otheruser[indexRight].ID;
                        textBoxNumR.Text = "7";

                        IDNAME.Add(labelNameL);
                        IDNAME.Add(labelNameU);
                        IDNAME.Add(labelNameR);
                        IDNUMS.Add(textBoxNumL);
                        IDNUMS.Add(textBoxNumU);
                        IDNUMS.Add(textBoxNumR);
                    }
                    break;
            }
        }



        public void ShowCurrentCard()
        {
            LoadCard(btnDiscardPileCard, currentCard);
        }

     
      
        public void NotTurn()
        {
            foreach (var n in IDNAME)
            {
                if (n.Text == HAFTDATA)
                {
                    n.Font = new Font(n.Font, FontStyle.Regular);
                    n.ForeColor = Color.Black;
                    break;
                }
            }
        }
        static int X = 162;
        static int Y = 450;
        static int i = 0;
        static int maxPerRow = 7; // Số lượng tối đa các nút trên mỗi hàng
        static int btnCountInRow = 0; // Biến đếm số lượng nút trên hàng hiện tại

        public void SettingUpCard()
        {
            flowLayoutCards.Controls.Clear(); // Xóa bài cũ nếu có
            Card.Add(new List<CardButton>());

            foreach (var cd in UserInfo.BAI)
            {
                CardButton cardbtn = new CardButton();
                cardbtn.id = cd;
                cardbtn.btn.Tag = cd;
                cardbtn.btn.FlatStyle = FlatStyle.Flat;
                cardbtn.btn.FlatAppearance.BorderSize = 2;
                cardbtn.btn.BackgroundImageLayout = ImageLayout.Stretch;
                cardbtn.btn.Size = new Size(80, 120);
                cardbtn.btn.Click += new EventHandler(cardBtn_Click);

                LoadCard(cardbtn.btn, cd);
                Card[0].Add(cardbtn); // Dùng 1 hàng (hoặc bỏ nếu không cần)

                flowLayoutCards.Controls.Add(cardbtn.btn); // Thêm vào panel
            }

            STOPPLAYING();
        }
        public void ProcessBocBai(string cd)
        {
            if (string.IsNullOrWhiteSpace(cd)) return; // ⚠️ bỏ qua nếu chuỗi rỗng

            CardButton THEBAI = new CardButton();
            THEBAI.id = cd;
            THEBAI.btn.Tag = cd;

            THEBAI.btn.FlatAppearance.BorderSize = 2;
            THEBAI.btn.FlatStyle = FlatStyle.Flat;
            THEBAI.btn.BackgroundImageLayout = ImageLayout.Stretch;
            THEBAI.btn.Size = new Size(80, 120);
            THEBAI.btn.Click += new EventHandler(cardBtn_Click);

            try
            {
                LoadCard(THEBAI.btn, cd); // 🔄 Load hình từ mã bài
            }
            catch
            {
                THEBAI.btn.Text = cd; // ❗ fallback nếu không có hình
            }

            Card[0].Add(THEBAI);
            flowLayoutCards.Controls.Add(THEBAI.btn);
        }

        public void HighlightPlayableCards()
        {
            foreach (CardButton cb in Card[0])
            {
                if (IsPlayable(cb.id)) // ✅ bạn tự viết hàm này theo luật UNO
                {
                    cb.btn.FlatAppearance.BorderColor = Color.Red;
                    cb.btn.FlatAppearance.BorderSize = 2;
                }
                else
                {
                    cb.btn.FlatAppearance.BorderColor = Color.Transparent;
                    cb.btn.FlatAppearance.BorderSize = 0;
                }
            }
        }

        private string EffectiveColor()
        {
            return !string.IsNullOrEmpty(ProcessSocket.room.overrideColor)
                ? ProcessSocket.room.overrideColor
                : GetColor(ProcessSocket.room.currentCard);
        }


        private bool IsPlayable(string card)
        {
            string colorCard = GetColor(card);
            string colorCurrent = EffectiveColor();

            string numCard = new string(card.Where(char.IsDigit).ToArray());
            string numCurrent = new string(ProcessSocket.room.currentCard.Where(char.IsDigit).ToArray());

            if (!string.IsNullOrEmpty(numCard) && numCard == numCurrent)
                return true;

            if (colorCard == colorCurrent)
                return true;

            if (card.Contains("wd") || card.Contains("df"))
                return true;

            if (card.Contains("s") && ProcessSocket.room.currentCard.Contains("s") && colorCard == colorCurrent)
                return true;

            if (card.Contains("Rv") && ProcessSocket.room.currentCard.Contains("Rv") && colorCard == colorCurrent)
                return true;

            if (card.Contains("dt") && ProcessSocket.room.currentCard.Contains("dt") && colorCard == colorCurrent)
                return true;

            return false;
        }






        public void CARDSYNC(string name, string n)
        {
            foreach(var tb in IDNUMS)
            {
                if(tb.Tag.ToString() == name)
                {
                    tb.Text = n;
                }
            }
        }

        public void STOPPLAYING()
        {
            foreach(var row in Card)
            {
                foreach (var cdbtn in row)
                {
                    cdbtn.btn.FlatAppearance.BorderColor = Color.Black;
                    cdbtn.btn.Enabled = false;
                }
            }
        }


        public string ChosenCard = ""; // To assign after btn card clicked

        private void btnDanhBai_Click(object sender, EventArgs e)
        {
            // ✅ Check tính hợp lệ trước
            if (!IsPlayable(ChosenCard))
            {
                MessageBox.Show("Không thể đánh lá bài này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcessSocket.Data = "DanhBai";

            if (ChosenCard.Contains("wd") || ChosenCard.Contains("df"))
            {
                panelColors.Visible = true; // ✅ Chờ người chơi chọn màu → mới trừ bài sau
            }
            else
            {
                string colormessage = UserInfo.ID + ";" + (UserInfo.SOLUONGBAI - 1) + ";" + ChosenCard;
                ProcessSocket.SENDER(colormessage);

                UserInfo.SOLUONGBAI--;
                UserInfo.BAI.Remove(ChosenCard);
                RemoveCardFromHand(ChosenCard);
                UpdateCardCountDisplay();
            }

            btnDanhBai.Enabled = false;
            btnBocBai.Enabled = false;
            currentCard = ChosenCard;
            ShowCurrentCard();
            STOPPLAYING();
        }

        private void StartGameTimer()
        {
            gameTimerLeft = 60;
            lblCountdown.Text = $"Thời gian còn: {gameTimerLeft}s";
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            gameTimerLeft--;
            lblCountdown.Text = $"Thời gian còn: {gameTimerLeft}s";

            if (gameTimerLeft <= 10)
                lblCountdown.ForeColor = Color.Red;
            else
                lblCountdown.ForeColor = Color.Black;

            if (gameTimerLeft <= 0)
            {
                gameTimer.Stop();
                EndGameByTimeout();
            }
        }

        private void EndGameByTimeout()
        {
            MessageBox.Show("Hết thời gian! Đang tính toán winner...", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string winner = UserInfo.ID;
            int minCards = UserInfo.SOLUONGBAI;

            foreach (var tb in IDNUMS)           // IDNUMS là danh sách TextBox bạn đã lưu
            {
                if (int.TryParse(tb.Text, out int num) && num < minCards)
                {
                    minCards = num;
                    winner = tb.Tag.ToString(); // Tag chứa ID của người chơi
                }
            }

            MessageBox.Show($"Người chiến thắng là: {winner} (còn {minCards} lá)", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void RemoveCardFromHand(string cardId)
        {
            foreach (var cd in Card[NowDeck])
            {
                if (cd.btn.Tag.ToString() == cardId)
                {
                    flowLayoutCards.Controls.Remove(cd.btn);
                    break;
                }
            }
        }

        private void UpdateCardCountDisplay()
        {
            foreach (var tb in IDNUMS)
            {
                if (tb.Tag.ToString() == UserInfo.ID)
                {
                    tb.Text = UserInfo.SOLUONGBAI.ToString();
                    break;
                }
            }
        }


        private void btnBocBai_Click(object sender, EventArgs e)
        {
            // BỊ ÉP RÚT
            if (IsForcedDraw)
            {
                string msg = UserInfo.ID + ";" + UserInfo.SOLUONGBAI + ";" + ForcedDrawType;
                ProcessSocket.Data = "SpecialCardDT";
                ProcessSocket.SENDER(msg);

                // reset
                IsForcedDraw = false;
                ForcedDrawType = "";

                btnBocBai.Enabled = false;
                STOPPLAYING();
                return;
            }

            // RÚT BÌNH THƯỜNG
            string colormessage = UserInfo.ID + ";" + UserInfo.SOLUONGBAI;
            ProcessSocket.Data = "AddNewCard";
            ProcessSocket.SENDER(colormessage);

            btnBocBai.Enabled = false;
            STOPPLAYING();
        }



        private void btnRed_Click(object sender, EventArgs e)
        {
            string msg = UserInfo.ID + ";" + (UserInfo.SOLUONGBAI--);

            if (ChosenCard.Contains("df") || ChosenCard.Contains("wd"))
                msg += ";" + ChosenCard;

            msg += ";r";

            ProcessSocket.Data = "DanhBai";
            ProcessSocket.SENDER(msg);

            // Cập nhật bài
            UserInfo.BAI.Remove(ChosenCard);
            currentCard = ChosenCard;
            ShowCurrentCard();

            // Xóa lá bài khỏi panel
            foreach (var cd in Card[0])
            {
                if (cd.btn.Tag.ToString() == ChosenCard)
                {
                    flowLayoutCards.Controls.Remove(cd.btn);
                    break;
                }
            }

            // Cập nhật số lượng bài
            foreach (var tb in IDNUMS)
            {
                if (tb.Tag.ToString() == UserInfo.ID)
                {
                    tb.Text = UserInfo.SOLUONGBAI.ToString();
                    break;
                }
            }

            btnDanhBai.Enabled = false;
            btnBocBai.Enabled = false;
            panelColors.Visible = false;
            STOPPLAYING();
        }


        private void btnYellow_Click(object sender, EventArgs e)
        {
            string msg = UserInfo.ID + ";" + (UserInfo.SOLUONGBAI--);

            if (ChosenCard.Contains("df") || ChosenCard.Contains("wd"))
                msg += ";" + ChosenCard;

            msg += ";y";

            ProcessSocket.Data = "DanhBai";
            ProcessSocket.SENDER(msg);

            UserInfo.BAI.Remove(ChosenCard);
            currentCard = ChosenCard;
            ShowCurrentCard();

            foreach (var cd in Card[0])
            {
                if (cd.btn.Tag.ToString() == ChosenCard)
                {
                    flowLayoutCards.Controls.Remove(cd.btn);
                    break;
                }
            }

            foreach (var tb in IDNUMS)
            {
                if (tb.Tag.ToString() == UserInfo.ID)
                {
                    tb.Text = UserInfo.SOLUONGBAI.ToString();
                    break;
                }
            }

            btnDanhBai.Enabled = false;
            btnBocBai.Enabled = false;
            panelColors.Visible = false;
            STOPPLAYING();
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            string msg = UserInfo.ID + ";" + (UserInfo.SOLUONGBAI--);

            if (ChosenCard.Contains("df") || ChosenCard.Contains("wd"))
                msg += ";" + ChosenCard;

            msg += ";g";

            ProcessSocket.Data = "DanhBai";
            ProcessSocket.SENDER(msg);

            UserInfo.BAI.Remove(ChosenCard);
            currentCard = ChosenCard;
            ShowCurrentCard();

            foreach (var cd in Card[0])
            {
                if (cd.btn.Tag.ToString() == ChosenCard)
                {
                    flowLayoutCards.Controls.Remove(cd.btn);
                    break;
                }
            }

            foreach (var tb in IDNUMS)
            {
                if (tb.Tag.ToString() == UserInfo.ID)
                {
                    tb.Text = UserInfo.SOLUONGBAI.ToString();
                    break;
                }
            }

            btnDanhBai.Enabled = false;
            btnBocBai.Enabled = false;
            panelColors.Visible = false;
            STOPPLAYING();
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            string msg = UserInfo.ID + ";" + (UserInfo.SOLUONGBAI--);

            if (ChosenCard.Contains("df") || ChosenCard.Contains("wd"))
                msg += ";" + ChosenCard;

            msg += ";b";

            ProcessSocket.Data = "DanhBai";
            ProcessSocket.SENDER(msg);

            UserInfo.BAI.Remove(ChosenCard);
            currentCard = ChosenCard;
            ShowCurrentCard();

            foreach (var cd in Card[0])
            {
                if (cd.btn.Tag.ToString() == ChosenCard)
                {
                    flowLayoutCards.Controls.Remove(cd.btn);
                    break;
                }
            }

            foreach (var tb in IDNUMS)
            {
                if (tb.Tag.ToString() == UserInfo.ID)
                {
                    tb.Text = UserInfo.SOLUONGBAI.ToString();
                    break;
                }
            }

            btnDanhBai.Enabled = false;
            btnBocBai.Enabled = false;
            panelColors.Visible = false;
            STOPPLAYING();
        }


        private int NowDeck = 0;




        void cardBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selected = btn.Tag.ToString();

            if (IsPlayable(selected))
            {
                // Reset border cho toàn bộ bài
                foreach (var card in Card[NowDeck])
                {
                    card.btn.FlatAppearance.BorderColor = Color.Black;
                }

                ChosenCard = selected;
                btn.FlatAppearance.BorderColor = Color.Red;
                btnDanhBai.Enabled = true;
            }
            else
            {
                MessageBox.Show("Không thể đánh lá bài này!", "Lỗi luật UNO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void GAMEROOM_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool IsPlayable(string selectedCard, string currentCard)
        {
            if (selectedCard.StartsWith("wd") || selectedCard.StartsWith("df"))
                return true; // Wild cards luôn hợp lệ

            string selectedColor = GetColor(selectedCard);
            string currentColor = GetColor(currentCard);

            string selectedValue = GetCardValue(selectedCard);
            string currentValue = GetCardValue(currentCard);

            return selectedColor == currentColor || selectedValue == currentValue;
        }

        private string GetColor(string cardId)
        {
            if (cardId.Contains("_r") || cardId.StartsWith("r")) return "r";
            if (cardId.Contains("_g") || cardId.StartsWith("g")) return "g";
            if (cardId.Contains("_b") || cardId.StartsWith("b")) return "b";
            if (cardId.Contains("_y") || cardId.StartsWith("y")) return "y";
            return "";
        }


        // Trích ra giá trị chính xác của lá bài
        private string GetCardValue(string card)
        {
            // Xử lý wild và draw four
            if (card.StartsWith("wd") || card.StartsWith("df"))
                return card.Substring(0, 2); // "wd", "df"

            // Bỏ hậu tố _X, _Y hoặc _
            card = card.Replace("_X", "").Replace("_Y", "").Replace("_", "");

            if (card.StartsWith("Rv"))
                return "Rv";
            if (card.StartsWith("s"))
                return "s";
            if (card.StartsWith("dt"))
                return "dt";

            // Trường hợp thông thường như r0, g3, b5
            return card.Substring(1); // trả về giá trị: "0", "1", ..., "9"
        }

        private void panelPlayerU_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCountdown_Click(object sender, EventArgs e)
        {

        }
    }

}
