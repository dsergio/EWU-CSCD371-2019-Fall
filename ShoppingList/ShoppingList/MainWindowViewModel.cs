using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using static ShoppingList.ShoppingItem;

namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        //{
        //    if (!EqualityComparer<T>.Default.Equals(field, value))
        //    {
        //        field = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        public ObservableCollection<ShoppingItem> ShoppingItemList { get; } = new ObservableCollection<ShoppingItem>();

        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand CreateNewItemCommand { get; }

        private bool CanExecute { get; set; }

        private ShoppingItem _SelectedShoppingItem = new ShoppingItem("", 0, 0, UnitType.Each);
        public ShoppingItem SelectedShoppingItem
        {
            get => _SelectedShoppingItem;
            set => Set(ref _SelectedShoppingItem, value);
        }

        
        public MainWindowViewModel()
        {
            ShoppingItemList.Add(new ShoppingItem("Half & half", 1, 0.5, UnitType.Gallon));
            ShoppingItemList.Add(new ShoppingItem("Coffee", 1, 1, UnitType.Pound));
            ShoppingItemList.Add(new ShoppingItem("Bananas", 5, 1, UnitType.Each));
            SelectedShoppingItem = ShoppingItemList.First();
            CanExecute = true;
            AddItemCommand = new RelayCommand(OnAddItem, () => CanExecute);
            DeleteItemCommand = new RelayCommand(OnDeleteItem, () => CanExecute);
            CreateNewItemCommand = new RelayCommand(OnCreateItem, () => CanExecute);



        }

        private void OnAddItem()
        {
            if (SelectedShoppingItem is null)
            {
                return;
            }
            ShoppingItemList.Add(new ShoppingItem(SelectedShoppingItem.Name, SelectedShoppingItem.Quantity, SelectedShoppingItem.Size, SelectedShoppingItem.Unit));
            CanExecute = true;
            //AddItemCommand.InvokeCanExecuteChanged();
        }

        private void OnCreateItem()
        {
            SelectedShoppingItem = new ShoppingItem("New Item", 1, 1, UnitType.Each);
            CanExecute = true;
        }

        private void OnDeleteItem()
        {
            if (SelectedShoppingItem is null)
            {
                return;
            }
            ShoppingItemList.Remove(SelectedShoppingItem);
            CanExecute = true;
            //DeleteItemCommand.InvokeCanExecuteChanged();
        }
    }
}
