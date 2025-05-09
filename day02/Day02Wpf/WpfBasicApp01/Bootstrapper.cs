using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;
using WpfBasicApp01.ViewModels;

namespace WpfBasicApp01
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container;
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IDialogCoordinator, DialogCoordinator>();
            _container.PerRequest<MainViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // base.OnStartup(sender, e);
            // App.xaml의 StartupUri와 동일한 일을 수행
            // MainViewModel과 동일한 이름의  View를 찾아서 바인딩 후 실행
            DisplayRootViewForAsync<MainViewModel>();
        }
    }
}

