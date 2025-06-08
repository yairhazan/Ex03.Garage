public class Vehicle
{
    //LicensePlate, ModelName, EnergyPercentage, TierModel, CurrAirPressure,  OwnerName, OwnerPhone

    public string LicenseID { get; set; }
    public string ModelName { get; set; }
    public string OwnerName { get; set; }
    public string OwnerPhone { get; set; }
    public List<Tier> Tiers { get; set; }
    public float EnergyPercentage { get; set; }

    public Vehicle(string i_LicenseID, string i_ModelName, string i_OwnerName, string i_OwnerPhone, List<Tier> i_Tiers, float i_EnergyPercentage)
    {
        LicenseID = i_LicenseID;
        ModelName = i_ModelName;
        OwnerName = i_OwnerName;
        OwnerPhone = i_OwnerPhone;
        Tiers = i_Tiers;
        EnergyPercentage = i_EnergyPercentage;
    }
}

