using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Rento.Controllers.Branchs.Dto
{
    public class UpdateBranchDto
    {

        public int Id { get; set; }
        public  string Name { get; set; }

        [Precision(15, 15)]
        public decimal Coordinateslatitude { get; set; }

        [Precision(15, 15)]
        public decimal Coordinateslongitude { get; set; }
        public bool IsActive { get; set; }

    }
}
