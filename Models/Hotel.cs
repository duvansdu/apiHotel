using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Hotel
{
    public Guid HotelId {get;set;}
    public string HotelNombre {get;set;}
    public string HotelCiudad {get;set;}
    public DateTime HotelFechaCreacion {get;set;}    
    public DateTime HotelFechaSalida {get;set;}  
    public int HotelNumPersonas {get;set;} 
    public int HotelDisponibilidad {get;set;} 

    [JsonIgnore]
    public virtual ICollection<Habitacion> Habitaciones {get;set;}
}
