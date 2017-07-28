﻿using System;
using System.Collections.Generic;
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
using WpfHttpClient.DataModel;

namespace WpfHttpClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MovieEntities _contextEntities = new MovieEntities();
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += RefreshMovies();
            timer.Start();
            SetMovies();
        }

        private void SetMovies()
        {
            List<Movie> movies = _contextEntities.Movies.ToList();
            foreach (Movie movie in movies)
            {
                var movie2 = movie;
            }
        }

        private EventHandler RefreshMovies()
        {

            return null;
        }

        private void GridControl_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //var item = _gridControl.GetFocused .SelectedIn;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            BuyTicket buyTicket = new BuyTicket();
            buyTicket.Owner = this;
            buyTicket.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            buyTicket.Show();
        }
    }
}
