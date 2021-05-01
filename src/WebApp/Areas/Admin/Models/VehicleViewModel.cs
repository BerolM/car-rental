using Domain.DTOs;
using System.Collections.Generic;

namespace WebApp.Areas.Admin.Models
{
    public class VehicleViewModel
    {
        public VehicleFilter Filter { get; set; }
        public List<VehicleDTO> Vehicles { get; set; }
    }
}
