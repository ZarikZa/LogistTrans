using Spire.Pdf.Graphics;
using Spire.Pdf;
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

        private void OtchetBtm_Click(object sender, RoutedEventArgs e)
        {
            TxtForm();
        }

        private void TxtForm()
        {
            string txtFilePath2 = System.IO.Path.Combine("output_1.txt");
            string pdfFilePath2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Общая загрузка транспорта.pdf");
            using (FileStream fs = new FileStream(txtFilePath2, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                string header = "Общая загрузка транспорта";
                int lineWidth = 70;

                string CenterString(string text, int width)
                {
                    if (text.Length >= width) return text;
                    int padding = (width - text.Length) / 2;
                    return new string(' ', padding) + text;
                }
                writer.WriteLine(CenterString(header, lineWidth));
                writer.WriteLine(new string('-', lineWidth));
                var RoutesData = context.Transport
                    .Select(w => new
                    {
                        w.CarNomber,
                        w.Vmestimost,
                        Sps = w.TransportSostoyanie.SostoyanieTransport,
                        DriverName = w.Drivers.DriverName,
                        DriverSurname = w.Drivers.DriverSurname,
                        DriverMiddleName = w.Drivers.DriverMiddleName,
                        DriverLecence = w.Drivers.DriverLecence
                    }).ToList();

                foreach (var order in RoutesData)
                {
                    string FullName = $"{order.DriverName} {order.DriverSurname} {order.DriverMiddleName}";
                    writer.WriteLine($"{"ФИО водителя:",-10} {FullName}");
                    writer.WriteLine($"{"Номер автомобиля:",-10} {order.CarNomber}");
                    writer.WriteLine($"{"Вместимость машины в кг:",-10} {order.Vmestimost}");
                    writer.WriteLine($"{"Состояние автомобиля:",-10} {order.Sps}");
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
    }
}