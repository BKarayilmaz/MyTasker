using MyTasker.Mobile.ViewModel;

namespace MyTasker.Mobile.Views;

public partial class DeletedTaskPage : ContentPage
{
	public DeletedTaskPage(DeletedTaskViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}