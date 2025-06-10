namespace Ex03.GarageLogic;
public class AnswersValidator
{
    public static void validateAnswers(Dictionary<int, string> i_Answers, Dictionary<int, Question> i_Questions)
    {
        foreach (int key in i_Answers.Keys)
        {
            if (i_Questions[key].m_Type == typeof(int) || i_Questions[key].m_Type == typeof(float))
            {
                if (i_Questions[key].m_Type == typeof(int) || i_Questions[key].m_Type == typeof(float))
                {
                    float value = float.Parse(i_Answers[key]);
                    if (value < (float)i_Questions[key].m_Min || value > (float)i_Questions[key].m_Max)
                    {
                        throw new ValueRangeException(i_Questions[key].m_Question_text, (float)i_Questions[key].m_Min, (float)i_Questions[key].m_Max);
                    }
                }
            }
            if (i_Questions[key].m_Type == typeof(bool))
            {
                bool value = bool.Parse(i_Answers[key]);
                if (value != true && value != false)
                {
                    throw new ArgumentException("invalid value for boolean");
                }
            }
        }
    }
}