using System;
namespace SimpleShoppingList.Models
{
    public class Item
    {
        public Item()
        {
            Id = 0;
            Name = string.Empty;
            Checked = false;
            ShoppingListId = 0;
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
        public bool Checked
        {
            get;
            set;
        }
        public int ShoppingListId
        {
            get;
            set;
        }
    }
}
