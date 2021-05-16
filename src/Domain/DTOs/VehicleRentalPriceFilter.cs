using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class VehicleRentalPriceFilter
    {
        public VehicleRentalPriceFilter(int vehicleId, DateTime? date=null)
        {
            VehicleId = vehicleId;
            Date = date;
        }
        public int VehicleId { get; set; }
        public DateTime? Date { get; set; }

    }
}
