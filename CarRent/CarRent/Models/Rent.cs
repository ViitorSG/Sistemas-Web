using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; } 
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public decimal TotalCost { get; set; }

        [ForeignKey("Car")]
        public int fk_CarId { get; set; }
        [ForeignKey("Client")]
        public int fk_ClientId { get; set; }

        public Car? Car { get; set; }
        public Client? Client { get; set; }
    }
}
