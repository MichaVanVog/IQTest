using Newtonsoft.Json;

namespace IQTestLibrary
{
    public class QuestionStorage
    {
        private static string Path = "Questions.Json";
        public static List<Question> GetQuestions()
        {
            List<Question> questions = new();
            if (!FileProvider.Exists(Path))
            {
                questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
                questions.Add(new Question("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?", 9));
                questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
                questions.Add(new Question("Укол делают каждые полчаса, сколько нужно минут для трех уколов?", 60));
                questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));

                Save(questions);
            }
            else
            {
                var lines = FileProvider.Get(Path);
                questions = JsonConvert.DeserializeObject<List<Question>>(lines);
            }
            return questions;
        }

        public static void Add(Question newQuestion)
        {
            var questions = GetQuestions();
            questions.Add(newQuestion);
            Save(questions);
        }

        private static void Save(List<Question> questions)
        {
            var serializedData = JsonConvert.SerializeObject(questions, Formatting.Indented);
            FileProvider.Replace(Path, serializedData);
        }
    }
}
