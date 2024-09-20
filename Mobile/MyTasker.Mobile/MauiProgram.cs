using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MyTasker.Mobile.Views;

namespace MyTasker.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddTransient<AddTaskPage>();
            builder.Services.AddTransient<DeletedTaskPage>();
            builder.Services.AddTransient<DetailTaskPage>();
            builder.Services.AddTransient<FavoriteTaskPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<ListTaskPage>();
            builder.Services.AddTransient<ListTaskWithStatus>();
            builder.Services.AddTransient<SettingsPage>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
