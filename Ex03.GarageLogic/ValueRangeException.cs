public class ValueRangeException : Exception
{
    int m_MinValue;
    int m_MaxValue;

    public ValueRangeException(int i_MinValue, int i_MaxValue)
    {
        m_MinValue = i_MinValue;
        m_MaxValue = i_MaxValue;
    }
}