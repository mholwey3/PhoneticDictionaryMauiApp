using PhoneticDictionaryMauiApp.Source;
using PhoneticDictionaryMauiApp.Views;
using static PhoneticDictionaryMauiApp.Source.DictionaryItem;

namespace PhoneticDictionaryMauiApp
{
    public partial class MainPage : ContentPage
    {
        private readonly PhoneticDictionaryDatabase _database;

        private readonly AdditionalInfoView _relatedItemsView;
        private readonly AdditionalInfoView _examplesView;

        public MainPage(PhoneticDictionaryDatabase database)
        {
            InitializeComponent();

            _database = database;
            _relatedItemsView = new AdditionalInfoView("Related Items");
            _examplesView = new AdditionalInfoView("Examples");
        }

        private void TryGetWord(object sender, EventArgs args)
        {
            string text = UserInput.Text.Trim().ToLower();
            UserInput.Text = "";

            List<DictionaryItem> items = _database.GetItems(text);

            if (items.Count > 0)
            {
                SetDataOnView(items);
            }
            else
            {
                HandleItemNotFound(text);
            }
        }

        private void HandleItemNotFound(string text)
        {
            Word.Text = text;
            Pronunciation.Text = "Item not found.";
            PhoneticSpelling.Text = string.Empty;
        }

        private void SetDataOnView(List<DictionaryItem> items)
        {
            DictionaryItem mainItem = items.Find(i => i.Type == ItemType.Main);
            List<DictionaryItem> relatedItems = items.FindAll(i => i.Type == ItemType.RelatedItem);
            List<DictionaryItem> examples = items.FindAll(i => i.Type == ItemType.Example);

            Word.Text = mainItem.WordDisplay;
            Pronunciation.Text = mainItem.Pronunciation;
            PhoneticSpelling.Text = mainItem.PhoneticSpelling;

            ClearRelatedItemsDataOnView();
            ClearExampleItemsDataOnView();

            if (relatedItems.Count > 0)
            {
                SetRelatedItemsDataOnView(relatedItems);
            }

            if (examples.Count > 0)
            {
                SetExampleItemsDataOnView(examples);
            }
        }

        private void SetRelatedItemsDataOnView(List<DictionaryItem> items)
        {
            _relatedItemsView.SetDataOnView(items);
            RelatedItemsParent.Children.Add(_relatedItemsView);
        }

        private void ClearRelatedItemsDataOnView()
        {
            _relatedItemsView.ClearDataOnView();
            RelatedItemsParent.Children.Clear();
        }

        private void SetExampleItemsDataOnView(List<DictionaryItem> items)
        {
            _examplesView.SetDataOnView(items);
            ExamplesParent.Children.Add(_examplesView);
        }

        private void ClearExampleItemsDataOnView()
        {
            _examplesView.ClearDataOnView();
            ExamplesParent.Children.Clear();
        }
    }

}
