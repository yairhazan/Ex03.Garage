namespace Ex03.GarageLogic;
public class ValueRangeException : Exception
{
    float m_MinValue;
    float m_MaxValue;
    float m_MinFloatValue;
    float m_MaxFloatValue;
    public ValueRangeException(string key, float i_MinValue, float i_MaxValue)
        : base($"invalid value for {key}, must be between {i_MinValue} and {i_MaxValue}.")
    {
        m_MinValue = i_MinValue;
        m_MaxValue = i_MaxValue;
    }
}