using MyTasker.Mobile.ViewModel;

namespace MyTasker.Mobile.Views;

public partial class FavoriteTaskPage : ContentPage
{
	public FavoriteTaskPage(FavoriteTaskViewModel viewModel)
	{
		InitializeComponent();
		BindingContext =viewModel;
	}
}