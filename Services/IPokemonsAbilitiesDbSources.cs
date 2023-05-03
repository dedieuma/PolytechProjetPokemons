using PokeAPIPolytech.Dtos;
using PokeAPIPolytech.Models;

namespace PokeAPIPolytech.Services;

public interface IPokemonsAbilitiesDbSources
{
    IEnumerable<AbilityDto> GetAllAbilities();
    AbilityDto CreateAbility(CreateAbilityDto dto);
    AbilityDto UpdateAbility(int id, UpdateAbilityDto dto);
    void DeleteAbility(int id);
}