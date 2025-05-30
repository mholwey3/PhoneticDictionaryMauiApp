using SQLite;

namespace PhoneticDictionaryMauiApp.Source
{
    public class PhoneticDictionaryDatabase
    {
        public static string DbPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Database.db");
            }
        }

        private SQLiteConnection _connection;

        public PhoneticDictionaryDatabase()
        {
            _connection = new SQLiteConnection(DbPath);
        }

        public List<DictionaryItem> GetItems(string wordToFind)
        {
            return _connection.Table<DictionaryItem>().Where(i => i.WordId == wordToFind).ToList();
        }
    }
}
