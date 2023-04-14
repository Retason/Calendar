using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    [Serializable]
    public class DayItem
    {
        public DayItem(DateTime day, FoodType[] foods)
        {
            Day = day;
            Foods = foods;
        }
        public DayItem () { }
        public DateTime Day { get; set; }   
        public FoodType[] Foods { get; set; }
    }
}
