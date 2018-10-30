using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleShoppingList.Models;

namespace SimpleShoppingListWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingListController : Controller // Or ControllerBase for removing "intellisense noise"
    {
        public static List<ShoppingList> shoppingLists = new List<ShoppingList>
        {
            new ShoppingList() {Id=0, Name="Hem", Items= {
                    new Item(){Id=0, Name= "Mjölk", ShoppingListId=0},
                    new Item(){Id=1, Name= "Bröd", ShoppingListId=0}
                }},
            new ShoppingList() {Id=1, Name="Bil", Items= {
                    new Item(){Id=0, Name="M140", ShoppingListId=1},
                    new Item(){Id=1, Name="M3", ShoppingListId=1},
                    new Item(){Id=2, Name="1M", ShoppingListId=1}
                }}
        };

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Console.WriteLine("Get(" + id + ")" + "Controller");
            ShoppingList result = 
                shoppingLists.FirstOrDefault(s => s.Id == id);
            if(result==null)
            {
                Console.WriteLine("Get(" + id + ")" + "Controller => NotFound");
                return NotFound();
            }

            Console.WriteLine("Get(" + id + ")" + "Controller => OK");
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IEnumerable Post(ShoppingList newList)
        {
            newList.Id = shoppingLists.Count;
            Console.WriteLine("Add shoppinglist " + newList.Name + " " + newList.Id);
            shoppingLists.Add(newList);
            return shoppingLists;
        }

    }
}
