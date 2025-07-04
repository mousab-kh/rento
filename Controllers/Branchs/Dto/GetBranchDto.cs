using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rento.Controllers.Branchs.Dto
{
    public class GetBranchDto
    {

        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Precision(15, 15)]
        public decimal CoordinatesLatitude { get; set; }
        [Precision(15, 15)]
        public decimal CoordinatesLongitude { get; set; }
        public bool IsActive { get; set; }
    }
}
