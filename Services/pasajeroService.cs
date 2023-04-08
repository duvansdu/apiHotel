
using webapi.Models;

namespace webapi.Services;
public class PasajeroService : IPasajeroService
{
    HotelContext context;

    public PasajeroService(HotelContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Pasajero>Get()
    {
        return context.Pasajeros;
    }

    public async Task  Save(Pasajero pasajero)
    {
        context.Add(pasajero);
        context.SaveChangesAsync();
    }

     public async Task  Update(Guid id, Pasajero pasajero)
    {
        var pasajeroActual = context.Pasajeros.Find(id);
        if(pasajeroActual != null)
        {
            pasajeroActual.PasajeroNombre = pasajero.PasajeroNombre;
            pasajeroActual.PasajeroApellido = pasajero.PasajeroApellido;
            pasajeroActual.PasajeroFechaNacimiento = pasajero.PasajeroFechaNacimiento;
            pasajeroActual.PasajeroGenero = pasajero.PasajeroGenero;
            pasajeroActual.PasajeroTipoDocumento = pasajero.PasajeroTipoDocumento;
            pasajeroActual.PasajeroNumeroDocumento = pasajero.PasajeroNumeroDocumento;
            pasajeroActual.PasajeroEmail = pasajero.PasajeroEmail;
            pasajeroActual.PasajeroTelefono = pasajero.PasajeroTelefono;
            await context.SaveChangesAsync();
        }
    }


    public async Task  Delete(Guid id)
    {
        var pasajeroActual = context.Habitaciones.Find(id);
        if(pasajeroActual != null)
        {
            context.Remove(pasajeroActual);
            await context.SaveChangesAsync();
        }
    }
} 

public interface IPasajeroService
{
    IEnumerable<Pasajero>Get();
    Task  Save(Pasajero pasajero);
    Task  Update(Guid id, Pasajero pasajero);
    Task  Delete(Guid id);

}