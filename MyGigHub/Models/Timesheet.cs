using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGigHub.Models
{
    public class Timesheet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string IP { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDay { get; set; }

        public TimeSpan GetDifferenceTimes()
        {
            return EndDay - StartDay;
        }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}