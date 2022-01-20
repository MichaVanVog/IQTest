using Newtonsoft.Json;

namespace IQTestLibrary
{
    public class UserResultsStorage
    {
        private static string Path = "UserResults.json";

        public static void Append(User user)
        {
            var userResults = GetAll();
            userResults.Add(user);
            Save(userResults);
        }

        public static List<User> GetAll()
        {
            if (!FileProvider.Exists(Path))
            {
                return new List<User>();
            }
            return JsonConvert.DeserializeObject<List<User>>(FileProvider.Get(Path));
        }

        static void Save(List<User> userResults)
        {
            var jsonData = JsonConvert.SerializeObject(userResults, Formatting.Indented);
            FileProvider.Replace(Path, jsonData);
        }
    }
}
