using System.Text;
using IQTestLibrary;

namespace IQTestConsoleApp;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        var questions = QuestionStorage.GetQuestions();
        var countQuestions = questions.Count;
        bool isValid;
        var random = new Random();

        Console.WriteLine("Введите Ваше имя:");

        var user = new User(Console.ReadLine() ?? "Неизвестно");

        for (int i = 0; i < countQuestions; i++)
        {
            Console.WriteLine($"Вопрос № {i + 1}");

            var randomIndex = random.Next(0, questions.Count);
            Console.WriteLine(questions[randomIndex].QuestionText);

            do
            {
                isValid = int.TryParse(Console.ReadLine(), out var userAnswer);
                if (!isValid || userAnswer < 0)
                {
                    Console.WriteLine("Неправильный ввод. \nВведите цифры!");
                    isValid = false;
                }
                else
                {
                    if (userAnswer == questions[randomIndex].Answer)
                    {
                        user.AcceptRightAnswers();
                    }
                }
            }
            while (!isValid);
            questions.RemoveAt(randomIndex);
        }
        Console.WriteLine($"Количество правильных ответов: {user.CountRightAnswers}");
        Diagnoses.CalculateGiagnose(user, countQuestions);
        Console.WriteLine($"Ваш диагноз: {user.Diagnose}");

        UserResultsStorage.Append(user);

        Console.WriteLine("Нажмите пробел для просмотра предудыщих результатов тестов\n");
        if (Console.ReadKey().Key == ConsoleKey.Spacebar)
        {
            var resultsFromFile = UserResultsStorage.GetAll();
            for (int i = 0; i < resultsFromFile.Count-3; i += 3)
            {
                Console.WriteLine($"Имя: {resultsFromFile[i]}\nКоличество правильных ответов: {resultsFromFile[i+1]}\nДиагноз: {resultsFromFile[i + 2]}\n");
            }
        }
    }
}