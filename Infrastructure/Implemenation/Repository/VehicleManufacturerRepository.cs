using Rento.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class VehicleManufacturerRepository : RentoRepository<Vehicle>
    {
        public VehicleManufacturerRepository(RentoDbContext context) : base(context)
        {
        }
    }
}
