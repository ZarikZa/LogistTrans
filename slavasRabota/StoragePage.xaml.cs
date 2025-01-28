using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace slavasRabota
{
    /// <summary>
    /// Логика взаимодействия для StoragePage.xaml
    /// </summary>
    public partial class StoragePage : Page
    {
        private LogisTransEntities1 context = new LogisTransEntities1 ();
        public StoragePage()
        {
            InitializeComponent();
            StorageDG.ItemsSource = context.Storage.ToList();
        }

        private bool ProverkaDigit(string ves)
        {
            return int.TryParse(ves, out _);
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            var store = new Storage();
            if (ColvoGruzInStorageTbx.Text != "" && DostupMestoTbx.Text != "" && StorageLocationTbx.Text != "")
            {
                if (ProverkaDigit(DostupMestoTbx.Text.Trim()))
                {
                    if (ProverkaDigit(ColvoGruzInStorageTbx.Text.Trim()))
                    {
                        try
                        {
                            store.DostupMesto = Convert.ToInt32(DostupMestoTbx.Text.Trim());
                            store.ColvoGruzInStorage = Convert.ToInt32(ColvoGruzInStorageTbx.Text.Trim());
                            store.StorageLocation = StorageLocationTbx.Text.Trim();

                            context.Storage.Add(store);
                            context.SaveChanges();
                            StorageDG.ItemsSource = context.Storage.ToList();

                            ColvoGruzInStorageTbx.Text = "";
                            DostupMestoTbx.Text = "";
                            StorageLocationTbx.Text = "";
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Невозможно добавить");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Количество груза на скледе должноо быть числом");
                    }
                }
                else
                {
                    MessageBox.Show("Доступное место должено быть числом");
                }
            }
            else
            {
                MessageBox.Show("Не все поля введены");
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = StorageDG.SelectedItem as Storage;
            if(selected != null)
            {
                if (ColvoGruzInStorageTbx.Text != "" && DostupMestoTbx.Text != "" && StorageLocationTbx.Text != "")
                {
                    if (ProverkaDigit(DostupMestoTbx.Text.Trim()))
                    {
                        if (ProverkaDigit(ColvoGruzInStorageTbx.Text.Trim()))
                        {
                            try
                            {
                                selected.DostupMesto = Convert.ToInt32(DostupMestoTbx.Text.Trim());
                                selected.ColvoGruzInStorage = Convert.ToInt32(ColvoGruzInStorageTbx.Text.Trim());
                                selected.StorageLocation = StorageLocationTbx.Text.Trim();

                                context.SaveChanges();
                                StorageDG.ItemsSource = context.Storage.ToList();

                                StorageDG.SelectedItem = null;
                                ColvoGruzInStorageTbx.Text = "";
                                DostupMestoTbx.Text = "";
                                StorageLocationTbx.Text = "";
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
            else
            {
                MessageBox.Show("Не выбран элемнет для изменения");
            }
        }

        private void bnullBtm_Click(object sender, RoutedEventArgs e)
        {
            StorageDG.SelectedItem = null;
            ColvoGruzInStorageTbx.Text = "";
            DostupMestoTbx.Text = "";
            StorageLocationTbx.Text = "";
        }

        private void StorageDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = StorageDG.SelectedItem as Storage;
            if (selected != null)
            {
                DostupMestoTbx.Text = selected.DostupMesto.ToString();
                ColvoGruzInStorageTbx.Text = selected.ColvoGruzInStorage.ToString();
                StorageLocationTbx.Text = selected.StorageLocation.ToString();
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = StorageDG.SelectedItem as Storage;
            if (selected != null)
            {
                try
                {
                    context.Storage.Remove(selected);
                    context.SaveChanges();
                    StorageDG.ItemsSource = context.Storage.ToList();

                    StorageDG.SelectedItem = null;
                    ColvoGruzInStorageTbx.Text = "";
                    DostupMestoTbx.Text = "";
                    StorageLocationTbx.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("Невозможно удалить");
                }
            }
        }
    }
}