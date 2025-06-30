namespace Rento.Entities
{
    public class VehicleCategorie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }

        public VehicleCategorie(string name)
        {
            SetCategorieName(name);
            IsActive = true;
        }

        private void SetCategorieName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Invalid Categorie Name");

            Name = name;
        }
    }
}
