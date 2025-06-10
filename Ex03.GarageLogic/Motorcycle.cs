namespace Ex03.GarageLogic;

public abstract class Motorcycle : Vehicle
{
    protected int m_EngineVolume;
    protected readonly int k_TireNumber = 2;
    protected int k_max_tire_pressure = 30;

    protected eLicenseType m_LicenseType;

    public Motorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
    {
        base.m_Questions.Add(3, new Question("Enter license type: A, A1, A2, A or B", typeof(string)));
        base.m_Questions.Add(4, new Question("Enter engine volume", typeof(int), 0, int.MaxValue));
    }

    public override string ToString()
    {
        return $"{base.ToString()}\nLicense type: {m_LicenseType}\nEngine volume: {m_EngineVolume}cc";
    }
}