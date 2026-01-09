namespace Rento.Entities.Entities
{
    public class RentalRate
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int VehicleCategorieId { get; set; }
        public int VehicleModelId { get; set; }
        public decimal Price { get; set; }
        public int RentalRateSchemasId { get; set; }

        public RentalRate(
            DateOnly startDate,
            DateOnly endDate, 
            int vehicleCategorieId, 
            int vehicleModelId, 
            decimal price, 
            int rentalRateSchemasId)
        {
            SetDates(startDate, endDate);
            vehicleCategorieId= CheckId(vehicleCategorieId);
            vehicleModelId= CheckId(vehicleModelId);
            SetPrice(price) ;
            rentalRateSchemasId = CheckId(rentalRateSchemasId);
        }

        private void SetPrice(decimal price)
        {
            if(price<=0)
                throw new Exception("Invalid VehicleCategorieId");
        }

        private static int CheckId(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid VehicleCategorieId");
            return id;
        }

        private void SetDates(DateOnly startDate, DateOnly endDate)
        {
            if (startDate > endDate)
                throw new Exception("Invalid Date");
            if (startDate< new DateOnly(2025, 7, 1))
                throw new Exception("Invalid Date");

            StartDate = startDate;
            EndDate = endDate;
        }

}
}
