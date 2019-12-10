using System;
using System.Collections.Generic;
using System.Text;
using static ShoppingList.MainWindowViewModel;

namespace ShoppingList
{
    public class ShoppingItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Size { get; set; }
        public UnitType Unit { get; set; }

        public enum UnitType
        {
            Gallon,
            FluidOunce,
            Liter,
            Gram,
            Pound,
            Each
        }

        public ShoppingItem(string name, int quantity, double size, UnitType unit)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Quantity = quantity;
            Size = size;
            Unit = unit;
        }
    }
}
