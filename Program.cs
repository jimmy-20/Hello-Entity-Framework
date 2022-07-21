using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Context;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareaContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareaContext>("Data Source = DESKTOP-ATV4JNH; Initial Catalog = TareasDb; User id = sa; password = JasoYT.2002");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/DbConnection", async ([FromServices] TareaContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria " + dbContext.Database.IsInMemory());
});

app.Run();
