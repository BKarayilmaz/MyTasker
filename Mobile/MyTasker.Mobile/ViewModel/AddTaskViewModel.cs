//using Android.Media;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FmgLib.HttpClientHelper;
using MyTasker.Core.Enums;
using MyTasker.Core.Models;
using Plugin.LocalNotification;
using System.Text.Json;

namespace MyTasker.Mobile.ViewModel
{
    public partial class AddTaskViewModel: BaseViewModel
    {
        [ObservableProperty]
        private string _title;
        [ObservableProperty]
        private string _content;
        [ObservableProperty]
        private DateTime _date;
        [ObservableProperty]
        private TimeSpan _time;
        [ObservableProperty]
        private string _color;

        [RelayCommand]
        public void SetColor(object model)
        {
            Color = model?.ToString();
        }

        [RelayCommand]
        public async Task Save()
        {
            string message=string.Empty;
            TaskModel model = new()
            {
                Color = Color,
                Content = Content,
                IsActive = true,
                IsFavorite = false,
                Status = MyTaskStatus.Backlog,
                Title = Title,
                TaskDate = DateTime.Parse(Date.ToShortDateString() + " " + Time.ToString())
            };
            var control = model.TryParseToJson(out string jsonModel);
            if (!control)
                jsonModel = JsonSerializer.Serialize(model);

            var result = await HttpClientHelper.SendAsync<string>(App.BaseUrl +"/Task",HttpMethod.Post,jsonModel,ClientContentType.Json);
            if (result == null || !bool.Parse(result))
                message = "Task don't save!";
            else
            {
                message = "Task saved!";

                var request = new NotificationRequest
                {
                    NotificationId = 1000 + model.Id,
                    Title = "My Tasker",
                    Subtitle = model.Title,
                   Description = model.Content,
                    BadgeNumber = 42,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = model.TaskDate,
                    }
                };
                LocalNotificationCenter.Current.Show(request);
            }

            SemanticScreenReader.Announce(message);
            var toast = Toast.Make(message, CommunityToolkit.Maui.Core.ToastDuration.Long, 20);

            await toast.Show();

            App.Current.MainPage = new AppShell();
        }
    }
}
