using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using System.Windows;

namespace WpfBasicApp01.ViewModels
{
    public class MainViewModel : Screen
    {
        // 메시지박스, 다이얼로그를 위한 변수
        private readonly IDialogCoordinator _dialogCoordinator;

        public string _greeting;

        public string Greeting
        {
            get => _greeting;
            set
            {
                _greeting = value;
                NotifyOfPropertyChange(() => Greeting);
                // 속성값 바뀐것을 알려줘야함!!!
            }
        }

        // IDialogCoordinator는 DI로 주입 받음
        public MainViewModel(IDialogCoordinator dialogCoordinator)
        {
            _dialogCoordinator = dialogCoordinator;
            Greeting = "Hello, Caliburn.Micro!!";
        }

        public async Task SayHello()
        {
            Greeting = "Hi, Everyone~!";
            //WinForms 방식
            //MessageBox.Show("Hi, Everyone~!", "Greeting", MessageBoxButton.OK, MessageBoxImage.Information);
            await _dialogCoordinator.ShowMessageAsync(this, "Greeting", "Hi, Everyone~!");
        }
    }
}
