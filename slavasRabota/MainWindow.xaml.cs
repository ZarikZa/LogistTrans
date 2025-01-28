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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace slavasRabota
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LogisTransEntities1 context = new LogisTransEntities1();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool proverks = false;
            foreach (var item in context.Sotrudnikis)
            {
                if (item.Loginn == LognTbx.Text && item.Passwordd == ParolTbx.Text)
                {
                    proverks = true;
                    if (item.Roles.RoleName == "Логист")
                    {
                        LogistOkno logistOkno = new LogistOkno();
                        logistOkno.Show();
                        Close();
                    }
                    else if (item.Roles.RoleName == "Руководитель")
                    {
                        RukovoditelZakazi rukovoditelZakazi = new RukovoditelZakazi();
                        Close();
                        rukovoditelZakazi.Show();
                    }
                }
            }
            foreach (var item in context.Drivers)
            {
                if (item.Email == LognTbx.Text && item.PassWordd == ParolTbx.Text)
                {
                    proverks = true;
                    VoditeliOkno voditeliOkno = new VoditeliOkno(item);
                    voditeliOkno.Show();
                    Close();
                    break;
                }
            }
            if (proverks == false)
            {
                MessageBox.Show("Пользоватлеь не найден");
            }
        }
    }
}