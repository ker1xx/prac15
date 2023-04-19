using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
namespace prac15
{
    /// <summary>
    /// Логика взаимодействия для PageOfday.xaml
    /// </summary>
    public partial class PageOfday : Page
    {
        private ButtonElement SelectedButton;
        private DateTime? Datee;
        public PageOfday(DateTime? Date, object button)
        {
            InitializeComponent();
            Datee = Date;
            this.Date.Text = Date.ToString();
            this.SelectedButton = button as ButtonElement;
            foreach (ElementModel item in y.Elements)
            {
                if (Datee == item.Date)
                {
                    UserControl1 element = new UserControl1();
                    element.NameOfElement.Text = item.Name;
                    element.img.Source = new BitmapImage(new Uri(item.ImgSource, UriKind.Absolute));
                    element.Checker.IsChecked = item.IsPicked;
                    element.Checker.Checked += Checker_Checked;
                    element.Checker.Unchecked += Checker_UnChecked;
                    element.Checker.Content = y.Elements.IndexOf(item);
                    element.Checker.CommandParameter = "{ Binding ElementName =dontknow}"; // И ЭТО ЧЕ НАХУЙ
                    this.Display.Children.Add(element);
                }
            }
        }
        private PageOfday()
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Checker_Checked(object sender, RoutedEventArgs e)
        {
            var dontknow = (((CheckBox)sender).CommandParameter) as UIElement; // Я В ДУШЕ НЕ ЕБУ ЧЕ ЭТО
            if (!CalendarModel.CalendarModels.Any(x => x.Date == Datee))
            {
                if (CalendarModel.CalendarModels.Any(x => x.Order.Any(k => k.IsPicked == false)))
                    CalendarModel.CalendarModels.FirstOrDefault(x => x.Date == Datee).Order.Add(y.Elements.FirstDisplay.Children.IndexOf(dontknow)); // здесь нужно индекс какойто спиздить 
                else
                    CalendarModel.CalendarModels.Add(new CalendarModel((DateTime)Datee, order));
            }
        }
        private void Checker_UnChecked(object sender, RoutedEventArgs e)
        {
            if (!CalendarModel.CalendarModels.Any(x => x.Date == Datee))
                order.Remove(Convert.ToInt32((sender as CheckBox).Content));
            if (CalendarModel.CalendarModels.Any(x => x.Date == Datee && !x.Order.Contains((Convert.ToInt32((sender as CheckBox).Content)))))
                CalendarModel.CalendarModels.FirstOrDefault(x => x.Date == Datee).Order = order;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedButton.Img.Source = new BitmapImage(new Uri(y.Elements.ElementAt(CalendarModel.CalendarModels.FirstOrDefault(x => x.Date == Datee).Order.Last()).ImgSource));
            y.Serialize(CalendarModel.CalendarModels, "Calendar.json");
            this.Visibility = Visibility.Collapsed;
        }

    }
}
