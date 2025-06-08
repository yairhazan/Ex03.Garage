namespace Ex03.GarageLogic
{
    public class Questions
    {
        public static Dictionary<string, Question> m_Questions { get; set; }

        static Questions()
        {
            m_Questions = new Dictionary<string, Question>();
            // generic vehice questions
            m_Questions.Add("1", new Question("Enter tire model", typeof(string), 0, 0));
            m_Questions.Add("2", new Question("Enter tire pressure", typeof(int), 0, 0));
            m_Questions.Add("3", new Question("Enter license type", typeof(string), 0, 0));
            m_Questions.Add("4", new Question("Enter engine volume", typeof(int), 0, 0));
            m_Questions.Add("5", new Question("Enter max battery time", typeof(int), 0, 0));
            m_Questions.Add("6", new Question("Enter current battery percentage", typeof(int), 0, 100));
            m_Questions.Add("7", new Question("Enter hours left in battery", typeof(int), 0, 100));
        }

        public List<string> get_questions(List<int> i_Questions)
        {
            List<string> questions = new List<string>();
            foreach (int i in i_Questions)
            {
                questions.Add(m_Questions[i.ToString()].m_Question_text);
            }
            return questions;
        }
    }
}