using ESIXamarinLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESIXamarinLib.Calendar.ViewModels
{
    public class AboutCalendarViewModel : BaseViewModel
    {
        private List<AboutItem> infoList = null;
        public List<AboutItem> InfoList
        {
            get { return infoList; }
            set
            {
                infoList = value;
                OnPropertyChanged("InfoList");
            }
        }

        public void InitInfoList()
        {
            List<AboutItem> lst = new List<AboutItem>();
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "SundayColor",
                Default = "Color.Default"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "SaturdayColor",
                Default = "Color.Default"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "WeekIteratorIconColor",
                Default = "Color.Default"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "WeekSelectorFontSizeColor",
                Default = "Default"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "WeekIteratorNameColor",
                Default = "Color.Default"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "MonthIteratorIconColor",
                Default = "Color.Default"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "MonthSelectorFontSize",
                Default = "Default"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "MonthIteratorNameColor",
                Default = "Color.Default"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "YearIteratorIconColor",
                Default = "Color.Default"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "YearSelectorFontSize",
                Default = "Default"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "YearIteratorNameColor",
                Default = "Color.Default"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "MonthYearSelectorGridBackground",
                Default = "Color.Default"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "MonthSelectorDim",
                Default = "20.0"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "DayOfWeekFontSize",
                Default = "Small"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "DayOfWeekFontAttribute",
                Default = "FontAttributes.None"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "WeekHeaderTextColor",
                Default = "Color.Default"
            });

            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "WeekHeaderDim",
                Default = "22.0"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "WeekViewHeaderBackground",
                Default = "Color.Default"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "NotCurrentMonthTextColor",
                Default = "Color.Default"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "NotCurrentMonthBackgroundColor",
                Default = "Color.Default"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "CalendarDayFontSize",
                Default = "Default"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "TodayColor",
                Default = "Color.Default"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "GridDim",
                Default = "40.0"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "TodayBackgroundColor",
                Default = "Color.Default"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "SelectedDateBackgroundColor",
                Default = "Color.Default"
            });
            lst.Add(new AboutItem()
            {
                ControlName = "monthView",
                Property = "CalendarBackground",
                Default = "Color.Default"
            });

            this.InfoList = lst;
        }
    }
}
