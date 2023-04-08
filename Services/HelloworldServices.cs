public class HelloWorldService : IHelloWorldService
{
  public string GetHelloWorld()
  {
    return "Hola Mundo";
  }  
}

public interface IHelloWorldService
{
    string GetHelloWorld();
}