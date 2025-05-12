using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfBookRentalShop01.Models
{
    public class Genre : ObservableObject
    {
        private string _division;
        private string _names;

        public string Division { 
            get => _division; 
            set => SetProperty(ref _division, value);
        }
        public string Names { 
            get => _names; 
            set => SetProperty(ref _names, value);
        }
    }
}
