using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FmgLib.HttpClientHelper;
using MyTasker.Core.Models;
using MyTasker.Mobile.Views;

namespace MyTasker.Mobile.ViewModel
{
    public partial class HomeViewModel : BaseViewModel
    {
        [ObservableProperty]
        private SettingsModel _settings;
        [ObservableProperty]
        private List<TaskModel> _tasks;
        [ObservableProperty]
        private string _userText;
        [ObservableProperty]
        private string _thisMonthTaskCount;
        public HomeViewModel()
        {
            GetHomePageDetails();
        }
        [RelayCommand]
        public async Task Search(string searchText)
        {
            var searchTasks = await HttpClientHelper.SendAsync<List<TaskModel>>(App.BaseUrl + $"/Task/GetAllSearch/{searchText}", HttpMethod.Get);

        }
        private async void GetHomePageDetails()
        {
            Tasks = await HttpClientHelper.SendAsync<List<TaskModel>>(App.BaseUrl + "/Task/GetAllWithDay", HttpMethod.Get);
            Settings = await HttpClientHelper.SendAsync<SettingsModel>(App.BaseUrl + "/Settings", HttpMethod.Get);
            UserText = GetUserText();
            ThisMonthTaskCount = await GetThisMounthTaskCountAsync();
        }

        private string GetUserText()
        {
            var time = DateTime.Now.Hour;
            if (time >= 5 && time < 12)
                return $"Good Morning, {Settings.UserName}";
            else if (time >= 12 && time < 18)
                return $"Good Afternoon, {Settings.UserName}";
            else
                return $"Good Night, {Settings.UserName}";
        }

        public async Task<string> GetThisMounthTaskCountAsync()
        {
            var count = await HttpClientHelper.SendAsync<string>(App.BaseUrl + $"/Task/GetThisMonthTaskCount", HttpMethod.Get);
            return $"You Have {count} Tasks This Month";

        }

        [RelayCommand]
        public async Task GoToStatusPage(string status)
        {
            ListTaskWithStatusViewModel.StatusValue = int.Parse(status);
            await Shell.Current.GoToAsync(nameof(ListTaskWithStatus));
        }
        [RelayCommand]
        public async Task GoToListTaskPage()
        {
            await Shell.Current.GoToAsync(nameof(ListTaskPage));
        }
        [RelayCommand]
        public async Task GoToAddTaskPage()
        {
            await Shell.Current.GoToAsync(nameof(AddTaskPage));
        }

        [RelayCommand]
        public async Task GoToDetailTaskPage(int id)
        {
            DetailTaskViewModel.Id = id;
            await Shell.Current.GoToAsync(nameof(DetailTaskPage));
        }
    }
}
