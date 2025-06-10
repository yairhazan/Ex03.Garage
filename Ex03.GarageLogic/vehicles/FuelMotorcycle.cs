namespace Ex03.GarageLogic.Vehicles;

public class FuelMotorcycle : Motorcycle
{
    //FuelMotorcycle,68,Michelin,28,Tom,052-1234560,A2,750



    private readonly eFuelType k_FuelType = eFuelType.Octan98;
    private readonly float k_MaxFuelAmount = 5.8f;
    public FuelMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
    {
        base.m_Questions.Add(5, new Question("Enter current fuel amount", typeof(float)));
        base.m_Engine = new FuelEngine(k_MaxFuelAmount, 0, k_FuelType);
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
            throw new ValueRangeException("tire pressure", 0, k_max_tire_pressure);
        }
        m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_Answers[3]);
        m_EngineVolume = int.Parse(i_Answers[4]);
        float current_fuel = float.Parse(i_Answers[5]);

        base.m_Engine = new FuelEngine(k_MaxFuelAmount, current_fuel, k_FuelType);

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
            throw new ValueRangeException("tire pressure", 0, k_max_tire_pressure);
        }
        m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_DB_Fields[8]);
        m_EngineVolume = int.Parse(i_DB_Fields[9]);
        float fuel_percentage = float.Parse(i_DB_Fields[3]);
        float current_fuel = fuel_percentage * k_MaxFuelAmount;
        base.m_Engine = new FuelEngine(k_MaxFuelAmount, current_fuel, k_FuelType);
        for (int i = 0; i < k_TireNumber; i++)
        {
            m_Tires.Add(new Tire(tire_model, tire_pressure, k_max_tire_pressure));
        }
    }
    public override string ToString()
    {
        return base.ToString() + $"\nType: Fuel Motorcycle";
    }
}
















