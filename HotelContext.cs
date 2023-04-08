using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class HotelContext: DbContext
{
    public DbSet<Hotel> Hoteles {get;set;}
    public DbSet<Habitacion> Habitaciones {get;set;}

    public DbSet<Pasajero> Pasajeros {get;set;}

    public DbSet<ContactoEmergencia> ContactosEmergencias {get;set;}

    public DbSet<Reserva> Reservas {get;set;}



    public HotelContext(DbContextOptions<HotelContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Hotel> hotelesInit = new List<Hotel>();
        hotelesInit.Add(new Hotel() { HotelId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), HotelNombre = "Hotel Cariongo",HotelCiudad = "Pamplona", HotelFechaCreacion = DateTime.Now,HotelFechaSalida = DateTime.Now, HotelNumPersonas = 4, HotelDisponibilidad = 1  });
        

        modelBuilder.Entity<Hotel>(hotel=> 
        {
            hotel.ToTable("Hotel");
            hotel.HasKey(p=> p.HotelId);
            hotel.Property(p=> p.HotelNombre).IsRequired().HasMaxLength(150);
            hotel.Property(p=> p.HotelCiudad).IsRequired().HasMaxLength(150);
            hotel.Property(p=> p.HotelFechaCreacion);
            hotel.Property(p=> p.HotelFechaSalida);
            hotel.Property(p=> p.HotelNumPersonas);
            hotel.Property(p=> p.HotelDisponibilidad);
            hotel.HasData(hotelesInit);
        });

        List<Habitacion> habitacionesInit = new List<Habitacion>();

        habitacionesInit.Add(new Habitacion() { HabitacionId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), HotelId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), HabitacionTipo = "cama doble", HabitacionPrecio= 10000, HabitacionDisponibilidad = 1 });
        
        modelBuilder.Entity<Habitacion>(habitacion=>
        {
            habitacion.ToTable("Habitacion");
            habitacion.HasKey(p=> p.HabitacionId);
            habitacion.HasOne(p=> p.Hotel).WithMany(p=> p.Habitaciones).HasForeignKey(p=> p.HotelId);
            habitacion.Property(p=> p.HabitacionTipo).IsRequired().HasMaxLength(200);
            habitacion.Property(p=> p.HabitacionPrecio);
            habitacion.Property(p=> p.HabitacionDisponibilidad);
            habitacion.HasData(habitacionesInit);

        });

         List<Pasajero> pasajeroInit = new List<Pasajero>();
        pasajeroInit.Add(new Pasajero() { PasajeroId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), PasajeroNombre = "Andres", PasajeroApellido = "Gonzales", PasajeroFechaNacimiento = DateTime.Now, PasajeroGenero = "Masculino",PasajeroTipoDocumento = "cc", PasajeroNumeroDocumento = "1094270086", PasajeroEmail = "admin@gmail.com", PasajeroTelefono ="3102311234"  });
        

        modelBuilder.Entity<Pasajero>(pasajero=> 
        {
            pasajero.ToTable("Pasajero");
            pasajero.HasKey(p=> p.PasajeroId);
            pasajero.Property(p=> p.PasajeroNombre).IsRequired().HasMaxLength(150);
            pasajero.Property(p=> p.PasajeroApellido).IsRequired().HasMaxLength(150);
            pasajero.Property(p=> p.PasajeroFechaNacimiento);
            pasajero.Property(p=> p.PasajeroGenero);
            pasajero.Property(p=> p.PasajeroTipoDocumento);
            pasajero.Property(p=> p.PasajeroNumeroDocumento);
            pasajero.Property(p=> p.PasajeroEmail);
            pasajero.Property(p=> p.PasajeroTelefono);
            pasajero.HasData(pasajeroInit);
        });

        List<ContactoEmergencia> contactoInit = new List<ContactoEmergencia>();

        contactoInit.Add(new ContactoEmergencia() { ContactoId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), PasajeroId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), ContactoNombre = "Javier", ContactoTelefono= "1114445" });
        
        modelBuilder.Entity<ContactoEmergencia>(contactoEmergencia=>
        {
            contactoEmergencia.ToTable("ContactoEmergencia");
            contactoEmergencia.HasKey(p=> p.ContactoId);
            contactoEmergencia.HasOne(p=> p.Pasajero).WithMany(p=> p.ContactosEmergencias).HasForeignKey(p=> p.PasajeroId);
            contactoEmergencia.Property(p=> p.ContactoNombre).IsRequired().HasMaxLength(200);
            contactoEmergencia.Property(p=> p.ContactoTelefono);
            contactoEmergencia.HasData(contactoInit);

        });

        List<Reserva> rerservaInit = new List<Reserva>();

        rerservaInit.Add(new Reserva() { ReservaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), PasajeroId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),HabitacionId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), ReservaFecha = DateTime.Now, ReservaPrecio= 12000 });
        
        modelBuilder.Entity<Reserva>(reserva=>
        {
            reserva.ToTable("Reserva");
            reserva.HasKey(p=> p.ReservaId);
            reserva.HasOne(p=> p.Pasajero).WithMany(p=> p.Reservas).HasForeignKey(p=> p.PasajeroId);
            reserva.HasOne(p=> p.Habitacion).WithMany(p=> p.Reservas).HasForeignKey(p=> p.HabitacionId);
            reserva.Property(p=> p.ReservaFecha);
            reserva.Property(p=> p.ReservaPrecio);
            reserva.HasData(rerservaInit);

        });


    }

}