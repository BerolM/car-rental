using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Domain.DTOs
{
    public class VehicleFilter
    {
        [Display(Name = "Model")]
        public int VehicleModelId { get; set; }

        [Display(Name = "Şanzıman")]
        public int TransmissionTypeId { get; set; }

        [Display(Name = "Yakıt Türü")]
        public int FuelTypeId { get; set; }

        [Display(Name = "Araç Sınıfı")]
        public int VehicleClassTypeId { get; set; }

        [Display(Name = "Renk")]
        public int ColorTypeId { get; set; }

        [Display(Name ="Lastik Türü")]
        public int TireTypeId { get; set; }

        [Display(Name = "Model Yılı")]
        public RangeValue<int?> ProductionYearRange { get; set; } = new RangeValue<int?>();

        [Display(Name = "Motor Hacmi")]
        public RangeValue<int?> EngineDisplacementRange { get; set; } = new RangeValue<int?>();

        [Display(Name = "Motor Gücü")]
        public RangeValue<int?> HorsepowerRange { get; set; } = new RangeValue<int?>();
    }
}