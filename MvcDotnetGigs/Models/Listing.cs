using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcDotnetGigs.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public string? IdentityUserId { get; set; }

        [ForeignKey("IdentityUserId")]
        public IdentityUser? User { get; set; }
    }
}