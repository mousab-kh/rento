using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rento.Controllers.Branchs.Dto
{
    public class GetBranchDto
    {


        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal CoordinatesLatitude { get; set; }

        public decimal CoordinatesLongitude { get; set; }
        public bool IsActive { get; set; }
    }
}
