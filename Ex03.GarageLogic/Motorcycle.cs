public class Motorcycle : Vehicle
{
    private readonly eLicenseType m_LicenseType;
    private readonly int m_EngineVolume;
    private List<Tire> m_Tires;

    /*
    * the constructor should get the license type and engine volume
    * and create the tires with the default values
    */
    public Motorcycle(string i_LicenseID, string i_ModelName, eLicenseType i_LicenseType, int i_EngineVolume) : base(i_LicenseID, i_ModelName)
    {
        m_LicenseType = i_LicenseType;
        m_EngineVolume = i_EngineVolume;
        //create 2 tires with max air pressure 30
        m_Tires = new List<Tire>(2,30);
    }
}