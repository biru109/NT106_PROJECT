
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
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.panelPlayerL = new System.Windows.Forms.Panel();
            this.textBoxNumL = new System.Windows.Forms.TextBox();
            this.labelNameL = new System.Windows.Forms.Label();
            this.panelPlayerR = new System.Windows.Forms.Panel();
            this.textBoxNumR = new System.Windows.Forms.TextBox();
            this.labelNameR = new System.Windows.Forms.Label();
            this.panelPlayerU = new System.Windows.Forms.Panel();
            this.textBoxNumU = new System.Windows.Forms.TextBox();
            this.labelNameU = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.labelTurnOf = new System.Windows.Forms.Label();
            this.panelColors.SuspendLayout();
            this.panelPlayerL.SuspendLayout();
            this.panelPlayerU.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDisplayTest
            // 
            this.textBoxDisplayTest.Location = new System.Drawing.Point(162, 434);
            this.textBoxDisplayTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDisplayTest.Name = "textBoxDisplayTest";
            this.textBoxDisplayTest.Size = new System.Drawing.Size(220, 22);
            this.textBoxDisplayTest.TabIndex = 0;
            // 
            // btnDanhBai
            // 
            this.btnDanhBai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDanhBai.BackgroundImage")));
            this.btnDanhBai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDanhBai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhBai.Location = new System.Drawing.Point(519, 273);
            this.btnDanhBai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDanhBai.Name = "btnDanhBai";
            this.btnDanhBai.Size = new System.Drawing.Size(70, 62);
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
            this.btnBocBai.Location = new System.Drawing.Point(235, 225);
            this.btnBocBai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBocBai.Name = "btnBocBai";
            this.btnBocBai.Size = new System.Drawing.Size(125, 152);
            this.btnBocBai.TabIndex = 2;
            this.btnBocBai.UseVisualStyleBackColor = true;
            this.btnBocBai.Click += new System.EventHandler(this.btnBocBai_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Location = new System.Drawing.Point(12, 14);
            this.btnRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(37, 31);
            this.btnRed.TabIndex = 3;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Yellow;
            this.btnYellow.Location = new System.Drawing.Point(56, 14);
            this.btnYellow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(39, 31);
            this.btnYellow.TabIndex = 4;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Lime;
            this.btnGreen.Location = new System.Drawing.Point(12, 50);
            this.btnGreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(37, 31);
            this.btnGreen.TabIndex = 5;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.Location = new System.Drawing.Point(56, 50);
            this.btnBlue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(39, 31);
            this.btnBlue.TabIndex = 6;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnDiscardPileCard
            // 
            this.btnDiscardPileCard.Location = new System.Drawing.Point(384, 227);
            this.btnDiscardPileCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDiscardPileCard.Name = "btnDiscardPileCard";
            this.btnDiscardPileCard.Size = new System.Drawing.Size(107, 154);
            this.btnDiscardPileCard.TabIndex = 7;
            this.btnDiscardPileCard.UseVisualStyleBackColor = true;
            // 
            // panelColors
            // 
            this.panelColors.BackColor = System.Drawing.Color.Transparent;
            this.panelColors.Controls.Add(this.btnRed);
            this.panelColors.Controls.Add(this.btnYellow);
            this.panelColors.Controls.Add(this.btnBlue);
            this.panelColors.Controls.Add(this.btnGreen);
            this.panelColors.Location = new System.Drawing.Point(579, 150);
            this.panelColors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelColors.Name = "panelColors";
            this.panelColors.Size = new System.Drawing.Size(104, 94);
            this.panelColors.TabIndex = 8;
            // 
            // button11
            // 
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button11.Location = new System.Drawing.Point(212, 49);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(61, 89);
            this.button11.TabIndex = 19;
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button12.BackgroundImage")));
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button12.Location = new System.Drawing.Point(181, 51);
            this.button12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(61, 89);
            this.button12.TabIndex = 20;
            this.button12.UseVisualStyleBackColor = true;
            // 
            // panelPlayerL
            // 
            this.panelPlayerL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelPlayerL.BackgroundImage")));
            this.panelPlayerL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelPlayerL.Controls.Add(this.textBoxNumL);
            this.panelPlayerL.Controls.Add(this.button12);
            this.panelPlayerL.Controls.Add(this.button11);
            this.panelPlayerL.Location = new System.Drawing.Point(2, 118);
            this.panelPlayerL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPlayerL.Name = "panelPlayerL";
            this.panelPlayerL.Size = new System.Drawing.Size(171, 338);
            this.panelPlayerL.TabIndex = 24;
            // 
            // textBoxNumL
            // 
            this.textBoxNumL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumL.Location = new System.Drawing.Point(258, 175);
            this.textBoxNumL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumL.Name = "textBoxNumL";
            this.textBoxNumL.Size = new System.Drawing.Size(32, 30);
            this.textBoxNumL.TabIndex = 22;
            this.textBoxNumL.Text = "0";
            this.textBoxNumL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNameL
            // 
            this.labelNameL.AutoSize = true;
            this.labelNameL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNameL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameL.Location = new System.Drawing.Point(12, 86);
            this.labelNameL.Name = "labelNameL";
            this.labelNameL.Size = new System.Drawing.Size(68, 25);
            this.labelNameL.TabIndex = 21;
            this.labelNameL.Text = "Name";
            this.labelNameL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPlayerR
            // 
            this.panelPlayerR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelPlayerR.BackgroundImage")));
            this.panelPlayerR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelPlayerR.Location = new System.Drawing.Point(671, 118);
            this.panelPlayerR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPlayerR.Name = "panelPlayerR";
            this.panelPlayerR.Size = new System.Drawing.Size(166, 326);
            this.panelPlayerR.TabIndex = 29;
            // 
            // textBoxNumR
            // 
            this.textBoxNumR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumR.Location = new System.Drawing.Point(687, 83);
            this.textBoxNumR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumR.Name = "textBoxNumR";
            this.textBoxNumR.Size = new System.Drawing.Size(32, 30);
            this.textBoxNumR.TabIndex = 30;
            this.textBoxNumR.Text = "0";
            this.textBoxNumR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNameR
            // 
            this.labelNameR.AutoSize = true;
            this.labelNameR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameR.Location = new System.Drawing.Point(725, 88);
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
            this.panelPlayerU.Controls.Add(this.textBoxNumU);
            this.panelPlayerU.Controls.Add(this.labelNameU);
            this.panelPlayerU.Location = new System.Drawing.Point(214, 0);
            this.panelPlayerU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPlayerU.Name = "panelPlayerU";
            this.panelPlayerU.Size = new System.Drawing.Size(410, 139);
            this.panelPlayerU.TabIndex = 30;
            // 
            // textBoxNumU
            // 
            this.textBoxNumU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumU.Location = new System.Drawing.Point(252, 179);
            this.textBoxNumU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumU.Name = "textBoxNumU";
            this.textBoxNumU.Size = new System.Drawing.Size(32, 30);
            this.textBoxNumU.TabIndex = 25;
            this.textBoxNumU.Text = "0";
            this.textBoxNumU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNameU
            // 
            this.labelNameU.AutoSize = true;
            this.labelNameU.Location = new System.Drawing.Point(104, 179);
            this.labelNameU.Name = "labelNameU";
            this.labelNameU.Size = new System.Drawing.Size(44, 16);
            this.labelNameU.TabIndex = 24;
            this.labelNameU.Text = "Name";
            this.labelNameU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(12, 560);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(68, 25);
            this.labelName.TabIndex = 34;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNum
            // 
            this.textBoxNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNum.Location = new System.Drawing.Point(114, 482);
            this.textBoxNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(32, 30);
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
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(834, 706);
            this.Controls.Add(this.textBoxNumR);
            this.Controls.Add(this.labelNameL);
            this.Controls.Add(this.labelNameR);
            this.Controls.Add(this.labelTurnOf);
            this.Controls.Add(this.textBoxNum);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.panelPlayerU);
            this.Controls.Add(this.panelPlayerR);
            this.Controls.Add(this.panelPlayerL);
            this.Controls.Add(this.panelColors);
            this.Controls.Add(this.btnDiscardPileCard);
            this.Controls.Add(this.btnBocBai);
            this.Controls.Add(this.btnDanhBai);
            this.Controls.Add(this.textBoxDisplayTest);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "GameBoard";
            this.Text = "Game Table";
            this.Load += new System.EventHandler(this.GAMEROOM_Load);
            this.panelColors.ResumeLayout(false);
            this.panelPlayerL.ResumeLayout(false);
            this.panelPlayerL.PerformLayout();
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
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
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
    }
}