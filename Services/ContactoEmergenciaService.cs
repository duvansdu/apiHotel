
using webapi.Models;

namespace webapi.Services;
public class ContactoEmergenciaService : IContactoEmergenciaService
{
    HotelContext context;

    public ContactoEmergenciaService(HotelContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<ContactoEmergencia>Get()
    {
        return context.ContactosEmergencias;
    }

    public async Task  Save(ContactoEmergencia contactoEmergencia)
    {
        context.Add(contactoEmergencia);
        context.SaveChangesAsync();
    }

     public async Task  Update(Guid id, ContactoEmergencia contactoEmergencia)
    {
        var contactoEmergenciaActual = context.ContactosEmergencias.Find(id);
        if(contactoEmergenciaActual != null)
        {
            contactoEmergenciaActual.ContactoNombre = contactoEmergencia.ContactoNombre;
            contactoEmergenciaActual.ContactoTelefono = contactoEmergencia.ContactoTelefono;
            await context.SaveChangesAsync();
        }
    }


    public async Task  Delete(Guid id)
    {
        var contactoEmergenciaActual = context.ContactosEmergencias.Find(id);
        if(contactoEmergenciaActual != null)
        {
            context.Remove(contactoEmergenciaActual);
            await context.SaveChangesAsync();
        }
    }
} 

public interface IContactoEmergenciaService
{
    IEnumerable<ContactoEmergencia>Get();
    Task  Save(ContactoEmergencia contactoEmergencia);
    Task  Update(Guid id, ContactoEmergencia contactoEmergencia);
    Task  Delete(Guid id);

}