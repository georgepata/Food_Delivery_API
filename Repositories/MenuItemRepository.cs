using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.MenuItem;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public MenuItemRepository(FoodDeliveryContext foodDeliveryContext)
    {
        _foodDeliveryContext = foodDeliveryContext;
    }
    public MenuItem GetMenuItemById(int id)
    {
        return _foodDeliveryContext.MenuItems.FirstOrDefault(x => x.MenuItemId == id);
    }
    public MenuItem GetMenuItemByName(string name)
    {
        return _foodDeliveryContext.MenuItems.FirstOrDefault(x=> x.Name == name) ?? null;
        
    }

    public bool AddMenuItem(MenuItem menuItem)
    {
        _foodDeliveryContext.Add(menuItem);
        return Save();
    }

    public bool UpdateMenuItem(int id, MenuItemDto menuItemDto)
    {
        var menuItemToUpdate = GetMenuItemById(id);
        menuItemToUpdate.Name = menuItemDto.Name;
        menuItemToUpdate.Price = menuItemDto.Price;
        menuItemToUpdate.Description = menuItemDto.Description;
        return true;
    }

    public bool DeleteMenuItem(int id)
    {
        var menuItemToDelete = GetMenuItemById(id);
        if (menuItemToDelete != null)
            _foodDeliveryContext.Remove(menuItemToDelete);
        return Save();
    }

    public bool Save(){
        var savedChanges = _foodDeliveryContext.SaveChanges();
        return savedChanges > 0 ? true : false;
    }

    public bool GetRestaurantOfMenuItem(string name)
    {
        throw new NotImplementedException();
    }
}