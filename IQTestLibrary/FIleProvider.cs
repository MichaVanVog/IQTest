namespace IQTestLibrary
{
    public class FileProvider
    {
        private static string? Path { get; }

        public static void Save(User user)
        {
            using var streamWriter = new StreamWriter(Path ?? "UserResults.txt", true, System.Text.Encoding.Unicode);
            streamWriter.Write($"{user.Name}&{user.CountRightAnswers}&{user.Diagnose}&");
        }

        public static string Load()
        {
            using var streamReader = new StreamReader(Path ?? "UserResults.txt", System.Text.Encoding.Unicode);
            return streamReader.ReadToEnd();
        }
    }
}
