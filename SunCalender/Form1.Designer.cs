namespace SunCalender
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            datetime = new Label();
            richTextBox1 = new RichTextBox();
            notifyIcon1 = new NotifyIcon(components);
            Lbl_Dollar = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(373, 211);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.WaitOnLoad = true;
            pictureBox1.Click += PictureBox1_Click;
            // 
            // datetime
            // 
            datetime.Dock = DockStyle.Top;
            datetime.Font = new Font("dana", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 178);
            datetime.Location = new Point(0, 211);
            datetime.Margin = new Padding(0);
            datetime.Name = "datetime";
            datetime.RightToLeft = RightToLeft.Yes;
            datetime.Size = new Size(373, 56);
            datetime.TabIndex = 1;
            datetime.Text = "تاریخ";
            datetime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Dock = DockStyle.Top;
            richTextBox1.Font = new Font("dana", 12F, FontStyle.Regular, GraphicsUnit.Point, 178);
            richTextBox1.Location = new Point(0, 267);
            richTextBox1.Margin = new Padding(0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(373, 211);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "درحال بارگزاری";
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Visible = true;
            notifyIcon1.Click += NotifyIcon1_Click;
            // 
            // Lbl_Dollar
            // 
            Lbl_Dollar.Dock = DockStyle.Top;
            Lbl_Dollar.Font = new Font("dana", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 178);
            Lbl_Dollar.Location = new Point(0, 478);
            Lbl_Dollar.Name = "Lbl_Dollar";
            Lbl_Dollar.RightToLeft = RightToLeft.Yes;
            Lbl_Dollar.Size = new Size(373, 49);
            Lbl_Dollar.TabIndex = 3;
            Lbl_Dollar.Text = "درحال بارگزاری";
            Lbl_Dollar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 530);
            Controls.Add(Lbl_Dollar);
            Controls.Add(richTextBox1);
            Controls.Add(datetime);
            Controls.Add(pictureBox1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تاریخ";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Label datetime;
        private RichTextBox richTextBox1;
        private NotifyIcon notifyIcon1;
        private Label Lbl_Dollar;
    }
}
