
namespace CLIENT
{
    partial class GameBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
            this.textBoxDisplayTest = new System.Windows.Forms.TextBox();
            this.btnDanhBai = new System.Windows.Forms.Button();
            this.btnBocBai = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnYellow = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnDiscardPileCard = new System.Windows.Forms.Button();
            this.panelColors = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelPlayerL = new System.Windows.Forms.Panel();
            this.labelNameL = new System.Windows.Forms.Label();
            this.textBoxNumL = new System.Windows.Forms.TextBox();
            this.panelPlayerR = new System.Windows.Forms.Panel();
            this.textBoxNumR = new System.Windows.Forms.TextBox();
            this.labelNameR = new System.Windows.Forms.Label();
            this.panelPlayerU = new System.Windows.Forms.Panel();
            this.labelNameU = new System.Windows.Forms.Label();
            this.textBoxNumU = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.labelTurnOf = new System.Windows.Forms.Label();
            this.flowLayoutCards = new System.Windows.Forms.FlowLayoutPanel();
            this.panelColors.SuspendLayout();
            this.panelPlayerL.SuspendLayout();
            this.panelPlayerR.SuspendLayout();
            this.panelPlayerU.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDisplayTest
            // 
            this.textBoxDisplayTest.Location = new System.Drawing.Point(844, 42);
            this.textBoxDisplayTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDisplayTest.Name = "textBoxDisplayTest";
            this.textBoxDisplayTest.Size = new System.Drawing.Size(201, 22);
            this.textBoxDisplayTest.TabIndex = 0;
            // 
            // btnDanhBai
            // 
            this.btnDanhBai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDanhBai.BackgroundImage")));
            this.btnDanhBai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDanhBai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDanhBai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDanhBai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhBai.ForeColor = System.Drawing.Color.Transparent;
            this.btnDanhBai.Location = new System.Drawing.Point(483, 371);
            this.btnDanhBai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDanhBai.Name = "btnDanhBai";
            this.btnDanhBai.Size = new System.Drawing.Size(128, 115);
            this.btnDanhBai.TabIndex = 1;
            this.btnDanhBai.UseVisualStyleBackColor = true;
            this.btnDanhBai.Click += new System.EventHandler(this.btnDanhBai_Click);
            // 
            // btnBocBai
            // 
            this.btnBocBai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBocBai.BackgroundImage")));
            this.btnBocBai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBocBai.FlatAppearance.BorderSize = 0;
            this.btnBocBai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBocBai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBocBai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBocBai.Location = new System.Drawing.Point(209, 186);
            this.btnBocBai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBocBai.Name = "btnBocBai";
            this.btnBocBai.Size = new System.Drawing.Size(110, 130);
            this.btnBocBai.TabIndex = 2;
            this.btnBocBai.UseVisualStyleBackColor = true;
            this.btnBocBai.Click += new System.EventHandler(this.btnBocBai_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Location = new System.Drawing.Point(40, 94);
            this.btnRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(59, 56);
            this.btnRed.TabIndex = 3;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Yellow;
            this.btnYellow.Location = new System.Drawing.Point(131, 94);
            this.btnYellow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(59, 56);
            this.btnYellow.TabIndex = 4;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Lime;
            this.btnGreen.Location = new System.Drawing.Point(217, 94);
            this.btnGreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(59, 56);
            this.btnGreen.TabIndex = 5;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.Location = new System.Drawing.Point(313, 94);
            this.btnBlue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(59, 56);
            this.btnBlue.TabIndex = 6;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnDiscardPileCard
            // 
            this.btnDiscardPileCard.Location = new System.Drawing.Point(335, 186);
            this.btnDiscardPileCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDiscardPileCard.Name = "btnDiscardPileCard";
            this.btnDiscardPileCard.Size = new System.Drawing.Size(103, 130);
            this.btnDiscardPileCard.TabIndex = 7;
            this.btnDiscardPileCard.UseVisualStyleBackColor = true;
            // 
            // panelColors
            // 
            this.panelColors.BackColor = System.Drawing.Color.Transparent;
            this.panelColors.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelColors.BackgroundImage")));
            this.panelColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelColors.Controls.Add(this.label1);
            this.panelColors.Controls.Add(this.label2);
            this.panelColors.Controls.Add(this.btnRed);
            this.panelColors.Controls.Add(this.btnYellow);
            this.panelColors.Controls.Add(this.btnBlue);
            this.panelColors.Controls.Add(this.btnGreen);
            this.panelColors.Location = new System.Drawing.Point(152, 118);
            this.panelColors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelColors.Name = "panelColors";
            this.panelColors.Size = new System.Drawing.Size(420, 251);
            this.panelColors.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(93, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "CHOOSE YOUR COLOR!!!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(75, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "You played a WILD CARD!";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panelPlayerL
            // 
            this.panelPlayerL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelPlayerL.BackgroundImage")));
            this.panelPlayerL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelPlayerL.Controls.Add(this.labelNameL);
            this.panelPlayerL.Controls.Add(this.textBoxNumL);
            this.panelPlayerL.Location = new System.Drawing.Point(12, 141);
            this.panelPlayerL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPlayerL.Name = "panelPlayerL";
            this.panelPlayerL.Size = new System.Drawing.Size(137, 165);
            this.panelPlayerL.TabIndex = 24;
            // 
            // labelNameL
            // 
            this.labelNameL.AutoSize = true;
            this.labelNameL.BackColor = System.Drawing.Color.Transparent;
            this.labelNameL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNameL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameL.Location = new System.Drawing.Point(37, 121);
            this.labelNameL.Name = "labelNameL";
            this.labelNameL.Size = new System.Drawing.Size(68, 25);
            this.labelNameL.TabIndex = 21;
            this.labelNameL.Text = "Name";
            this.labelNameL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNumL
            // 
            this.textBoxNumL.BackColor = System.Drawing.Color.White;
            this.textBoxNumL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNumL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumL.Location = new System.Drawing.Point(102, 140);
            this.textBoxNumL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumL.Name = "textBoxNumL";
            this.textBoxNumL.Size = new System.Drawing.Size(32, 23);
            this.textBoxNumL.TabIndex = 22;
            this.textBoxNumL.Text = "0";
            this.textBoxNumL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelPlayerR
            // 
            this.panelPlayerR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelPlayerR.BackgroundImage")));
            this.panelPlayerR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelPlayerR.Controls.Add(this.textBoxNumR);
            this.panelPlayerR.Controls.Add(this.labelNameR);
            this.panelPlayerR.Location = new System.Drawing.Point(568, 140);
            this.panelPlayerR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPlayerR.Name = "panelPlayerR";
            this.panelPlayerR.Size = new System.Drawing.Size(144, 165);
            this.panelPlayerR.TabIndex = 29;
            // 
            // textBoxNumR
            // 
            this.textBoxNumR.BackColor = System.Drawing.Color.White;
            this.textBoxNumR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNumR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumR.Location = new System.Drawing.Point(112, 143);
            this.textBoxNumR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumR.Name = "textBoxNumR";
            this.textBoxNumR.Size = new System.Drawing.Size(32, 23);
            this.textBoxNumR.TabIndex = 30;
            this.textBoxNumR.Text = "0";
            this.textBoxNumR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNameR
            // 
            this.labelNameR.AutoSize = true;
            this.labelNameR.BackColor = System.Drawing.Color.Transparent;
            this.labelNameR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameR.Location = new System.Drawing.Point(38, 122);
            this.labelNameR.Name = "labelNameR";
            this.labelNameR.Size = new System.Drawing.Size(68, 25);
            this.labelNameR.TabIndex = 29;
            this.labelNameR.Text = "Name";
            this.labelNameR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPlayerU
            // 
            this.panelPlayerU.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelPlayerU.BackgroundImage")));
            this.panelPlayerU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelPlayerU.Controls.Add(this.labelNameU);
            this.panelPlayerU.Controls.Add(this.textBoxNumU);
            this.panelPlayerU.Location = new System.Drawing.Point(244, 1);
            this.panelPlayerU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPlayerU.Name = "panelPlayerU";
            this.panelPlayerU.Size = new System.Drawing.Size(246, 113);
            this.panelPlayerU.TabIndex = 30;
            this.panelPlayerU.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPlayerU_Paint);
            // 
            // labelNameU
            // 
            this.labelNameU.AutoSize = true;
            this.labelNameU.BackColor = System.Drawing.Color.Transparent;
            this.labelNameU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameU.Location = new System.Drawing.Point(146, 59);
            this.labelNameU.Name = "labelNameU";
            this.labelNameU.Size = new System.Drawing.Size(68, 25);
            this.labelNameU.TabIndex = 24;
            this.labelNameU.Text = "Name";
            this.labelNameU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNumU
            // 
            this.textBoxNumU.BackColor = System.Drawing.Color.White;
            this.textBoxNumU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNumU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumU.Location = new System.Drawing.Point(43, 88);
            this.textBoxNumU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumU.Name = "textBoxNumU";
            this.textBoxNumU.Size = new System.Drawing.Size(32, 23);
            this.textBoxNumU.TabIndex = 25;
            this.textBoxNumU.Text = "0";
            this.textBoxNumU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(318, 473);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(68, 25);
            this.labelName.TabIndex = 34;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNum
            // 
            this.textBoxNum.BackColor = System.Drawing.Color.White;
            this.textBoxNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNum.Location = new System.Drawing.Point(426, 463);
            this.textBoxNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(32, 23);
            this.textBoxNum.TabIndex = 35;
            this.textBoxNum.Text = "0";
            this.textBoxNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTurnOf
            // 
            this.labelTurnOf.AutoSize = true;
            this.labelTurnOf.Location = new System.Drawing.Point(232, 141);
            this.labelTurnOf.Name = "labelTurnOf";
            this.labelTurnOf.Size = new System.Drawing.Size(0, 16);
            this.labelTurnOf.TabIndex = 36;
            this.labelTurnOf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutCards
            // 
            this.flowLayoutCards.AutoScroll = true;
            this.flowLayoutCards.Location = new System.Drawing.Point(12, 524);
            this.flowLayoutCards.Name = "flowLayoutCards";
            this.flowLayoutCards.Size = new System.Drawing.Size(700, 226);
            this.flowLayoutCards.TabIndex = 37;
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(724, 753);
            this.Controls.Add(this.flowLayoutCards);
            this.Controls.Add(this.panelColors);
            this.Controls.Add(this.labelTurnOf);
            this.Controls.Add(this.textBoxNum);
            this.Controls.Add(this.textBoxDisplayTest);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.panelPlayerU);
            this.Controls.Add(this.panelPlayerR);
            this.Controls.Add(this.panelPlayerL);
            this.Controls.Add(this.btnDiscardPileCard);
            this.Controls.Add(this.btnBocBai);
            this.Controls.Add(this.btnDanhBai);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "GameBoard";
            this.Text = "Game Table";
            this.Load += new System.EventHandler(this.GAMEROOM_Load);
            this.panelColors.ResumeLayout(false);
            this.panelColors.PerformLayout();
            this.panelPlayerL.ResumeLayout(false);
            this.panelPlayerL.PerformLayout();
            this.panelPlayerR.ResumeLayout(false);
            this.panelPlayerR.PerformLayout();
            this.panelPlayerU.ResumeLayout(false);
            this.panelPlayerU.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDisplayTest;
        private System.Windows.Forms.Button btnDanhBai;
        private System.Windows.Forms.Button btnBocBai;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnDiscardPileCard;
        private System.Windows.Forms.Panel panelColors;
        private System.Windows.Forms.Panel panelPlayerL;
        private System.Windows.Forms.TextBox textBoxNumL;
        private System.Windows.Forms.Label labelNameL;
        private System.Windows.Forms.Panel panelPlayerR;
        private System.Windows.Forms.TextBox textBoxNumR;
        private System.Windows.Forms.Label labelNameR;
        private System.Windows.Forms.Panel panelPlayerU;
        private System.Windows.Forms.TextBox textBoxNumU;
        private System.Windows.Forms.Label labelNameU;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.Label labelTurnOf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutCards;
    }
}