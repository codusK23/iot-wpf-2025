using Caliburn.Micro;
using System.Windows;
using WpfBasicApp02.ViewModels;

namespace WpfBasicApp02
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<MainViewModel>();
        }
    }
}

