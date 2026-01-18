using Vet_Clinic;

class Program
{
    static void Main()
    {
        Clinic clinic = new Clinic();
        bool closeGame = false;

        while (!closeGame)
        {
            Console.Clear();
            Console.WriteLine("Vet Clinic");
            Console.WriteLine("1. Look up pets");
            Console.WriteLine("2. Add pet");
            Console.WriteLine("3. Exit");
            Console.Write("\nChoice: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    clinic.ShowPets();
                    break;

                case "2":
                    clinic.AddPet();
                    break;

                case "3":
                    closeGame = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            if (!closeGame)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
