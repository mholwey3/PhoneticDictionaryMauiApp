using PhoneticDictionaryApp.Source;
using PhoneticDictionaryMauiApp.Views;

namespace PhoneticDictionaryMauiApp
{
    public partial class MainPage : ContentPage
    {
        private const string _FILE_NAME = "PHONETIC_DICTIONARY_BASE_A.csv";

        private IPhoneticDictionary _dictionary;

        private AdditionalInfoView _relatedItemsView;
        private AdditionalInfoView _examplesView;

        public MainPage()
        {
            InitializeComponent();

            _dictionary = new PhoneticDictionaryFile();
            _relatedItemsView = new AdditionalInfoView("Related Items");
            _examplesView = new AdditionalInfoView("Examples");
        }

        private void TryGetWord(object sender, EventArgs args)
        {
            string text = UserInput.Text;
            UserInput.Text = "";

            DictionaryItem? item = _dictionary.GetDictionaryItem(text);

            if (item != null)
            {
                SetDataOnView(item);
            }
            else
            {
                HandleItemNotFound(text);
            }
        }

        private void HandleItemNotFound(string text)
        {
            DictionaryItem item = new DictionaryItem(text, "No result found.", "", true);
            SetDataOnView(item);
        }

        private void SetDataOnView(DictionaryItem item)
        {
            Word.Text = item.Word;
            Pronunciation.Text = item.Pronunciation;
            PhoneticSpelling.Text = item.PhoneticSpelling;

            ClearRelatedItemsDataOnView();
            ClearExampleItemsDataOnView();

            if (item.RelatedItems.Count > 0)
            {
                SetRelatedItemsDataOnView(item);
            }

            if (item.UseCases.Count > 0)
            {
                SetExampleItemsDataOnView(item);
            }
        }

        private void SetRelatedItemsDataOnView(DictionaryItem item)
        {
            _relatedItemsView.SetDataOnView(item.RelatedItems);
            RelatedItemsParent.Children.Add(_relatedItemsView);
        }

        private void ClearRelatedItemsDataOnView()
        {
            _relatedItemsView.ClearDataOnView();
            RelatedItemsParent.Children.Clear();
        }

        private void SetExampleItemsDataOnView(DictionaryItem item)
        {
            _examplesView.SetDataOnView(item.UseCases);
            ExamplesParent.Children.Add(_examplesView);
        }

        private void ClearExampleItemsDataOnView()
        {
            _examplesView.ClearDataOnView();
            ExamplesParent.Children.Clear();
        }
    }

}
