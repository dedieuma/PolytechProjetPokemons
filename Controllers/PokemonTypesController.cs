using Microsoft.AspNetCore.Mvc;
using PokeAPIPolytech.Models;

namespace PokeAPIPolytech.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonTypesController : ControllerBase
{
    /// <summary>
    /// Returns all the posible types of a pokemon
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<PokemonType> GetAllTypes()
    {
        return Enum.GetValues<PokemonType>();
    }
}