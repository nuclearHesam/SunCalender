using Newtonsoft.Json;
using SunCalender.Models;

namespace SunCalender.Services;

public class Api
{
    public static async Task<DayEvent> GetResponse(DateTime dateTime)
    {
        using HttpClient client = new();
        try
        {
            string uri = $"https://holidayapi.ir/jalali/{dateTime.Year}/{dateTime.Month}/{dateTime.Day}";

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                DayEvent? root = JsonConvert.DeserializeObject<DayEvent>(jsonResponse);

                return root ?? throw new Exception("NullReferenceException");
            }
            else
            {
                throw new Exception("Error: " + response.StatusCode);
            }
        }
        catch
        {
            throw new Exception("Error");
        }
    }
}

