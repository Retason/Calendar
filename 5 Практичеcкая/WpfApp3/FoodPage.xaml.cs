using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для FoodPage.xaml
    /// </summary>
    public partial class FoodPage : Page
    {
        public delegate void Save(DayItem item);
        public event Save OnSave;
       private DateTime dt;
        public void SetFoods(FoodType[] foodType,DateTime date)
        {
            dt = date;
            if (foodType == null)
            {
                foreach (ListControl control in list.Items)
                    control.IsSelected = false;
                    return;
            }

            foreach (ListControl control in list.Items)
            {
                foreach (var v in foodType)
                {
                    if (control.FoodType == v)
                    {
                        control.IsSelected = true;
                        break;
                    }
                    else
                    {
                        control.IsSelected = false;
                    }
                }
            }
        }
        public FoodPage()
        {
            InitializeComponent();
            for (int i = 1; i <= 5; i++)
            {
                list.Items.Add(new ListControl(false, (FoodType)i, ((FoodType)i).ToString()));
            }
        }
        private FoodType[] GetFoods()
        {
            var res = new List<FoodType>();
            foreach (ListControl control in list.Items)
                if (control.IsSelected)
                    res.Add(control.FoodType);
            return res.ToArray();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnSave?.Invoke(new DayItem(dt, GetFoods()));
        }
    }
}
