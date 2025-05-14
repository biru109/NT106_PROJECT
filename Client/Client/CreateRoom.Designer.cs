namespace Client
{
    partial class CreateRoom
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
            this.create_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(373, 129);
            this.name.Multiline = true;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(274, 30);
            this.name.TabIndex = 0;
            // 
            // room_ip
            // 
            this.room_ip.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.room_ip.Location = new System.Drawing.Point(405, 212);
            this.room_ip.Multiline = true;
            this.room_ip.Name = "room_ip";
            this.room_ip.Size = new System.Drawing.Size(267, 34);
            this.room_ip.TabIndex = 1;
            // 
            // create_btn
            // 
            this.create_btn.Image = global::Client.Properties.Resources.create_btn;
            this.create_btn.Location = new System.Drawing.Point(456, 335);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(243, 64);
            this.create_btn.TabIndex = 2;
            this.create_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.create_btn.UseVisualStyleBackColor = true;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click_1);
            // 
            // CreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.create;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.room_ip);
            this.Controls.Add(this.name);
            this.DoubleBuffered = true;
            this.Name = "CreateRoom";
            this.Text = "CreateRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox room_ip;
        private System.Windows.Forms.Button create_btn;
    }
}