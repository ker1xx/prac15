using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac15
{
    internal class CalendarModel
    {
        public CalendarModel(DateTime date, int eImg)
        {
            Date = date;
            EImg = eImg;
        }
        public DateTime Date;
        public int EImg;
    }
}
