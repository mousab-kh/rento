using Rento.Entities.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class VehicleRepository : Repository<Vehicle>
    {
        public VehicleRepository(RentoDbContext context) : base(context)
        {
        }
    }
}
