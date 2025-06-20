namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();
        private Dictionary<string, (eVehicleStatus, ContactDetails)> m_Vehicles_Status = new Dictionary<string, (eVehicleStatus, ContactDetails)>();

        public void addVehicle(Vehicle vehicle, ContactDetails contactDetails)
        {
            m_Vehicles.Add(vehicle.m_LicenseID, vehicle);
            m_Vehicles_Status.Add(vehicle.m_LicenseID, (eVehicleStatus.InRepair, contactDetails));
        }
        public void LoadVehicles()
        {
            //example for line in db: FuelMotorcycle,75-321-22,Honda-CB650R,68,Michelin,28,Tom,052-1234560,A2,750
            //VehicleType, LicensePlate, ModelName, EnergyPercentage, TierModel, CurrAirPressure,  OwnerName, OwnerPhone, [SPECIFIC VEHICLE PROPERTIES]
            //store vehicles in dictionary by license number
            //read from vehicles.db
            string[] lines = System.IO.File.ReadAllLines("vehicles.db");
            Dictionary<int, string> answers = new Dictionary<int, string>();
            int i = 0;
            foreach (string line in lines)
            {
                if (line.StartsWith("*"))
                {
                    break;
                }
                //for vehiclde in vehicles.db, use constructor to create vehicle
                List<string> db_field = line.Split(',').ToList();
                string vehicleType = db_field[0];
                string licensePlate = db_field[1];
                string model = db_field[2];
                Vehicle vehicleToAdd = VehicleCreator.CreateVehicle(vehicleType, licensePlate, model);
                vehicleToAdd.loadFromDB(db_field);
                m_Vehicles.Add(licensePlate, vehicleToAdd);
                m_Vehicles_Status.Add(licensePlate, (eVehicleStatus.InRepair, new ContactDetails(db_field[6], db_field[7])));
                i++;
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
        public List<Vehicle> getListOfVehicles(int i_status)
        {
            eVehicleStatus status;
            switch (i_status)
            {
                case 1:
                    status = eVehicleStatus.InRepair;
                    break;
                case 2:
                    status = eVehicleStatus.Repaired;
                    break;
                case 3:
                    status = eVehicleStatus.Paid;
                    break;
                case 4:
                    return m_Vehicles.Values.ToList();
                default:
                    throw new ArgumentException("Invalid status");
            }
            List<Vehicle> vehicles = new List<Vehicle>();
            foreach (string LicensePlate in m_Vehicles_Status.Keys)
            {
                if (m_Vehicles_Status[LicensePlate].Item1 == status)
                {
                    vehicles.Add(m_Vehicles[LicensePlate]);
                }
            }
            return vehicles;
        }
        public Vehicle getVehicle(string licensePlate)
        {
            return m_Vehicles[licensePlate];
        }
        public void InflateTiresToMaxPressure(string licensePlate)
        {
            foreach (Tire tire in m_Vehicles[licensePlate].m_Tires)
            {
                tire.Inflate(tire.getMaxAirPressure() - tire.getCurrentAirPressure());
            }
        }
        public void refuelVehicle(string licensePlate, eFuelType fuelType, float amount)
        {
            if (!(m_Vehicles[licensePlate].getEngine() is FuelEngine))
            {
                throw new ArgumentException("Vehicle is not fuel");
            }
            if (fuelType != ((FuelEngine)m_Vehicles[licensePlate].getEngine()).m_FuelType)
            {
                throw new ArgumentException("Wrong fuel type");
            }
            m_Vehicles[licensePlate].getEngine().FillEnergy(amount);
        }
        public void chargeVehicle(string licensePlate, float time)
        {
            if (m_Vehicles[licensePlate].getEngine() is not ElectricEngine)
            {
                throw new ArgumentException("Vehicle is not electric");
            }
            m_Vehicles[licensePlate].getEngine().FillEnergy(time);
        }

        public (eVehicleStatus, ContactDetails) getVehicleDetails(string licensePlate)
        {
            return m_Vehicles_Status[licensePlate];
        }
    }
}