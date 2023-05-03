using PokeAPIPolytech.Dtos;

namespace PokeAPIPolytech.Services;

public interface IAbilityToPokemonService
{
    PokemonDto Link(PokemonToAbilityDto dto);
    PokemonDto RemoveLink(PokemonToAbilityDto dto);
}