using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.Branchs.Dto
{
    public class UpdateBranchDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public  string Name { get; set; }
        [Precision(15, 15)]
        public decimal Coordinateslatitude { get; set; }
        [Precision(15, 15)]
        public decimal Coordinateslongitude { get; set; }
        public bool IsActive { get; set; }

    }
}
