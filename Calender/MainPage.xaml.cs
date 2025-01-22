using System.Globalization;
using System;
using  Services;
using Services.Models;

namespace Calender
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        int lastday =0;

        private async void ContentPage_Loaded(object sender, EventArgs e)
        {
            await SetDate();
        }

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
                SeasonImage.Source = season + ".gif";

                // Format and display date
                string date = dayOfWeek + " - " + day.ToString().ChangeChars() + " / " + Month + " / " + year.ToString().ChangeChars();
                
                datetime.Text = date;

                try
                {
                    // Fetch events from the API
                    DayEvent res = await Api.GetResponse(new DateTime(year, month, day));
                    if (res != null)
                    {
                        res.RemoveDuplicateDescriptions();

                        events.Text = "";
                        for (int i = 0; i < res.events.Count; i++)
                        {
                            events.Text += $"{i + 1}. ".ChangeChars() + res.events[i].description.ChangeChars() + "\n";
                        }
                        events.TextColor = res.is_holiday ? Color.FromHex("#FF0000") : Color.FromHex("#000000");
                    }
                }
                catch { events.Text = "Connection issue"; }

                lastday = day; // Update last day
            }

            try
            {
                // Fetch and display dollar price
                int dollarPrice = DollarPriceExtractor.ExtractPrice();
                dollar.Text = "دلار: " + dollarPrice.ToString("N0").ChangeChars();
            }
            catch { dollar.Text = "Price unavailable"; }
        }
    }

}
