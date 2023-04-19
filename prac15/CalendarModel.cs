using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac15
{
    internal class CalendarModel
    {
        public CalendarModel(DateTime date, List<ElementModel> Order)
        {
            Date = date;
            this.Order = Order;
        }
        public DateTime Date;
        public List<ElementModel> Order;
        public static List<CalendarModel> CalendarModels = y.Deserialize<List<CalendarModel>>("Calendar.json");
    }
}
