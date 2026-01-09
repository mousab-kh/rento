using System.Diagnostics.CodeAnalysis;

namespace Rento.Entities.Entities
{
    public class VehicleManufacturer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }

        [SetsRequiredMembers]
        public VehicleManufacturer(string name)
        {
            SetManufacturerName(name);

            IsActive = true;
        }

        private void SetManufacturerName(string name)
        {
            if (name == null) 
                throw new Exception("Invalid Manufacturer Name");

            Name = name;
        }
    }
}
