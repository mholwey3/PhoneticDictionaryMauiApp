namespace PhoneticDictionaryApp.Source
{
    interface IPhoneticDictionary
    {
        DictionaryItem? GetDictionaryItem(string sWordToFind);
    }
}
