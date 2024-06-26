using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos.DeliveryDriver;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food_Delivery_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeliveryDriverController : ControllerBase
{
    private readonly IDeliveryDriverRepository _deliveryDriverRepository;
    public DeliveryDriverController(IDeliveryDriverRepository deliveryDriverRepository)
    {
        _deliveryDriverRepository = deliveryDriverRepository;
    }

    [HttpGet("deliverydrivers")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAllDeliveryDrivers(){
        var deliveryDrivers = _deliveryDriverRepository.GetDeliveryDrivers();
        if (deliveryDrivers == null)
            return BadRequest("No delivery drivers registered");
        var deliveryDriversDtoList = deliveryDrivers.Select(x => new DeliveryDriverDto{
            Name = x.Name,
            Phone = x.Phone
        });
        return Ok(deliveryDriversDtoList);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetDeliveryDriver(int id){
        var deliveryDriver = _deliveryDriverRepository.GetDeliveryDriver(id);
        if (deliveryDriver == null)
            return NotFound();
        return Ok(new DeliveryDriverDto{
            Name = deliveryDriver.Name,
            Phone = deliveryDriver.Phone
        });
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateDeliveryDriver([FromBody] DeliveryDriverDto deliveryDriverDto){
        var deliveryDriver = new DeliveryDriver{
            Name = deliveryDriverDto.Name,
            Phone = deliveryDriverDto.Phone  
        };
        _deliveryDriverRepository.CreateDeliveryDriver(deliveryDriver);
        return Ok(deliveryDriverDto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateDeliveryDriver(int id, [FromBody] DeliveryDriverDto deliveryDriverDto){
        var _deliveryDriver = _deliveryDriverRepository.GetDeliveryDriver(id);
        if (_deliveryDriver == null)
            return NotFound();
        _deliveryDriverRepository.UpdateDeliveryDriver(id, deliveryDriverDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteDeliveryDriver(int id){
        _deliveryDriverRepository.DeleteDeliveryDriver(id);
        return Ok();
    }
}