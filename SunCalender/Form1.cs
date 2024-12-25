using System.Globalization;
using SunCalender.Models;
using SunCalender.Services;

namespace SunCalender;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    // Array of Persian month names
    private readonly string[] persianMonths =
    [
        "فروردین",
        "اردیبهشت",
        "خرداد",
        "تیر",
        "مرداد",
        "شهریور",
        "مهر",
        "آبان",
        "آذر",
        "دی",
        "بهمن",
        "اسفند",
    ];

    // Array of Persian day names
    private readonly string[] persianDayofWeek =
    [
        "یکشنبه",
        "دوشنبه",
        "سه شنبه",
        "چهارشنبه",
        "پنجشنبه",
        "جمعه",
        "شنبه",
    ];

    // Stores the last updated day
    private int lastday = 0;

    // Event triggered when the form loads
    private void Form1_Load(object sender, EventArgs e)
    {
        SetDate(); // Initialize date and UI
        timer1.Start(); // Start the timer
    }

    // Updates the UI with the current date and events
    private async void SetDate()
    {
        PersianCalendar pc = new();

        int day = pc.GetDayOfMonth(DateTime.Now);

        if (day != lastday)
        {
            // Update date, time, and display it
            string dayOfWeek = persianDayofWeek[(int)pc.GetDayOfWeek(DateTime.Now)];
            int month = pc.GetMonth(DateTime.Now);
            string Month = persianMonths[month - 1];
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
            }
            catch { richTextBox1.Text = "Connection issue"; }

            lastday = day; // Update last day
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
    private void Timer1_Tick(object sender, EventArgs e)
    {
        SetDate();
    }

    // Show the form when the notify icon is clicked
    private void NotifyIcon1_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Normal;
        this.Show();
    }

    // Prevent form from closing and hide it instead
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        this.Hide();
    }
}