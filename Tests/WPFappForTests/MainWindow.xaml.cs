using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WPFappForTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Thread(ComputeValue).Start();
            //new Thread(GetResult).Start();

        }

        private void ComputeValue()
        {
            var value = LongProcess(DateTime.Now);
            if (ResultBlock.Dispatcher.CheckAccess())
            {
                ResultBlock.Text = value;
            }
            else
                //ResultBlock.Dispatcher.Invoke(() => ComputeValue());
                ResultBlock.Dispatcher.BeginInvoke(new Action(() => ResultBlock.Text = value));
            
        }

        //private  void GetResult()
        //{
        //    ResultBlock.Text = LongProcess(DateTime.Now);
        //}
        private static string LongProcess(DateTime dateTime)
        {
            Thread.Sleep(3000);
            return $"result value {dateTime}";
        }
    }
}
