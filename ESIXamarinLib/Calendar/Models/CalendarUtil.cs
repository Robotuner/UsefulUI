using System;
using System.Collections.Generic;

namespace ESIXamarinLib.Calendar.Models
{
    public static class CalendarUtil
    {
        public static List<IIteratorItem> MonthList = new List<IIteratorItem>
        {
            new IteratorItem() {Id = 0, Name= "January"},
            new IteratorItem() {Id = 1, Name= "February"},
            new IteratorItem() {Id = 2, Name= "March"},
            new IteratorItem() {Id = 3, Name= "April"},
            new IteratorItem() {Id = 4, Name= "May"},
            new IteratorItem() {Id = 5, Name= "June"},
            new IteratorItem() {Id = 6, Name= "July"},
            new IteratorItem() {Id = 7, Name= "August"},
            new IteratorItem() {Id = 8, Name= "September"},
            new IteratorItem() {Id = 9, Name= "October"},
            new IteratorItem() {Id = 10, Name= "November"},
            new IteratorItem() {Id = 11, Name= "December"}
        };

        public static List<DayOfWeek> InitWeekHeader(DayOfWeek startOfWeek)
        {
            int daysInWeek = 7;
            int currentday = (int)startOfWeek;
            List<DayOfWeek> dowList = new List<DayOfWeek>();
            for (int d = 0; d < daysInWeek; d++)
            {
                dowList.Add((System.DayOfWeek)currentday++);
                if (currentday == daysInWeek)
                {
                    currentday = 0;
                }
            }
            return dowList;
        }

        public static Dictionary<DayOfWeek, string> GetDayOfWeekDictionary()
        {
            Dictionary<DayOfWeek, string> lst = new Dictionary<DayOfWeek, string>();
            lst.Add(System.DayOfWeek.Sunday, "S");
            lst.Add(System.DayOfWeek.Monday, "M");
            lst.Add(System.DayOfWeek.Tuesday, "T");
            lst.Add(System.DayOfWeek.Wednesday, "W");
            lst.Add(System.DayOfWeek.Thursday, "T");
            lst.Add(System.DayOfWeek.Friday, "F");
            lst.Add(System.DayOfWeek.Saturday, "S");
            return lst;
        }

        public static Dictionary<int, string> GetMonthsDictionary()
        {
            Dictionary<int, string> MonthsDictionary = new Dictionary<int, string>();
            MonthsDictionary.Add(0, "Jan");
            MonthsDictionary.Add(1, "Feb");
            MonthsDictionary.Add(2, "Mar");
            MonthsDictionary.Add(3, "Apr");
            MonthsDictionary.Add(4, "May");
            MonthsDictionary.Add(5, "Jun");
            MonthsDictionary.Add(6, "Jul");
            MonthsDictionary.Add(7, "Aug");
            MonthsDictionary.Add(8, "Sep");
            MonthsDictionary.Add(9, "Oct");
            MonthsDictionary.Add(10, "Nov");
            MonthsDictionary.Add(11, "Dec");

            return MonthsDictionary;
        }
    }
}
