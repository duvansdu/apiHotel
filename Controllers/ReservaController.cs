using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;

namespace webapi.Controllers;

[Route("api/[controller]")]

public class ReservaController:  ControllerBase
{
 IReservaService reservaService;

 public ReservaController(IReservaService service)
 {
    reservaService = service;
 }

[HttpGet]
 public IActionResult Get()
 {
   return Ok(reservaService.Get());
 }

 [HttpPost]
 public IActionResult Post([FromBody] Reserva reserva )
 {
    reservaService.Save(reserva);
    return Ok();
 }
[HttpPut("{id}")]
 public IActionResult Put(Guid id, [FromBody] Reserva reserva )
 {
    reservaService.Update(id, reserva);
    return Ok();
 }
 [HttpDelete("{id}")]
public IActionResult Delete(Guid id)
{
    reservaService.Delete(id);
    return Ok();
}
}