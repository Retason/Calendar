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
    /// Логика взаимодействия для ListControl.xaml
    /// </summary>
    public partial class ListControl : UserControl
    {
        public FoodType FoodType { get; private set; }
        public bool IsSelected
        {
            get => cb.IsChecked.Value;
            set => cb.IsChecked = value;
        }
        public ListControl(bool isSelect, FoodType type, string name)
        {
            InitializeComponent();
            cb.IsChecked = isSelect;
            lb.Content = name;
            FoodType = type;
            if (type > 0)
                pic.Source = new BitmapImage(new Uri($"Pic\\{(int)type}.png", UriKind.Relative));
        }
    }
}
