using MyTasker.Mobile.ViewModel;

namespace MyTasker.Mobile.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext =viewModel;
	}
}