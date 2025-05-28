namespace PhoneticDictionaryApp.Source
{
    class PhoneticDictionaryFile : IPhoneticDictionary
    {
        private const string FILE_NAME = "PHONETIC_DICTIONARY_BASE_A.txt";

        public Dictionary<string, DictionaryItem> PhoneticDictionary { get; set; }

        public PhoneticDictionaryFile()
        {
            PhoneticDictionary = new Dictionary<string, DictionaryItem>();

            LoadDictionary();
        }

        protected async void LoadDictionary()
        {
            PhoneticDictionary = await ReadDictionaryData();
        }

        private async Task<Dictionary<string, DictionaryItem>> ReadDictionaryData()
        {
            using Stream stream = await FileSystem.Current.OpenAppPackageFileAsync(FILE_NAME);
            using StreamReader reader = new StreamReader(stream);
            DictionaryItem? item = null;
            string? sLine;
            string[] sLineComponents;
            int iParenLocation_Curr;
            string sMainWord_Curr;
            Dictionary<string, DictionaryItem> dictionary = new Dictionary<string, DictionaryItem>();

            while ((sLine = reader.ReadLine()) != null)
            {
                sLineComponents = sLine.Split(',');

                for (int i = 0; i < sLineComponents.Length; i++)
                {
                    sLineComponents[i] = sLineComponents[i].Trim().ToLower();
                }

                iParenLocation_Curr = sLineComponents[0].IndexOf('(');
                sMainWord_Curr = iParenLocation_Curr > 0 ? sLineComponents[0].Substring(0, iParenLocation_Curr).Trim() : sLineComponents[0];

                if (sLine.Contains("/")) // Use Case Item
                {
                    if (item != null)
                    {
                        sLineComponents[0] = sLineComponents[0].Replace("/", item.Word);
                        sLineComponents[1] = sLineComponents[1].Replace("/", item.Pronunciation);
                        sLineComponents[2] = sLineComponents[2].Replace("/", item.PhoneticSpelling);
                        item.UseCases.Add(new DictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2], false));
                    }
                }
                else if (!dictionary.ContainsKey(sMainWord_Curr)) // New Dictionary Item
                {
                    item = new DictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2], true);
                    dictionary.Add(sMainWord_Curr, item);
                }
                else // Related Item
                {
                    if (item != null)
                    {
                        item.RelatedItems.Add(new DictionaryItem(sLineComponents[0], sLineComponents[1], sLineComponents[2], false));
                    }
                }
            }

            return dictionary;
        }

        public DictionaryItem? GetDictionaryItem(string word)
        {
            string wordLowerCase = word.ToLower();

            if (PhoneticDictionary.TryGetValue(wordLowerCase, out DictionaryItem? dictionaryItem))
            {
                return dictionaryItem;
            }

            return null;
        }
    }
}

//DictionaryItem newItem = new DictionaryItem("foo", "foo", "foo", true);
//newItem.UseCases.Add(new DictionaryItem("I pity the foo", "I pity the foo", "I pity the foo", false));
//newItem.UseCases.Add(new DictionaryItem("I pity the foo", "I pity the foo", "I pity the foo", false));
//newItem.UseCases.Add(new DictionaryItem("I pity the foo", "I pity the foo", "I pity the foo", false));
//newItem.UseCases.Add(new DictionaryItem("I pity the foo", "I pity the foo", "I pity the foo", false));
//newItem.RelatedItems.Add(new DictionaryItem("foobar", "foobar", "foobar", false));
//newItem.RelatedItems.Add(new DictionaryItem("foobar", "foobar", "foobar", false));
//newItem.RelatedItems.Add(new DictionaryItem("foobar", "foobar", "foobar", false));
//newItem.RelatedItems.Add(new DictionaryItem("foobar", "foobar", "foobar", false));
//PhoneticDictionary.Add(newItem.Word, newItem);
