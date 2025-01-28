using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Xml.Linq;
using ClosedXML.Excel;
using System.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using Spire.Pdf.Graphics;
using Spire.Pdf;
namespace slavasRabota
{
    /// <summary>
    /// Логика взаимодействия для Otchet.xaml
    /// </summary>
    public partial class Otchet : Page
    {
        private LogisTransEntities1 context = new LogisTransEntities1 ();
        public Otchet()
        {
            InitializeComponent();
            MarshrutsDG.ItemsSource = context.Routess.ToList ();
        }

        private void OtchetBtm_Click(object sender, RoutedEventArgs e)
        {
            if (MarshrutsDG.SelectedItem is Routess selectedItem)
            {
                GenerateRouteList(selectedItem);
                GeneratePdfReceipt(selectedItem);
            }
        }

        private void GenerateRouteList(Routess selectedItem)
        {
            try
            {

                var routeData = new[]
                {
                new
                {
                    Маршрут_ID = selectedItem.ID_Route,
                    Заказ_ID = selectedItem.Orders.ID_Order,
                    Имя_Клиента = selectedItem.Orders.Clients.ClientName,
                    Телефон_Клиента = selectedItem.Orders.Clients.PhoneNumber,
                    Отправление = selectedItem.Otpravlenie,
                    Доставка = selectedItem.Dostavka,
                    Протяженность = selectedItem.Protyajonnost,
                    Транспорт = selectedItem.Transport?.CarNomber,
                    Имя_Водителя = selectedItem.Transport?.Drivers?.DriverName,
                    Лицензия_Водителя = selectedItem.Transport?.Drivers?.DriverLecence,
                    Статус_Маршрута = selectedItem.RouteStatuses?.RouteStatus
                   }
                };

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = $"{desktopPath}\\Маршрутный_лист{selectedItem.ID_Route}.xlsx"; 


                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Маршруты");
                    worksheet.Cell(1, 1).InsertTable(routeData.AsEnumerable());
                    workbook.SaveAs(filePath);
                }
                MessageBox.Show($"Маршрутный лист сохранен на рабочий стол: {filePath}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при генерации маршрутного листа: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void GeneratePdfReceipt(Routess selectedItem)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = $"{desktopPath}\\Квитанция_{selectedItem.ID_Route}.pdf";

                using (PdfDocument document = new PdfDocument())
                {
                    PdfPageBase page = document.Pages.Add();
                    float y = 20;
                    PdfBrush brush = PdfBrushes.Black;
                    System.Drawing.Font fontt = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
                    PdfTrueTypeFont font = new PdfTrueTypeFont(fontt, 12f, true);
                    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top);
                    page.Canvas.DrawString("Квитанция о доставке", font, brush, new PointF(page.Canvas.ClientSize.Width / 2, y), format);
                    y += 40;

                    var properties = new List<(string PropertyName, object Value)>()
                   {
                    ("Маршрут ID", selectedItem.ID_Route),
                    ("Заказ ID", selectedItem.Orders?.ID_Order),
                    ("Имя Клиента", selectedItem.Orders?.Clients?.ClientName),
                    ("Телефон Клиента", selectedItem.Orders?.Clients?.PhoneNumber),
                    ("Отправление", selectedItem.Otpravlenie),
                    ("Доставка", selectedItem.Dostavka),
                    ("Протяженность", selectedItem.Protyajonnost),
                     ("Транспорт", selectedItem.Transport?.CarNomber),
                     ("Имя Водителя", selectedItem.Transport?.Drivers?.DriverName),
                    ("Лицензия Водителя", selectedItem.Transport?.Drivers?.DriverLecence),
                   ("Статус Маршрута", selectedItem.RouteStatuses?.RouteStatus)
                    };

                    foreach (var property in properties)
                    {
                        page.Canvas.DrawString($"{property.PropertyName}: {property.Value}", font, brush, new PointF(20, y));
                        y += 20;
                    }

                    document.SaveToFile(filePath);
                }
                MessageBox.Show($"Квитанция сохранена на рабочий стол: {filePath}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при генерации квитанции: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}