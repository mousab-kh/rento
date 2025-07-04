using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.VehicleCategories.Dto
{
    public class GetVehicleCategorieDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
