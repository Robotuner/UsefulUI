using System;
using System.Collections.Generic;
using System.Text;

namespace ESIXamarinLib.Models
{
    public interface ISearchItem
    {
        string ID { get; set; }
        string Name { get; set; }
        bool IsSelected { get; set; }
        object Item { get; set; }
        bool CanEdit { get; set; }
    }
}
