namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();
        private Dictionary<string, (eVehicleStatus, ContactDetails)> m_Vehicles_Status = new Dictionary<string, (eVehicleStatus, ContactDetails)>();

        public void LoadVehicles()
        {
            //example for line in db: FuelMotorcycle,75-321-22,Honda-CB650R,68,Michelin,28,Tom,052-1234560,A2,750
            //VehicleType, LicensePlate, ModelName, EnergyPercentage, TierModel, CurrAirPressure,  OwnerName, OwnerPhone, [SPECIFIC VEHICLE PROPERTIES]
            //store vehicles in dictionary by license number
            //read from vehicles.db
            string[] lines = System.IO.File.ReadAllLines("vehicles.db");
            Dictionary<int, string> answers = new Dictionary<int, string>();
            foreach (string line in lines)
            {
                //for vehiclde in vehicles.db, use constructor to create vehicle
                List<string> db_field = line.Split(',').ToList();
                string vehicleType = db_field[0];
                string licensePlate = db_field[1];
                string model = db_field[2];
                Vehicle vehicleToAdd = VehicleCreator.CreateVehicle(vehicleType, licensePlate, model);
                vehicleToAdd.loadFromDB(db_field);
                m_Vehicles.Add(licensePlate, vehicleToAdd);
                m_Vehicles_Status.Add(licensePlate, (eVehicleStatus.InRepair, new ContactDetails(db_field[6], db_field[7])));
            }
        }
        public bool checkIfVehicleExists(string licensePlate)
        {
            return m_Vehicles.ContainsKey(licensePlate);
        }

        public void changeVehicleStatus(string licensePlate, eVehicleStatus status)
        {
            m_Vehicles_Status[licensePlate] = (status, m_Vehicles_Status[licensePlate].Item2);
        }

    }
}