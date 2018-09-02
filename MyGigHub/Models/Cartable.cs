using System.ComponentModel.DataAnnotations.Schema;

namespace MyGigHub.Models
{
    public class Cartable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }
        public string History { get; set; }
        public Priority Mypriority { get; set; }
        public ApplicationUser Receiveruser { get; set; }
        public object MyFile { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    public enum Priority
    {
        High,
        Moderate,
        Low
    }
}