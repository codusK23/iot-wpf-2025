using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using System.Windows;

namespace WpfBasicApp01.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        // 메시지박스
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

        public MainViewModel() 
        {
            Greeting = "Hello, Caliburn.Micro!!";
        }

        public async Task SayHello()
        {
            Greeting = "Hi, Everyone~!";
            //WinForms 방식
            //MessageBox.Show("Hi, Everyone~!", "Greeting", MessageBoxButton.OK, MessageBoxImage.Information);
            //await _dialogCoordinator.ShowMessageAsync(this, )
        }
    }
}
