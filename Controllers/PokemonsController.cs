using Microsoft.AspNetCore.Mvc;
using PokeAPIPolytech.Dtos;
using PokeAPIPolytech.Services;

namespace PokeAPIPolytech.Controllers;

/// <summary>
/// Pokemons Controller
/// </summary>
[ApiController]
[Route("[controller]")]
public class PokemonsController : ControllerBase
{
    private readonly IPokemonsDbSources pokemonsDbSources;

    public PokemonsController(IPokemonsDbSources pokemonsDbSources)
    {
        this.pokemonsDbSources = pokemonsDbSources;
    }

    
    /// <summary>
    /// Retrieves all the pokemons
    /// </summary>
    /// <returns></returns>
    [HttpGet("All")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<PokemonDto> GetAllPokemons()
    {
        return pokemonsDbSources.GetAll();
    }
    
    /// <summary>
    /// Retrieve a pokemon by his name
    /// </summary>
    /// <param name="name"></param>
    /// <response code="200">Returns the found pokemon</response>
    /// <response code="404">If no pokemon with given name has been found</response>
    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<PokemonDto> GetPokemonByName(string name)
    {
        var pokemon = pokemonsDbSources.GetByName(name);

        if (pokemon == null)
        {
            return NotFound();
        }

        return Ok(pokemon);
    }

    /// <summary>
    /// Creates a new pokemon
    /// </summary>
    /// <param name="dto"></param>
    /// <response code="200">Returns the created pokemon</response>
    /// <response code="400">If a pokemon already exists with the given id</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<PokemonDto> InsertPokemon(CreatePokemonDto dto)
    {
        var pokemon = pokemonsDbSources.Insert(dto);

        return Ok(pokemon);
    }

    /// <summary>
    /// Deletes the pokemon with the given id.
    /// If no pokemon exists with the id, silently end
    /// </summary>
    /// <param name="id"></param>
    /// <response code="204">Indicates the success of the operation</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public void DeletePokemonById(int id)
    {
        pokemonsDbSources.DeleteById(id);
    }

    /// <summary>
    /// Updates the pokemon identified with the given id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <response code="200">The pokemon has been updated</response>
    /// <response code="404">No pokemon was found with given id</response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<PokemonDto> UpdatePokemon(int id, UpdatePokemonDto dto)
    {
        var pokemon = pokemonsDbSources.Update(id, dto);

        return Ok(pokemon);
    }
}
