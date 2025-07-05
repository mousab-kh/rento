using Rento.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.Bookings.Dto
{
    public class GetBookingDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Range(1, int.MaxValue)]
        public int PickupBranchId { get; set; }
        [Range(1, int.MaxValue)]
        public int DropOffBranchId { get; set; }
        [Range(1, int.MaxValue)]
        public int VehicleModelId { get; set; }
        [Range(1, int.MaxValue)]
        public int RentalRateId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DropffDate { get; set; }
        public BookingStatus Status { get; set; }
    }
}
