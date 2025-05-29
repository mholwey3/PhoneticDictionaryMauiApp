using SQLite;

namespace PhoneticDictionaryMauiApp.Source
{
    [Table("dictionaryItem")]
    public class DictionaryItem
    {
        [Column("word_id")]
        public string WordId { get; private set; }

        [Column("word_display")]
        public string WordDisplay { get; private set; }

        [Column("pronunciation")]
        public string Pronunciation { get; private set; }

        [Column("phonetic_spelling")]
        public string PhoneticSpelling { get; private set; }

        [Column("item_type")]
        public ItemType Type { get; private set; }

        public enum ItemType
        {
            Main,
            RelatedItem,
            Example
        }

        public DictionaryItem()
        {
            
        }
    }
}
