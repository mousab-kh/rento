using Rento.Entities.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class BranchRepository : Repository<Branch>
    {
        public BranchRepository(RentoDbContext context) : base(context)
        {
        }
    }
}
