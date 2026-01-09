using Rento.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.BranchWorkingHours.Dto
{
    public class UpdateBranchWorkingHourInputDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        public List<WorkingHourIntervalDto> Intervals { get; set; }

        [Range(1, int.MaxValue)]
        public int BranchId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
    }
}
