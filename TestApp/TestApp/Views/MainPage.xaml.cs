using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Android.Net;
using Javax.Net.Ssl;
using Newtonsoft.Json;
using Xamarin.Android.Net;
using Xamarin.Forms;

namespace HelloWorld
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public partial class MainPage : ContentPage
    {

        private const string Url = "https://10.0.2.2:8443/quizking/quizzes";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Post> _posts;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", "ZW50bW9iMjAxOF82X3VzZXI6ZW50bW9iMjAxOF82X3VzZXI=");

            var content = await _client.GetStringAsync(Url);
            var posts = JsonConvert.DeserializeObject<List<Post>>(content);

            _posts = new ObservableCollection<Post>(posts);
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

        internal class BypassHostnameVerifier : Java.Lang.Object, IHostnameVerifier
        {
            public bool Verify(string hostname, ISSLSession session)
            {
                return true;
            }
        }

        internal class BypassSslValidationClientHandler : AndroidClientHandler
        {
            protected override SSLSocketFactory ConfigureCustomSSLSocketFactory(HttpsURLConnection connection)
            {
                return SSLCertificateSocketFactory.GetInsecure(1000, null);
            }

            protected override IHostnameVerifier GetSSLHostnameVerifier(HttpsURLConnection connection)
            {
                return new BypassHostnameVerifier();
            }
        }
    }
}