namespace Client
{
    partial class WaitingRoom
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
            this.room_ip = new System.Windows.Forms.TextBox();
            this.name_1 = new System.Windows.Forms.TextBox();
            this.name_2 = new System.Windows.Forms.TextBox();
            this.name_3 = new System.Windows.Forms.TextBox();
            this.name_4 = new System.Windows.Forms.TextBox();
            this.back_btn = new System.Windows.Forms.Button();
            this.play_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // room_ip
            // 
            this.room_ip.Location = new System.Drawing.Point(453, 81);
            this.room_ip.Name = "room_ip";
            this.room_ip.Size = new System.Drawing.Size(194, 22);
            this.room_ip.TabIndex = 0;
            this.room_ip.TextChanged += new System.EventHandler(this.room_ip_TextChanged);
            // 
            // name_1
            // 
            this.name_1.Location = new System.Drawing.Point(82, 350);
            this.name_1.Multiline = true;
            this.name_1.Name = "name_1";
            this.name_1.Size = new System.Drawing.Size(134, 30);
            this.name_1.TabIndex = 1;
            this.name_1.TextChanged += new System.EventHandler(this.name_1_TextChanged);
            // 
            // name_2
            // 
            this.name_2.Location = new System.Drawing.Point(307, 350);
            this.name_2.Multiline = true;
            this.name_2.Name = "name_2";
            this.name_2.Size = new System.Drawing.Size(131, 30);
            this.name_2.TabIndex = 2;
            this.name_2.TextChanged += new System.EventHandler(this.name_2_TextChanged);
            // 
            // name_3
            // 
            this.name_3.Location = new System.Drawing.Point(524, 350);
            this.name_3.Multiline = true;
            this.name_3.Name = "name_3";
            this.name_3.Size = new System.Drawing.Size(134, 30);
            this.name_3.TabIndex = 3;
            this.name_3.TextChanged += new System.EventHandler(this.name_3_TextChanged);
            // 
            // name_4
            // 
            this.name_4.Location = new System.Drawing.Point(750, 350);
            this.name_4.Multiline = true;
            this.name_4.Name = "name_4";
            this.name_4.Size = new System.Drawing.Size(128, 30);
            this.name_4.TabIndex = 4;
            this.name_4.TextChanged += new System.EventHandler(this.name_4_TextChanged);
            // 
            // back_btn
            // 
            this.back_btn.Location = new System.Drawing.Point(209, 470);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(187, 38);
            this.back_btn.TabIndex = 5;
            this.back_btn.Text = "back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // play_btn
            // 
            this.play_btn.Location = new System.Drawing.Point(566, 466);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(184, 46);
            this.play_btn.TabIndex = 6;
            this.play_btn.Text = "play";
            this.play_btn.UseVisualStyleBackColor = true;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // WaitingRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.Waiting_room;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(970, 549);
            this.Controls.Add(this.play_btn);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.name_4);
            this.Controls.Add(this.name_3);
            this.Controls.Add(this.name_2);
            this.Controls.Add(this.name_1);
            this.Controls.Add(this.room_ip);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Name = "WaitingRoom";
            this.Text = "WaitingRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox room_ip;
        private System.Windows.Forms.TextBox name_1;
        private System.Windows.Forms.TextBox name_2;
        private System.Windows.Forms.TextBox name_3;
        private System.Windows.Forms.TextBox name_4;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button play_btn;
    }
}