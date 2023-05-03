using PokeAPIPolytech.Models;

namespace PokeAPIPolytech.Dtos;

public record CreatePokemonDto
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
    public PokemonType Type { get; init; }
}