using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos.MenuItem;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Interfaces;

public interface IMenuItemRepository
{
    MenuItem GetMenuItemById(int id);
    bool AddMenuItem(MenuItem menuItem);
    bool UpdateMenuItem(int id, MenuItemDto menuItemDto);
    bool DeleteMenuItem(int id);
    MenuItem GetMenuItemByName(string name);
}