using Rento.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.Vehicles.Dto
{
    public class UpdateVehicleDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Range(1, int.MaxValue)]
        public int VehicleModelId { get; set; }
        [Range(1, int.MaxValue)]
        public int Year { get; set; }
        [Range(1, int.MaxValue)]
        public int VehicleManufacturerId { get; set; }
        public string LicensePlateNumber { get; set; }
        [EnumDataType(typeof(FuelType))]
        public FuelType FuelTypes { get; set; }
        [Range(1, int.MaxValue)]
        public int BranchId { get; set; }
    }
}
