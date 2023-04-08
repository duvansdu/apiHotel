using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Pasajero
{
    public Guid PasajeroId {get;set;}
    public string PasajeroNombre {get;set;}
    public string PasajeroApellido {get;set;}
    public DateTime PasajeroFechaNacimiento {get;set;}    
    public string PasajeroGenero {get;set;}
    public string PasajeroTipoDocumento {get;set;}
    public string PasajeroNumeroDocumento {get;set;}
    public string PasajeroEmail {get;set;}

    public string PasajeroTelefono {get;set;}

      [JsonIgnore]
    public virtual ICollection<ContactoEmergencia> ContactosEmergencias {get;set;}
     [JsonIgnore]
    public virtual ICollection<Reserva> Reservas {get;set;}

}
