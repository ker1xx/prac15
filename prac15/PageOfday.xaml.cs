using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для PageOfday.xaml
    /// </summary>
    public partial class PageOfday : Page
    {
       
        public PageOfday(DateTime? Date)
        {
            InitializeComponent();
            this.Date.Text = Date.ToString();
            foreach (ElementModel item in y.Elements)
            {
                UserControl1 element = new UserControl1();
                element.Name.Text = item.Name;
                element.img.Source = new BitmapImage( new Uri(item.ImgSource, UriKind.Relative));
            }   
        }
    }
}
