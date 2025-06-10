namespace Ex03.GarageLogic.Vehicles;

public class FuelCar : Car
{
    private FuelEngine m_FuelEngine { get; set; }
    private readonly float k_MaxFuelAmount = 48f;
    public FuelCar(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
    {
        base.m_Questions.Add(5, new Question("Enter fuel amount", typeof(float)));
        base.m_Questions.Add(6, new Question("Enter fuel type (Octan95, Octan96, Octan98, Soler)", typeof(string)));
        m_FuelEngine = new FuelEngine(48f, 0, eFuelType.Octan95);

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
        m_Color = (eCarColor)Enum.Parse(typeof(eCarColor), i_Answers[3]);
        m_Doors = int.Parse(i_Answers[4]);
        float fuel_amount = float.Parse(i_Answers[5]);
        eFuelType fuel_type = (eFuelType)Enum.Parse(typeof(eFuelType), i_Answers[6]);

        m_FuelEngine = new FuelEngine(k_MaxFuelAmount, fuel_amount, fuel_type);

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
        m_Color = (eCarColor)Enum.Parse(typeof(eCarColor), i_DB_Fields[8]);
        m_Doors = int.Parse(i_DB_Fields[9]);
        float fuel_percentage = float.Parse(i_DB_Fields[3]);
        float current_fuel_amount = fuel_percentage * k_MaxFuelAmount;
        m_FuelEngine = new FuelEngine(k_MaxFuelAmount, current_fuel_amount, eFuelType.Octan95);
        for (int i = 0; i < k_TireNumber; i++)
        {
            m_Tires.Add(new Tire(tire_model, tire_pressure, k_max_tire_pressure));
        }
    }

}