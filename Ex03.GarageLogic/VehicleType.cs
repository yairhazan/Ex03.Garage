namespace Ex03.GarageLogic
{
    public static class VehicleType
    {
        public static bool IsValidType(string vehicleType)
        {
            return VehicleCreator.SupportedTypes.Contains(vehicleType);
        }

        public static IEnumerable<string> GetAllTypes()
        {
            return VehicleCreator.SupportedTypes;
        }
    }
} 