using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleShoppingList.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleShoppingListWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        // POST api/values
        [HttpPost]
        public IActionResult Post(Item item)
        {
            logger.Trace("Post item " + item.Name + " to list " + item.ShoppingListId);
            ShoppingList shoppingList =
                ShoppingListController.shoppingLists
                                      .Where(s => s.Id == item.ShoppingListId)
                                      .FirstOrDefault();
            if(shoppingList==null)
            {
                return NotFound();
            }

            if (shoppingList.Items.Count() == 0)
            {
                item.Id = 0;
            }
            else
            {
                item.Id = shoppingList.Items.Max(i => i.Id) + 1;
            }
            logger.Trace("Add item " + item.Name + " to list " + shoppingList.Id);
            shoppingList.Items.Add(item);

            return Ok(shoppingList);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Item item)
        {
            logger.Trace("Put item " + item.Name + " to list " + item.ShoppingListId);

            ShoppingList shoppingList =
                ShoppingListController.shoppingLists
                                      .Where(s => s.Id == item.ShoppingListId)
                                      .FirstOrDefault();
            if (shoppingList == null)
            {
                return NotFound();
            }

            Item changedItem = shoppingList.Items.Where(i => i.Id == id).FirstOrDefault();

            if(changedItem==null){
                return NotFound();
            }

            changedItem.Checked = item.Checked;

            return Ok(shoppingList);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            logger.Trace("Delete item " + id + " from list 1 (hard coded)");

            ShoppingList shoppingList =
                ShoppingListController.shoppingLists
                                      .Where(s => s.Id == 0)
                                      .FirstOrDefault();
            if (shoppingList == null)
            {
                return NotFound();
            }

            Item removeItem = shoppingList.Items.Where(i => i.Id == id).FirstOrDefault();
            // What's the difference?
            //Item removeItem = shoppingList.Items.FirstOrDefault(i => i.Id == id);

            if (removeItem == null)
            {
                return NotFound();
            }

            shoppingList.Items.Remove(removeItem);

            return Ok(shoppingList);
        }
    }
}
