using Microsoft.AspNetCore.Mvc;
using PokeAPIPolytech.Dtos;
using PokeAPIPolytech.Services;

namespace PokeAPIPolytech.Controllers;

[ApiController]
[Route("Pokemons/Abilities")]
public class PokemonAbilitiesController : ControllerBase
{

    private readonly IAbilityToPokemonService abilityToPokemonService;

    public PokemonAbilitiesController(IAbilityToPokemonService abilityToPokemonService)
    {
        this.abilityToPokemonService = abilityToPokemonService;
    }

    /// <summary>
    /// Link an ability to a pokemon
    /// </summary>
    /// <param name="dto"></param>
    /// <response code="200">Returns updated pokemon</response>
    /// <response code="400">If the ability is already linked with the pokemon</response>
    /// <response code="404">If no pokemon with given id, or no ability with given id has been found</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<PokemonDto> LinkAbilityToPokemon(PokemonToAbilityDto dto)
    {
        var pokemon = abilityToPokemonService.Link(dto);

        return Ok(pokemon);
    }

    /// <summary>
    /// Remove a link between a pokemon and an ability
    /// </summary>
    /// <param name="dto"></param>
    /// <response code="200">Returns updated pokemon</response>
    /// <response code="400">If the ability is not linked with the pokemon</response>
    /// <response code="404">If no pokemon with given id, or no ability with given id has been found</response>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<PokemonDto> RemoveLink(PokemonToAbilityDto dto)
    {
        var pokemon = abilityToPokemonService.RemoveLink(dto);

        return Ok(pokemon);
    }
    
}