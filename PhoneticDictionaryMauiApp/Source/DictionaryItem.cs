using SQLite;

namespace PhoneticDictionaryMauiApp.Source
{
    [Table("dictionaryItem")]
    public class DictionaryItem
    {
        [Column("word_id")]
        public string WordId { get; set; }

        [Column("word_display")]
        public string WordDisplay { get; set; }

        [Column("pronunciation")]
        public string Pronunciation { get; set; }

        [Column("phonetic_spelling")]
        public string PhoneticSpelling { get; set; }

        [Column("type")]
        public ItemType Type { get; set; }

        public enum ItemType
        {
            Main,
            Example
        }
    }
}
