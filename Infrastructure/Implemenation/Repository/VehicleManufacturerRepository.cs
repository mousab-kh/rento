using Rento.Entities.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class VehicleManufacturerRepository : Repository<Vehicle>
    {
        public VehicleManufacturerRepository(RentoDbContext context) : base(context)
        {
        }
    }
}
