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

        private readonly SQLiteConnection _connection;

        public PhoneticDictionaryDatabase()
        {
            _connection = new SQLiteConnection(DbPath);
        }

        public List<DictionaryItem> GetItems(string wordToFind)
        {
            List<DictionaryItem> items = _connection.Table<DictionaryItem>().ToList();
            return items.Where(i => i.WordId == wordToFind).ToList();
        }
    }
}
