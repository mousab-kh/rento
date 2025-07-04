using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.VehicleCategories.Dto
{
    public class CreateVehicleCategorieDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
