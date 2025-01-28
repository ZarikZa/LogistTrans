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
        Drivers driv = new Drivers();
        public VoditeliOkno(Drivers driv)
        {
            InitializeComponent();
            this.driv = driv;
            List<Routess> routesses = new List<Routess>();
            foreach (Routess routess in context.Routess)
            {
                if(routess.Transport.Driver_ID == driv.ID_Drivers)
                {
                    if (routess.RouteStatuses.RouteStatus != "Доставлен")
                    {
                        routesses.Add(routess);
                    }
                }
            }
            MarshrutsDG.ItemsSource = routesses;
            StatusCB.ItemsSource = context.RouteStatuses.ToList();
            StatusCB.DisplayMemberPath = "RouteStatus";
        }

        private void ExitBtm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void MarshrutsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = MarshrutsDG.SelectedItem as Routess;
            if (selected != null)
                StatusCB.SelectedItem = selected.RouteStatuses;
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = MarshrutsDG.SelectedItem as Routess;
            if (selected != null)
            {
                selected.RouteStatuses = StatusCB.SelectedItem as RouteStatuses;

                context.SaveChanges();
                List<Routess> routesses = new List<Routess>();
                foreach (Routess routess in context.Routess)
                {
                    if (routess.Transport.Driver_ID == driv.ID_Drivers)
                    {
                        if (routess.RouteStatuses.RouteStatus != "Доставлен")
                        {
                            routesses.Add(routess);
                        }
                        else
                        {
                            routess.Orders.OrderStatus_ID = 3;
                        }
                    }
                }
                if(routesses.Count == 0)
                {
                    selected.Transport.Sostoyanie_ID = 3;
                }
                context.SaveChanges();
                MarshrutsDG.ItemsSource = routesses ?? new List<Routess>();
                StatusCB.SelectedItem = null;
            }
        }
    }
}