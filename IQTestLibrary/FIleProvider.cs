namespace IQTestLibrary
{
    public class FileProvider
    {
        public static void Append(string path, string value)
        {
            using var streamWriter = new StreamWriter(path, true, System.Text.Encoding.Unicode);
            streamWriter.WriteLine(value);
            streamWriter.Close();
        }

        public static void Replace (string path, string value)
        {

        }

        public static string Get(string path)
        {
            using var streamReader = new StreamReader(path, System.Text.Encoding.Unicode);
            var value = streamReader.ReadToEnd();
            streamReader.Close();
            return value;
        }

        public static bool Exists (string path)
        {
            return File.Exists(path);
        }
    }
}
