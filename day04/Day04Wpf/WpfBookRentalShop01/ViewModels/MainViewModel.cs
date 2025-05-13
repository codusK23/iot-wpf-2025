using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfBookRentalShop01.Helpers;
using WpfBookRentalShop01.Views;

namespace WpfBookRentalShop01.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        // MahApps.Metro 형태 다이얼로그 코디네이터
        private readonly IDialogCoordinator dialogCoordinator;

        private string _greeting;

        public string Greeting
        {
            get => _greeting;
            set => SetProperty(ref _greeting, value);
        }

        private string _currentStatus;

        public string CurrentStatus
        {
            get => _currentStatus;
            set => SetProperty(ref _currentStatus, value);
        }

        private UserControl _currentView;

        public UserControl CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public MainViewModel(IDialogCoordinator coordinator)
        {
            this.dialogCoordinator = coordinator;   // 다이얼로그 코디네이터 초기화
            Greeting = "BookRentalShop!!";

            Common.LOGGER.Info("책대여점 프로그램 실행");
        }

        #region '화면 기능(이벤트)처리'

        [RelayCommand]
        public async Task AppExit()
        {
            //MessageBox.Show("종료합니다!");
            //await this.dialogCoordinator.ShowMessageAsync(this, "종료합니다!", "메시지");
            var result = await this.dialogCoordinator.ShowMessageAsync(this, "종료확인", "종료하시겠습니까?", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative) // OK를 누르면
            {
                Application.Current.Shutdown();
            }
            else
            {
                return;
            }
        }

        [RelayCommand]
        public void ShowBookGenre()
        {
            var vm = new BookGenreViewModel(Common.DIALOGCOORDINATOR);
            var v = new BookGenreView
            {
                DataContext = vm,
            };
            CurrentView = v;
            CurrentStatus = "책장르관리 화면입니다";

            Common.LOGGER.Info("책장르관리 실행");
        }

        [RelayCommand]
        public void ShowBooks()
        {
            var vm = new BooksViewModel();
            var v = new BooksView
            {
                DataContext = vm,
            };
            CurrentView = v;
            CurrentStatus = "책관리 화면입니다";

            Common.LOGGER.Info("책관리 실행");
        }

        [RelayCommand]
        public void ShowMembers()
        {
            var vm = new MembersViewModel(Common.DIALOGCOORDINATOR);
            var v = new MembersView
            {
                DataContext = vm,
            };
            CurrentView = v;
            CurrentStatus = "회원관리 화면입니다";
            Common.LOGGER.Info("회원관리 실행");
        }

        [RelayCommand]
        public void ShowRentals()
        {
            var vm = new RentalsViewModel();
            var v = new RentalsView
            {
                DataContext = vm,
            };
            CurrentView = v;
            CurrentStatus = "대여관리 화면입니다";
            Common.LOGGER.Info("대여관리 실행");
        }
        #endregion
    }
}
