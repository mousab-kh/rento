using Rento.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Rento.Entities.Entities
{
    public class BranchWorkingHour
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartTime { get;  set; }
        public DateTime EndTime { get;  set; }
        public bool IsActive { get;  set; }
        public int BranchId { get; set; }
        public List<WorkingHourIntervalValueObject> Intervals { get;  set; }

        private BranchWorkingHour()
        {
        }

        public static BranchWorkingHour Create(
            DateTime start,
            DateTime end,
            int branchId, 
            List<WorkingHourIntervalValueObject> intervals)
        {
            var branchWorkingHour = new BranchWorkingHour();

            branchWorkingHour.SetDuration(start, end);
            branchWorkingHour.SetBranch(branchId);
            branchWorkingHour.SetIntervals(intervals);
            branchWorkingHour.IsActive = true;

            return branchWorkingHour;
        }

        public void Update(
            DateTime start,
            DateTime end,
            int branchId,
            List<WorkingHourIntervalValueObject> intervals,
            bool isActive)
        {
            SetDuration(start, end);
            SetBranch(branchId);
            SetIntervals(intervals);
            IsActive = isActive;
        }

        private void SetBranch(int branchId)
        {
            if (branchId < 0)
                throw new Exception("Invalid branch id");

            BranchId = branchId;
        }

        private void SetDuration(DateTime start, DateTime end)
        {
            //if (start >= end)
            //    throw new Exception("Invalid dates");

            StartTime = start;
            EndTime = end;
        }


        private void SetIntervals(List<WorkingHourIntervalValueObject> intervals)
        {
            //if (intervals == null || !intervals.Any())
            //    throw new Exception("Invalid  intervals");

            //intervals = intervals.OrderBy(a => a.Start).ToList();
            //for (int i = 0; i + 1 < intervals.Count; i++)
            //{
            //    if (intervals[i].End > intervals[i + 1].Start)
            //        throw new Exception("Invalid  intervals");
            //}

            Intervals = intervals;
        }
    }
}
