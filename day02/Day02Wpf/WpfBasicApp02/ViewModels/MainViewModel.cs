using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using WpfBasicApp02.Models;

namespace WpfBasicApp02.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        public ObservableCollection<KeyValuePair<string, string>> Divisions { get; set; }

        public ObservableCollection<Book> Books { get; set; }

        private Book _selectedBook;

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                NotifyOfPropertyChange(() => SelectedBook);
            }
        }

        private readonly IDialogCoordinator _dialogCoordinator;

        public MainViewModel(IDialogCoordinator dialogCoordinator)
        {
            _dialogCoordinator = new DialogCoordinator();
            LoadControlFromDb();
            LoadGridFromDb();
        }

        private void LoadControlFromDb()
        {
            // 1. 연결 문자열 (DB 연결 문자열은 필수)
            string connectionString = "Server=localhost;Database=bookrentalshop;Uid=root;Pwd=12345;Charset=utf8;";
            // 2. 사용쿼리
            string query = "SELECT division, names FROM divtbl";

            // Dictionary나 KeyValuePair 둘 다 상관없음
            ObservableCollection<KeyValuePair<string, string>> divisions = new ObservableCollection<KeyValuePair<string, string>>();

            // 3. DB연결, 명령, 리더
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();   // 데이터 가져올 때

                    while (reader.Read())
                    {
                        var division = reader.GetString("division");
                        var names = reader.GetString("names");


                        divisions.Add(new KeyValuePair<string, string>(division, names));
                    }
                }
                catch (MySqlException ex)
                {
                    // 나중에...
                }
            } // conn.Close() 자동발생

            Divisions = divisions;
            NotifyOfPropertyChange(() => Divisions); // Caliburn.Micro가 제공하는 메서드
        }

        // DB에서 데이터 로드 후 Books 속성에 집어넣기
        private void LoadGridFromDb()
        {
            // 1. 연결문자열(DB연결문자열은 필수)
            string connectionString = "Server=localhost;Database=bookrentalshop;Uid=root;Pwd=12345;Charset=utf8;";
            // 2. 사용쿼리, 기본쿼리로 먼저 작업 후 필요한 실제쿼리로 변경해도
            string query = @"SELECT b.Idx, b.Author, b.Division, b.Names, b.ReleaseDate, b.ISBN, b.Price,
                                       d.Names AS dNames
                                    FROM bookstbl AS b, divtbl AS d
                                    WHERE b.Division = d.Division
                                    ORDER by b.Idx";

            ObservableCollection<Book> books = new ObservableCollection<Book>();

            // 3. DB연결, 명령, 리더
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Idx = reader.GetInt32("Idx"),
                            Division = reader.GetString("Division"),
                            DNames = reader.GetString("dNames"),
                            Names = reader.GetString("Names"),
                            Author = reader.GetString("Author"),
                            ISBN = reader.GetString("ISBN"),
                            ReleaseDate = reader.GetDateTime("ReleaseDate"),
                            Price = reader.GetInt32("Price")
                        });
                    }
                }
                catch (MySqlException ex)
                {
                    // 나중에 ...
                }
            } // conn.Close() 자동발생

            Books = books;
            NotifyOfPropertyChange(() => Books);
        }

        public async void DoAction()
        {
        }

    }
}
