namespace IQTestLibrary
{
    public class User
    {
        public string Name { get; set; }
        public int CountRightAnswers { get; set; }
        public string Diagnose { get; set; }

        public User(string name)
        {
            Name = name;
            CountRightAnswers = 0;
            Diagnose = "Неизвестно";
        }
        public void AcceptRightAnswers()
        {
            CountRightAnswers++;
        }
        public static bool IsValid(string answer, out int userAnswer, out string message)
        {
            userAnswer = 0;
            message = "";
            try
            {
                userAnswer = Convert.ToInt32(answer);
                return true;
            }
            catch (FormatException)
            {
                message = "Введите число!";
                return false;
            }
            catch (OverflowException)
            {
                message = "Введите число меньшее чем 10^9!";
                return false;
            }
        }
    }
}
