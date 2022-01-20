namespace IQTestLibrary
{
    public class Game
    {
        private List<Question> questions;
        private Question currentQuestion;
        private int allQuestionsCount;
        private int questionNumber = 0;
        private User user;

        public Game(User user)
        {
            this.user = user;
            questions = QuestionStorage.GetQuestions();
            allQuestionsCount = questions.Count;
        }

        public Question PopRandomQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomIndex];
            questions.RemoveAt(randomIndex);
            questionNumber++;
            return currentQuestion;
        }

        public void AcceptAnswer(int userAnswer)
        {
            var rightAnswer = currentQuestion.Answer;

            if (userAnswer == rightAnswer)
            {
                user.AcceptRightAnswers();
            }
        }

        public string CalculateDiagnose()
        {
            Diagnoses.CalculateGiagnose(user, allQuestionsCount);
            return user.Name + ", Ваш диагноз: " + user.Diagnose;
        }

        public bool End()
        {
            return questions.Count == 0;
        }

        public string GetQuestionNumberInfo()
        {
            return "Вопрос №" + questionNumber;
        }
    }
}
