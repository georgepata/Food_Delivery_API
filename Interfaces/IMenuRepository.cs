using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos.Menu;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Interfaces;

public interface IMenuRepository
{
    Menu GetMenuById (int id);
    bool AddMenu (Menu menu);
    bool UpdateMenu (int id, MenuDto menuDto);
    bool DeleteMenu (int id);
}