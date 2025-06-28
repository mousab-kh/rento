using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.BranchWorkingHours.Dto
{
    public class GetBranchWorkingHourOutputDto
    {
        public int Id { get; set; }
        public List<WorkingHourIntervalDto> Intervals { get; set; }
        public int BranchId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
    }
}
