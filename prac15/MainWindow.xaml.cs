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

namespace prac15
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int DaysInCurrentMonth;
        public MainWindow()
        {
            InitializeComponent();
            Dater.SelectedDate = DateTime.Today;
            Dater.Text = Dater.SelectedDate.Value.Month.ToString();
        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (y.Elements.Any(x => x.Date == Dater.SelectedDate))
                this.PageOfday.Content = new PageOfday(Dater.SelectedDate, sender);
        }

        private void PreviousMonth_Click(object sender, RoutedEventArgs e)
        {
            Dater.SelectedDate = Convert.ToDateTime(Dater.SelectedDate.Value.AddMonths(-1));
        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            Dater.SelectedDate = Convert.ToDateTime(Dater.SelectedDate.Value.AddMonths(1));

        }

        private void Dater_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int prevcountofdays = DaysInCurrentMonth;
            if (Dater.SelectedDate.Value.Month == 1 || Dater.SelectedDate.Value.Month == 3 || Dater.SelectedDate.Value.Month == 5 ||
                Dater.SelectedDate.Value.Month == 7 || Dater.SelectedDate.Value.Month == 8 || Dater.SelectedDate.Value.Month == 10 ||
                Dater.SelectedDate.Value.Month == 12)
                DaysInCurrentMonth = 31;
            else if (Dater.SelectedDate.Value.Month == 2)
            {
                if ((Dater.SelectedDate.Value.Year) % 4 == 0)
                    DaysInCurrentMonth = 29;
                else
                    DaysInCurrentMonth = 28;
            }
            else
            {
                DaysInCurrentMonth = 30;
            }
            if (prevcountofdays != DaysInCurrentMonth)
            {
                ButtonsPlace.Children.Clear();
                for (int i = 1; i <= DaysInCurrentMonth; i++)
                {
                    ButtonElement button = new ButtonElement();
                    button.Name = "btn" + i;
                    button.Day.Content = i;
                    button.btn.Click += ButtonOnClick;

                    this.ButtonsPlace.Children.Add(button);
                }
            }
        }
    }
}
