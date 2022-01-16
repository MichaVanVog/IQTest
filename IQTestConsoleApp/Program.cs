using System.Text;

namespace IQTestConsoleApp;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        var questions = GetQuestions();
        var countRightAnswers = 0;
        var countQuestions = questions.Count;
        bool isValid;

        var random = new Random();

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
                        countRightAnswers++;
                    }
                }
            }
            while (!isValid);
            questions.RemoveAt(randomIndex);
        }
        Console.WriteLine($"Количество правильных ответов: {countRightAnswers}");

        var diagnose = GetDiagnoses();
        var rightPercentOfAnswers = countRightAnswers * 100 / countQuestions;
        if (rightPercentOfAnswers <= 0)
        {
            Console.WriteLine($"Ваш диагноз: {diagnose[0]}");
            return;
        }
        if (rightPercentOfAnswers <= 20)
        {
            Console.WriteLine($"Ваш диагноз: {diagnose[1]}");
            return;
        }
        if (rightPercentOfAnswers <= 40)
        {
            Console.WriteLine($"Ваш диагноз: {diagnose[2]}");
            return;
        }
        if (rightPercentOfAnswers <= 60)
        {
            Console.WriteLine($"Ваш диагноз: {diagnose[3]}");
            return;
        }
        if (rightPercentOfAnswers <= 80)
        {
            Console.WriteLine($"Ваш диагноз: {diagnose[4]}");
            return;
        }
        if (rightPercentOfAnswers <= 100)
        {
            Console.WriteLine($"Ваш диагноз: {diagnose[5]}");
            return;
        }
    }

    static List<string> GetDiagnoses()
    {
        var diagnose = new List<string>();
        diagnose.Add("Идиот");
        diagnose.Add("Кретин");
        diagnose.Add("Дурак");
        diagnose.Add("Нормальный");
        diagnose.Add("Талант");
        diagnose.Add("Гений");
        return diagnose;
    }

    static List<Question> GetQuestions()
    {
        List<Question> questions = new();
        questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
        questions.Add(new Question("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?", 9));
        questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
        questions.Add(new Question("Укол делают каждые полчаса, сколько нужно минут для трех уколов?", 60));
        questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
        return questions;
    }
}