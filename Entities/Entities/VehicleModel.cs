using Rento.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace Rento.Entities.Entities
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        public int VehicleModelYear { get; set; }
        public int VehicleCategorieId { get; set; }

        [SetsRequiredMembers]
        public VehicleModel(
            string name, 
            int vehicleCategorieId, 
            int vehicleModelYear)
        {
            SetModelName(name);
            SetCategory(vehicleCategorieId);
            SetVehicleModelYear(vehicleModelYear);
            IsActive = true;
        }

        private void SetVehicleModelYear(int vehicleModelYear)
        {
            //if (vehicleModelYear < 1950) throw new Exception("Invalid vehicle Model Year");
            VehicleModelYear = vehicleModelYear;
        }

        private void SetCategory(int vehicleCategorieId)
        {
            if (vehicleCategorieId <= 0)
                throw new Exception("Invalid Categorie Id");

            VehicleCategorieId = vehicleCategorieId;
        }

        private void SetModelName(string name)
        {
            if (name == null)
                throw new Exception("Invalid Model Name");

            Name = name;
        }
    }
}
