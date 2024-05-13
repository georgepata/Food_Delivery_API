using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.Menu;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public MenuRepository(FoodDeliveryContext foodDeliveryContext)
    {
        _foodDeliveryContext = foodDeliveryContext;
    }
    
    public Menu GetMenuById(int id)
    {
        return _foodDeliveryContext.Menus.FirstOrDefault(m => m.MenuId == id);
    }
    public bool AddMenu(Menu menu)
    {
        _foodDeliveryContext.Add(menu);
        return Save();
    }

    public bool UpdateMenu(int id, MenuDto menuDto)
    {
        var menu = _foodDeliveryContext.Menus.First(m => m.MenuId == id);
        menu.Name = menuDto.Name;
        return Save();
    }
    public bool DeleteMenu(int id)
    {
        var menuToDelete = GetMenuById(id);
        if (menuToDelete != null)
            _foodDeliveryContext.Remove(menuToDelete);
        return Save();
    }

    public bool Save(){
        var savedChanges = _foodDeliveryContext.SaveChanges();
        return savedChanges > 0 ? true : false;
    }
}