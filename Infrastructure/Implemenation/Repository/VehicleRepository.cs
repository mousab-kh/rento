using Rento.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class VehicleRepository : RentoRepository<Vehicle>
    {
        public VehicleRepository(RentoDbContext context) : base(context)
        {
        }
    }
}
