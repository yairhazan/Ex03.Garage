using System.Formats.Asn1;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;

public class ElectricMotorcycle : Motorcycle
{
    private ElectricEngine m_engine;

    public ElectricMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
    {
        base.m_Questions.Add(5, new Question("Enter hours left in battery", typeof(float)));
        m_engine = new ElectricEngine(3.2f, 0);

    }

    public override Dictionary<int, Question> getQuestions()
    {
        return base.m_Questions;
    }

    public override void parseAnswers(Dictionary<int, string> i_Answers)
    {
        AnswersValidator.validateAnswers(i_Answers, base.m_Questions);

        string tire_model = i_Answers[1];
        float tire_pressure = float.Parse(i_Answers[2]);
        if (tire_pressure > k_max_tire_pressure)
        {
            throw new ValueRangeException(0, k_max_tire_pressure);
        }
        m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_Answers[3]);
        m_EngineVolume = int.Parse(i_Answers[4]);
        float hours_left_in_battery = float.Parse(i_Answers[5]);

        m_engine = new ElectricEngine(3.2f, hours_left_in_battery);

        for (int i = 0; i < k_TireNumber; i++)
        {
            m_Tires.Add(new Tire(tire_model, tire_pressure, k_max_tire_pressure));
        }


    }

    public override void loadFromDB(List<string> i_DB_Fields)
    {
        string tire_model = i_DB_Fields[4];
        float tire_pressure = float.Parse(i_DB_Fields[5]);
        if (tire_pressure > k_max_tire_pressure)
        {
            throw new ValueRangeException(0, k_max_tire_pressure);
        }
        m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_DB_Fields[8]);
        m_EngineVolume = int.Parse(i_DB_Fields[9]);
        float energy_percentage = float.Parse(i_DB_Fields[3]);
        float current_battery_time = energy_percentage * 3.2f;
        m_engine = new ElectricEngine(3.2f, current_battery_time);
        for (int i = 0; i < k_TireNumber; i++)
        {
            m_Tires.Add(new Tire(tire_model, tire_pressure, k_max_tire_pressure));
        }
    }

}