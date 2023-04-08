using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    HotelContext dbcontext;

    public HelloWorldController(IHelloWorldService helloWorld,HotelContext db)
    {
        helloWorldService = helloWorld;
        dbcontext = db;

    }
    [HttpGet]
   
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }


    [HttpGet]
     [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();

        return Ok();
    }
    

}