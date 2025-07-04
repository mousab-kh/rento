using Rento.Entities.Enums;
using Rento.Migrations;
using System;
using System.Net.NetworkInformation;

namespace Rento.Entities.Entities
{
    public class Booking
    {

        public int Id { get; set; }
        public int BranchId { get; set; }
        public int BranchWorkingHourId { get; set; }
        public int VehicleId { get; set; }
        public int VehicleCategorieId { get; set; }
        public int VehicleModelId { get; set; }
        public int VehicleManufacturerId { get; set; }
        public int RentalRateId { get; set; }
        public int RentalRateSchemaId { get; set; }
        public  DateTime Pickup  { get; set; }
        public DateTime Dropff  { get; set; }
        public BookingStatus Status { get; set; }


        public Booking(
           int branchId,
           int branchWorkingHourId,
           int vehicleId,
           int vehicleCategorieId,
           int vehicleModelId,
           int vehicleManufacturerId,
           int rentalRateId,
           int rentalRateSchemaId,
           DateTime pickup,
           DateTime dropff,
           BookingStatus status)
        {
            BranchId= CheckId(branchId);
            BranchWorkingHourId= CheckId(branchWorkingHourId);
            VehicleId= CheckId(vehicleId);
            VehicleCategorieId= CheckId(vehicleCategorieId);
            VehicleModelId= CheckId(vehicleModelId);
            VehicleModelId= CheckId(vehicleManufacturerId);
            VehicleManufacturerId= CheckId(rentalRateId);
            RentalRateSchemaId= CheckId(rentalRateSchemaId);
            SetDate(pickup, dropff);
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
            Pickup = pickudate;
            Dropff= dropffdate;
        }

        private void SetStatus(BookingStatus bookingStatus)
        {
            if(!Enum.IsDefined(bookingStatus))
                throw new Exception("Invalid Status");
            Status = bookingStatus;
        }
    }

}
