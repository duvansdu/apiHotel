using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;

namespace webapi.Controllers;

[Route("api/[controller]")]

public class ContactoEmergenciaController:  ControllerBase
{
 IContactoEmergenciaService contactoEmergenciaService;

 public ContactoEmergenciaController(IContactoEmergenciaService service)
 {
    contactoEmergenciaService = service;
 }

[HttpGet]
 public IActionResult Get()
 {
   return Ok(contactoEmergenciaService.Get());
 }

 [HttpPost]
 public IActionResult Post([FromBody] ContactoEmergencia contactoEmergencia )
 {
    contactoEmergenciaService.Save(contactoEmergencia);
    return Ok();
 }
[HttpPut("{id}")]
 public IActionResult Put(Guid id, [FromBody] ContactoEmergencia contactoEmergencia )
 {
    contactoEmergenciaService.Update(id, contactoEmergencia);
    return Ok();
 }
 [HttpDelete("{id}")]
public IActionResult Delete(Guid id)
{
    contactoEmergenciaService.Delete(id);
    return Ok();
}
}