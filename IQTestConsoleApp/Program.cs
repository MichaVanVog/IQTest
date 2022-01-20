using System.Text;
using IQTestLibrary;

namespace IQTestConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Как тебя зовут?");
        var user = new User(Console.ReadLine());
        var game = new Game(user);
        while (!game.End())
        {
            var currentQuestion = game.PopRandomQuestion();
            Console.WriteLine(game.GetQuestionNumberInfo());

            Console.WriteLine(currentQuestion.QuestionText);
            var userAnswer = GetUserAnswer();
            game.AcceptAnswer(userAnswer);
        }

        Console.WriteLine("Количество правильных ответов: " + user.CountRightAnswers);
        Console.WriteLine(game.CalculateDiagnose());

        UserResultsStorage.Append(user);

        Console.WriteLine("Хотите посмотреть предыдущие результаты игр? Нажми Y/N?");
        var input = Console.ReadKey();
        Console.WriteLine();
        if (input.Key == ConsoleKey.Y)
        {
            var users = UserResultsStorage.GetAll();
            ViewUserResult(users);
        }

        Console.WriteLine("Хотите добавить новый вопрос? Нажми Y/N?");
        input = Console.ReadKey();
        Console.WriteLine();
        if (input.Key == ConsoleKey.Y)
        {
            var newQuestion = GetNewQuestion();
            QuestionStorage.Add(newQuestion);
        }

    }

    private static Question GetNewQuestion()
    {
        Console.WriteLine("Введите текст вопроса");
        var text = Console.ReadLine();

        Console.WriteLine("Введите ответ для вопроса");
        var answer = GetUserAnswer();
        var newQuestion = new Question(text, answer);
        return newQuestion;
    }

    private static void ViewUserResult(List<User> users)
    {
        Console.WriteLine("{0,-20}{1,-40}{2,-10}", "Имя", "Кол-во правильных ответов", "Диагноз");

        foreach (var user in users)
        {
            Console.WriteLine("{0,-20}{1,-40}{2,-10}", user.Name, user.CountRightAnswers, user.Diagnose);
        }
    }

    private static int GetUserAnswer()
    {
        var isValid = User.IsValid(Console.ReadLine(), out var userAnswer, out var errorMessage);
        while (!isValid)
        {
            Console.WriteLine(errorMessage);
            isValid = User.IsValid(Console.ReadLine(), out userAnswer, out errorMessage);
        }
        return userAnswer;
    }
}