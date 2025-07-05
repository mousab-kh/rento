using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.VehicleModels.Dto
{
    public class UpdateVehicleModelDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Range(1950, int.MaxValue)]
        public int VehicleModelYear { get; set; }
        public bool IsActive { get; set; }
        [Range(1, int.MaxValue)]
        public int VehicleCategorieId { get; set; }
    }
}
