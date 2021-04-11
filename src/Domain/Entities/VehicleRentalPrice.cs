using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class VehicleRentalPrice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int RentalPeriodId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public Vehicle Vehicle { get; set; }
        public RentalPeriod RentalPeriod { get; set; }
    }
}
