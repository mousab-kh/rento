using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.VehicleModels.Dto
{
    public class CreateVehicleModelDto
    {
        [Required]
        public required string Name { get; set; }
        //[Range(1950, int.MaxValue)]
        public int VehicleModelYear { get; set; }
        [Range(1, int.MaxValue)]
        public int VehicleCategorieId { get; set; }
    }
}
