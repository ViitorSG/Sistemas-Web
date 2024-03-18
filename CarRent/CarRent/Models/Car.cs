using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public required string Name { get; set; }
        public string? Color { get; set; }
    }
}
