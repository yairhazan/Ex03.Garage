public abstract class Vehicle
{

    public readonly string m_LicenseID;
    public readonly string m_ModelName;
    public readonly List<Tire> m_Tires;
    public float m_EnergyPercentage { get;}

    public Vehicle(string i_LicenseID, string i_ModelName)
    {
        m_LicenseID = i_LicenseID;
        m_ModelName = i_ModelName;
    }
}

