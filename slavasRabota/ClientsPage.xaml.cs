using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
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
using static MaterialDesignThemes.Wpf.Theme;
using Spire.Additions.Html;

namespace slavasRabota
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private LogisTransEntities1 context = new LogisTransEntities1();

        public ClientsPage()
        {
            InitializeComponent();
            ClientsDG.ItemsSource = context.Clients.ToList();
        }

        private bool ProverkaDigit(string ves)
        {
            for (int i = 0; i < ves.Length; i++)
            {
                if (!char.IsDigit(ves[i]))
                {
                    return false;
                }
            }
            return true;
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

        public static bool IsValidEmailRegex(string email)
        {
            string emailRegex = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, emailRegex);
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            Clients clien = new Clients();
            if (ClientNameTbx.Text != "" && ClientSurnameTbx.Text != "" && CompanyNameTbx.Text != "" && PhoneNumberTbx.Text != "" && INNTbx.Text != "" && EmailTbx.Text != "")
            {
                if (ProverkaDigit(INNTbx.Text.Trim()))
                {
                    if (HasLengthInRange(INNTbx.Text.Trim(), 12, 12))
                    {
                        if (IsValidPhoneNumberManual(PhoneNumberTbx.Text.Trim()))
                        {
                            if (IsValidEmailRegex(EmailTbx.Text))
                            {
                                clien.ClientSurname = ClientSurnameTbx.Text.Trim();
                                clien.ClientName = ClientNameTbx.Text.Trim();
                                clien.ClientMiddleName = ClientMiddleNameTbx.Text.Trim();
                                clien.CompanyName = CompanyNameTbx.Text.Trim();
                                clien.INN = INNTbx.Text.Trim();
                                clien.PhoneNumber = PhoneNumberTbx.Text.Trim();
                                clien.Email = EmailTbx.Text.Trim();

                                context.Clients.Add(clien);
                                context.SaveChanges();
                                ClientsDG.ItemsSource = context.Clients.ToList();

                                ClientMiddleNameTbx.Text = "";
                                ClientNameTbx.Text = "";
                                ClientSurnameTbx.Text = "";
                                CompanyNameTbx.Text = "";
                                INNTbx.Text = "";
                                PhoneNumberTbx.Text = "";
                                EmailTbx.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Почта введена не верно введён неверно");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Номер телефона введён неверно");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ИНН должен быть 12 символов");
                    }
                }
                else
                {
                    MessageBox.Show("ИНН должен состоять из чисел");
                }
            }
            else
            {
                MessageBox.Show("Не все поля введены");
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = ClientsDG.SelectedItem as Clients;
            if (ClientNameTbx.Text != "" && ClientSurnameTbx.Text != "" && CompanyNameTbx.Text != "" && PhoneNumberTbx.Text != "" && INNTbx.Text != "")
            {
                if (ProverkaDigit(INNTbx.Text.Trim()))
                {
                    if (HasLengthInRange(INNTbx.Text.Trim(), 12, 12))
                    {
                        if (IsValidPhoneNumberManual(PhoneNumberTbx.Text.Trim()))
                        {
                            if (IsValidEmailRegex(EmailTbx.Text))
                            {
                                selected.ClientSurname = ClientSurnameTbx.Text.Trim();
                                selected.ClientName = ClientNameTbx.Text.Trim();
                                selected.ClientMiddleName = ClientMiddleNameTbx.Text.Trim();
                                selected.CompanyName = CompanyNameTbx.Text.Trim();
                                selected.INN = INNTbx.Text.Trim();
                                selected.PhoneNumber = PhoneNumberTbx.Text.Trim();
                                selected.Email = EmailTbx.Text.Trim();
                                context.SaveChanges();
                                ClientsDG.ItemsSource = context.Clients.ToList();

                                ClientMiddleNameTbx.Text = "";
                                ClientNameTbx.Text = "";
                                ClientSurnameTbx.Text = "";
                                CompanyNameTbx.Text = "";
                                INNTbx.Text = "";
                                PhoneNumberTbx.Text = "";
                                EmailTbx.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Почта введена не верно введён неверно");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Номер телефона введён неверно");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ИНН должен быть 12 символов");
                    }
                }
                else
                {
                    MessageBox.Show("ИНН должен состоять из чисел");
                }
            }
            else
            {
                MessageBox.Show("Не все поля введены");
            }
        }

        private void DeleteBtm_Click(object sender, RoutedEventArgs e)
        {
            Clients selected = ClientsDG.SelectedItem as Clients;
            if (selected != null)
            {
                try
                {
                    context.Clients.Remove(selected);
                    context.SaveChanges();
                    ClientsDG.ItemsSource = context.Clients.ToList();

                    ClientMiddleNameTbx.Text = "";
                    ClientNameTbx.Text = "";
                    ClientSurnameTbx.Text = "";
                    CompanyNameTbx.Text = "";
                    INNTbx.Text = "";
                    PhoneNumberTbx.Text = "";
                    EmailTbx.Text = "";
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
            ClientMiddleNameTbx.Text = "";
            ClientNameTbx.Text = "";
            ClientSurnameTbx.Text = "";
            CompanyNameTbx.Text = "";
            INNTbx.Text = "";
            PhoneNumberTbx.Text = "";
            ClientsDG.SelectedItem = null;
            EmailTbx.Text = "";
        }

        private void TransportDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ClientsDG.SelectedItem as Clients;
            if (selected != null)
            {
                ClientMiddleNameTbx.Text = selected.ClientMiddleName.ToString();
                ClientNameTbx.Text = selected.ClientName.ToString();
                ClientSurnameTbx.Text = selected.ClientSurname.ToString();
                CompanyNameTbx.Text = selected.CompanyName.ToString();
                INNTbx.Text = selected.INN.ToString();
                PhoneNumberTbx.Text = selected.PhoneNumber.ToString();
                EmailTbx.Text = selected.Email.ToString();
            }
        }

        
    }
}
