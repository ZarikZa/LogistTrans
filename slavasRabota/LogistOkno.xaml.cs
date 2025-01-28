using System;
using System.Collections.Generic;
using System.Linq;
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

namespace slavasRabota
{
    /// <summary>
    /// Логика взаимодействия для LogistOkno.xaml
    /// </summary>
    public partial class LogistOkno : Window
    {
        public LogistOkno()
        {
            InitializeComponent();
            FrameLog.Content = new TransportPage();
        }

        private void RoutesPereh_Click(object sender, RoutedEventArgs e)
        {
            FrameLog.Content = new Marshruts();
        }

        private void TransportPereh_Click(object sender, RoutedEventArgs e)
        {
            FrameLog.Content = new TransportPage();
        }

        private void ExitBtm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void OtchetPereh_Click(object sender, RoutedEventArgs e)
        {
            FrameLog.Content = new Otchet();
        }
    }
}