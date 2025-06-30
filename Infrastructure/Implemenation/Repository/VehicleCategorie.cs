using Rento.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class VehicleCategorie : RentoRepository<Entities.VehicleModel>
    {
        public VehicleCategorie(RentoDbContext context) : base(context)
        {
        }
    }
}
