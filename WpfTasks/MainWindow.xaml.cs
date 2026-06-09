using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace WpfTasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Dependency 
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html",
            typeof(string),
            typeof(MainWindow),
            new FrameworkPropertyMetadata(OnHtmlChanged));
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Debug.WriteLine($"Thred number: {Thread.CurrentThread.ManagedThreadId}");
                HttpClient webClient = new HttpClient();
                string html = webClient.GetStringAsync("https://google.com").Result;
                MyButton.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"Thred number: {Thread.CurrentThread.ManagedThreadId}");
                    MyButton.Content = "Done downloading!!!";
                }
                );
                
            } );
            
            
            //MessageBox.Show("Button is working!!!");
        }
        // 
        private async void MyButton_Click_2(object sender, RoutedEventArgs e)
        {
            string myHtml = "Bla";
            Debug.WriteLine($"\nThred number: {Thread.CurrentThread.ManagedThreadId} before await task!!!");

            await Task.Run(async() =>
            {
                Debug.WriteLine($"\nThred number: {Thread.CurrentThread.ManagedThreadId} during await task!!");
                HttpClient webClient = new HttpClient();
                string html = webClient.GetStringAsync("https://google.com").Result;
                myHtml = html;

            });
            Debug.WriteLine($"\nThred number: {Thread.CurrentThread.ManagedThreadId} after await task!!!");

            MyButton.Content = "Done Downloading!!!";
            MyWebBroser.SetValue(HtmlProperty, myHtml);
            //MessageBox.Show("Button is working!!!");
        }
        static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = d as WebBrowser;
            if (webBrowser != null)
            {
                webBrowser.NavigateToString(e.NewValue as string);
            }
        }
    }
}
