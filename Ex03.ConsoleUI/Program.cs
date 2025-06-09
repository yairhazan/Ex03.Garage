using Ex03.GarageLogic;

public class Program
{
    private static Garage garage = new Garage();
    public static void Main(string[] args)
    {
        
        bool exit = false;
        Console.WriteLine("Welcome to our garage!");
        while (!exit)
        {
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
            switch (choice)
            {
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

    private static void LoadVehicles()
    {
        Console.WriteLine("Loading vehicles...`");
        //load vehicles from `Vehicles.db`
        try
        {
            garage.LoadVehicles();  
            Console.WriteLine("Vehicles loaded successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading vehicles: {ex.Message}");
        }
    }


    private static void InsertNewVehicle()
    {
        Console.WriteLine("Inserting new vehicle into the garage");
        Console.WriteLine("Enter the license plate:");
        string licensePlate = Console.ReadLine();
        bool vehicleExists = garage.checkIfVehicleExists(licensePlate);
        if (vehicleExists)
        {
            Console.WriteLine("Vehicle already exists, changing status to InRepair");
            garage.changeVehicleStatus(licensePlate, eVehicleStatus.InRepair);
        }
        else
        {
            Console.WriteLine("Vehicle does not exist, creating new vehicle");
            Console.WriteLine("Enter the model name:");
            string modelName = Console.ReadLine();
            try
            {
                Vehicle newVehicle = VehicleCreator.CreateVehicle(licensePlate, modelName);
                //a list of strings that will hold questions
                Dictionary<int, Question> questions = newVehicle.getQuestions();
                Dictionary<int, string> answers = new Dictionary<int, string>();
                foreach (KeyValuePair<int, Question> question in questions)
                {
                    Console.WriteLine(question.Value.Question);
                    string answer = Console.ReadLine();
                    answers.Add(question.Key, answer);
                }
                newVehicle.parseAnswers(answers);
                Console.WriteLine("Vehicle created successfully");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine($"Argument error: {ae.Message}");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Format error: {fe.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating vehicle: {ex.Message}");
            }
        }
    }

    private static void ShowListOfVehicles()
    {
        Console.WriteLine("Optionally enter the status filter:");
        string status = Console.ReadLine();
        List<Vehicle> vehicles = Ex03.GarageLogic.Garage.getListOfVehicles(status);
        Console.WriteLine("List of vehicles:");
        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine(vehicle.ToString());
        }
    }
    private static Vehicle getVehiclebyLicensePlate()
    {
        Console.WriteLine("Enter the license plate:");
        string licensePlate = Console.ReadLine();
        return Garage.getVehicle(licensePlate);
    }
    private static void ChangeVehicleStatus()
    {
        try
        {
            Vehicle vehicle = getVehiclebyLicensePlate();
            Console.WriteLine("Enter the new status:");
            Console.WriteLine("1. InRepair");
            Console.WriteLine("2. Repaired");
            Console.WriteLine("3. Paid");
            string status = Console.ReadLine();
            if (status == "1")
            {
                status = "InRepair";
            }
            else if (status == "2")
            {
                status = "Repaired";
            }
            else if (status == "3")
            {
                status = "Paid";
            }
            else
            {
                Console.WriteLine("Invalid status");
                return;
            }
            vehicle.setStatus(status);
            Console.WriteLine("Vehicle status changed successfully");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine($"Argument error: {ae.Message}");
        }
        catch (FormatException fe)
        {
            Console.WriteLine($"Format error: {fe.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error changing vehicle status: {ex.Message}");
        }
    }

    private static void InflateTiresToMaxPressure()
    {

        try
        {
            Vehicle vehicle = getVehiclebyLicensePlate();
            vehicle.inflateTiresToMaxPressure();
            Console.WriteLine("Tires inflated to max pressure successfully");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine($"Argument error: {ae.Message}");
        }
        catch (FormatException fe)
        {
            Console.WriteLine($"Format error: {fe.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inflating tires to max pressure: {ex.Message}");
        }
    }

    private static void RefuelVehicle()
    {
        try
        {
            Vehicle vehicle = getVehiclebyLicensePlate();
            Console.WriteLine("Enter the fuel type:");
            int i = 0;
            foreach (eFuelType fuel in Enum.GetValues(typeof(eFuelType)))
            {
                Console.WriteLine($"{i} - {fuel}");
                i++;
            }
            string fuelType = Console.ReadLine();
            if (!Enum.IsDefined(typeof(eFuelType), fuelType))
            {
                Console.WriteLine("Invalid fuel type");
                return;
            }
            Console.WriteLine("Enter the amount:");
            float amount = float.Parse(Console.ReadLine());
            vehicle.refuel(fuelType, amount);
            Console.WriteLine("Vehicle refueled successfully");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine($"Argument error: {ae.Message}");
        }
        catch (FormatException fe)
        {
            Console.WriteLine($"Format error: {fe.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error refueling vehicle: {ex.Message}");
        }
    }
    private static void ChargeElectricVehicle()
    {
        try
        {
            Vehicle vehicle = getVehiclebyLicensePlate();
            Console.WriteLine("Enter the amount of time to charge in minutes:");
            float time = float.Parse(Console.ReadLine());
            vehicle.charge(time);
            Console.WriteLine("Vehicle charged successfully");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine($"Argument error: {ae.Message}");
        }
        catch (FormatException fe)
        {
            Console.WriteLine($"Format error: {fe.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error charging vehicle: {ex.Message}");
        }
    }
    private static void DisplayFullVehicleDetails()
    {
        Vehicle vehicle = getVehiclebyLicensePlate();
        Console.WriteLine(vehicle.ToString());
    }
}