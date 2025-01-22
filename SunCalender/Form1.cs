using System.Globalization;
using Services.Models;
using Services;

namespace SunCalender;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    private int lastday = 0;

    // Event triggered when the form loads
    private async void Form1_Load(object sender, EventArgs e)
    {
        await SetDate(); // Initialize date and UI
        timer1.Start(); // Start the timer
    }

    // Updates the UI with the current date and events
    private async Task SetDate()
    {
        PersianCalendar pc = new();

        int day = pc.GetDayOfMonth(DateTime.Now);

        if (day != lastday)
        {
            // Update date, time, and display it
            string dayOfWeek = PersianDate.persianDayofWeek[(int)pc.GetDayOfWeek(DateTime.Now)];
            int month = pc.GetMonth(DateTime.Now);
            string Month = PersianDate.persianMonths[month - 1];
            int year = pc.GetYear(DateTime.Now);

            // Determine season and update the image
            string season = month switch
            {
                <= 3 => "spring",
                <= 6 => "summer",
                <= 9 => "autumn",
                _ => "winter"
            };
            pictureBox1.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(season);

            // Format and display date
            string date = dayOfWeek + " - " + day.ToString().ChangeChars() + " / " + Month + " / " + year.ToString().ChangeChars();
            notifyIcon1.Text = date;
            datetime.Text = date;

            try
            {
                // Fetch events from the API
                DayEvent res = await Api.GetResponse(new DateTime(year, month, day));
                if (res != null)
                {
                    res.RemoveDuplicateDescriptions();

                    // Display events in the rich text box
                    richTextBox1.Text = "";
                    for (int i = 0; i < res.events.Count; i++)
                    {
                        richTextBox1.Text += $"{i + 1}. ".ChangeChars() + res.events[i].description.ChangeChars() + "\n";
                    }
                    richTextBox1.ForeColor = res.is_holiday ? Color.Red : Color.Black;
                }

                lastday = day; // Update last day
            }
            catch
            {
                richTextBox1.Text = "Connection issue";
                lastday = 0;
            }
        }

        try
        {
            // Fetch and display dollar price
            int dollarPrice = DollarPriceExtractor.ExtractPrice();
            Lbl_Dollar.Text = "دلار: " + dollarPrice.ToString("N0").ChangeChars();
        }
        catch { Lbl_Dollar.Text = "Price unavailable"; }
    }

    // Timer tick event to update date and events
    private async void Timer1_Tick(object sender, EventArgs e)
    {
        await SetDate();
    }

    // Show the form when the notify icon is clicked
    private void NotifyIcon1_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Normal;
        this.Show();
    }

    private async void PictureBox1_Click(object sender, EventArgs e)
    {
        await SetDate();
    }

    // Prevent form from closing and hide it instead
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        this.Hide();
    }

}