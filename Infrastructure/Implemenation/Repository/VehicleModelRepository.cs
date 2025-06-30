using Rento.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class VehicleModelRepository : RentoRepository<VehicleModel>
    {
        public VehicleModelRepository(RentoDbContext context) : base(context)
        {
        }
    }
}
