using PhonesAppMAUI.ViewModels;

namespace PhonesAppMAUI;

public partial class PhonesPage : ContentPage
{
	public PhonesPage(PhonesCollectionViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}