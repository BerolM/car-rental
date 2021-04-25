using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Model")]
        public int VehicleModelId { get; set; }

        [Required]
        [Display(Name = "Şanzıman")]
        public int TransmissionTypeId { get; set; }

        [Required]
        [Display(Name = "Yakıt Türü")]
        public int FuelTypeId { get; set; }

        [Required]
        [Display(Name = "Lastik Türü")]
        public int TireTypeId { get; set; }

        [Required]
        [Display(Name = "Araç Sınıfı")]
        public int VehicleClassTypeId { get; set; }

        [Required]
        [Display(Name = "Renk")]
        public int ColorTypeId { get; set; }

        [Required]
        [Display(Name = "Model Yılı")]
        public int ProductionYear { get; set; }

        [Required]
        [Display(Name = "Motor Hacmi")]
        public int EngineDisplacement { get; set; }

        [Required]
        [Display(Name = "Motor Gücü")]
        public int Horsepower { get; set; }

        [Required]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        public VehicleModel VehicleModel { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public TireType TireType { get; set; }
        public VehicleClassType VehicleClassType { get; set; }
        public ColorType ColorType { get; set; }

    }
}
