public class ElectricEngine : Engine
{
    private readonly float m_MaxBatteryTime;
    private float m_CurrentBatteryTime;

    public ElectricEngine(float i_MaxBatteryTime, float i_CurrentBatteryTime) : base(i_MaxBatteryTime, i_CurrentBatteryTime)
    {
    }

    public override string ToString()
    {
        return $"Battery time: {base.ToString()} hours";
    }
}