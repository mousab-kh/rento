using Rento.Entities.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class VehicleModelRepository : Repository<VehicleModel>
    {
        public VehicleModelRepository(RentoDbContext context) : base(context)
        {
        }
    }
}
