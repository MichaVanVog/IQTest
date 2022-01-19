namespace IQTestLibrary
{
    public class Question
    {
        public string QuestionText { get; }
        public int Answer { get; }

        public Question(string text, int answer)
        {
            QuestionText = text;
            Answer = answer;
        }

    }
}
