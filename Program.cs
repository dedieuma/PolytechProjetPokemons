using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PokeAPIPolytech.Exceptions;
using PokeAPIPolytech.Repositories;
using PokeAPIPolytech.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "PokeAPIPolytech",
        Description = "A Web API To handle pokemons"
    });
    
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<PokemonContext>(options => options.UseSqlite("Data Source=pokemons.db"));

builder.Services.AddScoped<IPokemonsDbSources, PokemonsDbSources>();
builder.Services.AddScoped<IPokemonsAbilitiesDbSources, PokemonsAbilitiesDbSources>();
builder.Services.AddScoped<IAbilityToPokemonService, AbilityToPokemonService>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(setup =>
{
    setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokemon Swagger");
    setup.RoutePrefix = string.Empty;
});


app.UseExceptionHandler(new ExceptionHandlerOptions
    {ExceptionHandler = PokeApiExceptionHandler.HandleException});

app.UseCors(
    options => options
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();