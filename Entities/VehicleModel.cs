namespace Rento.Entities
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        public int VehicleCategorieId { get; set; }

        public VehicleModel(string name, int vehicleCategorieId)
        {
            SetModelName(name);
            SetCategory(vehicleCategorieId);
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
