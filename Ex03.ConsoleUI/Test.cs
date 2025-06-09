// using Ex03.GarageLogic;
// using Ex03.GarageLogic.Vehicles;

// public class Test
// {
//     public static void Main()
//     {
//         // Create a new electric motorcycle
//         Vehicle motorcycle = VehicleCreator.CreateVehicle("ElectricMotorcycle", "ABC123", "Tesla Bike");

//         // Create answers dictionary
//         Dictionary<int, string> answers = new Dictionary<int, string>
//         {
//             { 1, "Michelin" },           // Tire manufacturer
//             { 2, "25" },                 // Tire pressure
//             { 3, "A2" },                 // License type
//             { 4, "750" },                // Engine volume
//             { 5, "3.2" },                // Max battery time
//             { 6, "2.5" }                 // Hours left in battery
//         };

//         try
//         {
//             // Parse the answers
//             motorcycle.parseAnswers(answers);
//             Console.WriteLine("Electric motorcycle created successfully!");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error creating motorcycle: {ex.Message}");
//         }
//     }
// } 