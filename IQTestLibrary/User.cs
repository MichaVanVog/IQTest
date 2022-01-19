namespace IQTestLibrary
{
    public class User
    {
        public string Name { get; }
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
    }
}
