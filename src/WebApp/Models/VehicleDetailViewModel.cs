using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class VehicleDetailViewModel
    {
        public VehicleDTO Vehicle { get; set; }
        public List<VehicleImage> VehicleImages { get; set; }
        public List<VehicleRentalPriceDTO> VehicleRentalPrices { get; set; }
    }
}
