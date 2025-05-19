using BusanRestaurantApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BusanRestaurantApp.ViewModels
{
    public class GoogleMapViewModel : ObservableObject
    {
        public GoogleMapViewModel()
        {
            MatjibLocation = "";
        }

        private BusanItem _selectedMatjibItem;
        public BusanItem SelectedMatjibItem
        {
            get => _selectedMatjibItem;
            set
            {
                SetProperty(ref _selectedMatjibItem, value);
                // 위도(Latitude/Lat), 경도(Longitude/Lng)
                MatjibLocation = $"https://google.com/maps/place/{SelectedMatjibItem.Lat},{SelectedMatjibItem.Lng}";
            }
        }

        private string _matjibLocation;

        public string MatjibLocation
        {
            get => _matjibLocation;
            set => SetProperty(ref _matjibLocation, value);
        }


    }
}
