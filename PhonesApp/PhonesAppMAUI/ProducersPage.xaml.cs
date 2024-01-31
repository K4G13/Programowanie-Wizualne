using PhonesAppMAUI.ViewModels;

namespace PhonesAppMAUI;

public partial class ProducersPage : ContentPage
{
	public ProducersPage(ProducersCollectionViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}