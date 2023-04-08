
using webapi.Models;

namespace webapi.Services;
public class HabitacionService : IHabitacionService
{
    HotelContext context;

    public HabitacionService(HotelContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Habitacion>Get()
    {
        return context.Habitaciones;
    }

    public async Task  Save(Habitacion habitacion)
    {
        context.Add(habitacion);
        context.SaveChangesAsync();
    }

     public async Task  Update(Guid id, Habitacion habitacion)
    {
        var habitacionActual = context.Habitaciones.Find(id);
        if(habitacionActual != null)
        {
            habitacionActual.HabitacionTipo = habitacion.HabitacionTipo;
            habitacionActual.HabitacionPrecio = habitacion.HabitacionPrecio;
            habitacionActual.HabitacionDisponibilidad = habitacion.HabitacionDisponibilidad;
            await context.SaveChangesAsync();
        }
    }


    public async Task  Delete(Guid id)
    {
        var habitacionActual = context.Habitaciones.Find(id);
        if(habitacionActual != null)
        {
            context.Remove(habitacionActual);
            await context.SaveChangesAsync();
        }
    }
} 

public interface IHabitacionService
{
    IEnumerable<Habitacion>Get();
    Task  Save(Habitacion habitacion);
    Task  Update(Guid id, Habitacion habitacion);
    Task  Delete(Guid id);

}