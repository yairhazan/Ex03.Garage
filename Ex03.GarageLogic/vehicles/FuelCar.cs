namespace Ex03.GarageLogic.Vehicles;

public class FuelCar : Car
{
    private readonly float k_MaxFuelAmount = 48f;
    private readonly eFuelType k_FuelType = eFuelType.Octan95;
    public FuelCar(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
    {
        base.m_Questions.Add(5, new Question("Enter fuel amount", typeof(float), 0, k_MaxFuelAmount));
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
            throw new ValueRangeException("tire pressure", 0f, k_max_tire_pressure);
        }
        m_Color = (eCarColor)Enum.Parse(typeof(eCarColor), i_Answers[3]);
        m_Doors = int.Parse(i_Answers[4]);
        float fuel_amount = float.Parse(i_Answers[5]);
        base.m_Engine.FillEnergy(fuel_amount);

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
            throw new ValueRangeException("tire pressure", 0f, k_max_tire_pressure);
        }
        m_Color = (eCarColor)Enum.Parse(typeof(eCarColor), i_DB_Fields[8]);
        m_Doors = int.Parse(i_DB_Fields[9]);
        float fuel_percentage = float.Parse(i_DB_Fields[3]);
        float current_fuel_amount = fuel_percentage * k_MaxFuelAmount;
        base.m_Engine = new FuelEngine(k_MaxFuelAmount, current_fuel_amount, k_FuelType);
        for (int i = 0; i < k_TireNumber; i++)
        {
            m_Tires.Add(new Tire(tire_model, tire_pressure, k_max_tire_pressure));
        }
    }
    public override string ToString()
    {
        return base.ToString() + $"\nType: Fuel Car\nFuel Type: {k_FuelType}";
    }
}