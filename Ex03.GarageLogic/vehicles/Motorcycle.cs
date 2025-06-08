public class Motorcycle : Vehicle
{
    private readonly int m_EngineVolume;
    private readonly List<Tire> m_Tires;

    public Motorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
    {
        m_questions.Add("Enter license type");
        m_questions.Add("Enter engine volume");
    }
}