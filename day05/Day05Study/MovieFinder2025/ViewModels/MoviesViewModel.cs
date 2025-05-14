using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using MovieFinder2025.Helpers;
using MovieFinder2025.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Web;

namespace MovieFinder2025.ViewModels
{
    public partial class MoviesViewModel : ObservableObject
    {
        private readonly IDialogCoordinator dialogCoordinator;
        public MoviesViewModel(IDialogCoordinator coordinator) 
        {
            this.dialogCoordinator = coordinator;

            Common.LOGGER.Info("MovieFinder2025 Start.");

            PosterUri = new Uri("/No_Picture.png", UriKind.RelativeOrAbsolute);
        }

        private string _movieName;

        public string MovieName 
        {
            get => _movieName;
            set => SetProperty(ref _movieName, value);
        }

        private ObservableCollection<MovieItem> _movieItems;
        public ObservableCollection<MovieItem> MovieItems
        {
            get => _movieItems;
            set => SetProperty(ref _movieItems, value);
        }

        private MovieItem _seletedMovieItem;
        public MovieItem SelectedMovieItem
        {
            get => _seletedMovieItem;
            set
            {
                SetProperty(ref _seletedMovieItem, value);
                Common.LOGGER.Info($"Selected Movie Item > {value.Poster_path}");

                // 포스터 이미지를 포스터 영역에 표시
                PosterUri = new Uri($"{_base_url}{value.Poster_path}", UriKind.Absolute);
            }
        }

        private Uri _posterUri;

        public Uri PosterUri
        {
            get => _posterUri;
            set => SetProperty(ref _posterUri, value);
        }

        private string _base_url = "https://image.tmdb.org/t/p/w300_and_h450_bestv2";

        [RelayCommand]
        public async Task SearchMovie()
        {
            //await this.dialogCoordinator.ShowMessageAsync(this, "영화검색", MovieName);
            if (string.IsNullOrEmpty(MovieName))
            {
                await this.dialogCoordinator.ShowMessageAsync(this, "영화검색", "영화명을 입력하세요.");
                return;
            }
            var controller = await dialogCoordinator.ShowProgressAsync(this, "대기중", "검색 중...");
            controller.SetIndeterminate();
            SearchMovie(MovieName);
            await Task.Delay(1000);
            await controller.CloseAsync();
        }

        private async void SearchMovie(string movieName)
        {
            string tmdb_apikey = "229305322643a85a4f29d9041295282d"; // TMDB에서 신청한 API키
            string encoding_movieName = HttpUtility.UrlEncode(movieName, Encoding.UTF8);  // 입력한 한글을 UTF-8로 변경
            string openApiUri = $"https://api.themoviedb.org/3/search/movie?api_key={tmdb_apikey}" +
                                       $"&language=ko-KR&page=1&include_adult=false&query={encoding_movieName}";

            //Debug.WriteLine(openApiUri);
            Common.LOGGER.Info($"TMDB URI : {openApiUri}");

            string result =string.Empty;

            // OpenAPI 실행할 웹 객체, WebRequest, WebResponse -> Deprecated 추후 삭제될 예정
            // HrrpClient로 대체할 것
            //WebRequest req = null;
            //WebResponse res = null;
            HttpClient client = new HttpClient();
            ObservableCollection<MovieItem> movieItems = new ObservableCollection<MovieItem>();
            string reader; // 응답을 받은 결과를 담는 객체

            try
            {
                //response = await client.GetAsync(openApiUri);
                var response = await client.GetFromJsonAsync<MovieSearchResponse>(openApiUri);

                foreach (MovieItem movie in response.Results)
                {
                    Common.LOGGER.Info($"{movie.Title}, {movie.Release_date.ToString("yyyy-MM-dd")}");
                    movieItems.Add(movie);
                }
            }
            catch (Exception ex)
            {
                await this.dialogCoordinator.ShowMessageAsync(this, "예외", ex.Message);
                Common.LOGGER.Fatal(ex.Message);
            }
            MovieItems = movieItems;    // View에 가져갈 속성에 데이터 할당
        }

        [RelayCommand]
        public async Task MovieItemDoubleClick()
        {
            var currMovie = SelectedMovieItem;
            if (currMovie != null)
            {
                StringBuilder sb = new StringBuilder();

                // Environment.NewLine == "\r\n"
                //sb.Append(currMovie.Original_title + " (" + currMovie.Release_date.ToString("yyyy-MM-dd") + ")" + Environment.NewLine);
                
                sb.Append($"{currMovie.Original_title} ({currMovie.Release_date.ToString("yyyy-MM-dd")})\n");
                sb.Append($"평점 : {currMovie.Vote_average.ToString("F2")}\n\n");
                sb.Append(currMovie.Overview);


                await this.dialogCoordinator.ShowMessageAsync(this, currMovie.Title, sb.ToString());
            }
        }
    }
}
