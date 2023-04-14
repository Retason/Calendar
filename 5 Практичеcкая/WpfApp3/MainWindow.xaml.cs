using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<DayItem> days = new List<DayItem>();
        private FoodPage foodPage = new FoodPage();
        private Calendar calendar;

        public MainWindow()
        {
            days = SaveLoad.LoadData();
            calendar = new Calendar(days);
            InitializeComponent();
            foodPage.OnSave += FoodPage_OnSave;
            dt.SelectedDate = DateTime.Now;
            frame.Navigate(foodPage);
            frame.Navigate(calendar);
            calendar.OnClickDay += Calendar_OnClickDay;
        }

        private void FoodPage_OnSave(DayItem item)
        {
            frame.Navigate(calendar);
            bool b = false;
            for (int i = 0; i < days.Count; i++)
            {
                if (days[i].Day.Ticks == item.Day.Ticks)
                {
                    days[i] = item;
                    b = true;
                    break;
                }
            }
            if(!b)
                days.Add(item);
            calendar.Refresh();
            btn_Forward.Visibility = Visibility.Visible;

        }

        private void Calendar_OnClickDay(DateTime date)
        {
            btn_Forward.Visibility = Visibility.Hidden;
            dt.SelectedDate = date;
            var day = from d in days where d.Day == date select d;
            var curDay = day.FirstOrDefault() ?? new DayItem(date, null);
            foodPage.SetFoods(curDay.Foods,date);
            frame.Navigate(foodPage);
        }

        private void btn_beck_Click(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.Content.GetType() == typeof(Calendar))
            {

                dt.SelectedDate = dt.SelectedDate.Value.AddMonths(-1);
                (frame.NavigationService.Content as Calendar).CurDate = dt.SelectedDate.Value;
            }
            else
            {
                btn_Forward.Visibility = Visibility.Visible;

                frame.Navigate(calendar);

            }
        }

        private void btn_Forward_Click(object sender, RoutedEventArgs e)
        {
            dt.SelectedDate = dt.SelectedDate.Value.AddMonths(1);
        }

        private void dt_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            calendar.CurDate = dt.SelectedDate.Value;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveLoad.SaveData(days);
        }
    }
}
