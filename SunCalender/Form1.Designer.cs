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
            timer1 = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);
            Lbl_Dollar = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.winter;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(350, 211);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.WaitOnLoad = true;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // datetime
            // 
            datetime.Font = new Font("dana demibold", 13F, FontStyle.Bold);
            datetime.Location = new Point(12, 226);
            datetime.Name = "datetime";
            datetime.RightToLeft = RightToLeft.Yes;
            datetime.Size = new Size(350, 46);
            datetime.TabIndex = 1;
            datetime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("dana", 12F);
            richTextBox1.Location = new Point(12, 275);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(350, 200);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "Loading";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 3600000;
            timer1.Tick += Timer1_Tick;
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
            Lbl_Dollar.Font = new Font("dana demibold", 13F, FontStyle.Bold);
            Lbl_Dollar.Location = new Point(12, 478);
            Lbl_Dollar.Name = "Lbl_Dollar";
            Lbl_Dollar.RightToLeft = RightToLeft.Yes;
            Lbl_Dollar.Size = new Size(350, 46);
            Lbl_Dollar.TabIndex = 3;
            Lbl_Dollar.Text = "Loading";
            Lbl_Dollar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 534);
            Controls.Add(Lbl_Dollar);
            Controls.Add(richTextBox1);
            Controls.Add(datetime);
            Controls.Add(pictureBox1);
            Font = new Font("Vazir", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
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
        private System.Windows.Forms.Timer timer1;
        private NotifyIcon notifyIcon1;
        private Label Lbl_Dollar;
    }
}
