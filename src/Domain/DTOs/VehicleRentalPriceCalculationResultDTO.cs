using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class VehicleRentalPriceCalculationResultDTO
    {
        public int VehicleRentalPriceId { get; set; }
        public int NumberOfDays { get; set; }
        public decimal Amount { get; set; }
    }
}
