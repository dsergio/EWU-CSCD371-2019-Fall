using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<ShoppingItem> ShoppingItemList { get; } = new ObservableCollection<ShoppingItem>();

        public Command AddItemCommand { get; }
        public Command DeleteItemCommand { get; }

        private bool CanExecute { get; set; }

        private ShoppingItem _SelectedShoppingItem;
        public ShoppingItem SelectedShoppingItem
        {
            get => _SelectedShoppingItem;
            set => SetProperty(ref _SelectedShoppingItem, value);
        }

        public enum UnitType
        {
            Gallon,
            FluidOunce,
            Liter,
            Gram,
            Pound,
            Each
        }
        public MainWindowViewModel()
        {
            ShoppingItemList.Add(new ShoppingItem("Half & half", true, 1, 0.5, UnitType.Gallon));
            ShoppingItemList.Add(new ShoppingItem("Coffee", true, 1, 1, UnitType.Pound));
            ShoppingItemList.Add(new ShoppingItem("Bananas", true, 5, 1, UnitType.Each));
            SelectedShoppingItem = ShoppingItemList.First();
            CanExecute = true;
            AddItemCommand = new Command(OnAddItem, () => CanExecute);
            DeleteItemCommand = new Command(OnDeleteItem, () => CanExecute);
        }

        private void OnAddItem()
        {
            ShoppingItemList.Add(new ShoppingItem(SelectedShoppingItem.Name, SelectedShoppingItem.Active, SelectedShoppingItem.Quantity, SelectedShoppingItem.Size, SelectedShoppingItem.Unit));
            CanExecute = true;
            AddItemCommand.InvokeCanExecuteChanged();
        }

        private void OnDeleteItem()
        {
            ShoppingItemList.Remove(SelectedShoppingItem);
            CanExecute = true;
            DeleteItemCommand.InvokeCanExecuteChanged();
        }
    }
}
