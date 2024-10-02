using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FmgLib.HttpClientHelper;
using MyTasker.Core.Models;
using MyTasker.Mobile.Views;

namespace MyTasker.Mobile.ViewModel
{
    public partial class FavoriteTaskViewModel:BaseViewModel
    {
        [ObservableProperty]
        private List<TaskModel> _favorites;
        public FavoriteTaskViewModel()
        {
            GetFavoriteTasks();
        }

        private async void GetFavoriteTasks()
        {
            Favorites = await HttpClientHelper.SendAsync<List<TaskModel>>
                (App.BaseUrl + "/Task/GetFavorite", HttpMethod.Get);
        }
        [RelayCommand]
        public async Task GoToDetailTaskPage(int id)
        {
            DetailTaskViewModel.Id = id;
            await Shell.Current.GoToAsync(nameof(DetailTaskPage));
        }
    }
}
