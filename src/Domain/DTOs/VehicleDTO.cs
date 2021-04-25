using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class VehicleDTO
    {
        public int Id { get; set; }

        public int VehicleBrandId { get; set; }

        [Display(Name = "Marka")]
        public string VehicleBrandName { get; set; }

        public int VehicleModelId { get; set; }

        [Display(Name = "Model")]
        public string VehicleModelName { get; set; }

        public int TransmissionTypeId { get; set; }

        [Display(Name = "Şanzıman")]
        public string TransmissionTypeName { get; set; }

        public int FuelTypeId { get; set; }

        [Display(Name = "Yakıt Türü")]
        public string FuelTypeName { get; set; }

        public int TireTypeId { get; set; }

        [Display(Name = "Lastik Türü")]
        public string TireTypeName { get; set; }

        public int VehicleClassTypeId { get; set; }

        [Display(Name = "Araç Sınıfı")]
        public string VehicleClassTypeName { get; set; }

        public int ColorTypeId { get; set; }

        [Display(Name = "Renk")]
        public string ColorTypeName { get; set; }

        [Display(Name = "Model Yılı")]
        public int ProductionYear { get; set; }

        [Display(Name = "Motor Hacmi")]
        public int EngineDisplacement { get; set; }

        [Display(Name = "Motor Gücü")]
        public int Horsepower { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}