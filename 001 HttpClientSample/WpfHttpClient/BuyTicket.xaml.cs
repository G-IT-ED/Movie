using System;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfHttpClient
{
    /// <summary>
    /// Логика взаимодействия для BuyTicket.xaml
    /// </summary>
    public partial class BuyTicket : Window
    {
        public BuyTicket()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();

            client
                .GetAsync("URI")
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

                        Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                            (Action)(() => {  })); //TODO
                    }
                });
        }
    }
}
