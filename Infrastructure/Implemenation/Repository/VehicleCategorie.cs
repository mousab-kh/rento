using Rento.Entities.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class VehicleCategorie : Repository<VehicleModel>
    {
        public VehicleCategorie(RentoDbContext context) : base(context)
        {
        }
    }
}
