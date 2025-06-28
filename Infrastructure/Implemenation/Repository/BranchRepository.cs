using Rento.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class BranchRepository : RentoRepository<Branch>
    {
        public BranchRepository(RentoDbContext context) : base(context)
        {
        }
    }
}
