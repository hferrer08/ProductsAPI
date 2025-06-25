var builder = WebApplication.CreateBuilder(args);

// Registramos los controladores
builder.Services.AddControllers();

var app = builder.Build();

// Mapeamos las rutas de los controladores
app.MapControllers();

app.Run();