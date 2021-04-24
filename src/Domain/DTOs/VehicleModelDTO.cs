using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class VehicleModelDTO
    {
        public int Id { get; set; }

        [Display(Name="Adı")]
        public string Name { get; set; }
        public int VehicleBrandId { get; set; }

        [Display(Name = "Araç Markası")]
        public string VehicleBrandName { get; set; }
    }
}
