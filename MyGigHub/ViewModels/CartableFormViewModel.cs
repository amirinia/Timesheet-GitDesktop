using MyGigHub.Models;
using System.Collections.Generic;
namespace MyGigHub.ViewModels
{
    public class CartableFormViewModel
    {
        public string Text { get; set; }
        public string History { get; set; }
        public Priority Mypriority { get; set; }
        public int OwneruserId { get; set; }
        public object MyFile { get; set; }
        public int ApplicationUser { get; set; }
        public IEnumerable<ApplicationUser> applicationUsers { get; set; }
    }
    public enum Priority
    {
        High,
        Moderate,
        Low
    }
}