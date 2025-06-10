namespace Ex03.GarageLogic;

public abstract class Vehicle
{
    protected Engine m_Engine;
    public string m_LicenseID;
    public string m_ModelName;
    public List<Tire> m_Tires = new List<Tire>();
    public float m_EnergyPercentage;
    protected Dictionary<int, Question> m_Questions = new Dictionary<int, Question>();
    public Vehicle(string i_LicenseID, string i_ModelName)
    {
        m_LicenseID = i_LicenseID;
        m_ModelName = i_ModelName;
        m_Questions.Add(1, new Question("Enter tire model", typeof(string)));
        m_Questions.Add(2, new Question("Enter tire pressure", typeof(int), 0, int.MaxValue));
    }

    public abstract void parseAnswers(Dictionary<int, string> i_Answers);
    public abstract Dictionary<int, Question> getQuestions();
    public abstract void loadFromDB(List<string> i_DB_Fields);
    public Engine getEngine()
    {
        return m_Engine;
    }
    public override string ToString()
    {
        return $"License plate: {m_LicenseID}\nModel name: {m_ModelName}\nEnergy percentage: {m_EnergyPercentage}\nTire: {m_Tires[0]}";
    }
}

