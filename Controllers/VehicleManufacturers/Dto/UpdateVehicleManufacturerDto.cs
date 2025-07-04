using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.VehicleManufacturers.Dto
{
    public class UpdateVehicleManufacturerDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
