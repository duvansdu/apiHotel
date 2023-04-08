
using webapi.Models;

namespace webapi.Services;
public class HotelService : IHotelService
{
    HotelContext context;

    public HotelService(HotelContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Hotel>Get()
    {
        return context.Hoteles;
    }

    public async Task  Save(Hotel hotel)
    {
        context.Add(hotel);
        context.SaveChangesAsync();
    }

     public async Task  Update(Guid id, Hotel hotel)
    {
        var hotelActual = context.Hoteles.Find(id);
        if(hotelActual != null)
        {
            hotelActual.HotelNombre = hotel.HotelNombre;
            hotelActual.HotelCiudad = hotel.HotelCiudad;
            hotelActual.HotelFechaCreacion = hotel.HotelFechaCreacion;
            hotelActual.HotelFechaSalida = hotel.HotelFechaSalida;
            hotelActual.HotelNumPersonas = hotel.HotelNumPersonas;
            hotelActual.HotelDisponibilidad = hotel.HotelDisponibilidad;
            await context.SaveChangesAsync();
        }
    }


    public async Task  Delete(Guid id)
    {
        var hotelActual = context.Hoteles.Find(id);
        if(hotelActual != null)
        {
            context.Remove(hotelActual);
            await context.SaveChangesAsync();
        }
    }
} 

public interface IHotelService
{
    IEnumerable<Hotel>Get();
    Task  Save(Hotel hotel);
    Task  Update(Guid id, Hotel hotel);
    Task  Delete(Guid id);

}