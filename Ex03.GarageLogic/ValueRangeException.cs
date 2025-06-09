namespace Ex03.GarageLogic;
public class ValueRangeException : Exception
{
    int m_MinValue;
    int m_MaxValue;
    float m_MinFloatValue;
    float m_MaxFloatValue;
    public ValueRangeException(int i_MinValue, int i_MaxValue)
        : base($"Value must be between {i_MinValue} and {i_MaxValue}.")
    {
        m_MinValue = i_MinValue;
        m_MaxValue = i_MaxValue;
    }
    public ValueRangeException(float i_MinValue, float i_MaxValue)
        : base($"Value must be between {i_MinValue} and {i_MaxValue}.")
    {
        m_MinFloatValue = i_MinValue;
        m_MaxFloatValue = i_MaxValue;
    }
}