using System.Runtime.CompilerServices;

namespace Ex03.GarageLogic.Vehicles;

public class Truck : Vehicle
{
    private bool m_IsCarryingDangerousMaterials;
    private float m_MaxCarryingWeight;
    private readonly int k_TireNumber = 12;
    private readonly int k_MaxTirePressure = 26;
    private readonly float k_MaxFuelAmount = 135f;
    private readonly eFuelType k_FuelType = eFuelType.Soler;

    public Truck(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
    {

        base.m_Questions.Add(5, new Question("Enter the current fuel amount", typeof(float), 0, k_MaxFuelAmount));
        base.m_Questions.Add(8, new Question("Is the truck carrying dangerous materials? 0 for no, 1 for yes", typeof(int), 0, 1));
        base.m_Questions.Add(9, new Question("Enter the max carrying weight", typeof(float), 0, int.MaxValue));

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
        if (tire_pressure > k_MaxTirePressure)
        {
            throw new ValueRangeException("tire pressure", 0f, k_MaxTirePressure);
        }
        float current_fuel = float.Parse(i_Answers[5]);
        Console.WriteLine("Current fuel: " + current_fuel);
        m_IsCarryingDangerousMaterials = (int.Parse(i_Answers[8]) == 1);
        m_MaxCarryingWeight = float.Parse(i_Answers[9]);
        base.m_Engine.FillEnergy(current_fuel);
        Console.WriteLine("Truck engine: " + base.m_Engine.ToString());
        for (int i = 0; i < k_TireNumber; i++)
        {
            m_Tires.Add(new Tire(tire_model, tire_pressure, k_MaxTirePressure));
        }
    }

    public override void loadFromDB(List<string> i_DB_Fields)
    {
        //Truck,39-582-16,Scania-R450,44,Continental,25,Gil,052-1234569,false,22.4
        string tire_model = i_DB_Fields[4];
        float fuel_percentage = float.Parse(i_DB_Fields[3]);
        float current_fuel = fuel_percentage * k_MaxFuelAmount;
        float tire_pressure = float.Parse(i_DB_Fields[5]);
        if (tire_pressure > k_MaxTirePressure)
        {
            throw new ValueRangeException("tire pressure", 0f, k_MaxTirePressure);
        }
        m_IsCarryingDangerousMaterials = bool.Parse(i_DB_Fields[8]);
        m_MaxCarryingWeight = float.Parse(i_DB_Fields[9]);
        base.m_Engine = new FuelEngine(k_MaxFuelAmount, current_fuel, k_FuelType);
        for (int i = 0; i < k_TireNumber; i++)
        {
            m_Tires.Add(new Tire(tire_model, tire_pressure, k_MaxTirePressure));
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()}\nCarrying dangerous materials: {m_IsCarryingDangerousMaterials}\nMax carrying weight: {m_MaxCarryingWeight:F1} tons\nType: Truck\nFuel Type: {k_FuelType}";
    }
}