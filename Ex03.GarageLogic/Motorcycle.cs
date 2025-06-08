public class Motorcycle : Vehicle
{
    private readonly eLicenseType m_LicenseType;
    private readonly int m_EngineVolume;
    private List<Tire> m_Tires;

    /*
    * the constructor should get the license type and engine volume
    * and create the tires with the default values
    */
    public Motorcycle(string i_LicenseID, string i_ModelName): base(i_LicenseID, i_ModelName)
    {

    }
}