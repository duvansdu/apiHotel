using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class ContactoEmergencia
{
    public Guid ContactoId {get;set;}
    public Guid PasajeroId {get;set;}
    public string ContactoNombre {get;set;}
    public string ContactoTelefono {get;set;}
    public virtual Pasajero Pasajero {get;set;}
}