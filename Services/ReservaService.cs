
using webapi.Models;

namespace webapi.Services;
public class ReservaService : IReservaService
{
    HotelContext context;

    public ReservaService(HotelContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Reserva>Get()
    {
        return context.Reservas;
    }

    public async Task  Save(Reserva reserva)
    {
        context.Add(reserva);
        context.SaveChangesAsync();
    }

     public async Task  Update(Guid id, Reserva reserva)
    {
        var reservaActual = context.Reservas.Find(id);
        if(reservaActual != null)
        {
            reservaActual.ReservaFecha = reserva.ReservaFecha;
            reservaActual.ReservaPrecio = reserva.ReservaPrecio;
            await context.SaveChangesAsync();
        }
    }


    public async Task  Delete(Guid id)
    {
        var reservaActual = context.Reservas.Find(id);
        if(reservaActual != null)
        {
            context.Remove(reservaActual);
            await context.SaveChangesAsync();
        }
    }
} 

public interface IReservaService
{
    IEnumerable<Reserva>Get();
    Task  Save(Reserva reserva);
    Task  Update(Guid id, Reserva reserva);
    Task  Delete(Guid id);

}