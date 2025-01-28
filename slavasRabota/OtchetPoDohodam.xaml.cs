using Spire.Pdf.Graphics;
using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;

namespace slavasRabota
{
    /// <summary>
    /// Логика взаимодействия для OtchetPoDohodam.xaml
    /// </summary>
    public partial class OtchetPoDohodam : Page
    {
        private LogisTransEntities1 context = new LogisTransEntities1();

        public OtchetPoDohodam()
        {
            InitializeComponent();
            Zakazs.ItemsSource = context.Orders.ToList();
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

        private void OtchetBtm_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DateCTbx.Text) && !string.IsNullOrWhiteSpace(DatePOTbx.Text))
            {
                if (context.Orders.Any())
                {
                    if(IsDateNotLessThanToday(DateCTbx.Text) && IsDateNotLessThanToday(DatePOTbx.Text))
                    {
                        if (DateTime.TryParseExact(DateCTbx.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate) &&
                            DateTime.TryParseExact(DatePOTbx.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
                        {
                            TxtForm(startDate, endDate);
                        }
                        else
                        {
                            MessageBox.Show("Неверный формат даты. Используйте формат ДД.ММ.ГГГГ.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Дата должна быть не в прошлом");
                    }
                }
                else
                {
                    MessageBox.Show("Нет данных для отчёта");
                }
            }
            else
            {
                MessageBox.Show("Заполните даты");
            }

        }

        private void TxtForm(DateTime S, DateTime PO)
        {
            string txtFilePath = System.IO.Path.Combine("output_1.txt");
            string pdfFilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Общая загрузка заказов за период.pdf");

            using (FileStream fs = new FileStream(txtFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                string header = $"Загрузка заказов за период {S} - {PO}";
                int lineWidth = 70;

                string CenterString(string text, int width)
                {
                    if (text.Length >= width) return text;
                    int padding = (width - text.Length) / 2;
                    return new string(' ', padding) + text;
                }
                writer.WriteLine(CenterString(header, lineWidth));
                writer.WriteLine(new string('-', lineWidth));

                List<Orders> orders = context.Orders.ToList();
                List<OrderData> filteredOrders = new List<OrderData>();
                decimal sumOplat = 0;

                foreach (var order in orders)
                {
                    DateTime? itemDate = null;
                    if (DateTime.TryParseExact(order.DateDostavki, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                    {
                        itemDate = parsedDate.Date;
                    }

                    if (itemDate.HasValue && itemDate >= S && itemDate <= PO)
                    {
                        OrderData orderData = new OrderData
                        {
                            GruzName = order.GruzName,
                            GruzWeight = order.GruzWeight,
                            DateDostavki = order.DateDostavki != null ? DateTime.Parse(order.DateDostavki) : (DateTime?)null,
                            ClientName = order.Clients.ClientName,
                            ClientSurname = order.Clients.ClientSurname,
                            ClientMiddleName = order.Clients.ClientMiddleName,
                            CompanyName = order.Clients.CompanyName,
                            PhoneNumber = order.Clients.PhoneNumber,
                            StorageLocation = order.Storage.StorageLocation,
                            OrderStatus = order.OrderStatuses.OrderStatus,
                            SumOplati = order.SumOplati,
                        };
                        filteredOrders.Add(orderData);
                    }
                }

                foreach (var order in filteredOrders)
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
                    sumOplat += order.SumOplati.HasValue ? order.SumOplati.Value : 0;
                }
                writer.WriteLine($"{"Общая выручка:",-10} {sumOplat}");
            }
            ConvertTxtToPdf(txtFilePath, pdfFilePath);
            File.Delete(txtFilePath);
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

    public class OrderData
    {
        public string GruzName { get; set; }
        public decimal? GruzWeight { get; set; }
        public DateTime? DateOtpravki { get; set; }
        public DateTime? DateDostavki { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientMiddleName { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string StorageLocation { get; set; }
        public string OrderStatus { get; set; }
        public decimal? SumOplati { get; set; }
    }
}