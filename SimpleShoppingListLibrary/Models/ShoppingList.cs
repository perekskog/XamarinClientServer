using System;
using System.Collections.Generic;

namespace SimpleShoppingList.Models
{
    public class ShoppingList
    {
        public ShoppingList()
        {
            Id = 0;
            Name = String.Empty;
            Items = new List<Item>();
        }
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public List<Item> Items
        {
            get;
            set;
        }
    }
}
