using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class VehicleRentalPriceDTO
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string VehicleBrandName { get; set; }
        public string VehicleModelName { get; set; }
        public int RentalPeriodId { get; set; }

        [Display(Name ="Kiralama Periyodu")]
        public string RentalPeriodName { get; set; }

        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
    }
}
