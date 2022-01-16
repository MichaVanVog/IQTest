using System.Text;

namespace IQTestConsoleApp;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        var questions = GetQuestions();
        var countRightAnswer = 0;
        bool isValid;

        var random = new Random();

        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine($"Вопрос № {i + 1}");

            var randomIndex = random.Next(questions.Count);
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
                    if (userAnswer == questions[i].Answer)
                    {
                        countRightAnswer++;
                    }
                }
            }
            while (!isValid);
            questions.RemoveAt(randomIndex);
        }
        Console.WriteLine($"Количество правильных ответов: {countRightAnswer}");

    }
    static List<Question> GetQuestions()
    {
        List<Question> questions = new();
        questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
        questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 9));
        questions.Add(new Question("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?", 9));
        questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
        questions.Add(new Question("Укол делают каждые полчаса, сколько нужно минут для трех уколов?", 60));
        questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
        return questions;
    }
}