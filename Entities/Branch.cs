using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Rento.Entities
{

    public class Branch
    {
        [SetsRequiredMembers]
        public Branch(string name, decimal coordinatesLatitude, decimal coordinatesLongitude, bool isActive)
        {
            if (name == null) throw new Exception("Invalid Name");
            Name = name;
            CoordinatesLatitude = coordinatesLatitude;
            CoordinatesLongitude = coordinatesLongitude;
            IsActive = isActive;
            

        }

        private Branch ()
        {
        }

     


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
