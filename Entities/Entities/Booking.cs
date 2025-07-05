using Rento.Entities.Enums;
using Rento.Migrations;
using System;
using System.Net.NetworkInformation;

namespace Rento.Entities.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int PickupBranchId { get; set; }
        public int DropOffBranchId { get; set; }
        public int VehicleModelId { get; set; }
        public int RentalRateId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DropffDate { get; set; }
        public BookingStatus Status { get; set; }

        public Booking(
            int pickupBranchId,
            int dropOffBranchId,
            int vehicleModelId,
            int rentalRateId,
            DateTime pickupDate, 
            DateTime dropffDate,
            BookingStatus status)
        {
            PickupBranchId = CheckId(pickupBranchId);
            DropOffBranchId = CheckId(dropOffBranchId);
            VehicleModelId = CheckId(vehicleModelId);
            RentalRateId = CheckId(rentalRateId);
            SetDate(pickupDate, dropffDate);
            SetStatus(status);
        }

        private static int CheckId(int id)
        {
            if (id <= 0) throw new Exception("Invalid Id");
            return id;
        }

        private void SetDate(DateTime pickudate, DateTime dropffdate)
        {
            if (pickudate <= dropffdate) throw new Exception("Invalid Date");
            PickupDate = pickudate;
            DropffDate = dropffdate;
        }

        private void SetStatus(BookingStatus bookingStatus)
        {
            if(!Enum.IsDefined(bookingStatus))
                throw new Exception("Invalid Status");
            Status = bookingStatus;
        }
    }

}
