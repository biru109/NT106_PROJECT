namespace Client
{
    partial class JoinRoom
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
            this.name = new System.Windows.Forms.TextBox();
            this.room_ip = new System.Windows.Forms.TextBox();
            this.join_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(374, 124);
            this.name.Multiline = true;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(268, 37);
            this.name.TabIndex = 0;
            // 
            // room_ip
            // 
            this.room_ip.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.room_ip.Location = new System.Drawing.Point(403, 210);
            this.room_ip.Multiline = true;
            this.room_ip.Name = "room_ip";
            this.room_ip.Size = new System.Drawing.Size(266, 35);
            this.room_ip.TabIndex = 1;
            // 
            // join_btn
            // 
            this.join_btn.Location = new System.Drawing.Point(474, 341);
            this.join_btn.Name = "join_btn";
            this.join_btn.Size = new System.Drawing.Size(195, 49);
            this.join_btn.TabIndex = 2;
            this.join_btn.Text = "Join";
            this.join_btn.UseVisualStyleBackColor = true;
            // 
            // JoinRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.join;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.join_btn);
            this.Controls.Add(this.room_ip);
            this.Controls.Add(this.name);
            this.Name = "JoinRoom";
            this.Text = "JoinRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox room_ip;
        private System.Windows.Forms.Button join_btn;
    }
}