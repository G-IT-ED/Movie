using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Newtonsoft.Json;
using WpfHttpClient.DataModel;

namespace WpfHttpClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MovieEntities _contextEntities = new MovieEntities();

        private const string URI = "http://localhost:8889/api/movies";

        private BindingList<Movie> _bindingList = new BindingList<Movie>(); 

        public MainWindow()
        {
            InitializeComponent();
            _gridControl.DataSource = _bindingList;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 20);
            timer.Tick += new EventHandler(RefreshMovies);
            timer.Start();
            SetMovies();
            RefreshMovies(null,EventArgs.Empty);
        }

        private void SetMovies()
        {
            List<Movie> movies = _contextEntities.Movies.ToList();
            SetData(movies);
        }

        private void RefreshMovies(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            client
                .GetAsync(URI)
                .ContinueWith(response =>
                {
                    if (response.Exception != null)
                    {
                        MessageBox.Show(response.Exception.Message);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);//TODO
                        HttpResponseMessage message = response.Result;

                        string responseText = message.Content.ReadAsStringAsync().Result;
                        List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(responseText);

                        Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                            (Action)(() =>
                            {
                                SetData(movies);
                                foreach (Movie movie in _contextEntities.Movies)
                                {
                                    _contextEntities.Movies.Remove(movie);
                                }
                                _contextEntities.SaveChanges();

                                _contextEntities.Movies.AddRange(movies);
                                _contextEntities.SaveChanges();
                            })); //TODO
                    }
                });
            
        }

        private void SetData(List<Movie> movies)
        {
            _bindingList.Clear();
            foreach (Movie movie in movies)
            {
                _bindingList.Add(movie);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Movie movie = (_gridControl.SelectedItem == null) ? null : (Movie)_gridControl.SelectedItem;
            if (movie == null) return;
            ShowTicket(movie);
        }

        private void ShowTicket(Movie movie)
        {
            BuyTicket buyTicket = new BuyTicket(new Ticket(movie));
            buyTicket.Owner = this;
            buyTicket.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            buyTicket.Show();
        }


        public void Connect(int connectionId, object target)
        {
            throw new NotImplementedException();
        }
    }
}
