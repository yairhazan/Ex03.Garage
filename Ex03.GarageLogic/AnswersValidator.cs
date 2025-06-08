namespace Ex03.GarageLogic;
public class AnswersValidator
{
    public static void validateAnswers(Dictionary<int, string> i_Answers, Dictionary<int, Question> i_Questions)
    {
        foreach (int key in i_Answers.Keys)
        {
            if (i_Questions[key].m_Type == typeof(int) || i_Questions[key].m_Type == typeof(float))
            {
                if (i_Questions[key].m_Type == typeof(int))
                {
                    int value = int.Parse(i_Answers[key]);
                    if (value < i_Questions[key].m_Min || value > i_Questions[key].m_Max)
                    {
                        throw new ValueRangeException(i_Questions[key].m_Min, i_Questions[key].m_Max);
                    }
                }
                else
                {
                    float value = float.Parse(i_Answers[key]);
                    if (value < i_Questions[key].m_Min || value > i_Questions[key].m_Max)
                    {
                        throw new ValueRangeException(i_Questions[key].m_Min, i_Questions[key].m_Max);
                    }
                }

            }
        }
    }
}