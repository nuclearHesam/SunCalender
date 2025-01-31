using System.Globalization;
using Services.Models;
using Services;
using System.Drawing;

namespace SunCalender;

public partial class Form1 : Form
{
    private readonly PersianCalendar pc = new();
    private int lastday = 0;

    public Form1()
    {
        InitializeComponent();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await SetDate();
        _ = Task.Run(UpdateLoop);
    }

    private async Task UpdateLoop()
    {
        while (true)
        {
            await Task.Delay(60000);
            await SetDate();
        }
    }

    private async Task SetDate()
    {
        try
        {
            int day = pc.GetDayOfMonth(DateTime.Now);

            if (day != lastday)
            {
                string dayOfWeek = PersianDate.persianDayofWeek[(int)pc.GetDayOfWeek(DateTime.Now)];
                int month = pc.GetMonth(DateTime.Now);
                string Month = PersianDate.persianMonths[month - 1];
                int year = pc.GetYear(DateTime.Now);

                string season = month switch
                {
                    <= 3 => "spring",
                    <= 6 => "summer",
                    <= 9 => "autumn",
                    _ => "winter"
                };

                var newImage = (Image)Properties.Resources.ResourceManager.GetObject(season);
                if (pictureBox1.Image != newImage)
                {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = newImage;
                }

                string date = $"{dayOfWeek} - {day.ToString().ChangeChars()} / {Month} / {year.ToString().ChangeChars()}";
                notifyIcon1.Text = date;
                datetime.Text = date;

                DayEvent res = await Api.GetResponse(new DateTime(year, month, day));
                richTextBox1.Text = res?.events.Count > 0
                    ? string.Join("\n", res.events.Select((e, i) => $"{i + 1}. {e.description.ChangeChars()}"))
                    : "خبری نیست!.";
                richTextBox1.ForeColor = res?.is_holiday == true ? Color.Red : Color.Black;

                lastday = day;
            }

            Lbl_Dollar.Text = "دلار: " + DollarPriceExtractor.ExtractPrice().ToString("N0").ChangeChars();
        }
        catch
        {
            richTextBox1.Text = "مشکل اتصال!";
            Lbl_Dollar.Text = "قیمت دردسترس نیست!";
        }
    }

    private void NotifyIcon1_Click(object sender, EventArgs e)
    {
        if (this.WindowState == FormWindowState.Minimized)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }
    }

    private async void PictureBox1_Click(object sender, EventArgs e)
    {
        await SetDate();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
