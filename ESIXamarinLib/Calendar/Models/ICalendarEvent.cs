using Xamarin.Forms;

namespace ESIXamarinLib.Calendar.Models
{
    public interface ICalendarEvent
    {
        string Description { get; set; }
        string Symbol { get; set; }
        string FontFamily { get; set; }
        Color Color { get; set; }
        double FontSize { get; set; }
    }

    public class CalendarEvent : ICalendarEvent
    {
        public string Description { get; set; }
        public string Symbol { get; set; }
        public string FontFamily { get; set; }
        public Color Color { get; set; }        
        public double FontSize { get; set; }
    }
}
