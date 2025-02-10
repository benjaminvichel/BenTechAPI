using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BenTechAPI.Models
{
    [Table("users")]
    [Index(nameof(User_name),IsUnique=true)]
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string User_name { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public bool IsAdmin { get; set; }
    }
}
