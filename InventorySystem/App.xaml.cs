using InventorySystem.BLL;
using InventorySystem.DAL;
using InventorySystem.PL.Navigation;
using InventorySystem.PL.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace InventorySystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public IServiceProvider Services { get; }

        public App()
        {
            var services = new ServiceCollection();
            services.AddSingleton<Database>();
            services.AddTransient<ItemCodeDAL>();
            services.AddTransient<ItemCodeBLL>();

            //view models
            services.AddTransient<ItemCodeViewModel>();
            services.AddSingleton<NavigationService>();
            services.AddTransient<MainViewModel>();

            //window
            services.AddTransient<MainWindow>();

            Services = services.BuildServiceProvider();

        }

        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup(e);

            var Window = Services.GetRequiredService<MainWindow>();
            Window.Show();
        }


    }

}
