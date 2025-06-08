namespace Ex03.GarageLogic;

public class Question
{
    public string m_Question_text { get; set; }
    public int m_Min { get; set; }
    public int m_Max { get; set; }
    public Type m_Type { get; set; }

    public Question(string i_Question_text, Type i_Type, int i_Min, int i_Max)
    {
        m_Question_text = i_Question_text;
        m_Min = i_Min;
        m_Max = i_Max;
        m_Type = i_Type;
    }
}