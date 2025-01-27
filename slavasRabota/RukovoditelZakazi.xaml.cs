using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace slavasRabota
{
    /// <summary>
    /// Логика взаимодействия для RukovoditelZakazi.xaml
    /// </summary>
    public partial class RukovoditelZakazi : Window
    {
        public RukovoditelZakazi()
        {
            InitializeComponent();
            FrameRukovod.Content = new Zakazi();
        }

        private void ZakaziPereh_Click(object sender, RoutedEventArgs e)
        {
            FrameRukovod.Content = new Zakazi();

        }

        private void TransportPereh_Click(object sender, RoutedEventArgs e)
        {
            FrameRukovod.Content = new TransportPage();
        }

        private void ExitBtm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void ClientsPereh_Click(object sender, RoutedEventArgs e)
        {
            FrameRukovod.Content = new ClientsPage();
        }

        private void RoutesPereh_Click(object sender, RoutedEventArgs e)
        {
            FrameRukovod.Content = new Marshruts();
        }

        private void SkladPereh_Click(object sender, RoutedEventArgs e)
        {
            FrameRukovod.Content = new StoragePage();
        }

        private void SotrudPereh_Click(object sender, RoutedEventArgs e)
        {
            FrameRukovod.Content = new SotrudnikiPage();
        }

        private void VoditeliPereh_Click(object sender, RoutedEventArgs e)
        {
            FrameRukovod.Content = new Voditeli();
        }
    }
}
