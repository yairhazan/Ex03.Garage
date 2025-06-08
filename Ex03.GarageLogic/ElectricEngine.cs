public class ElectricEngine
{
    private readonly float m_MaxBatteryTime;
    private float m_CurrentBatteryTime;

    public ElectricEngine(float i_MaxBatteryTime, float i_CurrentBatteryTime)
    {
        m_MaxBatteryTime = i_MaxBatteryTime;
        m_CurrentBatteryTime = i_CurrentBatteryTime;
    }

    public void Charge(float i_HoursToCharge)
    {
        m_CurrentBatteryTime += i_HoursToCharge;
        if (m_CurrentBatteryTime > m_MaxBatteryTime)
        {
            m_CurrentBatteryTime = m_MaxBatteryTime;
        }
    }
}