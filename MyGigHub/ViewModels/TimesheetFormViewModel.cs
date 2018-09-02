using System;
using System.ComponentModel.DataAnnotations;

namespace MyGigHub.ViewModel
{
    public class TimesheetFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Date { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }

        public DateTime GetDateTimeStart()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, TimeStart));
        }
        public DateTime GetDateTimeEnd()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, TimeEnd));
        }
        public TimeSpan GetDifferenceTime()
        {
            return GetDateTimeStart() - GetDateTimeEnd();
        }
    }
}