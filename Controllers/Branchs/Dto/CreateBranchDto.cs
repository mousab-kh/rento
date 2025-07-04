

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.Branchs.Dto
{
    public class CreateBranchDto
    {
        [Required]
        public required string Name { get; set; }
        [Precision(15, 15)]
        public decimal Coordinateslatitude { get; set; }
        [Precision(15, 15)]
        public decimal Coordinateslongitude { get; set; }
    }

  

}
