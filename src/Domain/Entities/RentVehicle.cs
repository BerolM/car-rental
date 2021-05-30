using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RentVehicle
    {
        [Key]
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int VehicleRentalPriceId { get; set; }
        public int UserId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int NumberOfDays { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }

        public Vehicle Vehicle { get; set; }
        public VehicleRentalPrice VehicleRentalPrice { get; set; }
        public User User { get; set; }
    }
}
