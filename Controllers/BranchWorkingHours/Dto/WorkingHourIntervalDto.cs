using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.BranchWorkingHours.Dto
{
    public class WorkingHourIntervalDto
    {
        [Range(1, int.MaxValue)]
        public int Start { get; set; }

        [Range(1, int.MaxValue)]
        public int End { get; set; }
    }
}
