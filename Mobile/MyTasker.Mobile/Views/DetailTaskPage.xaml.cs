using MyTasker.Mobile.ViewModel;

namespace MyTasker.Mobile.Views;

public partial class DetailTaskPage : ContentPage
{
	public DetailTaskPage(DetailTaskViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        DateField.MinimumDate = DateTime.Now;
    }
}