namespace Ex03.GarageLogic;

public abstract class Car : Vehicle
{
    protected eCarColor m_Color;
    protected int m_Doors;
    protected readonly int k_TireNumber = 4;
    protected int k_max_tire_pressure = 32;

    public Car(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
    {
        base.m_Questions.Add(3, new Question("Enter car color: Yellow, Black, White or Silver", typeof(eCarColor)));
        base.m_Questions.Add(4, new Question("Enter car doors: 2,3,4 or 5", typeof(int), 2, 5));
    }

    public override string ToString()
    {
        return $"{base.ToString()}\nColor: {m_Color}\nNumber of doors: {m_Doors}";
    }
}