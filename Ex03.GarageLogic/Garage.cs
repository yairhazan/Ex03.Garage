namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();
        public void LoadVehicles()
        {
            //example for line in db: FuelMotorcycle,75-321-22,Honda-CB650R,68,Michelin,28,Tom,052-1234560,A2,750

            //store vehicles in dictionary by license number
            //read from vehicles.db
            List<string> lines = System.IO.File.ReadAllLines("vehicles.db");
            foreach (string line in lines)
            {
                //for vehiclde in vehicles.db, use constructor to create vehicle
                List<string> answers = line.Split(',').ToList();
                string vehicleType = answers[0];
                string licensePlate = answers[1];
                Vehicle vehicleToAdd = VehicleCreator.CreateVehicle(vehicleType, licensePlate);
                vehicleToAdd.parseAnswers(answers.Skip(2).ToArray());
                m_Vehicles.Add(licensePlate, vehicleToAdd);
            }
        }
    }
}