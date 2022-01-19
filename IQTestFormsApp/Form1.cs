using IQTestLibrary;

namespace IQTestFormsApp
{
    public partial class MainForm : Form
    {
        private List<Question> questions;
        private Question currentQuestion;
        private int countQuestions;
        private User user;
        private int questionNumber = 1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            questions = QuestionStorage.GetQuestions();
            countQuestions = questions.Count;
            user = new User("Неизвестно");

            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(questions.Count);

            currentQuestion = questions[randomIndex];
            QuestionLabel.Text = currentQuestion.QuestionText;

            CountQuestionLabel.Text = $"Вопрос № {questionNumber}";
            questionNumber++;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            var userAnswer = Int32.Parse(UserAnswerTextBox.Text);
            if (userAnswer == currentQuestion.Answer)
            {
                user.AcceptRightAnswers();
            }
            questions.Remove(currentQuestion);

            if (questions.Count == 0)
            {
                Diagnoses.CalculateGiagnose(user, countQuestions);
                MessageBox.Show(user.Diagnose, "Диагноз", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ShowNextQuestion();
        }
    }
}