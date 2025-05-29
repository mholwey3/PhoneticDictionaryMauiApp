namespace PhoneticDictionaryMauiApp.Source
{
    class PhoneticDictionaryFile
    {
        private const string FILE_NAME = "TEST_DOC.txt";

        public Dictionary<string, DictionaryItem> PhoneticDictionary { get; set; }

        public PhoneticDictionaryFile()
        {
            PhoneticDictionary = new Dictionary<string, DictionaryItem>();

            //LoadDictionary();
        }

        //protected async void LoadDictionary()
        //{
        //    PhoneticDictionary = await ReadDictionaryData();
        //}

        //private async Task<Dictionary<string, DictionaryItem>> ReadDictionaryData()
        //{
        //    using Stream stream = await FileSystem.Current.OpenAppPackageFileAsync(FILE_NAME);
        //    using StreamReader reader = new StreamReader(stream);
        //    DictionaryItem? item = null;
        //    string? line;
        //    string[] lineComponents;
        //    int curParenthesesIndex;
        //    string curWord;
        //    Dictionary<string, DictionaryItem> dictionary = new Dictionary<string, DictionaryItem>();

        //    while ((line = reader.ReadLine()) != null)
        //    {
        //        lineComponents = line.Split(',');

        //        for (int i = 0; i < lineComponents.Length; i++)
        //        {
        //            lineComponents[i] = lineComponents[i].Trim().ToLower();
        //        }

        //        curParenthesesIndex = lineComponents[0].IndexOf('(');
        //        curWord = curParenthesesIndex > 0 ? lineComponents[0].Substring(0, curParenthesesIndex).Trim() : lineComponents[0].Trim();

        //        if (lineComponents[0].Contains("/")) // Example Item
        //        {
        //            if (item != null)
        //            {
        //                lineComponents[0] = lineComponents[0].Replace("/", item.Word);
        //                lineComponents[1] = lineComponents[1].Replace("/", item.Pronunciation);
        //                lineComponents[2] = lineComponents[2].Replace("/", item.PhoneticSpelling);
        //                item.Examples?.Add(new DictionaryItem(lineComponents[0], lineComponents[1], lineComponents[2], false));
        //            }
        //        }
        //        else if (!dictionary.ContainsKey(curWord)) // New Dictionary Item
        //        {
        //            item = new DictionaryItem(lineComponents[0], lineComponents[1], lineComponents[2], true);
        //            dictionary.Add(curWord, item);
        //        }
        //        else // Related Item
        //        {
        //            if (item != null)
        //            {
        //                item.RelatedItems?.Add(new DictionaryItem(lineComponents[0], lineComponents[1], lineComponents[2], false));
        //            }
        //        }
        //    }

        //    return dictionary;
        //}

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
