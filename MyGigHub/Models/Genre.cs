using System;
using System.ComponentModel.DataAnnotations;

namespace MyGigHub.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }
    }
}