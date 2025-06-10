using Ex03.GarageLogic;

public class Program
{
    private static Garage garage = new Garage();
    public static void Main(string[] args)
    {
        Console.Clear();
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
                    Console.WriteLine("Thank you and see you next time!");
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

    public static string getVehicleType()
    {
        while (true)
        {
            int i = 0;
            foreach (string VehicleType in VehicleCreator.SupportedTypes)
            {
                Console.WriteLine($"{i} - {VehicleType}");
                i++;
            }
            Console.WriteLine($"Enter the vehicle type number: 0-{i - 1}");
            if (int.TryParse(Console.ReadLine(), out int typeNumber) &&
                typeNumber >= 0 &&
                typeNumber < VehicleCreator.SupportedTypes.Count)
            {
                return VehicleCreator.SupportedTypes[typeNumber];
            }
            else
            {
                Console.WriteLine("Invalid vehicle type number, try again");
            }
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
            string vehicleType = getVehicleType();
            Console.WriteLine("Enter the owner name:");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Enter the owner phone:");
            string ownerPhone = Console.ReadLine();
            ContactDetails contactDetails = new ContactDetails(ownerName, ownerPhone);
            Console.WriteLine("Enter the model name:");
            string modelName = Console.ReadLine();
            try
            {
                Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);
                //a list of strings that will hold questions
                Dictionary<int, Question> questions = newVehicle.getQuestions();
                Dictionary<int, string> answers = new Dictionary<int, string>();
                foreach (KeyValuePair<int, Question> question in questions)
                {
                    Console.WriteLine(question.Value.m_Question_text);
                    string answer = Console.ReadLine();
                    answers.Add(question.Key, answer);
                }
                newVehicle.parseAnswers(answers);
                garage.addVehicle(newVehicle, contactDetails);
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
        Console.WriteLine("Optionally enter the status filter: 1. InRepair, 2. Repaired, 3. Paid");
        string status = Console.ReadLine();
        int i_status;
        if (status == "") { i_status = 4; }
        else { i_status = int.Parse(status); }
        List<Vehicle> vehicles;
        try { vehicles = garage.getListOfVehicles(i_status); }
        catch (ArgumentException ae)
        {
            Console.WriteLine("Invalid input, try again");
            return;
        }
        Console.WriteLine("List of vehicles:");
        int i = 0;
        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine(i + ". " + vehicle.ToString());
            Console.WriteLine("--------------------------------");
            i++;
        }
    }
    private static Vehicle getVehiclebyLicensePlate()
    {
        Console.WriteLine("Enter the license plate:");
        string licensePlate = Console.ReadLine();
        while (!garage.checkIfVehicleExists(licensePlate))
        {
            Console.WriteLine("Vehicle does not exist. Please enter a valid license plate (or X to exit):");
            licensePlate = Console.ReadLine();
            if (licensePlate.ToUpper() == "X")
            {
                return null;
            }
        }
        return garage.getVehicle(licensePlate);
    }
    private static void ChangeVehicleStatus()
    {
        try
        {
            Vehicle vehicle = getVehiclebyLicensePlate();
            if (vehicle == null)
            {
                Console.WriteLine("Operation cancelled");
                return;
            }
            Console.WriteLine("Enter the new status: (1-3)");
            Console.WriteLine("1. InRepair");
            Console.WriteLine("2. Repaired");
            Console.WriteLine("3. Paid");
            eVehicleStatus newStatus;
            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        newStatus = eVehicleStatus.InRepair;
                        break;
                    case "2":
                        newStatus = eVehicleStatus.Repaired;
                        break;
                    case "3":
                        newStatus = eVehicleStatus.Paid;
                        break;
                    default:
                        Console.WriteLine("Invalid status. Please enter 1, 2 or 3:");
                        continue;
                }
                break;
            }
            garage.changeVehicleStatus(vehicle.m_LicenseID, newStatus);
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
            if (vehicle == null)
            {
                Console.WriteLine("Operation cancelled");
                return;
            }
            garage.InflateTiresToMaxPressure(vehicle.m_LicenseID);
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
            if (vehicle == null)
            {
                Console.WriteLine("Operation cancelled");
                return;
            }
            eFuelType fuelType;
            Console.WriteLine("Enter the fuel type:");
            int i = 0;
            foreach (eFuelType fuel in Enum.GetValues(typeof(eFuelType)))
            {
                Console.WriteLine($"{i} - {fuel}");
                i++;
            }
            string fuelTypeInput = Console.ReadLine();
            switch (fuelTypeInput)
            {
                case "0":
                    fuelType = eFuelType.Octan95;
                    break;
                case "1":
                    fuelType = eFuelType.Octan96;
                    break;
                case "2":
                    fuelType = eFuelType.Octan98;
                    break;
                case "3":
                    fuelType = eFuelType.Soler;
                    break;
                default:
                    throw new ArgumentException("Invalid fuel type");
            }

            float amount;
            while (true)
            {
                Console.WriteLine("Enter the amount:");
                if (float.TryParse(Console.ReadLine(), out amount))
                {
                    break;
                }
                Console.WriteLine("Invalid amount. Please enter a valid number.");
            }

            garage.refuelVehicle(vehicle.m_LicenseID, fuelType, amount);
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
            if (vehicle == null)
            {
                Console.WriteLine("Operation cancelled");
                return;
            }
            Console.WriteLine("Enter the amount of time to charge in minutes:");
            float time = float.Parse(Console.ReadLine());
            garage.chargeVehicle(vehicle.m_LicenseID, time);
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
        if (vehicle == null)
        {
            Console.WriteLine("Operation cancelled");
            return;
        }
        Console.WriteLine(vehicle);
    }
}