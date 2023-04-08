using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Habitacion
{
    public Guid HabitacionId {get;set;}
    public Guid HotelId {get;set;}
    public string HabitacionTipo {get;set;}
    public decimal HabitacionPrecio {get;set;}
    public int HabitacionDisponibilidad {get;set;}
    public virtual Hotel Hotel {get;set;}

   [JsonIgnore]
    public virtual ICollection<Reserva> Reservas {get;set;}
}
