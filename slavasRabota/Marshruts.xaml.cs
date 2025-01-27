using Spire.Pdf.Graphics;
using Spire.Pdf;
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
using Spire.Additions.Xps.Schema;
using static MaterialDesignThemes.Wpf.Theme;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Xml.Linq;
using System.Windows.Controls.Primitives;

namespace slavasRabota
{
    /// <summary>
    /// Логика взаимодействия для Marshruts.xaml
    /// </summary>
    public partial class Marshruts : Page
    {
        private LogisTransEntities1 context = new LogisTransEntities1();
        private const string FromEmail = "awesome.logis@yandex.ru";
        private const string FromPassword = "guyawwnulpvajvor";

        public Marshruts()
        {
            InitializeComponent();
            List<Routess> routesses = new List<Routess>();
            foreach (Routess routess in context.Routess)
            {
                if(routess.RouteStatuses.RouteStatus != "Доставлен")
                {
                    routesses.Add(routess);
                }
            }
            MarshrutsDG.ItemsSource = routesses;
            List<Orders> orderss = new List<Orders>();
            foreach (Orders orders in context.Orders)
            {
                if(orders.OrderStatuses.OrderStatus != "Завершён")
                {
                    if (orders.OrderStatuses.OrderStatus != "Отменён")
                    {
                        if (orders.OrderStatuses.OrderStatus != "Выполняется")
                        {
                            orderss.Add(orders);
                        }
                    }
                }
            }
            OrderCB.ItemsSource = orderss;
            OrderCB.DisplayMemberPath = "GruzName";
            StatusCB.ItemsSource = context.RouteStatuses.ToList();
            StatusCB.DisplayMemberPath = "RouteStatus";
            List<Transport> trans = new List<Transport>();
            foreach (var tr in context.Transport)
            {
                if (tr.TransportSostoyanie.SostoyanieTransport == "Простаивает")
                {
                    trans.Add(tr);
                }
            }
            TransportCB.ItemsSource = trans;
            TransportCB.DisplayMemberPath = "CarNomber";
        }

        private bool ProverkaDigit(string ves)
        {
            return int.TryParse(ves, out _);
        }

        private void AddBtm_Click(object sender, RoutedEventArgs e)
        {
            Routess routes = new Routess();
            if (TransportCB.SelectedItem != null && DostavkaTbx.Text != "" && OtprovlenieTbx.Text != "" && ProtiajennostTbx.Text != "" && StatusCB.SelectedItem != null && OrderCB.SelectedItem != null)
            {
                if (ProverkaDigit(ProtiajennostTbx.Text.Trim()))
                {
                    routes.Orders = OrderCB.SelectedItem as Orders;
                    routes.Otpravlenie = OtprovlenieTbx.Text.Trim();
                    routes.Dostavka = DostavkaTbx.Text.Trim();
                    routes.Protyajonnost = Convert.ToInt32(ProtiajennostTbx.Text.Trim());
                    routes.Transport = TransportCB.SelectedItem as Transport;
                    routes.RouteStatuses = StatusCB.SelectedItem as RouteStatuses;
                    routes.Orders.OrderStatus_ID = 2;
                    routes.Transport.Sostoyanie_ID = 1;
                    context.Routess.Add(routes);

                    context.SaveChanges();
                    List<Routess> routesses = new List<Routess>();
                    foreach (Routess routess in context.Routess)
                    {
                        if (routess.RouteStatuses.RouteStatus != "Доставлен")
                        {
                            routesses.Add(routess);
                        }
                    }
                    MarshrutsDG.ItemsSource = routesses;
                    List<Transport> trans = new List<Transport>();
                    foreach (var tr in context.Transport)
                    {
                        if (tr.TransportSostoyanie.SostoyanieTransport == "Простаивает")
                        {
                            trans.Add(tr);
                        }
                    }
                    TransportCB.ItemsSource = trans;
                    List<Orders> orderss = new List<Orders>();
                    foreach (Orders orders in context.Orders)
                    {
                        if (orders.OrderStatuses.OrderStatus != "Завершён")
                        {
                            if (orders.OrderStatuses.OrderStatus != "Отменён")
                            {
                                if (orders.OrderStatuses.OrderStatus != "Выполняется")
                                {
                                    orderss.Add(orders);
                                }
                            }
                        }
                    }
                    OrderCB.ItemsSource = orderss;
                    StatusCB.SelectedItem = null;
                    OrderCB.SelectedItem = null;
                    TransportCB.SelectedItem = null;
                    DostavkaTbx.Text = "";
                    OtprovlenieTbx.Text = "";
                    ProtiajennostTbx.Text = "";
                }
                else
                {
                    MessageBox.Show("Протяжённость должна быть числом");
                }
            }
            else
            {
                MessageBox.Show("Не все поля введены");
            }
        }

        private void EditBtm_Click(object sender, RoutedEventArgs e)
        {
            var selected = MarshrutsDG.SelectedItem as Routess;
            if (selected != null)
            {
                if (TransportCB.SelectedItem != null && DostavkaTbx.Text != "" && OtprovlenieTbx.Text != "" && ProtiajennostTbx.Text != "" && StatusCB.SelectedItem != null && OrderCB.SelectedItem != null)
                {
                    if (ProverkaDigit(ProtiajennostTbx.Text.Trim()))
                    {
                        selected.Orders = OrderCB.SelectedItem as Orders;
                        selected.Otpravlenie = OtprovlenieTbx.Text.Trim();
                        selected.Dostavka = DostavkaTbx.Text.Trim();
                        selected.Protyajonnost = Convert.ToInt32(ProtiajennostTbx.Text.Trim());
                        selected.Transport = TransportCB.SelectedItem as Transport;
                        selected.RouteStatuses = StatusCB.SelectedItem as RouteStatuses;
                        if (selected.RouteStatuses.RouteStatus == "Доставлен")
                        {
                            selected.Orders.Storage.ColvoGruzInStorage -= 1;
                            selected.Orders.Storage.DostupMesto += 1;
                            OpredelenieAsync(selected.Orders);
                            selected.Orders.OrderStatus_ID = 3;
                        }

                        context.SaveChanges();
                        List<Routess> routesses = new List<Routess>();
                        foreach (Routess routess in context.Routess)
                        {
                            if (routess.RouteStatuses.RouteStatus != "Доставлен")
                            {
                                routesses.Add(routess);
                            }
                        }
                        List<Transport> trans = new List<Transport>();
                        foreach (var tr in context.Transport)
                        {
                            if (tr.TransportSostoyanie.SostoyanieTransport == "Простаивает")
                            {
                                trans.Add(tr);
                            }
                        }
                        TransportCB.ItemsSource = trans;
                        List<Orders> orderss = new List<Orders>();
                        foreach (Orders orders in context.Orders)
                        {
                            if (orders.OrderStatuses.OrderStatus != "Завершён")
                            {
                                if (orders.OrderStatuses.OrderStatus != "Отменён")
                                {
                                    if (orders.OrderStatuses.OrderStatus != "Выполняется")
                                    {
                                        orderss.Add(orders);
                                    }
                                }
                            }
                        }
                        OrderCB.ItemsSource = orderss;
                        MarshrutsDG.ItemsSource = routesses;
                        MarshrutsDG.SelectedItem = null;
                        StatusCB.SelectedItem = null;
                        OrderCB.SelectedItem = null;
                        TransportCB.SelectedItem = null;
                        DostavkaTbx.Text = "";
                        OtprovlenieTbx.Text = "";
                        ProtiajennostTbx.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Протяжённость должна быть числом");
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
            MarshrutsDG.SelectedItem = null;
            
            StatusCB.SelectedItem = null;
            OrderCB.SelectedItem = null;
            TransportCB.SelectedItem = null;
            DostavkaTbx.Text = "";
            OtprovlenieTbx.Text = "";
            ProtiajennostTbx.Text = "";
            List<Orders> orderss = new List<Orders>();
            foreach (Orders orders in context.Orders)
            {
                if (orders.OrderStatuses.OrderStatus != "Завершён")
                {
                    if (orders.OrderStatuses.OrderStatus != "Отменён")
                    {
                        if (orders.OrderStatuses.OrderStatus != "Выполняется")
                        {
                            orderss.Add(orders);
                        }
                    }
                }
            }
            OrderCB.ItemsSource = orderss;
            List<Transport> trans = new List<Transport>();
            foreach (var tr in context.Transport)
            {
                if (tr.TransportSostoyanie.SostoyanieTransport == "Простаивает")
                {
                    trans.Add(tr);
                }
            }
            TransportCB.ItemsSource = trans;
        }

        private void MarshrutsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = MarshrutsDG.SelectedItem as Routess;
            var order = context.Orders.ToList();
            var ststus = context.RouteStatuses.ToList();
            var trans = context.Transport.ToList();
            if (selected != null)
            {
                DostavkaTbx.Text = selected.Dostavka.ToString();
                OtprovlenieTbx.Text = selected.Otpravlenie.ToString();
                ProtiajennostTbx.Text = selected.Protyajonnost.ToString();
                foreach (var ord in order)
                {
                    if (ord.ID_Order == selected.Order_ID)
                    {
                        List<Orders> orrd = new List<Orders>
                        {
                            selected.Orders
                        };
                        OrderCB.ItemsSource = orrd;
                        OrderCB.SelectedItem = ord;
                    }
                }
                foreach (var item in ststus)
                {
                    if (item.ID_RouteStatus == selected.RouteStatus_ID)
                    {
                        StatusCB.SelectedItem = item;
                    }
                }
                foreach (var item in trans)
                {
                    if (item.ID_Transport == selected.Transport_ID)
                    {
                        List<Transport> orrd = new List<Transport>
                        {
                            selected.Transport
                        };
                        TransportCB.ItemsSource = orrd;
                        TransportCB.SelectedItem = item;
                    }
                }
            }
        }

        private void OtchetBtm_Click(object sender, RoutedEventArgs e)
        {
            if (context.Routess.Count() != 0)
            {
                TxtForm();
            }
        }

        private void TxtForm()
        {
            string txtFilePath2 = System.IO.Path.Combine("output_1.txt");
            string pdfFilePath2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Общая загрузка маршрутов.pdf");
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
                var RoutesData = context.Routess
                    .Select(w => new
                    {
                        w.Otpravlenie,
                        w.Dostavka,
                        w.Protyajonnost,
                        driv = w.Transport.Drivers,
                        GruzName = w.Orders.GruzName,
                        GruzWeight = w.Orders.GruzWeight,
                        DateOtpravki = w.Orders.DateOtpravki,
                        DateDostavki = w.Orders.DateDostavki,
                        CarNomber = w.Transport.CarNomber,
                        RouteStatus = w.RouteStatuses.RouteStatus,
                    }).ToList();

                foreach (var order in RoutesData)
                {
                    string FullName = $"{order.driv.DriverName} {order.driv.DriverSurname} {order.driv.DriverMiddleName}";
                    writer.WriteLine($"{"ФИО водителя:",-10} {FullName}");
                    writer.WriteLine($"{"Название груза:",-10} {order.GruzName}");
                    writer.WriteLine($"{"Вес груза:",-10} {order.GruzWeight}");
                    writer.WriteLine($"{"Адрес отпракления:",-10} {order.Otpravlenie}");
                    writer.WriteLine($"{"Адрес доставки:",-10} {order.Dostavka}");
                    writer.WriteLine($"{"Протяжённость маршрута:",-10} {order.Protyajonnost}");
                    writer.WriteLine($"{"Дата отправки:",-10} {order.DateOtpravki}");
                    writer.WriteLine($"{"Дата доставки:",-10} {order.DateDostavki}");
                    writer.WriteLine($"{"Номер машины:",-10} {order.CarNomber}");
                    writer.WriteLine($"{"Статус:",-10} {order.RouteStatus}");
                    writer.WriteLine(new string('-', lineWidth));
                }
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

       
        private async Task OpredelenieAsync(Orders order)
        {
            string messageBody = $"Ваш заказ доставлен!\n---------------------------------------------------\nГруз: {order.GruzName}\nВес груза: {order.GruzWeight}\n---------------------------------------------------\nСпасибо, что воспользовались нашими услугами";

            try
            {
                var message = new MimeMessage(); 
                message.From.Add(new MailboxAddress("", FromEmail));
                message.To.Add(new MailboxAddress("", order.Clients.Email.ToString()));
                message.Subject = "Ваш заказ доставлен!";
                message.Body = new TextPart("plain") { Text = messageBody };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.yandex.ru", 465, SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync(FromEmail, FromPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                MessageBox.Show("Письмо успешно отправлено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки почты: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
