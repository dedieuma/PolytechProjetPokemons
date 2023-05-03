using Microsoft.AspNetCore.Mvc;
using PokeAPIPolytech.Dtos;
using PokeAPIPolytech.Services;

namespace PokeAPIPolytech.Controllers;

[ApiController]
[Route("Abilities")]
public class AbilitiesController : ControllerBase
{
    private readonly IPokemonsAbilitiesDbSources pokemonsAbilitiesDbSources;

    public AbilitiesController(IPokemonsAbilitiesDbSources pokemonsAbilitiesDbSources)
    {
        this.pokemonsAbilitiesDbSources = pokemonsAbilitiesDbSources;
    }

    /// <summary>
    /// Returns all the possible abilities
    /// </summary>
    /// <response code="200">All the abilities</response>
    [HttpGet("All")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<AbilityDto> GetAllAbilities()
    {
        return pokemonsAbilitiesDbSources.GetAllAbilities();
    }

    /// <summary>
    /// Create a new ability
    /// </summary>
    /// <param name="dto"></param>
    /// <response code="200">The Created ability</response>
    /// <response code="400">If the ability with given id already exists</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<AbilityDto> CreateAbility(CreateAbilityDto dto)
    {
        var ability = pokemonsAbilitiesDbSources.CreateAbility(dto);

        return Ok(ability);
    }

    /// <summary>
    /// Update a given ability
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <response code="200">The updated ability</response>
    /// <response code="400">If the ability with given id does not exists</response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<AbilityDto> UpdateAbility(int id, UpdateAbilityDto dto)
    {
        var ability = pokemonsAbilitiesDbSources.UpdateAbility(id, dto);

        return Ok(ability);
    }

    /// <summary>
    /// Delete an ability
    /// </summary>
    /// <response code="204">The Deleted Ability</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public void DeleteAbility(int id)
    {
        pokemonsAbilitiesDbSources.DeleteAbility(id);
    }
}
