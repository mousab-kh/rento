using Rento.Entities.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Rento.Entities.Entities
{
    public class RentalRateSchema
    {
        public int Id { get; set; }
        public RentalRateName RentalName { get; private set; }
        public DateOnly DayRentFrom { get; private set; }
        public DateOnly DayRentTo { get; private set; }

        [SetsRequiredMembers]
        public RentalRateSchema(RentalRateName name, DateOnly from, DateOnly to)
        {
            SetRentalRateName(name);
            SetDate(from, to);

        }
        public RentalRateSchema() 
        {
        }

        private void SetDate(DateOnly from, DateOnly to)
        {
            //if (from <= to)
            //    throw new Exception("Invalid Date");
            DayRentTo = to;
            DayRentFrom = from;
        }

        private void SetRentalRateName(RentalRateName name)
        {
            if (!Enum.IsDefined(name))
                throw new Exception("Invalid Rental Rate Name");
            RentalName = name;
        }
    }

}
