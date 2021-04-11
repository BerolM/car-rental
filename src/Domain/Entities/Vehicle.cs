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
        public int VehicleMpdelId { get; set; }

        [Required]
        public int TransmissionTypeId { get; set; }

        [Required]
        public int FuelTypeId { get; set; }
        
        [Required]
        public int VehicleClassTypeId { get; set; }

        [Required]
        public int ColorTypeId { get; set; }

        [Required]
        public int ProductionYear { get; set; }

        [Required]
        public int EngineDisplacement { get; set; }

        [Required]
        public int Horsepower { get; set; }

        [Required]
        public string Description { get; set; }

        public VehicleModel VehicleModel { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public TireType TireType { get; set; }
        public VehicleClassType VehicleClassType { get; set; }
        public ColorType ColorType { get; set; }

    }
}
