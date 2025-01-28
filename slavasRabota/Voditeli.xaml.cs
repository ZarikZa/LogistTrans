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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace slavasRabota
{
    /// <summary>
    /// Логика взаимодействия для Voditeli.xaml
    /// </summary>
    public partial class Voditeli : Page
    {
        private LogisTransEntities1 context = new LogisTransEntities1 ();
        public Voditeli()
        {
            InitializeComponent();
            VoditeliDG.ItemsSource = context.Drivers.ToList ();
        }

        public static bool IsValidPassword(string password)
        {
            if (password.Length <= 6)
            {
                return false;
            }

            bool hasLower = password.Any(char.IsLower);
            bool hasUpper = password.Any(char.IsUpper);

            return hasLower && hasUpper;
        }

        private bool ProverkaDigit(string ves)
        {
            if (ves.Length != 12)
            {
                return false;
            }
            for (int i = 0; i < ves.Length; i++)
            {
                if (!char.IsDigit(ves[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = VoditeliDG.SelectedItem as Drivers;
            if (selected != null)
            {
                try
                {
                    context.Drivers.Remove(selected);
                    context.SaveChanges();
                    VoditeliDG.ItemsSource = context.Drivers.ToList();

                    VoditeliDG.SelectedItem = null;
                    LoginnTbx.Text = "";
                    PassworddTbx.Text = "";
                    DriverNameTbx.Text = "";
                    DriverSurnameTbx.Text = "";
                    DriverMiddleNameTbx.Text = "";
                    DriverLecenceTbx.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("Невозможно удалить");
                }
            }
            else
            {
                MessageBox.Show("Элемент для удаления не выбран");
            }
           
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = VoditeliDG.SelectedItem as Drivers;
            if (LoginnTbx.Text != "" && PassworddTbx.Text != "" && DriverNameTbx.Text != "" && DriverSurnameTbx.Text != "" && DriverLecenceTbx.Text != "")
            {
                if (ProverkaDigit(DriverLecenceTbx.Text.Trim()))
                {
                    if (IsValidPassword(PassworddTbx.Text.Trim()))
                    {
                        try
                        {
                            selected.DriverName = DriverNameTbx.Text.Trim();
                            selected.DriverSurname = DriverSurnameTbx.Text.Trim();
                            selected.DriverMiddleName = DriverMiddleNameTbx.Text.Trim();
                            selected.Email = LoginnTbx.Text.Trim();
                            selected.PassWordd = PassworddTbx.Text.Trim();
                            selected.DriverLecence = DriverLecenceTbx.Text.Trim();

                            context.SaveChanges();
                            VoditeliDG.ItemsSource = context.Drivers.ToList();

                            VoditeliDG.SelectedItem = null;
                            LoginnTbx.Text = "";
                            PassworddTbx.Text = "";
                            DriverNameTbx.Text = "";
                            DriverSurnameTbx.Text = "";
                            DriverMiddleNameTbx.Text = "";
                            DriverLecenceTbx.Text = "";
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Невозможно изменить");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен быть больше 6 сиволов и содержать заглавную и строчную букву ");
                    }
                }
                else
                {
                    MessageBox.Show("Лицензия должна состоять из цифр","И больше 12 символов");
                }
            }
            else
            {
                MessageBox.Show("Не все поля введены");
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            var driv = new Drivers();
            if (LoginnTbx.Text != "" && PassworddTbx.Text != "" && DriverNameTbx.Text != "" && DriverSurnameTbx.Text != "" && DriverLecenceTbx.Text != "")
            {
                if (ProverkaDigit(DriverLecenceTbx.Text.Trim()))
                {
                    if (IsValidPassword(PassworddTbx.Text.Trim()))
                    {
                        try
                        {
                            driv.DriverName = DriverNameTbx.Text.Trim();
                            driv.DriverSurname = DriverSurnameTbx.Text.Trim();
                            driv.DriverMiddleName = DriverMiddleNameTbx.Text.Trim();
                            driv.Email = LoginnTbx.Text.Trim();
                            driv.PassWordd = PassworddTbx.Text.Trim();
                            driv.DriverLecence = DriverLecenceTbx.Text.Trim();

                            context.Drivers.Add(driv);
                            context.SaveChanges();
                            VoditeliDG.ItemsSource = context.Drivers.ToList();

                            LoginnTbx.Text = "";
                            PassworddTbx.Text = "";
                            DriverNameTbx.Text = "";
                            DriverSurnameTbx.Text = "";
                            DriverMiddleNameTbx.Text = "";
                            DriverLecenceTbx.Text = "";
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Невозможно добавить");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен быть больше 6 сиволов и содержать заглавную и строчную букву ");
                    }
                }
                else
                {
                    MessageBox.Show("Лицензия должна состоять из цифр");
                }
            }
            else
            {
                MessageBox.Show("Не все поля введены");
            }
        }

        private void bnullBtm_Click(object sender, RoutedEventArgs e)
        {
            LoginnTbx.Text = "";
            PassworddTbx.Text = "";
            DriverNameTbx.Text = "";
            DriverSurnameTbx.Text = "";
            DriverMiddleNameTbx.Text = "";
            DriverLecenceTbx.Text = "";
            VoditeliDG.SelectedItem = null;
        }

        private void StorageDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = VoditeliDG.SelectedItem as Drivers;
            if (selected != null)
            {
                LoginnTbx.Text = selected.Email.ToString();
                PassworddTbx.Text = selected.PassWordd.ToString();
                DriverNameTbx.Text = selected.DriverName.ToString();
                DriverSurnameTbx.Text = selected.DriverSurname.ToString();
                DriverMiddleNameTbx.Text = selected.DriverMiddleName.ToString();
                DriverLecenceTbx.Text = selected.DriverLecence.ToString();
            }
        }
    }
}