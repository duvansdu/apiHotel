using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<HotelContext>("Data Source=DESKTOP-4EIQT99; Initial Catalog=HotelDb; user id=sa; password=123456; Encrypt=False;");
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService());
builder.Services.AddScoped<IHotelService, HotelService>();
/*builder.Services.AddScoped<IHabitacionService, HabitacionService>();
builder.Services.AddScoped<IPasajeroService, PasajeroService>();
builder.Services.AddScoped<IContactoEmergenciaService, ContactoEmergenciaService>();
builder.Services.AddScoped<IReservaService, ReservaService>();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
