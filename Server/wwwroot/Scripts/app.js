var currentList = {};

function showShoppingList()
{
    $("#shoppingListTitle").html(currentList.name);
    $("#shoppingListItems").empty();

    $("#createListDiv").hide();
    $("#shoppingListDiv").show();

    $("#newItemName").focus();
    $("#newItemName").keyup(function(event) {
        if(event.keyCode==13) {
            addItem();
        }
    });
}

function createShoppingList()
{
    currentList.name = $("#shoppingListName").val();
    currentList.items = new Array();
    console.info("createShoppingList: before post");
    console.dir(currentList);

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "api/shoppinglist/",
        data: currentList,
        success: function(result) {
            // This is from the course, but it causes a type error later.
            // currentList = result;
            currentList = result.slice(-1)[0];
            showShoppingList();
            drawItems();
            console.info("createShoppingList: after post");
            console.dir(currentList);
        }
    });
}

function addItem()
{
    var newItem = {};
    newItem.name = $("#newItemName").val();
    newItem.shoppingListId = currentList.id;
    currentList.items.push(newItem);
    console.info("addItem: before post");
    console.dir(currentList);
    console.dir(newItem);

    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: "api/item/",
        data: newItem,
        success: function(result) {
            currentList = result;
            drawItems();
            $("#newItemName").val("");
            console.info("addItem: after post");
            console.dir(currentList);
        }
    });
}

function drawItems()
{
    var $list = $("#shoppingListItems").empty();

    for(i=0; i<currentList.items.length; i++)
    {
        var currentItem = currentList.items[i];
        var $li = $("<li>").html(currentItem.name).attr("id", "item_"+i);
        var $deleteBtn = $("<button onclick='deleteItem(" + i + ")'>D</button>").appendTo($li);
        var $checkBtn = $("<button onclick='checkItem(" + i + ")'>C</button>").appendTo($li);
        $li.appendTo($list);
        if(currentItem.checked) {
            $li.addClass("checked");
        }
    }

    $("#newItemName").val('');
}

function deleteItem(index)
{
    itemToDelete = currentList.items[index].id;

    console.info("deleteItem: before post");
    console.dir(currentList);
    console.dir(itemToDelete);

    $.ajax({
        type: "DELETE",
        dataType: "JSON",
        url: "api/item/" + itemToDelete,
        success: function(result) {
            currentList = result;
            drawItems();
            console.info("deleteItem: after post");
            console.dir(currentList);
        }
    });
}

function checkItem(index)
{
    changedItem = {};

    for(var i=0; i<currentList.items.length; i++)
    {
        if(currentList.items[i].id == index)
        {
            changedItem = currentList.items[index];
        }
    }

    changedItem.checked = !changedItem.checked;

    console.info("checkItem: before post");
    console.dir(currentList);
    console.dir(changedItem);

    $.ajax({
        type: "PUT",
        dataType: "JSON",
        url: "api/item/" + index,
        data: changedItem,
        success: function(result) {
            currentList = result;
            drawItems();
            console.info("checkItem: after post");
            console.dir(currentList);
        }
    });
}

function getShoppingListById(id)
{
    console.info("getShoppingListById:" + id);

    $.ajax({
        type: "GET",
        dataType: "JSON",
        url: "api/shoppinglist/" + id,
        success: function(result) {
            currentList = result;
            showShoppingList();
            drawItems();
            console.info("getShoppingListById: after post");
            console.dir(currentList);
        }
    });
}

$(document).ready(function() {
    console.info("Ready 20");

    $("#shoppingListName").focus();
    $("#shoppingListName").keyup(function(event) {
        if(event.keyCode==13) {
            createShoppingList();
        }
    });

    var pageURL = window.location.href;
    var idIndex = pageURL.indexOf("?id=");
    console.info("idIndex:" + idIndex);
    if(idIndex!=-1)
    {
        getShoppingListById(pageURL.substr(idIndex+4));
    }
})