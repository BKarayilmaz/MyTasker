using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FmgLib.HttpClientHelper;
using MyTasker.Core.Models;
using MyTasker.Mobile.Views;
using System.Text.Json;
using CommunityToolkit.Maui.Alerts;
using MyTasker.Mobile.Extensions;

namespace MyTasker.Mobile.ViewModel
{
    public partial class DeletedTaskViewModel:BaseViewModel
    {
        [ObservableProperty]
        private List<TaskModel> _deletedTask;
        public DeletedTaskViewModel()
        {
            GetDeletedTasks();
        }

        private async void GetDeletedTasks()
        {
            DeletedTask = await HttpClientHelper.SendAsync<List<TaskModel>>
                (App.BaseUrl + "/Task/GetTrash/", HttpMethod.Get);
        }
        [RelayCommand]
        public async Task GoToDetailTaskPage(int id)
        {
            DetailTaskViewModel.Id = id;
            await Shell.Current.GoToAsync(nameof(DetailTaskPage));
        }
        [RelayCommand]
        public async Task Restore(TaskModel model)
        {
            await Task.Run(async () =>
            {
                string message = string.Empty;
                var result = await HttpClientHelper.SendAsync<string>(App.BaseUrl + "/Task/RestoreTask/" + model.Id, HttpMethod.Get);
                if (result == null || !bool.Parse(result))
                    message = "Task don't restored!";
                else
                    message = "Task restored!";

                SemanticScreenReader.Announce(message);
                var toast = Toast.Make(message, CommunityToolkit.Maui.Core.ToastDuration.Long, 20);

                await toast.Show();
            }).ContinueInMainThreadWith(GetDeletedTasks);
        }

        [RelayCommand]
        public async Task Remove(TaskModel model)
        {
            await Task.Run(async () =>
            {
                string message = string.Empty;
                var result = await HttpClientHelper.SendAsync<string>(App.BaseUrl + "/Task/" + model.Id, HttpMethod.Delete);
                if (result == null || !bool.Parse(result))
                    message = "Task don't deleted!";
                else
                    message = "Task deleted!";

                SemanticScreenReader.Announce(message);
                var toast = Toast.Make(message, CommunityToolkit.Maui.Core.ToastDuration.Long, 20);

                await toast.Show();
            }).ContinueInMainThreadWith(GetDeletedTasks);
        }
    }
}
