using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Media;
using static ShoppingList.ShoppingItem;

namespace ShoppingList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MainWindowViewModel();
            InitializeComponent();
            UnitTypeComboBox.ItemsSource = Enum.GetValues(typeof(UnitType));
        }
    }
}
