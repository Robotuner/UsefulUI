namespace ESIXamarinLib.Calendar.Models
{
    using System;

    public interface IIteratorItem
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime? NextStartingDT { get; set; }
    }

    public class IteratorItem : IIteratorItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? NextStartingDT { get; set; }

    }
}
