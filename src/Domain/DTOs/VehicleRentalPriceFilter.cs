using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class VehicleRentalPriceFilter
    {
        public VehicleRentalPriceFilter(int vehicleId)
        {
            VehicleId = vehicleId;
        }
        public int VehicleId { get; set; }
    }
}
