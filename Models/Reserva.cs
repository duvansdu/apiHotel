using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class Reserva
{
    public Guid ReservaId {get;set;}
    public Guid PasajeroId {get;set;}
     public Guid HabitacionId {get;set;}
    public DateTime ReservaFecha {get;set;}
    public Decimal ReservaPrecio {get;set;}
    public virtual Pasajero Pasajero {get;set;}
    public virtual Habitacion Habitacion {get;set;}
}