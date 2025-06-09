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
    public float getCurrentAirPressure()
    {
        return m_CurrentAirPressure;
    }
    public float getMaxAirPressure()
    {
        return m_MaxAirPressure;
    }
    public string getTireModel()
    {
        return m_TireModel;
    }
    public override string ToString()
    {
        return $"Model: {m_TireModel}, Current pressure: {m_CurrentAirPressure}, Max pressure: {m_MaxAirPressure}";
    }
}
