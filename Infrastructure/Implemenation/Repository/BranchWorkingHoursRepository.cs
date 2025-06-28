using Rento.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class BranchWorkingHoursRepository : RentoRepository<BranchWorkingHour>
    {
        public BranchWorkingHoursRepository(RentoDbContext context) : base(context)
        {
        }

        
    }
}
