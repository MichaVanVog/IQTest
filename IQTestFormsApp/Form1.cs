using IQTestLibrary;

namespace IQTestFormsApp
{
    public partial class MainForm : Form
    {
        private Game game;
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
            user = new User("Неизвестно");
            var userInfoForm = new UserInfoForm(user);
            var result = userInfoForm.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                Close();
            }

            else
            {
                game = new Game(user);
                ShowNextQuestion();
            }
        }

        private void ShowNextQuestion()
        {
            currentQuestion = game.PopRandomQuestion();
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

            if (game.End())
            {
                Diagnoses.CalculateGiagnose(user, countQuestions);
                MessageBox.Show(user.Diagnose, "Диагноз", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ShowNextQuestion();
        }
    }
}