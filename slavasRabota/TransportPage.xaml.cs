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
    /// Логика взаимодействия для TransportPage.xaml
    /// </summary>
    public partial class TransportPage : Page
    {
        private LogisTransEntities1 context = new LogisTransEntities1();

        public TransportPage()
        {
            InitializeComponent();
            TransportDG.ItemsSource = context.Transport.ToList();
            SostoyanieCB.ItemsSource = context.TransportSostoyanie.ToList();
            SostoyanieCB.DisplayMemberPath = "SostoyanieTransport";
            VoditelCB.ItemsSource = context.Drivers.ToList();
            VoditelCB.DisplayMemberPath = "DriverName";
        }

        private bool ProverkaDigit(string ves)
        {
            return int.TryParse(ves, out _);
        }

        public static bool HasLengthInRange(string input, int minLength, int maxLength)
        {
            if (input == null)
            {
                return false;
            }
            int length = input.Length;
            return length >= minLength && length <= maxLength;
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            Transport trans = new Transport();
            if (VoditelCB.SelectedItem != null && CarNomberTbx.Text != "" && VmestimostTbx.Text != "" &&  SostoyanieCB.SelectedItem != null)
            {
                if (ProverkaDigit(VmestimostTbx.Text.Trim()))
                {
                    if (HasLengthInRange(CarNomberTbx.Text.Trim(), 9, 9))
                    {
                        try
                        {
                            trans.CarNomber = CarNomberTbx.Text.Trim();
                            trans.Drivers = VoditelCB.SelectedItem as Drivers;
                            trans.Vmestimost = Convert.ToInt32(VmestimostTbx.Text.Trim());
                            trans.TransportSostoyanie = SostoyanieCB.SelectedItem as TransportSostoyanie;

                            context.Transport.Add(trans);
                            context.SaveChanges();
                            TransportDG.ItemsSource = context.Transport.ToList();

                            SostoyanieCB.SelectedItem = null;
                            VoditelCB.SelectedItem = null;
                            CarNomberTbx.Text = "";
                            VmestimostTbx.Text = "";
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Невозможно добавить");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Номер машины введён не верно");
                    }
                }
                else
                {
                    MessageBox.Show("Вес должен быть числом");
                }
            }
            else
            {
                MessageBox.Show("Не все поля введены");
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = TransportDG.SelectedItem as Transport;
            if (VoditelCB.SelectedItem != null && CarNomberTbx.Text != "" && VmestimostTbx.Text != "" && SostoyanieCB.SelectedItem != null)
            {
                if (ProverkaDigit(VmestimostTbx.Text.Trim()))
                {
                    if (HasLengthInRange(CarNomberTbx.Text.Trim(), 9, 9))
                    {
                        try
                        {
                            selected.CarNomber = CarNomberTbx.Text.Trim();
                            selected.Drivers = VoditelCB.SelectedItem as Drivers;
                            selected.Vmestimost = Convert.ToInt32(VmestimostTbx.Text.Trim());
                            selected.TransportSostoyanie = SostoyanieCB.SelectedItem as TransportSostoyanie;

                            context.SaveChanges();
                            TransportDG.ItemsSource = context.Transport.ToList();

                            SostoyanieCB.SelectedItem = null;
                            VoditelCB.SelectedItem = null;
                            CarNomberTbx.Text = "";
                            VmestimostTbx.Text = "";
                            TransportDG.SelectedItem = null;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Невозможно изменить");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Номер машины введён не верно");
                    }
                }
                else
                {
                    MessageBox.Show("Вес должен быть числом");
                }
            }
            else
            {
                MessageBox.Show("Не все поля введены");
            }
        }

        private void bnullBtm_Click(object sender, RoutedEventArgs e)
        {
            SostoyanieCB.SelectedItem = null;
            VoditelCB.SelectedItem = null;
            CarNomberTbx.Text = "";
            VmestimostTbx.Text = "";
            TransportDG.SelectedItem = null;
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = TransportDG.SelectedItem as Transport;
            if (selected != null)
            {
                try
                {
                    context.Transport.Remove(selected);
                    context.SaveChanges();
                    TransportDG.ItemsSource = context.Transport.ToList();
                   
                    SostoyanieCB.SelectedItem = null;
                    VoditelCB.SelectedItem = null;
                    CarNomberTbx.Text = "";
                    VmestimostTbx.Text = "";
                    TransportDG.SelectedItem = null;
                }
                catch (Exception)
                {
                    MessageBox.Show("Невозможно удалить");
                }
            }
        }

        private void TransportDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = TransportDG.SelectedItem as Transport;
            var voditel = context.Drivers.ToList();
            var ststus = context.TransportSostoyanie.ToList();
            if (selected != null)
            {
                CarNomberTbx.Text = selected.CarNomber.ToString();
                VmestimostTbx.Text = selected.Vmestimost.ToString();
                foreach (var vodil in voditel)
                {
                    if (vodil.ID_Drivers == selected.Driver_ID)
                    {
                        VoditelCB.SelectedItem = vodil;
                    }
                }
                foreach (var item in ststus)
                {
                    if (item.ID_TransportSostoyanie == selected.Sostoyanie_ID)
                    {
                        SostoyanieCB.SelectedItem = item;
                    }
                }
            }
        }
    }
}