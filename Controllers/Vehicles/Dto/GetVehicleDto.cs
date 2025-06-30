using Rento.Entities.internalenum;

namespace Rento.Controllers.Vehicle.Dto
{
    public class GetVehicleDto
    {
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public int Year { get; set; }
        public int VehicleManufacturerId { get; set; }
        public required string LicensePlateNumber { get; set; }
        public FuelType FuelTypes { get; set; }
        public int BranchId { get; set; }
    }
}
