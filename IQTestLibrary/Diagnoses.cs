namespace IQTestLibrary
{
    public class Diagnoses
    {
        internal static List<string> GetDiagnoses()
        {
            List<string> diagnose = new()
            {
                "Идиот",
                "Кретин",
                "Дурак",
                "Нормальный",
                "Талант",
                "Гений"
            };
            return diagnose;
        }

        public static void CalculateGiagnose(User user, int countQuestions)
        {
            var diagnose = GetDiagnoses();
            var rightPercentOfAnswers = (double)user.CountRightAnswers * 100 / countQuestions;
            if (rightPercentOfAnswers <= 0)
            {
                user.Diagnose = diagnose[0];
                return;
            }
            if (rightPercentOfAnswers <= 20)
            {
                user.Diagnose = diagnose[1];
                return;
            }
            if (rightPercentOfAnswers <= 40)
            {
                user.Diagnose = diagnose[2];
                return;
            }
            if (rightPercentOfAnswers <= 60)
            {
                user.Diagnose = diagnose[3];
                return;
            }
            if (rightPercentOfAnswers <= 80)
            {
                user.Diagnose = diagnose[4];
                return;
            }
            if (rightPercentOfAnswers <= 100)
            {
                user.Diagnose = diagnose[5];
                return;
            }
        }
    }
}
