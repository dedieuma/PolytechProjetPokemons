namespace PokeAPIPolytech.Dtos;

public record PokemonToAbilityDto
{
    public int PokemonId { get; init; }
    public int AbilityId { get; init; }
}