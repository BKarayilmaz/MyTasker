﻿using FmgLib.HttpClientHelper;
using MyTasker.Core.Enums;
using MyTasker.Core.Models;

namespace MyTasker.Mobile
{
    public partial class App : Application
    {
        public static string BaseUrl { get; private set; }
        public App()
        {
            BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5238/api" : "http://localhost:5238/api";

            GetThemeAsync();
            InitializeComponent();

            MainPage = new AppShell();
        }

        private async void GetThemeAsync()
        {
            //Receive App Theme Choice
            var model = await HttpClientHelper.SendAsync<SettingsModel>(BaseUrl + "/Settings", HttpMethod.Get);
            UserAppTheme = model.Theme == MyTaskTheme.Dark ? AppTheme.Dark : AppTheme.Light;
        }

        
    }
}
