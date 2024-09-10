using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcDotnetGigs.Models
{
    public class ListingVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        [Required]
        public string? IdentityUserId { get; set; }

        [ForeignKey("IdentityUserId")]
        public IdentityUser? User { get; set; }
    }
}
