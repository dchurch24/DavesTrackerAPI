using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Classes
{
    public class foodcount
    {
        public string DateTime { get; set; }
        public string UserID { get; set; }
        public string Barcode { get; set; }
        public string Product { get; set; }
        public string Calories { get; set; }
        public string Percent { get; set; }
    }
}
