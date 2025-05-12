using System.Configuration;
using System.Data;
using System.Windows;
using WpfBasicApp01.Views;
using WpfBasicApp01.ViewModels;

namespace WpfBasicApp01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var viewModel = new MainViewModel();

            var View = new MainView 
            {
                DataContext = viewModel,
            };
            View.ShowDialog();
        }
    }

}
