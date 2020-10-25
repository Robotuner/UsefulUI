using ESIXamarinLib.Models;

namespace ESIXamarinLib.Controls.ViewModels
{
    public class ExampleSearchModel
    {

        public string ID { get; set; }

        public string Description { get; set; }

        public ExampleSearchModel()
        {
            int numOfChar = RandomLib.random.Next(5, 15);
            this.ID = RandomLib.RandomString(numOfChar, false);
            this.Description = "Just a property to fill out this object.";
        }
    }
}
