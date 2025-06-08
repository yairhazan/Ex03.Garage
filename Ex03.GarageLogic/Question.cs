namespace Ex03.GarageLogic;

public class Question
{
    public string m_Question_text { get; set; }
    public float m_Min { get; set; }
    public float m_Max { get; set; }
    public Type m_Type { get; set; }

    public Question(string i_Question_text, Type i_Type, float i_Min = 0, float i_Max = 0)
    {
        m_Question_text = i_Question_text;
        m_Min = i_Min;
        m_Max = i_Max;
        m_Type = i_Type;
    }
}