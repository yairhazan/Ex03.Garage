public class Vehicle
{

    public readonly string m_LicenseID;
    public readonly string m_ModelName;
    public readonly List<Tire> m_Tires;
    public float m_EnergyPercentage { get;}

    public Vehicle(string i_LicenseID, string i_ModelName, List<Tire> i_Tires, float i_EnergyPercentage)
    {
        m_LicenseID = i_LicenseID;
        m_ModelName = i_ModelName;
        m_Tires = i_Tires;
        m_EnergyPercentage = i_EnergyPercentage;
    }
}

