using System.Collections.Generic;

namespace Telegram.Helpers.JSON
{
    public class TimeTable
    {
        public string Id { get; set; }

        public string Speciality { get; set; }

        public string Group { get; set; }

        public List<Week> Weeks { get; set; }
    }
}
