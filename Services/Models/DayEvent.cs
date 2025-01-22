
namespace Services.Models;

public class Event
{
    public string? description { get; set; }
    public string? additional_description { get; set; }
    public bool is_holiday { get; set; }
    public bool is_religious { get; set; }
}

public class DayEvent
{
    public bool is_holiday { get; set; }
    public List<Event>? events { get; set; }

    public void RemoveDuplicateDescriptions()
    {
        if (events != null)
        {
            events = events
                .GroupBy(e => e.description)
                .Select(g => g.First())
                .ToList();
        }
    }
}
