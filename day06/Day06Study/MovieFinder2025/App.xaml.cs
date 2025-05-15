using MahApps.Metro.Controls.Dialogs;
using MovieFinder2025.Helpers;
using MovieFinder2025.ViewModels;
using MovieFinder2025.Views;
using System.Windows;

namespace MovieFinder2025
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Common.DIALOGCOORDINATOR = DialogCoordinator.Instance;  // new DialogCoordinator();

            var viewModel = new MoviesViewModel(Common.DIALOGCOORDINATOR);
            var view = new MoviesView
            {
                DataContext = viewModel,
            };
            view.Show();
        }
    }

}
