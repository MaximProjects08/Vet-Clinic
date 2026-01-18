using System.Text.RegularExpressions;

namespace Vet_Clinic
{
    public class Clinic
    {
        public List<Pet> Pets { get; private set; }

        public Clinic()
        {
            Pets = new List<Pet>();
        }

        public void AddPet()
        {
            Console.Clear();
            Console.WriteLine("Enter pet info:");
            Console.WriteLine("species, name, birthdate, weight, color, favourite toy (optional)");

            string input = Console.ReadLine();

            Pet pet;

            if(string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Input cannot be empty");
            }
            string[] splittedInput = input.Split(", ");
            if (splittedInput.Length < 5)
            {
                throw new Exception("Not enough data provided");
            }

            string species = splittedInput[0];
            string name = splittedInput[1];
            string birthdate = splittedInput[2];

            string birthdatePattern = @"^(0[1-9]|[12][0-9]|3[01])[./](0[1-9]|1[0-2])[./]\d{4}$";

            if (!Regex.IsMatch(birthdate, birthdatePattern))
            {
                throw new Exception("Birthdate must be in format DD.MM.YYYY or DD/MM/YYYY.");
            }
                
            
            double weight = double.Parse(splittedInput[3]);
            if(weight <= 0)
            {
                throw new Exception("weight can't be below zero");
            }

            string color = splittedInput[4];


            if (splittedInput.Length > 5)
                pet = new Pet(species, name, birthdate, weight, color, splittedInput[5]);
            else
                pet = new Pet(species, name, birthdate, weight, color);

            Pets.Add(pet);

            Console.WriteLine("\nPet added successfully!");

            Console.WriteLine("\nPet Stats:");
            Console.WriteLine($"Species: {pet.Species}");
            Console.WriteLine($"Name: {pet.Name}");
            Console.WriteLine($"Birthdate: {pet.Birthdate}");
            Console.WriteLine($"Weight: {pet.Weight}");
            Console.WriteLine($"Color: {pet.Color}");
            Console.WriteLine($"Favourite toy: {pet.FavToy ?? "None"}");
            Console.WriteLine($"Status: {pet.Status}");
        }

        public void ShowPets()
        {
            Console.Clear();

            if (Pets.Count == 0)
            {
                Console.WriteLine("No pets in the clinic.");
                return;
            }

            Console.WriteLine("Pets in clinic:\n");

            foreach (Pet pet in Pets)
            {
                Console.WriteLine($"- {pet.Name} ({pet.Species})");
            }
            Console.WriteLine("If you want to look at a specific Pet, type it's name or exit\n\n");
            string input = Console.ReadLine(); 
            if(input == "exit")
            {
                return;
            }
            foreach(Pet pet in Pets)
            {
                if(pet.Name == input)
                {
                    ShowStats(pet);
                }
                else
                {
                    Console.WriteLine("Pet doesn't exist");
                }
            }
        }

        public void ShowStats(Pet pet)
        {
            Console.Clear();

            Console.WriteLine("\nPet Stats:");
            Console.WriteLine($"Species: {pet.Species}");
            Console.WriteLine($"Name: {pet.Name}");
            Console.WriteLine($"Birthdate: {pet.Birthdate}");
            Console.WriteLine($"Weight: {pet.Weight}");
            Console.WriteLine($"Color: {pet.Color}");
            Console.WriteLine($"Favourite toy: {pet.FavToy ?? "None"}");
            Console.WriteLine($"Status: {pet.Status}");

            Adopting(pet);
        }

        public void Adopting(Pet pet)
        {
            if(pet.Status != "Adopted")
            {
                Console.WriteLine($"Do you want to adopt {pet.Name}\n");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No\n");
            }
            else
            {
                Console.WriteLine($"{pet.Name} is laready adopted\n");
            }
            

            string inp = Console.ReadLine();
            if(inp == "1")
            {
                Console.WriteLine($"Congratulations, you adopted {pet.Name}");
                pet.Status = "Adopted";
            }
            if (inp == "2")
            {
                
            }
        }
    }
}
