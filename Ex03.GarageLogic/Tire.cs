public class Tire
{
    private readonly string m_TireModel;
    private float m_CurrentAirPressure;
    private readonly float m_MaxAirPressure;

    public Tire(string i_TireModel, float i_CurrentAirPressure, float i_MaxAirPressure)
    {
        m_TireModel = i_TireModel;
        m_CurrentAirPressure = i_CurrentAirPressure;
        m_MaxAirPressure = i_MaxAirPressure;
    }

    public void Inflate(float i_AirToAdd)
    {
        m_CurrentAirPressure += i_AirToAdd;
        if (m_CurrentAirPressure > m_MaxAirPressure)
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }
    }
}