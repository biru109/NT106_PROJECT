namespace CLIENT
{
    partial class HowToPlay
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
            this.pictureBoxGuide = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGuide)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGuide
            // 
            this.pictureBoxGuide.Location = new System.Drawing.Point(-3, 1);
            this.pictureBoxGuide.Name = "pictureBoxGuide";
            this.pictureBoxGuide.Size = new System.Drawing.Size(787, 476);
            this.pictureBoxGuide.TabIndex = 0;
            this.pictureBoxGuide.TabStop = false;
            this.pictureBoxGuide.Click += new System.EventHandler(this.pictureBoxGuide_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(714, 159);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(70, 62);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "button1";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(151, 159);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 65);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "button1";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(584, 344);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 47);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "button1";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // HowToPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(782, 475);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pictureBoxGuide);
            this.DoubleBuffered = true;
            this.Name = "HowToPlay";
            this.Text = "HowToPlay";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGuide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGuide;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnExit;
    }
}