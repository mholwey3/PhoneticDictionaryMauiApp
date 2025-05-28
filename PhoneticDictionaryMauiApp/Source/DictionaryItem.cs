using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneticDictionaryApp.Source
{
	public class DictionaryItem
	{
        public string Word { get; private set; }
        public string Pronunciation { get; private set; }
        public string PhoneticSpelling { get; private set; }

        public List<DictionaryItem> RelatedItems { get; private set; }
        public List<DictionaryItem> UseCases { get; private set; }

        public DictionaryItem(string sWord, string sDictionaryPronunciation, string sPhoneticSpelling, bool bIsMainItem)
        {
            Word = sWord;
            Pronunciation = sDictionaryPronunciation;
            PhoneticSpelling = sPhoneticSpelling;

            if (bIsMainItem)
            {
                RelatedItems = new List<DictionaryItem>();
                UseCases = new List<DictionaryItem>();
            }
        }
    }
}
