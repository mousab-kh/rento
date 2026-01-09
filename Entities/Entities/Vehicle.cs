using Rento.Entities.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Rento.Entities.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public int Year { get; set; }
        public int VehicleManufacturerId { get; set; }
        public required string LicensePlateNumber { get; set; }
        public FuelType FuelTypes { get; set; }
        public int BranchId { get; set; }

        private Vehicle()
        {
        }

        [SetsRequiredMembers]
        public Vehicle(
            int vehicleModelId,
            int year,
            int vehicleManufacturerId,
            string licensePlateNumber, 
            FuelType fuelTypes, 
            int branchId)
        {
            SetVehicleModelId(vehicleModelId);
            SetYear(year);
            SetVehicleManufacturer(vehicleManufacturerId);
            SetLicensePlateNumber(licensePlateNumber);
            SetFuelTypes(fuelTypes);
            SetBranch(branchId);
        }

        public static void Update()
        {
        }

        private void SetVehicleManufacturer(int vehicleManufacturerId)
        {
            if (vehicleManufacturerId <= 0)
                throw new Exception("Invalid vehicle Manufacturer");

            VehicleManufacturerId = vehicleManufacturerId;
        }

        private void SetBranch(int branchId)
        {
            if (branchId <= 0)
                throw new Exception("Invalid branch id");

            BranchId = branchId;
        }

        private void SetVehicleModelId(int vehicleModelId)
        {
            if (vehicleModelId <= 0)
                throw new Exception("Invalid Vehicle Model");

            VehicleModelId = vehicleModelId;
        }

        private void SetFuelTypes(FuelType fuelTypes)
        {
            if (Enum.IsDefined(fuelTypes))
                throw new Exception("Invalid Fuel Type");
            FuelTypes = fuelTypes;
        }

        private void SetYear(int year)
        {
            if (year.ToString().Length != 4)
                throw new Exception("Invalid year");

            if (year < 1900)
                throw new Exception("Invalid year");

            Year = year;
        }

        private void SetLicensePlateNumber(string licensePlateNumber)
        {
            if (LicensePlateNumber == null)
                throw new Exception("Invalid License PlateNumber");

            if (licensePlateNumber.Length < 4 || licensePlateNumber.Length > 8)
                throw new Exception("Invalid License PlateNumber");

            if (licensePlateNumber.Contains("*") ||
                licensePlateNumber.Contains("+") ||
                licensePlateNumber.Contains("&") ||
                licensePlateNumber.Contains("^") ||
                licensePlateNumber.Contains("%"))
                throw new Exception("Invalid License PlateNumber");

            LicensePlateNumber = licensePlateNumber;
        }
    }
}
