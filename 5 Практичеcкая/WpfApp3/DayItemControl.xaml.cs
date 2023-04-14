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
    /// Логика взаимодействия для DayItemControl.xaml
    /// </summary>
    public partial class DayItemControl : Button
    {
        public int Day { get;private set; }
        public DayItemControl(int day, FoodType food)
        {
            Day = day;  
            InitializeComponent();
            lb.Content = day;
            if (food > 0)
                pic.Source = new BitmapImage(new Uri($"Pic\\{(int)food}.png", UriKind.Relative));
        }
    }
}
