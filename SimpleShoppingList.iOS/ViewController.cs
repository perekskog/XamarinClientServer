using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

using UIKit;

namespace SimpleShoppingList.iOS
{
    public partial class ViewController : UIViewController
    {
        public List<ShoppingList> currentList;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            button_getlist1.TouchUpInside += delegate
            {
                this.getList(1);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public async void getList(int list)
        {
            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            var RestUrl = "http://localhost:12333/api/shoppingList/1";
            var uri = new Uri(string.Format(RestUrl, string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<ShoppingList>>(content);
                this.currentList = Items;
            }
        }
    }

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
