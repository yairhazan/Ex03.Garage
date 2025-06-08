public class Program{
    public static void Main(string[] args){
        bool exit = false;
        while(!exit){
            Console.WriteLine("Welcome to our garage!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Load vehicles from `Vehicles.db`");
            Console.WriteLine("2. Insert new vehicle into the garage");
            Console.WriteLine("3. Show list of all vehicles, optionally filtered by status");
            Console.WriteLine("4. Change a vehicle's status");
            Console.WriteLine("5. Inflate tires to max pressure");
            Console.WriteLine("6. Refuel a vehicle (license, fuel type, amount)");
            Console.WriteLine("7. Charge electric vehicle (license, time in minutes)");
            Console.WriteLine("8. Display full vehicle details (license, model, owner, wheels, fuel/battery, etc.)");
            Console.WriteLine("9. Exit");
            string choice = Console.ReadLine();
            switch(choice){
                case "1":
                    LoadVehicles();
                    break;
                case "2":
                    InsertNewVehicle();
                    break;
                case "3":
                    ShowListOfVehicles();
                    break;
                case "4":
                    ChangeVehicleStatus();
                    break;
                case "5":
                    InflateTiresToMaxPressure();
                    break;
                case "6":
                    RefuelVehicle();
                    break;
                case "7":
                    ChargeElectricVehicle();
                    break;
                case "8":
                    DisplayFullVehicleDetails();
                    break;
                case "9":
                    exit = true;
                    throw new Exception("Thank you and see you next time!");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    private static void LoadVehicles(){
        Console.WriteLine("Loading vehicles...`");
        //load vehicles from `Vehicles.db`
        try{
            Console.WriteLine(Ex03.GarageLogic.Garage.LoadVehicles());
            Console.WriteLine("Vehicles loaded successfully");
        }
        catch (Exception ex){
            Console.WriteLine($"Error loading vehicles: {ex.Message}");
        }
    }

    private static void InsertNewVehicle(){
        Console.WriteLine("Inserting new vehicle into the garage");

    }
}