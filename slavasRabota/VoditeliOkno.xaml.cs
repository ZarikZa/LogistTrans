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
    /// Логика взаимодействия для VoditeliOkno.xaml
    /// </summary>
    public partial class VoditeliOkno : Window
    {
        private LogisTransEntities1 context = new LogisTransEntities1();    
        public VoditeliOkno(Drivers driv)
        {
            InitializeComponent();
            List<Routess> routesses = new List<Routess>();
            foreach (Routess routess in context.Routess)
            {
                if(routess.Transport.Driver_ID == driv.ID_Drivers)
                {
                    routesses.Add(routess);
                }
            }
            MarshrutsDG.ItemsSource = routesses;
        }

        private void ExitBtm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
