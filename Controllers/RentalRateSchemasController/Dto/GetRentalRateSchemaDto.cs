using Rento.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.RentalRateSchemasController.Dto
{
    public class GetRentalRateSchemaDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        public RentalRateName RentalName { get; set; }
        [DataType(DataType.Date)]
        public DateOnly DayRentFrom { get; set; }
        [DataType(DataType.Date)]
        public DateOnly DayRentTo { get; set; }
    }
}
