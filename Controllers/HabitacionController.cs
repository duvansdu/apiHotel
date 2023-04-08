using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;

namespace webapi.Controllers;

[Route("api/[controller]")]

public class HabitacionController:  ControllerBase
{
 IHabitacionService habitacionService;

 public HabitacionController(IHabitacionService service)
 {
    habitacionService = service;
 }

[HttpGet]
 public IActionResult Get()
 {
   return Ok(habitacionService.Get());
 }

 [HttpPost]
 public IActionResult Post([FromBody] Habitacion habitacion )
 {
    habitacionService.Save(habitacion);
    return Ok();
 }
[HttpPut("{id}")]
 public IActionResult Put(Guid id, [FromBody] Habitacion habitacion )
 {
    habitacionService.Update(id, habitacion);
    return Ok();
 }
 [HttpDelete("{id}")]
public IActionResult Delete(Guid id)
{
    habitacionService.Delete(id);
    return Ok();
}
}