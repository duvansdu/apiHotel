using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;

namespace webapi.Controllers;

[Route("api/[controller]")]

public class HotelController:  ControllerBase
{
 IHotelService hotelService;

 public HotelController(IHotelService service)
 {
    hotelService = service;
 }

[HttpGet]
 public IActionResult Get()
 {
   return Ok(hotelService.Get());
 }

 [HttpPost]
 public IActionResult Post([FromBody] Hotel hotel )
 {
    hotelService.Save(hotel);
    return Ok();
 }
[HttpPut("{id}")]
 public IActionResult Put(Guid id, [FromBody] Hotel hotel )
 {
    hotelService.Update(id, hotel);
    return Ok();
 }
 [HttpDelete("{id}")]
public IActionResult Delete(Guid id)
{
    hotelService.Delete(id);
    return Ok();
}
}