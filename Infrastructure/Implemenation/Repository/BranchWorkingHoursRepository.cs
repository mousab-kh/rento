using Rento.Entities.Entities;
using Rento.Infrastructure.Implemenation.Db;

namespace Rento.Infrastructure.Implemenation.Repository
{
    public class BranchWorkingHoursRepository : Repository<BranchWorkingHour>
    {
        public BranchWorkingHoursRepository(RentoDbContext context) : base(context)
        {
        }

        
    }
}
