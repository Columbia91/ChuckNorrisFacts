using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
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

namespace ChuckNorris.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private ObservableCollection<Categories>
        public MainWindow()
        {
            InitializeComponent();
            Api();
        }
        private void Api()
        {
            string url = "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/categories";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Headers["X-RapidAPI-Key"] = "a0ffdc746bmsh1d3fccdb8bdebd4p105957jsncf7f0f18ddad"; //Api-Key заменил на 123 т.к он уникален для каждого клиента
            httpWebRequest.Headers["X-RapidAPI-Host"] = "matchilling-chuck-norris-jokes-v1.p.rapidapi.com";
            httpWebRequest.Method = "GET";
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }

            var array = JsonConvert.DeserializeObject(response);
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchTextBox.Text == "Поиск...")
            {
                TextBox textBox = (TextBox)sender;
                textBox.Text = string.Empty;
                textBox.GotFocus -= SearchTextBox_GotFocus;
                textBox.Foreground = Brushes.LightGray;
            }
        }

        private void CategoriesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
