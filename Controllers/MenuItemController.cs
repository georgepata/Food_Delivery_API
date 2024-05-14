using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.MenuItem;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food_Delivery_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuItemController : ControllerBase
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemController(FoodDeliveryContext foodDeliveryContext, IMenuItemRepository menuItemRepository)
    {
        _foodDeliveryContext = foodDeliveryContext;
        _menuItemRepository = menuItemRepository;
    }

    [HttpGet("{id}")]
    public IActionResult GetMenuItemById(int id){
        var menuItem = _menuItemRepository.GetMenuItemById(id);
        if (menuItem == null)
            return NotFound();
        return Ok(menuItem);
    }

    [HttpPost]
    public IActionResult CreateMenuItem([FromBody] MenuItemDto menuItemDto){
        var menuItem = new MenuItem(){
            Name = menuItemDto.Name,
            Price = menuItemDto.Price,
            Description = menuItemDto.Description,
            Rating = 0,
            MenuId = menuItemDto.MenuId
        };
        _menuItemRepository.AddMenuItem(menuItem);
        return Ok(menuItem);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMenuItem(int id, [FromBody] MenuItemDto menuItemDto){
        var menuItem = _menuItemRepository.GetMenuItemById(id);
        if (menuItem !=null){
            _menuItemRepository.UpdateMenuItem(id , menuItemDto);
            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMenuItem(int id){
        var menuItemToDelete = _menuItemRepository.GetMenuItemById(id);
        if (menuItemToDelete != null){
            _menuItemRepository.DeleteMenuItem(id);
            return Ok(menuItemToDelete);
        }
        return NotFound();
    }
}