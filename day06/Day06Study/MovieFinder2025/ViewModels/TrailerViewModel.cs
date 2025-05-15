using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using MahApps.Metro.Controls.Dialogs;
using MovieFinder2025.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace MovieFinder2025.ViewModels
{
    public partial class TrailerViewModel : ObservableObject
    {
        private readonly IDialogCoordinator dialogCoordinator;
        public TrailerViewModel(IDialogCoordinator coordinator, string movieTitle) 
        {
            this.dialogCoordinator = coordinator;
            MovieTitle = movieTitle;    // 이렇게 해야 영화제목으로 검색가능

            YoutubeUri = "https://www.youtube.com";
            
            SearchYoutubeApi();
        }

        private string _movieTitle;

        public string MovieTitle
        {
            get => _movieTitle;
            set => SetProperty(ref _movieTitle, value);
        }

        private ObservableCollection<YoutubeItem> _youtubeItems;
        

        public ObservableCollection<YoutubeItem> YoutubeItems
        {
            get => _youtubeItems;
            set => SetProperty(ref _youtubeItems, value);
        }

        private YoutubeItem _selectedYoutube;

        public YoutubeItem SelectedYoutube
        {
            get => _selectedYoutube;
            set => SetProperty(ref _selectedYoutube, value);
        }

        private string _youtubeUri;
        public string YoutubeUri
        {
            get => _youtubeUri;
            set => SetProperty(ref _youtubeUri, value);
        }

        /// <summary>
        /// 핵심 Youtube Data APi v3 호출
        /// </summary>
        private async void SearchYoutubeApi()
        {
            await LoadDataCollection();
        }

        private async Task LoadDataCollection()
        {
            var service = new YouTubeService(
                new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyCmkTiWGp2JX449sfbpza81zr4Rqj_cikY",
                    ApplicationName = this.GetType().ToString()
                });

            var req = service.Search.List("snippet");
            req.Q = $"{MovieTitle} 공식 예고편";   // 영화이름만 사용해서 Youtube API를 검색
            req.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            req.Type = "video";
            req.MaxResults = 8;

            ObservableCollection<YoutubeItem> youtubeItems = new ObservableCollection<YoutubeItem>();

            var res = await req.ExecuteAsync(); // Youtube API 서버에 요청된 값을 실행하고 결과를 리턴(비동기)

            foreach (var item in res.Items)
            {
                youtubeItems.Add(new YoutubeItem
                {
                    Title = item.Snippet.Title,
                    ChannelTitle = item.Snippet.ChannelTitle,
                    URL = $"https://www.youtube.com/watch?v={item.Id.VideoId}",     // Youtube Play Link
                    Author = item.Snippet.ChannelId,
                    Thumbnail = new BitmapImage(new Uri(item.Snippet.Thumbnails.Default__.Url, UriKind.RelativeOrAbsolute))
                });
            }
            YoutubeItems = youtubeItems;
            Common.LOGGER.Info($"{MovieTitle}의 예고편 {YoutubeItems.Count} 조회완료!");
        }

        [RelayCommand]
        public async Task YoutubeDoubleClick()
        {
            YoutubeUri = SelectedYoutube.URL;
        }
    }
}
