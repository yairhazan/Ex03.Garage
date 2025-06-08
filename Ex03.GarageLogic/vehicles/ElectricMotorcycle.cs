public class ElectricMotorcycle : Vehicle
{
    private readonly eLicenseType m_LicenseType;
    private engine ElectricEngine;
    public ElectricMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
    {
        m_LicenseType = i_LicenseType;
        m_EngineVolume = i_EngineVolume;
        m_questions.Add("Enter hours left in battery");
        m_questions.Add("Enter max battery time");

    }
}