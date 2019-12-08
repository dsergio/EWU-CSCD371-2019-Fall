using System;
using System.Collections.Generic;
using System.Text;
using static ShoppingList.MainWindowViewModel;

namespace ShoppingList
{
    public class ShoppingItem
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public int Quantity { get; set; }
        public double Size { get; set; }
        public UnitType Unit { get; set; }

        public ShoppingItem(string name, bool active, int quantity, double size, UnitType unit)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Active = active;
            Quantity = quantity;
            Size = size;
            Unit = unit;
        }
    }
}
