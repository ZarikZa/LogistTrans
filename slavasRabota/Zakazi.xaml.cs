using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
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
using Spire.Pdf.Tables;
using System.Data.Entity;
using System.Threading;
using System.Data.Entity.SqlServer;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Controls.Primitives;
namespace slavasRabota
{
    /// <summary>
    /// Логика взаимодействия для Zakazi.xaml
    /// </summary>
    public partial class Zakazi : Page
    {
        private LogisTransEntities1 context = new LogisTransEntities1();
        public Zakazi()
        {
            InitializeComponent();
            List<Orders> orders = new List<Orders>();
            foreach (Orders order in context.Orders)
            {
                if (order.OrderStatuses.OrderStatus.ToString() != "Завершён")
                {
                    if (order.OrderStatuses.OrderStatus.ToString() != "Отменён")
                    {
                        orders.Add(order);
                    }
                }
            }
            Zakazs.ItemsSource = orders;
            ClientCB.ItemsSource = context.Clients.ToList();
            ClientCB.DisplayMemberPath = "CompanyName";
            OrderStatusCB.ItemsSource = context.OrderStatuses.ToList();
            OrderStatusCB.DisplayMemberPath = "OrderStatus";
            List<Storage> storages = new List<Storage>();
            foreach (var item in context.Storage)
            {
                if (item.DostupMesto != 0)
                {
                    storages.Add(item);
                }
            }
            StorageCB.ItemsSource = storages;
            StorageCB.DisplayMemberPath = "StorageLocation";

        }

        private bool ProverkaDigit(string ves)
        {
            return int.TryParse(ves, out _);
        }

        public static bool IsDateMultipleFormats(string dateString, string[] formats)
        {
            foreach (string format in formats)
            {
                if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsDecimal(string input)
        {
            return decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }

        public static bool IsDateNotLessThanToday(string dateString)
        {
            try
            {
                string dateFormat = "dd.MM.yyyy";
                if (DateTime.TryParseExact(dateString, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime inputDate))
                {
                    DateTime today = DateTime.Today;
                    return inputDate.Date >= today;
                }
                else
                {
                    return false; 
                }
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            if (ClientCB.SelectedItem != null && GruzNameTbx.Text != "" && GruzWeightTbx.Text != "" && DateDostavkiTbx.Text != "" && DateOtpravkiTbx.Text != "" && OrderStatusCB.SelectedItem != null && StorageCB.SelectedItem != null && SumOplatiTbx.Text != "")
            {
                if (ProverkaDigit(GruzWeightTbx.Text.Trim()))
                {
                    string[] formats = { "yyyy-MM-dd", "dd.MM.yyyy", "dd/MM/yyyy" };
                    if (IsDateMultipleFormats(DateDostavkiTbx.Text.Trim(), formats))
                    {
                        if (IsDateMultipleFormats(DateOtpravkiTbx.Text.Trim(), formats))
                        {
                            if (IsDecimal(SumOplatiTbx.Text))
                            {
                                if (IsDateNotLessThanToday(DateDostavkiTbx.Text.Trim()) && IsDateNotLessThanToday(DateOtpravkiTbx.Text.Trim()))
                                {

                                    orders.Clients = ClientCB.SelectedItem as Clients;
                                    orders.GruzName = GruzNameTbx.Text.Trim();
                                    orders.GruzWeight = Convert.ToInt32(GruzWeightTbx.Text.Trim());
                                    orders.DateOtpravki = DateOtpravkiTbx.Text.Trim();
                                    orders.DateDostavki = DateDostavkiTbx.Text.Trim();
                                    orders.OrderStatuses = OrderStatusCB.SelectedItem as OrderStatuses;
                                    orders.SumOplati = Convert.ToDecimal(SumOplatiTbx.Text.Trim());
                                    if ((StorageCB.SelectedItem as Storage).DostupMesto != 0)
                                    {
                                        orders.Storage = StorageCB.SelectedItem as Storage;
                                        orders.Storage.DostupMesto -= 1;
                                        orders.Storage.ColvoGruzInStorage += 1;
                                    }
                                    else
                                    {
                                        MessageBox.Show("На выбранном складе не осталось места, невозможно изменить");
                                    }
                                    context.Orders.Add(orders);
                                    context.SaveChanges();

                                    List<Orders> orderss = new List<Orders>();
                                    foreach (Orders order in context.Orders)
                                    {
                                        if (order.OrderStatuses.OrderStatus.ToString() != "Завершён")
                                        {
                                            if (order.OrderStatuses.OrderStatus.ToString() != "Отменён")
                                            {
                                                orderss.Add(order);
                                            }
                                        }
                                    }
                                    Zakazs.ItemsSource = orderss;

                                    ClientCB.SelectedItem = null;
                                    OrderStatusCB.SelectedItem = null;
                                    StorageCB.SelectedItem = null;
                                    DateDostavkiTbx.Text = "";
                                    DateOtpravkiTbx.Text = "";
                                    GruzNameTbx.Text = "";
                                    GruzWeightTbx.Text = "";
                                    SumOplatiTbx.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Дата должна быть не в прошлом");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Сумма оплати введена неверно");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Дата отправки введена неверно");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Дата доставки введена неверно");
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
            ClientCB.SelectedItem = null;
            List<Storage> storages = new List<Storage>();
            foreach (var item in context.Storage)
            {
                if (item.DostupMesto != 0)
                {
                    storages.Add(item);
                }
            }
            StorageCB.ItemsSource = storages;
            OrderStatusCB.SelectedItem = null;
            StorageCB.SelectedItem = null;
            DateDostavkiTbx.Text = "";
            DateOtpravkiTbx.Text = "";
            GruzNameTbx.Text = "";
            GruzWeightTbx.Text = "";
            Zakazs.SelectedItem = null;
            SumOplatiTbx.Text = "";

        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = Zakazs.SelectedItem as Orders;
            var forStorage = Zakazs.SelectedItem as Orders;
            if (selected != null)
            {
                if (ClientCB.SelectedItem != null && GruzNameTbx.Text != "" && GruzWeightTbx.Text != "" && DateDostavkiTbx.Text != "" && DateOtpravkiTbx.Text != "" && OrderStatusCB.SelectedItem != null && StorageCB.SelectedItem != null && SumOplatiTbx.Text != "")
                {
                    if (ProverkaDigit(GruzWeightTbx.Text.Trim()))
                    {
                        string[] formats = { "yyyy-MM-dd", "dd.MM.yyyy", "dd/MM/yyyy" };
                        if (IsDateMultipleFormats(DateDostavkiTbx.Text.Trim(), formats))
                        {
                            if (IsDateMultipleFormats(DateOtpravkiTbx.Text.Trim(), formats))
                            {
                                if (IsDecimal(SumOplatiTbx.Text))
                                {
                                    if (IsDateNotLessThanToday(DateDostavkiTbx.Text.Trim()) && IsDateNotLessThanToday(DateOtpravkiTbx.Text.Trim()))
                                    {
                                        selected.Clients = ClientCB.SelectedItem as Clients;
                                        selected.GruzName = GruzNameTbx.Text.Trim();
                                        selected.GruzWeight = Convert.ToInt32(GruzWeightTbx.Text.Trim());
                                        selected.DateOtpravki = DateOtpravkiTbx.Text.Trim();
                                        selected.DateDostavki = DateDostavkiTbx.Text.Trim();
                                        selected.OrderStatuses = OrderStatusCB.SelectedItem as OrderStatuses;
                                        if ((StorageCB.SelectedItem as Storage).DostupMesto != 0)
                                        {
                                            selected.Storage.DostupMesto += 1;
                                            selected.Storage.ColvoGruzInStorage -= 1;
                                            selected.Storage = StorageCB.SelectedItem as Storage;
                                            selected.Storage.DostupMesto -= 1;
                                            selected.Storage.ColvoGruzInStorage += 1;
                                        }
                                        else
                                        {
                                            MessageBox.Show("На выбранном складе не осталось места, невозможно изменить");
                                        }
                                        selected.SumOplati = Convert.ToDecimal(SumOplatiTbx.Text.Trim());

                                        context.SaveChanges();
                                        List<Orders> orders = new List<Orders>();
                                        foreach (Orders order in context.Orders)
                                        {
                                            if (order.OrderStatuses.OrderStatus.ToString() != "Завершён")
                                            {
                                                if (order.OrderStatuses.OrderStatus.ToString() != "Отменён")
                                                {
                                                    orders.Add(order);
                                                }
                                            }
                                        }
                                        Zakazs.ItemsSource = orders;
                                        List<Storage> storages = new List<Storage>();
                                        foreach (var item in context.Storage)
                                        {
                                            if (item.DostupMesto != 0)
                                            {
                                                storages.Add(item);
                                            }
                                        }
                                        StorageCB.ItemsSource = storages;
                                        ClientCB.SelectedItem = null;
                                        OrderStatusCB.SelectedItem = null;
                                        StorageCB.SelectedItem = null;
                                        DateDostavkiTbx.Text = "";
                                        DateOtpravkiTbx.Text = "";
                                        GruzNameTbx.Text = "";
                                        GruzWeightTbx.Text = "";
                                        SumOplatiTbx.Text = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("Дата должна быть не в прошлом");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Сумма оплати введена неверно");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Дата отправки введена неверно");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Дата доставки введена неверно");
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

        private void Zakazs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = Zakazs.SelectedItem as Orders;
            var clients = context.Clients.ToList();
            var ststus = context.OrderStatuses.ToList();
            var sclad = context.Storage.ToList();
            if (selected != null)
            {
                DateDostavkiTbx.Text = selected.DateDostavki.ToString();
                DateOtpravkiTbx.Text = selected.DateOtpravki.ToString();
                GruzNameTbx.Text = selected.GruzName.ToString();
                GruzWeightTbx.Text = selected.GruzWeight.ToString();
                SumOplatiTbx.Text = selected.SumOplati.ToString();
                foreach (var client in clients)
                {
                    if (client.ID_Client == selected.Client_ID)
                    {
                        ClientCB.SelectedItem = client;
                    }
                }
                foreach (var item in ststus)
                {
                    if (item.ID_OrderStatus == selected.OrderStatus_ID)
                    {
                        OrderStatusCB.SelectedItem = item;
                    }
                }
                foreach (var item in sclad)
                {
                    if (item.ID_Storage == selected.Storage_ID)
                    {
                        List<Storage> orrd = new List<Storage>
                        {
                            selected.Storage
                        };
                        StorageCB.ItemsSource = orrd;
                        StorageCB.SelectedItem = item;
                    }
                }
            }
        }

        private void OtchetBtm_Click(object sender, RoutedEventArgs e)
        {
            if (context.Orders.Count() != 0)
            {
                TxtForm();
            }
        }

        private void TxtForm()
        {
            string txtFilePath2 = System.IO.Path.Combine("output_1.txt");
            string pdfFilePath2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Общая загрузка заказов.pdf");
            using (FileStream fs = new FileStream(txtFilePath2, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                string header = "Общая загрузка Заказов";
                int lineWidth = 70;

                string CenterString(string text, int width)
                {
                    if (text.Length >= width) return text;
                    int padding = (width - text.Length) / 2;
                    return new string(' ', padding) + text;
                }
                writer.WriteLine(CenterString(header, lineWidth));
                writer.WriteLine(new string('-', lineWidth));

                var OrdersData = context.Orders
                    .Select(w => new
                    {
                        w.GruzName,
                        w.GruzWeight,
                        w.DateOtpravki,
                        w.DateDostavki,
                        ClientName = w.Clients.ClientName,
                        ClientSurname = w.Clients.ClientSurname,
                        ClientMiddleName = w.Clients.ClientMiddleName,
                        CompanyName = w.Clients.CompanyName,
                        PhoneNumber = w.Clients.PhoneNumber,
                        StorageLocation = w.Storage.StorageLocation,
                        OrderStatus = w.OrderStatuses.OrderStatus,
                        w.SumOplati,
                    }).ToList();

                decimal sumOplat = 0;
                foreach (var order in OrdersData)
                {
                    string FullName = $"{order.ClientName} {order.ClientSurname} {order.ClientMiddleName}";
                    writer.WriteLine($"{"ФИО:",-10} {FullName}");
                    writer.WriteLine($"{"Компания:",-10} {order.CompanyName}");
                    writer.WriteLine($"{"Контакт:",-10} {order.PhoneNumber}");
                    writer.WriteLine($"{"Адрес склада:",-10} {order.StorageLocation}");
                    writer.WriteLine($"{"Груз:",-10} {order.GruzName}");
                    writer.WriteLine($"{"Вес груза:",-10} {order.GruzWeight}");
                    writer.WriteLine($"{"Дата отправки:",-10} {order.DateOtpravki}");
                    writer.WriteLine($"{"Дата доставки:",-10} {order.DateDostavki}");
                    writer.WriteLine($"{"Статус заказа:",-10} {order.OrderStatus}");
                    writer.WriteLine($"{"Выручка за заказ:",-10} {order.SumOplati}");
                    writer.WriteLine(new string('-', lineWidth));
                    sumOplat += Convert.ToDecimal(order.SumOplati);
                }
                writer.WriteLine($"{"Общая выручка:",-10} {sumOplat}");
            }

            ConvertTxtToPdf(txtFilePath2, pdfFilePath2);
            File.Delete(txtFilePath2);
        }

        public static void ConvertTxtToPdf(string txtFilePath, string pdfFilePath)
        {
            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    PdfPageBase page = document.Pages.Add();
                    Font fontt = new Font("Times New Roman", 12f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
                    PdfTrueTypeFont font = new PdfTrueTypeFont(fontt, 12f, true);
                    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top);
                    string[] lines = File.ReadAllLines(txtFilePath, Encoding.UTF8);
                    float y = 20, lineHeight = font.MeasureString("A").Height + 2;
                    foreach (string line in lines)
                    {
                        page.Canvas.DrawString(line, font, PdfBrushes.Black, new PointF(20, y), format);
                        y += lineHeight;
                    }
                    document.SaveToFile(pdfFilePath);
                    MessageBox.Show($"PDF файл успешно создан: {pdfFilePath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании PDF: {ex.Message}");
            }
        }

    }
}