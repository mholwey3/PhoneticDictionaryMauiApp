
using PhoneticDictionaryApp.Source;

namespace PhoneticDictionaryMauiApp.Views;

public partial class AdditionalInfoView : StackLayout
{
    public AdditionalInfoView(string infoHeader)
    {
        InitializeComponent();

        InfoHeader.Text = infoHeader;
    }

    public void SetDataOnView(List<DictionaryItem> items)
    {
        BindableLayout.SetItemsSource(InfoList, items);
    }

    public void ClearDataOnView()
    {
        BindableLayout.SetItemsSource(InfoList, null);
    }
}