using PhoneticDictionaryMauiApp.Source;
using PhoneticDictionaryMauiApp.Views;
using System.Runtime.CompilerServices;
using static PhoneticDictionaryMauiApp.Source.DictionaryItem;

namespace PhoneticDictionaryMauiApp
{
    public partial class MainPage : ContentPage
    {
        private readonly PhoneticDictionaryDatabase _database;

        private readonly AdditionalInfoView _examplesView;

        public MainPage(PhoneticDictionaryDatabase database)
        {
            InitializeComponent();

            _database = database;
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
            NoResultsFoundDisplay.IsVisible = true;
            MainWordDisplay.IsVisible = false;
            WordDisplay.Text = text;
            Pronunciation.Text = "Item not found.";
            PhoneticSpelling.Text = string.Empty;
            ClearExampleItemsDataOnView();
        }

        private void SetDataOnView(List<DictionaryItem> items)
        {
            DictionaryItem mainItem = items.Find(i => i.Type == ItemType.Main);
            List<DictionaryItem> examples = items.FindAll(i => i.Type == ItemType.Example);

            NoResultsFoundDisplay.IsVisible = false;
            MainWordDisplay.IsVisible = true;
            WordDisplay.Text = mainItem.WordDisplay;
            Pronunciation.Text = mainItem.Pronunciation;
            PhoneticSpelling.Text = mainItem.PhoneticSpelling;

            ClearExampleItemsDataOnView();

            if (examples.Count > 0)
            {
                SetExampleItemsDataOnView(examples);
            }
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

        private void SwitchToggled(object sender, ToggledEventArgs e)
        {
            PhoneticSpelling.IsVisible = e.Value;
            Pronunciation.IsVisible = !e.Value;
        }
    }

}
