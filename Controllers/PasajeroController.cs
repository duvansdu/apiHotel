using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;

namespace webapi.Controllers;

[Route("api/[controller]")]

public class PasajeroController:  ControllerBase
{
 IPasajeroService pasajeroService;

 public PasajeroController(IPasajeroService service)
 {
    pasajeroService = service;
 }

[HttpGet]
 public IActionResult Get()
 {
   return Ok(pasajeroService.Get());
 }

 [HttpPost]
 public IActionResult Post([FromBody] Pasajero pasajero )
 {
    pasajeroService.Save(pasajero);
    return Ok();
 }
[HttpPut("{id}")]
 public IActionResult Put(Guid id, [FromBody] Pasajero pasajero )
 {
    pasajeroService.Update(id, pasajero);
    return Ok();
 }
 [HttpDelete("{id}")]
public IActionResult Delete(Guid id)
{
    pasajeroService.Delete(id);
    return Ok();
}
}