using MyTasker.Mobile.ViewModel;

namespace MyTasker.Mobile.Views;

public partial class ListTaskWithStatus : ContentPage
{
	public ListTaskWithStatus(ListTaskWithStatusViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}