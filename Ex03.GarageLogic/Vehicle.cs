public abstract class Vehicle
{

    public string m_LicenseID { get; set; }
    public string m_ModelName { get; set; }
    public List<Tire> m_Tires { get; set; }
    public float m_EnergyPercentage { get; set; }

    private readonly List<string> m_Questions;
    public Vehicle(string i_LicenseID, string i_ModelName)
    {
        m_LicenseID = i_LicenseID;
        m_ModelName = i_ModelName;
        m_Questions.Add("Enter tire model");
        m_Questions.Add("Enter tire pressure");
    }

    public abstract void parseAnswers(List<string> i_Answers);
    public abstract List<string> getQuestions();
}

