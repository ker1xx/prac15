using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac15
{
    internal class ElementModel
    {
        public ElementModel(string Name, string ImgSource, bool IsPicked, DateTime Date)
        {
            this.Name = Name;
            this.ImgSource = ImgSource;
            this.IsPicked = IsPicked;
            this.Date = Date;
        }
        public string Name;
        public string ImgSource;
        public bool IsPicked;
        public DateTime Date;
    }
}
