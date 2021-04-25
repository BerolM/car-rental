using System.Collections.Generic;

namespace Domain.DTOs
{
    public class VehicleFilter
    {
        public int? VehicleBrandId { get; set; }
        public int? VehicleModelId { get; set; }
        public List<int> TransmissionTypeIds { get; } = new List<int>();
        public List<int> FuelTypeIds { get; } = new List<int>();
        public List<int> VehicleClassTypeIds { get; } = new List<int>();
        public List<int> ColorTypeIds { get; } = new List<int>();
        public RangeValue<int> ProductionYearRange { get; set; }
        public RangeValue<int> EngineDisplacementRange { get; set; }
        public RangeValue<int> HorsepowerRange { get; set; }
    }
}