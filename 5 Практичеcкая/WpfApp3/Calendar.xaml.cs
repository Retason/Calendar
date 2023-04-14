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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Calendar.xaml
    /// </summary>
    public partial class Calendar : Page
    {
        public delegate void ClickDay(DateTime date);
        public event ClickDay OnClickDay;
        private DateTime curDate;
        public DateTime CurDate
        {
            get => curDate;
            set
            {
                curDate = value;
                Refresh();
            }
        }
        List<DayItem> dayItems = new List<DayItem>(31);
        public Calendar(List<DayItem> dayItems)
        {
            curDate = DateTime.Now;
            InitializeComponent();
            Refresh();
            this.dayItems = dayItems;
        }
        public void Refresh()
        {
            panel.Children.Clear();

            var days = (from d in dayItems where (d.Day.Year == curDate.Year && d.Day.Month == curDate.Month) select d).ToList(); 
            for (int i = 1; i < DateTime.DaysInMonth(curDate.Year, curDate.Month)+1; i++)
            {
                DayItemControl dayItemControl;
                var d = days.FirstOrDefault(x => x.Day.Day == i);
                if (d != null)
                    dayItemControl = new DayItemControl(i , d.Foods.FirstOrDefault());
                else
                    dayItemControl = new DayItemControl(i , FoodType.None);
                dayItemControl.Click += DayItemControl_Click;
                panel.Children.Add(dayItemControl);
            }
        }

        private void DayItemControl_Click(object sender, RoutedEventArgs e)
        {
            int day = (sender as DayItemControl).Day;
            DateTime res = new DateTime(curDate.Year, curDate.Month, day);
            OnClickDay?.Invoke(res);
        }
    }
}
