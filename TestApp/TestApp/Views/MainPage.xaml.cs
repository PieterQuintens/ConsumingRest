using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HelloWorld
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public int weight { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Response> Responses { get; set; }
        public Response  Response { get; set; }
    }

    public class Response
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Correct { get; set; }
    }


    public partial class MainPage : ContentPage
    {

        private const string Url = "https://10.0.2.2:8443/quizking/quizzes";
        //private const string Url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Quiz> _posts;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", "ZW50bW9iMjAxOF82X3VzZXI6ZW50bW9iMjAxOF82X3VzZXI=");

            var content = await _client.GetStringAsync(Url);
            var posts = JsonConvert.DeserializeObject<List<Quiz>>(content);

            _posts = new ObservableCollection<Quiz>(posts);
            postsListView.ItemsSource = _posts;

            base.OnAppearing();
        }

        void OnAdd(object sender, System.EventArgs e)
        {
        }

        void OnUpdate(object sender, System.EventArgs e)
        {
        }

        void OnDelete(object sender, System.EventArgs e)
        {
        }
    }
}