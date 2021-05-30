using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class RentVehicleDTO
    {
        public int VehicleId { get; set; }

        [Display(Name ="Alış Tarihi")]
        public DateTime? DeliveryDate { get; set; }

        [Display(Name = "İade Tarihi")]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "Tutar")]
        public decimal? Amount { get; set; }

        public int VehicleRentalPriceId { get; set; }
        public int NumberOfDays { get; set; }
    }
}
