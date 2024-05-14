using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.Menu;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_Delivery_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    private readonly IMenuRepository _menuRepository;

    public MenuController(FoodDeliveryContext foodDeliveryContext, IMenuRepository menuRepository)
    {
        _foodDeliveryContext = foodDeliveryContext;
        _menuRepository = menuRepository;
    }

    [HttpGet("{id}")]
    public IActionResult GetMenuById(int id){
        // var menu = _menuRepository.GetMenuById(id);
        var menu = _foodDeliveryContext.Menus
                    .Include(m => m.MenuItems)
                    .Include(m=> m.Restaurant)
                    .FirstOrDefault(u => u.MenuId == id);
        return Ok(menu);
    }

    [HttpPost]
    public IActionResult CreateMenu([FromBody] MenuDto menuDto){
        var menu = new Menu(){
            Name = menuDto.Name,  
            RestaurantId = menuDto.RestaurantId
        };
        _menuRepository.AddMenu(menu);
        return Ok(menu);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMenu(int id, [FromBody] MenuDto menuDto){
        var menu = GetMenuById(id);
        if (menu == null)
            return NotFound();
        _menuRepository.UpdateMenu(id, menuDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMenu(int id){
        var menuToDelete = GetMenuById(id);
        if (menuToDelete == null)
            return NotFound();
        _menuRepository.DeleteMenu(id);
        return Ok(menuToDelete);
    }
}



/* idee pentru a afisa numai ce vreau ca output folosindu ma de dto

[HttpGet("{id}")]
public IActionResult GetMenuById(int id)
{
    var menu = _foodDeliveryContext.Menus
                .Include(m => m.MenuItems)
                .Include(m => m.Restaurant)
                .FirstOrDefault(u => u.MenuId == id);

    if (menu == null)
    {
        return NotFound();
    }

    // Create MenuDetailsDto object with necessary data
    var menuDto = new MenuDetailsDto
    {
        MenuId = menu.MenuId,
        Name = menu.Name,
        RestaurantName = menu.Restaurant?.Name, // Include only the restaurant name
        MenuItems = menu.MenuItems.Select(mi => new MenuItemDto
        {
            MenuItemId = mi.MenuItemId,
            Name = mi.Name,
            Price = mi.Price,
            Description = mi.Description,
            Rating = mi.Rating
        }).ToList()
    };

    return Ok(menuDto);
}


*/