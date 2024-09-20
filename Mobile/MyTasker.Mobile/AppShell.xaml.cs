using MyTasker.Mobile.Views;

namespace MyTasker.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage),typeof(HomePage));
            Routing.RegisterRoute(nameof(AddTaskPage),typeof(AddTaskPage));
            Routing.RegisterRoute(nameof(DeletedTaskPage),typeof(DeletedTaskPage));
            Routing.RegisterRoute(nameof(DetailTaskPage),typeof(DetailTaskPage));
            Routing.RegisterRoute(nameof(FavoriteTaskPage),typeof(FavoriteTaskPage));
            Routing.RegisterRoute(nameof(ListTaskPage),typeof(ListTaskPage));
            Routing.RegisterRoute(nameof(ListTaskWithStatus),typeof(ListTaskWithStatus));
            Routing.RegisterRoute(nameof(SettingsPage),typeof(SettingsPage));
        }
    }
}
