using System.ComponentModel.DataAnnotations.Schema;

namespace BenTechAPI.Models
{
    [Table("users")]
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string User_name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
