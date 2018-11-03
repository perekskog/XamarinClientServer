using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleShoppingList.Models;
using Microsoft.Extensions.Logging;

namespace SimpleShoppingListWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingListController : Controller // Or ControllerBase for removing "intellisense noise"
    {
        private readonly ILogger<ShoppingListController> logger;

        public ShoppingListController(ILogger<ShoppingListController> logger)
        {
            this.logger = logger;
        }

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
            logger.LogDebug("1-debug-Get(" + id + ")" + "Controller");
            logger.LogError("1-error-Get(" + id + ")" + "Controller");
            logger.LogTrace("1-trace-Get(" + id + ")" + "Controller");
            logger.LogWarning("1-warning-Get(" + id + ")" + "Controller");
            logger.LogCritical("1-critical-Get(" + id + ")" + "Controller");
            logger.LogInformation("1-information-Get(" + id + ")" + "Controller");

            ShoppingList result = 
                shoppingLists.FirstOrDefault(s => s.Id == id);
            if(result==null)
            {
                logger.LogTrace("Get(" + id + ")" + "Controller => NotFound");
                return NotFound();
            }

            logger.LogTrace("Get(" + id + ")" + "Controller => OK");
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IEnumerable Post(ShoppingList newList)
        {
            newList.Id = shoppingLists.Count;
            logger.LogTrace("Add shoppinglist " + newList.Name + " " + newList.Id);
            shoppingLists.Add(newList);
            return shoppingLists;
        }

    }
}
