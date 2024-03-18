using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Email { get; set; }
    }
}
