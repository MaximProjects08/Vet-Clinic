namespace Vet_Clinic
{
    public class Pet
    {
        public Pet(string species, string name, string birthdate, double weight, string color)
        {
            Species = species;
            Name = name;
            Birthdate = birthdate;
            Weight = weight;
            Color = color;

            Status = "Not Adopted";
        }

        public Pet(string species, string name, string birthdate, double weight, string color, string favToy)
           
        {
            Species = species;
            Name = name;
            Birthdate = birthdate;
            Weight = weight;
            Color = color;
            FavToy = favToy;

            Status = "Not Adopted";
        }

        public string Species { get; set; }
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }
        public string? FavToy { get; set; }

        public string Status { get; set; }
    }
}
