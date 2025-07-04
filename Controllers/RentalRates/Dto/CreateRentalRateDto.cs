using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.RentalRates.Dto
{
    public class CreateRentalRateDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateOnly EndDate { get; set; }
        [Range(1, int.MaxValue)]
        public int VehicleCategorieId { get; set; }
        [Range(1, int.MaxValue)]
        public int VehicleModelId { get; set; }
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }
        [Range(1, int.MaxValue)]
        public int RentalRateSchemasId { get; set; }
    }
}
