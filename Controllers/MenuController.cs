using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.Menu;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Mvc;

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
        var menu = _menuRepository.GetMenuById(id);
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

