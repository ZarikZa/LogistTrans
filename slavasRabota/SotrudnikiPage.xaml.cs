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
    /// Логика взаимодействия для SotrudnikiPage.xaml
    /// </summary>
    public partial class SotrudnikiPage : Page
    {
        private LogisTransEntities1 context = new LogisTransEntities1();
        public SotrudnikiPage()
        {
            InitializeComponent();
            SotrudniksDG.ItemsSource = context.Sotrudnikis.ToList();
            RoleCB.ItemsSource = context.Roles.ToList();
            RoleCB.DisplayMemberPath = "RoleName";
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

        public static bool IsValidPhoneNumberManual(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            if (!phoneNumber.StartsWith("+7"))
            {
                return false;
            }

            if (phoneNumber.Length != 12)
            {
                return false;
            }

            for (int i = 2; i < phoneNumber.Length; i++)
            {
                if (!char.IsDigit(phoneNumber[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            var sptrud = new Sotrudnikis();
            if (LoginnTbx.Text != "" && PassworddTbx.Text != "" && PhoneNumberTbx.Text != "" && SotrudnikNameTbx.Text != "" && SotrudnikSurnameTbx.Text != "" && RoleCB.SelectedItem != null)
            {
                if (IsValidPhoneNumberManual(PhoneNumberTbx.Text.Trim()))
                {
                    if (IsValidPassword(PassworddTbx.Text.Trim()))
                    {
                        try
                        {
                            sptrud.SotrudnikName = SotrudnikNameTbx.Text.Trim();
                            sptrud.SotrudnikSurname = SotrudnikSurnameTbx.Text.Trim();
                            sptrud.SotrudnikMiddleName = SotrudnikMiddleNameTbx.Text.Trim();
                            sptrud.Loginn = LoginnTbx.Text.Trim();
                            sptrud.Passwordd = PassworddTbx.Text.Trim();
                            sptrud.PhoneNumber = PhoneNumberTbx.Text.Trim();
                            sptrud.Roles = RoleCB.SelectedItem as Roles;

                            context.Sotrudnikis.Add(sptrud);
                            context.SaveChanges();
                            SotrudniksDG.ItemsSource = context.Sotrudnikis.ToList();

                            LoginnTbx.Text = "";
                            PassworddTbx.Text = "";
                            PhoneNumberTbx.Text = "";
                            SotrudnikMiddleNameTbx.Text = "";
                            SotrudnikNameTbx.Text = "";
                            SotrudnikSurnameTbx.Text = "";
                            RoleCB.SelectedItem = null;
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
                    MessageBox.Show("Неверно введён номер телефона");
                }
            }
            else
            {
                MessageBox.Show("Не все поля введены");
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = SotrudniksDG.SelectedItem as Sotrudnikis;
            if (LoginnTbx.Text != "" && PassworddTbx.Text != "" && PhoneNumberTbx.Text != "" && SotrudnikNameTbx.Text != "" && SotrudnikSurnameTbx.Text != "" && RoleCB.SelectedItem != null)
            {
                if (IsValidPhoneNumberManual(PhoneNumberTbx.Text.Trim()))
                {
                    if (IsValidPassword(PassworddTbx.Text.Trim()))
                    {
                        try
                        {
                            selected.SotrudnikName = SotrudnikNameTbx.Text.Trim();
                            selected.SotrudnikSurname = SotrudnikSurnameTbx.Text.Trim();
                            selected.SotrudnikMiddleName = SotrudnikMiddleNameTbx.Text.Trim();
                            selected.Loginn = LoginnTbx.Text.Trim();
                            selected.Passwordd = PassworddTbx.Text.Trim();
                            selected.PhoneNumber = PhoneNumberTbx.Text.Trim();
                            selected.Roles = RoleCB.SelectedItem as Roles;

                            context.SaveChanges();
                            SotrudniksDG.ItemsSource = context.Sotrudnikis.ToList();

                            LoginnTbx.Text = "";
                            PassworddTbx.Text = "";
                            PhoneNumberTbx.Text = "";
                            SotrudnikMiddleNameTbx.Text = "";
                            SotrudnikNameTbx.Text = "";
                            SotrudnikSurnameTbx.Text = "";
                            RoleCB.SelectedItem = null;

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
                    MessageBox.Show("Неверно введён номер телефона");
                }
            }
            else
            {
                MessageBox.Show("Не все поля введены");
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = SotrudniksDG.SelectedItem as Sotrudnikis;
            if (selected != null)
            {
                try
                {
                    context.Sotrudnikis.Remove(selected);
                    context.SaveChanges();
                    SotrudniksDG.ItemsSource = context.Sotrudnikis.ToList();

                    LoginnTbx.Text = "";
                    PassworddTbx.Text = "";
                    PhoneNumberTbx.Text = "";
                    SotrudnikMiddleNameTbx.Text = "";
                    SotrudnikNameTbx.Text = "";
                    SotrudnikSurnameTbx.Text = "";
                    RoleCB.SelectedItem = null;
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

        private void bnullBtm_Click(object sender, RoutedEventArgs e)
        {
            SotrudniksDG.SelectedItem = null;
            LoginnTbx.Text = "";
            PassworddTbx.Text = "";
            PhoneNumberTbx.Text = "";
            SotrudnikMiddleNameTbx.Text = "";
            SotrudnikNameTbx.Text = "";
            SotrudnikSurnameTbx.Text = "";
            RoleCB.SelectedItem = null;
        }

        private void StorageDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = SotrudniksDG.SelectedItem as Sotrudnikis;
            var roles = context.Roles.ToList();
            if (selected != null)
            {
                LoginnTbx.Text = selected.Loginn.ToString();
                PassworddTbx.Text = selected.Passwordd.ToString();
                PhoneNumberTbx.Text = selected.PhoneNumber.ToString();
                SotrudnikMiddleNameTbx.Text = selected.SotrudnikMiddleName.ToString();
                SotrudnikNameTbx.Text = selected.SotrudnikName.ToString();
                SotrudnikSurnameTbx.Text = selected.SotrudnikName.ToString();
                foreach (var item in roles)
                {
                    if (item.ID_Role == selected.Role_ID)
                    {
                        RoleCB.SelectedItem = item;
                    }
                }
            }
        }
    }
}
